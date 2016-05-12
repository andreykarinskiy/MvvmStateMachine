namespace Shell.ViewModels
{
    using System.Windows.Input;

    using Microsoft.Practices.Unity;
    using MvvmFsm;

    using Prism.Commands;
    using Prism.Events;
    using Shell.ViewModels.States;

    public class ShellViewModel : StateableViewModel<ShellState>, IShell
    {
        public ShellViewModel([Dependency("Record")] ShellState initialState, ShellState[] allStates, IEventAggregator eventAggregator) : base(initialState, allStates, eventAggregator)
        {
            this.Record = new DelegateCommand(this.SwitchToRecorder, () => !this.CanRecord);
            this.Play = new DelegateCommand(this.SwitchToPlayer, () => !this.CanPlay);
        }

        public ICommand Record { get; }

        public ICommand Play { get; }

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
