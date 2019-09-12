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
            this.components = new System.ComponentModel.Container();
            this.lblAngle = new System.Windows.Forms.Label();
            this.grpProps = new System.Windows.Forms.GroupBox();
            this.tblProps = new System.Windows.Forms.TableLayoutPanel();
            this.cmdToggleSideLock = new System.Windows.Forms.Button();
            this.udSideDraw = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.udSideCount = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSidesShown = new System.Windows.Forms.Label();
            this.udLength = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.udAngle = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.cmdRot90 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpAppearance = new System.Windows.Forms.GroupBox();
            this.chkDrawOffset = new System.Windows.Forms.CheckBox();
            this.chkAlwaysCreateOnEdit = new System.Windows.Forms.CheckBox();
            this.chkNeverSnapCircle = new System.Windows.Forms.CheckBox();
            this.chkShowSideCount = new System.Windows.Forms.CheckBox();
            this.chkShowTotalLength = new System.Windows.Forms.CheckBox();
            this.chkShowLineLength = new System.Windows.Forms.CheckBox();
            this.chkDrawAnteSpokes = new System.Windows.Forms.CheckBox();
            this.chkDrawSpokes = new System.Windows.Forms.CheckBox();
            this.chkFillCenter = new System.Windows.Forms.CheckBox();
            this.grpTools = new System.Windows.Forms.GroupBox();
            this.cmdSetTotalLength = new System.Windows.Forms.Button();
            this.udDesiredTotal = new System.Windows.Forms.NumericUpDown();
            this.lblSetTotalLength = new System.Windows.Forms.Label();
            this.udDesiredLength = new System.Windows.Forms.NumericUpDown();
            this.cmdResizeToFit = new System.Windows.Forms.Button();
            this.lblDesiredLength = new System.Windows.Forms.Label();
            this.grpSpoke = new System.Windows.Forms.GroupBox();
            this.tblSpoke = new System.Windows.Forms.TableLayoutPanel();
            this.udSpokeStart = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.udSpokeSize = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.grpAnte = new System.Windows.Forms.GroupBox();
            this.tblAnte = new System.Windows.Forms.TableLayoutPanel();
            this.udAnteSpokeStart = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.udAnteSpokeSize = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.grpCircle = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.udThickness = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.chkDrawCircle = new System.Windows.Forms.CheckBox();
            this.ttOptions = new System.Windows.Forms.ToolTip(this.components);
            this.grpProps.SuspendLayout();
            this.tblProps.SuspendLayout();
            this.grpAppearance.SuspendLayout();
            this.grpTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDesiredTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDesiredLength)).BeginInit();
            this.grpSpoke.SuspendLayout();
            this.tblSpoke.SuspendLayout();
            this.grpAnte.SuspendLayout();
            this.tblAnte.SuspendLayout();
            this.grpCircle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAngle
            // 
            this.lblAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAngle.AutoSize = true;
            this.lblAngle.Location = new System.Drawing.Point(3, 68);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(43, 13);
            this.lblAngle.TabIndex = 0;
            this.lblAngle.Text = "Angle:";
            // 
            // grpProps
            // 
            this.grpProps.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpProps.Controls.Add(this.tblProps);
            this.grpProps.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpProps.Location = new System.Drawing.Point(0, 168);
            this.grpProps.Name = "grpProps";
            this.grpProps.Padding = new System.Windows.Forms.Padding(10);
            this.grpProps.Size = new System.Drawing.Size(200, 150);
            this.grpProps.TabIndex = 6;
            this.grpProps.TabStop = false;
            this.grpProps.Text = "Properties";
            // 
            // tblProps
            // 
            this.tblProps.AutoSize = true;
            this.tblProps.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblProps.ColumnCount = 3;
            this.tblProps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblProps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblProps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblProps.Controls.Add(this.cmdToggleSideLock, 2, 1);
            this.tblProps.Controls.Add(this.udSideDraw, 1, 1);
            this.tblProps.Controls.Add(this.label1, 0, 3);
            this.tblProps.Controls.Add(this.udSideCount, 1, 0);
            this.tblProps.Controls.Add(this.label5, 0, 0);
            this.tblProps.Controls.Add(this.lblAngle, 0, 2);
            this.tblProps.Controls.Add(this.lblSidesShown, 0, 1);
            this.tblProps.Controls.Add(this.udLength, 1, 3);
            this.tblProps.Controls.Add(this.udAngle, 1, 2);
            this.tblProps.Controls.Add(this.cmdRot90, 2, 2);
            this.tblProps.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblProps.Location = new System.Drawing.Point(10, 23);
            this.tblProps.Name = "tblProps";
            this.tblProps.RowCount = 4;
            this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblProps.Size = new System.Drawing.Size(180, 120);
            this.tblProps.TabIndex = 0;
            // 
            // cmdToggleSideLock
            // 
            this.cmdToggleSideLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdToggleSideLock.Image = global::TriDelta.DrawCircleMode.Properties.Resources.Link;
            this.cmdToggleSideLock.Location = new System.Drawing.Point(139, 33);
            this.cmdToggleSideLock.Name = "cmdToggleSideLock";
            this.cmdToggleSideLock.Size = new System.Drawing.Size(38, 23);
            this.cmdToggleSideLock.TabIndex = 9;
            this.ttOptions.SetToolTip(this.cmdToggleSideLock, "Lock/Unlock shown vertices to the number of sides");
            this.cmdToggleSideLock.UseVisualStyleBackColor = true;
            this.cmdToggleSideLock.Click += new System.EventHandler(this.cmdToggleSideLock_Click);
            // 
            // udSideDraw
            // 
            this.udSideDraw.AllowDecimal = false;
            this.udSideDraw.AllowExpressions = false;
            this.udSideDraw.AllowNegative = false;
            this.udSideDraw.AllowRelative = true;
            this.udSideDraw.BackColor = System.Drawing.Color.Transparent;
            this.udSideDraw.ButtonStep = 1;
            this.udSideDraw.ButtonStepBig = 16F;
            this.udSideDraw.ButtonStepFloat = 1F;
            this.udSideDraw.ButtonStepSmall = 8F;
            this.udSideDraw.ButtonStepsUseModifierKeys = true;
            this.udSideDraw.ButtonStepsWrapAround = true;
            this.udSideDraw.Location = new System.Drawing.Point(52, 33);
            this.udSideDraw.Name = "udSideDraw";
            this.udSideDraw.Size = new System.Drawing.Size(81, 24);
            this.udSideDraw.StepValues = null;
            this.udSideDraw.TabIndex = 7;
            this.udSideDraw.WhenTextChanged += new System.EventHandler(this.udSideDraw_WhenTextChanged);
            this.udSideDraw.WhenEnterPressed += new System.EventHandler(this.udSideDraw_Apply);
            this.udSideDraw.Leave += new System.EventHandler(this.udSideDraw_Apply);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Length:";
            // 
            // udSideCount
            // 
            this.udSideCount.AllowDecimal = false;
            this.udSideCount.AllowExpressions = false;
            this.udSideCount.AllowNegative = false;
            this.udSideCount.AllowRelative = true;
            this.udSideCount.BackColor = System.Drawing.Color.Transparent;
            this.udSideCount.ButtonStep = 1;
            this.udSideCount.ButtonStepBig = 16F;
            this.udSideCount.ButtonStepFloat = 1F;
            this.udSideCount.ButtonStepSmall = 8F;
            this.udSideCount.ButtonStepsUseModifierKeys = true;
            this.udSideCount.ButtonStepsWrapAround = true;
            this.tblProps.SetColumnSpan(this.udSideCount, 2);
            this.udSideCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udSideCount.Location = new System.Drawing.Point(52, 3);
            this.udSideCount.Name = "udSideCount";
            this.udSideCount.Size = new System.Drawing.Size(125, 24);
            this.udSideCount.StepValues = null;
            this.udSideCount.TabIndex = 6;
            this.udSideCount.WhenTextChanged += new System.EventHandler(this.UdSideCount_WhenTextChanged);
            this.udSideCount.WhenEnterPressed += new System.EventHandler(this.UdSideCount_Apply);
            this.udSideCount.Leave += new System.EventHandler(this.UdSideCount_Apply);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Sides:";
            // 
            // lblSidesShown
            // 
            this.lblSidesShown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSidesShown.AutoSize = true;
            this.lblSidesShown.Location = new System.Drawing.Point(3, 38);
            this.lblSidesShown.Name = "lblSidesShown";
            this.lblSidesShown.Size = new System.Drawing.Size(43, 13);
            this.lblSidesShown.TabIndex = 2;
            this.lblSidesShown.Text = "Shown:";
            this.ttOptions.SetToolTip(this.lblSidesShown, "Number of vertices to render");
            // 
            // udLength
            // 
            this.udLength.AllowDecimal = true;
            this.udLength.AllowExpressions = false;
            this.udLength.AllowNegative = true;
            this.udLength.AllowRelative = true;
            this.udLength.BackColor = System.Drawing.Color.Transparent;
            this.udLength.ButtonStep = 8;
            this.udLength.ButtonStepBig = 32F;
            this.udLength.ButtonStepFloat = 8F;
            this.udLength.ButtonStepSmall = 0.1F;
            this.udLength.ButtonStepsUseModifierKeys = true;
            this.udLength.ButtonStepsWrapAround = true;
            this.tblProps.SetColumnSpan(this.udLength, 2);
            this.udLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udLength.Location = new System.Drawing.Point(52, 93);
            this.udLength.Name = "udLength";
            this.udLength.Size = new System.Drawing.Size(125, 24);
            this.udLength.StepValues = null;
            this.udLength.TabIndex = 9;
            this.udLength.WhenTextChanged += new System.EventHandler(this.UdLength_WhenTextChanged);
            this.udLength.WhenEnterPressed += new System.EventHandler(this.UdLength_Apply);
            this.udLength.Leave += new System.EventHandler(this.UdLength_Apply);
            // 
            // udAngle
            // 
            this.udAngle.AllowDecimal = true;
            this.udAngle.AllowExpressions = false;
            this.udAngle.AllowNegative = true;
            this.udAngle.AllowRelative = true;
            this.udAngle.BackColor = System.Drawing.Color.Transparent;
            this.udAngle.ButtonStep = 1;
            this.udAngle.ButtonStepBig = 22.5F;
            this.udAngle.ButtonStepFloat = 1F;
            this.udAngle.ButtonStepSmall = 0.1F;
            this.udAngle.ButtonStepsUseModifierKeys = true;
            this.udAngle.ButtonStepsWrapAround = true;
            this.udAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udAngle.Location = new System.Drawing.Point(52, 63);
            this.udAngle.Name = "udAngle";
            this.udAngle.Size = new System.Drawing.Size(81, 24);
            this.udAngle.StepValues = null;
            this.udAngle.TabIndex = 7;
            this.udAngle.WhenTextChanged += new System.EventHandler(this.UdAngle_WhenTextChanged);
            this.udAngle.WhenEnterPressed += new System.EventHandler(this.UdAngle_Apply);
            this.udAngle.Leave += new System.EventHandler(this.UdAngle_Apply);
            // 
            // cmdRot90
            // 
            this.cmdRot90.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRot90.Location = new System.Drawing.Point(139, 63);
            this.cmdRot90.Name = "cmdRot90";
            this.cmdRot90.Size = new System.Drawing.Size(38, 23);
            this.cmdRot90.TabIndex = 8;
            this.cmdRot90.Text = "90°";
            this.ttOptions.SetToolTip(this.cmdRot90, "Rotate handle 90 degrees");
            this.cmdRot90.UseVisualStyleBackColor = true;
            this.cmdRot90.Click += new System.EventHandler(this.cmdRot90_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ante Spoke Start:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Spoke Start:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Spoke Size:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thickness:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ante Spoke Size:";
            // 
            // grpAppearance
            // 
            this.grpAppearance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpAppearance.Controls.Add(this.chkDrawOffset);
            this.grpAppearance.Controls.Add(this.chkAlwaysCreateOnEdit);
            this.grpAppearance.Controls.Add(this.chkNeverSnapCircle);
            this.grpAppearance.Controls.Add(this.chkShowSideCount);
            this.grpAppearance.Controls.Add(this.chkShowTotalLength);
            this.grpAppearance.Controls.Add(this.chkShowLineLength);
            this.grpAppearance.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAppearance.Location = new System.Drawing.Point(0, 0);
            this.grpAppearance.Name = "grpAppearance";
            this.grpAppearance.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.grpAppearance.Size = new System.Drawing.Size(200, 168);
            this.grpAppearance.TabIndex = 0;
            this.grpAppearance.TabStop = false;
            this.grpAppearance.Text = "Appearance";
            // 
            // chkDrawOffset
            // 
            this.chkDrawOffset.AutoSize = true;
            this.chkDrawOffset.Location = new System.Drawing.Point(12, 118);
            this.chkDrawOffset.Name = "chkDrawOffset";
            this.chkDrawOffset.Size = new System.Drawing.Size(164, 17);
            this.chkDrawOffset.TabIndex = 4;
            this.chkDrawOffset.Text = "Align segment against handle";
            this.chkDrawOffset.UseVisualStyleBackColor = true;
            this.chkDrawOffset.CheckedChanged += new System.EventHandler(this.chkDrawOffset_CheckedChanged);
            // 
            // chkAlwaysCreateOnEdit
            // 
            this.chkAlwaysCreateOnEdit.AutoSize = true;
            this.chkAlwaysCreateOnEdit.Location = new System.Drawing.Point(12, 141);
            this.chkAlwaysCreateOnEdit.Name = "chkAlwaysCreateOnEdit";
            this.chkAlwaysCreateOnEdit.Size = new System.Drawing.Size(141, 17);
            this.chkAlwaysCreateOnEdit.TabIndex = 5;
            this.chkAlwaysCreateOnEdit.Text = "Always start over on edit";
            this.chkAlwaysCreateOnEdit.UseVisualStyleBackColor = true;
            this.chkAlwaysCreateOnEdit.CheckedChanged += new System.EventHandler(this.chkAlwaysCreateOnEdit_CheckedChanged);
            // 
            // chkNeverSnapCircle
            // 
            this.chkNeverSnapCircle.AutoSize = true;
            this.chkNeverSnapCircle.Location = new System.Drawing.Point(12, 95);
            this.chkNeverSnapCircle.Name = "chkNeverSnapCircle";
            this.chkNeverSnapCircle.Size = new System.Drawing.Size(153, 17);
            this.chkNeverSnapCircle.TabIndex = 3;
            this.chkNeverSnapCircle.Text = "Never snap vertices to grid";
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
            // chkDrawAnteSpokes
            // 
            this.chkDrawAnteSpokes.AutoSize = true;
            this.chkDrawAnteSpokes.Location = new System.Drawing.Point(13, 0);
            this.chkDrawAnteSpokes.Name = "chkDrawAnteSpokes";
            this.chkDrawAnteSpokes.Size = new System.Drawing.Size(115, 17);
            this.chkDrawAnteSpokes.TabIndex = 16;
            this.chkDrawAnteSpokes.Text = "Draw Ante Spokes";
            this.chkDrawAnteSpokes.UseVisualStyleBackColor = true;
            this.chkDrawAnteSpokes.CheckedChanged += new System.EventHandler(this.chkDrawAnteSpokes_CheckedChanged);
            // 
            // chkDrawSpokes
            // 
            this.chkDrawSpokes.AutoSize = true;
            this.chkDrawSpokes.Location = new System.Drawing.Point(13, 0);
            this.chkDrawSpokes.Name = "chkDrawSpokes";
            this.chkDrawSpokes.Size = new System.Drawing.Size(90, 17);
            this.chkDrawSpokes.TabIndex = 13;
            this.chkDrawSpokes.Text = "Draw Spokes";
            this.chkDrawSpokes.UseVisualStyleBackColor = true;
            this.chkDrawSpokes.CheckedChanged += new System.EventHandler(this.chkDrawSpokes_CheckedChanged);
            // 
            // chkFillCenter
            // 
            this.chkFillCenter.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkFillCenter, 2);
            this.chkFillCenter.Location = new System.Drawing.Point(3, 33);
            this.chkFillCenter.Name = "chkFillCenter";
            this.chkFillCenter.Size = new System.Drawing.Size(184, 17);
            this.chkFillCenter.TabIndex = 12;
            this.chkFillCenter.Text = "Fill center when thickness is used";
            this.chkFillCenter.UseVisualStyleBackColor = true;
            this.chkFillCenter.CheckedChanged += new System.EventHandler(this.chkFillCenter_CheckedChanged);
            // 
            // grpTools
            // 
            this.grpTools.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpTools.Controls.Add(this.cmdSetTotalLength);
            this.grpTools.Controls.Add(this.udDesiredTotal);
            this.grpTools.Controls.Add(this.lblSetTotalLength);
            this.grpTools.Controls.Add(this.udDesiredLength);
            this.grpTools.Controls.Add(this.cmdResizeToFit);
            this.grpTools.Controls.Add(this.lblDesiredLength);
            this.grpTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTools.Location = new System.Drawing.Point(0, 563);
            this.grpTools.Name = "grpTools";
            this.grpTools.Padding = new System.Windows.Forms.Padding(10);
            this.grpTools.Size = new System.Drawing.Size(200, 114);
            this.grpTools.TabIndex = 19;
            this.grpTools.TabStop = false;
            this.grpTools.Text = "Tools";
            // 
            // cmdSetTotalLength
            // 
            this.cmdSetTotalLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSetTotalLength.Location = new System.Drawing.Point(111, 79);
            this.cmdSetTotalLength.Name = "cmdSetTotalLength";
            this.cmdSetTotalLength.Size = new System.Drawing.Size(75, 23);
            this.cmdSetTotalLength.TabIndex = 22;
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
            this.udDesiredTotal.Location = new System.Drawing.Point(13, 82);
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
            this.udDesiredTotal.Size = new System.Drawing.Size(92, 20);
            this.udDesiredTotal.TabIndex = 21;
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
            this.lblSetTotalLength.Location = new System.Drawing.Point(13, 66);
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
            this.udDesiredLength.Location = new System.Drawing.Point(13, 40);
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
            this.udDesiredLength.Size = new System.Drawing.Size(93, 20);
            this.udDesiredLength.TabIndex = 19;
            this.udDesiredLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmdResizeToFit
            // 
            this.cmdResizeToFit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdResizeToFit.Location = new System.Drawing.Point(112, 37);
            this.cmdResizeToFit.Name = "cmdResizeToFit";
            this.cmdResizeToFit.Size = new System.Drawing.Size(75, 23);
            this.cmdResizeToFit.TabIndex = 20;
            this.cmdResizeToFit.Text = "Resize";
            this.cmdResizeToFit.UseVisualStyleBackColor = true;
            this.cmdResizeToFit.Click += new System.EventHandler(this.cmdResizeToFit_Click);
            // 
            // lblDesiredLength
            // 
            this.lblDesiredLength.AutoSize = true;
            this.lblDesiredLength.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblDesiredLength.Location = new System.Drawing.Point(13, 23);
            this.lblDesiredLength.Name = "lblDesiredLength";
            this.lblDesiredLength.Size = new System.Drawing.Size(90, 13);
            this.lblDesiredLength.TabIndex = 1;
            this.lblDesiredLength.Text = "Set all linedefs to:";
            // 
            // grpSpoke
            // 
            this.grpSpoke.AutoSize = true;
            this.grpSpoke.Controls.Add(this.tblSpoke);
            this.grpSpoke.Controls.Add(this.chkDrawSpokes);
            this.grpSpoke.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSpoke.Location = new System.Drawing.Point(0, 397);
            this.grpSpoke.Name = "grpSpoke";
            this.grpSpoke.Padding = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.grpSpoke.Size = new System.Drawing.Size(200, 86);
            this.grpSpoke.TabIndex = 13;
            this.grpSpoke.TabStop = false;
            // 
            // tblSpoke
            // 
            this.tblSpoke.AutoSize = true;
            this.tblSpoke.ColumnCount = 2;
            this.tblSpoke.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSpoke.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSpoke.Controls.Add(this.udSpokeStart, 1, 1);
            this.tblSpoke.Controls.Add(this.udSpokeSize, 1, 0);
            this.tblSpoke.Controls.Add(this.label3, 0, 0);
            this.tblSpoke.Controls.Add(this.label4, 0, 1);
            this.tblSpoke.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblSpoke.Location = new System.Drawing.Point(10, 16);
            this.tblSpoke.Name = "tblSpoke";
            this.tblSpoke.RowCount = 2;
            this.tblSpoke.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSpoke.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSpoke.Size = new System.Drawing.Size(180, 60);
            this.tblSpoke.TabIndex = 6;
            // 
            // udSpokeStart
            // 
            this.udSpokeStart.AllowDecimal = true;
            this.udSpokeStart.AllowExpressions = false;
            this.udSpokeStart.AllowNegative = true;
            this.udSpokeStart.AllowRelative = true;
            this.udSpokeStart.BackColor = System.Drawing.Color.Transparent;
            this.udSpokeStart.ButtonStep = 1;
            this.udSpokeStart.ButtonStepBig = 32F;
            this.udSpokeStart.ButtonStepFloat = 1F;
            this.udSpokeStart.ButtonStepSmall = 8F;
            this.udSpokeStart.ButtonStepsUseModifierKeys = true;
            this.udSpokeStart.ButtonStepsWrapAround = true;
            this.udSpokeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udSpokeStart.Location = new System.Drawing.Point(75, 33);
            this.udSpokeStart.Name = "udSpokeStart";
            this.udSpokeStart.Size = new System.Drawing.Size(119, 24);
            this.udSpokeStart.StepValues = null;
            this.udSpokeStart.TabIndex = 11;
            this.udSpokeStart.WhenTextChanged += new System.EventHandler(this.udSpokeStart_WhenTextChanged);
            this.udSpokeStart.WhenEnterPressed += new System.EventHandler(this.UdSpokeStart_Apply);
            this.udSpokeStart.Leave += new System.EventHandler(this.UdSpokeStart_Apply);
            // 
            // udSpokeSize
            // 
            this.udSpokeSize.AllowDecimal = true;
            this.udSpokeSize.AllowExpressions = false;
            this.udSpokeSize.AllowNegative = true;
            this.udSpokeSize.AllowRelative = true;
            this.udSpokeSize.BackColor = System.Drawing.Color.Transparent;
            this.udSpokeSize.ButtonStep = 1;
            this.udSpokeSize.ButtonStepBig = 32F;
            this.udSpokeSize.ButtonStepFloat = 1F;
            this.udSpokeSize.ButtonStepSmall = 8F;
            this.udSpokeSize.ButtonStepsUseModifierKeys = true;
            this.udSpokeSize.ButtonStepsWrapAround = true;
            this.udSpokeSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udSpokeSize.Location = new System.Drawing.Point(75, 3);
            this.udSpokeSize.Name = "udSpokeSize";
            this.udSpokeSize.Size = new System.Drawing.Size(119, 24);
            this.udSpokeSize.StepValues = null;
            this.udSpokeSize.TabIndex = 9;
            this.udSpokeSize.WhenTextChanged += new System.EventHandler(this.UdSpokeSize_WhenTextChanged);
            this.udSpokeSize.WhenEnterPressed += new System.EventHandler(this.UdSpokeSize_Apply);
            this.udSpokeSize.Leave += new System.EventHandler(this.UdSpokeSize_Apply);
            // 
            // grpAnte
            // 
            this.grpAnte.Controls.Add(this.tblAnte);
            this.grpAnte.Controls.Add(this.chkDrawAnteSpokes);
            this.grpAnte.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAnte.Location = new System.Drawing.Point(0, 483);
            this.grpAnte.Name = "grpAnte";
            this.grpAnte.Padding = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.grpAnte.Size = new System.Drawing.Size(200, 80);
            this.grpAnte.TabIndex = 16;
            this.grpAnte.TabStop = false;
            // 
            // tblAnte
            // 
            this.tblAnte.AutoSize = true;
            this.tblAnte.ColumnCount = 2;
            this.tblAnte.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblAnte.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblAnte.Controls.Add(this.udAnteSpokeStart, 1, 1);
            this.tblAnte.Controls.Add(this.udAnteSpokeSize, 1, 0);
            this.tblAnte.Controls.Add(this.label7, 0, 1);
            this.tblAnte.Controls.Add(this.label6, 0, 0);
            this.tblAnte.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblAnte.Location = new System.Drawing.Point(10, 16);
            this.tblAnte.Name = "tblAnte";
            this.tblAnte.RowCount = 2;
            this.tblAnte.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblAnte.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblAnte.Size = new System.Drawing.Size(180, 60);
            this.tblAnte.TabIndex = 7;
            // 
            // udAnteSpokeStart
            // 
            this.udAnteSpokeStart.AllowDecimal = true;
            this.udAnteSpokeStart.AllowExpressions = false;
            this.udAnteSpokeStart.AllowNegative = true;
            this.udAnteSpokeStart.AllowRelative = true;
            this.udAnteSpokeStart.BackColor = System.Drawing.Color.Transparent;
            this.udAnteSpokeStart.ButtonStep = 1;
            this.udAnteSpokeStart.ButtonStepBig = 32F;
            this.udAnteSpokeStart.ButtonStepFloat = 1F;
            this.udAnteSpokeStart.ButtonStepSmall = 8F;
            this.udAnteSpokeStart.ButtonStepsUseModifierKeys = true;
            this.udAnteSpokeStart.ButtonStepsWrapAround = true;
            this.udAnteSpokeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udAnteSpokeStart.Location = new System.Drawing.Point(100, 33);
            this.udAnteSpokeStart.Name = "udAnteSpokeStart";
            this.udAnteSpokeStart.Size = new System.Drawing.Size(94, 24);
            this.udAnteSpokeStart.StepValues = null;
            this.udAnteSpokeStart.TabIndex = 13;
            this.udAnteSpokeStart.WhenTextChanged += new System.EventHandler(this.UdAnteSpokeStart_WhenTextChanged);
            this.udAnteSpokeStart.WhenEnterPressed += new System.EventHandler(this.UdAnteSpokeStart_Apply);
            this.udAnteSpokeStart.Leave += new System.EventHandler(this.UdAnteSpokeStart_Apply);
            // 
            // udAnteSpokeSize
            // 
            this.udAnteSpokeSize.AllowDecimal = true;
            this.udAnteSpokeSize.AllowExpressions = false;
            this.udAnteSpokeSize.AllowNegative = true;
            this.udAnteSpokeSize.AllowRelative = true;
            this.udAnteSpokeSize.BackColor = System.Drawing.Color.Transparent;
            this.udAnteSpokeSize.ButtonStep = 1;
            this.udAnteSpokeSize.ButtonStepBig = 32F;
            this.udAnteSpokeSize.ButtonStepFloat = 1F;
            this.udAnteSpokeSize.ButtonStepSmall = 8F;
            this.udAnteSpokeSize.ButtonStepsUseModifierKeys = true;
            this.udAnteSpokeSize.ButtonStepsWrapAround = true;
            this.udAnteSpokeSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udAnteSpokeSize.Location = new System.Drawing.Point(100, 3);
            this.udAnteSpokeSize.Name = "udAnteSpokeSize";
            this.udAnteSpokeSize.Size = new System.Drawing.Size(94, 24);
            this.udAnteSpokeSize.StepValues = null;
            this.udAnteSpokeSize.TabIndex = 12;
            this.udAnteSpokeSize.WhenTextChanged += new System.EventHandler(this.UdAnteSpokeSize_WhenTextChanged);
            this.udAnteSpokeSize.WhenEnterPressed += new System.EventHandler(this.UdAnteSpokeSize_Apply);
            this.udAnteSpokeSize.Leave += new System.EventHandler(this.UdAnteSpokeSize_Apply);
            // 
            // grpCircle
            // 
            this.grpCircle.Controls.Add(this.tableLayoutPanel1);
            this.grpCircle.Controls.Add(this.chkDrawCircle);
            this.grpCircle.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCircle.Location = new System.Drawing.Point(0, 318);
            this.grpCircle.Name = "grpCircle";
            this.grpCircle.Padding = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.grpCircle.Size = new System.Drawing.Size(200, 79);
            this.grpCircle.TabIndex = 10;
            this.grpCircle.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.udThickness, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkFillCenter, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(180, 53);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // udThickness
            // 
            this.udThickness.AllowDecimal = true;
            this.udThickness.AllowExpressions = false;
            this.udThickness.AllowNegative = true;
            this.udThickness.AllowRelative = true;
            this.udThickness.BackColor = System.Drawing.Color.Transparent;
            this.udThickness.ButtonStep = 1;
            this.udThickness.ButtonStepBig = 32F;
            this.udThickness.ButtonStepFloat = 1F;
            this.udThickness.ButtonStepSmall = 8F;
            this.udThickness.ButtonStepsUseModifierKeys = true;
            this.udThickness.ButtonStepsWrapAround = true;
            this.udThickness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udThickness.Location = new System.Drawing.Point(68, 3);
            this.udThickness.Name = "udThickness";
            this.udThickness.Size = new System.Drawing.Size(126, 24);
            this.udThickness.StepValues = null;
            this.udThickness.TabIndex = 8;
            this.udThickness.WhenTextChanged += new System.EventHandler(this.UdThickness_WhenTextChanged);
            this.udThickness.WhenEnterPressed += new System.EventHandler(this.UdThickness_Apply);
            this.udThickness.Leave += new System.EventHandler(this.UdThickness_Apply);
            // 
            // chkDrawCircle
            // 
            this.chkDrawCircle.AutoSize = true;
            this.chkDrawCircle.Location = new System.Drawing.Point(13, 0);
            this.chkDrawCircle.Name = "chkDrawCircle";
            this.chkDrawCircle.Size = new System.Drawing.Size(80, 17);
            this.chkDrawCircle.TabIndex = 10;
            this.chkDrawCircle.Text = "Draw Circle";
            this.chkDrawCircle.UseVisualStyleBackColor = true;
            this.chkDrawCircle.CheckedChanged += new System.EventHandler(this.chkDrawCircle_CheckedChanged);
            // 
            // OptionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.grpTools);
            this.Controls.Add(this.grpAnte);
            this.Controls.Add(this.grpSpoke);
            this.Controls.Add(this.grpCircle);
            this.Controls.Add(this.grpProps);
            this.Controls.Add(this.grpAppearance);
            this.Name = "OptionsPanel";
            this.Size = new System.Drawing.Size(200, 681);
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
            this.grpSpoke.ResumeLayout(false);
            this.grpSpoke.PerformLayout();
            this.tblSpoke.ResumeLayout(false);
            this.tblSpoke.PerformLayout();
            this.grpAnte.ResumeLayout(false);
            this.grpAnte.PerformLayout();
            this.tblAnte.ResumeLayout(false);
            this.tblAnte.PerformLayout();
            this.grpCircle.ResumeLayout(false);
            this.grpCircle.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.GroupBox grpProps;
        private System.Windows.Forms.TableLayoutPanel tblProps;
        private System.Windows.Forms.Label lblSidesShown;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkFillCenter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkDrawSpokes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDrawAnteSpokes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkAlwaysCreateOnEdit;
        private System.Windows.Forms.CheckBox chkDrawOffset;
        private System.Windows.Forms.GroupBox grpSpoke;
        private System.Windows.Forms.TableLayoutPanel tblSpoke;
        private System.Windows.Forms.GroupBox grpAnte;
        private System.Windows.Forms.TableLayoutPanel tblAnte;
        private System.Windows.Forms.GroupBox grpCircle;
        private System.Windows.Forms.CheckBox chkDrawCircle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button cmdRot90;
        public CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox udAngle;
        public CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox udSideCount;
        public CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox udThickness;
        public CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox udSpokeSize;
        public CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox udSpokeStart;
        public CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox udAnteSpokeSize;
        public CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox udAnteSpokeStart;
        private System.Windows.Forms.Label label1;
        public CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox udLength;
        private System.Windows.Forms.Button cmdToggleSideLock;
        public CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox udSideDraw;
        private System.Windows.Forms.ToolTip ttOptions;
    }
}
