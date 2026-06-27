using eCommerce.Api.Models;
using eCommerce.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController : ControllerBase
{
    private readonly ICommonRepository<Invoice> _invoiceRepository;

    public InvoicesController(ICommonRepository<Invoice> invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet]
    public async Task<ActionResult<List<Invoice>>> Get()
    {
        var invoices = await _invoiceRepository.GetAllAsync();
        if (invoices.Count > 0)
        {
            return Ok(invoices);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("{invoiceId:int}")]
    public async Task<ActionResult<Invoice>> Get(int invoiceId)
    {
        var invoice = await _invoiceRepository.GetDetailsAsync(invoiceId);
        if (invoice != null)
        {
            return Ok(invoice);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Invoice>> Post(Invoice invoice)
    {
        if (ModelState.IsValid)
        {
            int result = await _invoiceRepository.InsertAsync(invoice);
            if (result > 0)
            {
                return CreatedAtAction("Get", new { invoiceId = invoice.InvoiceId },
                invoice);
            }
        }
        return BadRequest();
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<Invoice>> Put(Invoice invoice)
    {
        if (ModelState.IsValid)
        {
            int result = await _invoiceRepository.UpdateAsync(invoice);
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
    public async Task<ActionResult<Invoice>> Delete(int id)
    {
        if (ModelState.IsValid)
        {
            int result = await _invoiceRepository.DeleteAsync(id);
            if (result > 0)
            {
                return NoContent();
            }
        }
        return BadRequest();
    }
}
