using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace MacroRecorder.ViewModels.States
{
    public class PausedState : RecorderState
    {
        public PausedState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override bool CanStart => true;

        public override bool CanPause => false;

        public override bool CanStop => true;

        protected override void StartRecording()
        {
            ChangeState<RecordingState>();
        }

        protected override void PauseRecording()
        {
        }

        protected override void StopRecording()
        {
            ChangeState<CompleteState>();
        }
    }
}
