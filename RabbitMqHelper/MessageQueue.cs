using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace RabbitMqHelper
{
    public class MessageQueue : IDisposable
    {
        /*
        private readonly ConnectionFactory factory;
        public MessageQueue(string url, string providerName, string exchangeName, string queueName, string routingKey)
        {
            factory = new ConnectionFactory();
            factory.Uri = new Uri(url);
            factory.ClientProvidedName = providerName;
        }
        
        public async Task AddMessageToQueue(string message, string exchangeName, string queueName, string routeKey)
        {
            IConnection con = await factory.CreateConnectionAsync();
            var channel = await con.CreateChannelAsync();
            await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct);
            await channel.QueueDeclareAsync(queueName);
            await channel.QueueBindAsync(queueName, exchangeName, routeKey);
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(message);
            await channel.BasicPublishAsync(exchangeName, routeKey, messageBodyBytes);
            await channel.CloseAsync();
            await con.CloseAsync();
            channel.Dispose();
            con.Dispose();
        }
        */

        private readonly ConnectionFactory factory;
        private IConnection connection = null!;
        private IChannel channel = null!;

        public MessageQueue(string url, string providerName)
        {
            factory = new ConnectionFactory
            {
                Uri = new Uri(url),
                ClientProvidedName = providerName
            };
        }

        public async Task InitializeAsync()
        {
            connection = await Task.Run(() => factory.CreateConnectionAsync());
            channel = await Task.Run(() => connection.CreateChannelAsync());
        }

        public async Task AddMessageToQueueAsync<T>(T messageObject, string exchangeName, string queueName, string routeKey)
        {
            if (channel == null)
            {
                throw new InvalidOperationException("Channel has not been initialized. Call InitializeAsync() first.");
            }

            // Declare exchange and queue
            await channel.ExchangeDeclareAsync(exchange: exchangeName, type: ExchangeType.Direct, durable: true, autoDelete: false);
            await channel.QueueDeclareAsync(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            await channel.QueueBindAsync(queue: queueName, exchange: exchangeName, routingKey: routeKey);

            string message = JsonSerializer.Serialize(messageObject);
            var messageBodyBytes = Encoding.UTF8.GetBytes(message);

            // Publish message
            await channel.BasicPublishAsync(exchange: exchangeName, routingKey: routeKey, body: messageBodyBytes);
        }

        public void Dispose()
        {
            if (channel != null)
            {
                channel.CloseAsync();
                channel.Dispose();
            }
            if (connection != null)
            {
                connection.CloseAsync();
                connection.Dispose();
            }
        }
    }
}
