using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSample.Paging;

/// <summary>
/// Controls the data paging and filtering for employee repisitory.
/// </summary>
internal class EmployeeDataViewManager
{
    [Required]
    private IEmployeeRepository _employeeRepository;

    private int _employeeCount;

    public int PageSize { get; private set; }

    public int PageCount { get; private set; }

    public int Page { get; private set; } = 1;

    public int EmployeeCount  => _employeeRepository.Employees().Value.Count();

    public BindingSource BindingSourceEmployees { get; private set; } = new();

    public BindingSource BindingSourceProfessions { get; private set; } = new();

    private Func<Employee, bool> Filter = (_ => true);

    public EmployeeDataViewManager(IEmployeeRepository employeeRepository, int pageSize = 10)
    {
        _employeeRepository = employeeRepository;
        PageSize = pageSize;
        Load();
    }

    /// <summary>
    /// Inserts new employee into the repository.
    /// </summary>
    /// <param name="employee"></param>
    public void CreateEmployee(Employee employee)
    {
        employee.Id = _employeeRepository.Create(employee);
        Load();
    }

    /// <summary>
    /// Updates the employee in the repository.
    /// </summary>
    /// <param name="employee"></param>
    public void UpdateEmployee(Employee employee)
    {
        _employeeRepository.Update(employee);
        Load();
    }

    /// <summary>
    /// Deletes the employee from the repository.
    /// </summary>
    /// <param name="employee"></param>
    public void DeleteEmployee(Employee employee)
    {
        _employeeRepository.Delete(employee);
        Load();
    }

    /// <summary>
    /// Loads the page with the given index.
    /// </summary>
    /// <param name="page"></param>
    public void LoadPage(int page)
    {
        Page = page;
        Load();
    }

    /// <summary>
    /// Loads next page.
    /// </summary>
    public void LoadNextPage()
    {
        LoadPage(++Page);
    }

    /// <summary>
    /// Loads Previus page.
    /// </summary>
    public void LoadPreviousPage()
    {
        LoadPage(--Page);
    }

    /// <summary>
    /// Loads current employee data in BindingSources for professions and employees.
    /// </summary>
    public void Load()
    {
        BindingSourceEmployees.DataSource = GetCurrentPage();
        var professions = _employeeRepository.Employees().Value.Select(e => e.Profession).ToHashSet().ToList();
        professions.Insert(0, string.Empty);
        BindingSourceProfessions.DataSource = professions;
    }

    /// <summary>
    /// Returns the current page of employees.
    /// </summary>
    /// <returns></returns>
    private List<Employee> GetCurrentPage()
    {
        List<Employee> employees = _employeeRepository.Employees().Value.Where(Filter).ToList();
        employees.Reverse();
        _employeeCount = employees.Count();
        ResetPageProperties();

        return employees.GetRange((Page - 1) * PageSize, Math.Min(_employeeCount - (Page - 1) * PageSize, PageSize));
    }

    /// <summary>
    /// Resets the page properties: PageCount, Page.
    /// </summary>
    private void ResetPageProperties()
    {
        PageCount = _employeeCount / PageSize + (_employeeCount % PageSize > 0 ? 1 : 0);
        Page = Math.Min(PageCount, Page);
        Page = Math.Max(1, Page);
    }

    /// <summary>
    /// Changes filtering delegate for employees.
    /// </summary>
    /// <param name="filter"></param>
    public void ChangeFilter(Func<Employee,bool> filter)
    {
        Filter = filter;
        Page = 1;
        Load();
    }

    /// <summary>
    /// Updates the page size and loads current page.
    /// </summary>
    /// <param name="pageSize"></param>
    public void ChangePageSize(int pageSize)
    {
        PageSize = pageSize;
        LoadPage(0);
    }
}
