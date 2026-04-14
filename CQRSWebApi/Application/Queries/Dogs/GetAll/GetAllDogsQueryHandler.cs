using CQRSWebApi.Infrastructure.Database;
using CQRSWebApi.Models;

namespace CQRSWebApi.Application.Queries.Dogs.GetAll;

public class GetAllDogsQueryHandler
{
    private readonly MockDatabase _mockDatabase;

    public GetAllDogsQueryHandler(MockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    public IReadOnlyCollection<Dog> Handle(GetAllDogsQuery query)
    {
        return _mockDatabase.Dogs;
    }
}
