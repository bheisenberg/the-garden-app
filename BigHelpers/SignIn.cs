using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace BigHelpers
{
    public partial class SignIn : UserControl
    {
        public Form form;
        private MySqlConnection connection;

        public SignIn()
        {
            InitializeComponent();
        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void SignInNow()
        {
            form.Controls.Remove(this);
            MainView mainView = new MainView();
            mainView.currentUser = new User(usernameBox.Text);
            form.Controls.Add(mainView);
            mainView.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataConnector dataConnector = new DataConnector();
                connection = dataConnector.connection;
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = string.Format("SELECT * FROM USERACCOUNTS WHERE username = '{0}' AND password = '{1}'", usernameBox.Text, passwordBox.Text);
                Console.WriteLine(command.CommandText);
                MySqlDataReader reader = command.ExecuteReader();
                int matches = 0;
                while (reader.Read()) 
                {
                    Console.WriteLine("Found matching account");
                    matches++;
                }
                connection.Close();
                if(matches == 1)
                {
                    SignInNow();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AppName_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            form.Controls.Remove(this);
            CreateAccount createAccount = new CreateAccount();
            createAccount.form = form;
            createAccount.signIn = this;
            createAccount.Dock = DockStyle.Fill;
            form.Controls.Add(createAccount);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void userName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
