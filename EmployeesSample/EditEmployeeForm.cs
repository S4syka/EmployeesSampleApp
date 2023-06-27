using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesSample;

/// <summary>
/// Form for editing employee details.
/// </summary>
public partial class EditEmployeeForm : BaseEmployeeForm
{
    private MainForm _mainForm;

    private Employee _employee;

    private bool _editMode;

    public EditEmployeeForm(MainForm mainForm, Employee employee, bool editMode = false) : base()
    {
        InitializeComponent();
        _mainForm = mainForm;
        _employee = employee;
        _editMode = editMode;
    }

    /// <summary>
    /// Starts edit mode and enables/disables controls accordingly.
    /// </summary>
    /// <param name="mode"></param>
    public void StartEditMode(bool mode = true)
    {
        ChangeTextBoxEnable(mode);
        Save_btn.Enabled = mode;
        Edit_btn.Enabled = !mode;
        Delete_btn.Enabled = !mode;
    }

    /// <summary>
    /// Saves the employee data change to the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Save_btn_Click(object sender, EventArgs e)
    {
        Employee employee = new();
        if (IsValidInput())
        {
            employee = ReadEmployeeData();
            employee.Id = _employee.Id;
            _mainForm.UpdateEmployee(employee);
            Close();
        }
    }

    /// <summary>
    /// Starts edit mode and enables/disables controls accordingly.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Edit_btn_Click(object sender, EventArgs e)
    {
        _editMode = true;
        StartEditMode();
    }

    /// <summary>
    /// Deletes the employee from the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Delete_btn_Click(object sender, EventArgs e)
    {
        _mainForm.DeleteEmployee(_employee);
        Close();
    }

    /// <summary>
    /// Fills in the employee data into the form and starts edit mode if necessary.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void EditEmployeeDetailsForm_Load(object sender, EventArgs e)
    {
        FillInEmployeeData(_employee);
        StartEditMode(_editMode);
    }

    /// <summary>
    /// Enables/disables the main form when this form is loaded/closed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void EditEmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        _mainForm.Enabled = true;
    }
}
