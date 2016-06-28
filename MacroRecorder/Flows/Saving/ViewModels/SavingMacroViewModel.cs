using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmFsm;

namespace MacroRecorder.Flows.Saving.ViewModels
{
    using System.Windows.Input;

    using MacroRecorder.Flows.Saving.ViewModels.States;

    using Microsoft.Practices.Unity;

    using Prism.Events;

    public class SavingMacroViewModel : StateableViewModel<SavingState>, ISavingMacroViewModel
    {
        public SavingMacroViewModel([Dependency("Saving.Ready")]SavingState initialViewModelState, SavingState[] allViewModelStates, IEventAggregator eventAggregator) : base(initialViewModelState, allViewModelStates, eventAggregator)
        {
        }

        public string MacroName
        {
            get { return this.CurrentState.MacroName; }
            set { this.CurrentState.MacroName = value; }
        }

        public ICommand Save => this.CurrentState.Save;

        public ICommand Cancel => this.CurrentState.Cancel;
    }
}
