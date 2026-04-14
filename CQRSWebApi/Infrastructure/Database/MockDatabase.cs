using CQRSWebApi.Models;

namespace CQRSWebApi.Infrastructure.Database;

public class MockDatabase
{
    public List<Dog> Dogs { get; set; } = new()
    {
        new Dog { Id = Guid.NewGuid(), Name = "Björn" },
        new Dog { Id = Guid.NewGuid(), Name = "Patrik" },
        new Dog { Id = Guid.NewGuid(), Name = "Alfred" },
        new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests" }
    };
}
