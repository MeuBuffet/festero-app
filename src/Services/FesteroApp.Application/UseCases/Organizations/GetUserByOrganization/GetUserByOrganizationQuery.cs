using SrShut.Cqrs.Requests;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Organizations.GetUserByOrganization;

public class GetUserByOrganizationQuery : PaginationCriteria, IRequest<GetUserByOrganizationQueryResult>
{
    public GetUserByOrganizationQuery()
    {
    }

    public GetUserByOrganizationQuery(Guid id, string? text) : base()
    {
        Id = id;
        Text = text;
    }

    public string? Text { get; set; }

    public Guid? Id { get; set; }
}