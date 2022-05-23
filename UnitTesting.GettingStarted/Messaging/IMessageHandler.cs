using System.Collections.Generic;

namespace UnitTesting.GettingStarted.Messaging
{
    public interface IMessageHandler
    {
        public bool HandleMessage(string message);
        public IList<string> GetMessages();
        public void SendToParser();
    }
}