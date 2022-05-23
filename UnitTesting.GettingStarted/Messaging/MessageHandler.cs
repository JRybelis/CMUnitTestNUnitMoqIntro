using System.Collections.Generic;
using System.Text;

namespace UnitTesting.GettingStarted.Messaging
{
    public class MessageHandler : IMessageHandler
    {
        private readonly IList<string> _messages = new List<string>();

        public bool HandleMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return false;
            }

            var sb = new StringBuilder();
            sb.Append($"[The message is: {message}].");
            
            _messages.Add(sb.ToString());
            
            return true;
        }

        public IList<string> GetMessages()
        {
            return _messages;
        }

        public void SendToParser()
        {
            // some code to send the messages to a parser service.
        }
    }
}