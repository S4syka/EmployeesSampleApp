namespace EmployeesSample
{
    partial class BaseEmployeeForm
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
            Status_txt = new TextBox();
            Profession_txt = new TextBox();
            Lastname_txt = new TextBox();
            Salary_txt = new TextBox();
            PhoneNumber_txt = new TextBox();
            Firstname_txt = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // Status_txt
            // 
            Status_txt.BackColor = SystemColors.Info;
            Status_txt.Location = new Point(423, 107);
            Status_txt.Name = "Status_txt";
            Status_txt.Size = new Size(211, 23);
            Status_txt.TabIndex = 24;
            // 
            // Profession_txt
            // 
            Profession_txt.BackColor = SystemColors.Info;
            Profession_txt.Location = new Point(423, 56);
            Profession_txt.Name = "Profession_txt";
            Profession_txt.Size = new Size(211, 23);
            Profession_txt.TabIndex = 23;
            // 
            // Lastname_txt
            // 
            Lastname_txt.BackColor = SystemColors.Info;
            Lastname_txt.Location = new Point(423, 9);
            Lastname_txt.Name = "Lastname_txt";
            Lastname_txt.Size = new Size(211, 23);
            Lastname_txt.TabIndex = 22;
            // 
            // Salary_txt
            // 
            Salary_txt.BackColor = SystemColors.Info;
            Salary_txt.Location = new Point(110, 107);
            Salary_txt.Name = "Salary_txt";
            Salary_txt.Size = new Size(211, 23);
            Salary_txt.TabIndex = 21;
            // 
            // PhoneNumber_txt
            // 
            PhoneNumber_txt.BackColor = SystemColors.Info;
            PhoneNumber_txt.Location = new Point(110, 56);
            PhoneNumber_txt.Name = "PhoneNumber_txt";
            PhoneNumber_txt.Size = new Size(211, 23);
            PhoneNumber_txt.TabIndex = 20;
            // 
            // Firstname_txt
            // 
            Firstname_txt.BackColor = SystemColors.Info;
            Firstname_txt.Location = new Point(110, 9);
            Firstname_txt.Name = "Firstname_txt";
            Firstname_txt.Size = new Size(211, 23);
            Firstname_txt.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Firebrick;
            label4.Location = new Point(343, 59);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 18;
            label4.Text = "Profession";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Firebrick;
            label5.Location = new Point(343, 110);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 17;
            label5.Text = "Status";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Firebrick;
            label6.Location = new Point(343, 12);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 16;
            label6.Text = "Lastname";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Firebrick;
            label3.Location = new Point(10, 59);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 15;
            label3.Text = "Phone number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Firebrick;
            label2.Location = new Point(10, 110);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 14;
            label2.Text = "Salary";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(10, 12);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 13;
            label1.Text = "Firstname";
            // 
            // BaseEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(658, 217);
            Controls.Add(Status_txt);
            Controls.Add(Profession_txt);
            Controls.Add(Lastname_txt);
            Controls.Add(Salary_txt);
            Controls.Add(PhoneNumber_txt);
            Controls.Add(Firstname_txt);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BaseEmployeeForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox Status_txt;
        private TextBox Profession_txt;
        private TextBox Lastname_txt;
        private TextBox Salary_txt;
        private TextBox PhoneNumber_txt;
        private TextBox Firstname_txt;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}