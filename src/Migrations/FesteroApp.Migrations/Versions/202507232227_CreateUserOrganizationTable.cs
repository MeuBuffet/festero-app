using FluentMigrator;

namespace FesteroApp.Migrations.Versions;

[Migration(202507232227)]
public class CreateUserOrganizationTable : Migration
{
    public override void Up()
    {
        Create.Table("UserOrganization")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Role").AsString(20).NotNullable()
            .WithColumn("UserId").AsGuid().Nullable().ForeignKey("FK_UserOrganization_User", "User", "Id")
            .WithColumn("OrganizationId").AsGuid().Nullable().ForeignKey("FK_UserOrganization_Organization", "Organization", "Id");
    }

    public override void Down()
    {
        Delete.Table("UserOrganization");
    }
}