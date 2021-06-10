// EditCustomer.cs
// Form to edit existing customer.

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
    public partial class EditCustomer : Form
    {
        int userID;
        string userName;
        int active = 1;
        UCertifyDB HomeDB = new UCertifyDB();
        Customer transfer;
        public EditCustomer(int ID, string name, Customer cust1)
        {
            InitializeComponent();
            HomeDB.fillComboBox(cityCombo, "city", "city");
            HomeDB.fillComboBox(countryCombo, "country", "country");
            userID = ID;
            userName = name;
            transfer = cust1;
            populateFields();
        }

        // Populates fields with existing customer data.
        private void populateFields()
        {
            IDTextBox.Text = $"{transfer.customerID}";
            nameTextBox.Text = transfer.customerName;
            addressTextBox.Text = transfer.customerAddress;
            address2TextBox.Text = transfer.customerAddress2;
            cityCombo.Text = transfer.city;
            countryCombo.Text = transfer.country;
            postalTextBox.Text = transfer.postalCode;
            createdTextBox.Text = transfer.createdBy;
            dateTimePicker1.Value = transfer.createDate;
            updatedTextBox.Text = transfer.updatedBy;
            dateTimePicker2.Value = transfer.lastUpdated;
            phoneTextBox.Text = transfer.phone;
            if (transfer.customerActive == 0)
            {
                activeCheckBox.Checked = false;
                active = 0;
            }
        }
        

    // Cancel button
    private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MainScreen Main = new MainScreen(userID, userName);
            Main.Show();
        }

        // Field validation
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                nameTextBox.BackColor = Color.LightCoral;
            }
            else
            {
                nameTextBox.BackColor = Color.White;
            }
        }

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(addressTextBox.Text))
            {
                addressTextBox.BackColor = Color.LightCoral;
            }
            else
            {
                addressTextBox.BackColor = Color.White;
            }
        }

        private void cityCombo_TextUpdate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cityCombo.Text))
            {
                cityCombo.BackColor = Color.LightCoral;
            }
            else
            {
                cityCombo.BackColor = Color.White;
            }
        }

        private void countryCombo_TextUpdate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(countryCombo.Text))
            {
                countryCombo.BackColor = Color.LightCoral;
            }
            else
            {
                countryCombo.BackColor = Color.White;
            }
        }

        private void postalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(postalTextBox.Text))
            {
                postalTextBox.BackColor = Color.LightCoral;
            }
            else
            {
                postalTextBox.BackColor = Color.White;
            }
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                phoneTextBox.BackColor = Color.LightCoral;
            }
            else
            {
                phoneTextBox.BackColor = Color.White;
            }
        }

        private void phoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 45 && ch != 40 && ch != 41)
            {
                e.Handled = true;
            }
        }

        // Save button
        private void saveButton_Click(object sender, EventArgs e)
        {
            int countryID;
            int cityID;
            int addressID;
            DateTime date = DateTime.Now;
            if (activeCheckBox.Checked == false)
            {
                active = 0;
            }
            else
            {
                active = 1;
            }

            if (nameTextBox.Text == "")
            {
                MessageBox.Show("Name cannot be blank.");
                return;
            }
            else if (addressTextBox.Text == "")
            {
                MessageBox.Show("Address cannot be blank.");
                return;
            }
            else if (cityCombo.Text == "")
            {
                MessageBox.Show("City cannot be blank.");
                return;
            }
            else if (countryCombo.Text == "")
            {
                MessageBox.Show("Country cannot be blank.");
                return;
            }
            else if (postalTextBox.Text == "")
            {
                MessageBox.Show("Postal code cannot be blank.");
                return;
            }
            if (nameTextBox.Text != transfer.customerName && HomeDB.customerDupeCheck(nameTextBox.Text) < 1)
            {
                return;
            }
            else
            {
                Customer updated = new Customer(transfer.customerID, nameTextBox.Text, addressTextBox.Text, address2TextBox.Text, cityCombo.Text, countryCombo.Text, postalTextBox.Text, phoneTextBox.Text, active, dateTimePicker1.Value, createdTextBox.Text, date, userName);

                if (HomeDB.countryCheck(updated.country, updated) == -1)
                {
                    countryID = HomeDB.countryCount();
                    HomeDB.countryAdd(updated.country, countryID, updated);
                }
                else
                {
                    countryID = HomeDB.countryCheck(updated.country, updated);
                }
                if (HomeDB.cityCheck(updated.city, updated) == -1)
                {
                    cityID = HomeDB.cityCount();
                    HomeDB.cityAdd(updated.city, updated, countryID, cityID);
                }
                else
                {
                    cityID = HomeDB.cityCheck(updated.city, updated);
                }
                if (HomeDB.addressCheck(updated) == -1)
                {
                    addressID = HomeDB.addressCount();
                    HomeDB.addressAdd(updated, cityID, addressID);
                }
                else
                {
                    addressID = HomeDB.addressCheck(updated);
                }
                HomeDB.updateCustomerRecord(updated, addressID);
                this.Close();
                MainScreen Main = new MainScreen(userID, userName);
                Main.Show();
            }
        }

        private void postalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (Char.IsLetterOrDigit(ch) || ch == 8 || ch == 46 || ch == 45)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
                
        }

        private void phoneTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (Char.IsDigit(ch) || ch == 8 || ch == 46 || ch == 45)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
    
}
