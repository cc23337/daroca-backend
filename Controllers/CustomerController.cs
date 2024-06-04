using Microsoft.AspNetCore.Mvc;

[Route("/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly DatabaseContext context;

    public CustomerController(DatabaseContext context) //eh o construtor 
    {
        this.context = context;
    }

    [HttpGet] //GET
    public ActionResult<IEnumerable<Customer>> GetCustomer() 
    {
        return this.context.Customer.ToList();
    }


    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomer(int id)
    {
        var customer = this.context.Customer.Find(id);

        if (customer == null)
        {
            return NotFound(); //erro 404
        }

        return customer;
    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(Customer customer)
    {
        if (customer == null)
        {
            return BadRequest();
        }
        this.context.Customer.Add(customer);
        this.context.SaveChanges();
        
        return CreatedAtAction(nameof(GetCustomer), new {id = customer.CustomerId}, customer);
    }

    [HttpDelete]
    public ActionResult<Customer> DeleteCustomer(int id)
    {
        var customer = this.context.Customer.Find(id);

        if(customer == null)
        {
            return NotFound();
        } 

        this.context.Customer.Remove(customer); //envia para o banco
        this.context.SaveChanges(); //salva as mudanças

        return customer;
    }
}