using DependencyInjection;
using Microsoft.Data.SqlClient;

namespace EmployeesSample;

internal static partial class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        StartLogging();

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm(DbInjection.InjectRepositoryServices()));
    }
}