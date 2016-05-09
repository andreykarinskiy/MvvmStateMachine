using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MvvmFsm;
using NUnit.Framework;

namespace MvvmFst.Tests
{
    [TestFixture]
    public class ViewModelTests
    {
        private SimpleViewModel sut;

        [SetUp]
        public void Setup()
        {
            sut = new SimpleViewModel();
        }

        [Test]
        public void WhenPropertyHasNotBeenSpecifiedThenReturnsDefaultValue()
        {
            // arrange

            // act
            var value = sut.Name;

            // assert
            value.Should().BeNullOrEmpty();
        }

        [Test]
        public void WhenPropertyHasBeenSetThenItReturnsValue()
        {
            // arrange
            sut.Name = "Batygin";

            // act
            var value = sut.Name;
             
            // assert
            value.Should().Be("Batygin");
        }
    }

    public class SimpleViewModel : ViewModel
    {
        public string Name
        {
            get { return Get(); }
            set { Set(value); }
        }
    }
}
