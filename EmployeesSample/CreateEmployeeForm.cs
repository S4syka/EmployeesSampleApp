using DataAccessLayer.Entities;

namespace EmployeesSample;

/// <summary>
/// Form for creating an new employee
/// </summary>
public partial class CreateEmployeeForm : BaseEmployeeForm
{
    private MainForm _mainForm;

    public CreateEmployeeForm(MainForm mainForm) : base()
    {
        InitializeComponent();
        _mainForm = mainForm;
    }

    /// <summary>
    /// Creates an employee and adds it to the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Save_btn_Click(object sender, EventArgs e)
    {
        Employee employee = new Employee();

        if (IsValidInput())
        {
            employee = ReadEmployeeData();
            _mainForm.CreateEmployee(employee);
            Close();
        }
    }

    /// <summary>
    /// Enables/disables main form when this form is opened/closed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CreateEmployeeForm_Load(object sender, EventArgs e)
    {
        _mainForm.Enabled = false;
    }

    /// <summary>
    /// Enables/disables main form when this form is opened/closed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CreateEmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        _mainForm.Enabled = true;
    }
}
