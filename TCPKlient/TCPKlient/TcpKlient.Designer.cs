namespace TCPKlient
{
    partial class TcpKlient
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nUDPort = new System.Windows.Forms.NumericUpDown();
            this.tbHostAddress = new System.Windows.Forms.TextBox();
            this.bwConnection = new System.ComponentModel.BackgroundWorker();
            this.btStop = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.bwSend = new System.ComponentModel.BackgroundWorker();
            this.wbChat = new System.Windows.Forms.WebBrowser();
            this.btUnderline = new System.Windows.Forms.Button();
            this.btItalic = new System.Windows.Forms.Button();
            this.btBold = new System.Windows.Forms.Button();
            this.btLenny = new System.Windows.Forms.Button();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(460, 20);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 63);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // nUDPort
            // 
            this.nUDPort.Location = new System.Drawing.Point(108, 43);
            this.nUDPort.Maximum = new decimal(new int[] {
            65355,
            0,
            0,
            0});
            this.nUDPort.Name = "nUDPort";
            this.nUDPort.Size = new System.Drawing.Size(100, 20);
            this.nUDPort.TabIndex = 3;
            this.nUDPort.Value = new decimal(new int[] {
            65355,
            0,
            0,
            0});
            // 
            // tbHostAddress
            // 
            this.tbHostAddress.Location = new System.Drawing.Point(108, 20);
            this.tbHostAddress.Name = "tbHostAddress";
            this.tbHostAddress.Size = new System.Drawing.Size(100, 20);
            this.tbHostAddress.TabIndex = 4;
            // 
            // bwConnection
            // 
            this.bwConnection.WorkerSupportsCancellation = true;
            this.bwConnection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwConnection_DoWork);
            // 
            // btStop
            // 
            this.btStop.Enabled = false;
            this.btStop.Location = new System.Drawing.Point(553, 20);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 63);
            this.btStop.TabIndex = 6;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Enabled = false;
            this.tbMessage.Location = new System.Drawing.Point(43, 316);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(719, 20);
            this.tbMessage.TabIndex = 8;
            // 
            // btSend
            // 
            this.btSend.Enabled = false;
            this.btSend.Location = new System.Drawing.Point(43, 342);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(719, 32);
            this.btSend.TabIndex = 9;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // bwSend
            // 
            this.bwSend.WorkerSupportsCancellation = true;
            this.bwSend.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSend_DoWork);
            // 
            // wbChat
            // 
            this.wbChat.Location = new System.Drawing.Point(43, 93);
            this.wbChat.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbChat.Name = "wbChat";
            this.wbChat.Size = new System.Drawing.Size(719, 171);
            this.wbChat.TabIndex = 10;
            // 
            // btUnderline
            // 
            this.btUnderline.Enabled = false;
            this.btUnderline.Location = new System.Drawing.Point(286, 287);
            this.btUnderline.Name = "btUnderline";
            this.btUnderline.Size = new System.Drawing.Size(75, 23);
            this.btUnderline.TabIndex = 11;
            this.btUnderline.Text = "Underline";
            this.btUnderline.UseVisualStyleBackColor = true;
            this.btUnderline.Click += new System.EventHandler(this.btUnderline_Click);
            // 
            // btItalic
            // 
            this.btItalic.Enabled = false;
            this.btItalic.Location = new System.Drawing.Point(205, 287);
            this.btItalic.Name = "btItalic";
            this.btItalic.Size = new System.Drawing.Size(75, 23);
            this.btItalic.TabIndex = 12;
            this.btItalic.Text = "Italic";
            this.btItalic.UseVisualStyleBackColor = true;
            this.btItalic.Click += new System.EventHandler(this.btItalic_Click);
            // 
            // btBold
            // 
            this.btBold.Enabled = false;
            this.btBold.Location = new System.Drawing.Point(124, 287);
            this.btBold.Name = "btBold";
            this.btBold.Size = new System.Drawing.Size(75, 23);
            this.btBold.TabIndex = 13;
            this.btBold.Text = "Bold";
            this.btBold.UseVisualStyleBackColor = true;
            this.btBold.Click += new System.EventHandler(this.btBold_Click);
            // 
            // btLenny
            // 
            this.btLenny.Enabled = false;
            this.btLenny.Location = new System.Drawing.Point(43, 287);
            this.btLenny.Name = "btLenny";
            this.btLenny.Size = new System.Drawing.Size(75, 23);
            this.btLenny.TabIndex = 14;
            this.btLenny.Text = "( ͡° ͜ʖ ͡°)";
            this.btLenny.UseVisualStyleBackColor = true;
            this.btLenny.Click += new System.EventHandler(this.btLenny_Click);
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(108, 67);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(100, 20);
            this.tbUsername.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Username";
            // 
            // TcpKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(785, 386);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.btLenny);
            this.Controls.Add(this.btBold);
            this.Controls.Add(this.btItalic);
            this.Controls.Add(this.btUnderline);
            this.Controls.Add(this.wbChat);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.tbHostAddress);
            this.Controls.Add(this.nUDPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btConnect);
            this.Name = "TcpKlient";
            this.Text = "Tcp Klient";
            ((System.ComponentModel.ISupportInitialize)(this.nUDPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nUDPort;
        private System.Windows.Forms.TextBox tbHostAddress;
        private System.ComponentModel.BackgroundWorker bwConnection;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btSend;
        private System.ComponentModel.BackgroundWorker bwSend;
        private System.Windows.Forms.WebBrowser wbChat;
        private System.Windows.Forms.Button btUnderline;
        private System.Windows.Forms.Button btItalic;
        private System.Windows.Forms.Button btBold;
        private System.Windows.Forms.Button btLenny;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label3;
    }
}

