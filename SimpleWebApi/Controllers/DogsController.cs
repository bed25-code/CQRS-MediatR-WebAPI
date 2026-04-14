using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Services;

namespace SimpleWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DogsController : ControllerBase
{
    private readonly IDogService _dogService;

    public DogsController(IDogService dogService)
    {
        _dogService = dogService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_dogService.GetAll());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var dog = _dogService.GetById(id);
        if (dog is null)
        {
            return NotFound();
        }

        return Ok(dog);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateDogRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required.");
        }

        var dog = _dogService.Add(request.Name.Trim());
        return CreatedAtAction(nameof(GetById), new { id = dog.Id }, dog);
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] UpdateDogRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required.");
        }

        var updated = _dogService.Update(id, request.Name.Trim());
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }
}

public class CreateDogRequest
{
    public string Name { get; set; } = string.Empty;
}

public class UpdateDogRequest
{
    public string Name { get; set; } = string.Empty;
}
