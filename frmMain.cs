using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RegExTester
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Setup application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            Version version = new Version(Application.ProductVersion);
            this.Text = "RegEx Tester v. " + version.ToString();

            sbpInfo.Text = "Using CLR v. " + CLRInfos.Version();
            sbpMatchCount.Text = "Nothing searched yet.";
        }

        /// <summary>
        /// Handle F5 Application hotkey
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && !e.Control && !e.Alt && !e.Shift && btnTest.Enabled)
            {
                if (rtbText.Focused)
                {
                    // Never do the test with the focus on the rtbText because the test makes selections inside it to make highligths
                    // and when the focus is in there the performance of the test decreases a lot.
                    btnTest.Focus();
                    DoTest();
                    rtbText.Focus();
                }
                else
                {
                    DoTest();
                }
            }
        }

        /// <summary>
        /// Handle click on "Test" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, System.EventArgs e)
        {
            DoTest();
            btnTest.Focus();
        }

        /// <summary>
        /// Handle click on "Copy" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            string regex = txtRegEx.Text;

            //If it's manipulated on execution I should also manipulate it in the same way 
            // so the copy button makes an trully equivalent regex string.
            if (cbIndentedInput.Checked) 
                regex = stripIndentation(regex);

            if (regex.Contains("\""))
            {
                // Have to escape it - can't use a literal string
                regex = regex.Replace(@"\", @"\\").Replace("\"", "\\\"");
                Clipboard.SetText("\"" + regex + "\"");
            }
            else
            {
                Clipboard.SetText("@\"" + regex + "\"");
            }

        }

        private string stripIndentation(string text)
        {
            return text.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("\v", "").Replace(" ", "");
        }

        /// <summary>
        /// Perform Regular Expression Test
        /// </summary>
        private void DoTest()
        {
            // Block the Test button
            btnTest.Text = "Testing....";
            btnTest.Enabled = false;

            // Setup options
            RegexOptions ro = new RegexOptions();
            if (cbIgnoreCase.Checked) ro |= RegexOptions.IgnoreCase;
            if (cbMultiLine.Checked) ro |= RegexOptions.Multiline;
            if (cbSingleLine.Checked) ro |= RegexOptions.Singleline;
            if (cbCultureInvariant.Checked) ro |= RegexOptions.CultureInvariant;

            // Create Regular Expression Engine
            Regex re = null;
            MatchCollection mc = null;

            // Prepare the RegEx with optional manipulations
            string regex = txtRegEx.Text;
            if (cbIndentedInput.Checked)
                regex = stripIndentation(regex);

            // Execute the RegEx and retrive the results. This could fail
            try
            {
                re = new Regex(regex, ro);
                mc = re.Matches(rtbText.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Unblock the Test button
                btnTest.Text = "Test";
                btnTest.Enabled = true;

                return;
            }

            // Setup ListView
            lvResult.Items.Clear();
            lvResult.Clear();
            lvResult.Columns.Add("Match", 408, HorizontalAlignment.Left);
            lvResult.Columns.Add("Position", 87, HorizontalAlignment.Left);
            lvResult.Columns.Add("Lenght", 98, HorizontalAlignment.Left);

            // Add the Capture Group columns to the Results ListView
            int[] groupNumbers = re.GetGroupNumbers();
            string[] groupNames = re.GetGroupNames();
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

            // Reset previous highligths in the RichTextBox and save current position.
            int rtbSelectionStart = rtbText.SelectionStart;
            int rtbSelectionLength = rtbText.SelectionLength;
            rtbText.HideSelection = true;
            rtbText.SelectAll();
            rtbText.SelectionColor = Color.Black;

            // Process the Matches!
            foreach (Match m in mc)
            {

                //Add it to the grid
                ListViewItem lvi = lvResult.Items.Add(m.ToString());
                lvi.SubItems.Add(m.Index.ToString());
                lvi.SubItems.Add(m.Length.ToString());
                for (int c = 1; c < m.Groups.Count; c++)
                {
                    lvi.SubItems.Add(m.Groups[c].Value);
                }

                //Highligth the match in the RichTextBox
                rtbText.Select(m.Index, m.Length);
                rtbText.SelectionColor = Color.Red;
            }

            // Reset RichTextBox
            rtbText.Select(rtbSelectionStart, rtbSelectionLength);

            // Show matching count
            sbpMatchCount.Text = "Match count: " + mc.Count.ToString();

            // Unblock the Test button
            btnTest.Text = "Test [F5]";
            btnTest.Enabled = true;
        }

        /// <summary>
        /// Handle click on a match result row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

    }
}
