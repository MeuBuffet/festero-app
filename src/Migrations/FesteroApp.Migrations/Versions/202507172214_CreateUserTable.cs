using FluentMigrator;

namespace FesteroApp.Migrations.Versions;

[Migration(202507172214)]
public class CreateUserTable : Migration
{
    public override void Up()
    {
        Create.Table("User")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Name").AsString(150).NotNullable()
            .WithColumn("Password").AsString(50).NotNullable()
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
        Delete.Table("User");
    }
}