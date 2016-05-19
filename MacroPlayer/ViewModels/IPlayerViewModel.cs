using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroPlayer.ViewModels
{
    using System.Windows.Input;

    public interface IPlayerViewModel
    {
        string Status { get; }

        ICommand Start { get; }

        bool CanStart { get; }

        ICommand Stop { get; }

        bool CanStop { get; }
    }
}
