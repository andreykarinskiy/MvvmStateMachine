using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder.ViewModels
{
    using System.Windows.Input;

    using Prism.Events;

    public interface IRecorderViewModel
    {
        string Status { get; }
        
        ICommand Start { get; }
        
        bool CanStart { get; }
        
        ICommand Pause { get; }
        
        bool CanPause { get; }
        
        ICommand Stop { get; }
        
        bool CanStop { get; } 
    }
}
