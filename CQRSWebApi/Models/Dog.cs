using CQRSWebApi.Models.Animal;

namespace CQRSWebApi.Models;

public class Dog : AnimalModel
{
    public string Bark()
    {
        return "This animal barks";
    }
}
