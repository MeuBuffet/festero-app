using SrShut.Cqrs.Requests;

namespace FesteroApp.Application.UseCases.Users.GetDetailUser;

public class GetDetailUserQuery : IRequest<GetDetailUserQueryResult>
{
    public GetDetailUserQuery()
    {
    }
    
    public GetDetailUserQuery(Guid id, string? text) : base()
    {
        Text = text;
        Id = id;
    }

    public string? Text { get; set; }
    
    public Guid Id { get; set; }
}