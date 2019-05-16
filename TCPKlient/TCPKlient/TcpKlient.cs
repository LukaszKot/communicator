using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TCPKlient
{
    public partial class TcpKlient : Form
    {
        public TcpKlient()
        {
            InitializeComponent();
            wbChat.DocumentCompleted += wbChat_DocumentCompleted;
        }

        private void wbChat_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            wbChat.Document.Window.ScrollTo(0, wbChat.Document.Body.ScrollRectangle.Height);
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "") return;
            bwConnection.RunWorkerAsync();
            btStop.Enabled = true;
            btConnect.Enabled = false;
            tbMessage.Enabled = true;
            btSend.Enabled = true;
            btBold.Enabled = true;
            btLenny.Enabled = true;
            btItalic.Enabled = true;
            btUnderline.Enabled = true;
            tbUsername.Enabled = false;
        }

        private TcpClient client = null;
        private BinaryReader reading = null;
        private BinaryWriter writing = null;

        private void bwConnection_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string host = tbHostAddress.Text;
            int port = System.Convert.ToInt16(nUDPort.Value);
            try
            {
                client = new TcpClient(host, port);
                wbChat.Invoke(new MethodInvoker(delegate { wbChat.DocumentText += ("Nawiązano połączenie z serwerem!<br /><hr />"); }));
                try
                {
                    NetworkStream ns = client.GetStream();
                    reading = new BinaryReader(ns);
                    writing = new BinaryWriter(ns);
                    bwSend.RunWorkerAsync();
                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                wbChat.Invoke(new MethodInvoker(delegate { wbChat.DocumentText += ("Błąd: Nie udało się nawiązać połaczenia!" + "<br /><hr />"); }));
                MessageBox.Show(ex.ToString());
                tbMessage.Invoke(new MethodInvoker(delegate { tbMessage.Enabled = false; }));
                btSend.Invoke(new MethodInvoker(delegate { btSend.Enabled = false; }));
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            btStop.Enabled = false;
            btConnect.Enabled = true;
            tbUsername.Enabled = true;
            bwConnection.CancelAsync();
            bwSend.CancelAsync();
            if(client!=null)client.Close();
            wbChat.Invoke(new MethodInvoker(delegate { wbChat.DocumentText += ("Przerwano połącznie z serwerem!" + "<br /><hr />"); }));
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbMessage.Text)) return;
            if (tbMessage.Text.Length >= 7 &&  tbMessage.Text[0] == '<' && tbMessage.Text[2] == '>' && tbMessage.Text[3] == '<' && tbMessage.Text[6] == '>') return;
            string messageSent = tbMessage.Text;
            writing.Write("<b>"+tbUsername.Text+"</b>: "+messageSent);
            tbMessage.Text = "";
        }

        private void bwSend_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                string messageRecived;
                while ((messageRecived = reading.ReadString()) != "END")
                {
                    wbChat.Invoke(new MethodInvoker(delegate { wbChat.DocumentText += (messageRecived + "<br /><hr />"); }));
                }
                
            }catch(IOException)
            {

            }
            client.Close();
            btStop.Invoke(new MethodInvoker(delegate { btStop.Enabled = false; }));
            tbUsername.Invoke(new MethodInvoker(delegate { tbUsername.Enabled = true; }));
            btConnect.Invoke(new MethodInvoker(delegate { btConnect.Enabled = true; }));
            tbMessage.Invoke(new MethodInvoker(delegate { tbMessage.Enabled = false; }));
            btSend.Invoke(new MethodInvoker(delegate { btSend.Enabled = false; }));
            btBold.Invoke(new MethodInvoker(delegate { btBold.Enabled = false; }));
            btLenny.Invoke(new MethodInvoker(delegate { btLenny.Enabled = false; }));
            btItalic.Invoke(new MethodInvoker(delegate { btItalic.Enabled = false; }));
            btUnderline.Invoke(new MethodInvoker(delegate { btUnderline.Enabled = false; }));
        }

        private void btBold_Click(object sender, EventArgs e)
        {
            tbMessage.Invoke(new MethodInvoker(delegate { tbMessage.Text +="<b>"+"</b>" ; }));
        }

        private void btItalic_Click(object sender, EventArgs e)
        {
            tbMessage.Invoke(new MethodInvoker(delegate { tbMessage.Text += "<i>" + "</i>"; }));
        }

        private void btUnderline_Click(object sender, EventArgs e)
        {
            tbMessage.Invoke(new MethodInvoker(delegate { tbMessage.Text += "<u>" + "</u>"; }));
        }

        private void btLenny_Click(object sender, EventArgs e)
        {
            tbMessage.Invoke(new MethodInvoker(delegate { tbMessage.Text += "( ͡° ͜ʖ ͡°)"; }));
        }
    }
}
