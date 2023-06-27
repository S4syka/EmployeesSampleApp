using DataAccessLayer.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EmployeesSample;

/// <summary>
/// Base form containing common methods and textboxes required for employee details.
/// </summary>
public partial class BaseEmployeeForm : Form
{
    public BaseEmployeeForm()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Checks if input is valid.
    /// </summary>
    /// <returns></returns>
    protected bool IsValidInput()
    {
        return true switch
        {
            _ when Firstname_txt.Text.IsNullOrEmpty() => OpenEmptyDataMessageBox("Firstname"),
            _ when Lastname_txt.Text.IsNullOrEmpty() => OpenEmptyDataMessageBox("Lastname"),
            _ when PhoneNumber_txt.Text.IsNullOrEmpty() => OpenEmptyDataMessageBox("Phone number"),
            _ when Profession_txt.Text.IsNullOrEmpty() => OpenEmptyDataMessageBox("Profession"),
            _ when Salary_txt.Text.IsNullOrEmpty() => OpenEmptyDataMessageBox("Salary"),
            _ when !decimal.TryParse(Salary_txt.Text, out _) => OpenInvalidDataMessageBox("Salary"),
            _ when Status_txt.Text.IsNullOrEmpty() => OpenEmptyDataMessageBox("Status"),
            _ => true
        };
    }

    /// <summary>
    /// Fill in textboxes with employee data.
    /// </summary>
    /// <param name="employee"></param>
    protected void FillInEmployeeData(Employee employee)
    {
        Firstname_txt.Text = employee.Firstname;
        Lastname_txt.Text = employee.Lastname;
        PhoneNumber_txt.Text = employee.PhoneNumber;
        Salary_txt.Text = employee.Salary.ToString();
        Status_txt.Text = employee.Status;
        Profession_txt.Text = employee.Profession;
    }

    /// <summary>
    /// Reads and returns employee data from textboxes.
    /// </summary>
    /// <returns></returns>
    protected Employee ReadEmployeeData()
    {
        return new Employee()
        {
            Firstname = Firstname_txt.Text,
            Lastname = Lastname_txt.Text,
            PhoneNumber = PhoneNumber_txt.Text,
            Salary = decimal.Parse(Salary_txt.Text),
            Status = Status_txt.Text,
            Profession = Profession_txt.Text
        };
    }

    /// <summary>
    /// Opens messagebox with information about empty data.
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    protected bool OpenEmptyDataMessageBox(string field)
    {
        MessageBox.Show($"Please input some data in {field}.", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return false;
    }

    /// <summary>
    /// Opens messagebox with information about invalid data.
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    protected bool OpenInvalidDataMessageBox(string field)
    {
        MessageBox.Show($"Data in {field} isn't correct type.", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return false;
    }

    /// <summary>
    /// Makes textboxes enabled or disabled.
    /// </summary>
    /// <param name="enable"></param>
    protected void ChangeTextBoxEnable(bool enable = false)
    {
        Firstname_txt.Enabled = enable;
        Lastname_txt.Enabled = enable;
        PhoneNumber_txt.Enabled = enable;
        Salary_txt.Enabled = enable;
        Status_txt.Enabled = enable;
        Profession_txt.Enabled = enable;
    }
}
