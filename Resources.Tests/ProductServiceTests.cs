using Resources.Enums;
using Resources.Models;
using Resources.Services;

namespace Resources.Tests;

public class ProductServiceTests
{
    [Fact]
    public void AddToList_ShouldReturnSuccess_WhenProductIsAddedToList()
    {
        
        Product product = new Product { ProductName = "Test perfume", ProductPrice = "100", ProductDescription = "White flower, Vanilla" };
        ProductService productService = new ProductService();
 
        
        ResultStatus result = productService.AddToList(product);
        var productList = productService.GetAllProducts();

        
        Assert.Equal(ResultStatus.Success, result);
        Assert.Single(productList);
    }
}
