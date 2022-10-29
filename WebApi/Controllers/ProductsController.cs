using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly DataCotext _context;
        public ProductsController(DataCotext cotext)
        {
            _context = cotext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {

            return Ok(await _context.Product.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var dbproduct = await _context.Product.FindAsync(id);
            if(dbproduct == null) { return BadRequest("Not Fount"); }

            return Ok(dbproduct);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(ProductDTO request)
        {
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Qnty = request.Qnty,
                Price = request.Price,
            };
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return Ok(await _context.Product.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(ProductDTO request)
        {
            var dbproduct = await _context.Product.FindAsync(request.Id);
            if (dbproduct == null) { return BadRequest("Not Fount"); }


            dbproduct.Name = request.Name;
            dbproduct.Qnty = request.Qnty;
            dbproduct.Price = request.Price;

            await _context.SaveChangesAsync();
            return Ok(await _context.Product.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var dbproduct = await _context.Product.FindAsync(id);
            if (dbproduct == null) {
                return BadRequest("Not Fount"); 
            }

            _context.Product.Remove(dbproduct);

            await _context.SaveChangesAsync();
            return Ok(await _context.Product.ToListAsync());
        }


    }
}
