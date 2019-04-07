using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer.Domain
{
    public class Message
    {
        public string Sender { get; private set; }
        public string Action { get; private set;  }
        public string Destination { get; private set; }
        public string Value { get; private set; }
        public Message(string sender, string destination, string value, string action)
        {
            Sender = sender;
            Destination = destination;
            Value = value;
            Action = action;
        }
    }
}
