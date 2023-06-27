namespace EmployeesSample
{
    partial class CreateEmployeeForm
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
            Save_btn = new Button();
            SuspendLayout();
            // 
            // Save_btn
            // 
            Save_btn.Location = new Point(504, 152);
            Save_btn.Name = "Save_btn";
            Save_btn.Size = new Size(130, 32);
            Save_btn.TabIndex = 25;
            Save_btn.Text = "Save";
            Save_btn.UseVisualStyleBackColor = true;
            Save_btn.Click += Save_btn_Click;
            // 
            // CreateEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 198);
            Controls.Add(Save_btn);
            Name = "CreateEmployeeForm";
            Text = "New employee entry";
            FormClosed += CreateEmployeeForm_FormClosed;
            Load += CreateEmployeeForm_Load;
            Controls.SetChildIndex(Save_btn, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Save_btn;
    }
}