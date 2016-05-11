// ReSharper disable ExplicitCallerInfoArgument
namespace MvvmFsm
{
    using System.ComponentModel;
    using Prism.Events;

    public abstract class HierarchicalViewModel : ViewModel
    {
        private readonly IEventAggregator eventAggregator;

        protected HierarchicalViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            eventAggregator
                .GetEvent<PubSubEvent<PropertyChangedEventArgs>>()
                .Subscribe(o => base.OnPropertyChanged(o.PropertyName));
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            eventAggregator.GetEvent<PubSubEvent<PropertyChangedEventArgs>>().Publish(new PropertyChangedEventArgs(propertyName));
        }
    }
}
