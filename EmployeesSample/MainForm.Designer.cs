namespace EmployeesSample
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            Create_btn = new Button();
            NameFilter_lbl = new Label();
            Lastname_lbl = new Label();
            FirstnameFilter_txt = new TextBox();
            LastnameFilter_txt = new TextBox();
            ProfessionFilter_lbl = new Label();
            SalaryFilter_lbl = new Label();
            Profession_box = new ComboBox();
            RangeMin_txt = new TextBox();
            RangeMax_txt = new TextBox();
            Filter_btn = new Button();
            PageIndex_txt = new TextBox();
            NextPage_btn = new Button();
            PreviousPage_btn = new Button();
            PageSize_txt = new TextBox();
            label1 = new Label();
            EmployeeCount_lbl = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.BackgroundColor = Color.Wheat;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.ImeMode = ImeMode.NoControl;
            dataGridView.Location = new Point(12, 138);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(744, 376);
            dataGridView.TabIndex = 0;
            dataGridView.CellClick += dataGridView_CellClick;
            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick;
            dataGridView.DataBindingComplete += dataGridView_DataBindingComplete;
            // 
            // Create_btn
            // 
            Create_btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Create_btn.Location = new Point(619, 20);
            Create_btn.Name = "Create_btn";
            Create_btn.Size = new Size(137, 48);
            Create_btn.TabIndex = 1;
            Create_btn.Text = "Create";
            Create_btn.UseVisualStyleBackColor = true;
            Create_btn.Click += Create_btn_Click;
            // 
            // NameFilter_lbl
            // 
            NameFilter_lbl.AutoSize = true;
            NameFilter_lbl.Location = new Point(12, 29);
            NameFilter_lbl.Name = "NameFilter_lbl";
            NameFilter_lbl.Size = new Size(59, 15);
            NameFilter_lbl.TabIndex = 2;
            NameFilter_lbl.Text = "Firstname";
            // 
            // Lastname_lbl
            // 
            Lastname_lbl.AutoSize = true;
            Lastname_lbl.Location = new Point(12, 85);
            Lastname_lbl.Name = "Lastname_lbl";
            Lastname_lbl.Size = new Size(58, 15);
            Lastname_lbl.TabIndex = 3;
            Lastname_lbl.Text = "Lastname";
            // 
            // FirstnameFilter_txt
            // 
            FirstnameFilter_txt.BackColor = SystemColors.Info;
            FirstnameFilter_txt.Location = new Point(76, 26);
            FirstnameFilter_txt.Name = "FirstnameFilter_txt";
            FirstnameFilter_txt.Size = new Size(100, 23);
            FirstnameFilter_txt.TabIndex = 4;
            // 
            // LastnameFilter_txt
            // 
            LastnameFilter_txt.BackColor = SystemColors.Info;
            LastnameFilter_txt.Location = new Point(76, 82);
            LastnameFilter_txt.Name = "LastnameFilter_txt";
            LastnameFilter_txt.Size = new Size(100, 23);
            LastnameFilter_txt.TabIndex = 5;
            // 
            // ProfessionFilter_lbl
            // 
            ProfessionFilter_lbl.AutoSize = true;
            ProfessionFilter_lbl.Location = new Point(289, 90);
            ProfessionFilter_lbl.Name = "ProfessionFilter_lbl";
            ProfessionFilter_lbl.Size = new Size(62, 15);
            ProfessionFilter_lbl.TabIndex = 6;
            ProfessionFilter_lbl.Text = "Profession";
            // 
            // SalaryFilter_lbl
            // 
            SalaryFilter_lbl.AutoSize = true;
            SalaryFilter_lbl.Location = new Point(289, 37);
            SalaryFilter_lbl.Name = "SalaryFilter_lbl";
            SalaryFilter_lbl.Size = new Size(38, 15);
            SalaryFilter_lbl.TabIndex = 7;
            SalaryFilter_lbl.Text = "Salary";
            // 
            // Profession_box
            // 
            Profession_box.BackColor = SystemColors.Info;
            Profession_box.FormattingEnabled = true;
            Profession_box.Location = new Point(374, 87);
            Profession_box.Name = "Profession_box";
            Profession_box.Size = new Size(121, 23);
            Profession_box.TabIndex = 8;
            // 
            // RangeMin_txt
            // 
            RangeMin_txt.BackColor = SystemColors.Info;
            RangeMin_txt.Location = new Point(374, 19);
            RangeMin_txt.Name = "RangeMin_txt";
            RangeMin_txt.Size = new Size(68, 23);
            RangeMin_txt.TabIndex = 9;
            // 
            // RangeMax_txt
            // 
            RangeMax_txt.BackColor = SystemColors.Info;
            RangeMax_txt.Location = new Point(374, 48);
            RangeMax_txt.Name = "RangeMax_txt";
            RangeMax_txt.Size = new Size(68, 23);
            RangeMax_txt.TabIndex = 10;
            // 
            // Filter_btn
            // 
            Filter_btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Filter_btn.Location = new Point(619, 85);
            Filter_btn.Name = "Filter_btn";
            Filter_btn.Size = new Size(137, 47);
            Filter_btn.TabIndex = 11;
            Filter_btn.Text = "Filter";
            Filter_btn.UseVisualStyleBackColor = true;
            Filter_btn.Click += Filter_btn_Click;
            // 
            // PageIndex_txt
            // 
            PageIndex_txt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PageIndex_txt.BackColor = SystemColors.Info;
            PageIndex_txt.Location = new Point(333, 523);
            PageIndex_txt.Name = "PageIndex_txt";
            PageIndex_txt.Size = new Size(59, 23);
            PageIndex_txt.TabIndex = 12;
            PageIndex_txt.TextAlign = HorizontalAlignment.Center;
            PageIndex_txt.Click += PageIndex_txt_Click;
            PageIndex_txt.KeyPress += PageIndex_txt_KeyPress;
            PageIndex_txt.Leave += PageIndex_txt_Leave;
            // 
            // NextPage_btn
            // 
            NextPage_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            NextPage_btn.Location = new Point(398, 523);
            NextPage_btn.Name = "NextPage_btn";
            NextPage_btn.Size = new Size(127, 23);
            NextPage_btn.TabIndex = 13;
            NextPage_btn.Text = "Next page";
            NextPage_btn.UseVisualStyleBackColor = true;
            NextPage_btn.Click += NextPage_btn_Click;
            // 
            // PreviousPage_btn
            // 
            PreviousPage_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PreviousPage_btn.Location = new Point(200, 523);
            PreviousPage_btn.Name = "PreviousPage_btn";
            PreviousPage_btn.Size = new Size(127, 23);
            PreviousPage_btn.TabIndex = 14;
            PreviousPage_btn.Text = "Previous page";
            PreviousPage_btn.UseVisualStyleBackColor = true;
            PreviousPage_btn.Click += PreviousPage_btn_Click;
            // 
            // PageSize_txt
            // 
            PageSize_txt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PageSize_txt.BackColor = SystemColors.Info;
            PageSize_txt.Location = new Point(712, 524);
            PageSize_txt.Name = "PageSize_txt";
            PageSize_txt.Size = new Size(44, 23);
            PageSize_txt.TabIndex = 15;
            PageSize_txt.Text = "10";
            PageSize_txt.TextAlign = HorizontalAlignment.Center;
            PageSize_txt.Click += PageSize_txt_Click;
            PageSize_txt.KeyPress += PageSize_txt_KeyPress;
            PageSize_txt.Leave += PageSize_txt_Leave;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(651, 527);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 16;
            label1.Text = "Page size";
            // 
            // EmployeeCount_lbl
            // 
            EmployeeCount_lbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            EmployeeCount_lbl.AutoSize = true;
            EmployeeCount_lbl.Location = new Point(12, 523);
            EmployeeCount_lbl.Name = "EmployeeCount_lbl";
            EmployeeCount_lbl.Size = new Size(13, 15);
            EmployeeCount_lbl.TabIndex = 17;
            EmployeeCount_lbl.Text = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(761, 555);
            Controls.Add(EmployeeCount_lbl);
            Controls.Add(label1);
            Controls.Add(PageSize_txt);
            Controls.Add(PreviousPage_btn);
            Controls.Add(NextPage_btn);
            Controls.Add(PageIndex_txt);
            Controls.Add(Filter_btn);
            Controls.Add(RangeMax_txt);
            Controls.Add(RangeMin_txt);
            Controls.Add(Profession_box);
            Controls.Add(SalaryFilter_lbl);
            Controls.Add(ProfessionFilter_lbl);
            Controls.Add(LastnameFilter_txt);
            Controls.Add(FirstnameFilter_txt);
            Controls.Add(Lastname_lbl);
            Controls.Add(NameFilter_lbl);
            Controls.Add(Create_btn);
            Controls.Add(dataGridView);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Employees information";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Button Create_btn;
        private Label NameFilter_lbl;
        private Label Lastname_lbl;
        private TextBox FirstnameFilter_txt;
        private TextBox LastnameFilter_txt;
        private Label ProfessionFilter_lbl;
        private Label SalaryFilter_lbl;
        private ComboBox Profession_box;
        private TextBox RangeMin_txt;
        private TextBox RangeMax_txt;
        private Button Filter_btn;
        private TextBox PageIndex_txt;
        private Button NextPage_btn;
        private Button PreviousPage_btn;
        private TextBox PageSize_txt;
        private Label label1;
        private Label EmployeeCount_lbl;
    }
}