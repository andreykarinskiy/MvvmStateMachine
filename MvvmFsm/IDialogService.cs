using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFsm
{
    using Prism.Interactivity.InteractionRequest;

    public interface IDialogService
    {
        IConfirmation Show(string title, ViewModel viewModel);
    }
}
