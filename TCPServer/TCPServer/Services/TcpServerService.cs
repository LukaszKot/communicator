using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using TCPServer.Extensions;

namespace TCPServer.Services
{
    public class TcpServerService
    {
        private readonly BackgroundWorker _serverWorker;
        private readonly Button _bStart;
        private readonly Button _bStop;
        private TcpListener server;
        private readonly WebBrowser _wbServer;
        private readonly List<Connection> _connections;
        private readonly TextBox _tbChatInput;
        private readonly Button _bChatSubmit;

        public TcpServerService(BackgroundWorker serverWorker, Button bStart, Button bStop, WebBrowser wbServer, TextBox tbChatInput, Button bChatSubmit)
        {
            _serverWorker = serverWorker;
            _bStart = bStart;
            _bStop = bStop;
            _wbServer = wbServer;
            _wbServer.DocumentCompleted += _wbServer_DocumentCompleted;
            _tbChatInput = tbChatInput;
            _bChatSubmit = bChatSubmit;
            _connections = new List<Connection>();
        }

        private void _wbServer_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _wbServer.Document.Window.ScrollTo(0, _wbServer.Document.Body.ScrollRectangle.Height);
        }

        public void RunServer(string address)
        {
            var addressIp = GetAddressIp(address);
            if (address == null) return;
            _serverWorker.RunWorkerAsync();
            _bStart.Enabled = false;
            _bStop.Enabled = true;
        }

        public void Listen(string address, decimal port)
        {
            var addressIp = GetAddressIp(address);
            var portInt = Convert.ToInt16(port);
            try
            {
                RunServer(addressIp, portInt);
                ListenProcess();
            }
            catch (Exception ex)
            {
                _wbServer.Display("Błąd inicjacki serwera!");
                MessageBox.Show(ex.ToString(), "Błąd");
            }
        }

        private void RunServer(IPAddress addressIp, int port)
        {
            server = new TcpListener(addressIp, port);
            server.Start();
            _wbServer.Display("<b>[Serwer]</b> Rozpoczęto pracę serwera.");
        }

        private void ListenProcess()
        {
            while(ListenCycle())
            {
                ListenCycle();
            }
        }

        private bool ListenCycle()
        {
            if(_serverWorker.CancellationPending)
            {
                SayGoodbye();
                CloseAllConnections();
                server.Stop();
                return false;
            }

            try
            {
                TryConnect();
            }
            catch(SocketException)
            {
            }

            return true;
        }

        private void CloseAllConnections()
        {
            foreach(var connection in _connections)
            {
                connection.Close();
            }
            _connections.Clear();
        }

        private void TryConnect()
        {
            if(server.Pending())
            {
                Connect();
            }
        }

        private void Connect()
        {
            TcpClient client = server.AcceptTcpClient();
            var connection = new Connection(client, _wbServer, this);
            connection.RunConnectionWorker();
            _connections.Add(connection);
            _tbChatInput.Invoke(() => _tbChatInput.Enabled = true);
            _bChatSubmit.Invoke(() => _bChatSubmit.Enabled = true);
        }

        private IPAddress GetAddressIp(string address)
        {
            IPAddress addressIp = null;
            try
            {
                addressIp = IPAddress.Parse(address);
            }
            catch
            {
                MessageBox.Show("Błędny format adresu IP!", "Błąd");
            }
            return addressIp;
        }

        public void PropagateToEveryone(string message)
        {
            foreach(var connection in _connections)
            {
                connection.Send(message);
            }
        }

        public void IfNoneTurnOffChat(Connection connection)
        {
            _connections.Remove(connection);
            if(_connections.Count==0)
            {
                _tbChatInput.Invoke(() => _tbChatInput.Enabled = false);
                _bChatSubmit.Invoke(() => _bChatSubmit.Enabled = false);
            }
        }

        public void CloseServer()
        {
            try
            {
                SayGoodbye();
            }
            catch (IOException) { }
            catch (ObjectDisposedException) { }
            _bStart.Enabled = true;
            _bStop.Enabled = false;
            CloseAllConnections();
            _serverWorker.CancelAsync();
            _wbServer.Display("<b>[Serwer]</b> Zakończono pracę serwera ...");
        }

        private void SayGoodbye()
        {
            PropagateToEveryone("END");
        }

        public void FormClose()
        {
            try
            {
                _serverWorker.CancelAsync();
                CloseAllConnections();
                Environment.Exit(Environment.ExitCode);
            }
            catch (Exception) { }
            
        }

    }
}
