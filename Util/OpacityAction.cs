using System.Diagnostics;
using DmLib.Window;

namespace OnTopper.Util
{
    public class OpacityAction : Action
    {
        private readonly ushort previous;
        private readonly ushort current;

        public OpacityAction(ushort previous, ushort current, Process p)
        {
            this.Proc = p;
            this.previous = previous;
            this.current = current;
            this.Reverted = false;
        }

        private OpacityAction(ushort previous, ushort current, Process p, bool reverted)
        {
            this.Proc = p;
            this.previous = previous;
            this.current = current;
            this.Reverted = reverted;
        }

        public override Action Revert()
        {
            Transparency.SetWindowTransparency(Proc, previous);
            return new OpacityAction(current, previous, Proc, !Reverted);
        }

        public override string ToString()
        {
            var s = $"{Time}: Set opacity of {Proc.ProcessName} from {previous} to {current}";
            return Reverted ? s + " (reverted)" : s;
        }
    }
}
