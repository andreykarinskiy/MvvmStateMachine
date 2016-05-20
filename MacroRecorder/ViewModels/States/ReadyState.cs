using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder.ViewModels.States
{
    using Prism.Events;

    public class ReadyState : RecorderState
    {
        public ReadyState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override bool CanStart => true;

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
