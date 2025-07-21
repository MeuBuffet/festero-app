using FluentMigrator.Runner;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FesteroApp.Migrations;

internal class Program
{
    public static int Main(string[] args)
    {
        var app = new CommandLineApplication();
        app.HelpOption();

        var taskOption = app.Option<string>(
            "-t|--task <TASK>",
            "The task you want FluentMigrator to perform. Available choices are: 'up' or 'down'. Default is 'up'.",
            CommandOptionType.SingleOrNoValue);
        taskOption.DefaultValue = Options.Up;

        var versionOptions = app.Option<long>(
            "-v|--version <VERSION>",
            "The specific version to migrate. Default is 0, which will run all migrations.",
            CommandOptionType.SingleValue);
        versionOptions.DefaultValue = 0;

        var environmentOptions = app.Option<string>(
            "-e|--environment <ENVIRONMENT>",
            "The specific version to migrate. Default is 'Development', which will run all migrations.",
            CommandOptionType.SingleValue);
        environmentOptions.DefaultValue = "";

        app.OnExecute(
            () =>
            {
                string task = Options.Up;
                if (taskOption.HasValue())
                    task = taskOption.Value()?.ToLower()!;

                long version = 0;
                if (versionOptions.HasValue())
                    version = Convert.ToInt64(versionOptions.Value());


                using var host = Host.CreateDefaultBuilder(args)
                    .UseEnvironment(environmentOptions.Value()!)
                    .ConfigureServices((host, services) =>
                    {
                        services
                            .AddFluentMigratorCore()
                            .ConfigureRunner(rb => rb
                                .AddSqlServer()
                                .WithGlobalConnectionString(host.Configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString"))
                                .ScanIn(typeof(Program).Assembly).For.Migrations()
                                .ScanIn(typeof(Program).Assembly).For.EmbeddedResources());

                    }).Build();

                var runner = host.Services.GetRequiredService<IMigrationRunner>();

                switch (task)
                {
                    case Options.Up:
                    {
                        if (version > 0)
                            runner.MigrateUp(version);
                        else
                            runner.MigrateUp();

                        break;
                    }
                    case Options.Down:
                    {
                        if (version <= 0)
                            throw new Exception("The task you want FluentMigrator to perform. The version is required to task 'down'.");

                        runner.MigrateDown(version);
                        break;
                    }
                    default:
                    {
                        throw new Exception("The task you want FluentMigrator to perform. Available choices are: 'up' or 'down'. Default is 'up'.");
                    }
                }

                return 0;
            });

        return app.Execute(args);
    }

    public class Options
    {
        public const string Up = "up";
        public const string Down = "down";
    }
}