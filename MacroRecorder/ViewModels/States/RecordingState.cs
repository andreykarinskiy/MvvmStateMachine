using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace MacroRecorder.ViewModels.States
{
    public class RecordingState : RecorderState
    {
        public RecordingState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override bool CanStart => false;

        public override bool CanPause => true;

        public override bool CanStop => true;

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
