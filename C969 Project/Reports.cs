// Reports.cs
// Form to generate reports.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Project
{
    public partial class Reports : Form
    {
        int userID;
        string userName;
        UCertifyDB HomeDB = new UCertifyDB();
        BindingList<Appointment> appointmentTable = new BindingList<Appointment>();
        BindingList<Customer> customerTable = new BindingList<Customer>();
        BindingList<User> userTable = new BindingList<User>();
        BindingList<Appointment> selectedTable = new BindingList<Appointment>();
        BindingList<string> typeTable = new BindingList<string>();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();


        public Reports(int id, string name)
        {
            InitializeComponent();
            userID = id;
            userName = name;
            HomeDB.fillAppointments(appointmentTable);
            HomeDB.fillCustomers(customerTable);
            HomeDB.fillUsers(userTable);
            HomeDB.fillList(typeTable);
            HomeDB.fillComboBox(userComboBox, "user", "userName");
            dt3.Clear();
            dt3.Columns.Add("Type of Appointment");
            dt3.Columns.Add("Number of Appointments");
            dt2.Clear();
            dt2.Columns.Add("Customer");
            dt2.Columns.Add("Number of Appointments");
            dt.Clear();
            dt.Columns.Add("Consultant");
            dt.Columns.Add("Number of Appointments");
        }
        // Exit button
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MainScreen Main = new MainScreen(userID, userName);
            Main.Show();
        }
        // Required field validation
        private void fieldValidate(string notblank)
        {
            if (notblank == "")
                throw new MissingFieldException();
        }
        // Generates report based on user selections
        private void reportsButton_Click(object sender, EventArgs e)
        {
            if (radioMonthUser.Checked == true)
            {
                reportTitle.Text = $"{monthlyDate.Text} User Report";
                dt.Clear();
                foreach (User user in userTable)
                {
                    int count = 0;
                    foreach (Appointment appt in appointmentTable)
                    {
                        if (appt.userId == user.userID && appt.Start.Month == monthlyDate.Value.Month && appt.Start.Year == monthlyDate.Value.Year)
                        {
                            count += 1;
                        }
                    }
                    dt.Rows.Add(new object[] { user.userName, count });
                }
                dataGridView1.DataSource = dt;

            }
            else if (radioMonthCustomer.Checked == true)
            {
                reportTitle.Text = $"{monthlyDate.Text} Customer Report";
                dt2.Clear();
                foreach (Customer customer in customerTable)
                {
                    int count = 0;
                    foreach (Appointment appt in appointmentTable)
                    {
                        if (appt.customerId == customer.customerID && appt.Start.Month == monthlyDate.Value.Month && appt.Start.Year == monthlyDate.Value.Year)
                        {
                            count += 1;
                        }
                    }
                    dt2.Rows.Add(new object[] { customer.customerName, count });
                }
                dataGridView1.DataSource = dt2;
            }
            else if (radioMonthType.Checked == true)
            {
                reportTitle.Text = $"{monthlyDate.Text} Type Report";
                dt3.Clear();
                foreach(string value in typeTable)
                {
                    int count = 0;
                    foreach (Appointment appt in appointmentTable)
                    {
                        if (value == appt.Type && appt.Start.Month == monthlyDate.Value.Month && appt.Start.Year == monthlyDate.Value.Year)
                        {
                            count += 1;
                        }
                    }
                    dt3.Rows.Add(new object[] { value, count });
                }
                dataGridView1.DataSource = dt3;

            }
        }
        // Generates schedule for selected user
        private void scheduleReportsButton_Click(object sender, EventArgs e)
        {
            selectedTable.Clear();
            reportTitle.Text = $"Full Schedule for {userComboBox.Text}";
            if (userComboBox.Text == "")
            {
                MessageBox.Show("Please select a consultant.");
                return;
            }
            else
            {
                int userNum = 0;
                foreach(User user in userTable)
                {
                    if (user.userName == userComboBox.Text)
                    {
                        userNum = user.userID;
                    }
                }
                foreach(Appointment appt in appointmentTable)
                {
                    if (appt.userId == userNum)
                    {
                        selectedTable.Add(appt);
                    }
                }
                dataGridView1.DataSource = selectedTable;
                formatDGV(dataGridView1);
            }
        }
        // Formats the datagridview to hide undesired columns.
        private void formatDGV(DataGridView dgv)
        {
            this.dataGridView1.Columns["appointmentId"].Visible = false;
            this.dataGridView1.Columns["customerId"].Visible = false;
            this.dataGridView1.Columns["userId"].Visible = false;
            this.dataGridView1.Columns["description"].Visible = false;
            this.dataGridView1.Columns["location"].Visible = false;
            this.dataGridView1.Columns["Url"].Visible = false;
            this.dataGridView1.Columns["End"].Visible = false;
            this.dataGridView1.Columns["CreateDate"].Visible = false;
            this.dataGridView1.Columns["CreatedBy"].Visible = false;
            this.dataGridView1.Columns["LastUpdate"].Visible = false;
            this.dataGridView1.Columns["LastUpdateBy"].Visible = false;
            this.dataGridView1.Columns["Start"].DisplayIndex = 0; ;
            this.dataGridView1.Columns["Start"].Width = 115;
            this.dataGridView1.Columns["Title"].DisplayIndex = 1;
            this.dataGridView1.Columns["Title"].Width = 335;
            this.dataGridView1.Columns["Contact"].DisplayIndex = 2;
            this.dataGridView1.Columns["Contact"].Width = 150;
            this.dataGridView1.Columns["Type"].DisplayIndex = 3;
            this.dataGridView1.Columns["Type"].Width = 150;

        }
    }
}
