using FridgementBackend.Data;
using FridgementBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FridgementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            // create a database context instance
            using var context = new AppDbContext();

            // from the context instance grab the list of products
            var product = await context.Products.ToListAsync<Product>();

            // return them
            return product;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(string id)
        {
            // generate the context
            using var context = new AppDbContext();

            // use the parameter to search
            var product = await context.Products.FindAsync(id);

            // with the returned product from the database return it back to the client
            return product;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            // generate the app context
            using var context = new AppDbContext();

            // use the value from the body to turn into a product object
            context.Add(product);

            // save the changes within the context
            context.SaveChanges();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Product value)
        {
            using var context = new AppDbContext();

            try
            {
                context.Update<Product>(value);
                context.SaveChanges();
            } 
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                Console.WriteLine("An error has occured while updating a product");
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            // create the database context
            using var context = new AppDbContext();

            try
            {
                // search for the single item that you are going to remove from the database
                var product = context.Products.Find(id);

                if (product != null)
                {
                    // perform the remove using the whole object from the database.
                    context.Remove<Product>(product);
                }
                else
                {
                    throw new DbUpdateException("The product to delete was not found");
                }
                context.SaveChanges();
            }
            // for now just use a generalization of exceptions and then we can decide
            // which one is the approriate exception
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                Console.WriteLine("An error has occured while trying to remove a product");
            }
            
        }
    }
}
