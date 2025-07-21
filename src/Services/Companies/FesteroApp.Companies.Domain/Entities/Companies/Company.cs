namespace FesteroApp.Companies.Domain.Entities.Companies
{
    public class Company
    {
        public Company()
        {

        }

        public Company(Guid id, string? name) : this()
        {
            Id = id;
            Name = name;

            CreatedOn = UpdatedOn = DateTime.Now;
        }

        public Guid Id { get; set; }

        public string? Name { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public void Delete()
        {
            DeletedOn = DateTime.Now;
        }
    }
}