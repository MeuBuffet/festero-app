using SrShut.Common.Collections;
using SrShut.Cqrs.Requests;

namespace FesteroApp.Application.UseCases.Organizations.GetOrganization;

public class GetOrganizationQueryResult : PartialCollection<GetOrganizationQueryResult.GetOrganizationQueryItem>, IRequestResult
{
    public GetOrganizationQueryResult() { }
    
    public GetOrganizationQueryResult(IList<GetOrganizationQueryItem> items) : base(items)
    {
        TotalCount = items.Count;
    }
    
    public class GetOrganizationQueryItem
    {
        public Guid? Id { get; set; }
        
        public string? LegalName { get; set; }
        
        public string? TradeName { get; set; }
        
        public string? Document { get; set; }
        
        public string? Email  { get; set; }
        
        public string? Phone { get; set; }  
        
        public string? Street { get; set; }

        public string? Number { get;  set; }

        public string? Neighborhood { get; set; }

        public string? Complement { get;  set; }

        public string? PostalCode { get;  set; }

        public string? City { get;  set; }

        public string? State { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        public DateTime UpdatedOn { get; set; }
    }
}