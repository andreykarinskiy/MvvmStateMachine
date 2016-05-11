namespace MvvmFsm
{
    using Prism.Events;

    public abstract class ViewModelState : HierarchicalViewModel
    {
        protected ViewModelState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        protected virtual void ChangeState(Trigger trigger)
        {
            eventAggregator.Publish(trigger);
        }

        protected virtual void ChangeState<TState>() where TState : ViewModelState
        {
            ChangeState(new Trigger<TState>());
        }
    }
}
