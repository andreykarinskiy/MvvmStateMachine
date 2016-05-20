using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder.ViewModels
{
    using System.Windows.Input;

    using MvvmFsm;

    using Prism.Commands;
    using Prism.Regions;

    public class RecorderViewModel : ViewModel, IRecorderViewModel
    {
        private readonly IRegionManager regionManager;

        public RecorderViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            this.Start = new DelegateCommand(this.StartRecording, () => this.CanStart);
            this.Pause = new DelegateCommand(this.PauseRecording, () => this.CanPause);
            this.Stop = new DelegateCommand(this.StopRecording, () => this.CanStop);

            this.Status = "recorder status";
        }

        public string Status
        {
            get { return Get(); }
            set { Set(value); }
        }

        public ICommand Start { get; }

        public bool CanStart { get; } = false;

        public ICommand Pause { get; }

        public bool CanPause { get; } = false;

        public ICommand Stop { get; }

        public bool CanStop { get; } = true;

        public void StartRecording()
        {
        }

        public void PauseRecording()
        {
        }

        public void StopRecording()
        {
            this.regionManager.RequestNavigate("Controls", "PlayerView");
        }
    }
}
