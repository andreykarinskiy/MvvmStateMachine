using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder.Services
{
    public struct WindowsEvent
    {
        public WindowsEvent(DateTime time)
        {
            this.Time = time;
        }

        public DateTime Time { get; }
    }
}
