using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace RegExTester
{
    public partial class frmMain : Form
    {
        // constants used in the btnTest's text property to change it's behavior
        private const string STOPPED_MODE_BUTTON_TEXT = "Test [F5]";
        private const string RUNNING_MODE_BUTTON_TEXT = "Stop [Esc]";

        private string _lastFindString = "";       // Used by the Find Next Feature

        private Thread worker; // The worker that really does the execution in a separate thread.

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Setup window's title, status bar and CrossThreadCalls
        /// </summary>
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            // Writting some version information on screen
            this.Text += " - v. " + Application.ProductVersion.ToString();
            sbpContext.Text = "Using CLR v. " + CLRInfos.Version();

            // This is a critical line.
            // It allows the other thread to access the controls of this class/object.
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// Handle Application hotkeys to start and abort the test.
        /// </summary>
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && btnTest.Text == STOPPED_MODE_BUTTON_TEXT && !e.Control && !e.Alt && !e.Shift)
            {
                StartTest();
            }
            else if (e.KeyCode == Keys.Escape && btnTest.Text == RUNNING_MODE_BUTTON_TEXT && !e.Control && !e.Alt && !e.Shift)
            {
                AbortTest();
            }
        }

        /// <summary>
        /// Handle the multiple behaviors of the Test button based on it's text
        /// </summary>
        private void btnTest_Click(object sender, System.EventArgs e)
        {
            if (btnTest.Text == STOPPED_MODE_BUTTON_TEXT)
            {
                StartTest();
            }
            else if (btnTest.Text == RUNNING_MODE_BUTTON_TEXT)
            {
                AbortTest();
            }
        }

        /// <summary>
        /// Prepare and launch the asynchronous execution using the backgroundWorker
        /// </summary>
        private void StartTest()
        {
            sbpStatus.Text = "Creating the Test Thread...";
            // Creates the separate Thread for executing the Test
            worker = new Thread(AsyncTest);

            // After this instruction if the worker hungs and this thread exits then nobody has to
            // wait for the worker to finish. (e.g. The worker will be aborted if the user wants to close the app.)
            worker.IsBackground = true;

            // Start the Asynchronous Test function
            worker.Start();
        }

        /// <summary>
        /// Instructs to abort the asynchronous execution of the Test.
        /// </summary>
        private void AbortTest()
        {
            // This generates a ThreadAbortException at the worker function AsyncTest()
            if (worker.IsAlive) worker.Abort();
        }

        /// <summary>
        /// This is the core of the app. The RegEx execution and processing function.
        /// It's being run on a separated thread.
        /// </summary>
        private void AsyncTest()
        {
            // Every line in this function is susceptible of a ThreadAbortException
            // Which is how the user is able to stop it.
            try
            {
                sbpStatus.Text = "Making UI adjustments...";
                // For performance reasons I have to ensure that the rtbText control doesn't have focus
                bool restoreRtbTextFocus = rtbText.Focused;
                if (rtbText.Focused) btnTest.Focus();

                // Change the btnText functionality
                btnTest.Text = RUNNING_MODE_BUTTON_TEXT;

                sbpStatus.Text = "Preparing the RegEx options...";
                // Create the options object based on the UI checkboxes
                RegexOptions regexOptions = new RegexOptions();
                if (cbIgnoreCase.Checked) regexOptions |= RegexOptions.IgnoreCase;
                if (cbMultiLine.Checked) regexOptions |= RegexOptions.Multiline;
                if (cbSingleLine.Checked) regexOptions |= RegexOptions.Singleline;
                if (cbCultureInvariant.Checked) regexOptions |= RegexOptions.CultureInvariant;

                sbpStatus.Text = "Preparing the RegEx string...";
                // Create the RegEx string with optional manipulations
                string regexString = txtRegEx.Text;
                if (cbIndentedInput.Checked) regexString = stripIndentation(regexString);

                sbpStatus.Text = "Creating the RegEx Engine and parsing the RegEx string...";
                // Creates the RegEx engine passing the RegEx string and the options object
                Regex regex = new Regex(regexString, regexOptions);

                sbpStatus.Text = "Evaluating the RegEx against the Test Text...";
                // This executes the Regex and collects the results
                // The execution isn't done until a member of the matchCollection is read.
                // So I read the Count property for the regex to really execute from start to finish
                MatchCollection matchCollection = regex.Matches(rtbText.Text);
                int matchesCount = matchCollection.Count;

                sbpStatus.Text = "Preparing the Results grid...";
                // Setup the results ListView
                lvResult.Items.Clear();
                lvResult.Clear();
                lvResult.Columns.Add("Match", 408, HorizontalAlignment.Left);
                lvResult.Columns.Add("Position", 87, HorizontalAlignment.Left);
                lvResult.Columns.Add("Lenght", 98, HorizontalAlignment.Left);

                // Add the Capture Group columns to the Results ListView
                int[] groupNumbers = regex.GetGroupNumbers();
                string[] groupNames = regex.GetGroupNames();
                string groupName = null;

                foreach (int groupNumber in groupNumbers)
                {
                    if (groupNumber > 0)
                    {
                        groupName = "Group " + groupNumber;
                        if (groupNames[groupNumber] != groupNumber.ToString()) groupName += " (" + groupNames[groupNumber] + ")";
                        lvResult.Columns.Add(groupName, 100, HorizontalAlignment.Left);
                    }
                }

                sbpStatus.Text = "Preparing the Test textbox...";
                // Store/Backup the user's cursor and selection on the RichTextBox
                int rtbSelectionStart = rtbText.SelectionStart;
                int rtbSelectionLength = rtbText.SelectionLength;

                // Reset previous highligths in the RichTextBox and save current position.
                rtbText.SelectAll();
                rtbText.SelectionColor = Color.Black;

                // This pauses the Result ListView drawing to speed-up the process
                lvResult.BeginUpdate();

                sbpStatus.Text = "Processing the " + matchesCount + " matchs...";
                // Process each of the Matches!
                foreach (Match match in matchCollection)
                {
                    //Add it to the grid
                    ListViewItem lvi = lvResult.Items.Add(match.ToString());
                    lvi.SubItems.Add(match.Index.ToString());
                    lvi.SubItems.Add(match.Length.ToString());
                    for (int c = 1; c < match.Groups.Count; c++)
                    {
                        lvi.SubItems.Add(match.Groups[c].Value);
                    }

                    //Highligth the match in the RichTextBox
                    rtbText.Select(match.Index, match.Length);
                    rtbText.SelectionColor = Color.Red;
                }

                // This turns off the Result ListView drawing pause. Now it's drawed again.
                lvResult.EndUpdate();

                // Restore RichTextBox's cursor position to the original user's position
                rtbText.Select(rtbSelectionStart, rtbSelectionLength);

                // This reverts the performance adjustments
                if (restoreRtbTextFocus) rtbText.Focus();

                sbpStatus.Text = "Test success. Processed " + matchesCount + " matches.";
            }
            catch (ThreadAbortException)
            {
                sbpStatus.Text = "Test aborted by the user.";
            }
            catch (Exception e)
            {
                sbpStatus.Text = "Test aborted by an error.";
                // Any other Exception is shown to the user
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restore the btnText functionality
                btnTest.Text = STOPPED_MODE_BUTTON_TEXT;

                // This turns off the Result ListView drawing pause. Now it's drawed again.
                lvResult.EndUpdate();
            }
        }

        /// <summary>
        /// Show the matched text on the rtbText when the user clicks on a match in the ListView
        /// </summary>
        private void lvResult_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lvResult.SelectedItems.Count == 0) return;

            rtbText.HideSelection = false;
            rtbText.Select(0, 0);

            int position = Convert.ToInt32(lvResult.SelectedItems[0].SubItems[1].Text);
            int lenght = Convert.ToInt32(lvResult.SelectedItems[0].SubItems[2].Text);

            rtbText.Select(position, lenght);
        }

        /// <summary>
        /// Changes the multi-line properties of the RegEx control
        /// </summary>
        private void cbIndentedInput_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIndentedInput.Checked)
            {
                //why is it that the textbox changes it's height by itself when i change it's multiline property? 
                // I have to reset it in order to not mix up the splitter control.
                int originalHeight = txtRegEx.Height;
                txtRegEx.Multiline = true;
                txtRegEx.Height = originalHeight;

                txtRegEx.AcceptsTab = true;
                txtRegEx.ScrollBars = ScrollBars.Vertical;

                splitContainer.IsSplitterFixed = false;
                splitContainer.SplitterDistance = 150;
            }
            else
            {
                int originalHeight = txtRegEx.Height;
                txtRegEx.Multiline = false;
                txtRegEx.Height = originalHeight;

                txtRegEx.AcceptsTab = false;
                txtRegEx.ScrollBars = ScrollBars.None;
                txtRegEx.Text = stripIndentation(txtRegEx.Text);

                splitContainer.SplitterDistance = 90;
                splitContainer.IsSplitterFixed = true;
            }
        }

        /// <summary>
        /// This function removes the \r \n \t \v and ' ' from any string
        /// It's used at StartTest, cbIndentedInput_CheckedChanged and copyGenericTSMenuItem_Click
        /// </summary>
        /// <param name="text">The indented string to be stripped off</param>
        /// <returns>A single-line version of the input text stripped of tabs and spaces</returns>
        private string stripIndentation(string text)
        {
            return text.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("\v", "").Replace(" ", "");
        }

        #region The Copy Feature implementation

        /// <summary>
        /// Show the Copy Feature context menu with all the formating options.
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            btnCopyContextMenuStrip.Show(btnCopy, new Point(0, btnCopy.Height));
        }

        /// <summary>
        /// This function handles all the Copy context menu options.
        /// Formats the regex and copies it to the clipboard
        /// </summary>
        private void copyGenericTSMenuItem_Click(object sender, EventArgs e)
        {
            // Grab the original text
            string regex = txtRegEx.Text;

            // Optionally apply the stripIndentation funcion
            if (cbIndentedInput.Checked) regex = stripIndentation(regex);

            // I used the Tag attribute of each MenuItem to now identify which was pressed
            string format = ((ToolStripMenuItem)sender).Tag.ToString();
            if (format == "cs") 
            {
                regex = "@\"" + regex.Replace("\"", "\"\"") + "\""; //change  my"quo\te  to  @"my""quo\te"
            }
            else if (format == "html") 
            {
                regex = System.Web.HttpUtility.HtmlEncode(regex);
            }

            // Copy it to the clipboard. Clipboard.SetText fails if regex is ""
            if (!string.IsNullOrEmpty(regex)) Clipboard.SetText(regex);
        }

        #endregion

        #region Help links, Web Links and About
        
        private void llAbout_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            frmAbout af = new frmAbout();
            af.ShowDialog();
            af.Dispose();
        }

        private void llIgnoreCase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This option makes the RegEx case-insensitive which means that 'a' and 'A' are treated as the same letter.", "Ignore Case Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void llCultureInvariant_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("If you use the Ignore Case Option you should always keep in mind the Culture Invariant Option because (\"file\" == \"FILE\") is True for many cultures (e.g. en-US) but it's False on some of them (e.g. tr-TR Turkish). Turning On this option is generally safer.", "Culture Invariant Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void llMultiLine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This option makes ^ and $ match beginning and end of each line insted of the beginning and end of the whole text.", "Treat as Multi Line Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void llSingleLine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This option makes . match every character including newline.", "Treat as Single Line Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void llIndentedInput_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"If you activate this option the RegEx will be stripped of \r \n \t \v and spaces before execution. This allows you to write thouse ugly, long and cryptic RegEx in an indented and spaced fashion.", "Indented Input Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void llRegExLibrary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("This would open the uri http://regexlib.com/ in your default browser.", "RegEx Library", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Process.Start("http://regexlib.com/");
        }

        private void llRegExCheatSheet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("This would open the uri http://www.ilovejackdaniels.com/cheat-sheets/regular-expressions-cheat-sheet/ in your default browser.", "RegEx CheatSheet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Process.Start("http://www.ilovejackdaniels.com/cheat-sheets/regular-expressions-cheat-sheet/");
            
        }

        #endregion

        #region rtbText ContextMenuEvents

        private void undoTSMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.Undo();
        }

        private void redoTSMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.Redo();
        }

        private void cutTSMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.Copy();
        }

        private void pasteTSMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.Paste();
        }

        private void deleteTSMenuItem_Click(object sender, EventArgs e)
        {
            // I had to use this approach because the rtb doen't have a Delection-Delete function.
            SendKeys.Send("{DEL}"); // Delete key
        }

        private void findTSMenuItem_Click(object sender, EventArgs e)
        {
            string findString = Microsoft.VisualBasic.Interaction.InputBox("Insert text to find...", "Find Function", _lastFindString, -1, -1);

            if (string.IsNullOrEmpty(findString)) return;
            int position = rtbText.Find(findString, 0, RichTextBoxFinds.None);
            if (position == -1)
            {
                MessageBox.Show("Text not found", "Find Function", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                rtbText.Select(position, findString.Length);
                _lastFindString = findString;
            }
        }

        private void findNextTSMenuItem_Click(object sender, EventArgs e)
        {
            string findString = _lastFindString;

            if (string.IsNullOrEmpty(findString)) return;
            int position = rtbText.Find(findString, rtbText.SelectionStart + rtbText.SelectionLength, RichTextBoxFinds.None);
            if (position == -1)
            {
                MessageBox.Show("No more occurrences found", "Find Next Function", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                rtbText.Select(position, findString.Length);
            }
        }

        private void selectAllTSMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.SelectAll();
        }

        #endregion

    }
}
