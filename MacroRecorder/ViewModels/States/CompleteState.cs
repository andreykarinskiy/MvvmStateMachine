using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace MacroRecorder.ViewModels.States
{
    public class CompleteState : RecorderState
    {
        public CompleteState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override bool CanStart => false;

        public override bool CanPause => false;

        public override bool CanStop => false;

        protected override void StartRecording()
        {
        }

        protected override void PauseRecording()
        {
        }

        protected override void StopRecording()
        {
        }
    }
}
