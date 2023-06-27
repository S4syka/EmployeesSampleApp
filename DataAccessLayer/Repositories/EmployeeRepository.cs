using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;

namespace DataAccessLayer.Repositories;

/// <summary>
/// Employee repository
/// </summary>
public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(DbConnectionStringBuilder connectionBuilder) : base(connectionBuilder)
    {
    }

    /// <summary>
    /// Loads all employees lazily.
    /// </summary>
    /// <returns></returns>
    public Lazy<IEnumerable<Employee>> Employees() => new Lazy<IEnumerable<Employee>>(Load);
}