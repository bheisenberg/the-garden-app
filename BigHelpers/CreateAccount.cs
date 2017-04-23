using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BigHelpers
{
    public partial class CreateAccount : UserControl
    {
        private MySqlConnection connection;
        public Form form;
        public SignIn signIn;
        public CreateAccount()
        {
            InitializeComponent();
            DataConnector dataConnection = new DataConnector();
            connection = dataConnection.connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlCommand select = connection.CreateCommand();
                select.CommandText = string.Format("SELECT * FROM USERACCOUNTS WHERE username = '{0}'", usernameBox.Text);
                Console.WriteLine(usernameBox.Text);
                connection.Open();
                MySqlDataReader reader = select.ExecuteReader();
                int matches = 0;
                while (reader.Read())
                {
                    Console.WriteLine("Username already exists");
                    matches++;
                }
                connection.Close();

                if (matches == 0)
                {
                    MySqlCommand insert = connection.CreateCommand();
                    insert.CommandText = string.Format("INSERT INTO USERACCOUNTS VALUES ('{0}', '{1}')", usernameBox.Text, passwordBox.Text);
                    Console.WriteLine(insert.CommandText);
                    connection.Open();
                    insert.ExecuteNonQuery();
                    Console.WriteLine("INSERTED");
                    connection.Close();
                    signIn.Dock = DockStyle.Fill;
                    form.Controls.Remove(this);
                    form.Controls.Add(signIn);
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
