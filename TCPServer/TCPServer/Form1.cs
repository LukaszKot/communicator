using System;
using System.Windows.Forms;
using TCPServer.Extensions;
using TCPServer.Services;

namespace TCPServer
{
    public partial class MainWindow : Form
    {
        private TcpServerService _tcpServerService;
        public MainWindow()
        {
            InitializeComponent();
            _tcpServerService = new TcpServerService(bwConnection, bStart, bStop, wbServer, tbChatInput, bChatSubmit);
        }

        private void bStart_Click(object sender, EventArgs e)
            =>  _tcpServerService.RunServer(tAddress.Text);

        private void bStop_Click(object sender, EventArgs e)
            => _tcpServerService.CloseServer();


        private void bwConnection_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
            => _tcpServerService.Listen(tAddress.Text, numPort.Value);

        private void bChatSubmit_Click(object sender, EventArgs e)
        {
            if(tbChatInput.Text.Length>=7 && tbChatInput.Text[0]=='<' && tbChatInput.Text[2] == '>' && tbChatInput.Text[3] == '<'&& tbChatInput.Text[6] == '>') return;
            string messageSent = tbChatInput.Text;
            if(messageSent!=string.Empty)
            {
                string theMessage = $"<b>Serwer</b>: {messageSent}";
                wbServer.Display(theMessage);
                _tcpServerService.PropagateToEveryone(theMessage);
            }
            tbChatInput.Text = "";
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
            => _tcpServerService.FormClose();

    }
}
