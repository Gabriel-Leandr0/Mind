using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mind.Domain.DTos;
using Mind.Domain.Models;
using Mind.Infrastructure.Data;

namespace Mind.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : Controller
{
    private readonly MindDbContext _context;
    private readonly IMapper _mapper;

    public CategoryController(MindDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        var category = _mapper.Map<Category>(createCategoryDto);
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IEnumerable<ReadCategoryDto> GetAllCategories()
    {

        var categoryList = _mapper.Map<List<ReadCategoryDto>>(_context.Categories.ToList());
        return categoryList;

    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult GetCategoryById(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            return NotFound();
        }
        var categoryDto = _mapper.Map<ReadCategoryDto>(category);
        return Ok(categoryDto);
    }
}
