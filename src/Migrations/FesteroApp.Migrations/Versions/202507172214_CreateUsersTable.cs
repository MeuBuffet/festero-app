using FluentMigrator;

namespace FesteroApp.Migrations.Versions;

[Migration(202507172214)]
public class CreateUsersTable : Migration
{
    public override void Up()
    {
        Create.Table("User")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Name").AsString(150).NotNullable()
            .WithColumn("Email").AsString(500).NotNullable()
            .WithColumn("Password").AsString(50).NotNullable()
            .WithColumn("CreatedOn").AsDateTime().NotNullable()
            .WithColumn("UpdatedOn").AsDateTime().NotNullable()
            .WithColumn("DeletedOn").AsDateTime().Nullable();
    }

    public override void Down()
    {
        Delete.Table("User");
    }
}