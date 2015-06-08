namespace TriDelta.DrawCircleMode {
    partial class OptionsPanel {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblAngle = new System.Windows.Forms.Label();
            this.grpProps = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tblProps = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpAppearance = new System.Windows.Forms.GroupBox();
            this.chkDrawAnteSpokes = new System.Windows.Forms.CheckBox();
            this.chkDrawSpokes = new System.Windows.Forms.CheckBox();
            this.chkFillCenter = new System.Windows.Forms.CheckBox();
            this.chkNeverSnapCircle = new System.Windows.Forms.CheckBox();
            this.chkShowSideCount = new System.Windows.Forms.CheckBox();
            this.chkShowTotalLength = new System.Windows.Forms.CheckBox();
            this.chkShowLineLength = new System.Windows.Forms.CheckBox();
            this.grpTools = new System.Windows.Forms.GroupBox();
            this.cmdSetTotalLength = new System.Windows.Forms.Button();
            this.udDesiredTotal = new System.Windows.Forms.NumericUpDown();
            this.lblSetTotalLength = new System.Windows.Forms.Label();
            this.udDesiredLength = new System.Windows.Forms.NumericUpDown();
            this.cmdResizeToFit = new System.Windows.Forms.Button();
            this.lblDesiredLength = new System.Windows.Forms.Label();
            this.chkAlwaysCreateOnEdit = new System.Windows.Forms.CheckBox();
            this.udSideCount = new TriDelta.DrawCircleMode.VariableNumericUpDown();
            this.udThickness = new TriDelta.DrawCircleMode.VariableNumericUpDown();
            this.udAngle = new TriDelta.DrawCircleMode.VariableNumericUpDown();
            this.udLength = new TriDelta.DrawCircleMode.VariableNumericUpDown();
            this.udSpokeSize = new TriDelta.DrawCircleMode.VariableNumericUpDown();
            this.udSpokeStart = new TriDelta.DrawCircleMode.VariableNumericUpDown();
            this.udAnteSpokeSize = new TriDelta.DrawCircleMode.VariableNumericUpDown();
            this.udAnteSpokeStart = new TriDelta.DrawCircleMode.VariableNumericUpDown();
            this.grpProps.SuspendLayout();
            this.tblProps.SuspendLayout();
            this.grpAppearance.SuspendLayout();
            this.grpTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDesiredTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDesiredLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSideCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSpokeSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSpokeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAnteSpokeSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAnteSpokeStart)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAngle
            // 
            this.lblAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAngle.AutoSize = true;
            this.lblAngle.Location = new System.Drawing.Point(3, 32);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(91, 13);
            this.lblAngle.TabIndex = 0;
            this.lblAngle.Text = "Angle:";
            // 
            // grpProps
            // 
            this.grpProps.AutoSize = true;
            this.grpProps.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpProps.Controls.Add(this.label1);
            this.grpProps.Controls.Add(this.tblProps);
            this.grpProps.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpProps.Location = new System.Drawing.Point(0, 213);
            this.grpProps.Name = "grpProps";
            this.grpProps.Padding = new System.Windows.Forms.Padding(15);
            this.grpProps.Size = new System.Drawing.Size(254, 264);
            this.grpProps.TabIndex = 1;
            this.grpProps.TabStop = false;
            this.grpProps.Text = "Properties";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(15, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shift = 1 / Ctrl = 0.1 / Alt = 32";
            // 
            // tblProps
            // 
            this.tblProps.AutoSize = true;
            this.tblProps.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblProps.ColumnCount = 2;
            this.tblProps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblProps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblProps.Controls.Add(this.label7, 0, 7);
            this.tblProps.Controls.Add(this.udSideCount, 1, 0);
            this.tblProps.Controls.Add(this.label5, 0, 0);
            this.tblProps.Controls.Add(this.label4, 0, 5);
            this.tblProps.Controls.Add(this.label3, 0, 4);
            this.tblProps.Controls.Add(this.udThickness, 1, 3);
            this.tblProps.Controls.Add(this.label2, 0, 3);
            this.tblProps.Controls.Add(this.udAngle, 1, 1);
            this.tblProps.Controls.Add(this.lblAngle, 0, 1);
            this.tblProps.Controls.Add(this.lblLength, 0, 2);
            this.tblProps.Controls.Add(this.udLength, 1, 2);
            this.tblProps.Controls.Add(this.udSpokeSize, 1, 4);
            this.tblProps.Controls.Add(this.udSpokeStart, 1, 5);
            this.tblProps.Controls.Add(this.label6, 0, 6);
            this.tblProps.Controls.Add(this.udAnteSpokeSize, 1, 6);
            this.tblProps.Controls.Add(this.udAnteSpokeStart, 1, 7);
            this.tblProps.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblProps.Location = new System.Drawing.Point(15, 28);
            this.tblProps.Name = "tblProps";
            this.tblProps.RowCount = 8;
            this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblProps.Size = new System.Drawing.Size(224, 208);
            this.tblProps.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ante Spoke Start:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Sides:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Spoke Start:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Spoke Size:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thickness:";
            // 
            // lblLength
            // 
            this.lblLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(3, 58);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(91, 13);
            this.lblLength.TabIndex = 2;
            this.lblLength.Text = "Length:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ante Spoke Size:";
            // 
            // grpAppearance
            // 
            this.grpAppearance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpAppearance.Controls.Add(this.chkAlwaysCreateOnEdit);
            this.grpAppearance.Controls.Add(this.chkDrawAnteSpokes);
            this.grpAppearance.Controls.Add(this.chkDrawSpokes);
            this.grpAppearance.Controls.Add(this.chkFillCenter);
            this.grpAppearance.Controls.Add(this.chkNeverSnapCircle);
            this.grpAppearance.Controls.Add(this.chkShowSideCount);
            this.grpAppearance.Controls.Add(this.chkShowTotalLength);
            this.grpAppearance.Controls.Add(this.chkShowLineLength);
            this.grpAppearance.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAppearance.Location = new System.Drawing.Point(0, 0);
            this.grpAppearance.Name = "grpAppearance";
            this.grpAppearance.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.grpAppearance.Size = new System.Drawing.Size(254, 213);
            this.grpAppearance.TabIndex = 2;
            this.grpAppearance.TabStop = false;
            this.grpAppearance.Text = "Appearance";
            // 
            // chkDrawAnteSpokes
            // 
            this.chkDrawAnteSpokes.AutoSize = true;
            this.chkDrawAnteSpokes.Location = new System.Drawing.Point(13, 164);
            this.chkDrawAnteSpokes.Name = "chkDrawAnteSpokes";
            this.chkDrawAnteSpokes.Size = new System.Drawing.Size(115, 17);
            this.chkDrawAnteSpokes.TabIndex = 6;
            this.chkDrawAnteSpokes.Text = "Draw Ante Spokes";
            this.chkDrawAnteSpokes.UseVisualStyleBackColor = true;
            this.chkDrawAnteSpokes.CheckedChanged += new System.EventHandler(this.chkDrawAnteSpokes_CheckedChanged);
            // 
            // chkDrawSpokes
            // 
            this.chkDrawSpokes.AutoSize = true;
            this.chkDrawSpokes.Location = new System.Drawing.Point(13, 141);
            this.chkDrawSpokes.Name = "chkDrawSpokes";
            this.chkDrawSpokes.Size = new System.Drawing.Size(90, 17);
            this.chkDrawSpokes.TabIndex = 5;
            this.chkDrawSpokes.Text = "Draw Spokes";
            this.chkDrawSpokes.UseVisualStyleBackColor = true;
            this.chkDrawSpokes.CheckedChanged += new System.EventHandler(this.chkDrawSpokes_CheckedChanged);
            // 
            // chkFillCenter
            // 
            this.chkFillCenter.AutoSize = true;
            this.chkFillCenter.Location = new System.Drawing.Point(13, 118);
            this.chkFillCenter.Name = "chkFillCenter";
            this.chkFillCenter.Size = new System.Drawing.Size(184, 17);
            this.chkFillCenter.TabIndex = 4;
            this.chkFillCenter.Text = "Fill center when thickness is used";
            this.chkFillCenter.UseVisualStyleBackColor = true;
            this.chkFillCenter.CheckedChanged += new System.EventHandler(this.chkFillCenter_CheckedChanged);
            // 
            // chkNeverSnapCircle
            // 
            this.chkNeverSnapCircle.AutoSize = true;
            this.chkNeverSnapCircle.Location = new System.Drawing.Point(13, 95);
            this.chkNeverSnapCircle.Name = "chkNeverSnapCircle";
            this.chkNeverSnapCircle.Size = new System.Drawing.Size(141, 17);
            this.chkNeverSnapCircle.TabIndex = 3;
            this.chkNeverSnapCircle.Text = "Never snap circle to grid";
            this.chkNeverSnapCircle.UseVisualStyleBackColor = true;
            this.chkNeverSnapCircle.CheckedChanged += new System.EventHandler(this.chkNeverSnapCircle_CheckedChanged);
            // 
            // chkShowSideCount
            // 
            this.chkShowSideCount.AutoSize = true;
            this.chkShowSideCount.Location = new System.Drawing.Point(13, 72);
            this.chkShowSideCount.Name = "chkShowSideCount";
            this.chkShowSideCount.Size = new System.Drawing.Size(117, 17);
            this.chkShowSideCount.TabIndex = 2;
            this.chkShowSideCount.Text = "Show linedef count";
            this.chkShowSideCount.UseVisualStyleBackColor = true;
            this.chkShowSideCount.CheckedChanged += new System.EventHandler(this.chkShowSideCount_CheckedChanged);
            // 
            // chkShowTotalLength
            // 
            this.chkShowTotalLength.AutoSize = true;
            this.chkShowTotalLength.Location = new System.Drawing.Point(13, 49);
            this.chkShowTotalLength.Name = "chkShowTotalLength";
            this.chkShowTotalLength.Size = new System.Drawing.Size(142, 17);
            this.chkShowTotalLength.TabIndex = 1;
            this.chkShowTotalLength.Text = "Show total linedef length";
            this.chkShowTotalLength.UseVisualStyleBackColor = true;
            this.chkShowTotalLength.CheckedChanged += new System.EventHandler(this.chkShowTotalLength_CheckedChanged);
            // 
            // chkShowLineLength
            // 
            this.chkShowLineLength.AutoSize = true;
            this.chkShowLineLength.Location = new System.Drawing.Point(13, 26);
            this.chkShowLineLength.Name = "chkShowLineLength";
            this.chkShowLineLength.Size = new System.Drawing.Size(119, 17);
            this.chkShowLineLength.TabIndex = 0;
            this.chkShowLineLength.Text = "Show linedef length";
            this.chkShowLineLength.UseVisualStyleBackColor = true;
            this.chkShowLineLength.CheckedChanged += new System.EventHandler(this.chkShowLineLength_CheckedChanged);
            // 
            // grpTools
            // 
            this.grpTools.AutoSize = true;
            this.grpTools.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpTools.Controls.Add(this.cmdSetTotalLength);
            this.grpTools.Controls.Add(this.udDesiredTotal);
            this.grpTools.Controls.Add(this.lblSetTotalLength);
            this.grpTools.Controls.Add(this.udDesiredLength);
            this.grpTools.Controls.Add(this.cmdResizeToFit);
            this.grpTools.Controls.Add(this.lblDesiredLength);
            this.grpTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTools.Location = new System.Drawing.Point(0, 477);
            this.grpTools.Name = "grpTools";
            this.grpTools.Padding = new System.Windows.Forms.Padding(15);
            this.grpTools.Size = new System.Drawing.Size(254, 138);
            this.grpTools.TabIndex = 3;
            this.grpTools.TabStop = false;
            this.grpTools.Text = "Tools";
            // 
            // cmdSetTotalLength
            // 
            this.cmdSetTotalLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSetTotalLength.Location = new System.Drawing.Point(160, 84);
            this.cmdSetTotalLength.Name = "cmdSetTotalLength";
            this.cmdSetTotalLength.Size = new System.Drawing.Size(75, 23);
            this.cmdSetTotalLength.TabIndex = 6;
            this.cmdSetTotalLength.Text = "Resize";
            this.cmdSetTotalLength.UseVisualStyleBackColor = true;
            this.cmdSetTotalLength.Click += new System.EventHandler(this.cmdSetTotalLength_Click);
            // 
            // udDesiredTotal
            // 
            this.udDesiredTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.udDesiredTotal.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.udDesiredTotal.Location = new System.Drawing.Point(18, 87);
            this.udDesiredTotal.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.udDesiredTotal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udDesiredTotal.Name = "udDesiredTotal";
            this.udDesiredTotal.Size = new System.Drawing.Size(136, 20);
            this.udDesiredTotal.TabIndex = 5;
            this.udDesiredTotal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSetTotalLength
            // 
            this.lblSetTotalLength.AutoSize = true;
            this.lblSetTotalLength.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblSetTotalLength.Location = new System.Drawing.Point(18, 71);
            this.lblSetTotalLength.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblSetTotalLength.Name = "lblSetTotalLength";
            this.lblSetTotalLength.Size = new System.Drawing.Size(127, 13);
            this.lblSetTotalLength.TabIndex = 4;
            this.lblSetTotalLength.Text = "Set total linedef length to:";
            // 
            // udDesiredLength
            // 
            this.udDesiredLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.udDesiredLength.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.udDesiredLength.Location = new System.Drawing.Point(18, 45);
            this.udDesiredLength.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.udDesiredLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udDesiredLength.Name = "udDesiredLength";
            this.udDesiredLength.Size = new System.Drawing.Size(137, 20);
            this.udDesiredLength.TabIndex = 3;
            this.udDesiredLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmdResizeToFit
            // 
            this.cmdResizeToFit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdResizeToFit.Location = new System.Drawing.Point(161, 42);
            this.cmdResizeToFit.Name = "cmdResizeToFit";
            this.cmdResizeToFit.Size = new System.Drawing.Size(75, 23);
            this.cmdResizeToFit.TabIndex = 2;
            this.cmdResizeToFit.Text = "Resize";
            this.cmdResizeToFit.UseVisualStyleBackColor = true;
            this.cmdResizeToFit.Click += new System.EventHandler(this.cmdResizeToFit_Click);
            // 
            // lblDesiredLength
            // 
            this.lblDesiredLength.AutoSize = true;
            this.lblDesiredLength.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblDesiredLength.Location = new System.Drawing.Point(18, 28);
            this.lblDesiredLength.Name = "lblDesiredLength";
            this.lblDesiredLength.Size = new System.Drawing.Size(90, 13);
            this.lblDesiredLength.TabIndex = 1;
            this.lblDesiredLength.Text = "Set all linedefs to:";
            // 
            // chkAlwaysCreateOnEdit
            // 
            this.chkAlwaysCreateOnEdit.AutoSize = true;
            this.chkAlwaysCreateOnEdit.Location = new System.Drawing.Point(13, 187);
            this.chkAlwaysCreateOnEdit.Name = "chkAlwaysCreateOnEdit";
            this.chkAlwaysCreateOnEdit.Size = new System.Drawing.Size(141, 17);
            this.chkAlwaysCreateOnEdit.TabIndex = 7;
            this.chkAlwaysCreateOnEdit.Text = "Always start over on edit";
            this.chkAlwaysCreateOnEdit.UseVisualStyleBackColor = true;
            this.chkAlwaysCreateOnEdit.CheckedChanged += new System.EventHandler(this.chkAlwaysCreateOnEdit_CheckedChanged);
            // 
            // udSideCount
            // 
            this.udSideCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.udSideCount.AutoSize = true;
            this.udSideCount.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.udSideCount.IncrementAlt = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.udSideCount.IncrementCtrl = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udSideCount.IncrementShift = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udSideCount.Location = new System.Drawing.Point(100, 3);
            this.udSideCount.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.udSideCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.udSideCount.Name = "udSideCount";
            this.udSideCount.Size = new System.Drawing.Size(121, 20);
            this.udSideCount.TabIndex = 10;
            this.udSideCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.udSideCount.ValueChanged += new System.EventHandler(this.udSideCount_ValueChanged);
            // 
            // udThickness
            // 
            this.udThickness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.udThickness.AutoSize = true;
            this.udThickness.DecimalPlaces = 1;
            this.udThickness.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.udThickness.IncrementAlt = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.udThickness.IncrementCtrl = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udThickness.IncrementShift = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udThickness.Location = new System.Drawing.Point(100, 81);
            this.udThickness.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.udThickness.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.udThickness.Name = "udThickness";
            this.udThickness.Size = new System.Drawing.Size(121, 20);
            this.udThickness.TabIndex = 5;
            this.udThickness.ValueChanged += new System.EventHandler(this.udThickness_ValueChanged);
            // 
            // udAngle
            // 
            this.udAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.udAngle.AutoSize = true;
            this.udAngle.DecimalPlaces = 1;
            this.udAngle.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.udAngle.IncrementAlt = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.udAngle.IncrementCtrl = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udAngle.IncrementShift = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udAngle.Location = new System.Drawing.Point(100, 29);
            this.udAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.udAngle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.udAngle.Name = "udAngle";
            this.udAngle.Size = new System.Drawing.Size(121, 20);
            this.udAngle.TabIndex = 1;
            this.udAngle.ValueChanged += new System.EventHandler(this.udAngle_ValueChanged);
            // 
            // udLength
            // 
            this.udLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.udLength.AutoSize = true;
            this.udLength.DecimalPlaces = 1;
            this.udLength.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.udLength.IncrementAlt = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.udLength.IncrementCtrl = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udLength.IncrementShift = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLength.Location = new System.Drawing.Point(100, 55);
            this.udLength.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.udLength.Name = "udLength";
            this.udLength.Size = new System.Drawing.Size(121, 20);
            this.udLength.TabIndex = 3;
            this.udLength.ValueChanged += new System.EventHandler(this.udLength_ValueChanged);
            // 
            // udSpokeSize
            // 
            this.udSpokeSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.udSpokeSize.AutoSize = true;
            this.udSpokeSize.DecimalPlaces = 1;
            this.udSpokeSize.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.udSpokeSize.IncrementAlt = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.udSpokeSize.IncrementCtrl = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udSpokeSize.IncrementShift = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udSpokeSize.Location = new System.Drawing.Point(100, 107);
            this.udSpokeSize.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.udSpokeSize.Name = "udSpokeSize";
            this.udSpokeSize.Size = new System.Drawing.Size(121, 20);
            this.udSpokeSize.TabIndex = 7;
            this.udSpokeSize.ValueChanged += new System.EventHandler(this.udSpokeSize_ValueChanged);
            // 
            // udSpokeStart
            // 
            this.udSpokeStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.udSpokeStart.AutoSize = true;
            this.udSpokeStart.DecimalPlaces = 1;
            this.udSpokeStart.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.udSpokeStart.IncrementAlt = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.udSpokeStart.IncrementCtrl = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udSpokeStart.IncrementShift = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udSpokeStart.Location = new System.Drawing.Point(100, 133);
            this.udSpokeStart.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.udSpokeStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.udSpokeStart.Name = "udSpokeStart";
            this.udSpokeStart.Size = new System.Drawing.Size(121, 20);
            this.udSpokeStart.TabIndex = 9;
            this.udSpokeStart.ValueChanged += new System.EventHandler(this.udSpokeStart_ValueChanged);
            // 
            // udAnteSpokeSize
            // 
            this.udAnteSpokeSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.udAnteSpokeSize.AutoSize = true;
            this.udAnteSpokeSize.DecimalPlaces = 1;
            this.udAnteSpokeSize.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.udAnteSpokeSize.IncrementAlt = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.udAnteSpokeSize.IncrementCtrl = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udAnteSpokeSize.IncrementShift = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udAnteSpokeSize.Location = new System.Drawing.Point(100, 159);
            this.udAnteSpokeSize.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.udAnteSpokeSize.Name = "udAnteSpokeSize";
            this.udAnteSpokeSize.Size = new System.Drawing.Size(121, 20);
            this.udAnteSpokeSize.TabIndex = 13;
            this.udAnteSpokeSize.ValueChanged += new System.EventHandler(this.udAnteSpokeSize_ValueChanged);
            // 
            // udAnteSpokeStart
            // 
            this.udAnteSpokeStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.udAnteSpokeStart.AutoSize = true;
            this.udAnteSpokeStart.DecimalPlaces = 1;
            this.udAnteSpokeStart.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.udAnteSpokeStart.IncrementAlt = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.udAnteSpokeStart.IncrementCtrl = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udAnteSpokeStart.IncrementShift = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udAnteSpokeStart.Location = new System.Drawing.Point(100, 185);
            this.udAnteSpokeStart.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.udAnteSpokeStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.udAnteSpokeStart.Name = "udAnteSpokeStart";
            this.udAnteSpokeStart.Size = new System.Drawing.Size(121, 20);
            this.udAnteSpokeStart.TabIndex = 14;
            this.udAnteSpokeStart.ValueChanged += new System.EventHandler(this.udAnteSpokeStart_ValueChanged);
            // 
            // OptionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.grpTools);
            this.Controls.Add(this.grpProps);
            this.Controls.Add(this.grpAppearance);
            this.Name = "OptionsPanel";
            this.Size = new System.Drawing.Size(254, 619);
            this.grpProps.ResumeLayout(false);
            this.grpProps.PerformLayout();
            this.tblProps.ResumeLayout(false);
            this.tblProps.PerformLayout();
            this.grpAppearance.ResumeLayout(false);
            this.grpAppearance.PerformLayout();
            this.grpTools.ResumeLayout(false);
            this.grpTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDesiredTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDesiredLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSideCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSpokeSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSpokeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAnteSpokeSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAnteSpokeStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.GroupBox grpProps;
        private System.Windows.Forms.TableLayoutPanel tblProps;
        private VariableNumericUpDown udAngle;
        private System.Windows.Forms.Label lblLength;
        private VariableNumericUpDown udLength;
        private System.Windows.Forms.GroupBox grpAppearance;
        private System.Windows.Forms.CheckBox chkShowSideCount;
        private System.Windows.Forms.CheckBox chkShowTotalLength;
        private System.Windows.Forms.CheckBox chkShowLineLength;
        private System.Windows.Forms.GroupBox grpTools;
        private System.Windows.Forms.Button cmdResizeToFit;
        private System.Windows.Forms.Label lblDesiredLength;
        private System.Windows.Forms.NumericUpDown udDesiredLength;
        private System.Windows.Forms.CheckBox chkNeverSnapCircle;
        private System.Windows.Forms.Button cmdSetTotalLength;
        private System.Windows.Forms.NumericUpDown udDesiredTotal;
        private System.Windows.Forms.Label lblSetTotalLength;
        private System.Windows.Forms.Label label1;
        private VariableNumericUpDown udThickness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkFillCenter;
        private System.Windows.Forms.Label label3;
        private VariableNumericUpDown udSpokeSize;
        private System.Windows.Forms.CheckBox chkDrawSpokes;
        private System.Windows.Forms.Label label4;
        private VariableNumericUpDown udSpokeStart;
        private VariableNumericUpDown udSideCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDrawAnteSpokes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private VariableNumericUpDown udAnteSpokeSize;
        private VariableNumericUpDown udAnteSpokeStart;
        private System.Windows.Forms.CheckBox chkAlwaysCreateOnEdit;
    }
}
