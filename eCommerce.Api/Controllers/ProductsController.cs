using eCommerce.Api.Models;
using eCommerce.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ICommonRepository<Product> _productRepository;

    public ProductsController(ICommonRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet]
    public async Task<ActionResult<List<Product>>> Get()
    {
        var products = await _productRepository.GetAllAsync();
        if (products.Count > 0)
        {
            return Ok(products);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("{productId:int}")]
    public async Task<ActionResult<Product>> Get(int productId)
    {
        var product = await _productRepository.GetDetailsAsync(productId);
        if (product != null)
        {
            return Ok(product);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Product>> Post(Product product)
    {
        if (ModelState.IsValid)
        {
            int result = await _productRepository.InsertAsync(product);
            if (result > 0)
            {
                return CreatedAtAction("Get", new { productId = product.ProductId },
                product);
            }
        }
        return BadRequest();
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<Product>> Put(Product product)
    {
        if (ModelState.IsValid)
        {
            int result = await _productRepository.UpdateAsync(product);
            if (result > 0)
            {
                return NoContent();
            }
        }
        return BadRequest();
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> Delete(int id)
    {
        if (ModelState.IsValid)
        {
            int result = await _productRepository.DeleteAsync(id);
            if (result > 0)
            {
                return NoContent();
            }
        }
        return BadRequest();
    }
}
