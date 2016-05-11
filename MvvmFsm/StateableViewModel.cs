namespace MvvmFsm
{
    using System.Linq;
    using Prism.Events;

    public abstract class StateableViewModel<TState> : HierarchicalViewModel
        where TState : ViewModelState
    {
        private readonly TState[] allStates;

        protected StateableViewModel(TState initialState, TState[] allStates, IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            this.allStates = allStates;

            eventAggregator.Subscribe<Trigger>(ChangeState);

            ChangeState(initialState);
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
        }

        private TState FindState(Trigger trigger)
        {
            var stateTrigger = trigger;
            return allStates.SingleOrDefault(o => o.GetType() == stateTrigger.State);
        }
    }
}
