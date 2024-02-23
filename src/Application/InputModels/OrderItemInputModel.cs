namespace Application.InputModels;

public class OrderItemInputModel
{
    public int Amount { get; set; }
    public string KitchenAreaName { get; set; } = null!;
    public string Name { get; set; } = null!;
}