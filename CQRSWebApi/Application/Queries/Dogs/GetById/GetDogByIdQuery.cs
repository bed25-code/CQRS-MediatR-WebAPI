namespace CQRSWebApi.Application.Queries.Dogs.GetById;

public class GetDogByIdQuery
{
    public GetDogByIdQuery(Guid dogId)
    {
        Id = dogId;
    }

    public Guid Id { get; }
}
