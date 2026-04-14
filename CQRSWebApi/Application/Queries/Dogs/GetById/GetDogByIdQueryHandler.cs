using CQRSWebApi.Infrastructure.Database;
using CQRSWebApi.Models;

namespace CQRSWebApi.Application.Queries.Dogs.GetById;

public class GetDogByIdQueryHandler
{
    private readonly MockDatabase _mockDatabase;

    public GetDogByIdQueryHandler(MockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    public Dog? Handle(GetDogByIdQuery query)
    {
        return _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == query.Id);
    }
}
