using Microsoft.AspNetCore.Mvc;
using MyShop.Server.DB;
using MyShop.Shared;

namespace MyShop.Server.Controllers;
public class ProductsController : Controller
{
    private readonly ProductsDBContext _dbContext;
    public ProductsController(ProductsDBContext ctx)
    {
        _dbContext = ctx;
    }

    [HttpGet]
    [Route("Products/Categories")]
    public IEnumerable<Category> Categories()
    {
        return _dbContext.Categories;
    }
    [HttpGet]
    [Route("Products/ProductsByCategory/{Id}")]
    public IEnumerable<Product> ProductsByCategory(string Id)
    {
        return _dbContext.Products.Where(p => p.Category.Id == int.Parse(Id));
    }
    [HttpGet]
    [Route("Products/OneProduct/{Id}")]
    public Product? OneProduct(string Id)
    {
        if (int.TryParse(Id, out int id))
            return _dbContext.Products.First(p => p.Id == id);
        return null;
    }
    [HttpGet]
    [Route("Products/AllProducts")]
    public IEnumerable<Product> AllProducts()
    {
        return _dbContext.Products;
    }

    [HttpPost]
    [Route("Products/AddProduct")]
    public void AddProduct([FromBody] Product p)
    {
        p.Category = _dbContext.Categories.First(x => x.Id == p.Category.Id);
        _dbContext.Products.Add(p);
        _dbContext.SaveChanges();
    }

    [HttpPost]
    [Route("Products/AddCategory")]
    public void AddCategory([FromBody] Category c)
    {
        _dbContext.Categories.Add(c);
        _dbContext.SaveChanges();
    }
}

