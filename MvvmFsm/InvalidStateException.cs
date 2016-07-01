using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MvvmFsm.Annotations;

namespace MvvmFsm
{
    public class InvalidStateException : Exception
    {
        public InvalidStateException(ViewModelState state, [CallerMemberName]string methodName = default(string)) : base(Format(state, methodName))
        {
        }

        private static string Format(ViewModelState state, string methodName)
        {
            return $"{state.GetType().Name} --> {methodName}()";
        }
    }
}
