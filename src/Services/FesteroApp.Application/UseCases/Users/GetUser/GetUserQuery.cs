using System.Text.Json.Serialization;
using SrShut.Cqrs.Requests;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Users.GetUser;

public class GetUserQuery : PaginationCriteria, IRequest<GetUserQueryResult>
{
    public GetUserQuery()
    {
        TenantId = [];
    }
    
    public GetUserQuery(string? text) : base()
    {
        Text = text;
    }

    public string? Text { get; set; }
    
    [JsonIgnore] public List<Guid> TenantId { get; set; }
}