using System;
using System.Diagnostics;

namespace OnTopper.Util
{
    public abstract class Action
    {
        protected Process Proc;
        protected bool Reverted { get; set; }
        protected readonly DateTime Time = DateTime.Now;

        public abstract Action Revert();
    }
}
