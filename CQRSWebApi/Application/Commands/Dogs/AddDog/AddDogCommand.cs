using CQRSWebApi.Application.Dtos;

namespace CQRSWebApi.Application.Commands.Dogs.AddDog;

public class AddDogCommand
{
    public AddDogCommand(DogDto newDog)
    {
        NewDog = newDog;
    }

    public DogDto NewDog { get; }
}
