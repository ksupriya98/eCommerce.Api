using eCommerce.Api.Models;
using eCommerce.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly ICommonRepository<Cart> _cartRepository;

    public CartsController(ICommonRepository<Cart> cartRepository)
    {
        _cartRepository = cartRepository;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet]
    public async Task<ActionResult<List<Cart>>> Get()
    {
        var carts = await _cartRepository.GetAllAsync();
        if (carts.Count > 0)
        {
            return Ok(carts);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("{cartId:int}")]
    public async Task<ActionResult<Cart>> Get(int cartId)
    {
        var cart = await _cartRepository.GetDetailsAsync(cartId);
        if (cart != null)
        {
            return Ok(cart);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Cart>> Post(Cart cart)
    {
        if (ModelState.IsValid)
        {
            int result = await _cartRepository.InsertAsync(cart);
            if (result > 0)
            {
                return CreatedAtAction("Get", new { cartId = cart.CartId },
                cart);
            }
        }
        return BadRequest();
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<Cart>> Put(Cart cart)
    {
        if (ModelState.IsValid)
        {
            int result = await _cartRepository.UpdateAsync(cart);
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
    public async Task<ActionResult<Cart>> Delete(int id)
    {
        if (ModelState.IsValid)
        {
            int result = await _cartRepository.DeleteAsync(id);
            if (result > 0)
            {
                return NoContent();
            }
        }
        return BadRequest();
    }
}
