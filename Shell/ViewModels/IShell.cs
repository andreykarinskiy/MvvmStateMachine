using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.ViewModels
{
    public interface IShell
    {
        string Status { get; }

        bool CanRecord { get; }

        bool CanPlay { get; }

        void SwitchToRecorder();

        void SwitchToPlayer();
    }
}
