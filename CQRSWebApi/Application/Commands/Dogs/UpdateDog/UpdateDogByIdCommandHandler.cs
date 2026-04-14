using CQRSWebApi.Infrastructure.Database;
using CQRSWebApi.Models;

namespace CQRSWebApi.Application.Commands.Dogs.UpdateDog;

public class UpdateDogByIdCommandHandler
{
    private readonly MockDatabase _mockDatabase;

    public UpdateDogByIdCommandHandler(MockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    public Dog? Handle(UpdateDogByIdCommand command)
    {
        var dogToUpdate = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == command.Id);
        if (dogToUpdate is null)
        {
            return null;
        }

        dogToUpdate.Name = command.UpdatedDog.Name;
        return dogToUpdate;
    }
}
