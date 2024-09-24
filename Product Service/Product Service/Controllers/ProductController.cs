using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Service.Entity;
using Product_Service.Infra;

namespace Product_Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetAllProduct();
            return Ok(products);
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            await _productRepository.AddProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        // PUT: api/product/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProduct(int id, Product product)
        //{
        //    if (id != product.ProductId)
        //    {
        //        return BadRequest();
        //    }

        //    await _productRepository.UpdateProduct(product);
        //    return NoContent();
        //}

        //// DELETE: api/product/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    await _productRepository.DeleteProduct(id);
        //    return NoContent();
        //}
    }
}
