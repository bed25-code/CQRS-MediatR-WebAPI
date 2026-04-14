using CQRSWebApi.Models;
using MediatR;

namespace CQRSWebApi.Application.Queries.Dogs.GetAll;

public class GetAllDogsQuery : IRequest<List<Dog>>
{
}
