using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DataBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace DependencyInjection;

/// <summary>
/// Dependency injection class for the database.
/// </summary>
public static class DbInjection
{
    private static IConfiguration _configuration = GetConfiguration();

    /// <summary>
    /// Injects the repository services and returns the service provider.
    /// </summary>
    /// <returns></returns>
    public static IServiceProvider InjectRepositoryServices()
    {
        string connectionString = SetUpDB();

        IServiceProvider serviceProvider = new ServiceCollection()
            .AddSingleton<IEmployeeRepository, EmployeeRepository>()
            .AddSingleton<DbConnectionStringBuilder>(new DbConnectionStringBuilder { ConnectionString = connectionString })
            .BuildServiceProvider();

        return serviceProvider;
    }

    /// <summary>
    /// Sets up the database and returns the connection string.
    /// </summary>
    /// <returns></returns>
    private static string SetUpDB()
    {
        DatabaseManager dbManager = new DatabaseManager(_configuration["DbConfig:ServerName"]!, _configuration["DbConfig:DbName"]!, _configuration["SqlScripts"]!);
        dbManager.InitDb();
        return dbManager.GetConnectionString();
    }

    /// <summary>
    /// Returns the configuration for appsettings.json
    /// </summary>
    /// <returns></returns>
    private static IConfiguration GetConfiguration()
    {
        return new ConfigurationBuilder()
            .AddJsonFile(Path.Combine("Settings", "appsettings.json"), optional: false, reloadOnChange: true)
            .Build();
    }
}
