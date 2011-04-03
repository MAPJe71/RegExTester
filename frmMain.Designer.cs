using System.Windows.Forms;

namespace RegExTester
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    partial class frmMain
    {


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.sbpStatus = new System.Windows.Forms.StatusBarPanel();
			this.sbpMatches = new System.Windows.Forms.StatusBarPanel();
			this.sbpExecutionTime = new System.Windows.Forms.StatusBarPanel();
			this.sbpContext = new System.Windows.Forms.StatusBarPanel();
			this.spctTopAndMiddle = new System.Windows.Forms.SplitContainer();
			this.btnAbout = new System.Windows.Forms.Button();
			this.btnRegExLibrary = new System.Windows.Forms.Button();
			this.btnRegExCheatSheet = new System.Windows.Forms.Button();
			this.btnReplaceMode = new System.Windows.Forms.Button();
			this.btnIndentedInput = new System.Windows.Forms.Button();
			this.btnSingleLine = new System.Windows.Forms.Button();
			this.btnMultiLine = new System.Windows.Forms.Button();
			this.btnCultureInvariant = new System.Windows.Forms.Button();
			this.btnIgnoreCase = new System.Windows.Forms.Button();
			this.cbReplaceMode = new System.Windows.Forms.CheckBox();
			this.cbIndentedInput = new System.Windows.Forms.CheckBox();
			this.btnCopy = new System.Windows.Forms.Button();
			this.btnTest = new System.Windows.Forms.Button();
			this.cbSingleLine = new System.Windows.Forms.CheckBox();
			this.cbMultiLine = new System.Windows.Forms.CheckBox();
			this.cbIgnoreCase = new System.Windows.Forms.CheckBox();
			this.cbCultureInvariant = new System.Windows.Forms.CheckBox();
			this.spctRegExAndRepEx = new System.Windows.Forms.SplitContainer();
			this.lblRegEx = new System.Windows.Forms.Label();
			this.txtRegEx = new System.Windows.Forms.TextBox();
			this.lblRepEx = new System.Windows.Forms.Label();
			this.txtRepEx = new System.Windows.Forms.TextBox();
			this.spctMiddleAndBottom = new System.Windows.Forms.SplitContainer();
			this.spctTextAndResults = new System.Windows.Forms.SplitContainer();
			this.lblText = new System.Windows.Forms.Label();
			this.lblResults = new System.Windows.Forms.Label();
			this.exportResultsLinkLabel = new System.Windows.Forms.LinkLabel();
			this.lvResult = new System.Windows.Forms.ListView();
			this.chMatch = new System.Windows.Forms.ColumnHeader();
			this.chPosition = new System.Windows.Forms.ColumnHeader();
			this.chLength = new System.Windows.Forms.ColumnHeader();
			this.lblResultsList = new System.Windows.Forms.Label();
			this.cmsCopyButton = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiCopyGeneric0 = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiCopyGeneric1 = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiCopyGeneric2 = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiCopyGeneric3 = new System.Windows.Forms.ToolStripMenuItem();
			this.exportSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.rtbText = new RegExTester.CustomRichTextBox();
			this.rtbResults = new RegExTester.CustomRichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.sbpStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpMatches)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpExecutionTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpContext)).BeginInit();
			this.spctTopAndMiddle.Panel1.SuspendLayout();
			this.spctTopAndMiddle.Panel2.SuspendLayout();
			this.spctTopAndMiddle.SuspendLayout();
			this.spctRegExAndRepEx.Panel1.SuspendLayout();
			this.spctRegExAndRepEx.Panel2.SuspendLayout();
			this.spctRegExAndRepEx.SuspendLayout();
			this.spctMiddleAndBottom.Panel1.SuspendLayout();
			this.spctMiddleAndBottom.Panel2.SuspendLayout();
			this.spctMiddleAndBottom.SuspendLayout();
			this.spctTextAndResults.Panel1.SuspendLayout();
			this.spctTextAndResults.Panel2.SuspendLayout();
			this.spctTextAndResults.SuspendLayout();
			this.cmsCopyButton.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 435);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbpStatus,
            this.sbpMatches,
            this.sbpExecutionTime,
            this.sbpContext});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(592, 22);
			this.statusBar.TabIndex = 1;
			this.statusBar.Text = "statusBar";
			// 
			// sbpStatus
			// 
			this.sbpStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.sbpStatus.Name = "sbpStatus";
			this.sbpStatus.Text = "Nothing searched yet.";
			this.sbpStatus.Width = 545;
			// 
			// sbpMatches
			// 
			this.sbpMatches.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.sbpMatches.MinWidth = 0;
			this.sbpMatches.Name = "sbpMatches";
			this.sbpMatches.Width = 10;
			// 
			// sbpExecutionTime
			// 
			this.sbpExecutionTime.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.sbpExecutionTime.MinWidth = 0;
			this.sbpExecutionTime.Name = "sbpExecutionTime";
			this.sbpExecutionTime.Width = 10;
			// 
			// sbpContext
			// 
			this.sbpContext.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.sbpContext.MinWidth = 0;
			this.sbpContext.Name = "sbpContext";
			this.sbpContext.Width = 10;
			// 
			// spctTopAndMiddle
			// 
			this.spctTopAndMiddle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.spctTopAndMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spctTopAndMiddle.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spctTopAndMiddle.IsSplitterFixed = true;
			this.spctTopAndMiddle.Location = new System.Drawing.Point(0, 0);
			this.spctTopAndMiddle.Name = "spctTopAndMiddle";
			this.spctTopAndMiddle.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// spctTopAndMiddle.Panel1
			// 
			this.spctTopAndMiddle.Panel1.Controls.Add(this.btnAbout);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.btnRegExLibrary);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.btnRegExCheatSheet);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.btnReplaceMode);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.btnIndentedInput);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.btnSingleLine);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.btnMultiLine);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.btnCultureInvariant);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.btnIgnoreCase);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.cbReplaceMode);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.cbIndentedInput);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.btnCopy);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.btnTest);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.cbSingleLine);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.cbMultiLine);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.cbIgnoreCase);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.cbCultureInvariant);
			this.spctTopAndMiddle.Panel1.Controls.Add(this.spctRegExAndRepEx);
			this.spctTopAndMiddle.Panel1MinSize = 100;
			// 
			// spctTopAndMiddle.Panel2
			// 
			this.spctTopAndMiddle.Panel2.Controls.Add(this.spctMiddleAndBottom);
			this.spctTopAndMiddle.Size = new System.Drawing.Size(592, 435);
			this.spctTopAndMiddle.SplitterDistance = 100;
			this.spctTopAndMiddle.TabIndex = 0;
			// 
			// btnAbout
			// 
			this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAbout.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAbout.ForeColor = System.Drawing.Color.Blue;
			this.btnAbout.Location = new System.Drawing.Point(438, 1);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(137, 25);
			this.btnAbout.TabIndex = 31;
			this.btnAbout.Text = "About This Program";
			this.btnAbout.UseVisualStyleBackColor = true;
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
			// 
			// btnRegExLibrary
			// 
			this.btnRegExLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRegExLibrary.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnRegExLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRegExLibrary.ForeColor = System.Drawing.Color.Blue;
			this.btnRegExLibrary.Location = new System.Drawing.Point(328, 1);
			this.btnRegExLibrary.Name = "btnRegExLibrary";
			this.btnRegExLibrary.Size = new System.Drawing.Size(102, 25);
			this.btnRegExLibrary.TabIndex = 30;
			this.btnRegExLibrary.Text = "RegEx Library";
			this.btnRegExLibrary.UseVisualStyleBackColor = true;
			this.btnRegExLibrary.Click += new System.EventHandler(this.btnRegExLibrary_Click);
			// 
			// btnRegExCheatSheet
			// 
			this.btnRegExCheatSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRegExCheatSheet.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnRegExCheatSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRegExCheatSheet.ForeColor = System.Drawing.Color.Blue;
			this.btnRegExCheatSheet.Location = new System.Drawing.Point(186, 1);
			this.btnRegExCheatSheet.Name = "btnRegExCheatSheet";
			this.btnRegExCheatSheet.Size = new System.Drawing.Size(127, 25);
			this.btnRegExCheatSheet.TabIndex = 28;
			this.btnRegExCheatSheet.Text = "RegEx CheatSheet";
			this.btnRegExCheatSheet.UseVisualStyleBackColor = true;
			this.btnRegExCheatSheet.Click += new System.EventHandler(this.btnRegExCheatSheet_Click);
			// 
			// btnReplaceMode
			// 
			this.btnReplaceMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnReplaceMode.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnReplaceMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnReplaceMode.ForeColor = System.Drawing.Color.Blue;
			this.btnReplaceMode.Location = new System.Drawing.Point(375, 73);
			this.btnReplaceMode.Name = "btnReplaceMode";
			this.btnReplaceMode.Size = new System.Drawing.Size(22, 22);
			this.btnReplaceMode.TabIndex = 24;
			this.btnReplaceMode.Text = "?";
			this.btnReplaceMode.UseVisualStyleBackColor = true;
			this.btnReplaceMode.Click += new System.EventHandler(this.btnReplaceMode_Click);
			// 
			// btnIndentedInput
			// 
			this.btnIndentedInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnIndentedInput.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnIndentedInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnIndentedInput.ForeColor = System.Drawing.Color.Blue;
			this.btnIndentedInput.Location = new System.Drawing.Point(380, 51);
			this.btnIndentedInput.Name = "btnIndentedInput";
			this.btnIndentedInput.Size = new System.Drawing.Size(22, 22);
			this.btnIndentedInput.TabIndex = 23;
			this.btnIndentedInput.Text = "?";
			this.btnIndentedInput.UseVisualStyleBackColor = true;
			this.btnIndentedInput.Click += new System.EventHandler(this.btnIndentedInput_Click);
			// 
			// btnSingleLine
			// 
			this.btnSingleLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSingleLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnSingleLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSingleLine.ForeColor = System.Drawing.Color.Blue;
			this.btnSingleLine.Location = new System.Drawing.Point(243, 73);
			this.btnSingleLine.Name = "btnSingleLine";
			this.btnSingleLine.Size = new System.Drawing.Size(22, 22);
			this.btnSingleLine.TabIndex = 22;
			this.btnSingleLine.Text = "?";
			this.btnSingleLine.UseVisualStyleBackColor = true;
			this.btnSingleLine.Click += new System.EventHandler(this.btnSingleLine_Click);
			// 
			// btnMultiLine
			// 
			this.btnMultiLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnMultiLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnMultiLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMultiLine.ForeColor = System.Drawing.Color.Blue;
			this.btnMultiLine.Location = new System.Drawing.Point(232, 51);
			this.btnMultiLine.Name = "btnMultiLine";
			this.btnMultiLine.Size = new System.Drawing.Size(22, 22);
			this.btnMultiLine.TabIndex = 21;
			this.btnMultiLine.Text = "?";
			this.btnMultiLine.UseVisualStyleBackColor = true;
			this.btnMultiLine.Click += new System.EventHandler(this.btnMultiLine_Click);
			// 
			// btnCultureInvariant
			// 
			this.btnCultureInvariant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCultureInvariant.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnCultureInvariant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCultureInvariant.ForeColor = System.Drawing.Color.Blue;
			this.btnCultureInvariant.Location = new System.Drawing.Point(130, 73);
			this.btnCultureInvariant.Name = "btnCultureInvariant";
			this.btnCultureInvariant.Size = new System.Drawing.Size(22, 22);
			this.btnCultureInvariant.TabIndex = 20;
			this.btnCultureInvariant.Text = "?";
			this.btnCultureInvariant.UseVisualStyleBackColor = true;
			this.btnCultureInvariant.Click += new System.EventHandler(this.btnCultureInvariant_Click);
			// 
			// btnIgnoreCase
			// 
			this.btnIgnoreCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnIgnoreCase.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnIgnoreCase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnIgnoreCase.ForeColor = System.Drawing.Color.Blue;
			this.btnIgnoreCase.Location = new System.Drawing.Point(102, 51);
			this.btnIgnoreCase.Name = "btnIgnoreCase";
			this.btnIgnoreCase.Size = new System.Drawing.Size(22, 22);
			this.btnIgnoreCase.TabIndex = 19;
			this.btnIgnoreCase.Text = "?";
			this.btnIgnoreCase.UseVisualStyleBackColor = true;
			this.btnIgnoreCase.Click += new System.EventHandler(this.btnIgnoreCase_Click);
			// 
			// cbReplaceMode
			// 
			this.cbReplaceMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbReplaceMode.CausesValidation = false;
			this.cbReplaceMode.Checked = true;
			this.cbReplaceMode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbReplaceMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbReplaceMode.Location = new System.Drawing.Point(275, 73);
			this.cbReplaceMode.Name = "cbReplaceMode";
			this.cbReplaceMode.Size = new System.Drawing.Size(127, 22);
			this.cbReplaceMode.TabIndex = 15;
			this.cbReplaceMode.Text = "Replace mode";
			this.cbReplaceMode.CheckedChanged += new System.EventHandler(this.cbReplaceMode_CheckedChanged);
			// 
			// cbIndentedInput
			// 
			this.cbIndentedInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbIndentedInput.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbIndentedInput.Location = new System.Drawing.Point(275, 51);
			this.cbIndentedInput.Name = "cbIndentedInput";
			this.cbIndentedInput.Size = new System.Drawing.Size(127, 22);
			this.cbIndentedInput.TabIndex = 13;
			this.cbIndentedInput.Text = "Indented Input";
			this.cbIndentedInput.CheckedChanged += new System.EventHandler(this.cbIndentedInput_CheckedChanged);
			// 
			// btnCopy
			// 
			this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCopy.Location = new System.Drawing.Point(405, 56);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(75, 34);
			this.btnCopy.TabIndex = 17;
			this.btnCopy.Text = "Copy";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// btnTest
			// 
			this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTest.Location = new System.Drawing.Point(486, 56);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(92, 34);
			this.btnTest.TabIndex = 18;
			this.btnTest.Text = "Test [F5]";
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// cbSingleLine
			// 
			this.cbSingleLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbSingleLine.Checked = true;
			this.cbSingleLine.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSingleLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbSingleLine.Location = new System.Drawing.Point(160, 73);
			this.cbSingleLine.Name = "cbSingleLine";
			this.cbSingleLine.Size = new System.Drawing.Size(109, 22);
			this.cbSingleLine.TabIndex = 11;
			this.cbSingleLine.Text = "Single Line";
			// 
			// cbMultiLine
			// 
			this.cbMultiLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbMultiLine.Checked = true;
			this.cbMultiLine.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMultiLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbMultiLine.Location = new System.Drawing.Point(160, 51);
			this.cbMultiLine.Name = "cbMultiLine";
			this.cbMultiLine.Size = new System.Drawing.Size(109, 22);
			this.cbMultiLine.TabIndex = 9;
			this.cbMultiLine.Text = "Multi Line";
			// 
			// cbIgnoreCase
			// 
			this.cbIgnoreCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbIgnoreCase.Checked = true;
			this.cbIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbIgnoreCase.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbIgnoreCase.Location = new System.Drawing.Point(11, 51);
			this.cbIgnoreCase.Name = "cbIgnoreCase";
			this.cbIgnoreCase.Size = new System.Drawing.Size(142, 22);
			this.cbIgnoreCase.TabIndex = 5;
			this.cbIgnoreCase.Text = "Ignore Case";
			// 
			// cbCultureInvariant
			// 
			this.cbCultureInvariant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbCultureInvariant.Checked = true;
			this.cbCultureInvariant.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbCultureInvariant.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbCultureInvariant.Location = new System.Drawing.Point(11, 73);
			this.cbCultureInvariant.Name = "cbCultureInvariant";
			this.cbCultureInvariant.Size = new System.Drawing.Size(142, 22);
			this.cbCultureInvariant.TabIndex = 7;
			this.cbCultureInvariant.Text = "Culture Invariant";
			// 
			// spctRegExAndRepEx
			// 
			this.spctRegExAndRepEx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.spctRegExAndRepEx.Location = new System.Drawing.Point(11, 5);
			this.spctRegExAndRepEx.Name = "spctRegExAndRepEx";
			// 
			// spctRegExAndRepEx.Panel1
			// 
			this.spctRegExAndRepEx.Panel1.Controls.Add(this.lblRegEx);
			this.spctRegExAndRepEx.Panel1.Controls.Add(this.txtRegEx);
			// 
			// spctRegExAndRepEx.Panel2
			// 
			this.spctRegExAndRepEx.Panel2.Controls.Add(this.lblRepEx);
			this.spctRegExAndRepEx.Panel2.Controls.Add(this.txtRepEx);
			this.spctRegExAndRepEx.Size = new System.Drawing.Size(567, 42);
			this.spctRegExAndRepEx.SplitterDistance = 283;
			this.spctRegExAndRepEx.TabIndex = 4;
			// 
			// lblRegEx
			// 
			this.lblRegEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblRegEx.Location = new System.Drawing.Point(0, 3);
			this.lblRegEx.Name = "lblRegEx";
			this.lblRegEx.Size = new System.Drawing.Size(283, 16);
			this.lblRegEx.TabIndex = 1;
			this.lblRegEx.Text = "Regular Expression";
			// 
			// txtRegEx
			// 
			this.txtRegEx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRegEx.HideSelection = false;
			this.txtRegEx.Location = new System.Drawing.Point(0, 21);
			this.txtRegEx.Name = "txtRegEx";
			this.txtRegEx.Size = new System.Drawing.Size(283, 21);
			this.txtRegEx.TabIndex = 0;
			// 
			// lblRepEx
			// 
			this.lblRepEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblRepEx.Location = new System.Drawing.Point(0, 3);
			this.lblRepEx.Name = "lblRepEx";
			this.lblRepEx.Size = new System.Drawing.Size(284, 16);
			this.lblRepEx.TabIndex = 2;
			this.lblRepEx.Text = "Replacement Expression";
			// 
			// txtRepEx
			// 
			this.txtRepEx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRepEx.HideSelection = false;
			this.txtRepEx.Location = new System.Drawing.Point(0, 21);
			this.txtRepEx.Name = "txtRepEx";
			this.txtRepEx.Size = new System.Drawing.Size(280, 21);
			this.txtRepEx.TabIndex = 0;
			// 
			// spctMiddleAndBottom
			// 
			this.spctMiddleAndBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.spctMiddleAndBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spctMiddleAndBottom.Location = new System.Drawing.Point(0, 0);
			this.spctMiddleAndBottom.Name = "spctMiddleAndBottom";
			this.spctMiddleAndBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// spctMiddleAndBottom.Panel1
			// 
			this.spctMiddleAndBottom.Panel1.Controls.Add(this.spctTextAndResults);
			this.spctMiddleAndBottom.Panel1MinSize = 61;
			// 
			// spctMiddleAndBottom.Panel2
			// 
			this.spctMiddleAndBottom.Panel2.Controls.Add(this.exportResultsLinkLabel);
			this.spctMiddleAndBottom.Panel2.Controls.Add(this.lvResult);
			this.spctMiddleAndBottom.Panel2.Controls.Add(this.lblResultsList);
			this.spctMiddleAndBottom.Panel2MinSize = 89;
			this.spctMiddleAndBottom.Size = new System.Drawing.Size(592, 331);
			this.spctMiddleAndBottom.SplitterDistance = 191;
			this.spctMiddleAndBottom.TabIndex = 0;
			// 
			// spctTextAndResults
			// 
			this.spctTextAndResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.spctTextAndResults.Location = new System.Drawing.Point(11, 9);
			this.spctTextAndResults.Name = "spctTextAndResults";
			// 
			// spctTextAndResults.Panel1
			// 
			this.spctTextAndResults.Panel1.Controls.Add(this.lblText);
			this.spctTextAndResults.Panel1.Controls.Add(this.rtbText);
			// 
			// spctTextAndResults.Panel2
			// 
			this.spctTextAndResults.Panel2.Controls.Add(this.lblResults);
			this.spctTextAndResults.Panel2.Controls.Add(this.rtbResults);
			this.spctTextAndResults.Size = new System.Drawing.Size(567, 166);
			this.spctTextAndResults.SplitterDistance = 283;
			this.spctTextAndResults.TabIndex = 1;
			// 
			// lblText
			// 
			this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblText.Location = new System.Drawing.Point(-3, 0);
			this.lblText.Name = "lblText";
			this.lblText.Size = new System.Drawing.Size(286, 16);
			this.lblText.TabIndex = 1;
			this.lblText.Text = "Test Text";
			// 
			// lblResults
			// 
			this.lblResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblResults.Location = new System.Drawing.Point(-3, 0);
			this.lblResults.Name = "lblResults";
			this.lblResults.Size = new System.Drawing.Size(287, 16);
			this.lblResults.TabIndex = 2;
			this.lblResults.Text = "Test Results";
			// 
			// exportResultsLinkLabel
			// 
			this.exportResultsLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.exportResultsLinkLabel.AutoSize = true;
			this.exportResultsLinkLabel.Location = new System.Drawing.Point(454, 9);
			this.exportResultsLinkLabel.Name = "exportResultsLinkLabel";
			this.exportResultsLinkLabel.Size = new System.Drawing.Size(128, 13);
			this.exportResultsLinkLabel.TabIndex = 2;
			this.exportResultsLinkLabel.TabStop = true;
			this.exportResultsLinkLabel.Text = "Export Results (CSV)";
			this.exportResultsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.exportResultsLinkLabel_LinkClicked);
			// 
			// lvResult
			// 
			this.lvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chMatch,
            this.chPosition,
            this.chLength});
			this.lvResult.FullRowSelect = true;
			this.lvResult.GridLines = true;
			this.lvResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvResult.HideSelection = false;
			this.lvResult.Location = new System.Drawing.Point(11, 27);
			this.lvResult.MultiSelect = false;
			this.lvResult.Name = "lvResult";
			this.lvResult.Size = new System.Drawing.Size(567, 91);
			this.lvResult.TabIndex = 1;
			this.lvResult.UseCompatibleStateImageBehavior = false;
			this.lvResult.View = System.Windows.Forms.View.Details;
			this.lvResult.SelectedIndexChanged += new System.EventHandler(this.lvResult_SelectedIndexChanged);
			// 
			// chMatch
			// 
			this.chMatch.Text = "Match";
			this.chMatch.Width = 350;
			// 
			// chPosition
			// 
			this.chPosition.Text = "Position";
			// 
			// chLength
			// 
			this.chLength.Text = "Length";
			// 
			// lblResultsList
			// 
			this.lblResultsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblResultsList.Location = new System.Drawing.Point(8, 9);
			this.lblResultsList.Name = "lblResultsList";
			this.lblResultsList.Size = new System.Drawing.Size(570, 15);
			this.lblResultsList.TabIndex = 0;
			this.lblResultsList.Text = "Test Results";
			// 
			// cmsCopyButton
			// 
			this.cmsCopyButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopyGeneric0,
            this.tsmiCopyGeneric1,
            this.tsmiCopyGeneric2,
            this.tsmiCopyGeneric3});
			this.cmsCopyButton.Name = "btnCopyContextMenuStrip";
			this.cmsCopyButton.Size = new System.Drawing.Size(174, 92);
			// 
			// tsmiCopyGeneric0
			// 
			this.tsmiCopyGeneric0.Image = global::RegExTester.Properties.Resources.CSharpSnippet;
			this.tsmiCopyGeneric0.Name = "tsmiCopyGeneric0";
			this.tsmiCopyGeneric0.Size = new System.Drawing.Size(173, 22);
			this.tsmiCopyGeneric0.Tag = "csharp snippet";
			this.tsmiCopyGeneric0.Text = "C# code &snippet";
			this.tsmiCopyGeneric0.Click += new System.EventHandler(this.tsmiCopyGeneric_Click);
			// 
			// tsmiCopyGeneric1
			// 
			this.tsmiCopyGeneric1.Image = global::RegExTester.Properties.Resources.CSharp;
			this.tsmiCopyGeneric1.Name = "tsmiCopyGeneric1";
			this.tsmiCopyGeneric1.Size = new System.Drawing.Size(173, 22);
			this.tsmiCopyGeneric1.Tag = "csharp";
			this.tsmiCopyGeneric1.Text = "&C# escaped string";
			this.tsmiCopyGeneric1.Click += new System.EventHandler(this.tsmiCopyGeneric_Click);
			// 
			// tsmiCopyGeneric2
			// 
			this.tsmiCopyGeneric2.Image = global::RegExTester.Properties.Resources.Html;
			this.tsmiCopyGeneric2.Name = "tsmiCopyGeneric2";
			this.tsmiCopyGeneric2.Size = new System.Drawing.Size(173, 22);
			this.tsmiCopyGeneric2.Tag = "html";
			this.tsmiCopyGeneric2.Text = "&HTML encoded";
			this.tsmiCopyGeneric2.Click += new System.EventHandler(this.tsmiCopyGeneric_Click);
			// 
			// tsmiCopyGeneric3
			// 
			this.tsmiCopyGeneric3.Image = global::RegExTester.Properties.Resources.Plain;
			this.tsmiCopyGeneric3.Name = "tsmiCopyGeneric3";
			this.tsmiCopyGeneric3.Size = new System.Drawing.Size(173, 22);
			this.tsmiCopyGeneric3.Tag = "plain";
			this.tsmiCopyGeneric3.Text = "&Plain text";
			this.tsmiCopyGeneric3.Click += new System.EventHandler(this.tsmiCopyGeneric_Click);
			// 
			// exportSaveFileDialog
			// 
			this.exportSaveFileDialog.DefaultExt = "csv";
			this.exportSaveFileDialog.Filter = "Comma Separated Values|*.csv|All files|*.*";
			// 
			// rtbText
			// 
			this.rtbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rtbText.HideSelection = false;
			this.rtbText.Location = new System.Drawing.Point(0, 19);
			this.rtbText.Name = "rtbText";
			this.rtbText.Size = new System.Drawing.Size(283, 147);
			this.rtbText.TabIndex = 0;
			this.rtbText.Text = "";
			// 
			// rtbResults
			// 
			this.rtbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rtbResults.HideSelection = false;
			this.rtbResults.Location = new System.Drawing.Point(0, 19);
			this.rtbResults.Name = "rtbResults";
			this.rtbResults.Size = new System.Drawing.Size(280, 147);
			this.rtbResults.TabIndex = 0;
			this.rtbResults.Text = "";
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(592, 457);
			this.Controls.Add(this.spctTopAndMiddle);
			this.Controls.Add(this.statusBar);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(600, 390);
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RegEx Tester";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.sbpStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpMatches)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpExecutionTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpContext)).EndInit();
			this.spctTopAndMiddle.Panel1.ResumeLayout(false);
			this.spctTopAndMiddle.Panel2.ResumeLayout(false);
			this.spctTopAndMiddle.ResumeLayout(false);
			this.spctRegExAndRepEx.Panel1.ResumeLayout(false);
			this.spctRegExAndRepEx.Panel1.PerformLayout();
			this.spctRegExAndRepEx.Panel2.ResumeLayout(false);
			this.spctRegExAndRepEx.Panel2.PerformLayout();
			this.spctRegExAndRepEx.ResumeLayout(false);
			this.spctMiddleAndBottom.Panel1.ResumeLayout(false);
			this.spctMiddleAndBottom.Panel2.ResumeLayout(false);
			this.spctMiddleAndBottom.Panel2.PerformLayout();
			this.spctMiddleAndBottom.ResumeLayout(false);
			this.spctTextAndResults.Panel1.ResumeLayout(false);
			this.spctTextAndResults.Panel2.ResumeLayout(false);
			this.spctTextAndResults.ResumeLayout(false);
			this.cmsCopyButton.ResumeLayout(false);
			this.ResumeLayout(false);

        }
        #endregion


        private StatusBar statusBar;
        private StatusBarPanel sbpStatus;
        private StatusBarPanel sbpContext;
        private SplitContainer spctTopAndMiddle;
        private SplitContainer spctMiddleAndBottom;
        private Button btnCopy;
        private Button btnTest;
        private CheckBox cbCultureInvariant;
        private CheckBox cbSingleLine;
        private CheckBox cbMultiLine;
        private CheckBox cbIgnoreCase;
        private Label lblResultsList;
        private ListView lvResult;
        private ColumnHeader chMatch;
        private ColumnHeader chPosition;
        private ColumnHeader chLength;
        private CheckBox cbIndentedInput;
        private System.ComponentModel.IContainer components;
        private ContextMenuStrip cmsCopyButton;
        private ToolStripMenuItem tsmiCopyGeneric1;
        private ToolStripMenuItem tsmiCopyGeneric2;
        private ToolStripMenuItem tsmiCopyGeneric3;
        private CheckBox cbReplaceMode;
        private SplitContainer spctTextAndResults;
        private CustomRichTextBox rtbResults;
        private CustomRichTextBox rtbText;
        private SplitContainer spctRegExAndRepEx;
        private TextBox txtRegEx;
        private TextBox txtRepEx;
        private ToolStripMenuItem tsmiCopyGeneric0;
        private Label lblText;
        private Label lblResults;
        private Label lblRegEx;
        private Label lblRepEx;
        private StatusBarPanel sbpMatches;
        private StatusBarPanel sbpExecutionTime;
        private Button btnIgnoreCase;
        private Button btnCultureInvariant;
        private Button btnMultiLine;
        private Button btnSingleLine;
        private Button btnReplaceMode;
        private Button btnIndentedInput;
        private Button btnAbout;
        private Button btnRegExLibrary;
        private Button btnRegExCheatSheet;
		private LinkLabel exportResultsLinkLabel;
		private SaveFileDialog exportSaveFileDialog;

    }
}