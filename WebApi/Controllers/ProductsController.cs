using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<List<Products>>> Get()
        {

            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> Get(int id)
        {
            var dbproduct = await _context.Products.FindAsync(id);
            if(dbproduct == null) { return BadRequest("Not Fount"); }

            return Ok(dbproduct);
        }

        [HttpPost]
        public async Task<ActionResult<List<Products>>> AddProduct(Products product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Products>>> UpdateProduct(Products request)
        {
            var dbproduct = await _context.Products.FindAsync(request.Id);
            if (dbproduct == null) { return BadRequest("Not Fount"); }


            dbproduct.Name = request.Name;
            dbproduct.Qnty = request.Qnty;

            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> Delete(int id)
        {
            var dbproduct = await _context.Products.FindAsync(id);
            if (dbproduct == null) {
                return BadRequest("Not Fount"); 
            }

            _context.Products.Remove(dbproduct);

            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }


    }
}
