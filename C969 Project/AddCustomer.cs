// AddCustomer.cs
// Form for adding customers to database.

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
    public partial class AddCustomer : Form
    {
        int userID;
        string userName;
        int newID;
        int active = 1;
        BindingList<Customer> customerTable = new BindingList<Customer>();

        UCertifyDB HomeDB = new UCertifyDB();
        public AddCustomer(int id, string name)
        {
            InitializeComponent();
            HomeDB.fillComboBox(cityCombo, "city", "city");
            HomeDB.fillComboBox(countryCombo, "country", "country");
            HomeDB.fillCustomers(customerTable);
            int maxID = customerTable.Max(r => r.customerID); // This lambda expression streamlines the process for calculating a unique customerID.
            newID = maxID + 1;
            userID = id;
            userName = name;
            createdTextBox.Text = userName;
            updatedTextBox.Text = userName;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;


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
        // Save button
        private void saveButton_Click(object sender, EventArgs e)
        {
            int countryID;
            int cityID;
            int addressID;
            // Required Field Check

            if (nameTextBox.Text == "")
            {
                MessageBox.Show("Name cannot be blank.");
                return;
            } else if (addressTextBox.Text == "")
            {
                MessageBox.Show("Address cannot be blank.");
                return;
            } else if (cityCombo.Text == "")
            {
                MessageBox.Show("City cannot be blank.");
                return;
            } else if (countryCombo.Text == "")
            {
                MessageBox.Show("Country cannot be blank.");
                return;
            } else if (postalTextBox.Text == "")
            {
                MessageBox.Show("Postal code cannot be blank.");
                return;
            } else if (HomeDB.customerDupeCheck(nameTextBox.Text) < 1)
            {
                return;
            }
            else
            {
                Customer cust1 = new Customer(newID, nameTextBox.Text, addressTextBox.Text, address2TextBox.Text, cityCombo.Text, countryCombo.Text, postalTextBox.Text, phoneTextBox.Text, active, dateTimePicker1.Value, createdTextBox.Text, dateTimePicker2.Value, updatedTextBox.Text);
                if (activeCheckBox.Checked == false)
                {
                    active = 0;
                }
                if (HomeDB.countryCheck(cust1.country, cust1) == -1)
                {
                    countryID = HomeDB.countryCount();
                    HomeDB.countryAdd(cust1.country, countryID, cust1);
                }
                else
                {
                    countryID = HomeDB.countryCheck(cust1.country, cust1);
                }
                if (HomeDB.cityCheck(cust1.city, cust1) == -1)
                {
                    cityID = HomeDB.cityCount();
                    HomeDB.cityAdd(cust1.city, cust1, countryID, cityID);
                }
                else
                {
                    cityID = HomeDB.cityCheck(cust1.city, cust1);
                }
                if (HomeDB.addressCheck(cust1) == -1)
                {
                    addressID = HomeDB.addressCount();
                    HomeDB.addressAdd(cust1, cityID, addressID);
                }
                else
                {
                    addressID = HomeDB.addressCheck(cust1);
                }
                HomeDB.addCustomerRecord(cust1, addressID);
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
    }
}
