using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder.Flows.Saving.ViewModels
{
    using System.Windows.Input;

    using Prism.Interactivity.InteractionRequest;

    public interface ISavingMacroViewModel
    {
        IConfirmation SavingConfirmation { get; }

        string MacroName { get; set; }

        ICommand Save { get; }

        bool CanSave { get; }

        ICommand Cancel { get; }

        bool CanCancel { get; }
    }
}
