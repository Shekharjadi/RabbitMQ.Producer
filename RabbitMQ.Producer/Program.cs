using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Producer;
using System.Text;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};

using var connection = factory.CreateConnection();  // Corrected: Use CreateConnection() directly
using var channel = connection.CreateModel();
DirectExchangePublisher.Publish(channel);
