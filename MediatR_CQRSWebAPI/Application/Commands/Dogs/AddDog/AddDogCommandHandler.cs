using CQRSWebApi.Infrastructure.Database;
using CQRSWebApi.Models;
using MediatR;

namespace CQRSWebApi.Application.Commands.Dogs.AddDog;

internal sealed class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
{
    private readonly MockDatabase _mockDatabase;

    public AddDogCommandHandler(MockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    public Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
    {
        var dogToCreate = new Dog
        {
            Id = Guid.NewGuid(),
            Name = request.NewDog.Name
        };

        _mockDatabase.Dogs.Add(dogToCreate);

        return Task.FromResult(dogToCreate);
    }
}
