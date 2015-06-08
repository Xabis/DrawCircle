using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeImp.DoomBuilder;

namespace TriDelta.DrawCircleMode {
    public partial class OptionsPanel : UserControl {
        private DrawCircleMode mode;
        ToolTip helpToolLinedefLength = new ToolTip();
        ToolTip helpToolLinedefTotal = new ToolTip();
        ToolTip helpToolAlwaysCreate = new ToolTip();

        public OptionsPanel(DrawCircleMode mode) {
            InitializeComponent();
            this.mode = mode;

            //help tooltips
            helpToolLinedefLength.SetToolTip(this.lblDesiredLength, "Resizes the circle so that all linedefs match the desired length.\n Useful for fitting textures.");
            helpToolLinedefTotal.SetToolTip(this.lblSetTotalLength, "Resizes the circle so that all linedefs total up to the desired length.\n Useful for wrapping a texture perfectly around a column.");
            helpToolAlwaysCreate.SetToolTip(this.chkAlwaysCreateOnEdit, "The drawing will be automatically reset\n when using the secondary mouse button.");


            //read tools settings
            udDesiredLength.Value = General.Settings.ReadPluginSetting("lastlinedeflength", 128);
            udDesiredTotal.Value = General.Settings.ReadPluginSetting("lasttotallength", 256);

            //populate from the engine
            udThickness.Value = (decimal)mode.CircleThickness;
            chkShowLineLength.Checked = mode.ShowLineLength;
            chkShowTotalLength.Checked = mode.ShowLineTotal;
            chkShowSideCount.Checked = mode.ShowSideCount;
            chkNeverSnapCircle.Checked = mode.NeverSnapCircle;
            chkFillCenter.Checked = mode.FillCenter;
            chkDrawSpokes.Checked = mode.DrawSpokes;
            chkDrawAnteSpokes.Checked = mode.DrawAnteSpokes;
            chkAlwaysCreateOnEdit.Checked = mode.AlwaysCreateOnEdit;

            udSpokeSize.Value = (decimal)mode.SpokeThickness;
            udSpokeStart.Value = (decimal)mode.SpokeMinimum;
            udSideCount.Value = (decimal)mode.CircleSides;
            udAnteSpokeSize.Value = (decimal)mode.AnteSpokeThickness;
            udAnteSpokeStart.Value = (decimal)mode.AnteSpokeMinimum;

            udSpokeSize.Enabled = chkDrawSpokes.Checked;
            udSpokeStart.Enabled = chkDrawSpokes.Checked;

            udAnteSpokeSize.Enabled = chkDrawAnteSpokes.Checked;
            udAnteSpokeStart.Enabled = chkDrawAnteSpokes.Checked;

            //set initial edit state
            EditState = false;
        }

        internal bool EditState {
            set {
                grpTools.Enabled = value;
                grpProps.Enabled = value;
            }
        }

        internal void SetAngleBox(decimal value) {
            udAngle.Value = value;
        }

        internal void SetLengthBox(decimal value) {
            udLength.Value = value;
        }

        private void cmdResizeToFit_Click(object sender, EventArgs e) {
            mode.SetSidedefLength((float)udDesiredLength.Value);
            General.Settings.WritePluginSetting("lastlinedeflength", udDesiredLength.Value);
        }
        private void cmdSetTotalLength_Click(object sender, EventArgs e) {
            mode.SetSidedefLength((float)(udDesiredTotal.Value / mode.CircleSides));
            General.Settings.WritePluginSetting("lasttotallength", udDesiredTotal.Value);
        }

        private void chkShowLineLength_CheckedChanged(object sender, EventArgs e) {
            mode.ShowLineLength = chkShowLineLength.Checked;
        }
        private void chkShowTotalLength_CheckedChanged(object sender, EventArgs e) {
            mode.ShowLineTotal = chkShowTotalLength.Checked;
        }
        private void chkShowSideCount_CheckedChanged(object sender, EventArgs e) {
            mode.ShowSideCount = chkShowSideCount.Checked;
        }
        private void chkNeverSnapCircle_CheckedChanged(object sender, EventArgs e) {
            mode.NeverSnapCircle = chkNeverSnapCircle.Checked;
        }
        private void udAngle_ValueChanged(object sender, EventArgs e) {
            if (udAngle.Value < 0)
                udAngle.Value = 359;
            else if (udAngle.Value > 359)
                udAngle.Value = 0;
            mode.SetAngle((float)udAngle.Value, true);
        }
        private void udLength_ValueChanged(object sender, EventArgs e) {
            mode.SetLength((float)udLength.Value, true);
        }

        private void udThickness_ValueChanged(object sender, EventArgs e) {
            mode.CircleThickness = (float)udThickness.Value;
        }

        private void chkFillCenter_CheckedChanged(object sender, EventArgs e) {
            mode.FillCenter = chkFillCenter.Checked;
        }

        private void chkDrawSpokes_CheckedChanged(object sender, EventArgs e) {
            mode.DrawSpokes = chkDrawSpokes.Checked;
            udSpokeSize.Enabled = chkDrawSpokes.Checked;
            udSpokeStart.Enabled = chkDrawSpokes.Checked;
        }

        private void udSpokeSize_ValueChanged(object sender, EventArgs e) {
            mode.SpokeThickness = (float)udSpokeSize.Value;
        }

        private void udSpokeStart_ValueChanged(object sender, EventArgs e) {
            mode.SpokeMinimum = (float)udSpokeStart.Value;
        }

        private void udSideCount_ValueChanged(object sender, EventArgs e) {
            mode.CircleSides = (int)udSideCount.Value;
        }

        private void chkDrawAnteSpokes_CheckedChanged(object sender, EventArgs e) {
            mode.DrawAnteSpokes = chkDrawAnteSpokes.Checked;
            udAnteSpokeSize.Enabled = chkDrawAnteSpokes.Checked;
            udAnteSpokeStart.Enabled = chkDrawAnteSpokes.Checked;
        }

        private void udAnteSpokeSize_ValueChanged(object sender, EventArgs e) {
            mode.AnteSpokeThickness = (float)udAnteSpokeSize.Value;
        }

        private void udAnteSpokeStart_ValueChanged(object sender, EventArgs e) {
            mode.AnteSpokeMinimum = (float)udAnteSpokeStart.Value;
        }

        private void chkAlwaysCreateOnEdit_CheckedChanged(object sender, EventArgs e) {
            mode.AlwaysCreateOnEdit = chkAlwaysCreateOnEdit.Checked;
        }
    }
}
