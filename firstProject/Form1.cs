using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void signup_Click(object sender, EventArgs e)
        {
            signup SP = new signup();
            SP.Show();
            this.Hide();
            SP.FormClosed += (s, args) => this.Close();
        }

        private void login_Click(object sender, EventArgs e)
        {
            login Login = new login();
            Login.Show();
            this.Hide();
            Login.FormClosed += (s, args) => this.Close();
        }
    }
}
