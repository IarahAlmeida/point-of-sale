using Application.InputModels;
using Application.ViewModels;

namespace Application.Services;

public interface IOrderService
{
    Task<int> Create(OrderInputModel inputModel);

    Task<OrderViewModel?> GetById(int id);
}