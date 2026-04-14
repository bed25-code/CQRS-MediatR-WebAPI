using CQRSWebApi.Application.Dtos;
using CQRSWebApi.Models;
using MediatR;

namespace CQRSWebApi.Application.Commands.Dogs.UpdateDog;

public class UpdateDogByIdCommand : IRequest<Dog?>
{
    public UpdateDogByIdCommand(DogDto updatedDog, Guid id)
    {
        UpdatedDog = updatedDog;
        Id = id;
    }

    public DogDto UpdatedDog { get; }
    public Guid Id { get; }
}
