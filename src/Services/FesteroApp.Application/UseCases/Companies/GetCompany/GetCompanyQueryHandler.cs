using System.Text;
using Dapper;
using FesteroApp.Application.UseCases.Users.GetUser;
using Microsoft.Extensions.Configuration;
using SrShut.Cqrs.Requests;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Companies.GetCompany;

public class GetCompanyQueryHandler :
    BaseDataAccess,
    IRequestHandler<GetCompanyQuery, GetCompanyQueryResult>
{
    public GetCompanyQueryHandler(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<GetCompanyQueryResult> HandleAsync(GetCompanyQuery query)
    {
        var orderBy = " ORDER BY C.Name ASC ";

        var sql = $@"
        WITH RecordsRN AS (
        SELECT 
            C.Id,
            C.Name,
            C.CorporateName,
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
        FROM [Company] AS C WITH(NOLOCK)
        WHERE C.DeletedOn IS NULL
        {Condition(query)}
        )
        SELECT * FROM RecordsRN WITH(NOLOCK) 
        WHERE NumberLine BETWEEN @FirstResult AND @LastResult 
        ORDER BY NumberLine ASC;";

        var items = new GetCompanyQueryResult();

        using var con = CreateConnection();
        var results = await con.QueryAsync<dynamic>(sql, query);
        int? totalRows = null;

        foreach (var row in results)
        {
            totalRows ??= row.TotalRows;

            var item = new GetCompanyQueryResult.GetCompanyQueryItem()
            {
                Id = row.Id,
                Name = row.Name,
                CorporateName = row.CorporateName,
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
    
    private string Condition(GetCompanyQuery query)
    {
        var condition = new StringBuilder();

        if (string.IsNullOrEmpty(query.Text)) return condition.ToString();
        
        var like = " LIKE '%' + @Text + '%' ";
        
        condition.Append($@" AND ( C.Id {like} OR C.Name {like} OR C.CorporateName {like} ) ");

        return condition.ToString();
    }
}