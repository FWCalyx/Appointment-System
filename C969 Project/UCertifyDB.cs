// UCertifyDB.cs
// Holds all functions that access the database.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Windows.Forms;

namespace C969_Project
{
    class UCertifyDB
    {
        private string connectionString;
        private MySqlConnection myCon;

        public UCertifyDB()
        {
            connectionString = "(Removed for security)";
            myCon = new MySqlConnection(connectionString);
        }
        // Adds customer record to the database
        public void addCustomerRecord(Customer cust1, int addressID)
        {
            string created = cust1.createDate.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss");
            string updated = cust1.lastUpdated.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss");

            string query = $"INSERT INTO U08jw9.customer(customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@customerId, @customerName, (SELECT addressId from U08jw9.address WHERE addressId = @addressId), @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
            using (myCon)
            {

                myCon.Open();
                MySqlCommand add = new MySqlCommand(query, myCon);

                add.Parameters.AddWithValue("@customerId", cust1.customerID);
                add.Parameters.AddWithValue("@customerName", cust1.customerName);
                add.Parameters.AddWithValue("@addressId", addressID);
                add.Parameters.AddWithValue("@active", cust1.customerActive);
                add.Parameters.AddWithValue("@createDate", created);
                add.Parameters.AddWithValue("@createdBy", cust1.createdBy);
                add.Parameters.AddWithValue("@lastUpdate", updated);
                add.Parameters.AddWithValue("@lastUpdateBy", cust1.updatedBy);

                if (add.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Customer added to database.");
                }
                else
                {
                    MessageBox.Show("Could not add the customer.");
                }
                myCon.Close();
            }
 
        }
        // Updates customer record in the database
        public void updateCustomerRecord(Customer cust1, int addressID)
        {
            string updated = cust1.lastUpdated.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss");

            string query = $"UPDATE U08jw9.customer SET customerName = @customerName, customer.addressId = @addressId, customer.active = @active, customer.lastUpdate = @lastUpdate, customer.lastUpdateBy = @lastUpdateBy WHERE customer.customerId = {cust1.customerID}";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand update = new MySqlCommand(query, myCon);

                update.Parameters.AddWithValue("@customerName", cust1.customerName);
                update.Parameters.AddWithValue("@addressId", addressID);
                update.Parameters.AddWithValue("@active", cust1.customerActive);
                update.Parameters.AddWithValue("@lastUpdate", updated);
                update.Parameters.AddWithValue("@lastUpdateBy", cust1.updatedBy);

                if (update.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Customer data updated.");
                }
                else
                {
                    MessageBox.Show("Could not update the customer.");
                }
                myCon.Close();
            }
        }
        // Deletes customer record from the database
        public void deleteCustomerRecord(Customer cust1)
        {
            string query = $"DELETE FROM U08jw9.customer WHERE customerId = {cust1.customerID}";

            using (myCon)
            {
                myCon.Open();
                MySqlCommand delete = new MySqlCommand(query, myCon);

                if (delete.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Customer deleted.");

                }
                else
                {
                    MessageBox.Show("Could not delete the customer.");
                }
                myCon.Close();
            }
        }
        // Adds an appointment record to the database
        public void addAppointmentRecord(Appointment appt1)
        {
            string created = appt1.CreateDate.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss");
            string updated = appt1.LastUpdate.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss");
            string start = appt1.Start.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss");
            string end = appt1.End.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss");

            string query = $"INSERT INTO U08jw9.appointment(appointmentId, customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@appointmentId, (SELECT customerId FROM U08jw9.customer WHERE customerId = @customerId), (SELECT userId from U08jw9.user WHERE userId = @userId), @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
            using (myCon)
            {

                myCon.Open();
                MySqlCommand add = new MySqlCommand(query, myCon);

                add.Parameters.AddWithValue("@appointmentId", appt1.appointmentId);
                add.Parameters.AddWithValue("@customerId", appt1.customerId);
                add.Parameters.AddWithValue("@userId", appt1.userId);
                add.Parameters.AddWithValue("@title", appt1.Title);
                add.Parameters.AddWithValue("@description", appt1.description);
                add.Parameters.AddWithValue("@location", appt1.location);
                add.Parameters.AddWithValue("@contact", appt1.Contact);
                add.Parameters.AddWithValue("@type", appt1.Type);
                add.Parameters.AddWithValue("@url", appt1.Url);
                add.Parameters.AddWithValue("@start", start);
                add.Parameters.AddWithValue("@end", end);
                add.Parameters.AddWithValue("@createDate", created);
                add.Parameters.AddWithValue("@createdBy", appt1.CreatedBy);
                add.Parameters.AddWithValue("@lastUpdate", updated);
                add.Parameters.AddWithValue("@lastUpdateBy", appt1.LastUpdateBy);


                if (add.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Appointment added to database.");
                }
                else
                {
                    MessageBox.Show("Could not add the appointment.");
                }
                myCon.Close();
            }

        }

        // Updates appointment record in the database
        public void updateAppointmentRecord(Appointment appt1)
        {
            string updated = appt1.LastUpdate.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss");
            string start = appt1.Start.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss");
            string end = appt1.End.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss");


            string query = $"UPDATE U08jw9.appointment SET customerId = @customerId, title = @title, description = @description, location = @location, contact = @contact, type = @type, url = @url, start = @start, end = @end, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy WHERE appointmentId = @appointmentId;";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand update = new MySqlCommand(query, myCon);

                update.Parameters.AddWithValue("@customerId", appt1.customerId);
                update.Parameters.AddWithValue("@title", appt1.Title);
                update.Parameters.AddWithValue("@description", appt1.description);
                update.Parameters.AddWithValue("@location", appt1.location);
                update.Parameters.AddWithValue("@contact", appt1.Contact);
                update.Parameters.AddWithValue("@type", appt1.Type);
                update.Parameters.AddWithValue("@url", appt1.Url);
                update.Parameters.AddWithValue("@start", start);
                update.Parameters.AddWithValue("@end", end);
                update.Parameters.AddWithValue("@lastUpdate", updated);
                update.Parameters.AddWithValue("@lastUpdateBy", appt1.LastUpdateBy);
                update.Parameters.AddWithValue("@appointmentId", appt1.appointmentId);

                if (update.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Appointment updated.");
                }
                else
                {
                    MessageBox.Show("Could not update the appointment.");
                }
                myCon.Close();
            }
        }

        // Deletes appointment record from the database
        public void deleteAppointmentRecord(Appointment appt1)
        {
            string query = $"DELETE FROM U08jw9.appointment WHERE appointmentId = {appt1.appointmentId}";

            using (myCon)
            {
                myCon.Open();
                MySqlCommand delete = new MySqlCommand(query, myCon);

                if (delete.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Appointment deleted.");

                }
                else
                {
                    MessageBox.Show("Could not delete the appointment.");
                }
                myCon.Close();
            }
        }

        // Populates binding list with customers from the database.
        public void fillCustomers(BindingList<Customer> List)
        {
            string query = "SELECT customer.customerId, customer.customerName, customer.addressId, address.address, address.address2, address.cityId, city.cityId, city.city, city.countryId, country.country, address.postalCode, address.phone, customer.active, customer.createDate, customer.createdBy, customer.lastUpdate, customer.lastUpdateBy FROM U08jw9.customer INNER JOIN U08jw9.address ON customer.addressId = address.addressId INNER JOIN U08jw9.city ON address.cityId = city.cityId INNER JOIN U08jw9.country ON city.countryId = country.countryId ORDER BY customer.customerName";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand lookup = new MySqlCommand(query, myCon);
                MySqlDataReader reader = lookup.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer cust1 = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(3), reader.GetString(4), reader.GetString(7), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetInt32(12), reader.GetDateTime(13).ToLocalTime(), reader.GetString(14), reader.GetDateTime(15).ToLocalTime(), reader.GetString(16));
                        List.Add(cust1);
                    }
                }
                else
                {
                    MessageBox.Show("No customers found.");
                }
                reader.Close();
                myCon.Close();
            }
               
        }
        // Populates binding list with appointments from the database.
        public void fillAppointments(BindingList<Appointment> List)
        {
            string query = "SELECT appointment.appointmentId, appointment.customerId, appointment.userId, appointment.title, appointment.description, appointment.location, appointment.contact, appointment.type, appointment.url, appointment.start, appointment.end, appointment.createDate, appointment.createdBy, appointment.lastUpdate, appointment.lastUpdateBy FROM U08jw9.appointment INNER JOIN U08jw9.customer ON appointment.customerId = customer.customerId ORDER BY appointment.start";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand lookup = new MySqlCommand(query, myCon);
                MySqlDataReader reader = lookup.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Appointment appt1 = new Appointment(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetDateTime(9).ToLocalTime(), reader.GetDateTime(10).ToLocalTime(), reader.GetDateTime(11).ToLocalTime(), reader.GetString(12), reader.GetDateTime(13).ToLocalTime(), reader.GetString(14)); 
                        List.Add(appt1);
                    }
                }
                else
                {
                    MessageBox.Show("No appointments found.");
                }
                reader.Close();
                myCon.Close();
            }
                
        }

        // Populates binding list with users from the database.
        public void fillUsers(BindingList<User> List)
        {
            string query = "SELECT * FROM U08jw9.user ORDER BY userName";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand lookup = new MySqlCommand(query, myCon);
                MySqlDataReader reader = lookup.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user1 = new User(reader.GetInt32(0), reader.GetString(1));
                        List.Add(user1);
                    }
                }
                else
                {
                    MessageBox.Show("No users found.");
                }
                reader.Close();
                myCon.Close();
            }

        }
        // Populates combo boxes with database information to provide dropdown menus.
        public void fillComboBox(ComboBox box, string table, string column)
        {
            string query = $"SELECT DISTINCT {column} FROM {table} ORDER BY {table}.{column}";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand fillCombo = new MySqlCommand(query, myCon);
                MySqlDataReader reader = fillCombo.ExecuteReader();
                while (reader.Read())
                {
                    box.Items.Add(reader.GetString(column));
                }
                reader.Close();
                myCon.Close();
            }
        }
        // Fills a list with desired table data
        public void fillList(BindingList<string> List)
        {
            string query = $"SELECT DISTINCT type FROM appointment ORDER BY appointment.type";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand fillCombo = new MySqlCommand(query, myCon);
                MySqlDataReader reader = fillCombo.ExecuteReader();
                while (reader.Read())
                {
                    List.Add(reader.GetString("type"));
                }
                reader.Close();
                myCon.Close();
            }
        }
        // Login and password verification
        public int userCheck(string username, string password)
        {
            int userID = 0;
            string query = $"SELECT userId FROM user WHERE userName =  '{username}' AND password = '{password}'";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand uCheck = new MySqlCommand(query, myCon);
                MySqlDataReader reader = uCheck.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    userID = reader.GetInt32(0);
                    myCon.Close();
                    return userID;
                }
                else
                {
                    myCon.Close();
                    return userID;
                }
            } 
        }

        // Verifies whether this is a duplicate customer
        public int customerDupeCheck(string customerName)
        {
            string query = $"SELECT * FROM customer WHERE LOWER (customerName) = LOWER('{customerName}')";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if (MessageBox.Show($"The customer {reader.GetString("customerName")} with ID number {reader.GetInt32("customerId")} already exists. Would you like to add another customer with the same name?",
                    "Customer Already Exists",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        reader.Close();
                        myCon.Close();
                        return 1;
                    }
                    else
                    {
                        reader.Close();
                        myCon.Close();
                        return 0;
                    }
                }
                else
                {
                    reader.Close();
                    myCon.Close();
                    return 2;
                }
            }
        }

        public int customerCheck(string customerName)
        {
            string query = $"SELECT * FROM customer WHERE LOWER (customerName) = LOWER('{customerName}')";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    myCon.Close();
                    return 1;
                }
                else
                {
                    if (MessageBox.Show($"The customer {customerName} does not exist. Would you like to add this customer?",
                        "Customer Already Exists", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        reader.Close();
                        myCon.Close();
                        return 0;
                    }
                    else
                    {
                        reader.Close();
                        myCon.Close();
                        return 2;
                    }
                }
            }
        }


        // Checks for existence of country in database
        public int countryCheck(string countryname, Customer cust1)
        {
            int countryID;
            string query = $"SELECT * FROM country WHERE LOWER (country) = LOWER('{countryname}')";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    countryID = reader.GetInt32("countryId");
                    reader.Close();
                    myCon.Close();
                    return countryID;
                }
                else
                {
                    reader.Close();
                    myCon.Close();
                    return -1;
                }
            }
        }

        // Finds the maximum value of all current country IDs and creates a new one that is one larger.
        public int countryCount()
        {
            List<int> Countries = new List<int>();
            string query = $"SELECT * FROM country";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Countries.Add(reader.GetInt32("countryId"));
                }
                // This lambda expression streamlines the process of calculating a new country ID by determining the highest existing ID value.
                int maxID = Countries.Max(r => r); 
                int countryID = maxID + 1;
                reader.Close();
                myCon.Close();
                return countryID;
            }
        }
        // Adds new country to the database
        public void countryAdd(string countryName, int countryID, Customer cust1)
        {
            using (myCon)
            {
                myCon.Open();
                string query = "INSERT INTO U08jw9.country(countryId, country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@countryId, @country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@countryId", countryID);
                cmd.Parameters.AddWithValue("@country", countryName);
                cmd.Parameters.AddWithValue("@createDate", cust1.createDate.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss"));
                cmd.Parameters.AddWithValue("@createdBy", cust1.createdBy);
                cmd.Parameters.AddWithValue("@lastUpdate", cust1.lastUpdated.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss"));
                cmd.Parameters.AddWithValue("@lastUpdateBy", cust1.updatedBy);

                cmd.ExecuteNonQuery();
                myCon.Close();
            }
        }

        // Checks for existence of city in the database
        public int cityCheck(string cityname, Customer cust1)
        {

            int cityID;
            string query = $"SELECT * FROM city WHERE LOWER (city) =  LOWER('{cityname}')";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    cityID = reader.GetInt32("cityId");
                    reader.Close();
                    myCon.Close();
                    return cityID;
                }
                else
                {
                    reader.Close();
                    myCon.Close();
                    return -1;
                }
            }
                
        }
        // Finds the maximum value of all current city IDs and creates a new one that is one larger.
        public int cityCount()
        {
            List<int> Cities = new List<int>();
            string query = $"SELECT * FROM city";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cities.Add(reader.GetInt32("cityId"));
                }
                // This lambda expression streamlines the process of calculating a new city ID by determining the highest existing ID value.
                int maxID = Cities.Max(r => r); 
                int cityID = maxID + 1;
                myCon.Close();
                return cityID;
            }
        }
        // Adds new city to the database
        public void cityAdd(string cityName, Customer cust1, int countryID, int cityID)
        {
            
            using (myCon)
            {
                myCon.Open();
                
                string query = "INSERT INTO U08jw9.city(cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@cityId, @city, (SELECT countryId from U08jw9.country WHERE countryId = @countryId), @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                MySqlCommand add = new MySqlCommand(query, myCon);
                add.Parameters.AddWithValue("@cityId", cityID);
                add.Parameters.AddWithValue("@city", cust1.city);
                add.Parameters.AddWithValue("@countryId", countryID);
                add.Parameters.AddWithValue("@createDate", cust1.createDate.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss"));
                add.Parameters.AddWithValue("@createdBy", cust1.createdBy);
                add.Parameters.AddWithValue("@lastUpdate", cust1.lastUpdated.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss")); ;
                add.Parameters.AddWithValue("@lastUpdateBy", cust1.updatedBy);
                add.ExecuteNonQuery();
                myCon.Close();
            }
        }
        // Checks for existence of address in the database
        public int addressCheck(Customer cust1)
        {
            int addressID;
            string query = $"SELECT * FROM address WHERE LOWER (address) =  LOWER('{cust1.customerAddress}') AND LOWER (address2) = LOWER('{cust1.customerAddress2}')";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    addressID = reader.GetInt32("addressId");
                    reader.Close();
                    myCon.Close();
                    return addressID;
                }
                else
                {
                    reader.Close();
                    myCon.Close();
                    return -1;
                }
            }
        }
        // Finds the maximum value of all current address IDs and creates a new one that is one larger.
        public int addressCount()
        {
            List<int> Addresses = new List<int>();
            string query = $"SELECT * FROM address";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Addresses.Add(reader.GetInt32("addressId"));
                }
                // This lambda expression streamlines the process of calculating a new address ID by determining the highest existing ID value.
                int maxID = Addresses.Max(r => r); 
                int addressID = maxID + 1;
                myCon.Close();
                return addressID;
            }
        }
        // Adds new address to the database
        public void addressAdd(Customer cust1, int cityID, int addressID)
        {
            string query = "INSERT INTO U08jw9.address(addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@addressId, @address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
            using (myCon)
            {
                myCon.Open();
                MySqlCommand add = new MySqlCommand(query, myCon);
                add.Parameters.AddWithValue("@addressId", addressID);
                add.Parameters.AddWithValue("@address", cust1.customerAddress);
                add.Parameters.AddWithValue("@address2", cust1.customerAddress2);
                add.Parameters.AddWithValue("@cityID", cityID);
                add.Parameters.AddWithValue("@postalCode", cust1.postalCode);
                add.Parameters.AddWithValue("@phone", cust1.phone);
                add.Parameters.AddWithValue("@createDate", cust1.createDate.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss"));
                add.Parameters.AddWithValue("@createdBy", cust1.createdBy);
                add.Parameters.AddWithValue("@lastUpdate", cust1.lastUpdated.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss"));
                add.Parameters.AddWithValue("@lastUpdateBy", cust1.updatedBy);
                add.ExecuteNonQuery();
                myCon.Close();
            }
        }
    }
}
