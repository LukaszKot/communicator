using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using TCPServer.Extensions;

namespace TCPServer.Services
{
    public class Connection
    {
        private readonly TcpClient _client;
        private readonly BackgroundWorker _backgroundWorker;
        private readonly BinaryReader _binaryReader;
        private readonly BinaryWriter _binaryWriter;
        public string Username { get; private set; }
        private readonly WebBrowser _wbServer;
        private readonly TcpServerService _tcpServerService;
        public Connection(TcpClient client, WebBrowser wbServer, TcpServerService tcpServer)
        {
            _client = client;
            _wbServer = wbServer;
            _tcpServerService = tcpServer;
            var networkStream = _client.GetStream();
            _binaryReader = new BinaryReader(networkStream);
            _binaryWriter = new BinaryWriter(networkStream);
            _backgroundWorker = new BackgroundWorker();
            Username = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();
            _wbServer.Display($"[{Username}]: Nawiązano połączenie");
            SetupBackgroundWorker();
        }

        private void SetupBackgroundWorker()
        {
            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.WorkerSupportsCancellation = true;
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ListenForIncomingMessages();
            }
            catch(IOException)
            {
            }
            HardCloseConnection();
            return;
        }

        private void HardCloseConnection()
        {
            _wbServer.Display($"<b>[{Username}]</b>: Zakończono połączenie");
            _backgroundWorker.CancelAsync();
            if(_backgroundWorker.CancellationPending)
            {
                _client.Close();
                _tcpServerService.IfNoneTurnOffChat(this);
            }
        }

        private void ListenForIncomingMessages()
        {
            string message;
            while((message=_binaryReader.ReadString())!="END")
            {
                string resultMessage = $"<b>{Username}</b>: {message}";
                _wbServer.Display(resultMessage);
                _tcpServerService.PropagateToEveryone(resultMessage);
            }
        }

        public void Close()
        {
            if(_client!=null) _client.Close();
        }

        public void RunConnectionWorker()
        {
            _backgroundWorker.RunWorkerAsync();
        }

        public void Send(string message)
        {
            if(_binaryWriter!=null) _binaryWriter.Write(message);
        }
    }
}
