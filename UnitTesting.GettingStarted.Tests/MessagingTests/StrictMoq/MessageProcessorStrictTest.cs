using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using UnitTesting.GettingStarted.Messaging;

namespace UnitTesting.GettingStarted.Tests.MessagingTests.StrictMoq
{
    [TestFixture]
    public class MessageProcessorStrictTest
    {
        [Test]
        public void ProcessMessage_OnError_ReturnsFalse()
        {
            // Arrange
            var incomingMessages = new List<string>
            {
                "Message 1",
                "Message 2"
            };

            var messageHandlerMock = new Mock<IMessageHandler>(MockBehavior.Strict);

            messageHandlerMock.Setup(x => x.HandleMessage(It.IsAny<string>())).Returns(false);

            var itemUnderTest = new MessageProcessor(messageHandlerMock.Object);
            
            // Act
            var result = itemUnderTest.ProcessMessages(incomingMessages);
            
            // Assert 
            Assert.That(result, Is.False);
        }

        [Test]
        public void ProcessMessage_OnSuccess_ReturnsTrue()
        {
            // Arrange 
            var incomingMessages = new List<string>
            {
                "Message 1",
                "Message 2"
            };

            var messageHandlerMock = new Mock<IMessageHandler>(MockBehavior.Strict);

            messageHandlerMock.Setup(x => x.HandleMessage(It.IsAny<string>())).Returns(true);

            var itemUnderTest = new MessageProcessor(messageHandlerMock.Object);
            
            // Act 
            var result = itemUnderTest.ProcessMessages(incomingMessages);
            
            // Assert 
            Assert.That(result, Is.True);
        }
    }
}