using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.ViewModels.States
{
    using MvvmFsm;

    using Prism.Events;

    public abstract class ShellState : ViewModelState, IShell
    {
        protected ShellState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public string Status
        {
            get { return Get(); }
            set { Set(value); }
        }

        public abstract bool CanRecord { get; }

        public abstract bool CanPlay { get; }

        public abstract void SwitchToRecorder();

        public abstract void SwitchToPlayer();
    }
}
