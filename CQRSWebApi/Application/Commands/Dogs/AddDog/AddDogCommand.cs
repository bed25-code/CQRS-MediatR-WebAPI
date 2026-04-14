using CQRSWebApi.Application.Dtos;
using CQRSWebApi.Models;
using MediatR;

namespace CQRSWebApi.Application.Commands.Dogs.AddDog;

public class AddDogCommand : IRequest<Dog>
{
    public AddDogCommand(DogDto newDog)
    {
        NewDog = newDog;
    }

    public DogDto NewDog { get; }
}
