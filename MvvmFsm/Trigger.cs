namespace MvvmFsm
{
    using System;

    public abstract class Trigger
    {
        public abstract Type State { get; }
    }

    public sealed class Trigger<TState> : Trigger
        where TState : ViewModelState
    {
        public override Type State => typeof(TState);
    }
}
