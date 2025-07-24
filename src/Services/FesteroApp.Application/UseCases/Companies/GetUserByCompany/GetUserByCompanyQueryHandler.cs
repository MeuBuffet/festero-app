using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using SrShut.Cqrs.Requests;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Companies.GetUserByCompany;

public class GetUserByCompanyQueryHandler(IConfiguration configuration) :
    BaseDataAccess(configuration),
    IRequestHandler<GetUserByCompanyQuery, GetUserByCompanyQueryResult>
{
    public async Task<GetUserByCompanyQueryResult> HandleAsync(GetUserByCompanyQuery query)
    {
        var orderBy = " ORDER BY C.TradeName ASC ";

        var sql = $@"
        WITH RecordsRN AS (
        SELECT 
            U.Id,
            U.Name,
            U.Document,
            U.Email,
            U.Phone,
            U.Street,
            U.Number,
            U.Complement,
            U.Neighborhood,
            U.PostalCode,
            U.City,
            U.State,
            U.CreatedOn,
            U.UpdatedOn,
            ROW_NUMBER() OVER( ORDER BY C.TradeName ASC ) as NumberLine,
            COUNT(*) OVER() AS TotalRows 
        FROM [Company] AS C WITH(NOLOCK)
        INNER JOIN [UserCompany] AS UC WITH(NOLOCK) ON UC.CompanyId = C.Id 
        INNER JOIN [User] AS U WITH(NOLOCK) ON U.Id = UC.UserId 
        WHERE C.DeletedOn IS NULL
          AND U.DeletedOn IS NULL
          AND C.Id = @Id
        {Condition(query)}
        )
        SELECT * FROM RecordsRN WITH(NOLOCK) 
        WHERE NumberLine BETWEEN @FirstResult AND @LastResult 
        ORDER BY NumberLine ASC;";

        var items = new GetUserByCompanyQueryResult();

        using var con = CreateConnection();
        var results = await con.QueryAsync<dynamic>(sql, query);
        int? totalRows = null;

        foreach (var row in results)
        {
            totalRows ??= row.TotalRows;

            var item = new GetUserByCompanyQueryResult.GetUserByCompanyQueryItem()
            {
                Id = row.Id,
                Name = row.Name,
                Document = row.Document,
                Email = row.Email,
                Phone = row.Phone,
                Street = row.Street,
                Number = row.Number,
                Complement = row.Complement,
                Neighborhood = row.Neighborhood,
                PostalCode = row.PostalCode,
                City = row.City,
                State = row.State,
                CreatedOn = row.CreatedOn,
                UpdatedOn = row.UpdatedOn,
            };

            items.Items.Add(item);
        }

        items.TotalCount = totalRows ?? 0;
        
        return items;
    }
    
    private string Condition(GetUserByCompanyQuery query)
    {
        var condition = new StringBuilder();

        if (string.IsNullOrEmpty(query.Text)) return condition.ToString();
        
        var like = " LIKE '%' + @Text + '%' ";
        
        condition.Append($@" AND ( C.Id {like} OR C.Name {like} OR C.CorporateName {like} ) ");

        return condition.ToString();
    }
}