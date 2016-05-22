using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroRecorder.Services;

namespace MacroRecorder.ViewModels.States
{
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
            ChangeState<RecordingState>();
        }

        protected override void PauseRecording()
        {
        }

        protected override void StopRecording()
        {
        }
    }
}
