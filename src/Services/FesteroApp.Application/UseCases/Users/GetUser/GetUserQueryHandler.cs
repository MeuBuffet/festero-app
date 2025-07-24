using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using SrShut.Cqrs.Requests;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Users.GetUser;

public class GetUserQueryHandler :
    BaseDataAccess,
    IRequestHandler<GetUserQuery, GetUserQueryResult>
{
    public GetUserQueryHandler(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<GetUserQueryResult> HandleAsync(GetUserQuery query)
    {
        var orderBy = " ORDER BY U.Name ASC ";

        var sql = $@"
            WITH RecordsRN AS (
                SELECT 
                    U.Id,
                    U.Name,
                    U.Email,
                    U.CreatedOn,
                    U.UpdatedOn,
                    ROW_NUMBER() OVER({orderBy}) as NumberLine,
                    COUNT(*) OVER() AS TotalRows 
                FROM [User] AS U WITH(NOLOCK)
                INNER JOIN [UserCompany] AS UCO ON U.Id = UCO.UserId 
                WHERE U.DeletedOn IS NULL
                  AND UCO.CompanyId = @TenantId
                {Condition(query)}
            )
            SELECT * FROM RecordsRN WITH(NOLOCK) 
            WHERE NumberLine BETWEEN @FirstResult AND @LastResult 
            ORDER BY NumberLine ASC;";

        var items = new GetUserQueryResult();

        using var con = CreateConnection();
        var results = await con.QueryAsync<dynamic>(sql, query);
        int? totalRows = null;

        foreach (var row in results)
        {
            totalRows ??= row.TotalRows;

            var item = new GetUserQueryResult.GetUserQueryItem()
            {
                Id = row.Id,
                Name = row.Name,
                Email = row.Email,
                CreatedOn = row.CreatedOn,
                UpdatedOn = row.UpdatedOn,
            };

            items.Items.Add(item);
        }

        items.TotalCount = totalRows ?? 0;
        
        return items;
    }
    
    private string Condition(GetUserQuery query)
    {
        var condition = new StringBuilder();

        if (string.IsNullOrEmpty(query.Text)) return condition.ToString();
        
        var like = " LIKE '%' + @Text + '%' ";
        
        condition.Append($@" AND ( U.Id {like} OR U.Name {like} OR U.Description {like} ) ");

        return condition.ToString();
    }
}