using FluentMigrator;

namespace FesteroApp.Migrations.Versions;

[Migration(202507242106)]
public class AlterTableUserAlterColumnsToNullable : Migration
{
    public override void Up()
    {
        Alter.Table("User").AlterColumn("Phone").AsString(20).Nullable();
        Alter.Table("User").AlterColumn("Street").AsString(150).Nullable();
        Alter.Table("User").AlterColumn("Number").AsString(10).Nullable();
        Alter.Table("User").AlterColumn("Complement").AsString(150).Nullable();
        Alter.Table("User").AlterColumn("Neighborhood").AsString(150).Nullable();
        Alter.Table("User").AlterColumn("PostalCode").AsString(10).Nullable();
        Alter.Table("User").AlterColumn("City").AsString(150).Nullable();
        Alter.Table("User").AlterColumn("State").AsString(50).Nullable();
    }

    public override void Down()
    {
        Alter.Table("User").AlterColumn("Phone").AsString(20).NotNullable();
        Alter.Table("User").AlterColumn("Street").AsString(150).NotNullable();
        Alter.Table("User").AlterColumn("Number").AsString(10).NotNullable();
        Alter.Table("User").AlterColumn("Complement").AsString(150).NotNullable();
        Alter.Table("User").AlterColumn("Neighborhood").AsString(150).NotNullable();
        Alter.Table("User").AlterColumn("PostalCode").AsString(10).NotNullable();
        Alter.Table("User").AlterColumn("City").AsString(150).NotNullable();
        Alter.Table("User").AlterColumn("State").AsString(50).NotNullable();
    }
}