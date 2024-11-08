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
    public partial class Profile : Form
    {
        private string profileName;
        private string profileEmail;
        public Profile(string name, string email)
        {
            InitializeComponent();
            profileName = name;
            profileEmail = email;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Profile_Load(object sender, EventArgs e)
        {
            lblEmail.Text = profileEmail;
            lblName.Text = profileName;
        }

        private void buttoLogout_Click(object sender, EventArgs e)
        {
            login login_ = new login();
            login_.Show();
            login_.FormClosed += (s, args) => this.Close();
        }
    }
}
