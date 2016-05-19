namespace Shell
{
    using System;
    using System.Windows;

    using MacroRecorder;

    using Microsoft.Practices.Unity;

    using MvvmFsm;

    using Prism.Modularity;
    using Prism.Mvvm;
    using Prism.Unity;

    using Shell.ViewModels.States;
    using Shell.Views;

    public class ShellBootstrapper : UnityBootstrapper, IDisposable
    {
        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = new ModuleCatalog();

            catalog
                .AddModule(typeof(MacroPlayer.ModuleInitializer))
                .AddModule(typeof(MacroRecorder.ModuleIntializer));

            return catalog;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container
                .RegisterFsm<ShellViewModelState>()
                .State<RecordViewModelState>("Record")
                .State<PlayerViewModelState>("Player");
        }

        //protected override void ConfigureViewModelLocator()
        //{
        //    ViewModelLocationProvider.SetDefaultViewModelFactory(t => Container.Resolve(t));
        //}

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
