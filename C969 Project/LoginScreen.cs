// LoginScreen.cs
// Login form

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
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace C969_Project
{
    public partial class LoginScreen : Form
    {
        int langcheck = 0;
        int userID;
        public LoginScreen()
        {
            InitializeComponent();
            CultureInfo culture = CultureInfo.CurrentCulture; // CultureInfo data for localization
            string language = culture.NativeName;
            if (language.StartsWith("español"))
            {
                langcheck = 1;
            }

        }
        // Exit button
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Login button
        private void loginButton_Click(object sender, EventArgs e)
        {
            UCertifyDB HomeDB = new UCertifyDB();

            if (userTextBox.Text == "" || passTextBox.Text == "")
            {
                if (langcheck == 1)
                {
                    MessageBox.Show("Ni el nombre de usuario ni la contraseña pueden dejarse en blanco.");
                }
                else
                {
                    MessageBox.Show("Neither username nor password can be blank.");
                    return;
                }

            }
            else
            {
                try
                {
                    userID = (HomeDB.userCheck(userTextBox.Text, passTextBox.Text));
                    if (userID != 0)
                    {
                        DateTime date = DateTime.Now;
                        logUserAccess(userID, userTextBox.Text, date);
                        this.Hide();
                        MainScreen Main = new MainScreen(userID, userTextBox.Text);
                        Main.Show();
                    }
                    else if (userID == 0)
                    {
                        if (langcheck == 1)
                        {
                            MessageBox.Show("Nombre de usuario o contraseña incorrecta.");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Username or password is incorrect.");
                            return;
                        }

                    }
                }
                catch
                {
                    if (langcheck == 1)
                    {
                        MessageBox.Show("Error al iniciar sesión. Vuelve a intentarlo.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Error logging in. Please try again.");
                        return;
                    }
                   
                }
            }
        }
        // Records logins in text file
        public void logUserAccess(int id, string name, DateTime date)
        {
            string filepath = "userlog.txt";
            if (!File.Exists(filepath))
            {
                using (StreamWriter logger = File.CreateText(filepath))
                {
                    logger.WriteLine($"{userID}, {userTextBox.Text}, {date}");
                }
            }
            else
            {
                using (StreamWriter logger = File.AppendText(filepath))
                {
                    logger.WriteLine($"{userID}, {userTextBox.Text}, {date}");
                }
            }

        }

        
    }
}
