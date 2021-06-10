
namespace C969_Project
{
    partial class MainScreen
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.loginLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.customerButton = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioUnfilteredButton = new System.Windows.Forms.RadioButton();
            this.radioMonthButton = new System.Windows.Forms.RadioButton();
            this.radioWeekButton = new System.Windows.Forms.RadioButton();
            this.radioDayButton = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addAppointmentButton = new System.Windows.Forms.Button();
            this.editAppointmentButton = new System.Windows.Forms.Button();
            this.deleteAppointmentButton = new System.Windows.Forms.Button();
            this.reportsButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appointment Keeper";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(697, 526);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(597, 21);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(79, 15);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "Logged In As:";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userLabel.Location = new System.Drawing.Point(682, 16);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(0, 20);
            this.userLabel.TabIndex = 3;
            // 
            // customerButton
            // 
            this.customerButton.Location = new System.Drawing.Point(257, 526);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(131, 23);
            this.customerButton.TabIndex = 4;
            this.customerButton.Text = "Customer List";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.Click += new System.EventHandler(this.customerButton_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 387);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 5;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioUnfilteredButton);
            this.panel1.Controls.Add(this.radioMonthButton);
            this.panel1.Controls.Add(this.radioWeekButton);
            this.panel1.Controls.Add(this.radioDayButton);
            this.panel1.Location = new System.Drawing.Point(257, 387);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 104);
            this.panel1.TabIndex = 6;
            // 
            // radioUnfilteredButton
            // 
            this.radioUnfilteredButton.AutoSize = true;
            this.radioUnfilteredButton.Checked = true;
            this.radioUnfilteredButton.Location = new System.Drawing.Point(16, 77);
            this.radioUnfilteredButton.Name = "radioUnfilteredButton";
            this.radioUnfilteredButton.Size = new System.Drawing.Size(77, 19);
            this.radioUnfilteredButton.TabIndex = 3;
            this.radioUnfilteredButton.TabStop = true;
            this.radioUnfilteredButton.Text = "Unfiltered";
            this.radioUnfilteredButton.UseVisualStyleBackColor = true;
            this.radioUnfilteredButton.CheckedChanged += new System.EventHandler(this.radioUnfilteredButton_CheckedChanged);
            // 
            // radioMonthButton
            // 
            this.radioMonthButton.AutoSize = true;
            this.radioMonthButton.Location = new System.Drawing.Point(16, 52);
            this.radioMonthButton.Name = "radioMonthButton";
            this.radioMonthButton.Size = new System.Drawing.Size(89, 19);
            this.radioMonthButton.TabIndex = 2;
            this.radioMonthButton.Text = "Month View";
            this.radioMonthButton.UseVisualStyleBackColor = true;
            this.radioMonthButton.CheckedChanged += new System.EventHandler(this.radioMonthButton_CheckedChanged);
            // 
            // radioWeekButton
            // 
            this.radioWeekButton.AutoSize = true;
            this.radioWeekButton.Location = new System.Drawing.Point(16, 27);
            this.radioWeekButton.Name = "radioWeekButton";
            this.radioWeekButton.Size = new System.Drawing.Size(82, 19);
            this.radioWeekButton.TabIndex = 1;
            this.radioWeekButton.Text = "Week View";
            this.radioWeekButton.UseVisualStyleBackColor = true;
            this.radioWeekButton.CheckedChanged += new System.EventHandler(this.radioWeekButton_CheckedChanged);
            // 
            // radioDayButton
            // 
            this.radioDayButton.AutoSize = true;
            this.radioDayButton.Location = new System.Drawing.Point(16, 2);
            this.radioDayButton.Name = "radioDayButton";
            this.radioDayButton.Size = new System.Drawing.Size(73, 19);
            this.radioDayButton.TabIndex = 0;
            this.radioDayButton.Text = "Day View";
            this.radioDayButton.UseVisualStyleBackColor = true;
            this.radioDayButton.CheckedChanged += new System.EventHandler(this.radioDayButton_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(750, 325);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // addAppointmentButton
            // 
            this.addAppointmentButton.Location = new System.Drawing.Point(637, 387);
            this.addAppointmentButton.Name = "addAppointmentButton";
            this.addAppointmentButton.Size = new System.Drawing.Size(131, 23);
            this.addAppointmentButton.TabIndex = 8;
            this.addAppointmentButton.Text = "Add Appointment";
            this.addAppointmentButton.UseVisualStyleBackColor = true;
            this.addAppointmentButton.Click += new System.EventHandler(this.addAppointmentButton_Click);
            // 
            // editAppointmentButton
            // 
            this.editAppointmentButton.Enabled = false;
            this.editAppointmentButton.Location = new System.Drawing.Point(637, 416);
            this.editAppointmentButton.Name = "editAppointmentButton";
            this.editAppointmentButton.Size = new System.Drawing.Size(131, 23);
            this.editAppointmentButton.TabIndex = 9;
            this.editAppointmentButton.Text = "Edit Appointment";
            this.editAppointmentButton.UseVisualStyleBackColor = true;
            this.editAppointmentButton.Click += new System.EventHandler(this.editAppointmentButton_Click);
            // 
            // deleteAppointmentButton
            // 
            this.deleteAppointmentButton.Enabled = false;
            this.deleteAppointmentButton.Location = new System.Drawing.Point(637, 445);
            this.deleteAppointmentButton.Name = "deleteAppointmentButton";
            this.deleteAppointmentButton.Size = new System.Drawing.Size(131, 23);
            this.deleteAppointmentButton.TabIndex = 10;
            this.deleteAppointmentButton.Text = "Delete Appointment";
            this.deleteAppointmentButton.UseVisualStyleBackColor = true;
            this.deleteAppointmentButton.Click += new System.EventHandler(this.deleteAppointmentButton_Click);
            // 
            // reportsButton
            // 
            this.reportsButton.Location = new System.Drawing.Point(257, 497);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Size = new System.Drawing.Size(131, 23);
            this.reportsButton.TabIndex = 11;
            this.reportsButton.Text = "Generate Reports";
            this.reportsButton.UseVisualStyleBackColor = true;
            this.reportsButton.Click += new System.EventHandler(this.reportsButton_Click);
            // 
            // timer1
            // 
            //this.timer1.Enabled = true;
            //this.timer1.Interval = 30000;
            //this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.reportsButton);
            this.Controls.Add(this.deleteAppointmentButton);
            this.Controls.Add(this.editAppointmentButton);
            this.Controls.Add(this.addAppointmentButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.customerButton);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label1);
            this.Name = "MainScreen";
            this.Text = "Main Screen";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button customerButton;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioMonthButton;
        private System.Windows.Forms.RadioButton radioWeekButton;
        private System.Windows.Forms.RadioButton radioDayButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addAppointmentButton;
        private System.Windows.Forms.Button editAppointmentButton;
        private System.Windows.Forms.Button deleteAppointmentButton;
        private System.Windows.Forms.Button reportsButton;
        private System.Windows.Forms.RadioButton radioUnfilteredButton;
        private System.Windows.Forms.Timer timer1;
    }
}