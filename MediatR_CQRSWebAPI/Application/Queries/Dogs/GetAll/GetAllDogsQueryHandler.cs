using CQRSWebApi.Infrastructure.Database;
using CQRSWebApi.Models;
using MediatR;

namespace CQRSWebApi.Application.Queries.Dogs.GetAll;

internal sealed class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
{
    private readonly MockDatabase _mockDatabase;

    public GetAllDogsQueryHandler(MockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    public Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_mockDatabase.Dogs);
    }
}
