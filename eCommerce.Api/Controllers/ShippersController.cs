using eCommerce.Api.Models;
using eCommerce.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShippersController : ControllerBase
{
    private readonly ICommonRepository<Shipper> _shipperRepository;

    public ShippersController(ICommonRepository<Shipper> shipperRepository)
    {
        _shipperRepository = shipperRepository;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet]
    public async Task<ActionResult<List<Shipper>>> Get()
    {
        var shippers = await _shipperRepository.GetAllAsync();
        if (shippers.Count > 0)
        {
            return Ok(shippers);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("{shipperId:int}")]
    public async Task<ActionResult<Shipper>> Get(int shipperId)
    {
        var shipper = await _shipperRepository.GetDetailsAsync(shipperId);
        if (shipper != null)
        {
            return Ok(shipper);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Shipper>> Post(Shipper shipper)
    {
        if (ModelState.IsValid)
        {
            int result = await _shipperRepository.InsertAsync(shipper);
            if (result > 0)
            {
                return CreatedAtAction("Get", new { shipperId = shipper.ShipperId },
                shipper);
            }
        }
        return BadRequest();
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<Shipper>> Put(Shipper shipper)
    {
        if (ModelState.IsValid)
        {
            int result = await _shipperRepository.UpdateAsync(shipper);
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
    public async Task<ActionResult<Shipper>> Delete(int id)
    {
        if (ModelState.IsValid)
        {
            int result = await _shipperRepository.DeleteAsync(id);
            if (result > 0)
            {
                return NoContent();
            }
        }
        return BadRequest();
    }
}
