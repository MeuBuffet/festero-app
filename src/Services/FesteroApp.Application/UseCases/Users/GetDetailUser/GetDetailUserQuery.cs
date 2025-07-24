using System.Text.Json.Serialization;
using SrShut.Cqrs.Requests;
using SrShut.Data;

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