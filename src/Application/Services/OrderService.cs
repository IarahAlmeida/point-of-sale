using Application.InputModels;
using Application.ViewModels;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class OrderService(IOrderRepository orderRepository, IMessageQueueService messageQueueService) : IOrderService
{
    private readonly IMessageQueueService _messageQueueService = messageQueueService;
    private readonly IOrderRepository _orderRepository = orderRepository;

    public Task<int> Create(OrderInputModel inputModel)
    {
        var order = new Order
        {
            Items = inputModel.Items.Select(x => new OrderItem(x.Amount, x.KitchenAreaName, x.Name)).ToList(),
        };
        var id = _orderRepository.Create(order);
        foreach (var item in order.Items)
        {
            _messageQueueService.PublishOrderCreatedMessage(item, item.KitchenArea.ToString());
        }
        return id;
    }

    public async Task<OrderViewModel?> GetById(int id)
    {
        var order = await _orderRepository.GetById(id);
        if (order == null)
        {
            return null;
        }
        else
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                IsCompleted = order.IsCompleted,
                Items = order.Items.Select(x => new OrderItemViewModel()
                {
                    IsCompleted = x.IsCompleted,
                    KitchenAreaName = x.KitchenArea.ToString(),
                    Name = x.Name
                }).ToList(),
            };
        }
    }
}