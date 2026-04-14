using CQRSWebApi.Application.Commands.Dogs.AddDog;
using CQRSWebApi.Application.Commands.Dogs.UpdateDog;
using CQRSWebApi.Application.Dtos;
using CQRSWebApi.Application.Queries.Dogs.GetAll;
using CQRSWebApi.Application.Queries.Dogs.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("getAllDogs")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllDogsQuery()));
    }

    [HttpGet]
    [Route("getDogById/{dogId:guid}")]
    public async Task<IActionResult> GetById(Guid dogId)
    {
        var dog = await _mediator.Send(new GetDogByIdQuery(dogId));
        if (dog is null)
        {
            return NotFound();
        }

        return Ok(dog);
    }

    [HttpPost]
    [Route("addNewDog")]
    public async Task<IActionResult> Create([FromBody] DogDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required.");
        }

        var createdDog = await _mediator.Send(new AddDogCommand(request));
        return Ok(createdDog);
    }

    [HttpPut]
    [Route("updateDog/{updatedDogId:guid}")]
    public async Task<IActionResult> Update([FromBody] DogDto request, Guid updatedDogId)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required.");
        }

        var updatedDog = await _mediator.Send(new UpdateDogByIdCommand(request, updatedDogId));
        if (updatedDog is null)
        {
            return NotFound();
        }

        return Ok(updatedDog);
    }
}
