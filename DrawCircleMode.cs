using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using CodeImp.DoomBuilder;
using CodeImp.DoomBuilder.Rendering;
using CodeImp.DoomBuilder.Editing;
using CodeImp.DoomBuilder.Actions;
using CodeImp.DoomBuilder.Geometry;
using CodeImp.DoomBuilder.Map;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using CodeImp.DoomBuilder.Windows;
using System.Windows.Forms.Design;
using CodeImp.DoomBuilder.Controls;

namespace TriDelta.DrawCircleMode {
   [EditMode(
      DisplayName = "Draw Circle Mode",
      SwitchAction = "drawcirclemode",
      ButtonImage = "icon.png",
      ButtonOrder = 501,
      ButtonGroup = "000_editing",
      SafeStartMode = false,
      Volatile = true,
      Optional = false,
      AllowCopyPaste = false
   )]
   public class DrawCircleMode : ClassicMode {
      protected string textUndoEntry = "Draw Circle";
      protected string textStatusCreated = "Circle Created.";

      private ControlHandle   handleInner;
      private ControlHandle   handleOuter;
      private ControlHandle   handleCurrent;
      private LineLengthLabel labelGuideLength;
      private TextLabel       labelSideCount;
      private TextLabel       labelSizeLength;

      private PixelColor pcHandle;
      private PixelColor pcLineSnap = General.Colors.Selection;
      private PixelColor pcLineFree = General.Colors.Highlight;
      private PixelColor pcHandleFill = General.Colors.Background;

      private const float GRIP_SIZE      = 9.0f;
      private const float LINE_THICKNESS = 0.8f;
		private const float TEXT_SCALE     = 14f;

      private bool snapcircletogrid;
      private bool snapguidetogrid;
      private bool neversnapcircle;

      private bool showlinelength;
      private bool showlinetotal;
      private bool showsidecount;

      private bool isCreating; //force fire updates on mouse move if creating the guide

      private List<DrawnVertex> editCircle;
      private int               editSides;

      private ToolStripItem tbAddSide;
      private ToolStripItem tbRemoveSide;
      private ToolStripItem tbRotateOriginCW;
      private ToolStripItem tbRotateOriginCCW;
      private ToolStripItem tbSwapHandles;

      OptionsPanel panel;
      Docker docker;

      public DrawCircleMode() {
         pcHandle = General.Colors.BrightColors[new Random().Next(General.Colors.BrightColors.Length - 1)];
         labelGuideLength = new LineLengthLabel(true);

         labelSideCount = new TextLabel(3);
			labelSideCount.AlignX = TextAlignmentX.Center;
			labelSideCount.AlignY = TextAlignmentY.Middle;
			labelSideCount.Color = General.Colors.Highlight;
			labelSideCount.Backcolor = General.Colors.Background;
			labelSideCount.Scale = TEXT_SCALE;
			labelSideCount.TransformCoords = true;

         labelSizeLength = new TextLabel(3);
         labelSizeLength.AlignX = TextAlignmentX.Center;
         labelSizeLength.AlignY = TextAlignmentY.Middle;
         labelSizeLength.Color = General.Colors.Highlight;
         labelSizeLength.Backcolor = General.Colors.Background;
         labelSizeLength.Scale = TEXT_SCALE;
         labelSizeLength.TransformCoords = true;


         showlinelength = General.Settings.ReadPluginSetting("showlinelength", true);
         showlinetotal = General.Settings.ReadPluginSetting("showlinetotal", true);
         showsidecount = General.Settings.ReadPluginSetting("showsidecount", true);
         neversnapcircle = General.Settings.ReadPluginSetting("neversnapcircle", true);

         editCircle = new List<DrawnVertex>();
         editSides = General.Settings.ReadPluginSetting("editsides", 10);

         tbAddSide = new ToolStripButton(GetResourceImage("TriDelta.DrawCircleMode.icon_increase.png"));
         tbAddSide.Text = "Increase Sides";
         tbAddSide.DisplayStyle = ToolStripItemDisplayStyle.Image;
         tbAddSide.Enabled = false;
         tbAddSide.Click += new EventHandler(tbAddSide_Click);

         tbRemoveSide = new ToolStripButton(GetResourceImage("TriDelta.DrawCircleMode.icon_decrease.png"));
         tbRemoveSide.Text = "Decrease Sides";
         tbRemoveSide.DisplayStyle = ToolStripItemDisplayStyle.Image;
         tbRemoveSide.Enabled = false;
         tbRemoveSide.Click += new EventHandler(tbRemoveSide_Click);

         tbRotateOriginCW = new ToolStripButton(GetResourceImage("TriDelta.DrawCircleMode.icon_rotate_cw.png"));
         tbRotateOriginCW.Text = "Rotate CW";
         tbRotateOriginCW.DisplayStyle = ToolStripItemDisplayStyle.Image;
         tbRotateOriginCW.Enabled = false;
         tbRotateOriginCW.Click += new EventHandler(tbRotateOriginCW_Click);

         tbRotateOriginCCW = new ToolStripButton(GetResourceImage("TriDelta.DrawCircleMode.icon_rotate_ccw.png"));
         tbRotateOriginCCW.Text = "Rotate CCW";
         tbRotateOriginCCW.DisplayStyle = ToolStripItemDisplayStyle.Image;
         tbRotateOriginCCW.Enabled = false;
         tbRotateOriginCCW.Click += new EventHandler(tbRotateOriginCCW_Click);

         tbSwapHandles = new ToolStripButton(GetResourceImage("TriDelta.DrawCircleMode.icon_swap.png"));
         tbSwapHandles.Text = "Swap Handle Positions";
         tbSwapHandles.DisplayStyle = ToolStripItemDisplayStyle.Image;
         tbSwapHandles.Enabled = false;
         tbSwapHandles.Click += new EventHandler(tbSwapHandles_Click);
      }

      //==============================================================================================================
      // Properties
      //==============================================================================================================
      internal bool ShowLineLength {
         get { return showlinelength; }
         set{
            if (showlinelength != value) {
               showlinelength = value;
               General.Settings.WritePluginSetting("showlinelength", value);
               Update();
            }
         }
      }

      internal bool ShowLineTotal {
         get { return showlinetotal; }
         set{
            if (showlinetotal != value) {
               showlinetotal = value;
               General.Settings.WritePluginSetting("showlinetotal", value);
               Update();
            }
         }
      }

      internal bool ShowSideCount {
         get { return showsidecount; }
         set{
            if (showsidecount != value) {
               showsidecount = value;
               General.Settings.WritePluginSetting("showsidecount", value);
               Update();
            }
         }
      }

      internal bool NeverSnapCircle {
         get { return neversnapcircle; }
         set{
            if (neversnapcircle != value) {
               neversnapcircle = value;
               General.Settings.WritePluginSetting("neversnapcircle", value);
               Update();
            }
         }
      }

      internal int CircleSides {
         get { return editSides; }
         set {
            if (editSides != value) {
               editSides = value;
               if (editSides < 3)
                  editSides = 3;
               General.Settings.WritePluginSetting("editsides", editSides);
               Update();
            }
         }
      }

      //==============================================================================================================
      // Methods
      //==============================================================================================================
      [BeginAction("swapcirclehandles")]
      public void SwapHandles() {
         if (handleInner != null) {
            ControlHandle temp = handleInner;
            handleInner = handleOuter;
            handleOuter = temp;
            UpdateAll();
         }
      }

      [BeginAction("rotateorigincw")]
      public void RotateOriginCW() {
         RotateNodes(-1);
      }

      [BeginAction("rotateoriginccw")]
      public void RotateOriginCCW() {
         RotateNodes(1);
      }

      [BeginAction("addcirclesides")]
      public void IncreaseSides() {
         CircleSides++;
      }

      [BeginAction("subcirclesides")]
      public void DecreaseSides() {
         CircleSides--;
      }

      //==============================================================================================================
      // Inner
      //==============================================================================================================
      //Moves the guide to match the specified angle
      internal void SetAngle(float angle) {
         SetAngle(angle, false);
      }
      internal void SetAngle(float angle, bool nosnap) {
         if (handleInner == null)
            return;

         float length = (handleOuter.Position - handleInner.Position).GetLength();
         float rads = (float)(angle * (Math.PI / 180)); //rotate 90 degrees to match what line label is defining as angle 0
         Vector2D position = new Vector2D(
            handleInner.Position.x + (float)(Math.Cos(rads) * length),
            handleInner.Position.y + (float)(Math.Sin(rads) * length)
         );
         handleOuter.Position = snapguidetogrid && !nosnap ? General.Map.Grid.SnappedToGrid(position) : position;

         UpdateLengthBox();
         Update();
      }

      //sets the guide to the specific length
      internal void SetLength(float length) {
         SetLength(length, false);
      }
      internal void SetLength(float length, bool nosnap) {
         if (handleInner == null)
            return;

         float rads = (float)Math.Atan2(-(handleInner.Position.y - handleOuter.Position.y), -(handleInner.Position.x - handleOuter.Position.x));
         Vector2D position = new Vector2D(
            handleInner.Position.x + (float)(Math.Cos(rads) * length),
            handleInner.Position.y + (float)(Math.Sin(rads) * length)
         );
         handleOuter.Position = snapguidetogrid && !nosnap ? General.Map.Grid.SnappedToGrid(position) : position;

         UpdateAngleBox();
         Update();
      }

      //Moves the guide the specified number of vertexes along the path
      internal void RotateNodes(int nodes) {
         RotateNodes(nodes, false);
      }
      internal void RotateNodes(int nodes, bool nosnap) {
         if (handleInner == null)
            return;

         float length = (handleOuter.Position - handleInner.Position).GetLength();
         float originRads = (float)Math.Atan2(handleInner.Position.y - handleOuter.Position.y, handleInner.Position.x - handleOuter.Position.x);
         float pointRads = (float)((Math.PI / (double)editSides) * 2);
         Vector2D position = new Vector2D(
            handleInner.Position.x - (float)(Math.Cos(originRads + (pointRads * (float)nodes)) * length),
            handleInner.Position.y - (float)(Math.Sin(originRads + (pointRads * (float)nodes)) * length)
         );
         handleOuter.Position = snapguidetogrid & !nosnap ? General.Map.Grid.SnappedToGrid(position) : position;

         UpdateAll();
      }

      //resizes the circle to match the desired linedef length for the current number of sides
      internal void SetSidedefLength(float newlength) {
         if (handleInner == null || editSides < 3)
            return;

         Debug.WriteLine("sides: " + editSides + " len: " + newlength);
         double aoe = (360 / editSides) / 2;
         double rads = aoe * (Math.PI / 180);
         float length = (float)((newlength / 2) / Math.Sin(rads)); //assume a right angle (sin(90) = 1)
         SetLength(length, true);
         UpdateLengthBox();
      }

      private void UpdateAll() {
         if (handleInner != null && handleInner.Position.x != float.NaN) {
            UpdateAngleBox();
            UpdateLengthBox();
         }
         Update();
      }

      private void UpdateAngleBox() {
         //Update the angle box with the latest number
         float originRads = (float)Math.Atan2(-(handleInner.Position.y - handleOuter.Position.y), -(handleInner.Position.x - handleOuter.Position.x));
         if (originRads < 0)
            originRads += (float)(Math.PI * 2);

         panel.SetAngleBox((decimal)(originRads * (180 / Math.PI)));
         //tbAngleBox.Push((decimal)(originRads * (180 / Math.PI)));
      }

      private void UpdateLengthBox() {
         panel.SetLengthBox((decimal)(handleInner.Position - handleOuter.Position).GetLength());
         //tbLengthBox.Push((decimal)(handleInner.Position - handleOuter.Position).GetLength());
      }

      //Flushes and rebuilds the circle vertex cache
      private void Update() {
         editCircle.Clear();

         if (handleInner != null && handleOuter != null) {
            //handle special snapping overrides
            snapcircletogrid = !neversnapcircle && (General.Interface.ShiftState ^ General.Interface.SnapToGrid) ^ General.Interface.CtrlState; //if shift is held then flip the snap state for both guide and circle
            snapguidetogrid = General.Interface.ShiftState ^ General.Interface.SnapToGrid;                                  //if control is held then only flip the circle

            //calculate the spacing
            Vector2D delta = handleOuter.Position - handleInner.Position;
            float length = delta.GetLength();
            float originRads = (float)Math.Atan2(handleInner.Position.y - handleOuter.Position.y, handleInner.Position.x - handleOuter.Position.x);
            float pointRads = (float)((Math.PI / (double)editSides) * 2);

            //build the circle
            for(int i = 0; i < editSides; i++) {
               float rads = originRads + (pointRads * (float)i);
               DrawnVertex point = new DrawnVertex();
               point.stitch = true;
               point.stitchline = true;
               point.pos.y = handleInner.Position.y - (float)(Math.Sin(rads) * length);
               point.pos.x = handleInner.Position.x - (float)(Math.Cos(rads) * length);
               if(snapcircletogrid)
                  point.pos = General.Map.Grid.SnappedToGrid(point.pos);
               editCircle.Add(point);
            }
         }

         Render();
      }
            
      //Renders the guide and preview circle
      private void Render() {
         if(renderer.StartOverlay(true)) {
            //Render Guide
            if (handleInner != null) {
               //guide line
               renderer.RenderLine(handleInner.Position, handleOuter.Position, LINE_THICKNESS, snapguidetogrid ? pcLineSnap : pcLineFree, true);
               float gripsize = GRIP_SIZE / renderer.Scale;

               //size text
               labelGuideLength.Start = handleInner.Position;
               labelGuideLength.End = handleOuter.Position;
               renderer.RenderText(labelGuideLength.TextLabel);

               //control handles
               RectangleF handleRect = new RectangleF(handleInner.Position.x - gripsize * 0.5f, handleInner.Position.y - gripsize * 0.5f, gripsize, gripsize);
               renderer.RenderRectangleFilled(handleRect, pcHandleFill, true);
               renderer.RenderRectangle(handleRect, 2, snapguidetogrid ? pcLineSnap : pcLineFree, true);

               handleRect = new RectangleF(handleOuter.Position.x - gripsize * 0.5f, handleOuter.Position.y - gripsize * 0.5f, gripsize, gripsize);
               renderer.RenderRectangleFilled(handleRect, pcHandleFill, true);
               renderer.RenderRectangle(handleRect, 2, snapguidetogrid ? pcLineSnap : pcLineFree, true);
            }

            //render preview circle
            if(editCircle.Count > 2) {
               //linedefs
               float length = 0,
                     totalLength = 0,
                     vsize = ((float)renderer.VertexSize + 1.0f) / renderer.Scale;
               Vector2D delta;
               int side = editCircle.Count - 1;
               DrawnVertex lastp = editCircle[0];

               do {
                  //render the line
                  renderer.RenderLine(lastp.pos, editCircle[side].pos, LINE_THICKNESS, snapcircletogrid ? pcLineSnap : pcLineFree, true);
                  RenderPoint(lastp, vsize, snapcircletogrid ? pcLineFree : pcLineSnap);

                  //measure the line
                  delta = editCircle[side].pos - lastp.pos;
                  length = delta.GetLength();
                  totalLength += length;

                  //display the length of the current linedef
                  if (showlinelength) {
                     labelSizeLength.Text = Math.Round(length).ToString();
                     labelSizeLength.Rectangle = new RectangleF(lastp.pos.x + delta.x * 0.5f, lastp.pos.y + delta.y * 0.5f, 0f, 0f);
                     renderer.RenderText(labelSizeLength);
                  }

                  //store the end point as the start point for the next line
                  lastp = editCircle[side];
               } while (side-- > 0);

               //display how many linedefs are in the circle
               if (showsidecount) {
                  labelSideCount.Text = editCircle.Count.ToString();
                  labelSideCount.Rectangle = new RectangleF(handleInner.Position.x, handleInner.Position.y - ((GRIP_SIZE + 4) / renderer.Scale), 0f, 0f);
                  renderer.RenderText(labelSideCount);
               }

               //display how many units all lines occupy
               if (showlinetotal) {
                  labelSideCount.Text = Math.Round(totalLength).ToString();
                  labelSideCount.Rectangle = new RectangleF(handleInner.Position.x, handleInner.Position.y + ((GRIP_SIZE + 4) / renderer.Scale), 0f, 0f);
                  renderer.RenderText(labelSideCount);
               }
            }
            renderer.Finish();
         }
         renderer.Present();
      }

      //helper function to visualize a line's vertexes in preview mode
      private void RenderPoint(DrawnVertex p, float size, PixelColor color) {
         renderer.RenderRectangleFilled(new RectangleF(p.pos.x - size, p.pos.y - size, size * 2.0f, size * 2.0f), color, true);
      }

      //pulls the named resource from within the binary
      private Image GetResourceImage(string name) {
         Assembly a = Assembly.GetExecutingAssembly();
         System.IO.Stream s = a.GetManifestResourceStream(name);
         if(s != null)
            return Image.FromStream(s);
         return null;
      }

      //retrieves the current mouse position on the grid, snapped as necessary
      private Vector2D GetCurrentPosition() {
         Vector2D vm = mousemappos;
			float vrange = 20f / renderer.Scale;

         // Try the nearest vertex
			Vertex nv = General.Map.Map.NearestVertexSquareRange(vm, vrange);
			if(nv != null)
            return nv.Position;

			// Try the nearest linedef
			Linedef nl = General.Map.Map.NearestLinedefRange(vm, vrange);
			if(nl != null) {            
            // Snap to grid?
            if(snapguidetogrid) {
               // Get grid intersection coordinates
               List<Vector2D> coords = nl.GetGridIntersections();

               // Find nearest grid intersection
               bool found = false;
               float found_distance = float.MaxValue;
               Vector2D found_coord = new Vector2D();
               foreach(Vector2D v in coords) {
                  Vector2D delta = vm - v;
                  if(delta.GetLengthSq() < found_distance) {
                     found_distance = delta.GetLengthSq();
                     found_coord = v;
                     found = true;
                  }               
               }

               if(found)
                  return found_coord;
            } else {
               return nl.NearestOnLine(vm);
				}
			}

         //Just get the current mouse location instead
         if(snapguidetogrid)
            return General.Map.Grid.SnappedToGrid(vm);
         return vm;
      }

      //==============================================================================================================
      // Events
      //==============================================================================================================
      public override void OnEngage() {
         base.OnEngage();

         // Add docker
         panel = new OptionsPanel(this);
			docker = new Docker("drawcircle", "Draw Circle", panel);
			General.Interface.AddDocker(docker);
			General.Interface.SelectDocker(docker);
         
         //add the toolbar buttons to the main interface
         General.Interface.AddButton(tbRemoveSide);
         General.Interface.AddButton(tbAddSide);
         General.Interface.AddButton(tbRotateOriginCW);
         General.Interface.AddButton(tbRotateOriginCCW);        
         General.Interface.AddButton(tbSwapHandles);
         
         tbRemoveSide.Enabled = false;
         tbAddSide.Enabled = false;
         tbRotateOriginCW.Enabled = false;
         tbRotateOriginCCW.Enabled = false;
         tbSwapHandles.Enabled = false;
         panel.EditState = false;

         renderer.SetPresentation(Presentation.Standard);
      }

      public override void OnDisengage() {
         //clean up the toolbar buttons
         General.Interface.RemoveButton(tbRemoveSide);
         General.Interface.RemoveButton(tbAddSide);
         General.Interface.RemoveButton(tbRotateOriginCW);
         General.Interface.RemoveButton(tbRotateOriginCCW);
         General.Interface.RemoveButton(tbSwapHandles);

			// Remove docker
			General.Interface.RemoveDocker(docker);
			panel.Dispose();
			panel = null;

         base.OnDisengage();
      }

      protected override void OnEditBegin() {
         base.OnEditBegin();

         isCreating = true;

         snapcircletogrid = !neversnapcircle && (General.Interface.ShiftState ^ General.Interface.SnapToGrid) ^ General.Interface.CtrlState; //if shift is held then flip the snap state for both guide and circle
         snapguidetogrid = General.Interface.ShiftState ^ General.Interface.SnapToGrid;                                  //if control is held then only flip the circle

         tbAddSide.Enabled = false;
         tbRemoveSide.Enabled = false;
         tbRotateOriginCW.Enabled = false;
         tbRotateOriginCCW.Enabled = false;
         tbSwapHandles.Enabled = false;
         panel.EditState = false;

         //initialize the guide line
         handleInner = new ControlHandle();
         handleOuter = new ControlHandle();
         handleInner.Position = handleOuter.Position = GetCurrentPosition();

         Update();
      }

      protected override void OnEditEnd() {
         base.OnEditEnd();

          //if the opening edit was cancelled before letting go of the mouse then do no further processing
         if (!isCreating)
            return;
         isCreating = false;

         handleOuter.Position = GetCurrentPosition();
         if ((handleOuter.Position - handleInner.Position).GetLength() == 0) {
            handleInner = null;
            handleOuter = null;
            return;
         }

         tbAddSide.Enabled = true;
         tbRemoveSide.Enabled = true;
         tbRotateOriginCW.Enabled = true;
         tbRotateOriginCCW.Enabled = true;
         tbSwapHandles.Enabled = true;
         panel.EditState = true;

         UpdateAll();
      }

      public override void OnRedrawDisplay() {
         renderer.RedrawSurface();
         if(renderer.StartPlotter(true)) {
            renderer.PlotLinedefSet(General.Map.Map.Linedefs);
            renderer.PlotVerticesSet(General.Map.Map.Vertices);
            renderer.Finish();
         }
         if(renderer.StartThings(true)) {
            renderer.RenderThingSet(General.Map.Map.Things, 1.0f);
            renderer.Finish();
         }
         Update();
      }

      protected override void OnDragStart(MouseEventArgs e) {
         base.OnDragStart(e);
         if (handleInner != null) {
            float gripsize = GRIP_SIZE / renderer.Scale;
            if (handleOuter.isHovered(mousemappos, gripsize)) {
               handleCurrent = handleOuter;
               General.Interface.SetCursor(Cursors.Cross);
               return;
            }
            if (handleInner.isHovered(mousemappos, gripsize)) {
               handleCurrent = handleInner;
               General.Interface.SetCursor(Cursors.Cross);
               return;
            }
         }

         handleCurrent = null;
      }

      protected override void OnDragStop(MouseEventArgs e) {
         base.OnDragStop(e);
         General.Interface.SetCursor(Cursors.Default);
         handleCurrent = null;
      }

      public override void OnMouseMove(MouseEventArgs e) {
         base.OnMouseMove(e);

         if (handleCurrent != null) {
            handleCurrent.Position = GetCurrentPosition();
            UpdateAll();
         } else if (isCreating) {
            handleOuter.Position = GetCurrentPosition();
            UpdateAll();
         }
      }

      public override void OnKeyUp(KeyEventArgs e) {
         base.OnKeyUp(e);
         Update();
      }

      public override void OnKeyDown(KeyEventArgs e) {
         base.OnKeyDown(e);
         Update();
         if (handleInner != null && e.KeyCode == Keys.Enter)
            OnAccept();
      }

      public override void OnCancel() {
         base.OnCancel();

         tbAddSide.Enabled = false;
         tbRemoveSide.Enabled = false;
         tbRotateOriginCW.Enabled = false;
         tbRotateOriginCCW.Enabled = false;
         tbSwapHandles.Enabled = false;
         panel.EditState = false;

         isCreating = false;
         handleInner = null;
         handleOuter = null;
         editCircle.Clear();

         panel.SetAngleBox(0);
         panel.SetLengthBox(0);

         Render();
      }

      public override void OnAccept() {
         Cursor.Current = Cursors.AppStarting;
         General.Settings.FindDefaultDrawSettings();

         // When points have been drawn
         if(editCircle.Count > 0) {
            editCircle.Add(editCircle[0]); //close it

            // Make undo for the draw
            General.Map.UndoRedo.CreateUndo(textUndoEntry);

            General.Interface.DisplayStatus(StatusType.Action, textStatusCreated);

            // Make the drawing
            Tools.DrawLines(editCircle);

            // Snap to map format accuracy
            General.Map.Map.SnapAllToAccuracy();

            // Clear selection
            General.Map.Map.ClearAllSelected();

            // Update cached values
            General.Map.Map.Update();

            // Update the used textures
            General.Map.Data.UpdateUsedTextures();

            // Map is changed
            General.Map.IsChanged = true;
         }

         // Done
         Cursor.Current = Cursors.Default;

         tbAddSide.Enabled = false;
         tbRemoveSide.Enabled = false;
         tbRotateOriginCW.Enabled = false;
         tbRotateOriginCCW.Enabled = false;
         tbSwapHandles.Enabled = false;
         panel.EditState = false;

         isCreating = false;
         handleInner = null;
         handleOuter = null;
         editCircle.Clear();

         panel.SetAngleBox(0);
         panel.SetLengthBox(0);

         OnRedrawDisplay();
      }

      //==============================================================================================================
      // Toolbar Handlers
      //==============================================================================================================
      private void tbRotateOriginCCW_Click(object sender, EventArgs e) {
         RotateOriginCCW();
      }
      private void tbRotateOriginCW_Click(object sender, EventArgs e) {
         RotateOriginCW();
      }
      private void tbRemoveSide_Click(object sender, EventArgs e) {
         DecreaseSides();
      }
      private void tbAddSide_Click(object sender, EventArgs e) {
         IncreaseSides();
      }
      private void tbSwapHandles_Click(object sender, EventArgs e) {
         SwapHandles();
      }
   }


   //============================================================================================================
   // Helper classes
   //============================================================================================================
   //holder class for the guide drag handles
   internal class ControlHandle {
      public Vector2D Position;

      public ControlHandle() {}
      public ControlHandle(Vector2D position) {
         this.Position = position;
      }
      public bool isHovered(Vector2D position, float size) {
         return position.x <= this.Position.x + size && position.x >= this.Position.x - size && position.y <= this.Position.y + size && position.y >= this.Position.y - size;
      }
   }

   //straight rip from buildermodes, with minor fix to the angle display
	internal class LineLengthLabel : IDisposable {
		#region ================== Constants

		private const int TEXT_CAPACITY = 15;
		private const float TEXT_SCALE = 14f;
		private const string VALUE_FORMAT = "0";

		#endregion

		#region ================== Variables

		protected TextLabel label;
        protected Vector2D start;
        protected Vector2D end;
		private bool showAngle; //mxd
		
		#endregion

		#region ================== Properties

		public TextLabel TextLabel { get { return label; } }
		public Vector2D Start { get { return start; } set { start = value; Update(); } }
		public Vector2D End { get { return end; } set { end = value; Update(); } }

		#endregion

		#region ================== Constructor / Disposer

		// Constructor
		public LineLengthLabel(bool showAngle)
		{
			this.showAngle = showAngle; //mxd
			// Initialize
			Initialize();
		}

		// Constructor
		public LineLengthLabel(Vector2D start, Vector2D end)
		{
			// Initialize
			Initialize();
			Move(start, end);
		}

		// Initialization
		protected virtual void Initialize()
		{
			label = new TextLabel(TEXT_CAPACITY);
			label.AlignX = TextAlignmentX.Center;
			label.AlignY = TextAlignmentY.Middle;
			label.Color = General.Colors.Highlight;
			label.Backcolor = General.Colors.Background;
			label.Scale = TEXT_SCALE;
			label.TransformCoords = true;
		}
		
		// Disposer
		public void Dispose()
		{
			label.Dispose();
		}

		#endregion
		
		#region ================== Methods

		// This updates the text
        protected virtual void Update()
		{
			Vector2D delta = end - start;
			float length = delta.GetLength();

			//mxd
			if(showAngle) {
            float rads = (float)Math.Atan2(-(start.y - end.y), -(start.x - end.x));
            if (rads < 0)
               rads += (float)(Math.PI * 2);
				int angle = (int)Math.Round(rads * 180 / Math.PI);

				label.Text = "l:" + length.ToString(VALUE_FORMAT) + "; a:" + angle;
			} else {
				label.Text = length.ToString(VALUE_FORMAT);
			}

			label.Rectangle = new RectangleF(start.x + delta.x * 0.5f, start.y + delta.y * 0.5f, 0f, 0f);
		}

		// This moves the label
		public void Move(Vector2D start, Vector2D end)
		{
			this.start = start;
			this.end = end;
			Update();
		}
		
		#endregion
	}
}
