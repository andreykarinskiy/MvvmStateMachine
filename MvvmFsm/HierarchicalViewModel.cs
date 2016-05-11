// ReSharper disable ExplicitCallerInfoArgument
namespace MvvmFsm
{
    using System.ComponentModel;
    using Prism.Events;

    public abstract class HierarchicalViewModel : ViewModel
    {
        protected readonly IEventAggregator eventAggregator;

        protected HierarchicalViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            eventAggregator.Subscribe<PropertyChangedEventArgs>(o => base.OnPropertyChanged(o.PropertyName));
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            eventAggregator.Publish(new PropertyChangedEventArgs(propertyName));
        }
    }
}
