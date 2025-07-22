using FluentMigrator;

namespace FesteroApp.Migrations.Versions;

[Migration(202507212243)]
public class CreateCompanyTable : Migration
{
    public override void Up()
    {
        Create.Table("Company")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Name").AsString(500).NotNullable()
            .WithColumn("CorporateName").AsString(500).NotNullable()
            .WithColumn("Document").AsString(20).NotNullable()
            .WithColumn("Email").AsString(150).NotNullable()
            .WithColumn("Phone").AsString(20).NotNullable()
            .WithColumn("Street").AsString(150).NotNullable()
            .WithColumn("Number").AsString(150).NotNullable()
            .WithColumn("Complement").AsString(150).NotNullable()
            .WithColumn("Neighborhood").AsString(150).NotNullable()
            .WithColumn("PostalCode").AsString(150).NotNullable()
            .WithColumn("City").AsString(150).NotNullable()
            .WithColumn("State").AsString(150).NotNullable()
            .WithColumn("CreatedOn").AsDateTime().NotNullable()
            .WithColumn("UpdatedOn").AsDateTime().NotNullable()
            .WithColumn("DeletedOn").AsDateTime().Nullable();
    }

    public override void Down()
    {
        Delete.Table("Company");
    }
}