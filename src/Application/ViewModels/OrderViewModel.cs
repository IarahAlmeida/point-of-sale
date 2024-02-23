namespace Application.ViewModels;

public class OrderViewModel
{
    public int Id { get; set; }
    public bool IsCompleted { get; set; }
    public List<OrderItemViewModel> Items { get; set; } = [];
}