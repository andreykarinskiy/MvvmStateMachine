namespace MacroRecorder.Flows.Recording.ViewModels.States
{
    using MacroRecorder.Services;

    using Prism.Events;

    public class ReadyState : RecorderState
    {
        public ReadyState(IEventProducer eventProducer, IEventAggregator eventAggregator) : base(eventProducer, eventAggregator)
        {
        }

        public override bool CanStart => true;

        public override bool CanPause => false;

        public override bool CanStop => false;

        protected override void StartRecording()
        {
            this.ChangeState<RecordingState>();
        }

        protected override void PauseRecording()
        {
        }

        protected override void StopRecording()
        {
        }
    }
}
