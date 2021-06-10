//EditAppointment.cs
//Form to edit existing appointment.

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
    public partial class EditAppointment : Form
    {
        int userID;
        int customerID;
        string userName;
        UCertifyDB HomeDB = new UCertifyDB();
        BindingList<Appointment> apptTable = new BindingList<Appointment>();
        BindingList<Customer> customerTable = new BindingList<Customer>();
        BindingList<Appointment> selectedTable = new BindingList<Appointment>();
        Appointment transfer;
        public EditAppointment(int id, string name, Appointment appt1)
        {
            InitializeComponent();
            HomeDB.fillCustomers(customerTable);
            HomeDB.fillAppointments(apptTable);
            HomeDB.fillComboBox(custComboBox, "customer", "customerName");
            HomeDB.fillComboBox(typeComboBox, "appointment", "type");
            userID = id;
            userName = name;
            userLabel.Text = userName;
            transfer = appt1;
            populateFields();
        }

        // Populates fields with existing appointment data.
        private void populateFields()
        {
            TitleTextBox.Text = transfer.Title;
            DescTextBox.Text = transfer.description;
            LocTextBox.Text = transfer.location;
            custComboBox.Text = transfer.Contact;
            typeComboBox.Text = transfer.Type;
            URLTextBox.Text = transfer.Url;
            startTime.Value = transfer.Start;
            endTime.Value = transfer.End;
            createdTime.Value = transfer.CreateDate;
            updatedTime.Value = transfer.LastUpdate;
            createdLabel.Text = transfer.CreatedBy;
            updatedLabel.Text = transfer.LastUpdateBy;
        }
        // Cancel button
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MainScreen Main = new MainScreen(userID, userName);
            Main.Show();
        }
        // Blank field validator function
        private void fieldValidate(string notblank)
        {
            if (notblank == "")
                throw new MissingFieldException();
        }
        // Ensures time is during business hours (7:00AM - 6:00PM CST)
        private void timeValidate(DateTime origStart, DateTime origEnd)
        {
            DateTime start = origStart.ToUniversalTime();
            DateTime end = origEnd.ToUniversalTime();
            DateTime begin = new DateTime(2000, 01, 01, 12, 00, 00);
            DateTime stop = new DateTime(2000, 01, 01, 23, 00, 00);
            if (start.TimeOfDay < begin.TimeOfDay || end.TimeOfDay > stop.TimeOfDay)
            {
                throw new InvalidAppointmentTimeException();
            }
        }

        // Ensures appt start time never falls after appt end time.
        private void startEndValidate(DateTime origStart, DateTime origEnd)
        {
            if (origStart > origEnd)
            {
                throw new StartAfterEndTimeException();
            }
        }
        // Ensures dates do not fall on weekends.
        private void dateValidate(DateTime origStart, DateTime origEnd)
        {
            int start = (int)origStart.DayOfWeek;
            int end = (int)origEnd.DayOfWeek;
            if (start < 1 || start > 5 || end < 1 || end > 5)
            {
                throw new InvalidAppointmentDateException();
            }
        }
        // Ensures appointments do not overlap.

        private void overlapValidate(DateTime origStart, DateTime origEnd)
        {

            foreach (Appointment element in apptTable)
            {
                if (element.userId == userID)
                {
                    if (origStart.Day == element.Start.Day &&
                        origStart.Hour >= element.Start.Hour &&
                        origStart.Minute >= element.Start.Minute &&
                        origStart.TimeOfDay < element.End.TimeOfDay)

                    {
                        throw new InvalidAppointmentOverlap(element);
                    }
                }
            }
        }
        // Save button
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                fieldValidate(typeComboBox.Text);
            }
            catch (MissingFieldException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            try
            {
                timeValidate(startTime.Value, endTime.Value);
            }
            catch (InvalidAppointmentTimeException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            try
            {
                startEndValidate(startTime.Value, endTime.Value);
            }
            catch (StartAfterEndTimeException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            try
            {
                dateValidate(startTime.Value, endTime.Value);
            }
            catch (InvalidAppointmentDateException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            try
            {
                overlapValidate(startTime.Value, endTime.Value);
            }
            catch (InvalidAppointmentOverlap ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (HomeDB.customerCheck(custComboBox.Text) == 0)
            {
                this.Close();
                AddCustomer newCust = new AddCustomer(userID, userName);
                newCust.Show();
            }
            else if (HomeDB.customerCheck(custComboBox.Text) == 2)
            {
                return;
            }
            else
            {
                foreach (Customer element in customerTable)
                {
                    if (element.customerName == custComboBox.Text)
                    {
                        customerID = element.customerID;
                    }
                }
                DateTime date = DateTime.Now;
                Appointment updatedAppt = new Appointment(transfer.appointmentId, customerID, userID, TitleTextBox.Text, DescTextBox.Text, LocTextBox.Text, custComboBox.Text, typeComboBox.Text, URLTextBox.Text, startTime.Value, endTime.Value, createdTime.Value, userName, date, userName);
                HomeDB.updateAppointmentRecord(updatedAppt);
                this.Close();
                MainScreen Main = new MainScreen(userID, userName);
                Main.Show();
            }
        }
    }
}
