using SrShut.Cqrs.Commands;

namespace FesteroApp.Companies.Application.UseCases.DetailCompany
{
    public class DetailCompanyQueryResult(Guid? id, string? name):ICommand
    {
        public Guid? Id { get; set; } = id;

        public string? Name { get; set; } = name;
    }
}