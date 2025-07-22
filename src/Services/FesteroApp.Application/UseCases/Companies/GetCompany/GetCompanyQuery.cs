using SrShut.Cqrs.Requests;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Companies.GetCompany;

public class GetCompanyQuery : PaginationCriteria, IRequest<GetCompanyQueryResult>
{
    public GetCompanyQuery()
    {
        
    }
    
    public GetCompanyQuery(string? text) : base()
    {
        Text = text;
    }

    public string? Text { get; set; }
}