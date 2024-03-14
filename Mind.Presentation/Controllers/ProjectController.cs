using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mind.Domain.DTos;
using Mind.Domain.Models;
using Mind.Infrastructure.Data;

namespace Mind.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : Controller
{
    private readonly MindDbContext _context;
    private readonly IMapper _mapper;

    public ProjectController(MindDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto createProjectDto)
    {
        var project = _mapper.Map<Project>(createProjectDto);
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IEnumerable<ReadProjectDto> GetAllProjects()
    {
        var projectList = _mapper.Map<List<ReadProjectDto>>(_context.Projects.ToList());
        return projectList;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult GetProjectById(int id)
    {
        var project = _context.Projects.FirstOrDefault(p => p.Id == id);
        if (project == null)
        {
            return NotFound();
        }

        var projectDto = _mapper.Map<ReadProjectDto>(project);
        return Ok(projectDto);
    }  
}