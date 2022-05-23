using System;
using System.Collections.Generic;

namespace UnitTesting.GettingStarted.Messaging
{
    public class MessageProcessor : IMessageProcessor
    {
        private readonly IMessageHandler _handler;

        public MessageProcessor(IMessageHandler handler)
        {
            _handler = handler;
        }

        public bool ProcessMessages(IList<string> messages)
        {
            foreach (var message in messages)
            {
                var result = _handler.HandleMessage(message);
                _handler.SendToParser();

                if (!result)
                {
                    return false;
                }
            }

            return true;
        }

        public IList<string> GetMessages()
        {
            return _handler.GetMessages();
        }
    }
}