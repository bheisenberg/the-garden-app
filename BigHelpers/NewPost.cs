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
    public partial class NewPost : UserControl
    {
        public MainView control;

        public NewPost()
        {
            InitializeComponent();
            ActiveControl = titleText;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TagSplitter splitter = new TagSplitter(tagsText.Text);
            Request request = new Request(control.currentUser.name, titleText.Text, descriptionText.Text, splitter.tags);
            request.Dock = DockStyle.Top;
            control.panel.Controls.Add(request);

            DataConnector dataConnector = new DataConnector();
            MySqlConnection connection = dataConnector.connection;
            MySqlCommand insert = connection.CreateCommand();
            insert.CommandText = string.Format("INSERT INTO POSTS VALUES ('{0}', '{1}', '{2}', '{3}')", control.currentUser.name, titleText.Text, descriptionText.Text, splitter.tags[0]);
            Console.WriteLine(insert.CommandText);
            connection.Open();
            insert.ExecuteNonQuery();
            Console.WriteLine("INSERTED");
            connection.Close();
            this.ParentForm.Close();
        }
    }
}
