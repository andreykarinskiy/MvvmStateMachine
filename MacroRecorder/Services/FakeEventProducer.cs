using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Prism.Events;

namespace MacroRecorder.Services
{
    public class FakeEventProducer : IEventProducer
    {
        private readonly ISubject<WindowsEvent> eventProducer = new Subject<WindowsEvent>();

        private Timer timer;

        public IObservable<WindowsEvent> Events => eventProducer;

        public void Start()
        {
            Stop();

            timer = new Timer(Callback, this, 0, 1000);
        }

        public void Stop()
        {
            if (timer == null)
            {
                return;
            }

            timer.Dispose();
            timer = null;
        }

        public void Dispose()
        {
            Stop();
        }

        private void Callback(object state)
        {
            var time = DateTime.Now;
            eventProducer.OnNext(new WindowsEvent(time));
        }
    }
}
