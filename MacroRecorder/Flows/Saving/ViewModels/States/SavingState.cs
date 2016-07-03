﻿using System.Windows.Input;
using MvvmFsm;
using Prism.Commands;
using Prism.Events;

namespace MacroRecorder.Flows.Saving.ViewModels.States
{
    using Prism.Interactivity.InteractionRequest;

    public abstract class SavingState : ViewModelState, ISavingMacroViewModel
    {
        protected SavingState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            this.Save = new DelegateCommand(this.SaveMacro, () => this.CanSave);
            this.Cancel = new DelegateCommand(this.CancelSaving, () => this.CanCancel);

            this.SavingConfirmation = new Confirmation { Confirmed = false };
        }

        public IConfirmation SavingConfirmation { get; set; }

        public string MacroName
        {
            get { return Get<string>(); }
            set { Set(value);}
        }

        public ICommand Save { get; }

        public abstract bool CanSave { get; }

        public ICommand Cancel { get; }

        public abstract bool CanCancel { get; }

        protected abstract void SaveMacro();

        protected abstract void CancelSaving();

    }
}
