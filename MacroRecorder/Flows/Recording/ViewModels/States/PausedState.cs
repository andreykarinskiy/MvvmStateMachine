using MvvmFsm;

namespace MacroRecorder.Flows.Recording.ViewModels.States
{
    using MacroRecorder.Services;

    using Prism.Events;

    public class PausedState : RecorderState
    {
        public PausedState(IEventProducer eventProducer, IEventAggregator eventAggregator) : base(eventProducer, eventAggregator)
        {
        }

        public override bool CanStart => true; 

        public override bool CanPause => false;

        public override bool CanStop => true;

        protected override void StartRecording()
        {
            this.ChangeState<RecordingState>();
        }

        protected override void PauseRecording()
        {
            throw new InvalidStateException(this);
        }

        protected override void StopRecording()
        {
            this.ChangeState<CompleteState>();
        }

        public override void Enter()
        {
            this.eventProducer.Stop();
        }
    }
}
