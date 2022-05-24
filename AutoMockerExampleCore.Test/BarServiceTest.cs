using AutoMockerExampleCore.Interfaces;
using AutoMockerExampleCore.Services;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace AutoMockerExampleCore.Test
{
    [TestFixture]
    public class BarServiceTest
    {
        [Test]
        public void DoBarThing_Always_ShouldCallFooServiceTenTimes()
        {
            // Arrange
            var autoMocker = new AutoMocker();
            
            // We do not need to explicitly create a Mock for the IFooService for unitUnderTest.
            // Typically, if I was constructing an instance of “BarService” from a test,
            // I would need to inject in the mocks that I need.
            // Here, it is done implicitly when I call “CreateInstance”.
            // All constructor-injected dependencies are identified,
            // and mocks are automatically injected for them.
            var unitUnderTest = autoMocker.CreateInstance<BarService>();
            
            // Act 
            unitUnderTest.DoBarThing();
            
            // Assert
            // Call a “GetMock” to retrieve the implicitly mocked “IFooService” back out.
            var fooServiceMock = autoMocker.GetMock<IFooService>();
            fooServiceMock.Verify(x => x.DoFooThing(It.IsAny<int>()), Times.Exactly(10));
        }

        [Test]
        public void DoBarThing_Always_ShouldCallIntoStubbedFooService()
        {
            // Arrange
            var autoMocker = new AutoMocker();
            var fooServiceStub = new FooServiceStub();
            autoMocker.Use<IFooService>(fooServiceStub);
            var unitUnderTest = autoMocker.CreateInstance<BarService>();
            
            // Pre-assert
            //Assert.That(fooServiceStub, Has.Count.EqualTo(45));

            // Act 
            unitUnderTest.DoBarThing();
            
            // Assert
            Assert.That(fooServiceStub, Has.Count.EqualTo(45));
        }
    }
}