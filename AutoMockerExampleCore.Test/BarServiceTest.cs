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
            
            // I tell AutoMocker that I want to use this stub if any class requests an instance of IFooService:
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

        [Test]
        public void DoOtherThing_Always_ShouldPerformMockedBehaviour()
        {
            // Arrange
            var autoMocker = new AutoMocker();
            
            // I setup AutoMocker to use a dynamically stubbed implementation of ISomeOtherService.
            // I instruct it to return the integer 30 when it receives the string “value”.
            autoMocker.Use<ISomeOtherService>(x => x.GetSomeValue("value") == 30);
            
            var unitUnderTest = autoMocker.CreateInstance<BarService>();
            
            // Act 
            var result = unitUnderTest.DoOtherThing("value");
            
            // Assert
            // I make an assertion that the correct value is returned, but also that all invocations setup on the mock are performed correctly, via the standard “VerifyAll()” method.
            Assert.That(result, Is.EqualTo(30));
            autoMocker.GetMock<ISomeOtherService>().VerifyAll();
        }
    }
}