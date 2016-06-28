using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder.Flows.Saving.ViewModels
{
    using System.Windows.Input;

    public interface ISavingMacroViewModel
    {
        string MacroName { get; set; }

        ICommand Save { get; }

        ICommand Cancel { get; }
    }
}
