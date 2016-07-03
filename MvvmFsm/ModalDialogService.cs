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
            var vmType = viewModel.GetType();
            var assembly = vmType.Assembly;
            var s = assembly
                .GetTypes()
                .Where(t => typeof(FrameworkElement).IsAssignableFrom(t))
                .Where(t => t.Name.StartsWith("Saving"));

            var window = new DialogWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.SizeToContent = SizeToContent.WidthAndHeight;

            var viewType = s.First();
            var view = this.container.Resolve(viewType);
            window.Content = view;
            window.ShowDialog();

            dynamic vm = viewModel;
            IConfirmation confirmation = vm.SavingConfirmation;

            return confirmation;
        }
    }
}
