using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder.Flows.Saving.ViewModels.States
{
    using MvvmFsm;

    using Prism.Events;
    using Prism.Interactivity.InteractionRequest;

    public class ReadyState : SavingState
    {
        public ReadyState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override bool CanSave => true;

        public override bool CanCancel => true;

        protected override void SaveMacro()
        {
            throw new NotImplementedException();
        }

        protected override void CancelSaving()
        {
            this.SavingConfirmation = new Confirmation { Confirmed = false };
        }
    }
}
