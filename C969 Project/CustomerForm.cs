// CustomerForm.cs
// Customer viewing screen.

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

namespace C969_Project
{
    public partial class CustomerForm : Form
    {
        int userID;
        string userName;
        int RowIdx;
        UCertifyDB HomeDB = new UCertifyDB();
        BindingList<Customer> customerTable = new BindingList<Customer>();
        Customer currentCustomer;


        public CustomerForm(int id, string name)
        {
            InitializeComponent();
            userID = id;
            userName = name;
            customerDGV.DataSource = customerTable;
            userLabel.Text = userName;
            try
            {
                HomeDB.fillCustomers(customerTable);
                return;
            }
            catch
            {
                MessageBox.Show("Unable to look up customers. Please check your database connection and try again.");
                return;
            }

        }
        // Cancel button
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            MainScreen Main = new MainScreen(userID, userName);
            Main.Show();
        }
        // Populates customerDGV
        private void customerDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowIdx = customerDGV.CurrentCell.RowIndex;
            currentCustomer = customerTable[RowIdx];
            editButton.Enabled = true;
            deleteButton.Enabled = true;
            return;
        }
        // Calls AddCustomer form
        private void addButton_Click(object sender, EventArgs e)
        {
            this.Close();
            AddCustomer addCust = new AddCustomer(userID, userName);
            addCust.Show();
        }
        // Calls EditCustomer form
        private void editButton_Click(object sender, EventArgs e)
        {
            this.Close();
            EditCustomer editCust = new EditCustomer(userID, userName, currentCustomer);
            editCust.Show();
        }
        // Calls DeleteCustomer form
        private void deleteButton_Click(object sender, EventArgs e)
        {
            this.Close();
            DeleteCustomer deleteCust = new DeleteCustomer(userID, userName, currentCustomer);
            deleteCust.Show();
        }
    }
}
