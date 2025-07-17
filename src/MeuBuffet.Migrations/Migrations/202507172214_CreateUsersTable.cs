using FluentMigrator;

namespace MeuBuffet.Migrations.Migrations
{
    [Migration(202507172214)]
    public class CreateUsersTable : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("Name").AsString(150).NotNullable()
                .WithColumn("Email").AsString(500).NotNullable()
                .WithColumn("Password").AsString(50).NotNullable()
                .WithColumn("CreatedOn").AsDateTime().NotNullable()
                .WithColumn("UpdateOn").AsDateTime().NotNullable()
                .WithColumn("DeleteOn").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Users");
        }
    }
}