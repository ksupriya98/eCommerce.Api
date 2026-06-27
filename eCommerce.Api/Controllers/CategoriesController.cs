using eCommerce.Api.Models;
using eCommerce.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace eCommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICommonRepository<Category> _categoryRepository;

    public CategoriesController(ICommonRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet]
    public async Task<ActionResult<List<Category>>> Get()
    {
        var categories = await _categoryRepository.GetAllAsync();
        if (categories.Count > 0)
        {
            return Ok(categories);
        }
        else
        {
            return NoContent();
        }
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("{categoryId:int}")]
    public async Task<ActionResult<Category>> Get(int categoryId)
    {
        var category = await _categoryRepository.GetDetailsAsync(categoryId);
        if (category != null)
        {
            return Ok(category);
        }
        else
        {
            return NoContent();
        }
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Category>> Post(Category category)
    {
        if (ModelState.IsValid)
        {
            int result = await _categoryRepository.InsertAsync(category);
            if (result > 0)
            {
                return CreatedAtAction("Get", new { categoryId = category.CategoryId },
                category);
            }
        }
        return BadRequest();
    }
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<Category>> Put(Category category)
    {
        if (ModelState.IsValid)
        {
            int result = await _categoryRepository.UpdateAsync(category);
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
    public async Task<ActionResult<Category>> Delete(int id)
    {
        if (ModelState.IsValid)
        {
            int result = await _categoryRepository.DeleteAsync(id);
            if (result > 0)
            {
                return NoContent();
            }
        }
        return BadRequest();
    }
}
