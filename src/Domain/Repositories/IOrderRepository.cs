using Domain.Entities;

namespace Domain.Repositories;

public interface IOrderRepository
{
    Task<int> Create(Order order);

    Task<Order?> GetById(int id);
}