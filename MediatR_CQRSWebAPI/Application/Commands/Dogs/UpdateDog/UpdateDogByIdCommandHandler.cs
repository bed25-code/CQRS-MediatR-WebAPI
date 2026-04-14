using CQRSWebApi.Infrastructure.Database;
using CQRSWebApi.Models;
using MediatR;

namespace CQRSWebApi.Application.Commands.Dogs.UpdateDog;

internal class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog?>
{
    private readonly MockDatabase _mockDatabase;

    public UpdateDogByIdCommandHandler(MockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    public Task<Dog?> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
    {
        var dogToUpdate = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.Id);
        if (dogToUpdate is null)
        {
            return Task.FromResult<Dog?>(null);
        }

        dogToUpdate.Name = request.UpdatedDog.Name;
        return Task.FromResult<Dog?>(dogToUpdate);
    }
}
