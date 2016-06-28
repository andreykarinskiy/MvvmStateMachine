using System.Windows.Input;
using MvvmFsm;
using Prism.Commands;
using Prism.Events;

namespace MacroRecorder.Flows.Saving.ViewModels.States
{
    public abstract class SavingState : ViewModelState, ISavingMacroViewModel
    {
        protected SavingState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            this.Save = new DelegateCommand(this.SaveMacro, () => this.CanSave);
            this.Cancel = new DelegateCommand(this.CancelSaving, () => this.CanCancel);
        }

        public string MacroName { get; set; }

        public ICommand Save { get; }

        public abstract bool CanSave { get; }

        public ICommand Cancel { get; }

        public abstract bool CanCancel { get; }

        protected abstract void SaveMacro();

        protected abstract void CancelSaving();

    }
}
