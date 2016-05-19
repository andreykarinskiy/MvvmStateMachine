using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroPlayer.ViewModels.States
{
    using MvvmFsm;

    using Prism.Events;
    using Prism.Regions;

    public class ReadyState : PlayerState
    {
        private readonly IRegionManager regionManager;

        public ReadyState(IEventAggregator eventAggregator, IRegionManager regionManager) : base(eventAggregator)
        {
            this.regionManager = regionManager;
        }

        public override bool CanStart => true;

        public override bool CanStop => false;

        protected override void StartPlaying()
        {
            this.regionManager.RequestNavigate("Controls", "RecorderView");
            //this.eventAggregator.Publish();
        }

        protected override void StopPlaying()
        {
        }
    }
}
