using RabbitMQ.Client;
using EDevlet.Document.Common;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;

namespace EDevlet.Document.Request
{
    public partial class Form1 : Form
    {
        IConnection connection;
        private readonly string createDocument = "create_document_queue";
        private readonly string documentCreated = "document_created_queue";
        private readonly string documentCreateExchange = "document_create_exchange";

        IModel _channel;
        IModel channel => _channel ?? (_channel = GetChannel());

       

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (connection == null || !connection.IsOpen)
                connection = GetConnection();

            btnCreateDocument.Enabled = true;

            channel.ExchangeDeclare(documentCreateExchange, "direct");

            channel.QueueDeclare(createDocument, false, false, false);
            channel.QueueBind(createDocument, documentCreateExchange, createDocument);

            channel.QueueDeclare(documentCreated, false, false, false);
            channel.QueueBind(documentCreated, documentCreateExchange, documentCreated);

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

        private void btnCreateDocument_Click(object sender, EventArgs e)
        {
            var model = new CreateDocumentModel()
            {
                UserId = 1,
                DocumentType = DocumentType.Document,
            };

            WriteQueue(createDocument, model);

            frmSplash frmSplash = new frmSplash();
            frmSplash.Show();

            var consumerEvent = new EventingBasicConsumer(channel);

            consumerEvent.Received += (ch, ea) =>
            {
                var modelReceived = JsonConvert.DeserializeObject<CreateDocumentModel>(Encoding.UTF8.GetString(ea.Body.ToArray()));

                AddLog($"Received Data Url: {modelReceived.Url}");

                closeSplashScreen(frmSplash);
            };


            channel.BasicConsume(documentCreated, true, consumerEvent);

        }

        private void WriteQueue(string queueName, CreateDocumentModel model)
        {
             var messageArr = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

            channel.BasicPublish(documentCreateExchange, queueName, null, messageArr);

            AddLog("Message Published.");

           
        }

        private void closeSplashScreen(frmSplash frmSplash)
        {
            if (frmSplash.InvokeRequired)
            {
                frmSplash.Invoke(new Action(() => closeSplashScreen(frmSplash)));
                return;
            }

            frmSplash.Close();
        }

        private IModel GetChannel()
        {
            return connection.CreateModel();
        }
    }
}
