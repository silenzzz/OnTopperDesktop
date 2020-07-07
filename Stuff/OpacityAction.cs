using System.Diagnostics;
using DmLib.Window;

namespace OnTopper.Stuff
{
    public class OpacityAction : Action
    {
        private readonly ushort previous;
        private readonly ushort current;

        public OpacityAction(ushort previous, ushort current, Process p)
        {
            this.proc = p;
            this.previous = previous;
            this.current = current;
            this.Reverted = false;
        }

        private OpacityAction(ushort previous, ushort current, Process p, bool reverted)
        {
            this.proc = p;
            this.previous = previous;
            this.current = current;
            this.Reverted = reverted;
        }

        public override Action Revert()
        {
            Transparency.SetWindowTransparency(proc, previous);
            return new OpacityAction(current, previous, proc, !Reverted);
        }

        public override string ToString()
        {
            string s = string.Format("{0}: Set opacity of {1} from {2} to {3}", time, proc.ProcessName, previous, current);
            if (Reverted)
            {
                return s + " (reverted)";
            }
            return s;
        }
    }
}
