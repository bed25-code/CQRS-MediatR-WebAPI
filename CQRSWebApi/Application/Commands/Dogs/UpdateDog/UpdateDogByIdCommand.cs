using CQRSWebApi.Application.Dtos;

namespace CQRSWebApi.Application.Commands.Dogs.UpdateDog;

public class UpdateDogByIdCommand
{
    public UpdateDogByIdCommand(DogDto updatedDog, Guid id)
    {
        UpdatedDog = updatedDog;
        Id = id;
    }

    public DogDto UpdatedDog { get; }
    public Guid Id { get; }
}
