namespace MvvmFsm
{
    using System.Linq;
    using Prism.Events;

    public abstract class StateableViewModel<TState> : HierarchicalViewModel
        where TState : ViewModelState
    {
        private readonly TState[] allViewModelStates;

        protected StateableViewModel(TState initialViewModelState, TState[] allViewModelStates, IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            this.allViewModelStates = allViewModelStates;

            eventAggregator.Subscribe<Trigger>(ChangeState);

            ChangeState(initialViewModelState);
        }

        protected TState CurrentState { get; private set; }

        private void ChangeState(Trigger trigger)
        {
            var nextState = FindState(trigger);

            if (nextState == null)
            {
                return;
            }

            ChangeState(nextState);
        }

        private void ChangeState(TState nextState)
        {
            CurrentState?.Exit();

            CurrentState = nextState;

            CurrentState.Enter();

            this.OnPropertyChanged(string.Empty);
        }

        private TState FindState(Trigger trigger)
        {
            var stateTrigger = trigger;
            return this.allViewModelStates.SingleOrDefault(o => o.GetType() == stateTrigger.State);
        }
    }
}
