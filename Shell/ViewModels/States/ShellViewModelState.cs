using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.ViewModels.States
{
    using System.Windows.Input;

    using MvvmFsm;

    using Prism.Commands;
    using Prism.Events;

    public abstract class ShellViewModelState : ViewModelState, IShellViewModel
    {
        protected ShellViewModelState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            this.Record = new DelegateCommand(this.SwitchToRecorder, () => !this.CanRecord);
            this.Play = new DelegateCommand(this.SwitchToPlayer, () => !this.CanPlay);
        }

        public string Status
        {
            get { return Get(); }
            set { Set(value); }
        }

        public ICommand Record { get; }

        public ICommand Play { get; }

        public abstract bool CanRecord { get; }

        public abstract bool CanPlay { get; }

        public abstract void SwitchToRecorder();

        public abstract void SwitchToPlayer();
    }
}
