using SrShut.Cqrs.Requests;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Companies.GetUserByCompany;

public class GetUserByCompanyQuery : PaginationCriteria, IRequest<GetUserByCompanyQueryResult>
{
    public GetUserByCompanyQuery()
    {
    }

    public GetUserByCompanyQuery(Guid id, string? text) : base()
    {
        Id = id;
        Text = text;
    }

    public string? Text { get; set; }

    public Guid? Id { get; set; }
}