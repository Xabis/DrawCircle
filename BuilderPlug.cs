using System;
using CodeImp.DoomBuilder.Plugins;

namespace TriDelta.DrawCircleMode {
    public class BuilderPlug : Plug {
        private static BuilderPlug me;
        public static BuilderPlug Me { get { return me; } }

        public override string Name {
            get { return "Draw Circle"; }
        }

        public override void OnInitialize() {
            base.OnInitialize();
            me = this;
        }

        public override void Dispose() {
            base.Dispose();
        }
    }
}