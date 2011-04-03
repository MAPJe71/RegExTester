using System;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;

namespace RegExTester
{
    public partial class frmMain : Form
    {
        // constants used in the btnTest's text property to change it's behavior
        private const string STOPPED_MODE_BUTTON_TEXT = "Test [F5]";
        private const string RUNNING_MODE_BUTTON_TEXT = "Stop [Esc]";

        private Thread worker; // The worker that really does the execution in a separate thread.

        public frmMain()
        {
            InitializeComponent();
            ActiveControl = txtRegEx;
        }

        /// <summary>
        /// Setup window's title, status bar and CrossThreadCalls
        /// </summary>
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            // Writting some version information on screen
            this.Text += " - v" + Application.ProductVersion.ToString();
            sbpContext.Text = string.Format("CLR {0}.{1}", Environment.Version.Major, Environment.Version.Minor);

            // This is a critical line.
            // It allows the other thread to access the controls of this class/object.
            Control.CheckForIllegalCrossThreadCalls = false;

            // This sets the initial UI with Replace Mode Off
            cbReplaceMode.Checked = false;
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
        /// Prepare and launch the asynchronous execution using another thread
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
            if (worker.IsAlive) 
                worker.Abort();
        }

        /// <summary>
        /// This is the core of the app. The RegEx execution and processing function.
        /// It's being run on a separated thread.
        /// </summary>
        private void AsyncTest()
        {
            int rtbSelectionStart = int.MinValue;
            int rtbSelectionLength = int.MinValue;
            int matchesFound = 0;
            int matchesProcessed = 0;
            DateTime startMoment = DateTime.Now;

            // Every line in this function is susceptible of a ThreadAbortException
            // Which is how the user is able to stop it.
            try
            {
                // Adjustments in the UI
                sbpStatus.Text = "Making UI Adjustments...";
                btnTest.Text = RUNNING_MODE_BUTTON_TEXT;
                sbpMatches.Text = string.Empty;
                sbpExecutionTime.Text = string.Empty;

                // Create the options object based on the UI checkboxes
                sbpStatus.Text = "Configuring the RegEx engine...";
                RegexOptions regexOptions = new RegexOptions();
                if (cbIgnoreCase.Checked) regexOptions |= RegexOptions.IgnoreCase;
                if (cbCultureInvariant.Checked) regexOptions |= RegexOptions.CultureInvariant;
                if (cbMultiLine.Checked) regexOptions |= RegexOptions.Multiline;
                if (cbSingleLine.Checked) regexOptions |= RegexOptions.Singleline;
                if (cbIndentedInput.Checked) regexOptions |= RegexOptions.IgnorePatternWhitespace;

                sbpStatus.Text = "Creating the RegEx Engine and parsing the RegEx string...";
                // Creates the RegEx engine passing the RegEx string and the options object
                Regex regex = new Regex(txtRegEx.Text, regexOptions);

                sbpStatus.Text = "Evaluating the RegEx against the Test Text...";
                // This executes the Regex and collects the results
                // The execution isn't done until a member of the matchCollection is read.
                // So I read the Count property for the regex to really execute from start to finish
                MatchCollection matchCollection = regex.Matches(rtbText.Text);
                matchesFound = matchCollection.Count;

                // Also do the RegEx replacement if the user asked for it
                if (cbReplaceMode.Checked)
                {
                    sbpStatus.Text = "Evaluating the RegEx Replace against the Test Text...";
                    rtbResults.Text = regex.Replace(rtbText.Text, txtRepEx.Text);
                }

                sbpStatus.Text = "Preparing the Results grid...";
                // Setup the results ListView
                lvResult.Items.Clear();
                for (int i = lvResult.Columns.Count; i > 3; i--) //Skip the first 3 columns
                    lvResult.Columns.RemoveAt(i-1);   

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

                // Store/Backup the user's cursor and selection on the RichTextBox
                rtbSelectionStart = rtbText.SelectionStart;
                rtbSelectionLength = rtbText.SelectionLength;

                // This pauses the drawing to speed-up the work
                rtbText.SuspendLayout();
                lvResult.SuspendLayout();
                lvResult.BeginUpdate();

                // Reset previous highligths in the RichTextBox and save current position.
                rtbText.SelectAll();
                rtbText.SelectionColor = Color.Black;

                sbpStatus.Text = "Processing the " + matchesFound + " matchs...";
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

                    matchesProcessed++;
                }

                sbpStatus.Text = "Test success.";
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

                // Restore RichTextBox's cursor position to the original user's position
                if (rtbSelectionStart != int.MinValue && rtbSelectionLength != int.MinValue)
                    rtbText.Select(rtbSelectionStart, rtbSelectionLength);

                if (matchesProcessed == matchesFound)
                    sbpMatches.Text = string.Format("{0} match(es).", matchesProcessed);
                else
                    sbpMatches.Text = string.Format("{0} match(es) of {1} found.", matchesProcessed, matchesFound);


                // Calculate execution time
                TimeSpan executionTimeSpan = DateTime.Now.Subtract(startMoment);
                if (executionTimeSpan.TotalHours > 1) sbpExecutionTime.Text = string.Format("{0} hs.", executionTimeSpan.TotalHours.ToString("##.##"));
                else if (executionTimeSpan.TotalMinutes > 1) sbpExecutionTime.Text = string.Format("{0} mins.", executionTimeSpan.TotalMinutes.ToString("##.##"));
                else if (executionTimeSpan.TotalSeconds > 1) sbpExecutionTime.Text = string.Format("{0} s.", executionTimeSpan.TotalSeconds.ToString("##.##"));
                else if (executionTimeSpan.TotalMilliseconds > 1) sbpExecutionTime.Text = string.Format("{0} ms.", executionTimeSpan.TotalMilliseconds.ToString("#"));

                // This reverts the rendering of the controls (turned off for performance)
                lvResult.EndUpdate();
                lvResult.ResumeLayout();
                rtbText.ResumeLayout();
            }
        }

        /// <summary>
        /// Show the matched text on the rtbText when the user clicks on a match in the ListView
        /// </summary>
        private void lvResult_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lvResult.SelectedItems.Count == 0) return;

            rtbText.Select(0, 0);

            int position = Convert.ToInt32(lvResult.SelectedItems[0].SubItems[1].Text);
            int length = Convert.ToInt32(lvResult.SelectedItems[0].SubItems[2].Text);

            rtbText.Select(position, length);
        }

        #region IndentedInput and ReplaceMode UI adjustments

        /// <summary>
        /// Changes the multi-line properties of the RegEx control
        /// </summary>
        private void cbIndentedInput_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIndentedInput.Checked)
            {
                txtRegEx.Multiline = txtRepEx.Multiline = true;
                txtRegEx.AcceptsTab = txtRepEx.AcceptsTab = true;
                txtRegEx.ScrollBars = txtRepEx.ScrollBars = ScrollBars.Vertical;

                spctTopAndMiddle.IsSplitterFixed = false;
                spctTopAndMiddle.SplitterDistance = 160;
            }
            else
            {
                txtRegEx.Multiline = txtRepEx.Multiline = false;
                txtRegEx.AcceptsTab = txtRepEx.AcceptsTab = false;
                txtRegEx.ScrollBars = txtRepEx.ScrollBars = ScrollBars.None;

                spctTopAndMiddle.SplitterDistance = 100;
                spctTopAndMiddle.IsSplitterFixed = true;
            }
        }

        /// <summary>
        /// Reveals the two textboxes which enable Replace features
        /// </summary>
        private void cbReplaceMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbReplaceMode.Checked)
            {
                spctRegExAndRepEx.Panel2Collapsed = false;
                spctTextAndResults.Panel2Collapsed = false;
                btnRegExCheatSheet.Visible = false;
                btnRegExLibrary.Visible = false;
                btnAbout.Visible = false;
            }
            else
            {
                spctRegExAndRepEx.Panel2Collapsed = true;
                spctTextAndResults.Panel2Collapsed = true;
                btnRegExCheatSheet.Visible = true;
                btnRegExLibrary.Visible = true;
                btnAbout.Visible = true;
            }
        }

        #endregion

        #region Copy Feature implementation

        /// <summary>
        /// Show the Copy Feature context menu with all the formating options.
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            cmsCopyButton.Show(btnCopy, new Point(0, btnCopy.Height));
        }

        /// <summary>
        /// This function handles all the Copy context menu options.
        /// Formats the regex and copies it to the clipboard
        /// </summary>
        private void tsmiCopyGeneric_Click(object sender, EventArgs e)
        {
            // Grab the original text
            string regex = txtRegEx.Text;

            // I used the Tag attribute of each MenuItem to now identify which was pressed
            string format = ((ToolStripMenuItem)sender).Tag.ToString();
            
            if (format == "html") 
            {
                regex = System.Web.HttpUtility.HtmlEncode(regex);
            }
            else if (format.StartsWith("csharp")) 
            {
                regex = string.Format("@\"{0}\"", regex.Replace("\"", "\"\"")); //change  my"quo\te  to  @"my""quo\te"

                if (format.EndsWith("snippet"))
                {
                    StringBuilder regexsb = new StringBuilder();
                    regexsb.Append("Regex regex = new Regex(");
                    if (cbIndentedInput.Checked && regex.Contains("\n"))
                    {
                        regexsb.Append("\r\n    ");
                        regexsb.Append(Regex.Replace(regex, @"\r?\n", "$0    ", RegexOptions.Singleline));
                    } 
                    else
                        regexsb.Append(regex);

                    if (cbIgnoreCase.Checked || cbMultiLine.Checked || cbSingleLine.Checked || cbCultureInvariant.Checked || cbIndentedInput.Checked)
                    {
                        regexsb.Append(", ");
                        if (cbIndentedInput.Checked && regex.Contains("\n"))
                            regexsb.Append("\r\n    ");
                        if (cbIgnoreCase.Checked) regexsb.Append("RegexOptions.IgnoreCase | ");
                        if (cbCultureInvariant.Checked) regexsb.Append("RegexOptions.CultureInvariant | ");
                        if (cbMultiLine.Checked) regexsb.Append("RegexOptions.Multiline | ");
                        if (cbSingleLine.Checked) regexsb.Append("RegexOptions.Singleline | ");
                        if (cbIndentedInput.Checked) regexsb.Append("RegexOptions.IgnorePatternWhitespace | ");
                        regexsb.Remove(regexsb.Length - 3, 3);// 3 = len(" | ")
                    }
                    regexsb.AppendLine(");");
                    regexsb.AppendLine("MatchCollection matchCollection = regex.Matches( [Target_string] );");
                    regexsb.AppendLine("foreach (Match match in matchCollection)");
                    regexsb.AppendLine("{");
                    regexsb.AppendLine("    do some work;");
                    regexsb.AppendLine("}");

                    regex = regexsb.ToString();
                }
            }

            // Copy it to the clipboard. Clipboard.SetText fails if regex is ""
            if (!string.IsNullOrEmpty(regex)) Clipboard.SetText(regex);
        }

        #endregion

        #region Help links, Web Links and About
        
        private void btnIgnoreCase_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option makes the RegEx case-insensitive which means that 'a' and 'A' are treated as the same letter.", "Ignore Case Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCultureInvariant_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you use the Ignore Case Option you should always keep in mind the Culture Invariant Option because (\"file\" == \"FILE\") is True for many cultures (e.g. en-US) but it's False on some of them (e.g. tr-TR Turkish). Turning On this option is generally safer.", "Culture Invariant Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMultiLine_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option makes ^ and $ match beginning and end of each line insted of the beginning and end of the whole text.", "Treat as Multi Line Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSingleLine_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option makes . match every character including newline.", "Treat as Single Line Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnIndentedInput_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"If you activate this option the RegEx will be stripped of \r \n \t \v and spaces before execution. This allows you to write thouse ugly, long and cryptic RegEx in an indented and spaced fashion. The whitespace characters still works inside character classes.", "Indented Input Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReplaceMode_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"You will be able to test a RegEx replacement expression. Remember that $0 represents the match and $N represents the Nth capture group.", "RegEx Replace Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRegExLibrary_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This would open the uri http://regexlib.com/ in your default browser.", "RegEx Library", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Process.Start("http://regexlib.com/");
        }

        private void btnRegExCheatSheet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This would open the uri http://www.addedbytes.com/cheat-sheets/regular-expressions-cheat-sheet/ in your default browser.", "RegEx CheatSheet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Process.Start("http://www.addedbytes.com/cheat-sheets/regular-expressions-cheat-sheet/");
            
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            frmAbout af = new frmAbout();
            af.ShowDialog();
            af.Dispose();
        }

        #endregion

		private void exportResultsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (lvResult.Items.Count < 1)
			{
				MessageBox.Show("There are no results to export.", "Export failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (exportSaveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StringBuilder sb = new StringBuilder();
				bool firstColumn = true;

				foreach (ColumnHeader columnHeader in lvResult.Columns)
				{
					if (!firstColumn)
					{
						sb.Append(",");
					}

					sb.AppendFormat("\"{0}\"", columnHeader.Text);

					firstColumn = false;
				}

				sb.AppendLine();

				firstColumn = true;

				foreach (ListViewItem listViewItem in lvResult.Items)
				{
					foreach (ListViewItem.ListViewSubItem listViewSubItem in listViewItem.SubItems)
					{
						if (!firstColumn)
						{
							sb.Append(",");
						}

						sb.AppendFormat("\"{0}\"", listViewSubItem.Text);

						firstColumn = false;
					}

					sb.AppendLine();

					firstColumn = true;
				}


				File.WriteAllText(exportSaveFileDialog.FileName, sb.ToString());

				sbpStatus.Text = "Export saved";
			}
		}

    }
}
