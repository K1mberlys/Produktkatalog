using Newtonsoft.Json;
using Resources.Enums;
using Resources.Models;

namespace Resources.Services;

public class ProductService 
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "file.json"); 
    private readonly FileService _fileService = new FileService(_filePath); 
    private List<Product> _productList = new List<Product>(); 
    
    public ResultStatus AddToList(Product product)
    {
        try
        {
            GetProductsFromFile(); 

            if (_productList.Any(x => x.ProductName == product.ProductName)) 
            return ResultStatus.Exists; 


            _productList.Add(product); 

            var json = JsonConvert.SerializeObject(_productList, Formatting.Indented); 
            var result = _fileService.SaveToFile(json);
            if(result)
                return ResultStatus.Success;

            return ResultStatus.FinishedWithErrors;
            
        }
        catch 
        {
            return ResultStatus.Failed;
        }
    }

    public IEnumerable<Product> GetAllProducts() 
    {
        GetProductsFromFile(); 
        return _productList;
    }

    public Product GetProduct(string productName)
    {
        GetProductsFromFile(); 
        try
        {
            var product = _productList.FirstOrDefault(x => x.ProductName == productName); 
            return product ?? null!;
        }
        catch 
        {
            return null!;
        }
    }

    public void GetProductsFromFile()
    {
        try
        {
            var content = _fileService.GetromFile();

            if (!string.IsNullOrEmpty(content))
                _productList = JsonConvert.DeserializeObject<List<Product>>(content)!; 
        }
        catch { }

    }

    public ResultStatus DeleteProduct(string productName)
    {
        try
        {
            GetProductsFromFile();
            var product = GetProduct(productName);

            if (product == null)
                return ResultStatus.NotFound;

            _productList.Remove(product);

            var json = JsonConvert.SerializeObject(_productList, Formatting.Indented); 
            var result = _fileService.SaveToFile(json); 
            if (result)
                return ResultStatus.Success;

            return ResultStatus.FinishedWithErrors;
        }
        catch 
        {
            return ResultStatus.Failed;
        }
    }
}
