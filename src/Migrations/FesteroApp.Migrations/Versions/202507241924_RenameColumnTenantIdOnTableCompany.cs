using FluentMigrator;

namespace FesteroApp.Migrations.Versions;

[Migration(202507241924)]
public class RenameColumnTenantIdOnTableCompany : Migration
{
    public override void Up()
    {
        Rename.Column("TenantId").OnTable("Company").To("ParentId");
    }

    public override void Down()
    {
        Rename.Column("ParentId").OnTable("Company").To("TenantId");
    }
}