using FluentMigrator;

namespace FesteroApp.Migrations.Versions;

[Migration(202507232227)]
public class CreateUserCompanyTable : Migration
{
    public override void Up()
    {
        Create.Table("UserCompany")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("UserId").AsGuid().Nullable().ForeignKey("FK_UserCompany_User", "User", "Id")
            .WithColumn("CompanyId").AsGuid().Nullable().ForeignKey("FK_UserCompany_Company", "Company", "Id");
    }

    public override void Down()
    {
        Delete.Table("UserCompany");
    }
}