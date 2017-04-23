using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigHelpers
{
    public partial class Request : UserControl
    {
        private string username;
        public string Username
        {
            get { return username; }
            set {
                username = value;
                userLabel.Text = username; }
        }
        private string title;
        public string Title {
            get { return title; }
            set { title = value;
                postTitle.Text = title;
            }
        }
        private string description;
        public string Description
        { get { return description; }
            set { description = value; descriptionBox.Text = description; }
        }
        private List<string> tags;
        public List<string> Tags
        {
            get { return tags; }
            set { foreach (string tag in tags)
                {
                    Button button = new Button();
                    button.Text = tag;
                    button.Dock = DockStyle.Left;
                    tagpanel.Controls.Add(button);
                }
            }
        }

        public Request(string username, string title, string description, List<string> tags)
        {
            InitializeComponent();
            this.Username = username;
            this.Title = title;
            this.Description = description;
            this.tags = tags;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Request_Load(object sender, EventArgs e)
        {

        }

        private void tag3_Click(object sender, EventArgs e)
        {

        }
    }
}
