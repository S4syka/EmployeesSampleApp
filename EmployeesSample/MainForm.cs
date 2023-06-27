using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using EmployeesSample.Paging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace EmployeesSample;

/// <summary>
/// Main form of the application.
/// </summary>
public partial class MainForm : Form
{
    [Required]
    private IEmployeeRepository _employeeRepository;

    private EmployeeDataViewManager _dataViewManager;

    public MainForm(IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

        _employeeRepository = serviceProvider.GetService<IEmployeeRepository>()!;
        _dataViewManager = new(_employeeRepository);

        if (_employeeRepository is null)
        {
            throw new InvalidOperationException("Failed to resolve IEmployeeRepository. Ensure it has been registered in the service collection.");
        }

        InitializeComponent();
    }

    /// <summary>
    /// Inserts new employee into the repository.
    /// </summary>
    /// <param name="employee"></param>
    public void CreateEmployee(Employee employee)
    {
        _dataViewManager.CreateEmployee(employee);
    }

    /// <summary>
    /// Updates the employee in the repository.
    /// </summary>
    /// <param name="employee"></param>
    public void UpdateEmployee(Employee employee)
    {
        _dataViewManager.UpdateEmployee(employee);
    }

    /// <summary>
    /// Deletes the employee from the repository.
    /// </summary>
    /// <param name="employee"></param>
    public void DeleteEmployee(Employee employee)
    {
        _dataViewManager.DeleteEmployee(employee);
    }

    /// <summary>
    /// Sets up the columns of the DataGridView.
    /// </summary>
    private void SetUpDataGridView()
    {
        DataGridViewButtonColumn buttonDeleteColumn = new DataGridViewButtonColumn();
        buttonDeleteColumn.Name = "Delete";
        buttonDeleteColumn.HeaderText = "Delete";
        buttonDeleteColumn.Text = "Delete";
        buttonDeleteColumn.UseColumnTextForButtonValue = true;

        if (dataGridView.Columns["Delete"] == null)
            dataGridView.Columns.Add(buttonDeleteColumn);

        DataGridViewButtonColumn buttonEditColumn = new DataGridViewButtonColumn();
        buttonEditColumn.Name = "Edit";
        buttonEditColumn.HeaderText = "Edit";
        buttonEditColumn.Text = "Edit";
        buttonEditColumn.UseColumnTextForButtonValue = true;

        if (dataGridView.Columns["Edit"] == null)
            dataGridView.Columns.Add(buttonEditColumn);

        if (dataGridView.Columns["id"] != null)
        {
            dataGridView.Columns["id"].Visible = false;
        }
        if (dataGridView.Columns["PhoneNumber"] != null)
        {
            dataGridView.Columns["PhoneNumber"].Visible = false;
        }

        EmployeeCount_lbl.Text = $"Employees: {_dataViewManager.EmployeeCount}";
    }

    /// <summary>
    /// Loads the data from EmployeeDataViewManager into the DataGridView.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MainForm_Load(object sender, EventArgs e)
    {
        dataGridView.DataSource = _dataViewManager.BindingSourceEmployees;
        Profession_box.DataSource = _dataViewManager.BindingSourceProfessions;
    }

    /// <summary>
    /// Opens CreateEmployeeForm for creating a new employee.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Create_btn_Click(object sender, EventArgs e)
    {
        CreateEmployeeForm newEmployee = new(this);
        newEmployee.Show();
    }

    /// <summary>
    /// Opens EditEmployeeForm for editing the selected employee.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex == -1)
        {
            return;
        }

        BindingSource employees = (BindingSource)dataGridView.DataSource;
        EditEmployeeForm details = new(this, (Employee)employees[e.RowIndex]);
        details.Show();
    }

    /// <summary>
    /// Changes _dataViewManager's filter according to the filters set in the form.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Filter_btn_Click(object sender, EventArgs e)
    {
        if (!RangeMin_txt.Text.IsNullOrEmpty() && !decimal.TryParse(RangeMin_txt.Text, out _))
        {
            MessageBox.Show($"Data in min range isn't correct type.", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (!RangeMax_txt.Text.IsNullOrEmpty() && !decimal.TryParse(RangeMax_txt.Text, out _))
        {
            MessageBox.Show($"Data in max range isn't correct type.", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _dataViewManager.ChangeFilter(em => FilterByFirstname(em) && FilterByLastname(em) && FilterByProfession(em) && FilterByMinSalary(em) && FilterByMaxSalary(em));
    }

    /// <summary>
    /// Updates the max page size of the _dataViewManager.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PageSize_txt_Leave(object sender, EventArgs e)
    {
        int pageSize;

        if (PageSize_txt.Text.IsNullOrEmpty())
        {
            PageSize_txt.Text = _dataViewManager.PageSize.ToString();
        }
        else if (!Int32.TryParse(PageSize_txt.Text, out pageSize))
        {
            MessageBox.Show($"Plese provide valid page size.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            _dataViewManager.ChangePageSize(pageSize);
        }
    }

    /// <summary>
    /// Updates the page index of the _dataViewManager.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NextPage_btn_Click(object sender, EventArgs e)
    {
        _dataViewManager.LoadNextPage();
    }

    /// <summary>
    /// Updates the page index of the _dataViewManager.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PreviousPage_btn_Click(object sender, EventArgs e)
    {
        _dataViewManager.LoadPreviousPage();
    }

    /// <summary>
    /// If possible updates the current page index of the _dataViewManager.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PageIndex_txt_Leave(object sender, EventArgs e)
    {
        int page;

        if (!Int32.TryParse(PageIndex_txt.Text, out page))
        {
            MessageBox.Show($"Plese provide valid page index.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            _dataViewManager.LoadPage(page);
        }
    }

    /// <summary>
    /// Opens new form for editing selected employee or deletes the selected employee.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex == -1)
        {
            return;
        }

        BindingSource employees = (BindingSource)dataGridView.DataSource;

        if (e.ColumnIndex == dataGridView.Columns["Delete"].Index)
        {
            DeleteEmployee((Employee)employees[e.RowIndex]);
        }
        else if (e.ColumnIndex == dataGridView.Columns["Edit"].Index)
        {
            EditEmployeeForm details = new(this, (Employee)employees[e.RowIndex], true);
            details.Show();
        }
    }

    /// <summary>
    /// Filters the employee by their FirstName.
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    private bool FilterByFirstname(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);

        if (FirstnameFilter_txt.Text.IsNullOrEmpty())
        {
            return true;
        }

        return employee.Firstname!.Contains(FirstnameFilter_txt.Text);
    }

    /// <summary>
    /// Filters the employee by their LastName.
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    private bool FilterByLastname(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);

        if (LastnameFilter_txt.Text.IsNullOrEmpty())
        {
            return true;
        }

        return employee.Lastname!.Contains(LastnameFilter_txt.Text);
    }

    /// <summary>
    /// Filters the employee by their Profession.
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    private bool FilterByProfession(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);

        if (Profession_box.Text.IsNullOrEmpty())
        {
            return true;
        }

        return employee.Profession!.Contains(Profession_box.Text);

    }

    /// <summary>
    /// Filters the employee by their min Salary.
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    private bool FilterByMinSalary(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);

        decimal min;

        if (RangeMin_txt.Text.IsNullOrEmpty())
        {
            return true;
        }

        decimal.TryParse(RangeMin_txt.Text, out min);
        return employee.Salary >= min;
    }

    /// <summary>
    /// Filters the employee by their max Salary.
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    private bool FilterByMaxSalary(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);

        decimal max;

        if (RangeMax_txt.Text.IsNullOrEmpty())
        {
            return true;
        }

        decimal.TryParse(RangeMax_txt.Text, out max);
        return employee.Salary <= max;
    }

    /// <summary>
    /// Updates page inde of the _dataViewManager and sets up the dataGridView.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        PageIndex_txt.Text = _dataViewManager.Page.ToString();
        SetUpDataGridView();
    }

    /// <summary>
    /// Updates the page size of the _dataViewManager.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PageSize_txt_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            PageSize_txt_Leave(sender, e);
        }
    }

    /// <summary>
    /// Updates the page index of the _dataViewManager.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PageIndex_txt_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            PageIndex_txt_Leave(sender, e);
        }
    }

    /// <summary>
    /// Selects all text in the PageSize_txt.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PageSize_txt_Click(object sender, EventArgs e)
    {
        PageSize_txt.SelectAll();
    }

    /// <summary>
    /// Selects all text in the PageIndex_txt.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PageIndex_txt_Click(object sender, EventArgs e)
    {
        PageIndex_txt.SelectAll();
    }
}