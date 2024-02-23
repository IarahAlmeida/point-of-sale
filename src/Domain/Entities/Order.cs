using Domain.Common;

namespace Domain.Entities;

public class Order : BaseEntity
{
    public bool IsCompleted { get; set; }
    public IEnumerable<OrderItem> Items { get; set; } = new List<OrderItem>();
}