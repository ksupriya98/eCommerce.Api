using eCommerce.Api.Models;
using eCommerce.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICommonRepository<Customer> _customerRepository;

    public CustomersController(ICommonRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet]
    public async Task<ActionResult<List<Customer>>> Get()
    {
        var customers = await _customerRepository.GetAllAsync();
        if (customers.Count > 0)
        {
            return Ok(customers);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("{customerId:int}")]
    public async Task<ActionResult<Customer>> Get(int customerId)
    {
        var customer = await _customerRepository.GetDetailsAsync(customerId);
        if (customer != null)
        {
            return Ok(customer);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Customer>> Post(Customer customer)
    {
        if (ModelState.IsValid)
        {
            int result = await _customerRepository.InsertAsync(customer);
            if (result > 0)
            {
                return CreatedAtAction("Get", new { customerId = customer.CustomerId },
                customer);
            }
        }
        return BadRequest();
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<Customer>> Put(Customer customer)
    {
        if (ModelState.IsValid)
        {
            int result = await _customerRepository.UpdateAsync(customer);
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
    public async Task<ActionResult<Customer>> Delete(int id)
    {
        if (ModelState.IsValid)
        {
            int result = await _customerRepository.DeleteAsync(id);
            if (result > 0)
            {
                return NoContent();
            }
        }
        return BadRequest();
    }
}
