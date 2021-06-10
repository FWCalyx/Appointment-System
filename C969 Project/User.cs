// User.cs
// User class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Project
{
    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; }

        public User(int id, string name)
        {
            userID = id;
            userName = name;
        }
    }
}
