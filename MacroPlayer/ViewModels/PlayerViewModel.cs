using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroPlayer.ViewModels
{
    using System.Windows.Input;

    using MacroPlayer.ViewModels.States;

    using Microsoft.Practices.Unity;

    using MvvmFsm;

    using Prism.Events;

    public class PlayerViewModel : StateableViewModel<PlayerState>, IPlayerViewModel
    {
        public PlayerViewModel([Dependency("Ready")]PlayerState initialViewModelState, PlayerState[] allViewModelStates, IEventAggregator eventAggregator) : base(initialViewModelState, allViewModelStates, eventAggregator)
        {
        }

        public string Status => this.CurrentState.Status;

        public ICommand Start => this.CurrentState.Start;

        public bool CanStart => this.CurrentState.CanStart;

        public ICommand Stop => this.CurrentState.Stop;

        public bool CanStop => this.CurrentState.CanStop;
    }
}
