using SimpleWebApi.Models;

namespace SimpleWebApi.Services;

public class InMemoryDogService : IDogService
{
    private readonly List<Dog> _dogs = new()
    {
        new Dog { Id = Guid.NewGuid(), Name = "Björn" },
        new Dog { Id = Guid.NewGuid(), Name = "Patrik" },
        new Dog { Id = Guid.NewGuid(), Name = "Alfred" },
        new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests" }
    };

    public IReadOnlyCollection<Dog> GetAll()
    {
        return _dogs;
    }

    public Dog? GetById(Guid id)
    {
        return _dogs.FirstOrDefault(dog => dog.Id == id);
    }

    public Dog Add(string name)
    {
        var dog = new Dog
        {
            Id = Guid.NewGuid(),
            Name = name
        };

        _dogs.Add(dog);
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
