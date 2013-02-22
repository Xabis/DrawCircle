namespace TriDelta.DrawCircleMode
{
   partial class OptionsPanel
   {
      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.lblAngle = new System.Windows.Forms.Label();
         this.grpProps = new System.Windows.Forms.GroupBox();
         this.tblProps = new System.Windows.Forms.TableLayoutPanel();
         this.udAngle = new System.Windows.Forms.NumericUpDown();
         this.lblLength = new System.Windows.Forms.Label();
         this.udLength = new System.Windows.Forms.NumericUpDown();
         this.grpAppearance = new System.Windows.Forms.GroupBox();
         this.chkShowSideCount = new System.Windows.Forms.CheckBox();
         this.chkShowTotalLength = new System.Windows.Forms.CheckBox();
         this.chkShowLineLength = new System.Windows.Forms.CheckBox();
         this.grpTools = new System.Windows.Forms.GroupBox();
         this.lblDesiredLength = new System.Windows.Forms.Label();
         this.cmdResizeToFit = new System.Windows.Forms.Button();
         this.udDesiredLength = new System.Windows.Forms.NumericUpDown();
         this.chkNeverSnapCircle = new System.Windows.Forms.CheckBox();
         this.lblSetTotalLength = new System.Windows.Forms.Label();
         this.udDesiredTotal = new System.Windows.Forms.NumericUpDown();
         this.cmdSetTotalLength = new System.Windows.Forms.Button();
         this.grpProps.SuspendLayout();
         this.tblProps.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.udAngle)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.udLength)).BeginInit();
         this.grpAppearance.SuspendLayout();
         this.grpTools.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.udDesiredLength)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.udDesiredTotal)).BeginInit();
         this.SuspendLayout();
         // 
         // lblAngle
         // 
         this.lblAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.lblAngle.AutoSize = true;
         this.lblAngle.Location = new System.Drawing.Point(3, 6);
         this.lblAngle.Name = "lblAngle";
         this.lblAngle.Size = new System.Drawing.Size(43, 13);
         this.lblAngle.TabIndex = 0;
         this.lblAngle.Text = "Angle:";
         // 
         // grpProps
         // 
         this.grpProps.AutoSize = true;
         this.grpProps.Controls.Add(this.tblProps);
         this.grpProps.Dock = System.Windows.Forms.DockStyle.Top;
         this.grpProps.Location = new System.Drawing.Point(0, 128);
         this.grpProps.Name = "grpProps";
         this.grpProps.Padding = new System.Windows.Forms.Padding(15);
         this.grpProps.Size = new System.Drawing.Size(254, 95);
         this.grpProps.TabIndex = 1;
         this.grpProps.TabStop = false;
         this.grpProps.Text = "Properties";
         // 
         // tblProps
         // 
         this.tblProps.AutoSize = true;
         this.tblProps.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.tblProps.ColumnCount = 2;
         this.tblProps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tblProps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tblProps.Controls.Add(this.udAngle, 1, 0);
         this.tblProps.Controls.Add(this.lblAngle, 0, 0);
         this.tblProps.Controls.Add(this.lblLength, 0, 1);
         this.tblProps.Controls.Add(this.udLength, 1, 1);
         this.tblProps.Dock = System.Windows.Forms.DockStyle.Top;
         this.tblProps.Location = new System.Drawing.Point(15, 28);
         this.tblProps.Name = "tblProps";
         this.tblProps.RowCount = 2;
         this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tblProps.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tblProps.Size = new System.Drawing.Size(224, 52);
         this.tblProps.TabIndex = 0;
         // 
         // udAngle
         // 
         this.udAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.udAngle.AutoSize = true;
         this.udAngle.DecimalPlaces = 1;
         this.udAngle.Location = new System.Drawing.Point(52, 3);
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
         this.udAngle.Size = new System.Drawing.Size(169, 20);
         this.udAngle.TabIndex = 1;
         this.udAngle.ValueChanged += new System.EventHandler(this.udAngle_ValueChanged);
         // 
         // lblLength
         // 
         this.lblLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.lblLength.AutoSize = true;
         this.lblLength.Location = new System.Drawing.Point(3, 32);
         this.lblLength.Name = "lblLength";
         this.lblLength.Size = new System.Drawing.Size(43, 13);
         this.lblLength.TabIndex = 2;
         this.lblLength.Text = "Length:";
         // 
         // udLength
         // 
         this.udLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.udLength.AutoSize = true;
         this.udLength.Location = new System.Drawing.Point(52, 29);
         this.udLength.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
         this.udLength.Name = "udLength";
         this.udLength.Size = new System.Drawing.Size(169, 20);
         this.udLength.TabIndex = 3;
         this.udLength.ValueChanged += new System.EventHandler(this.udLength_ValueChanged);
         // 
         // grpAppearance
         // 
         this.grpAppearance.AutoSize = true;
         this.grpAppearance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.grpAppearance.Controls.Add(this.chkNeverSnapCircle);
         this.grpAppearance.Controls.Add(this.chkShowSideCount);
         this.grpAppearance.Controls.Add(this.chkShowTotalLength);
         this.grpAppearance.Controls.Add(this.chkShowLineLength);
         this.grpAppearance.Dock = System.Windows.Forms.DockStyle.Top;
         this.grpAppearance.Location = new System.Drawing.Point(0, 0);
         this.grpAppearance.Name = "grpAppearance";
         this.grpAppearance.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
         this.grpAppearance.Size = new System.Drawing.Size(254, 128);
         this.grpAppearance.TabIndex = 2;
         this.grpAppearance.TabStop = false;
         this.grpAppearance.Text = "Appearance";
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
         this.grpTools.Location = new System.Drawing.Point(0, 223);
         this.grpTools.Name = "grpTools";
         this.grpTools.Padding = new System.Windows.Forms.Padding(15);
         this.grpTools.Size = new System.Drawing.Size(254, 138);
         this.grpTools.TabIndex = 3;
         this.grpTools.TabStop = false;
         this.grpTools.Text = "Tools";
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
         // OptionsPanel
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grpTools);
         this.Controls.Add(this.grpProps);
         this.Controls.Add(this.grpAppearance);
         this.Name = "OptionsPanel";
         this.Size = new System.Drawing.Size(254, 367);
         this.grpProps.ResumeLayout(false);
         this.grpProps.PerformLayout();
         this.tblProps.ResumeLayout(false);
         this.tblProps.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.udAngle)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.udLength)).EndInit();
         this.grpAppearance.ResumeLayout(false);
         this.grpAppearance.PerformLayout();
         this.grpTools.ResumeLayout(false);
         this.grpTools.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.udDesiredLength)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.udDesiredTotal)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblAngle;
      private System.Windows.Forms.GroupBox grpProps;
      private System.Windows.Forms.TableLayoutPanel tblProps;
      private System.Windows.Forms.NumericUpDown udAngle;
      private System.Windows.Forms.Label lblLength;
      private System.Windows.Forms.NumericUpDown udLength;
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
   }
}
