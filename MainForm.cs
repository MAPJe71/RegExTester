using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using System.Reflection;

namespace RegExTester {
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form {
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.RichTextBox rtbText;
		private System.Windows.Forms.Label lblText;
		private System.Windows.Forms.TextBox txtRegEx;
		private System.Windows.Forms.Label lblRegEx;
		private System.Windows.Forms.ListView lvResult;
		private System.Windows.Forms.ColumnHeader chMatch;
		private System.Windows.Forms.ColumnHeader chPosition;
		private System.Windows.Forms.ColumnHeader chLenght;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel sbpMatchCount;
		private System.Windows.Forms.StatusBarPanel sbpInfo;
		private System.Windows.Forms.CheckBox cbIgnoreCase;
		private System.Windows.Forms.CheckBox cbMultiline;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel llAbout;
        private Button buttonCopy;
        private CheckBox cbSingleLine;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnTest = new System.Windows.Forms.Button();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.txtRegEx = new System.Windows.Forms.TextBox();
            this.lblRegEx = new System.Windows.Forms.Label();
            this.lvResult = new System.Windows.Forms.ListView();
            this.chMatch = new System.Windows.Forms.ColumnHeader();
            this.chPosition = new System.Windows.Forms.ColumnHeader();
            this.chLenght = new System.Windows.Forms.ColumnHeader();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.sbpInfo = new System.Windows.Forms.StatusBarPanel();
            this.sbpMatchCount = new System.Windows.Forms.StatusBarPanel();
            this.cbIgnoreCase = new System.Windows.Forms.CheckBox();
            this.cbMultiline = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.llAbout = new System.Windows.Forms.LinkLabel();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.cbSingleLine = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.sbpInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpMatchCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(3, 51);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 9;
            this.btnTest.Text = "Test";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // rtbText
            // 
            this.rtbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbText.HideSelection = false;
            this.rtbText.Location = new System.Drawing.Point(3, 103);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(857, 134);
            this.rtbText.TabIndex = 8;
            this.rtbText.Text = "";
            this.rtbText.WordWrap = false;
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(0, 84);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(624, 16);
            this.lblText.TabIndex = 7;
            this.lblText.Text = "Text";
            // 
            // txtRegEx
            // 
            this.txtRegEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegEx.Location = new System.Drawing.Point(3, 24);
            this.txtRegEx.Name = "txtRegEx";
            this.txtRegEx.Size = new System.Drawing.Size(857, 21);
            this.txtRegEx.TabIndex = 6;
            // 
            // lblRegEx
            // 
            this.lblRegEx.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegEx.Location = new System.Drawing.Point(0, 8);
            this.lblRegEx.Name = "lblRegEx";
            this.lblRegEx.Size = new System.Drawing.Size(624, 16);
            this.lblRegEx.TabIndex = 5;
            this.lblRegEx.Text = "Regular Expression";
            // 
            // lvResult
            // 
            this.lvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chMatch,
            this.chPosition,
            this.chLenght});
            this.lvResult.FullRowSelect = true;
            this.lvResult.GridLines = true;
            this.lvResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvResult.Location = new System.Drawing.Point(3, 264);
            this.lvResult.MultiSelect = false;
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(857, 252);
            this.lvResult.TabIndex = 10;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.View = System.Windows.Forms.View.Details;
            this.lvResult.SelectedIndexChanged += new System.EventHandler(this.lvResult_SelectedIndexChanged);
            // 
            // chMatch
            // 
            this.chMatch.Text = "Match";
            this.chMatch.Width = 435;
            // 
            // chPosition
            // 
            this.chPosition.Text = "Position";
            this.chPosition.Width = 87;
            // 
            // chLenght
            // 
            this.chLenght.Text = "Lenght";
            this.chLenght.Width = 98;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 522);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbpInfo,
            this.sbpMatchCount});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(864, 22);
            this.statusBar1.TabIndex = 12;
            this.statusBar1.Text = "statusBar1";
            // 
            // sbpInfo
            // 
            this.sbpInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbpInfo.Name = "sbpInfo";
            this.sbpInfo.Width = 766;
            // 
            // sbpMatchCount
            // 
            this.sbpMatchCount.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.sbpMatchCount.Name = "sbpMatchCount";
            this.sbpMatchCount.Text = "Match Count:";
            this.sbpMatchCount.Width = 81;
            // 
            // cbIgnoreCase
            // 
            this.cbIgnoreCase.Checked = true;
            this.cbIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIgnoreCase.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbIgnoreCase.Location = new System.Drawing.Point(263, 51);
            this.cbIgnoreCase.Name = "cbIgnoreCase";
            this.cbIgnoreCase.Size = new System.Drawing.Size(104, 24);
            this.cbIgnoreCase.TabIndex = 13;
            this.cbIgnoreCase.Text = "Ignore Case";
            // 
            // cbMultiline
            // 
            this.cbMultiline.Checked = true;
            this.cbMultiline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMultiline.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbMultiline.Location = new System.Drawing.Point(373, 51);
            this.cbMultiline.Name = "cbMultiline";
            this.cbMultiline.Size = new System.Drawing.Size(420, 24);
            this.cbMultiline.TabIndex = 14;
            this.cbMultiline.Text = "Treat as Multiline (^ and $ match beginning and end of lines)";
            this.cbMultiline.CheckedChanged += new System.EventHandler(this.cbMultiline_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(624, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Results";
            // 
            // llAbout
            // 
            this.llAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llAbout.Location = new System.Drawing.Point(740, 5);
            this.llAbout.Name = "llAbout";
            this.llAbout.Size = new System.Drawing.Size(120, 16);
            this.llAbout.TabIndex = 16;
            this.llAbout.TabStop = true;
            this.llAbout.Text = "About This Program";
            this.llAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAbout_LinkClicked);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(84, 51);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 17;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // cbSingleLine
            // 
            this.cbSingleLine.Checked = true;
            this.cbSingleLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSingleLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbSingleLine.Location = new System.Drawing.Point(373, 73);
            this.cbSingleLine.Name = "cbSingleLine";
            this.cbSingleLine.Size = new System.Drawing.Size(420, 24);
            this.cbSingleLine.TabIndex = 18;
            this.cbSingleLine.Text = "Treat as Single Line (. matches every character including newline)";
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(864, 544);
            this.Controls.Add(this.cbSingleLine);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.llAbout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMultiline);
            this.Controls.Add(this.cbIgnoreCase);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.lvResult);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtRegEx);
            this.Controls.Add(this.lblRegEx);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegEx Tester";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sbpInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpMatchCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
            Application.EnableVisualStyles();
		    Application.Run(new MainForm());
		}

		/// <summary>
		/// Handle click on "Test" button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTest_Click(object sender, System.EventArgs e) {
			btnTest.Text = "Testing....";
			btnTest.Enabled = false;

			DoTest();

			btnTest.Text = "Test";
			btnTest.Enabled = true;
		}

		/// <summary>
		/// Perform Regular Expression Test
		/// </summary>
		private void DoTest() {
			// Setup options
			RegexOptions ro = new RegexOptions();
			if (cbIgnoreCase.Checked) ro |= RegexOptions.IgnoreCase;
			if (cbMultiline.Checked) ro |= RegexOptions.Multiline;
            if (cbSingleLine.Checked) ro |= RegexOptions.Singleline;

			// Create Regular Expression Engine
			Regex re = null;
			MatchCollection mc = null;
			try {
				re = new Regex(txtRegEx.Text, ro);
				mc = re.Matches(rtbText.Text);
			} 
			catch (Exception ex){
				MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Setup ListView
			int[] ag = re.GetGroupNumbers();

			lvResult.Clear();

			lvResult.Columns.Add("Match", 435, HorizontalAlignment.Left);
			lvResult.Columns.Add("Position", 87, HorizontalAlignment.Left);
			lvResult.Columns.Add("Lenght", 98, HorizontalAlignment.Left);

			foreach(int c in ag) {
				if (c > 0)
					lvResult.Columns.Add("Group " + c.ToString(), 100, HorizontalAlignment.Left);
			}
			
			lvResult.Items.Clear();

			// Setup RichTextBox
			rtbText.HideSelection = true;
			rtbText.SelectAll();
			rtbText.SelectionColor = Color.Black;

			// Match!
			foreach(Match m in mc) {
				ListViewItem lvi = lvResult.Items.Add(m.ToString());

				lvi.SubItems.Add(m.Index.ToString());
				lvi.SubItems.Add(m.Length.ToString());
				
				for (int c=1; c<m.Groups.Count; c++) {
					lvi.SubItems.Add(m.Groups[c].Value);
				}

				rtbText.Select(m.Index, m.Length);
				rtbText.SelectionColor = Color.Red;
			}

			// Reset RichTextBox
			rtbText.Select(0,0);
			rtbText.SelectionColor = Color.Black;

			// Show matching count
			sbpMatchCount.Text = "Match count: " + mc.Count.ToString();
		}

		/// <summary>
		/// Setup application
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Load(object sender, System.EventArgs e) {
			Assembly ea = Assembly.GetExecutingAssembly();
			this.Text = "RegExTest v." +  ea.GetName().Version.ToString();

			sbpInfo.Text = "Using CLR v. " + CLRInfos.Version();
			sbpMatchCount.Text = "Nothing searched yet.";
		}

		/// <summary>
		/// Handle click on a match result row
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lvResult_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (lvResult.SelectedItems.Count == 0) return;

			rtbText.HideSelection = false;
			rtbText.Select(0, 0);

			int position = Convert.ToInt32(lvResult.SelectedItems[0].SubItems[1].Text);
			int lenght = Convert.ToInt32(lvResult.SelectedItems[0].SubItems[2].Text);

			rtbText.Select(position, lenght);
		}

		/// <summary>
		/// Handle click 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void llAbout_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
			FormAbout af = new FormAbout();

			af.ShowDialog();

			af.Dispose();
		}

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (this.txtRegEx.Text.Contains("\""))
            {
                // Have to escape it - can't use a literal string
                string regex = this.txtRegEx.Text.Replace(@"\", @"\\").Replace("\"", "\\\"");
                System.Windows.Forms.Clipboard.SetText("\"" + regex + "\"");
            }
            else
            {
                System.Windows.Forms.Clipboard.SetText("@\"" + this.txtRegEx.Text + "\"");
            }

        }

        private void cbMultiline_CheckedChanged(object sender, EventArgs e)
        {

        }
	}
}
