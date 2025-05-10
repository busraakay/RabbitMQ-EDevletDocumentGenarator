namespace EDevlet.Document.Request
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtConnectionString = new TextBox();
            btnConnect = new Button();
            btnCreateDocument = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            txtLog = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 41);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 0;
            label1.Text = "Connection String";
            label1.Click += label1_Click;
            // 
            // txtConnectionString
            // 
            txtConnectionString.Location = new Point(154, 38);
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.Size = new Size(265, 23);
            txtConnectionString.TabIndex = 1;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(441, 37);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnCreateDocument
            // 
            btnCreateDocument.Enabled = false;
            btnCreateDocument.Location = new Point(190, 97);
            btnCreateDocument.Name = "btnCreateDocument";
            btnCreateDocument.Size = new Size(192, 92);
            btnCreateDocument.TabIndex = 3;
            btnCreateDocument.Text = "Create Document";
            btnCreateDocument.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // txtLog
            // 
            txtLog.Location = new Point(96, 221);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(375, 229);
            txtLog.TabIndex = 4;
            txtLog.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 450);
            Controls.Add(txtLog);
            Controls.Add(btnCreateDocument);
            Controls.Add(btnConnect);
            Controls.Add(txtConnectionString);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtConnectionString;
        private Button btnConnect;
        private Button btnCreateDocument;
        private ContextMenuStrip contextMenuStrip1;
        private RichTextBox txtLog;
    }
}
