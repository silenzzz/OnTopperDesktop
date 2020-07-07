using System;
using System.Diagnostics;

namespace OnTopper.Stuff
{
    public abstract class Action
    {
        protected Process proc;
        protected bool Reverted { get; set; }
        protected readonly DateTime time = DateTime.Now;

        public abstract Action Revert();
    }
}
