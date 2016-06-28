using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFsm
{
    public static class TimeExtension
    {
        public static TimeSpan Second(this int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }
    }
}
