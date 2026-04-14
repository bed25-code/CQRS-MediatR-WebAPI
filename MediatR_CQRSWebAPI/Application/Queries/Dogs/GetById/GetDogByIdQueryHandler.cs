using CQRSWebApi.Infrastructure.Database;
using CQRSWebApi.Models;
using MediatR;

namespace CQRSWebApi.Application.Queries.Dogs.GetById;

public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog?>
{
    private readonly MockDatabase _mockDatabase;

    public GetDogByIdQueryHandler(MockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    public Task<Dog?> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
    {
        var wantedDog = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.Id);
        return Task.FromResult(wantedDog);
    }
}
