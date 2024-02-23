namespace Application.Services;

public interface IMessageQueueService
{
    void PublishOrderCreatedMessage(object message, string queueName);
}