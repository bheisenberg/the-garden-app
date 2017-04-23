using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BigHelpers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        public void InitializeView ()
        {
            SignIn signUp = new SignIn();
            signUp.form = this;
            signUp.Dock = DockStyle.Fill;
            this.Controls.Add(signUp);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
