using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};

using var connection = factory.CreateConnection();  // Corrected: Use CreateConnection() directly
using var channel = connection.CreateModel();

channel.QueueDeclare("demo-queue",
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null);  // Corrected: Removed invalid parameter

var message = new { Name = "Producer", Message = "Hello!" };
var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

channel.BasicPublish("", "demo-queue", null, body);

Console.WriteLine("Message published to queue.");
