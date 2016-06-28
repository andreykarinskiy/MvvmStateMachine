namespace MacroRecorder.Flows.Recording.ViewModels
{
    using System.Windows.Input;

    using MacroRecorder.Flows.Recording.ViewModels.States;

    using Microsoft.Practices.Unity;

    using MvvmFsm;

    using Prism.Events;
    using Prism.Regions;

    public class RecorderViewModel : StateableViewModel<RecorderState>, IRecorderViewModel
    {
        private readonly IRegionManager regionManager;

        public RecorderViewModel([Dependency("Ready")]RecorderState initialViewModelState, RecorderState[] allViewModelStates, IEventAggregator eventAggregator, IRegionManager regionManager) : base(initialViewModelState, allViewModelStates, eventAggregator)
        {
            this.regionManager = regionManager;
        }

        public string Status => this.CurrentState.Status;

        public ICommand Start => this.CurrentState.Start;

        public bool CanStart => this.CurrentState.CanStart;

        public ICommand Pause => this.CurrentState.Pause;

        public bool CanPause => this.CurrentState.CanPause;

        public ICommand Stop => this.CurrentState.Stop;

        public bool CanStop => this.CurrentState.CanStop;

        public void StartRecording()
        {
        }

        public void PauseRecording()
        {
        }

        public void StopRecording()
        {
            this.regionManager.RequestNavigate("Controls", "PlayerView");
        }
    }
}
