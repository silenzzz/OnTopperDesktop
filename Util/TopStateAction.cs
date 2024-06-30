using System.Diagnostics;
using static DmLib.Window.State;

namespace OnTopper.Util
{
    public class TopStateAction : Action
    {
        private readonly WINDOW_STATE currentState;

        public TopStateAction(Process p, WINDOW_STATE currentState)
        {
            this.Proc = p;
            this.currentState = currentState;
            this.Reverted = false;
        }

        private TopStateAction(Process p, WINDOW_STATE currentState, bool reverted)
        {
            this.Proc = p;
            this.currentState = currentState;
            this.Reverted = reverted;
        }

        private static WINDOW_STATE Invert(WINDOW_STATE state)
        {
            return state == WINDOW_STATE.TOP ? WINDOW_STATE.UNTOP : WINDOW_STATE.TOP;
        }

        public override Action Revert()
        {
            SetWindowState(Proc, Invert(this.currentState));
            return new TopStateAction(Proc, Invert(this.currentState), !Reverted);
        }

        public override string ToString()
        {
            var s = $"{Time}: Set {Proc.ProcessName} to {currentState.ToString()} state";
            return Reverted ? s + " (reverted)" : s;
        }
    }
}
