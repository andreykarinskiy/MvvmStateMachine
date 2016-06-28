using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder.Flows.Saving.ViewModels.States
{
    using MvvmFsm;

    using Prism.Events;

    public class ReadyState : SavingState
    {
        public ReadyState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override bool CanSave => true;

        public override bool CanCancel => false;

        protected override void SaveMacro()
        {
        }

        protected override void CancelSaving()
        {
        }
    }
}
