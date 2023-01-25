using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serverapp.Models;

namespace serverapp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Context _context;
        public ProductController(Context context)
        {
            _context = context;
        }

        [HttpGet("getproducts")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProducts()
        {
            var list = _context.Products.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var value = _context.Products.FindAsync(id);
                return Ok(value);
            }
            catch (Exception)
            {
                return BadRequest("Bir hatayla karşılaşıldı!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product productdto)
        {
            await _context.Products.AddAsync(productdto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = productdto.Id });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,Product productdto)
        {
            if (id != productdto.Id)
                return BadRequest();
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return NotFound();

            product.Name = productdto.Name;
            product.Price = productdto.Price;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deletedItem=await _context.Products.FindAsync(id);
            if (deletedItem==null)
                return NotFound();
            _context.Products.Remove(deletedItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
