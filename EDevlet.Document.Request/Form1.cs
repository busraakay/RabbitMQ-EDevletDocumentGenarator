using RabbitMQ.Client;

namespace EDevlet.Document.Request
{
    public partial class Form1 : Form
    {
        IConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(connection == null ||     !connection.IsOpen) 
                connection = GetConnection();

            btnCreateDocument.Enabled = true;

            AddLog("Connection is open now.");

            //amqp://guest:guest@localhost:5672
        }

        private IConnection GetConnection()
        {
            var connectitonFactory = new ConnectionFactory()
            {
                Uri = new Uri(txtConnectionString.Text)
            };

            return connectitonFactory.CreateConnection();
        }
        private void AddLog(string logStr)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => AddLog(logStr)));
                return;
            }

            logStr = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] - {logStr}";
            txtLog.AppendText($"{logStr}\n");


            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }
    }
}
