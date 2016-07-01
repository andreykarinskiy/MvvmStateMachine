using MvvmFsm;

namespace MacroRecorder.Flows.Recording.ViewModels.States
{
    using System;

    using MacroRecorder.Services;

    using Prism.Events;

    public class RecordingState : RecorderState
    {
        public RecordingState(IEventProducer eventProducer, IEventAggregator eventAggregator) : base(eventProducer, eventAggregator)
        {
            eventProducer.Events.Subscribe(o => Console.Beep());
        }

        public override bool CanStart => false;

        public override bool CanPause => true;

        public override bool CanStop => true;

        public override void Enter()
        {
            this.eventProducer.Start();
        }

        public override void Exit()
        {
            this.eventProducer.Stop();
        }

        protected override void StartRecording()
        {
            throw new InvalidStateException(this);
        }

        protected override void PauseRecording()
        {
            this.ChangeState<PausedState>();
        }

        protected override void StopRecording()
        {
            this.ChangeState<CompleteState>();
        }
    }
}
