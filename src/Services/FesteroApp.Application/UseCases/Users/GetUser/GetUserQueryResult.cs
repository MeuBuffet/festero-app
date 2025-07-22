using SrShut.Common.Collections;
using SrShut.Cqrs.Requests;

namespace FesteroApp.Application.UseCases.Users.GetUser;

public class GetUserQueryResult : PartialCollection<GetUserQueryResult.GetUserQueryItem>, IRequestResult
{
    public GetUserQueryResult() { }
    
    public GetUserQueryResult(IList<GetUserQueryItem> items) : base(items)
    {
        TotalCount = items.Count;
    }
    
    public class GetUserQueryItem
    {
        public Guid? Id { get; set; }
        
        public string? Name { get; set; }
        
        public string? Email { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        public DateTime UpdatedOn { get; set; }
    }
}