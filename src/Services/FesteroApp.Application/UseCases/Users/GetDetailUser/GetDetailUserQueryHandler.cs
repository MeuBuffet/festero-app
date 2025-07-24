using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using SrShut.Cqrs.Requests;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Users.GetDetailUser;

public class GetDetailUserQueryHandler(IConfiguration configuration) :
    BaseDataAccess(configuration),
    IRequestHandler<GetDetailUserQuery, GetDetailUserQueryResult>
{
    public async Task<GetDetailUserQueryResult> HandleAsync(GetDetailUserQuery query)
    {
        var sql = @"
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
            U.UpdatedOn
        FROM [User] AS U WITH(NOLOCK)
        WHERE U.DeletedOn IS NULL
          AND U.Id = @Id
        ";

        using var con = CreateConnection();
        var result = await con.QueryFirstOrDefaultAsync<GetDetailUserQueryResult>(sql, query);

        return result;
    }
}