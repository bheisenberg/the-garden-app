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
    public partial class MainView : UserControl
    {
        public Panel panel;
        public User currentUser;

        public MainView()
        {
            InitializeComponent();
            this.panel = app;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            NewPostForm newPost = new NewPostForm();
            NewPost post = new NewPost();
            post.Dock = DockStyle.Fill;
            newPost.StartPosition = FormStartPosition.CenterScreen;
            newPost.Controls.Add(post);
            newPost.Show();
            newPost.TopMost = true;
            post.control = this;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            DataConnector dataConnection = new DataConnector();
            MySqlConnection connection = dataConnection.connection;
            MySqlCommand select = connection.CreateCommand();
            select.CommandText = ("SELECT * FROM POSTS");
            connection.Open();
            MySqlDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                Request request = new Request(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), new List<string>() { reader[3].ToString() });
                request.Dock = DockStyle.Top;
                app.Controls.Add(request);
            }
            connection.Close();
        }
    }
}
