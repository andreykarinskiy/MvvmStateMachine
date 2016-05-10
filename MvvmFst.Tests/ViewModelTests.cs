namespace MvvmFst.Tests
{
    using FluentAssertions;
    using MvvmFsm;
    using NUnit.Framework;

    [TestFixture]
    public class ViewModelTests
    {
        private ViewModelWithSimpleProperty sut;

        [SetUp]
        public void Setup()
        {
            sut = new ViewModelWithSimpleProperty();
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

        [Test]
        public void WhenPropertyChangesThenNotificationPerformed()
        {
            // arrange
            sut.MonitorEvents();

            // act
            sut.Name = "New value";

            // assert
            sut.ShouldRaisePropertyChangeFor(o => o.Name);
        }
    }

    public class ViewModelWithSimpleProperty : ViewModel
    {
        public string Name
        {
            get { return Get(); }
            set { Set(value); }
        }
    }
}
