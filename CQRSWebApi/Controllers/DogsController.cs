using CQRSWebApi.Application.Commands.Dogs.AddDog;
using CQRSWebApi.Application.Commands.Dogs.UpdateDog;
using CQRSWebApi.Application.Dtos;
using CQRSWebApi.Application.Queries.Dogs.GetAll;
using CQRSWebApi.Application.Queries.Dogs.GetById;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DogsController : ControllerBase
{
    private readonly GetAllDogsQueryHandler _getAllDogsQueryHandler;
    private readonly GetDogByIdQueryHandler _getDogByIdQueryHandler;
    private readonly AddDogCommandHandler _addDogCommandHandler;
    private readonly UpdateDogByIdCommandHandler _updateDogByIdCommandHandler;

    public DogsController(
        GetAllDogsQueryHandler getAllDogsQueryHandler,
        GetDogByIdQueryHandler getDogByIdQueryHandler,
        AddDogCommandHandler addDogCommandHandler,
        UpdateDogByIdCommandHandler updateDogByIdCommandHandler)
    {
        _getAllDogsQueryHandler = getAllDogsQueryHandler;
        _getDogByIdQueryHandler = getDogByIdQueryHandler;
        _addDogCommandHandler = addDogCommandHandler;
        _updateDogByIdCommandHandler = updateDogByIdCommandHandler;
    }

    [HttpGet]
    [Route("getAllDogs")]
    public IActionResult GetAll()
    {
        return Ok(_getAllDogsQueryHandler.Handle(new GetAllDogsQuery()));
    }

    [HttpGet]
    [Route("getDogById/{dogId:guid}")]
    public IActionResult GetById(Guid dogId)
    {
        var dog = _getDogByIdQueryHandler.Handle(new GetDogByIdQuery(dogId));
        if (dog is null)
        {
            return NotFound();
        }

        return Ok(dog);
    }

    [HttpPost]
    [Route("addNewDog")]
    public IActionResult Create([FromBody] DogDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required.");
        }

        request.Name = request.Name.Trim();
        var createdDog = _addDogCommandHandler.Handle(new AddDogCommand(request));
        return Ok(createdDog);
    }

    [HttpPut]
    [Route("updateDog/{updatedDogId:guid}")]
    public IActionResult Update([FromBody] DogDto request, Guid updatedDogId)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required.");
        }

        request.Name = request.Name.Trim();
        var updatedDog = _updateDogByIdCommandHandler.Handle(new UpdateDogByIdCommand(request, updatedDogId));
        if (updatedDog is null)
        {
            return NotFound();
        }

        return Ok(updatedDog);
    }
}
