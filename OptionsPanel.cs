using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeImp.DoomBuilder;

namespace TriDelta.DrawCircleMode
{
   public partial class OptionsPanel : UserControl
   {
      private DrawCircleMode mode;
      ToolTip helpToolLinedefLength = new ToolTip();
      ToolTip helpToolLinedefTotal = new ToolTip();
      bool suppressEvent;

      public OptionsPanel(DrawCircleMode mode)
      {
         InitializeComponent();
         this.mode = mode;

         //help tooltips
         helpToolLinedefLength.SetToolTip(this.lblDesiredLength, "Resizes the circle so that all linedefs match the desired length. Useful for fitting textures.");
         helpToolLinedefTotal.SetToolTip(this.lblSetTotalLength, "Resizes the circle so that all linedefs total up to the desired length. Useful for wrapping a texture perfectly around a column.");

         //read settings
         udDesiredLength.Value = General.Settings.ReadPluginSetting("lastlinedeflength", 128);
         udDesiredTotal.Value = General.Settings.ReadPluginSetting("lasttotallength", 256);
         chkShowLineLength.Checked = mode.ShowLineLength;
         chkShowTotalLength.Checked = mode.ShowLineTotal;
         chkShowSideCount.Checked = mode.ShowSideCount;
         chkNeverSnapCircle.Checked = mode.NeverSnapCircle;

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
         suppressEvent = true;
         udAngle.Value = value;
         suppressEvent = false;
      }

      internal void SetLengthBox(decimal value) {
         suppressEvent = true;
         udLength.Value = value;
         suppressEvent = false;
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
   }
}
