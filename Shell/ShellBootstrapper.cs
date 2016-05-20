namespace Shell
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using MacroRecorder;
    using MacroRecorder.Views;

    using Microsoft.Practices.Unity;

    using MvvmFsm;

    using Prism.Events;
    using Prism.Modularity;
    using Prism.Mvvm;
    using Prism.Regions;
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

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = new ModuleCatalog();

            catalog
                .AddModule(typeof(MacroPlayer.ModuleInitializer))
                .AddModule(typeof(MacroRecorder.ModuleIntializer));

            return catalog;
        }

        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<ShellView>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();

            var eventAggregator = Container.Resolve<IEventAggregator>();
            eventAggregator.Publish(new ShellInitialized());
        }

        public void Dispose()
        {
            this.Container.Dispose();
        }
    }
}
