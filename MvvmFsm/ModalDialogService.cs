using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFsm
{
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;

    using CommonControls;

    using Microsoft.Practices.Unity;

    using Prism.Interactivity.InteractionRequest;
    using Prism.Mvvm;

    public class ModalDialogService : IDialogService
    {
        private readonly IUnityContainer container;

        public ModalDialogService(IUnityContainer container)
        {
            this.container = container;
        }

        public IConfirmation Show(string title, ViewModel viewModel)
        {
            //var views = this.container.

            var vmType = viewModel.GetType();
            var assembly = vmType.Assembly;
            var s = assembly
                .GetTypes()
                .Where(t => typeof(FrameworkElement).IsAssignableFrom(t))
                .Where(t => t.Name.StartsWith("Saving"));

            var window = new DialogWindow();
            var view = s.First();
            window.Content = view;
            window.ShowDialog();

            return null;
        }
    }
}
