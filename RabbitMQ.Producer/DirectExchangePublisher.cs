﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ.Producer
{
    public static  class DirectExchangePublisher
    {
        public static void Publish(IModel channel)
        {
            var ttl = new Dictionary<string, object>
            {
                {"x-message-ttl", 3000}
            };
            channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct, arguments: ttl);
            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = $"Hello! Count : {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("", "demo-queue", null, body);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
