using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Newtonsoft.Json;
using TCPServer.Infrastructure;

namespace TCPServer
{
    public partial class MainWindow : Form
    {
        private TcpListener server;
        private TcpClient client;
        private BinaryReader reading = null;
        private BinaryWriter writing = null;
        private IPEndPoint ip = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            IPAddress addressIp = null;
            try
            {
                addressIp = IPAddress.Parse(tAddress.Text);
            }
            catch
            {
                MessageBox.Show("Błędny format adresu IP!", "Błąd");

                tAddress.Text = String.Empty;
                return;
            }
            bwConnection.RunWorkerAsync();
            bStart.Enabled = false;
            bStop.Enabled = true;
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            try
            {
                if(writing!=null)
                    writing.Write("END");
            }
            catch (IOException) { }
            catch (ObjectDisposedException) { }
            bStart.Enabled = true;
            bStop.Enabled = false;
            bwConnection.CancelAsync();
            bwMessages.CancelAsync();
            
            lbServer.Items.Add("[Serwer] Zakończono pracę serwera ...");
            lbServer.Invoke(new MethodInvoker(delegate { GoToBottom(lbServer); }));

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void bwConnection_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IPAddress addressIp = null;
            try
            {
                addressIp = IPAddress.Parse(tAddress.Text);
            }
            catch
            {
                MessageBox.Show("Błędny format adresu IP!", "Błąd");
                
                tAddress.Invoke(new MethodInvoker(delegate { tAddress.Text = String.Empty; }));
                return;
            }

            int port = Convert.ToInt16(numPort.Value);

            try
            {
                server = new TcpListener(addressIp, port);
                server.Start();
                lbServer.Invoke(new MethodInvoker(delegate { lbServer.Items.Add($"[Serwer] Rozpoczęto pracę serwera."); }));
                lbServer.Invoke(new MethodInvoker(delegate { GoToBottom(lbServer); }));
                while (true)
                {
                    if(bwConnection.CancellationPending)
                    {
                        server.Stop();
                        if (client != null) client.Close();
                        return;
                    }
                    try
                    {
                        if(server.Pending())
                        {
                            client = server.AcceptTcpClient();
                            var communication = new Communication(client);
                            NetworkStream ns = client.GetStream();

                            writing = new BinaryWriter(ns);
                            reading = new BinaryReader(ns);
                            string odczyt = reading.ReadString();
                            if (odczyt == "password")
                            {
                                ip = (IPEndPoint)client.Client.RemoteEndPoint;
                                lbServer.Invoke(new MethodInvoker(delegate { lbServer.Items.Add($"[{ip.ToString()}]: Nawiązano połączenie"); }));
                                lbServer.Invoke(new MethodInvoker(delegate { GoToBottom(lbServer); }));
                                bwMessages.RunWorkerAsync();
                                tbChatInput.Invoke(new MethodInvoker(delegate { tbChatInput.Enabled = true; }));
                                bChatSubmit.Invoke(new MethodInvoker(delegate { bChatSubmit.Enabled = true; }));
                            }
                        }
                    }
                    catch (SocketException)
                    {
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                lbServer.Invoke(new MethodInvoker(delegate { lbServer.Items.Add("Błąd inicjacji serwera!"); }));
                MessageBox.Show(ex.ToString(), "Błąd");
            }
        }

        private void bwMessages_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                string message;
                while ((message = reading.ReadString()) != "END")
                {
                    lbServer.Invoke(new MethodInvoker(delegate { lbServer.Items.Add("Kolega: " + message); }));
                    lbServer.Invoke(new MethodInvoker(delegate { GoToBottom(lbServer); }));
                }
            }
            catch (IOException)
            {
            }
            try
            {
                lbServer.Invoke(new MethodInvoker(delegate { lbServer.Items.Add($"[{ip.ToString()}]: Zakończono połączenie"); }));
                lbServer.Invoke(new MethodInvoker(delegate { GoToBottom(lbServer); }));
            }
            catch { }
            
            bwMessages.CancelAsync();
            if (bwMessages.CancellationPending)
            {
                if(client!=null)client.Close();
                try
                {
                    tbChatInput.Invoke(new MethodInvoker(delegate { tbChatInput.Enabled = false; }));
                    bChatSubmit.Invoke(new MethodInvoker(delegate { bChatSubmit.Enabled = false; }));
                }
                catch { }
                
                return;
            }

        }

        private void bChatSubmit_Click(object sender, EventArgs e)
        {
            string messageSent = tbChatInput.Text;
            if(messageSent!=string.Empty)
            {
                lbServer.Items.Add($"You: {messageSent}");
                GoToBottom(lbServer);
                writing.Write(messageSent);
                tbChatInput.Text = "";
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            bwMessages.CancelAsync();
            bwConnection.CancelAsync();
            try
            {
                Environment.Exit(Environment.ExitCode);
            }
            catch { }
            
        }

        private void GoToBottom(ListBox listBox)
        {
            listBox.TopIndex = listBox.Items.Count - 1;
        }
    }
}
