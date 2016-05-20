namespace MvvmFsm
{
    using System;
    using Prism.Events;

    public static class EventAggregatorExtension
    {
        public static void Subscribe<T>(this IEventAggregator eventAggregator, Action<T> subscriber)
        {
            eventAggregator.GetEvent<PubSubEvent<T>>().Subscribe(subscriber);
        }

        public static void Publish<T>(this IEventAggregator eventAggregator, T message)
        {
            eventAggregator.GetEvent<PubSubEvent<T>>().Publish(message);
        }

        public static void Publish<T>(this IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<PubSubEvent<T>>().Publish(default(T));
        }
    }
}
