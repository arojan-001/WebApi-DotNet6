using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly DataCotext _context;
        public OrdersController(DataCotext cotext)
        {
            _context = cotext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {

            return Ok(await _context.Order.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var dborder = await _context.Order.FindAsync(id);
            if (dborder == null) {
                return BadRequest("Not Fount");
            }

            return Ok(dborder);
        }

        [HttpPost]
        public async Task<ActionResult<List<Order>>> AddOrder(OrderDTO request)
        {
            var product = await _context.Product.FindAsync(request.ProductId);
            if (product == null)
                return BadRequest(); 
            var order = new Order
            {
                Product = product,
                Quantity = request.Quantity,
                Price =  ((decimal)request.Quantity) *  product.Price,
                Valuedate =  request.Valuedate    

            };
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
            return Ok(await _context.Order.ToListAsync());
        }
         
        [HttpPut]
        public async Task<ActionResult<List<Order>>> UpdateOrder(OrderDTO request)
        {
            var dborder = await _context.Order.FindAsync(request.Id);
            var product = await _context.Product.FindAsync(request.ProductId);
            if (dborder == null || product == null) {
                return BadRequest("Not Found"); 
            }


            dborder.Product = product;
            dborder.Quantity = request.Quantity;
            dborder.Price = (decimal)request.Quantity * product.Price;
            dborder.Valuedate = request.Valuedate;
            

            await _context.SaveChangesAsync();
            return Ok(await _context.Order.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(int id)
        {
            var dborder = await _context.Order.FindAsync(id);
            if (dborder == null) {
                return BadRequest("Not Found");
            }

            _context.Order.Remove(dborder);

            await _context.SaveChangesAsync();
            return Ok(await _context.Order.ToListAsync());
        }
        [HttpGet("{prodtuctid}")]
        public async Task<ActionResult<Order>> GetByProductId(int prodtuctid)
        {
            var dborder = await _context.Order
                .Where(c=> c.ProductId == prodtuctid)
                .ToListAsync();
            if (dborder == null) { return BadRequest("Not Fount"); }

            return Ok(dborder);
        }



    }
}
