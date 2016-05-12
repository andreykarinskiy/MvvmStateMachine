using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFsm
{
    using Microsoft.Practices.Unity;

    public static class ContainerExtension
    {
        public static FsmBuilder<TState> RegisterFsm<TState>(this IUnityContainer container)
            where TState : ViewModelState
        {
            return new FsmBuilder<TState>(container);
        }

        public sealed class FsmBuilder<TBaseState>
            where TBaseState : ViewModelState
        {
            private readonly IUnityContainer container;

            internal FsmBuilder(IUnityContainer container)
            {
                this.container = container;
            }

            public FsmBuilder<TBaseState> State<TConcreteState>(string stateName)
                where TConcreteState : TBaseState
            {
                var lifetime = new ContainerControlledLifetimeManager();
                container.RegisterType<TBaseState, TConcreteState>(stateName, lifetime);
                return this;
            }
        }
    }
}
