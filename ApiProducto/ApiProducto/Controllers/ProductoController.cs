using ApiProducto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiProducto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public readonly Context _context;

        public ProductoController(Context context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Producto>> GetProducto()
        {
            return await _context.Producto.ToListAsync();
        }

    }
}
