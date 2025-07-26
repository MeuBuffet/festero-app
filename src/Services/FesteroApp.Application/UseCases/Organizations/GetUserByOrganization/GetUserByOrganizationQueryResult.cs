using SrShut.Common.Collections;
using SrShut.Cqrs.Requests;

namespace FesteroApp.Application.UseCases.Organizations.GetUserByOrganization;

public class GetUserByOrganizationQueryResult : PartialCollection<GetUserByOrganizationQueryResult.GetUserByOrganizationQueryItem>, IRequestResult
{
    public GetUserByOrganizationQueryResult() { }
    
    public GetUserByOrganizationQueryResult(IList<GetUserByOrganizationQueryItem> items) : base(items)
    {
        TotalCount = items.Count;
    }
    
    public class GetUserByOrganizationQueryItem
    {
        public Guid? Id { get; set; }
        
        public string? Name { get; set; }
        
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