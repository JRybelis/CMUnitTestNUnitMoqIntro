using System.Collections.Generic;

namespace UnitTesting.GettingStarted.Messaging
{
    public interface IMessageProcessor
    {
        public bool ProcessMessages(IList<string> messages);
        public IList<string> GetMessages();
    }
}