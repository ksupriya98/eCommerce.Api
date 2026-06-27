using eCommerce.Api.Models;
using eCommerce.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuppliersController : ControllerBase
{
    private readonly ICommonRepository<Supplier> _supplierRepository;

    public SuppliersController(ICommonRepository<Supplier> supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet]
    public async Task<ActionResult<List<Supplier>>> Get()
    {
        var suppliers = await _supplierRepository.GetAllAsync();
        if (suppliers.Count > 0)
        {
            return Ok(suppliers);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("{supplierId:int}")]
    public async Task<ActionResult<Supplier>> Get(int supplierId)
    {
        var supplier = await _supplierRepository.GetDetailsAsync(supplierId);
        if (supplier != null)
        {
            return Ok(supplier);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Supplier>> Post(Supplier supplier)
    {
        if (ModelState.IsValid)
        {
            int result = await _supplierRepository.InsertAsync(supplier);
            if (result > 0)
            {
                return CreatedAtAction("Get", new { supplierId = supplier.SupplierId },
                supplier);
            }
        }
        return BadRequest();
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<Supplier>> Put(Supplier supplier)
    {
        if (ModelState.IsValid)
        {
            int result = await _supplierRepository.UpdateAsync(supplier);
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
    public async Task<ActionResult<Supplier>> Delete(int id)
    {
        if (ModelState.IsValid)
        {
            int result = await _supplierRepository.DeleteAsync(id);
            if (result > 0)
            {
                return NoContent();
            }
        }
        return BadRequest();
    }
}
