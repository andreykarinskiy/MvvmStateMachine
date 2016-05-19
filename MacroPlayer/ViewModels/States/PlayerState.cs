using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroPlayer.ViewModels.States
{
    using System.Windows.Input;

    using MvvmFsm;

    using Prism.Commands;
    using Prism.Events;

    public abstract class PlayerState : ViewModelState, IPlayerViewModel
    {
        protected PlayerState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            this.Start = new DelegateCommand(this.StartPlaying, () => this.CanStart);
            this.Stop = new DelegateCommand(this.StopPlaying, () => this.CanStop);
        }

        public string Status
        {
            get { return Get(); }
            set { Set(value); }
        }

        public ICommand Start { get; }

        public ICommand Stop { get; }

        public abstract bool CanStart { get; }

        public abstract bool CanStop { get; }

        protected abstract void StartPlaying();

        protected abstract void StopPlaying();
    }
}
