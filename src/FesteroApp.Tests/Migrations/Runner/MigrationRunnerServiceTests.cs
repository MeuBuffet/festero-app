using FesteroApp.Migrations.Runner;
using Microsoft.Data.SqlClient;

namespace FesteroApp.Tests.Migrations.Runner
{
    public class MigrationRunnerServiceTests
    {
        [Test]
        public void Execute_WithInvalidConnection_ThrowsSqlException()
        {
            var invalidConnection = "Server=invalid;Database=not_exists;Trusted_Connection=True;";

            Assert.Throws<SqlException>(() =>
            {
                MigrationRunnerService.Execute(invalidConnection);
            });
        }
    }
}