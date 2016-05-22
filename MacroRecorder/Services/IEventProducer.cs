using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder.Services
{
    public interface IEventProducer : IDisposable
    {
        IObservable<WindowsEvent> Events { get; }

        void Start();

        void Stop();
    }
}
