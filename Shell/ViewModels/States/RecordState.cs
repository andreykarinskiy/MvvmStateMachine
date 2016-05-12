using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.ViewModels.States
{
    using Prism.Events;

    public class RecordState : ShellState
    {
        public RecordState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            this.Status = "Recorder";
        }

        public override bool CanRecord => true;

        public override bool CanPlay => false;

        public override void SwitchToRecorder()
        {
        }

        public override void SwitchToPlayer()
        {
            ChangeState<PlayerState>();
        }
    }
}
