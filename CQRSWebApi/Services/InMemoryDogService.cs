using CQRSWebApi.Infrastructure.Database;
using CQRSWebApi.Models;

namespace CQRSWebApi.Services;

public class InMemoryDogService : IDogService
{
    private readonly MockDatabase _mockDatabase;

    public InMemoryDogService(MockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    public IReadOnlyCollection<Dog> GetAll()
    {
        return _mockDatabase.Dogs;
    }

    public Dog? GetById(Guid id)
    {
        return _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == id);
    }

    public Dog Add(string name)
    {
        var dog = new Dog
        {
            Id = Guid.NewGuid(),
            Name = name
        };

        _mockDatabase.Dogs.Add(dog);
        return dog;
    }

    public bool Update(Guid id, string name)
    {
        var dog = GetById(id);
        if (dog is null)
        {
            return false;
        }

        dog.Name = name;
        return true;
    }
}
