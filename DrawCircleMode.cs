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
    internal delegate void ModeChangedEvent(DrawCircleMode mode);

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

        private ControlHandle handleInner;
        private ControlHandle handleOuter;
        private ControlHandle handleCurrent;
        private LineLengthLabel labelGuideLength;
        private TextLabel labelSideCount;
        private TextLabel labelSizeLength;

        private PixelColor pcHandle;
        private PixelColor pcLineSnap = General.Colors.Selection;
        private PixelColor pcLineFree = General.Colors.Highlight;
        private PixelColor pcHandleFill = General.Colors.Background;

        private const float GRIP_SIZE = 9.0f;
        private const float LINE_THICKNESS = 0.8f;
        private const float TEXT_SCALE = 14f;

        private bool snapcircletogrid;
        private bool snapguidetogrid;
        private bool neversnapcircle;

        private bool fillcenter;

        private bool showlinelength;
        private bool showlinetotal;
        private bool showsidecount;

        private bool drawcircle;
        private bool drawoffset;
        private bool drawspokes;
        private bool drawantespokes;

        private bool alwayscreateonedit;

        private bool isCreating; //force fire updates on mouse move if creating the guide

        private List<List<DrawnVertex>> shapes;

        private int editSides;
        private float circleThickness = 0f;
        float spokethickness = 0f;
        float spokestartcustom = -1f;
        float antespokethickness = 16f;
        float antespokestartcustom = -1f;

        private ToolStripItem tbAddSide;
        private ToolStripItem tbRemoveSide;
        private ToolStripItem tbRotateOriginCW;
        private ToolStripItem tbRotateOriginCCW;
        private ToolStripItem tbSwapHandles;

        private float circleSegmentLength = 0f;

        internal event ModeChangedEvent ModeChanged;

        private const double rightrads = 1.5707963267948966;

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
            
            alwayscreateonedit = General.Settings.ReadPluginSetting("alwayscreateonedit", false);
            showlinelength = General.Settings.ReadPluginSetting("showlinelength", true);
            showlinetotal = General.Settings.ReadPluginSetting("showlinetotal", true);
            showsidecount = General.Settings.ReadPluginSetting("showsidecount", true);
            neversnapcircle = General.Settings.ReadPluginSetting("neversnapcircle", true);
            circleThickness = General.Settings.ReadPluginSetting("circlethickness", 0f);
            fillcenter = General.Settings.ReadPluginSetting("fillcenter", true);
            drawcircle = General.Settings.ReadPluginSetting("drawcircle", true);
            drawoffset = General.Settings.ReadPluginSetting("drawoffset", false);

            drawspokes = General.Settings.ReadPluginSetting("drawspokes", false);
            spokethickness = General.Settings.ReadPluginSetting("spokethickness", 0f);
            spokestartcustom = General.Settings.ReadPluginSetting("spokeminimum", -1f);

            drawantespokes = General.Settings.ReadPluginSetting("drawantespokes", false);
            antespokethickness = General.Settings.ReadPluginSetting("antespokethickness", 0f);
            antespokestartcustom = General.Settings.ReadPluginSetting("antespokeminimum", -1f);

            shapes = new List<List<DrawnVertex>>();

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
        internal bool AlwaysCreateOnEdit {
            get { return alwayscreateonedit; }
            set {
                if (alwayscreateonedit != value) {
                    alwayscreateonedit = value;
                    General.Settings.WritePluginSetting("alwayscreateonedit", value);
                    Update();
                }
            }
        }

        internal bool ShowLineLength {
            get { return showlinelength; }
            set {
                if (showlinelength != value) {
                    showlinelength = value;
                    General.Settings.WritePluginSetting("showlinelength", value);
                    Update();
                }
            }
        }

        internal bool ShowLineTotal {
            get { return showlinetotal; }
            set {
                if (showlinetotal != value) {
                    showlinetotal = value;
                    General.Settings.WritePluginSetting("showlinetotal", value);
                    Update();
                }
            }
        }

        internal bool ShowSideCount {
            get { return showsidecount; }
            set {
                if (showsidecount != value) {
                    showsidecount = value;
                    General.Settings.WritePluginSetting("showsidecount", value);
                    Update();
                }
            }
        }

        internal bool NeverSnapCircle {
            get { return neversnapcircle; }
            set {
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
                    if (editSides < 1)
                        editSides = 1;
                    General.Settings.WritePluginSetting("editsides", editSides);
                    if (ModeChanged != null)
                        ModeChanged(this);
                    Update();
                }
            }
        }

        internal float CircleThickness {
            get { return circleThickness; }
            set {
                if (circleThickness != value) {
                    circleThickness = value;
                    General.Settings.WritePluginSetting("circlethickness", circleThickness);
                    Update();
                }
            }
        }


        internal bool FillCenter {
            get { return fillcenter; }
            set {
                if (fillcenter != value) {
                    fillcenter = value;
                    General.Settings.WritePluginSetting("fillcenter", fillcenter);
                    Update();
                }
            }
        }

        internal bool DrawCircle {
            get { return drawcircle; }
            set {
                if (drawcircle != value) {
                    drawcircle = value;
                    General.Settings.WritePluginSetting("drawcircle", drawcircle);
                    Update();
                }
            }
        }

        internal bool DrawOffset {
            get { return drawoffset; }
            set {
                if (drawoffset != value) {
                    drawoffset = value;
                    General.Settings.WritePluginSetting("drawoffset", drawoffset);
                    Update();
                }
            }
        }

        internal bool DrawSpokes {
            get { return drawspokes; }
            set {
                if (drawspokes != value) {
                    drawspokes = value;
                    General.Settings.WritePluginSetting("drawspokes", drawspokes);
                    Update();
                }
            }
        }

        internal float SpokeMinimum {
            get { return spokestartcustom; }
            set {
                if (spokestartcustom != value) {
                    spokestartcustom = value;
                    General.Settings.WritePluginSetting("spokeminimum", spokestartcustom);
                    Update();
                }
            }
        }

        internal float SpokeThickness {
            get { return spokethickness; }
            set {
                if (spokethickness != value) {
                    spokethickness = value;
                    General.Settings.WritePluginSetting("spokethickness", spokethickness);
                    Update();
                }
            }
        }


        internal bool DrawAnteSpokes {
            get { return drawantespokes; }
            set {
                if (drawantespokes != value) {
                    drawantespokes = value;
                    General.Settings.WritePluginSetting("drawantespokes", drawantespokes);
                    Update();
                }
            }
        }

        internal float AnteSpokeMinimum {
            get { return antespokestartcustom; }
            set {
                if (antespokestartcustom != value) {
                    antespokestartcustom = value;
                    General.Settings.WritePluginSetting("antespokeminimum", antespokestartcustom);
                    Update();
                }
            }
        }

        internal float AnteSpokeThickness {
            get { return antespokethickness; }
            set {
                if (antespokethickness != value) {
                    antespokethickness = value;
                    General.Settings.WritePluginSetting("antespokethickness", antespokethickness);
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
            if (handleInner != null && handleOuter != null)
                CircleSides++;
        }

        [BeginAction("subcirclesides")]
        public void DecreaseSides() {
            if (handleInner != null && handleOuter != null)
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
            double rads = angle * (Math.PI / 180);
            Vector2D position = new Vector2D(
                handleInner.Position.x + (float)(Math.Cos(rads) * length),
                handleInner.Position.y + (float)(Math.Sin(rads) * length)
            );

            if (snapguidetogrid && !nosnap) { 
                handleOuter.Position = General.Map.Grid.SnappedToGrid(position);
                UpdateLengthBox();
            } else {
                handleOuter.Position = position;
            }

            Update();
        }

        //sets the guide to the specific length
        internal void SetLength(float length) {
            SetLength(length, false);
        }
        internal void SetLength(float length, bool nosnap) {
            if (handleInner == null)
                return;

            Vector2D O = handleOuter.Position - handleInner.Position;
            double angle = Math.Atan2(O.y, O.x);
            Vector2D position = new Vector2D(
                handleInner.Position.x + (float)(Math.Cos(angle) * length),
                handleInner.Position.y + (float)(Math.Sin(angle) * length)
            );

            if (snapguidetogrid && !nosnap) {
                handleOuter.Position = General.Map.Grid.SnappedToGrid(position);
                UpdateAngleBox();
            } else {
                handleOuter.Position = position;
            }
            Update();
        }

        //Moves the guide the specified number of vertexes along the path
        internal void RotateNodes(int nodes) {
            if (handleInner == null)
                return;

            Vector2D O = handleOuter.Position - handleInner.Position;
            double length = O.GetLength();
            double originRads = Math.Atan2(O.y, O.x);
            double pointRads = (Math.PI / (double)editSides) * 2.0;
            Vector2D position = new Vector2D(
                handleInner.Position.x + (float)(Math.Cos(originRads + pointRads * nodes) * length),
                handleInner.Position.y + (float)(Math.Sin(originRads + pointRads * nodes) * length)
            );
            handleOuter.Position = position;

            UpdateAll();
        }

        //resizes the circle to match the desired linedef length for the current number of sides
        internal void SetSidedefLength(float newlength) {
            if (handleInner == null || editSides < 3)
                return;

            double aoe = (360 / (float)editSides) / 2;
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
            Vector2D o = handleOuter.Position - handleInner.Position;
            double originRads = Math.Atan2(o.y, o.x);
            if (originRads < 0)
                originRads += (Math.PI * 2.0);

            //Precision is reduced on purpose here so that a slight rounding effect occurs during the degree conversion
            panel.SetAngleBox((float)((float)originRads * (180.0 / Math.PI)));
        }

        private void UpdateLengthBox() {
            panel.SetLengthBox((handleInner.Position - handleOuter.Position).GetLength());
        }

        //Flushes and rebuilds the circle vertex cache
        private void Update() {
            List<DrawnVertex> shape;

            shapes.Clear();

            //handle special snapping overrides
            snapcircletogrid = !neversnapcircle && (General.Interface.ShiftState ^ General.Interface.SnapToGrid) ^ General.Interface.CtrlState; //if shift is held then flip the snap state for both guide and circle
            snapguidetogrid = General.Interface.ShiftState ^ General.Interface.SnapToGrid;                                  //if control is held then only flip the circle

            //only create geometry if both control handles have been set
            if (handleInner != null && handleOuter != null) {
                //Create the MAIN circle.
                shape = new List<DrawnVertex>();

                //Calculate the angle and circle starting point
                Vector2D delta = handleOuter.Position - handleInner.Position;
                float length = delta.GetLength();
                float originRads = (float)Math.Atan2(handleInner.Position.y - handleOuter.Position.y, handleInner.Position.x - handleOuter.Position.x);
                float pointRads = (float)((Math.PI / (double)editSides) * 2);
                float segcenterRads = pointRads / 2f;

                //If the drawing is to be offset, then calculate new start and length
                if (drawoffset) {
                    //rotate origin by one-half segment
                    originRads -= segcenterRads;

                    //calculate the new circle length so that the segment lands firmly on the control handle                    
                    double segangle = Math.PI - rightrads - segcenterRads;
                    length = (float)Math.Abs(length / Math.Sin(segangle));
                }

                circleSegmentLength = 0f; //reset

                Vector2D last = new Vector2D();

                //---------------------------------------------------------------------------------
                // Build the MAIN circle
                //---------------------------------------------------------------------------------
                if (drawcircle) {
                    for (int i = 0; i < editSides; i++) {
                        //calculate where the vertex should go, based on the number of segments
                        float rads = originRads + (pointRads * (float)i);
                        DrawnVertex point = new DrawnVertex();
                        point.stitch = true;
                        point.stitchline = true;
                        point.pos.y = handleInner.Position.y - (float)(Math.Sin(rads) * length);
                        point.pos.x = handleInner.Position.x - (float)(Math.Cos(rads) * length);
                        if (snapcircletogrid)
                            point.pos = General.Map.Grid.SnappedToGrid(point.pos);
                        shape.Add(point);

                        //measure the segment for the total length display
                        if (i > 0) {
                            delta = point.pos - last;
                            circleSegmentLength += delta.GetLength();
                        }
                        last = point.pos;
                    }

                    //measure the last segment
                    delta = last - shape[0].pos;
                    circleSegmentLength += delta.GetLength();

                    shape.Add(shape[0]); //close it

                    //Build the OUTER circle (if configured)
                    if (circleThickness != 0f) {
                        List<DrawnVertex> outershape = new List<DrawnVertex>();

                        //calculate the spacing
                        float outerlength = length + circleThickness;

                        //create the points
                        for (int i = 0; i < editSides; i++) {
                            float rads = originRads + (pointRads * (float)i);
                            DrawnVertex point = new DrawnVertex();
                            point.stitch = true;
                            point.stitchline = true;
                            point.pos.y = handleInner.Position.y - (float)(Math.Sin(rads) * outerlength);
                            point.pos.x = handleInner.Position.x - (float)(Math.Cos(rads) * outerlength);
                            if (snapcircletogrid)
                                point.pos = General.Map.Grid.SnappedToGrid(point.pos);
                            outershape.Add(point);
                        }
                        outershape.Add(outershape[0]); //close it

                        if (fillcenter) {
                            //if we are filling, then both circles are two distintive shapes.
                            shapes.Add(shape);          //add inner circle
                            shapes.Add(outershape);     //add outer circle separately
                        } else {
                            //if not filling, then append the outer circle to the main one
                            shape.AddRange(outershape);
                            shapes.Add(shape);
                        }
                    } else {
                        shapes.Add(shape);
                    }
                }

                //---------------------------------------------------------------------------------
                // Build the SPOKES
                //---------------------------------------------------------------------------------
                if (drawspokes) {
                    float spokestart = spokestartcustom;
                    float spokehalf = spokethickness / 2f;

                    //if a custom start length is not set, then calculate the minimum safe distance
                    if (spokestart < 0) {
                        //calculate the distance from the center where the segments lifedefs join with each other
                        spokestart = (float)(spokehalf / Math.Sin(segcenterRads));

                        //calculate and subtract the chord's sagitta to tighten the segments
                        spokestart -= spokestart - (float)Math.Sqrt(Math.Pow(spokestart, 2) - Math.Pow(spokehalf, 2));
                    }


                    //create the spoke for each vertex
                    for (int i = 0; i < editSides; i++) {
                        shape = new List<DrawnVertex>();

                        //calculate current angle
                        float rads_center = originRads + (pointRads * (float)i);
                        Vector2D origin = new Vector2D(
                            handleInner.Position.x - (float)(Math.Cos(rads_center) * spokestart),
                            handleInner.Position.y - (float)(Math.Sin(rads_center) * spokestart)
                        );

                        if (spokehalf > 0) {
                            //if a thickness is set, then the spoke is a rectangle offset from the center
                            float rads_left = (float)(rads_center - (90 * (Math.PI / 180)));
                            float rads_right = (float)(rads_center + (90 * (Math.PI / 180)));

                            DrawnVertex bl = new DrawnVertex();
                            bl.stitch = true;
                            bl.stitchline = true;
                            bl.pos.y = origin.y - (float)(Math.Sin(rads_left) * spokehalf);
                            bl.pos.x = origin.x - (float)(Math.Cos(rads_left) * spokehalf);
                            if (snapcircletogrid)
                                bl.pos = General.Map.Grid.SnappedToGrid(bl.pos);
                            shape.Add(bl);

                            DrawnVertex br = new DrawnVertex();
                            br.stitch = true;
                            br.stitchline = true;
                            br.pos.y = origin.y - (float)(Math.Sin(rads_right) * spokehalf);
                            br.pos.x = origin.x - (float)(Math.Cos(rads_right) * spokehalf);
                            if (snapcircletogrid)
                                br.pos = General.Map.Grid.SnappedToGrid(br.pos);
                            shape.Add(br);

                            DrawnVertex tr = new DrawnVertex();
                            tr.stitch = true;
                            tr.stitchline = true;
                            tr.pos.y = br.pos.y - (float)(Math.Sin(rads_center) * (length - spokestart));
                            tr.pos.x = br.pos.x - (float)(Math.Cos(rads_center) * (length - spokestart));
                            if (snapcircletogrid)
                                tr.pos = General.Map.Grid.SnappedToGrid(tr.pos);
                            shape.Add(tr);

                            DrawnVertex tl = new DrawnVertex();
                            tl.stitch = true;
                            tl.stitchline = true;
                            tl.pos.y = tr.pos.y - (float)(Math.Sin(rads_left) * (spokehalf * 2));
                            tl.pos.x = tr.pos.x - (float)(Math.Cos(rads_left) * (spokehalf * 2));
                            if (snapcircletogrid)
                                tl.pos = General.Map.Grid.SnappedToGrid(tl.pos);
                            shape.Add(tl);
                        } else {
                            //If a thickness is not set, then just render a plain linedef, to reduce geometry merging artifacts
                            //  e.g. unmerged vertexes and unsplit linedefs. plus reduces peformance penalty a bit.
                            DrawnVertex p1 = new DrawnVertex();
                            p1.stitch = true;
                            p1.stitchline = true;
                            p1.pos.y = origin.y;
                            p1.pos.x = origin.x;
                            if (snapcircletogrid)
                                p1.pos = General.Map.Grid.SnappedToGrid(p1.pos);
                            shape.Add(p1);

                            DrawnVertex p2 = new DrawnVertex();
                            p2.stitch = true;
                            p2.stitchline = true;
                            p2.pos.y = origin.y - (float)(Math.Sin(rads_center) * (length - spokestart));
                            p2.pos.x = origin.x - (float)(Math.Cos(rads_center) * (length - spokestart));
                            if (snapcircletogrid)
                                p2.pos = General.Map.Grid.SnappedToGrid(p2.pos);
                            shape.Add(p2);
                        }

                        shape.Add(shape[0]); //close it
                        shapes.Add(shape);
                    }
                }

                //---------------------------------------------------------------------------------
                // Build the ANTE SPOKES (spokes that go to the center of the sidedef)
                //---------------------------------------------------------------------------------
                if (drawantespokes) {
                    float spokestart = antespokestartcustom;
                    float spokehalf = antespokethickness / 2f;

                    //if a custom start length is not set, then calculate the minimum safe distance
                    if (spokestart < 0) {
                        //calculate the distance from the center where the segments lifedefs join with each other
                        spokestart = (float)(spokehalf / Math.Sin(segcenterRads));

                        //calculate and subtract the chord's sagitta to tighten the segments
                        spokestart -= spokestart - (float)Math.Sqrt(Math.Pow(spokestart, 2) - Math.Pow(spokehalf, 2));
                    }

                    //calculate the TRUE segment length
                    Vector2D s1 = new Vector2D(
                        handleInner.Position.x - (float)(Math.Cos(originRads) * length),
                        handleInner.Position.y - (float)(Math.Sin(originRads) * length)
                    );
                    Vector2D s2 = new Vector2D(
                        handleInner.Position.x - (float)(Math.Cos(originRads + pointRads) * length),
                        handleInner.Position.y - (float)(Math.Sin(originRads + pointRads) * length)
                    );
                    float seglen = (s2 - s1).GetLength();

                    //calculate how far the spoke shoots past the linedef (sagitta), and rope it back in
                    float segsagitta = length - (float)Math.Sqrt(Math.Pow(length, 2) - Math.Pow(seglen / 2, 2));
                    float spokelen = length - segsagitta - spokestart;

                    //create the spoke for each vertex
                    for (int i = 0; i < editSides; i++) {
                        shape = new List<DrawnVertex>();

                        //calculate current angle
                        float rads_center = originRads - segcenterRads + (pointRads * (float)i);
                        Vector2D origin = new Vector2D(
                            handleInner.Position.x - (float)(Math.Cos(rads_center) * spokestart),
                            handleInner.Position.y - (float)(Math.Sin(rads_center) * spokestart)
                        );

                        if (spokehalf > 0) {
                            //if a thickness is set, then the spoke is a rectangle offset from the center
                            float rads_left = (float)(rads_center - (90 * (Math.PI / 180)));
                            float rads_right = (float)(rads_center + (90 * (Math.PI / 180)));

                            DrawnVertex bl = new DrawnVertex();
                            bl.stitch = true;
                            bl.stitchline = true;
                            bl.pos.y = origin.y - (float)(Math.Sin(rads_left) * spokehalf);
                            bl.pos.x = origin.x - (float)(Math.Cos(rads_left) * spokehalf);
                            if (snapcircletogrid)
                                bl.pos = General.Map.Grid.SnappedToGrid(bl.pos);
                            shape.Add(bl);

                            DrawnVertex br = new DrawnVertex();
                            br.stitch = true;
                            br.stitchline = true;
                            br.pos.y = origin.y - (float)(Math.Sin(rads_right) * spokehalf);
                            br.pos.x = origin.x - (float)(Math.Cos(rads_right) * spokehalf);
                            if (snapcircletogrid)
                                br.pos = General.Map.Grid.SnappedToGrid(br.pos);
                            shape.Add(br);

                            DrawnVertex tr = new DrawnVertex();
                            tr.stitch = true;
                            tr.stitchline = true;
                            tr.pos.y = br.pos.y - (float)(Math.Sin(rads_center) * spokelen);
                            tr.pos.x = br.pos.x - (float)(Math.Cos(rads_center) * spokelen);
                            if (snapcircletogrid)
                                tr.pos = General.Map.Grid.SnappedToGrid(tr.pos);
                            shape.Add(tr);

                            DrawnVertex tl = new DrawnVertex();
                            tl.stitch = true;
                            tl.stitchline = true;
                            tl.pos.y = tr.pos.y - (float)(Math.Sin(rads_left) * (spokehalf * 2));
                            tl.pos.x = tr.pos.x - (float)(Math.Cos(rads_left) * (spokehalf * 2));
                            if (snapcircletogrid)
                                tl.pos = General.Map.Grid.SnappedToGrid(tl.pos);
                            shape.Add(tl);
                        } else {
                            //If a thickness is not set, then just render a plain linedef, to reduce geometry merging artifacts
                            //  e.g. unmerged vertexes and unsplit linedefs. plus reduces peformance penalty a bit.
                            DrawnVertex p1 = new DrawnVertex();
                            p1.stitch = true;
                            p1.stitchline = true;
                            p1.pos.y = origin.y;
                            p1.pos.x = origin.x;
                            if (snapcircletogrid)
                                p1.pos = General.Map.Grid.SnappedToGrid(p1.pos);
                            shape.Add(p1);

                            DrawnVertex p2 = new DrawnVertex();
                            p2.stitch = true;
                            p2.stitchline = true;
                            p2.pos.y = origin.y - (float)(Math.Sin(rads_center) * spokelen);
                            p2.pos.x = origin.x - (float)(Math.Cos(rads_center) * spokelen);
                            if (snapcircletogrid)
                                p2.pos = General.Map.Grid.SnappedToGrid(p2.pos);
                            shape.Add(p2);
                        }

                        shape.Add(shape[0]); //close it
                        shapes.Add(shape);
                    }
                }
            }

            Render();
        }

        //Renders the guide and preview circle
        private void Render() {
            if (renderer.StartOverlay(true)) {
                //render preview
                if (shapes.Count > 0) {
                    //display all of the built shapes from the update phase
                    for (var i = 0; i < shapes.Count; i++) {
                        List<DrawnVertex> shape = shapes[i];

                        if (shape.Count > 1) {
                            //linedefs
                            float length = 0,
                                  vsize = ((float)renderer.VertexSize + 1.0f) / renderer.Scale;
                            Vector2D delta;
                            int side = shape.Count - 1;
                            DrawnVertex lastp = shape[0];

                            do {
                                //render the line
                                renderer.RenderLine(lastp.pos, shape[side].pos, LINE_THICKNESS, snapcircletogrid ? pcLineSnap : pcLineFree, true);
                                RenderPoint(lastp, vsize, snapcircletogrid ? pcLineFree : pcLineSnap);

                                //measure the line
                                delta = shape[side].pos - lastp.pos;
                                length = delta.GetLength();

                                //display the length of the current linedef
                                if (showlinelength && length > 0f) {
                                    labelSizeLength.Text = Math.Round(length).ToString();
                                    labelSizeLength.Rectangle = new RectangleF(lastp.pos.x + delta.x * 0.5f, lastp.pos.y + delta.y * 0.5f, 0f, 0f);
                                    renderer.RenderText(labelSizeLength);
                                }

                                //store the end point as the start point for the next line
                                lastp = shape[side];
                            } while (side-- > 0);
                        }
                    }

                    //display how many linedefs are in the circle
                    if (showsidecount) {
                        labelSideCount.Text = editSides.ToString();
                        labelSideCount.Rectangle = new RectangleF(handleInner.Position.x, handleInner.Position.y - ((GRIP_SIZE + 4) / renderer.Scale), 0f, 0f);
                        renderer.RenderText(labelSideCount);
                    }

                    //display how many units all lines occupy
                    if (showlinetotal) {
                        labelSideCount.Text = Math.Round(circleSegmentLength).ToString();
                        labelSideCount.Rectangle = new RectangleF(handleInner.Position.x, handleInner.Position.y + ((GRIP_SIZE + 4) / renderer.Scale), 0f, 0f);
                        renderer.RenderText(labelSideCount);
                    }
                }

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
            if (s != null)
                return Image.FromStream(s);
            return null;
        }

        //retrieves the current mouse position on the grid, snapped as necessary
        private Vector2D GetCurrentPosition() {
            Vector2D vm = MouseMapPos;
            float vrange = 20f / renderer.Scale;

            // Try the nearest vertex
            Vertex nv = General.Map.Map.NearestVertexSquareRange(vm, vrange);
            if (nv != null)
                return nv.Position;

            // Try the nearest linedef
            Linedef nl = General.Map.Map.NearestLinedefRange(vm, vrange);
            if (nl != null) {
                // Snap to grid?
                if (snapguidetogrid) {
                    // Get grid intersection coordinates
                    List<Vector2D> coords = nl.GetGridIntersections();

                    // Find nearest grid intersection
                    bool found = false;
                    float found_distance = float.MaxValue;
                    Vector2D found_coord = new Vector2D();
                    foreach (Vector2D v in coords) {
                        Vector2D delta = vm - v;
                        if (delta.GetLengthSq() < found_distance) {
                            found_distance = delta.GetLengthSq();
                            found_coord = v;
                            found = true;
                        }
                    }

                    if (found)
                        return found_coord;
                } else {
                    return nl.NearestOnLine(vm);
                }
            }

            //Just get the current mouse location instead
            if (snapguidetogrid)
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

            if (shapes.Count == 0 || alwayscreateonedit) {
                //this is a brand new circle, so setup the control handles and do initial shape creation and rendering
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
            } else if (handleInner != null) {
                //if we are already in preview mode, then only allow the control handles to be dragged
                float gripsize = GRIP_SIZE / renderer.Scale;
                if (handleOuter.isHovered(MouseMapPos, gripsize)) {
                    handleCurrent = handleOuter;
                    General.Interface.SetCursor(Cursors.Cross);
                    return;
                } else if (handleInner.isHovered(MouseMapPos, gripsize)) {
                    handleCurrent = handleInner;
                    General.Interface.SetCursor(Cursors.Cross);
                    return;
                }
            }
        }

        protected override void OnEditEnd() {
            base.OnEditEnd();

            if (isCreating) {
                //if the opening edit was cancelled before letting go of the mouse then do no further processing
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
            } else {
                //since we were just dragging an existing handle, just let go of it
                General.Interface.SetCursor(Cursors.Default);
                handleCurrent = null;
            }
        }

        public override void OnRedrawDisplay() {
            renderer.RedrawSurface();
            if (renderer.StartPlotter(true)) {
                renderer.PlotLinedefSet(General.Map.Map.Linedefs);
                renderer.PlotVerticesSet(General.Map.Map.Vertices);
                renderer.Finish();
            }
            if (renderer.StartThings(true)) {
                renderer.RenderThingSet(General.Map.Map.Things, 1.0f);
                renderer.Finish();
            }
            Update();
        }

        protected override void OnDragStart(MouseEventArgs e) {
            base.OnDragStart(e);

            //this differs from "EditStart", as this is a PRIMARY mouse click, rather than a SECONDARY one.
            if (handleInner != null) {
                float gripsize = GRIP_SIZE / renderer.Scale;
                if (handleOuter.isHovered(MouseDownMapPos, gripsize)) {
                    handleCurrent = handleOuter;
                    General.Interface.SetCursor(Cursors.Cross);
                    return;
                } else if (handleInner.isHovered(MouseDownMapPos, gripsize)) {
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

            float gripsize = GRIP_SIZE / renderer.Scale;
            if (handleCurrent != null) {
                handleCurrent.Position = GetCurrentPosition();
                UpdateAll();
            } else if (isCreating) {
                handleOuter.Position = GetCurrentPosition();
                UpdateAll();
            } else if (handleOuter != null && handleOuter.isHovered(MouseMapPos, gripsize)) {
                General.Interface.SetCursor(Cursors.Hand);
            } else if (handleInner != null && handleInner.isHovered(MouseMapPos, gripsize)) {
                General.Interface.SetCursor(Cursors.Hand);
            } else {
                General.Interface.SetCursor(Cursors.Default);
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
            shapes.Clear();

            panel.SetAngleBox(0);
            panel.SetLengthBox(0);

            Render();
        }


        public override void OnAccept() {
            Cursor.Current = Cursors.AppStarting;
            General.Settings.FindDefaultDrawSettings();

            // When points have been drawn
            if (shapes.Count > 0) {
                // Make undo for the draw
                General.Map.UndoRedo.CreateUndo(textUndoEntry);
                General.Interface.DisplayStatus(StatusType.Action, textStatusCreated);

                // Clear selection
                General.Map.Map.ClearAllSelected();

                for (var i = 0; i < shapes.Count; i++) {
                    List<DrawnVertex> shape = shapes[i];

                    //if the user holds down ALT while creating, assume they want a "guide" for positioning other map elements. A guide will not split linedefs.
                    if (!General.Interface.AutoMerge || General.Interface.AltState) {
                        int j = shape.Count;
                        DrawnVertex v;
                        while (j-- > 0) {
                            v = shape[j];
                            v.stitchline = false; //don't split any linedefs

                            //don't complete the circle if ALT mode, to prevent sector creation and background fill
                            if (General.Interface.AltState)
                                v.stitch = false;

                            shape[j] = v;
                        }
                    }


                    // Make the drawing
                    Tools.DrawLines(shape);
                    General.Map.Map.SelectMarkedLinedefs(true, true);
                }

                // Snap to map format accuracy
                General.Map.Map.SnapAllToAccuracy();

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
            shapes.Clear();

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

        public ControlHandle() { }
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
        public LineLengthLabel(bool showAngle) {
            this.showAngle = showAngle; //mxd
            // Initialize
            Initialize();
        }

        // Constructor
        public LineLengthLabel(Vector2D start, Vector2D end) {
            // Initialize
            Initialize();
            Move(start, end);
        }

        // Initialization
        protected virtual void Initialize() {
            label = new TextLabel(TEXT_CAPACITY);
            label.AlignX = TextAlignmentX.Center;
            label.AlignY = TextAlignmentY.Middle;
            label.Color = General.Colors.Highlight;
            label.Backcolor = General.Colors.Background;
            label.Scale = TEXT_SCALE;
            label.TransformCoords = true;
        }

        // Disposer
        public void Dispose() {
            label.Dispose();
        }

        #endregion

        #region ================== Methods

        // This updates the text
        protected virtual void Update() {
            Vector2D delta = end - start;
            float length = delta.GetLength();

            //mxd
            if (showAngle) {
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
        public void Move(Vector2D start, Vector2D end) {
            this.start = start;
            this.end = end;
            Update();
        }

        #endregion
    }
}
