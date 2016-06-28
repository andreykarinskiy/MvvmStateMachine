namespace MvvmFsm
{
    using System;
    using System.Threading.Tasks;

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

        protected virtual void ChangeState(Trigger trigger, TimeSpan? delay)
        {
            if (delay != null)
            {
                Task
                    .Delay(delay.Value)
                    .ContinueWith(task => Fire(trigger));
            }
            else
            {
                Fire(trigger);
            }
        }

        protected virtual void ChangeState<TState>(TimeSpan? delay = null) where TState : ViewModelState
        {
            ChangeState(new Trigger<TState>(), delay);
        }

        private void Fire(Trigger trigger)
        {
            eventAggregator.Publish(trigger);
            OnPropertyChanged(string.Empty);
        }
    }
}
