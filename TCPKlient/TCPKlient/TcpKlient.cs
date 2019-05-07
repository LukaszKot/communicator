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
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            bwConnection.RunWorkerAsync();
            btStop.Enabled = true;
            btConnect.Enabled = false;
            tbMessage.Enabled = true;
            btSend.Enabled = true;
            btBold.Enabled = true;
            btItalic.Enabled = true;
            btUnderline.Enabled = true;
        }

        private TcpClient client = null;
        private BinaryReader reading = null;
        private BinaryWriter writing = null;
        private bool activeCall = false;

        private void bwConnection_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string host = tbHostAddress.Text;
            int port = System.Convert.ToInt16(nUDPort.Value);
            try
            {
                client = new TcpClient(host, port);
                lbMessage.Invoke(new MethodInvoker(delegate { lbMessage.Items.Add("Nawiązano połączenie z " + host + " na porcie: " + port); }));
                try
                {
                    NetworkStream ns = client.GetStream();
                    reading = new BinaryReader(ns);
                    writing = new BinaryWriter(ns);
                    writing.Write("password");
                    activeCall = true;
                    bwSend.RunWorkerAsync();
                }
                catch
                {
                    activeCall = false;
                }
            }
            catch (Exception ex)
            {
                lbMessage.Invoke(new MethodInvoker(delegate { lbMessage.Items.Add("Błąd: Nie udało się nawiązać połaczenia!"); }));
                MessageBox.Show(ex.ToString());
                tbMessage.Invoke(new MethodInvoker(delegate { tbMessage.Enabled = false; }));
                btSend.Invoke(new MethodInvoker(delegate { btSend.Enabled = false; }));
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            btStop.Enabled = false;
            btConnect.Enabled = true;
            bwConnection.CancelAsync();
            bwSend.CancelAsync();
            client.Close();
            lbMessage.Invoke(new MethodInvoker(delegate { lbMessage.Items.Add("Przerwano połącznie"); }));
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            string messageSent = tbMessage.Text;
            wbChat.Invoke(new MethodInvoker(delegate { wbChat.DocumentText += ("Ty: " + messageSent + "</br>"); }));
            writing.Write(messageSent);
            tbMessage.Text = "";
        }

        private void bwSend_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                string messageRecived;
                while ((messageRecived = reading.ReadString()) != "END")
                {
                    wbChat.Invoke(new MethodInvoker(delegate { wbChat.DocumentText += ("Kolega: "+messageRecived + "</br>"); }));
                }
                
            }catch(IOException)
            {

            }
            client.Close();
            btStop.Invoke(new MethodInvoker(delegate { btStop.Enabled = false; }));
            btConnect.Invoke(new MethodInvoker(delegate { btConnect.Enabled = true; }));
            tbMessage.Invoke(new MethodInvoker(delegate { tbMessage.Enabled = false; }));
            btSend.Invoke(new MethodInvoker(delegate { btSend.Enabled = false; }));
            btBold.Invoke(new MethodInvoker(delegate { btBold.Enabled = false; }));
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


        //nazwa.runworkerasync
        //nazwa.canselasync         wymaga true dla własności worker support canselation
    }
}
