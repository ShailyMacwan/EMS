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
    public partial class Dashoboard : Form
    {
        private string Name;
        private string Email;
        public Dashoboard(string name, string email)
        {
            InitializeComponent();
            Name = name;
            Email = email;
        }

        private void Dashoboard_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"Welcome , {Name}";
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(Name, Email);
            profile.Show();
            profile.FormClosed += (s, args) => this.Close();


        }

        private void report_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
            report.FormClosed += (s, args) => this.Close();

        }
    }
}
