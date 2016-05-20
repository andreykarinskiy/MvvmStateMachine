namespace Shell.ViewModels
{
    using System.Windows.Input;

    using Microsoft.Practices.Unity;
    using MvvmFsm;

    using Prism.Commands;
    using Prism.Events;
    using Prism.Regions;

    using Shell.ViewModels.States;

    public class ShellViewModelViewModel : StateableViewModel<ShellViewModelState>, IShellViewModel
    {
        private readonly IRegionManager regionManager;

        public ShellViewModelViewModel([Dependency("Record")] ShellViewModelState initialViewModelState, ShellViewModelState[] allViewModelStates, IEventAggregator eventAggregator, IRegionManager regionManager) : base(initialViewModelState, allViewModelStates, eventAggregator)
        {
            this.regionManager = regionManager;
            eventAggregator.Subscribe<ShellInitialized>(state => regionManager.RequestNavigate("Controls", "RecorderView"));
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
