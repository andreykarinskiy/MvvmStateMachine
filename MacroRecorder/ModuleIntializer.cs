using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder
{
    using MacroRecorder.Views;

    using Microsoft.Practices.Unity;

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
            this.regionManager.RegisterViewWithRegion("Controls", typeof(RecorderView));
        }
    }
}
