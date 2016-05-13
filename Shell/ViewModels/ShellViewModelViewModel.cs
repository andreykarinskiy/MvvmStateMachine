namespace Shell.ViewModels
{
    using System.Windows.Input;

    using Microsoft.Practices.Unity;
    using MvvmFsm;

    using Prism.Commands;
    using Prism.Events;
    using Shell.ViewModels.States;

    public class ShellViewModelViewModel : StateableViewModel<ShellViewModelState>, IShellViewModel
    {
        public ShellViewModelViewModel([Dependency("Record")] ShellViewModelState initialViewModelState, ShellViewModelState[] allViewModelStates, IEventAggregator eventAggregator) : base(initialViewModelState, allViewModelStates, eventAggregator)
        {
        }

        public ICommand Record => this.CurrentState.Record;

        public ICommand Play => this.CurrentState.Play;

        public bool CanRecord => this.CurrentState.CanRecord;

        public bool CanPlay => this.CurrentState.CanPlay;

        public string Status => this.CurrentState.Status;

        public void SwitchToRecorder()
        {
            this.CurrentState.SwitchToRecorder();
        }

        public void SwitchToPlayer()
        {
            this.CurrentState.SwitchToPlayer();
        }
    }
}
