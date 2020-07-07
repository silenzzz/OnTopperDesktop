using System.Diagnostics;
using static DmLib.Window.State;

namespace OnTopper.Stuff
{
    public class TopStateAction : Action
    {
        private readonly WINDOW_STATE state;

        public TopStateAction(Process p, WINDOW_STATE state)
        {
            this.proc = p;
            this.state = state;
            this.Reverted = false;
        }

        private TopStateAction(Process p, WINDOW_STATE state, bool reverted)
        {
            this.proc = p;
            this.state = state;
            this.Reverted = reverted;
        }

        private WINDOW_STATE Invert(WINDOW_STATE state)
        {
            return state == WINDOW_STATE.TOP ? WINDOW_STATE.UNTOP : WINDOW_STATE.TOP;
        }

        public override Action Revert()
        {
            SetWindowState(proc, Invert(this.state));
            return new TopStateAction(proc, Invert(this.state), !Reverted);
        }

        public override string ToString()
        {
            var s = string.Format("{0}: Set {1} to {2} state", time, proc.ProcessName, state.ToString());
            if (Reverted)
            {
                return s + " (reverted)";
            }
            return s;
        }
    }
}
