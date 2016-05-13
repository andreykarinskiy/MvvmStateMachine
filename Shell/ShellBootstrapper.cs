namespace Shell
{
    using System;
    using System.Windows;
    using Microsoft.Practices.Unity;

    using MvvmFsm;

    using Prism.Unity;

    using Shell.ViewModels.States;
    using Shell.Views;

    public class ShellBootstrapper : UnityBootstrapper, IDisposable
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container
                .RegisterFsm<ShellViewModelState>()
                .State<RecordViewModelState>("Record")
                .State<PlayerViewModelState>("Player");
        }

        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<ShellView>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        public void Dispose()
        {
            this.Container.Dispose();
        }
    }
}
