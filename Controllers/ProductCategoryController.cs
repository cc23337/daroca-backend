using Microsoft.AspNetCore.Mvc;

[Route("/[controller]")]
[ApiController]
public class ProductCategoryController : ControllerBase 
{
    private readonly DatabaseContext context;

    public ProductCategoryController(DatabaseContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductCategory>> GetProductCategory()
    {
        return this.context.ProductCategory.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<ProductCategory> GetProductCategory(int id)
    {
        var productCategory = this.context.ProductCategory.Find(id);

        if(productCategory == null)
        {
            return NotFound();
        }

        return productCategory;
    }

    [HttpPost]
    public ActionResult<ProductCategory> CreateProductCategory(ProductCategory productCategory)
    {
        if (productCategory == null)
        {
            return BadRequest();
        }
        this.context.ProductCategory.Add(productCategory);
        this.context.SaveChanges();

        return CreatedAtAction(nameof(GetProductCategory), new {id = productCategory.ProductCategoryId}, productCategory);
    }

    [HttpDelete("{id}")]
    public ActionResult<ProductCategory> DeleteProductCategory(int id)
    {
        var productCategory = this.context.ProductCategory.Find(id);

        if(productCategory == null)
        {
            return NotFound();
        }

        this.context.ProductCategory.Remove(productCategory);
        this.context.SaveChanges();

        return productCategory;
    }
}