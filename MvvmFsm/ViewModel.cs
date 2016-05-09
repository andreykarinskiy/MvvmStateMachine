using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace MvvmFsm
{
    public class ViewModel : BindableBase
    {
        private readonly IDictionary<string, object> properties = new Dictionary<string, object>();

        protected dynamic Get([CallerMemberName] string propertyName = default(string))
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            return Get<dynamic>(propertyName);
        }

        protected virtual T Get<T>([CallerMemberName] string propertyName = default(string))
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException("propertyName");
            }

            object value;
            if (properties.TryGetValue(propertyName, out value))
            {
                return (T) value;
            }

            return default(T);
        }

        protected virtual void Set<T>(T value, [CallerMemberName] string propertyName = default(string))
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException("propertyName");
            }

            properties[propertyName] = value;
        }
    }
}
