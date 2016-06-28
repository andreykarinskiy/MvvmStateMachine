namespace MacroRecorder.Flows.Recording.ViewModels.States
{
    using System.Windows.Input;

    using MacroRecorder.Services;

    using MvvmFsm;

    using Prism.Commands;
    using Prism.Events;

    public abstract class RecorderState : ViewModelState, IRecorderViewModel
    {
        protected readonly IEventProducer eventProducer;

        protected RecorderState(IEventProducer eventProducer, IEventAggregator eventAggregator) : base(eventAggregator)
        {
            this.eventProducer = eventProducer;
            this.Start = new DelegateCommand(this.StartRecording, () => this.CanStart);
            this.Pause = new DelegateCommand(this.PauseRecording, () => this.CanPause);
            this.Stop = new DelegateCommand(this.StopRecording, () => this.CanStop);
        }

        public string Status
        {
            get { return this.Get(); }
            set { this.Set(value); }
        }

        public ICommand Start { get; }

        public abstract bool CanStart { get; }

        public ICommand Pause { get; }

        public abstract bool CanPause { get; }

        public ICommand Stop { get; }

        public abstract bool CanStop { get; }

        protected abstract void StartRecording();

        protected abstract void PauseRecording();

        protected abstract void StopRecording();

        public override void Enter()
        {
            this.Status = this.GetType().Name;
        }
    }
}
