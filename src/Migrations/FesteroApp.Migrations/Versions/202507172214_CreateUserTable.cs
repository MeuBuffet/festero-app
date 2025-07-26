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
            .WithColumn("Phone").AsString(20).Nullable()
            .WithColumn("Street").AsString(150).Nullable()
            .WithColumn("Number").AsString(10).Nullable()
            .WithColumn("Complement").AsString(150).Nullable()
            .WithColumn("Neighborhood").AsString(150).Nullable()
            .WithColumn("PostalCode").AsString(15).Nullable()
            .WithColumn("City").AsString(150).Nullable()
            .WithColumn("State").AsString(30).Nullable()
            .WithColumn("CreatedOn").AsDateTime().NotNullable()
            .WithColumn("UpdatedOn").AsDateTime().NotNullable()
            .WithColumn("DeletedOn").AsDateTime().Nullable();
    }

    public override void Down()
    {
        Delete.Table("User");
    }
}