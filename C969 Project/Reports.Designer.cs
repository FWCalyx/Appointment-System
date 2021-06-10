
namespace C969_Project
{
    partial class Reports
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userLabel = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportsButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.monthlyDate = new System.Windows.Forms.DateTimePicker();
            this.radioMonthType = new System.Windows.Forms.RadioButton();
            this.radioMonthCustomer = new System.Windows.Forms.RadioButton();
            this.radioMonthUser = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.reportTitle = new System.Windows.Forms.Label();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.scheduleReportsButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(750, 250);
            this.dataGridView1.TabIndex = 19;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userLabel.Location = new System.Drawing.Point(682, 17);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(0, 20);
            this.userLabel.TabIndex = 15;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(597, 22);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(79, 15);
            this.loginLabel.TabIndex = 14;
            this.loginLabel.Text = "Logged In As:";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(693, 440);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 30);
            this.label1.TabIndex = 12;
            this.label1.Text = "Generate Reports";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportsButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.monthlyDate);
            this.panel1.Controls.Add(this.radioMonthType);
            this.panel1.Controls.Add(this.radioMonthCustomer);
            this.panel1.Controls.Add(this.radioMonthUser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(18, 314);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 149);
            this.panel1.TabIndex = 23;
            // 
            // reportsButton
            // 
            this.reportsButton.Location = new System.Drawing.Point(191, 104);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Size = new System.Drawing.Size(131, 23);
            this.reportsButton.TabIndex = 24;
            this.reportsButton.Text = "Generate Report";
            this.reportsButton.UseVisualStyleBackColor = true;
            this.reportsButton.Click += new System.EventHandler(this.reportsButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Month:";
            // 
            // monthlyDate
            // 
            this.monthlyDate.CustomFormat = "MMMM yyyy";
            this.monthlyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.monthlyDate.Location = new System.Drawing.Point(184, 42);
            this.monthlyDate.Name = "monthlyDate";
            this.monthlyDate.Size = new System.Drawing.Size(138, 23);
            this.monthlyDate.TabIndex = 15;
            // 
            // radioMonthType
            // 
            this.radioMonthType.AutoSize = true;
            this.radioMonthType.Location = new System.Drawing.Point(12, 106);
            this.radioMonthType.Name = "radioMonthType";
            this.radioMonthType.Size = new System.Drawing.Size(65, 19);
            this.radioMonthType.TabIndex = 13;
            this.radioMonthType.Text = "By Type";
            this.radioMonthType.UseVisualStyleBackColor = true;
            // 
            // radioMonthCustomer
            // 
            this.radioMonthCustomer.AutoSize = true;
            this.radioMonthCustomer.Location = new System.Drawing.Point(12, 76);
            this.radioMonthCustomer.Name = "radioMonthCustomer";
            this.radioMonthCustomer.Size = new System.Drawing.Size(93, 19);
            this.radioMonthCustomer.TabIndex = 12;
            this.radioMonthCustomer.Text = "By Customer";
            this.radioMonthCustomer.UseVisualStyleBackColor = true;
            // 
            // radioMonthUser
            // 
            this.radioMonthUser.AutoSize = true;
            this.radioMonthUser.Checked = true;
            this.radioMonthUser.Location = new System.Drawing.Point(12, 46);
            this.radioMonthUser.Name = "radioMonthUser";
            this.radioMonthUser.Size = new System.Drawing.Size(64, 19);
            this.radioMonthUser.TabIndex = 11;
            this.radioMonthUser.TabStop = true;
            this.radioMonthUser.Text = "By User";
            this.radioMonthUser.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(107, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Monthly Reports";
            // 
            // reportTitle
            // 
            this.reportTitle.AutoSize = true;
            this.reportTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reportTitle.Location = new System.Drawing.Point(309, 10);
            this.reportTitle.Name = "reportTitle";
            this.reportTitle.Size = new System.Drawing.Size(0, 30);
            this.reportTitle.TabIndex = 24;
            // 
            // userComboBox
            // 
            this.userComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Location = new System.Drawing.Point(78, 45);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(178, 23);
            this.userComboBox.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "User:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.scheduleReportsButton);
            this.panel2.Controls.Add(this.userComboBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(396, 314);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 149);
            this.panel2.TabIndex = 27;
            // 
            // scheduleReportsButton
            // 
            this.scheduleReportsButton.Location = new System.Drawing.Point(149, 104);
            this.scheduleReportsButton.Name = "scheduleReportsButton";
            this.scheduleReportsButton.Size = new System.Drawing.Size(131, 23);
            this.scheduleReportsButton.TabIndex = 25;
            this.scheduleReportsButton.Text = "Generate Report";
            this.scheduleReportsButton.UseVisualStyleBackColor = true;
            this.scheduleReportsButton.Click += new System.EventHandler(this.scheduleReportsButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(97, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 21);
            this.label5.TabIndex = 25;
            this.label5.Text = "Full Schedule";
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 486);
            this.Controls.Add(this.reportTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Name = "Reports";
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker monthlyDate;
        private System.Windows.Forms.RadioButton radioMonthType;
        private System.Windows.Forms.RadioButton radioMonthCustomer;
        private System.Windows.Forms.RadioButton radioMonthUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button reportsButton;
        private System.Windows.Forms.Label reportTitle;
        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button scheduleReportsButton;
        private System.Windows.Forms.Label label5;
    }
}