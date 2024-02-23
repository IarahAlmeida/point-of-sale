namespace Application.ViewModels;

public class OrderItemViewModel
{
    public bool IsCompleted { get; set; }
    public string KitchenAreaName { get; set; } = null!;
    public string Name { get; set; } = null!;
}