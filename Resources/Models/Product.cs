namespace Resources.Models;

public class Product 
{
    public string Id { get; set; } = Guid.NewGuid().ToString(); 
    public string ProductName { get; set; } = null!; 
    public string ProductDescription { get; set; } = null!; 
    public string ProductSize { get; set; } = null!;  
    public string ProductPrice { get; set; } = null!; 
}
