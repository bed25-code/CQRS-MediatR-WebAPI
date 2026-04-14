using Microsoft.AspNetCore.Mvc;
using CQRSWebApi.Services;

namespace CQRSWebApi.Controllers;

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
    [Route("getAllDogs")]
    public IActionResult GetAll()
    {
        return Ok(_dogService.GetAll());
    }

    [HttpGet]
    [Route("getDogById/{dogId:guid}")]
    public IActionResult GetById(Guid dogId)
    {
        var dog = _dogService.GetById(dogId);
        if (dog is null)
        {
            return NotFound();
        }

        return Ok(dog);
    }

    [HttpPost]
    [Route("addNewDog")]
    public IActionResult Create([FromBody] DogRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required.");
        }

        var createdDog = _dogService.Add(request.Name.Trim());
        return Ok(createdDog);
    }

    [HttpPut]
    [Route("updateDog/{updatedDogId:guid}")]
    public IActionResult Update([FromBody] DogRequest request, Guid updatedDogId)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required.");
        }

        var updated = _dogService.Update(updatedDogId, request.Name.Trim());
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }
}

public class DogRequest
{
    public string Name { get; set; } = string.Empty;
}
