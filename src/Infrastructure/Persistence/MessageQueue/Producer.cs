using Application.Services;
using Domain.ValueObjects;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Infrastructure.Persistence.MessageQueue;

public class Producer : IMessageQueueService
{
    private const string _queueConnectionString = "amqp://guest:guest@localhost:5672";

    public Producer()
    {
        var factory = new ConnectionFactory
        {
            Uri = new Uri(_queueConnectionString)
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(
               KitchenArea.Desert.ToString(),
               durable: true,
               exclusive: false,
               autoDelete: false,
            arguments: null
        );
        channel.QueueDeclare(
           KitchenArea.Drink.ToString(),
           durable: true,
           exclusive: false,
           autoDelete: false,
           arguments: null
       );
        channel.QueueDeclare(
           KitchenArea.Fries.ToString(),
           durable: true,
           exclusive: false,
           autoDelete: false,
           arguments: null
       );
        channel.QueueDeclare(
           KitchenArea.Grill.ToString(),
           durable: true,
           exclusive: false,
           autoDelete: false,
           arguments: null
       );
        channel.QueueDeclare(
           KitchenArea.Salad.ToString(),
           durable: true,
           exclusive: false,
           autoDelete: false,
           arguments: null
       );
    }

    public void PublishOrderCreatedMessage(object message, string queueName)
    {
        var factory = new ConnectionFactory
        {
            Uri = new Uri(_queueConnectionString)
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
        channel.BasicPublish(string.Empty, queueName, null, body);
    }
}