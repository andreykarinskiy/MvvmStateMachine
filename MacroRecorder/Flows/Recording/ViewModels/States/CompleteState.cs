namespace MacroRecorder.Flows.Recording.ViewModels.States
{
    using System;

    using MacroRecorder.Flows.Saving.ViewModels;
    using MacroRecorder.Services;

    using Microsoft.Practices.Unity;

    using MvvmFsm;

    using Prism.Events;

    public class CompleteState : RecorderState
    {
        private readonly IUnityContainer container;
        private readonly IDialogService dialogService;

        public CompleteState(IUnityContainer container, IDialogService dialogService, IEventProducer eventProducer, IEventAggregator eventAggregator) : base(eventProducer, eventAggregator)
        {
            this.container = container;
            this.dialogService = dialogService;
        }

        public override bool CanStart => false;

        public override bool CanPause => false;

        public override bool CanStop => false;

        protected override void StartRecording()
        {
        }

        protected override void PauseRecording()
        {
        }

        protected override void StopRecording()
        {
        }

        public override void Enter()
        {
            var confirmation = dialogService.Show("title", this.container.Resolve<SavingMacroViewModel>());

            if (confirmation == null)
            {
                throw new NotImplementedException();
            }

            if (confirmation.Confirmed)
            {
                
            }
            else
            {
                ChangeState<ReadyState>(delay: 1.Second());
            }
        }
    }
}
