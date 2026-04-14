using CQRSWebApi.Infrastructure.Database;
using CQRSWebApi.Models;

namespace CQRSWebApi.Application.Commands.Dogs.AddDog;

public class AddDogCommandHandler
{
    private readonly MockDatabase _mockDatabase;

    public AddDogCommandHandler(MockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    public Dog Handle(AddDogCommand command)
    {
        var dogToCreate = new Dog
        {
            Id = Guid.NewGuid(),
            Name = command.NewDog.Name
        };

        _mockDatabase.Dogs.Add(dogToCreate);
        return dogToCreate;
    }
}
