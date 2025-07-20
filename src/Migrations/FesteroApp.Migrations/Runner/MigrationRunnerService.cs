using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace FesteroApp.Migrations.Runner
{
    public static class MigrationRunnerService
    {
        public static void Execute(string connectionString)
        {
            try
            {
                var serviceProvider = new ServiceCollection()
                    .AddFluentMigratorCore()
                    .ConfigureRunner(rb => rb
                        .AddSqlServer()
                        .WithGlobalConnectionString(connectionString)
                        .ScanIn(typeof(MigrationRunnerService).Assembly).For.Migrations())
                    .AddLogging(lb => lb.AddFluentMigratorConsole())
                    .BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                runner.MigrateUp();
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                throw;
            }
        }
    }
}