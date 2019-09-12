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

        //TRack last value for relative processing
        int LastSides = 0;
        int LastDrawnSides = 0;
        float LastAngle = 0;
        float LastLength = 0;
        float LastThickness = 0;
        float LastSpokeSize = 0;
        float LastSpokeStart = 0;
        float LastAnteSize = 0;
        float LastAnteStart = 0;

        //Angle/Len/Sides can be set bi-directionally, so need to track state to prevent unwanted updates
        bool bUpdatingSides = false;
        bool bUpdatingAngle = false;
        bool bUpdatingLength = false;

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
            chkShowLineLength.Checked = mode.ShowLineLength;
            chkShowTotalLength.Checked = mode.ShowLineTotal;
            chkShowSideCount.Checked = mode.ShowSideCount;
            chkNeverSnapCircle.Checked = mode.NeverSnapCircle;
            chkFillCenter.Checked = mode.FillCenter;
            chkDrawCircle.Checked = mode.DrawCircle;
            chkDrawOffset.Checked = mode.DrawOffset;
            chkDrawSpokes.Checked = mode.DrawSpokes;
            chkDrawAnteSpokes.Checked = mode.DrawAnteSpokes;
            chkAlwaysCreateOnEdit.Checked = mode.AlwaysCreateOnEdit;

            LastSides = mode.CircleSides;
            LastDrawnSides = mode.DrawnSides;
            LastThickness = mode.CircleThickness;
            LastSpokeSize = mode.SpokeThickness;
            LastSpokeStart = mode.SpokeMinimum;
            LastAnteSize = mode.AnteSpokeThickness;
            LastAnteStart = mode.AnteSpokeMinimum;

            udSideCount.Text = LastSides.ToString();
            udSideDraw.Text = LastDrawnSides.ToString();
            udThickness.Text = LastThickness.ToString("0.###");
            udSpokeSize.Text = LastSpokeSize.ToString("0.###");
            udSpokeStart.Text = LastSpokeStart.ToString("0.###");
            udAnteSpokeSize.Text = LastAnteSize.ToString("0.###");
            udAnteSpokeStart.Text = LastAnteStart.ToString("0.###");

            udSideDraw.Enabled = !mode.LockSides;
            chkFillCenter.Enabled = chkDrawCircle.Checked;
            udThickness.Enabled = chkDrawCircle.Checked;

            udSpokeSize.Enabled = chkDrawSpokes.Checked;
            udSpokeStart.Enabled = chkDrawSpokes.Checked;

            udAnteSpokeSize.Enabled = chkDrawAnteSpokes.Checked;
            udAnteSpokeStart.Enabled = chkDrawAnteSpokes.Checked;

            //set initial edit state
            EditState = false;

            mode.ModeChanged += mode_ModeChanged;
        }

        private void mode_ModeChanged(DrawCircleMode mode) {
            if (!bUpdatingSides)
                udSideCount.Text = mode.CircleSides.ToString();
            udSideDraw.Text = mode.DrawnSides.ToString();
        }

        internal bool EditState {
            set {
                grpTools.Enabled = value;
                grpProps.Enabled = value;
            }
        }

        internal void SetAngleBox(float value) {
            if (bUpdatingAngle)
                return;
            LastAngle = value;
            udAngle.Text = value.ToString("0.###");
        }

        internal void SetLengthBox(float value) {
            if (bUpdatingLength)
                return;
            LastLength = value;
            udLength.Text = value.ToString("0.###");
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

        private void chkFillCenter_CheckedChanged(object sender, EventArgs e) {
            mode.FillCenter = chkFillCenter.Checked;
        }

        private void chkDrawSpokes_CheckedChanged(object sender, EventArgs e) {
            mode.DrawSpokes = chkDrawSpokes.Checked;
            udSpokeSize.Enabled = chkDrawSpokes.Checked;
            udSpokeStart.Enabled = chkDrawSpokes.Checked;
        }

        private void chkDrawAnteSpokes_CheckedChanged(object sender, EventArgs e) {
            mode.DrawAnteSpokes = chkDrawAnteSpokes.Checked;
            udAnteSpokeSize.Enabled = chkDrawAnteSpokes.Checked;
            udAnteSpokeStart.Enabled = chkDrawAnteSpokes.Checked;
        }

        private void chkAlwaysCreateOnEdit_CheckedChanged(object sender, EventArgs e) {
            mode.AlwaysCreateOnEdit = chkAlwaysCreateOnEdit.Checked;
        }

        private void chkDrawOffset_CheckedChanged(object sender, EventArgs e) {
            mode.DrawOffset = chkDrawOffset.Checked;
        }

        private void chkDrawCircle_CheckedChanged(object sender, EventArgs e) {
            mode.DrawCircle = chkDrawCircle.Checked;
            chkFillCenter.Enabled = chkDrawCircle.Checked;
            udThickness.Enabled = chkDrawCircle.Checked;
        }


        //Side Count
        //-------------------------------
        private void UdSideCount_WhenTextChanged(object sender, EventArgs e) {
            bUpdatingSides = true;
            mode.CircleSides = udSideCount.GetResult(LastSides);
            bUpdatingSides = false;
        }
        private void UdSideCount_Apply(object sender, EventArgs e) {
            LastSides = udSideCount.GetResult(LastSides);
            udSideCount.Text = LastSides.ToString();
        }
        private void udSideDraw_WhenTextChanged(object sender, EventArgs e) {
            mode.DrawnSides = udSideDraw.GetResult(LastDrawnSides);
        }
        private void udSideDraw_Apply(object sender, EventArgs e) {
            LastDrawnSides = udSideDraw.GetResult(LastDrawnSides);
            udSideDraw.Text = LastDrawnSides.ToString();
        }
        private void cmdToggleSideLock_Click(object sender, EventArgs e) {
            mode.LockSides = !mode.LockSides;
            udSideDraw.Enabled = !mode.LockSides;
        }

        //Angle
        //-------------------------------
        private void UpdateAngle(float value, bool apply = false) {
            bUpdatingAngle = true;
            if (value < 0)
                value = 360 - Math.Abs(value % 360);
            else if (value >= 360)
                value = 0 + Math.Abs(value % 360);
            mode.SetAngle(value, true);

            //Only update if a modifier is not currently in place. Clamp to 3 digits and prevent exp notation.
            float boxtext;
            if (apply || float.TryParse(udAngle.Text, out boxtext)) {
                udAngle.Text = value.ToString("0.###");
                LastAngle = value;
            }
            bUpdatingAngle = false;
        }
        private void UdAngle_WhenTextChanged(object sender, EventArgs e) {
            UpdateAngle(udAngle.GetResultFloat(LastAngle));
        }
        private void UdAngle_Apply(object sender, EventArgs e) {
            UpdateAngle(udAngle.GetResultFloat(LastAngle), true);
        }
        private void cmdRot90_Click(object sender, EventArgs e) {
            UpdateAngle(udAngle.GetResultFloat(LastAngle) + 90f);
        }


        //Length
        //-------------------------------
        private void UpdateLength(float value, bool apply = false) {
            bUpdatingLength = true;
            mode.SetLength(value, true);

            //Only update if a modifier is not currently in place. Clamp to 3 digits and prevent exp notation.
            float boxtext;
            if (apply || float.TryParse(udLength.Text, out boxtext)) {
                udLength.Text = value.ToString("0.###");
                LastLength = value;
            }
            bUpdatingLength = false;
        }
        private void UdLength_WhenTextChanged(object sender, EventArgs e) {
            UpdateLength(udLength.GetResultFloat(LastLength));
        }
        private void UdLength_Apply(object sender, EventArgs e) {
            UpdateLength(udLength.GetResultFloat(LastLength), true);
        }

        //Thickness
        //-------------------------------
        private void UdThickness_WhenTextChanged(object sender, EventArgs e) {
            mode.CircleThickness = udThickness.GetResultFloat(LastThickness);
        }
        private void UdThickness_Apply(object sender, EventArgs e) {
            LastThickness = udThickness.GetResultFloat(LastThickness);
            udThickness.Text = LastThickness.ToString();
        }

        //Spokes
        //-------------------------------
        private void UdSpokeSize_WhenTextChanged(object sender, EventArgs e) {
            mode.SpokeThickness = udSpokeSize.GetResultFloat(LastSpokeSize);
        }
        private void UdSpokeSize_Apply(object sender, EventArgs e) {
            LastSpokeSize = udSpokeSize.GetResultFloat(LastSpokeSize);
            udSpokeSize.Text = LastSpokeSize.ToString();
        }

        private void udSpokeStart_WhenTextChanged(object sender, EventArgs e) {
            mode.SpokeMinimum = udSpokeStart.GetResultFloat(LastSpokeStart);
        }
        private void UdSpokeStart_Apply(object sender, EventArgs e) {
            LastSpokeStart = udSpokeStart.GetResultFloat(LastSpokeStart);
            udSpokeStart.Text = LastSpokeStart.ToString();
        }

        private void UdAnteSpokeSize_WhenTextChanged(object sender, EventArgs e) {
            mode.AnteSpokeThickness = udAnteSpokeSize.GetResultFloat(LastAnteSize);
        }
        private void UdAnteSpokeSize_Apply(object sender, EventArgs e) {
            LastAnteSize = udAnteSpokeSize.GetResultFloat(LastAnteSize);
            udAnteSpokeSize.Text = LastAnteSize.ToString();
        }

        private void UdAnteSpokeStart_WhenTextChanged(object sender, EventArgs e) {
            mode.AnteSpokeMinimum = udAnteSpokeStart.GetResultFloat(LastAnteStart);
        }
        private void UdAnteSpokeStart_Apply(object sender, EventArgs e) {
            LastAnteStart = udAnteSpokeStart.GetResultFloat(LastAnteStart);
            udAnteSpokeStart.Text = LastAnteStart.ToString();
        }
    }
}
