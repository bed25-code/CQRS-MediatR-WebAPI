using CQRSWebApi.Models;
using MediatR;

namespace CQRSWebApi.Application.Queries.Dogs.GetById;

public class GetDogByIdQuery : IRequest<Dog?>
{
    public GetDogByIdQuery(Guid dogId)
    {
        Id = dogId;
    }

    public Guid Id { get; }
}
