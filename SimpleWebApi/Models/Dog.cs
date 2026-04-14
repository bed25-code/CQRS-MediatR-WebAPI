using SimpleWebApi.Models.Animal;

namespace SimpleWebApi.Models;

public class Dog : AnimalModel
{
    public string Bark()
    {
        return "This animal barks";
    }
}
