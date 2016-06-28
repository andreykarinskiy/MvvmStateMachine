using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroRecorder.Services;

namespace MacroRecorder
{
    using MacroRecorder.Flows.Recording.ViewModels.States;
    using MacroRecorder.Flows.Recording.Views;
    using MacroRecorder.Flows.Saving.ViewModels.States;

    using Microsoft.Practices.Unity;

    using MvvmFsm;

    using Prism.Modularity;
    using Prism.Regions;

    using ReadyState = MacroRecorder.Flows.Recording.ViewModels.States.ReadyState;

    public class ModuleIntializer : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;

        public ModuleIntializer(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            container
                .RegisterType<IEventProducer, FakeEventProducer>(new ContainerControlledLifetimeManager());

            container
                .RegisterFsm<RecorderState>()
                .State<ReadyState>("Ready")
                .State<RecordingState>("Recording")
                .State<PausedState>("Paused")
                .State<CompleteState>("Complete");

            container
                .RegisterFsm<SavingState>()
                .State<Flows.Saving.ViewModels.States.ReadyState>("Saving.Ready");

            container
                .RegisterType<IDialogService, ModalDialogService>();

            regionManager
                .AddToRegion("Controls", container.Resolve<RecorderView>());
        }
    }
}
