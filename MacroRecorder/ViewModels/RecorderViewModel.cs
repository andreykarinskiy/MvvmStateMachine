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

    public class RecorderViewModel : ViewModel, IRecorderViewModel
    {
        public RecorderViewModel()
        {
            this.Start = new DelegateCommand(this.StartRecording, () => this.CanStart);
            this.Pause = new DelegateCommand(this.PauseRecording, () => this.CanPause);
            this.Start = new DelegateCommand(this.StopRecording, () => this.CanStop);
        }

        public string Status { get; }

        public ICommand Start { get; }

        public bool CanStart { get; } = true;

        public ICommand Pause { get; }

        public bool CanPause { get; } = false;

        public ICommand Stop { get; }

        public bool CanStop { get; } = false;

        protected void StartRecording()
        {
        }

        protected void PauseRecording()
        {
        }

        protected void StopRecording()
        {
        }
    }
}
