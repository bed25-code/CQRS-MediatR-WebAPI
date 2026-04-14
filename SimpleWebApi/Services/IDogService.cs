using SimpleWebApi.Models;

namespace SimpleWebApi.Services;

public interface IDogService
{
    IReadOnlyCollection<Dog> GetAll();
    Dog? GetById(Guid id);
    Dog Add(string name);
    bool Update(Guid id, string name);
}
