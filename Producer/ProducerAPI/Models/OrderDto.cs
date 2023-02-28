namespace ProducerAPI.Models;

public class OrderDto
{
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}