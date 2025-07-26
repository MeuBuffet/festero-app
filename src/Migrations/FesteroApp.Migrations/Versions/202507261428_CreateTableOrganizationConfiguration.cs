using FluentMigrator;

namespace FesteroApp.Migrations.Versions;

[Migration(202507261428)]
public class CreateTableOrganizationConfiguration : Migration
{
    public override void Up()
    {
        Create.Table("OrganizationConfiguration")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("OrganizationId").AsGuid().NotNullable().ForeignKey("FK_OrganizationConfiguration_Organization", "Organization", "Id")
            .WithColumn("WorkdayStart").AsTime().Nullable()
            .WithColumn("WorkdayEnd").AsTime().Nullable();
    }

    public override void Down()
    {
        Delete.Table("OrganizationConfiguration");
    }
}