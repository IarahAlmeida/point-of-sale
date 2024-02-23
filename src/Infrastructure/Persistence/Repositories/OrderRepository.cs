using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = [];
    private int lastId = 0;

    public Task<int> Create(Order order)
    {
        order.Id = ++lastId;
        _orders.Add(order);
        return Task.FromResult(order.Id);
    }

    public Task<Order?> GetById(int id)
    {
        var order = _orders.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(order);
    }
}