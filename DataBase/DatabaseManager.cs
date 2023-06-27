using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DataBase;

/// <summary>
/// Ensures that the database is created and initialized.
/// </summary>
public class DatabaseManager
{
    [Required]
    public string ServerName { get; private set; }

    [Required]
    public string DbName { get; private set; }

    [Required]
    public string ScriptsAddress { get; private set; }


    public DatabaseManager(string serverName, string dbName, string scriptsAddress)
    {
        ServerName = serverName;
        DbName = dbName;
        ScriptsAddress = scriptsAddress;
    }

    /// <summary>
    /// Initializes the database.
    /// </summary>
    public void InitDb()
    {
        if (!DatabaseExists())
        {
            string generateDbPath = Path.Combine(Environment.CurrentDirectory, ScriptsAddress, "EmployeeSampleBuild.sql");
            Trace.WriteLine($"Started creating new database: {DbName}");
            try
            {
                ExecuteSqlScript(generateDbPath);
                Trace.WriteLine($"Database created successfully: {DbName}");
            }
            catch(Exception ex)
            {
                Trace.WriteLine($"Error creating database: {DbName}.\n{ex.Message}");
                throw;
            }
        }
    }

    /// <summary>
    /// Executes a sql script.
    /// </summary>
    /// <param name="scriptFilePath">Path of script to execute</param>
    private void ExecuteSqlScript(string scriptFilePath)
    {
        string connectionString = $"Server ={ServerName}; Database=master; integrated security=true; encrypt=false";

        string script = File.ReadAllText(scriptFilePath).Replace("EmployeeSample", DbName);

        string[] commands = script.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            foreach (string command in commands)
            {
                if (!string.IsNullOrWhiteSpace(command))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Checks if database exists.
    /// </summary>
    /// <returns></returns>
    private bool DatabaseExists()
    {
        string connectionString = $"Server={ServerName};Database=master;integrated security = true; encrypt = false";

        string queryString = $"SELECT database_id FROM sys.databases WHERE Name = '{DbName}';";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            var result = command.ExecuteScalar();
            return result != null;
        }
    }

    /// <summary>
    /// Returns database connection string
    /// </summary>
    /// <returns></returns>
    public string GetConnectionString()
    {
        return $"Server={ServerName};Database={DbName};integrated security = true; encrypt = false";
    }
}
