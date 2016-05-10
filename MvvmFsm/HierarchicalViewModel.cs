using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace MvvmFsm
{
    public abstract class HierarchicalViewModel : ViewModel
    {
        private readonly IEventAggregator eventAggregator;

        protected HierarchicalViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            SubscribeToEvents(eventAggregator);
        }

        private void SubscribeToEvents(IEventAggregator eventAggregator)
        {
            eventAggregator
                .GetEvent<PubSubEvent<PropertyChangedEventArgs>>()
                .Subscribe(o => OnPropertyChanged(o.PropertyName));
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            eventAggregator.GetEvent<PubSubEvent<PropertyChangedEventArgs>>().Publish(new PropertyChangedEventArgs(propertyName));
        }
    }
}
