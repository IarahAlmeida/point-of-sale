using Domain.ValueObjects;

namespace Domain.Entities;

public class OrderItem
{
    public OrderItem(int amount, string kitchenAreaName, string name)
    {
        Amount = amount;
        KitchenArea = KitchenArea.From(kitchenAreaName);
        Name = name;
    }

    protected OrderItem()
    { }

    public int Amount { get; set; }
    public bool IsCompleted { get; set; }
    public KitchenArea KitchenArea { get; set; } = null!;
    public string Name { get; set; } = null!;
}