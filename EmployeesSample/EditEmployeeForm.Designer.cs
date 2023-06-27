namespace EmployeesSample
{
    partial class EditEmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Edit_btn = new Button();
            Save_btn = new Button();
            Delete_btn = new Button();
            SuspendLayout();
            // 
            // Edit_btn
            // 
            Edit_btn.BackColor = Color.AntiqueWhite;
            Edit_btn.BackgroundImageLayout = ImageLayout.None;
            Edit_btn.FlatStyle = FlatStyle.System;
            Edit_btn.Location = new Point(368, 163);
            Edit_btn.Name = "Edit_btn";
            Edit_btn.Size = new Size(130, 32);
            Edit_btn.TabIndex = 27;
            Edit_btn.Text = "Edit";
            Edit_btn.UseVisualStyleBackColor = false;
            Edit_btn.Click += Edit_btn_Click;
            // 
            // Save_btn
            // 
            Save_btn.Enabled = false;
            Save_btn.Location = new Point(504, 163);
            Save_btn.Name = "Save_btn";
            Save_btn.Size = new Size(130, 32);
            Save_btn.TabIndex = 28;
            Save_btn.Text = "Save";
            Save_btn.UseVisualStyleBackColor = true;
            Save_btn.Click += Save_btn_Click;
            // 
            // Delete_btn
            // 
            Delete_btn.BackgroundImageLayout = ImageLayout.None;
            Delete_btn.Location = new Point(10, 163);
            Delete_btn.Name = "Delete_btn";
            Delete_btn.Size = new Size(130, 32);
            Delete_btn.TabIndex = 29;
            Delete_btn.Text = "Delete employee";
            Delete_btn.UseVisualStyleBackColor = true;
            Delete_btn.Click += Delete_btn_Click;
            // 
            // EditEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 215);
            Controls.Add(Delete_btn);
            Controls.Add(Save_btn);
            Controls.Add(Edit_btn);
            Name = "EditEmployeeForm";
            Text = "Employee details";
            FormClosed += EditEmployeeForm_FormClosed;
            Load += EditEmployeeDetailsForm_Load;
            Controls.SetChildIndex(Edit_btn, 0);
            Controls.SetChildIndex(Save_btn, 0);
            Controls.SetChildIndex(Delete_btn, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Edit_btn;
        private Button Save_btn;
        private Button Delete_btn;
    }
}