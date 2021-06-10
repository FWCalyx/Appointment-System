// Customer.cs
// Customer class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace C969_Project
{
    public class Customer
    {
        [DisplayName("Customer ID")]
        public int customerID { get; set; }
        [DisplayName("Customer Name")]
        public string customerName { get; set; }
        [DisplayName("Address")]
        public string customerAddress { get; set; }
        public string customerAddress2 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }

        [DisplayName("Active")]
        public int customerActive { get; set; }
        [DisplayName("Date Created")]
        public DateTime createDate { get; set; }
        [DisplayName("Created By")]
        public string createdBy { get; set; }
        [DisplayName("Last Updated")]
        public DateTime lastUpdated { get; set; }
        [DisplayName("Updated By")]
        public string updatedBy { get; set; }

        public Customer(int ID, string name, string address, string address2, string City, string Country, string pCode, string Phone, int active, DateTime created, string creator, DateTime updated, string updater)
        {
            customerID = ID;
            customerName = name;
            customerAddress = address;
            customerAddress2 = address2;
            city = City;
            country = Country;
            postalCode = pCode;
            phone = Phone;
            customerActive = active;
            createDate = created;
            createdBy = creator;
            lastUpdated = updated;
            updatedBy = updater;
        }

    }
}
