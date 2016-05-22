using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroRecorder.Services;

namespace MacroRecorder.ViewModels.States
{
    using System.Windows.Input;

    using MvvmFsm;

    using Prism.Commands;
    using Prism.Events;

    public abstract class RecorderState : ViewModelState, IRecorderViewModel
    {
        protected readonly IEventProducer eventProducer;

        protected RecorderState(IEventProducer eventProducer, IEventAggregator eventAggregator) : base(eventAggregator)
        {
            this.eventProducer = eventProducer;
            this.Start = new DelegateCommand(this.StartRecording, () => this.CanStart);
            this.Pause = new DelegateCommand(this.PauseRecording, () => this.CanPause);
            this.Stop = new DelegateCommand(this.StopRecording, () => this.CanStop);
        }

        public string Status
        {
            get { return Get(); }
            set { Set(value); }
        }

        public ICommand Start { get; }

        public abstract bool CanStart { get; }

        public ICommand Pause { get; }

        public abstract bool CanPause { get; }

        public ICommand Stop { get; }

        public abstract bool CanStop { get; }

        protected abstract void StartRecording();

        protected abstract void PauseRecording();

        protected abstract void StopRecording();

        public override void Enter()
        {
            Status = GetType().Name;
        }
    }
}
