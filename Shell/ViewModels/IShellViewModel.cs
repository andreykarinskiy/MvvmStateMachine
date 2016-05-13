using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.ViewModels
{
    using System.Windows.Input;

    public interface IShellViewModel
    {
        string Status { get; }

        ICommand Record { get; }

        bool CanRecord { get; }

        ICommand Play { get; }

        bool CanPlay { get; }

        void SwitchToRecorder();

        void SwitchToPlayer();
    }
}
