using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using SrShut.Cqrs.Requests;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Organizations.GetOrganization;

public class GetOrganizationQueryHandler(IConfiguration configuration) :
    BaseDataAccess(configuration),
    IRequestHandler<GetOrganizationQuery, GetOrganizationQueryResult>
{
    public async Task<GetOrganizationQueryResult> HandleAsync(GetOrganizationQuery query)
    {
        var orderBy = " ORDER BY C.TradeName ASC ";

        var sql = $@"
        WITH RecordsRN AS (
        SELECT 
            C.Id,
            C.LegalName,
            C.TradeName,
            C.Document,
            C.Phone,
            C.Email,
            C.Street,
            C.Number,
            C.Complement,
            C.Neighborhood,
            C.PostalCode,
            C.City,
            C.State,
            C.CreatedOn,
            C.UpdatedOn,
            ROW_NUMBER() OVER({orderBy}) as NumberLine,
            COUNT(*) OVER() AS TotalRows 
        FROM [Organization] AS C WITH(NOLOCK)
        INNER JOIN [Organization] AS CC WITH(NOLOCK) ON CC.Id = @TenantId
        WHERE C.DeletedOn IS NULL
          AND CC.DeletedOn IS NULL
          AND C.Path LIKE CC.Path + '/%'
        {Condition(query)}
        )
        SELECT * FROM RecordsRN WITH(NOLOCK) 
        WHERE NumberLine BETWEEN @FirstResult AND @LastResult 
        ORDER BY NumberLine ASC;";

        var items = new GetOrganizationQueryResult();

        using var con = CreateConnection();
        var results = await con.QueryAsync<dynamic>(sql, query);
        int? totalRows = null;

        foreach (var row in results)
        {
            totalRows ??= row.TotalRows;

            var item = new GetOrganizationQueryResult.GetOrganizationQueryItem()
            {
                Id = row.Id,
                LegalName = row.LegalName,
                TradeName = row.TradeName,
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
    
    private string Condition(GetOrganizationQuery query)
    {
        var condition = new StringBuilder();

        if (string.IsNullOrEmpty(query.Text)) return condition.ToString();
        
        var like = " LIKE '%' + @Text + '%' ";
        
        condition.Append($@" AND ( C.Id {like} OR C.Name {like} OR C.CorporateName {like} ) ");

        return condition.ToString();
    }
}