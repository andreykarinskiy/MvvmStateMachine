using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.ViewModels.States
{
    using Prism.Events;

    public class PlayerState : ShellState
    {
        public PlayerState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            this.Status = "Player";
        }

        public override bool CanRecord => false;

        public override bool CanPlay => true;

        public override void SwitchToRecorder()
        {
            this.ChangeState<RecordState>();
        }

        public override void SwitchToPlayer()
        {
        }
    }
}
