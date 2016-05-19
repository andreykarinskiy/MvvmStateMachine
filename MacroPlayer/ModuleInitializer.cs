using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroPlayer
{
    using MacroPlayer.ViewModels.States;
    using MacroPlayer.Views;

    using Microsoft.Practices.Unity;

    using MvvmFsm;

    using Prism.Modularity;
    using Prism.Regions;

    public class ModuleInitializer : IModule
    {
        private readonly IRegionManager regionManager;

        private readonly IUnityContainer container;

        public ModuleInitializer(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            container
                .RegisterFsm<PlayerState>()
                .State<ReadyState>("Ready");

            this.regionManager.RegisterViewWithRegion("Controls", typeof(PlayerView));
        }
    }
}
