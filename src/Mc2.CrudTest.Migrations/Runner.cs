using System.IO;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Migrations;

internal class Runner
{
    internal static void Main(string[] args)
    {
        string connectionString = GetConnectionString();
        CreateDatabase(connectionString);
        IMigrationRunner runner = CreateRunner(connectionString);
        runner.MigrateUp();
    }

    private static void CreateDatabase(string connectionString)
    {
        string databaseName = GetDatabaseName(connectionString);
        string masterConnectionString =
            ChangeDatabaseName(connectionString, "master");
        string commandScript =
            $"if db_id(N'{databaseName}') is null create database [{databaseName}]";

        using SqlConnection connection =
            new SqlConnection(masterConnectionString);
        connection.Open();
        using (SqlCommand command = new SqlCommand(commandScript, connection))
        {
            command.ExecuteNonQuery();
        }

        connection.Close();
    }

    private static string ChangeDatabaseName(string connectionString,
        string databaseName)
    {
        SqlConnectionStringBuilder csb =
            new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = databaseName
            };
        return csb.ConnectionString;
    }

    private static string GetDatabaseName(string connectionString)
    {
        return new SqlConnectionStringBuilder(connectionString)
            .InitialCatalog;
    }

    private static IMigrationRunner CreateRunner(string connectionString)
    {
        ServiceProvider container = new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(_ => _
                .AddSqlServer()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(Runner).Assembly).For.All())
            .AddSingleton(new MigrationSettings
                { ConnectionString = connectionString })
            .AddLogging(_ => _.AddFluentMigratorConsole())
            .BuildServiceProvider();
        return container.GetRequiredService<IMigrationRunner>();
    }

    private static string GetConnectionString()
    {
        // var isDevelopment = GetDevelopmentUsageValue();
        // if (isDevelopment)
        return GetDevelopmentConnectionString();
        // var connectionString = Environment.GetEnvironmentVariable
        // ("CONNECTION_STRING", EnvironmentVariableTarget.Process);
        // return connectionString;
    }

    private static string GetDevelopmentConnectionString()
    {
        IConfigurationRoot configurations = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json", true, true)
            .AddEnvironmentVariables()
            .Build();

        return configurations["ConnectionString"];
    }

    public static bool GetDevelopmentUsageValue()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false).Build();
        return bool.Parse(config["IsDevelopment"]);
    }
}

public class MigrationSettings
{
    public string ConnectionString { get; set; }
}