using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroRecorder.Services;
using Prism.Events;

namespace MacroRecorder.ViewModels.States
{
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
            eventProducer.Start();
        }

        public override void Exit()
        {
            eventProducer.Stop();
        }

        protected override void StartRecording()
        {
        }

        protected override void PauseRecording()
        {
            ChangeState<PausedState>();
        }

        protected override void StopRecording()
        {
            ChangeState<CompleteState>();
        }
    }
}
