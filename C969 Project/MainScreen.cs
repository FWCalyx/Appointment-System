// MainScreen.cs
// Main Screen for program.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace C969_Project
{
    public partial class MainScreen : Form
    {
        int user;
        string userName;
        UCertifyDB HomeDB = new UCertifyDB();
        Appointment currentAppt;
        BindingList<Appointment> appointmentTable = new BindingList<Appointment>();
        BindingList<Appointment> selectedTable = new BindingList<Appointment>();
        DateTime startDate = DateTime.Now;
        DateTime endDate;
        TimeSpan day = new TimeSpan(1, 0, 0, 0);
        TimeSpan reminder = new TimeSpan(0, 0, 15, 0);
        BindingList<Timer> timerTable = new BindingList<Timer>();



        public MainScreen(int ID, string name)
        {
            InitializeComponent();
            user = ID;
            userName = name;
            userLabel.Text = userName;
            try { HomeDB.fillAppointments(appointmentTable); }
            catch { MessageBox.Show("No appointments found."); }
            dataGridView1.DataSource = appointmentTable;
            formatDGV(dataGridView1);
            upcomingAppointments();
        }
        // Formats the datagridview to show only desired columns.
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
            this.dataGridView1.Columns["Start"].DisplayIndex = 0;;
            this.dataGridView1.Columns["Start"].Width = 115;
            this.dataGridView1.Columns["Title"].DisplayIndex = 1;
            this.dataGridView1.Columns["Title"].Width = 335;
            this.dataGridView1.Columns["Contact"].DisplayIndex = 2;
            this.dataGridView1.Columns["Contact"].Width = 150;
            this.dataGridView1.Columns["Type"].DisplayIndex = 3;
            this.dataGridView1.Columns["Type"].Width = 150;

        }
        // Exit button
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Calls customer form
        private void customerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerForm Customer = new CustomerForm(user, userName);
            Customer.Show();
        }
        // Calls AddAppointment form
        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddAppointment newAppt = new AddAppointment(user, userName);
            newAppt.Show();
        }
        // Sets current selection to current appointment object.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = 0;
            string currApptID = dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString();
            foreach(Appointment appt in appointmentTable)
            {
                if (appt.appointmentId.ToString() == currApptID)
                {
                    currentAppt = appt;
                }
            }
            editAppointmentButton.Enabled = true;
            deleteAppointmentButton.Enabled = true;

        }
        // Calls Edit Appointment form
        private void editAppointmentButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditAppointment editAppt = new EditAppointment(user, userName, currentAppt);
            editAppt.Show();
        }
        // Calls Delete Appointment Form
        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {
            this.Close();
            DeleteAppointment deleteAppt = new DeleteAppointment (user, userName, currentAppt);
            deleteAppt.Show();
        }
        // Changes the visible appointments based on date and range selected
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            startDate = monthCalendar1.SelectionRange.Start;
            if (radioDayButton.Checked == true)
            {
                radioDayCheck();
            }
            else if (radioWeekButton.Checked == true)
            {
                radioWeekCheck();
            }
            else if (radioMonthButton.Checked == true)
            {
                radioMonthCheck();
            }
        }
        private void radioUnfilteredButton_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = appointmentTable;
        }

        private void radioMonthButton_CheckedChanged(object sender, EventArgs e)
        {
            radioMonthCheck();
        }

        private void radioWeekButton_CheckedChanged(object sender, EventArgs e)
        {
            radioWeekCheck();
        }

        private void radioDayButton_CheckedChanged(object sender, EventArgs e)
        {
            radioDayCheck();
        }

        private void radioDayCheck()
        {
            selectedTable.Clear();
            startDate = monthCalendar1.SelectionRange.Start;
            endDate = startDate + day;
            foreach (Appointment element in appointmentTable)
            {
                if (element.Start.Day == startDate.Day && element.Start.Month == startDate.Month && element.Start.Year == startDate.Year)
                {
                    selectedTable.Add(element);

                }
                dataGridView1.DataSource = selectedTable;
            }
        }
        private void radioWeekCheck()
        {
            selectedTable.Clear();

            DateTime selectDate = monthCalendar1.SelectionRange.Start;

            int daySwitch = (int)selectDate.DayOfWeek;

            switch (daySwitch)
            {
                case 0:
                    startDate = selectDate.Add(day);
                    endDate = selectDate.Add(day * 5);
                    break;
                case 2:
                    startDate = selectDate.Subtract(day);
                    endDate = selectDate.Add(day * 3);
                    break;
                case 3:
                    startDate = selectDate.Subtract(day * 2);
                    endDate = selectDate.Add(day * 2);
                    break;
                case 4:
                    startDate = selectDate.Subtract(day * 3);
                    endDate = selectDate.Add(day * 1);
                    break;
                case 5:
                    startDate = selectDate.Subtract(day * 4);
                    endDate = selectDate;
                    break;
                case 6:
                    startDate = selectDate.Subtract(day * 6);
                    endDate = selectDate.Subtract(day);
                    break;
                default:
                    startDate = selectDate;
                    endDate = selectDate.Add(day * 4);
                    break;
            }
            foreach (Appointment element in appointmentTable)
            {
                if (element.Start.Day >= startDate.Day && element.Start.Day <= endDate.Day && element.Start.Month == startDate.Month && element.Start.Year == startDate.Year)
                {
                    selectedTable.Add(element);
                }
                dataGridView1.DataSource = selectedTable;
            }
        }

        private void radioMonthCheck()
        {
            selectedTable.Clear();
            DateTime selectDate = monthCalendar1.SelectionRange.Start;
            int monthSwitch = (int)selectDate.Month;

            switch (monthSwitch)
            {
                case 1:
                    startDate = selectDate.Subtract(day * ((int)(selectDate.Day) - 1));
                    endDate = startDate.Add(day * 30);
                    break;
                case 2:
                    startDate = selectDate.Subtract(day * ((int)(selectDate.Day) - 1));
                    int year = (int)(selectDate.Year);
                    if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0))
                    {
                        endDate = startDate.Add(day * 28);
                    }
                    else
                    {
                        endDate = startDate.Add(day * 27);
                    }
                    break;
                case 3:
                    startDate = selectDate.Subtract(day * ((int)(selectDate.Day) - 1));
                    endDate = startDate.Add(day * 30);
                    break;
                case 4:
                    startDate = selectDate.Subtract(day * ((int)(selectDate.Day) - 1));
                    endDate = startDate.Add(day * 29);
                    break;
                case 5:
                    startDate = selectDate.Subtract(day * ((int)(selectDate.Day) - 1));
                    endDate = startDate.Add(day * 30);
                    break;
                case 6:
                    startDate = selectDate.Subtract(day * ((int)(selectDate.Day) - 1));
                    endDate = startDate.Add(day * 29);
                    break;
                case 7:
                    startDate = selectDate.Subtract(day * ((int)(selectDate.Day) - 1));
                    endDate = startDate.Add(day * 30);
                    break;
                case 8:
                    startDate = selectDate.Subtract(day * ((int)(selectDate.Day) - 1));
                    endDate = startDate.Add(day * 30);
                    break;
                case 9:
                    startDate = selectDate.Subtract(day * ((int)(selectDate.Day) - 1));
                    endDate = startDate.Add(day * 29);
                    break;
                case 10:
                    startDate = selectDate.Subtract(day * ((int)(selectDate.Day) - 1));
                    endDate = startDate.Add(day * 30);
                    break;
                case 11:
                    startDate = selectDate.Subtract(day * ((int)(selectDate.Day) - 1));
                    endDate = startDate.Add(day * 29);
                    break;
                default:
                    startDate = selectDate.Subtract(day * ((int)(selectDate.Day) - 1));
                    endDate = startDate.Add(day * 30);
                    break;

            }
            foreach (Appointment element in appointmentTable)
            {
                if (element.Start.Day >= startDate.Day && element.Start.Day <= endDate.Day && element.Start.Month == startDate.Month && element.Start.Year == startDate.Year)
                {
                    selectedTable.Add(element);
                }
                dataGridView1.DataSource = selectedTable;
            }
        }
        // Calls reports form
        private void reportsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports reports = new Reports(user, userName);
            reports.Show();
        }

        public void upcomingAppointments()
        {
            foreach (Appointment appt in appointmentTable)
            {
                if (appt.userId == user)
                {
                    DateTime today = DateTime.Now;
                    if (today < appt.Start && (appt.Start - today) < reminder)
                    {
                        MessageBox.Show($"You have an appointment with {appt.Contact} scheduled for {appt.Start}.");
                    }
                }
            }
            return;
        }
        // Sets timer function
        //public void setTimerFunction()
        //{
        //    foreach (Appointment appt in appointmentTable)
        //    {
        //        if (appt.userId == user)
        //        {
        //            DateTime today = DateTime.Now;
        //            if (today < appt.Start && (appt.Start - today) < reminder)
        //            {
        //                MessageBox.Show($"You have an appointment with {appt.Contact} scheduled for {appt.Start}.");
        //            }
        //        }
        //    }
        //    return;
        //}
        // Event handler for timer tick
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    setTimerFunction();
        //}


    }
}
