// DeleteAppointment.cs
// Form to delete appointments from database.

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
    public partial class DeleteAppointment : Form
    {
        int userID;
        string userName;
        UCertifyDB HomeDB = new UCertifyDB();
        Appointment transfer;

        public DeleteAppointment(int id, string name, Appointment appt1)
        {
            InitializeComponent();
            userID = id;
            userName = name;
            userLabel.Text = userName;
            transfer = appt1;
            populateFields();
        }
        // Populates fields with appointment data.
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
        // Delete button
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to delete this appointment?",
                    "Delete Appointment",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HomeDB.deleteAppointmentRecord(transfer);
                this.Close();
                MainScreen Main = new MainScreen(userID, userName);
                Main.Show();
            }
            else
            {
                return;
            }
        }
    }
}
