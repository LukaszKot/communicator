using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using TCPServer.Extensions;

namespace TCPServer.Infrastructure
{
    class Communication
    {
        private TcpClient _client;
        public BinaryReader Reader { get; private set; }
        private BinaryWriter _writer;
        public bool IsLoggedIn { get; private set; }
        private BackgroundWorker _backgroundWorker;
        public string Username { get; private set; }
        public List<string> EnteredChat { get; private set; }
        private ListBox _lbServer;
        private List<Communication> _existingCommunications;
        public Communication(TcpClient client, ListBox lbServer, List<Communication> exisitingCommunications)
        {
            _client = client;
            var networkStream = client.GetStream();
            Reader = new BinaryReader(networkStream);
            _writer = new BinaryWriter(networkStream);
            IsLoggedIn = false;
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += (e, sender)=>Work();
            _backgroundWorker.RunWorkerAsync();
            _lbServer = lbServer;
            EnteredChat = new List<string>();
            _existingCommunications = exisitingCommunications;
        }

        private void GoToBottom(ListBox listBox)
        {
            listBox.TopIndex = listBox.Items.Count - 1;
        }

        private void Work()
        {
            try
            {
                string message;
                while((message = Reader.ReadString())!="END")
                {
                    var messageObject = JsonConvert.DeserializeObject<Domain.Message>(message);
                    if(IsLoggedIn==false)
                    {
                        ProcessLogin(messageObject);
                    }
                    else
                    {
                        ProcessOtherCommands(messageObject);
                    }
                }
            }
        }

        private void ProcessLogin(Domain.Message message)
        {
            if (message.Action == "LOGIN")
            {
                Username = message.Sender;
                IsLoggedIn = true;
            }
        }

        private void ProcessOtherCommands(Domain.Message message)
        {
            if(message.Action=="MESSAGE")
            {
                string text = $"{message.Sender}: {message.Value}";
                _lbServer.Invoke(() => _lbServer.Items.Add(text));
                _lbServer.Invoke(() => GoToBottom(_lbServer));
                var filtredCommunication = _existingCommunications
                        .Where(x=>x.EnteredChat.Contains())
            }
        }
    }
}
