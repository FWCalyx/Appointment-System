// DeleteCustomer.cs
// Form to delete customer from database.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace C969_Project
{
    public partial class DeleteCustomer : Form
    {
        int userID;
        string userName;
        Customer transfer;
        UCertifyDB HomeDB = new UCertifyDB();
        public DeleteCustomer(int ID, string name, Customer cust1)
        {
            InitializeComponent();
            userID = ID;
            userName = name;
            IDTextBox.Text = $"{cust1.customerID}";
            nameTextBox.Text = cust1.customerName;
            addressTextBox.Text = cust1.customerAddress;
            address2TextBox.Text = cust1.customerAddress2;
            cityCombo.Text = cust1.city;
            countryCombo.Text = cust1.country;
            postalTextBox.Text = cust1.postalCode;
            createdTextBox.Text = cust1.createdBy;
            dateTimePicker1.Value = cust1.createDate;
            updatedTextBox.Text = cust1.updatedBy;
            dateTimePicker2.Value = cust1.lastUpdated;
            phoneTextBox.Text = cust1.phone;
            if (cust1.customerActive == 0)
            {
                activeCheckBox.Checked = false;
            }
            transfer = cust1;
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
            if (MessageBox.Show("Are you sure you wish to delete this customer?",
                    "Delete Customer",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HomeDB.deleteCustomerRecord(transfer);
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
