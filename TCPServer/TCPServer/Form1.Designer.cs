namespace TCPServer
{
    partial class MainWindow
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
            this.lAddress = new System.Windows.Forms.Label();
            this.tAddress = new System.Windows.Forms.TextBox();
            this.lPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lbServer = new System.Windows.Forms.ListBox();
            this.bStart = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.bwConnection = new System.ComponentModel.BackgroundWorker();
            this.tbChatInput = new System.Windows.Forms.TextBox();
            this.bChatSubmit = new System.Windows.Forms.Button();
            this.bwMessages = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // lAddress
            // 
            this.lAddress.AutoSize = true;
            this.lAddress.Location = new System.Drawing.Point(25, 24);
            this.lAddress.Name = "lAddress";
            this.lAddress.Size = new System.Drawing.Size(45, 13);
            this.lAddress.TabIndex = 0;
            this.lAddress.Text = "Address";
            // 
            // tAddress
            // 
            this.tAddress.Location = new System.Drawing.Point(76, 21);
            this.tAddress.Name = "tAddress";
            this.tAddress.Size = new System.Drawing.Size(100, 20);
            this.tAddress.TabIndex = 1;
            // 
            // lPort
            // 
            this.lPort.AutoSize = true;
            this.lPort.Location = new System.Drawing.Point(579, 24);
            this.lPort.Name = "lPort";
            this.lPort.Size = new System.Drawing.Size(26, 13);
            this.lPort.TabIndex = 2;
            this.lPort.Text = "Port";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(620, 21);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(120, 20);
            this.numPort.TabIndex = 3;
            this.numPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbServer
            // 
            this.lbServer.FormattingEnabled = true;
            this.lbServer.Location = new System.Drawing.Point(28, 67);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(533, 173);
            this.lbServer.TabIndex = 4;
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(586, 76);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 5;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bStop
            // 
            this.bStop.Enabled = false;
            this.bStop.Location = new System.Drawing.Point(667, 76);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 6;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bwConnection
            // 
            this.bwConnection.WorkerSupportsCancellation = true;
            this.bwConnection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwConnection_DoWork);
            // 
            // tbChatInput
            // 
            this.tbChatInput.Enabled = false;
            this.tbChatInput.Location = new System.Drawing.Point(28, 253);
            this.tbChatInput.Name = "tbChatInput";
            this.tbChatInput.Size = new System.Drawing.Size(533, 20);
            this.tbChatInput.TabIndex = 8;
            // 
            // bChatSubmit
            // 
            this.bChatSubmit.Enabled = false;
            this.bChatSubmit.Location = new System.Drawing.Point(28, 280);
            this.bChatSubmit.Name = "bChatSubmit";
            this.bChatSubmit.Size = new System.Drawing.Size(533, 61);
            this.bChatSubmit.TabIndex = 9;
            this.bChatSubmit.Text = "Send";
            this.bChatSubmit.UseVisualStyleBackColor = true;
            this.bChatSubmit.Click += new System.EventHandler(this.bChatSubmit_Click);
            // 
            // bwMessages
            // 
            this.bwMessages.WorkerSupportsCancellation = true;
            this.bwMessages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwMessages_DoWork);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bChatSubmit);
            this.Controls.Add(this.tbChatInput);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.lPort);
            this.Controls.Add(this.tAddress);
            this.Controls.Add(this.lAddress);
            this.Name = "MainWindow";
            this.Text = "Tcp Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lAddress;
        private System.Windows.Forms.TextBox tAddress;
        private System.Windows.Forms.Label lPort;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.ListBox lbServer;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bStop;
        private System.ComponentModel.BackgroundWorker bwConnection;
        private System.Windows.Forms.TextBox tbChatInput;
        private System.Windows.Forms.Button bChatSubmit;
        private System.ComponentModel.BackgroundWorker bwMessages;
    }
}

