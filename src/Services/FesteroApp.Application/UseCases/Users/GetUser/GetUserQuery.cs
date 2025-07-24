using SrShut.Cqrs.Requests;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Users.GetUser;

public class GetUserQuery : PaginationCriteria, IRequest<GetUserQueryResult>
{
    public GetUserQuery()
    {
        
    }
    
    public GetUserQuery(string? text) : base()
    {
        Text = text;
    }

    public string? Text { get; set; }
}