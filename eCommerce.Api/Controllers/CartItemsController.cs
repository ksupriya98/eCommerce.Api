using eCommerce.Api.Models;
using eCommerce.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartItemsController : ControllerBase
{
    private readonly ICommonRepository<CartItem> _cartItemRepository;

    public CartItemsController(ICommonRepository<CartItem> cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet]
    public async Task<ActionResult<List<CartItem>>> Get()
    {
        var cartItems = await _cartItemRepository.GetAllAsync();
        if (cartItems.Count > 0)
        {
            return Ok(cartItems);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("{cartItemId:int}")]
    public async Task<ActionResult<CartItem>> Get(int cartItemId)
    {
        var cartItem = await _cartItemRepository.GetDetailsAsync(cartItemId);
        if (cartItem != null)
        {
            return Ok(cartItem);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<CartItem>> Post(CartItem cartItem)
    {
        if (ModelState.IsValid)
        {
            int result = await _cartItemRepository.InsertAsync(cartItem);
            if (result > 0)
            {
                return CreatedAtAction("Get", new { cartItemId = cartItem.CartItemId },
                cartItem);
            }
        }
        return BadRequest();
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<CartItem>> Put(CartItem cartItem)
    {
        if (ModelState.IsValid)
        {
            int result = await _cartItemRepository.UpdateAsync(cartItem);
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
    public async Task<ActionResult<CartItem>> Delete(int id)
    {
        if (ModelState.IsValid)
        {
            int result = await _cartItemRepository.DeleteAsync(id);
            if (result > 0)
            {
                return NoContent();
            }
        }
        return BadRequest();
    }
}
