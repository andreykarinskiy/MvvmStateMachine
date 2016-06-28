using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroRecorder.Services;
using Prism.Events;

namespace MacroRecorder.ViewModels.States
{
    using MvvmFsm;

    public class CompleteState : RecorderState
    {
        public CompleteState(IEventProducer eventProducer, IEventAggregator eventAggregator) : base(eventProducer, eventAggregator)
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

        public override void Enter()
        {
            this.ChangeState<ReadyState>(delay: 1.Second());
        }
    }
}
