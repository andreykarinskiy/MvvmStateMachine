using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MvvmFsm;
using NUnit.Framework;
using Prism.Events;

namespace MvvmFst.Tests
{
    [TestFixture]
    public class HierarchicalViewModelTests
    {
        private ParentViewModel sut;

        [SetUp]
        public void Setup()
        {
            var eventAggregator = new EventAggregator();

            sut = new ParentViewModel(eventAggregator)
            {
                Child = new ChildViewModel(eventAggregator)
            };
        }

        [Test]
        public void WhenChildPropertyChangedThenParentWillBeNotified()
        {
            // arrange
            var eventRaised = false;
            sut.PropertyChanged += (sender, args) => eventRaised = true;

            // act
            sut.Child.Number = 10;

            // assert
            eventRaised.Should().BeTrue();
        }
    }

    public sealed class ParentViewModel : HierarchicalViewModel
    {
        public ParentViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public ChildViewModel Child { get; set; }
    }

    public sealed class ChildViewModel : HierarchicalViewModel
    {
        public ChildViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public int Number
        {
            get { return Get(); }
            set { Set(value); }
        }
    }
}
