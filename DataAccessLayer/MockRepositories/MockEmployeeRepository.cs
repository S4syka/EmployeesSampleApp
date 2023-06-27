using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Mock;

/// <summary>
/// Mock repository for the Employee entity
/// </summary>
public class MockEmployeeRepository : IEmployeeRepository
{
    private int _index = 3;

    private List<Employee> _employees = new List<Employee>()
    {
        new Employee()
        {
            Id = 1,
            Firstname = "eke",
            Lastname = "bichi",
            PhoneNumber = "12332",
            Profession = "123321",
            Salary = 1000000M,
            Status = "ar vici ra aris es"
        },
        new Employee()
        {
            Id = 2,
            Firstname = "eke",
            Lastname = "bichuna",
            PhoneNumber = "12332",
            Profession = "123321",
            Salary = 2000000M,
            Status = "ar vici ra aris es"
        },
        new Employee()
        {
            Id = 3,
            Firstname = "ekeke",
            Lastname = "bichi",
            PhoneNumber = "12332",
            Profession = "123321",
            Salary = 3000000M,
            Status = "ar vici ra aris es"
        }
    };

    /// <summary>
    /// Creates a new employee
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public int Create(Employee entity)
    {
        _index++;
        entity.Id = _index;
        _employees.Add(entity);
        return _index;
    }

    /// <summary>
    /// Reads an employee by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Employee Read(int id)
    {
        return _employees.Where(e => e.Id == e.Id).Single();
    }

    /// <summary>
    /// Updates an employee with the given entity
    /// </summary>
    /// <param name="entity"></param>
    public void Update(Employee entity)
    {
        Delete(entity);
        _employees.Add(entity);
    }

    /// <summary>
    /// Deletes an employee with the given entity
    /// </summary>
    /// <param name="entity"></param>
    public void Delete(Employee entity)
    {
        _employees = _employees.Where(e => e.Id != entity.Id).ToList();
    }

    /// <summary>
    /// Loads all employees
    /// </summary>
    /// <returns></returns>
    public List<Employee> Load()
    {
        return _employees;
    }

    /// <summary>
    /// Lazily loads all employees.
    /// </summary>
    /// <returns></returns>
    public Lazy<IEnumerable<Employee>> Employees() => new Lazy<IEnumerable<Employee>>(Load);
}
