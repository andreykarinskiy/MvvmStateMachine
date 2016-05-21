using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder
{
    using MacroRecorder.ViewModels.States;
    using MacroRecorder.Views;

    using Microsoft.Practices.Unity;

    using MvvmFsm;

    using Prism.Modularity;
    using Prism.Regions;

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
                .RegisterFsm<RecorderState>()
                .State<ReadyState>("Ready")
                .State<RecordingState>("Recording")
                .State<PausedState>("Paused")
                .State<CompleteState>("Complete");

            regionManager
                .AddToRegion("Controls", container.Resolve<RecorderView>());
        }
    }
}
