using Microsoft.AspNetCore.Mvc;

[Route("/[controller]")]
[ApiController]
public class ProductController : ControllerBase 
{
    private readonly DatabaseContext context;

    public ProductController(DatabaseContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProduct()
    {
        return this.context.Product.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = this.context.Product.Find(id);

        if(product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
        if (product == null)
        {
            return BadRequest();
        }
        this.context.Product.Add(product);
        this.context.SaveChanges();

        return CreatedAtAction(nameof(GetProduct), new {id = product.ProductId}, product);
    }

    [HttpDelete("{id}")]
    public ActionResult<Product> DeleteProduct(int id)
    {
        var product = this.context.Product.Find(id);

        if(product == null)
        {
            return NotFound();
        }

        this.context.Product.Remove(product);
        this.context.SaveChanges();

        return product;
    }
}