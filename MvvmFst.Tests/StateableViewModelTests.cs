using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFst.Tests
{
    using FluentAssertions;

    using MvvmFsm;

    using NUnit.Framework;

    using Prism.Events;

    [TestFixture]
    public class StateableViewModelTests
    {
        private DoorViewModel sut;

        [SetUp]
        public void Setup()
        {
            var eventAggregator = new EventAggregator();

            var closedState = new ClosedState(eventAggregator);
            var openedState = new OpenedState(eventAggregator);

            sut = new DoorViewModel(closedState, new DoorState[] { closedState, openedState }, eventAggregator);
        }

        [Test]
        public void t1()
        {
            // assert
            sut.IsOpened.Should().BeFalse();
        }

        [Test]
        public void t2()
        {
            sut.Open();
            sut.IsOpened.Should().BeTrue();
        }

        [Test]
        public void t3()
        {
            sut.Open();
            sut.Close();
            sut.IsOpened.Should().BeFalse();
        }
    }

    public interface IDoor
    {
        bool IsOpened { get; }

        void Open();

        void Close();
    }

    public class DoorViewModel : StateableViewModel<DoorState>, IDoor
    {
        public DoorViewModel(DoorState initialState, DoorState[] allStates, IEventAggregator eventAggregator) : base(initialState, allStates, eventAggregator)
        {
        }

        public bool IsOpened => CurrentState.IsOpened;

        public void Open()
        {
            CurrentState.Open();
        }

        public void Close()
        {
            CurrentState.Close();
        }
    }

    public abstract class DoorState : ViewModelState, IDoor
    {
        protected DoorState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public bool IsOpened { get; set; }

        public abstract void Open();

        public abstract void Close();
    }

    public sealed class ClosedState : DoorState
    {
        public ClosedState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override void Enter()
        {
            IsOpened = false;
        }

        public override void Open()
        {
            ChangeState<OpenedState>();
        }

        public override void Close()
        {
        }
    }

    public sealed class OpenedState : DoorState
    {
        public OpenedState(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override void Enter()
        {
            IsOpened = true;
        }

        public override void Open()
        {
        }

        public override void Close()
        {
            ChangeState<ClosedState>();
        }
    }
}
