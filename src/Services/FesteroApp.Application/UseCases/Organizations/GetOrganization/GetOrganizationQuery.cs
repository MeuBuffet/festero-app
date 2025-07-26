using System.Text.Json.Serialization;
using SrShut.Cqrs.Requests;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Organizations.GetOrganization;

public class GetOrganizationQuery : PaginationCriteria, IRequest<GetOrganizationQueryResult>
{
    public GetOrganizationQuery()
    {
    }

    public GetOrganizationQuery(string? text) : base()
    {
        Text = text;
    }

    public string? Text { get; set; }

    [JsonIgnore] public Guid? TenantId { get; set; }
}