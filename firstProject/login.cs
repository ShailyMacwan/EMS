using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.ComponentModel.Composition.Primitives;


namespace firstProject
{
    public partial class login : Form
    {
        private IMongoCollection<BsonDocument> collection;
        public login()
        {
            InitializeComponent();

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Register");
            collection = database.GetCollection<BsonDocument>("user");
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string email = textEmail.Text;
            string password = textPassword.Text;

            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("Email", email),
                Builders<BsonDocument>.Filter.Eq("Password", password));

            var endResult = collection.Find(filter).FirstOrDefault();

            if (endResult == null)
            {
                MessageBox.Show("Please enter correct credentials");
            }
            else
            {
                string name = endResult["Name"].AsString;


                MessageBox.Show("Login successful");
                Dashoboard db = new Dashoboard(name, email);
                db.Show();
                this.Hide();
                db.FormClosed += (s, args) => this.Close();


                Profile profile = new Profile(name, email);
            }





        }

        private void signupOnLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup signup = new signup();
            signup.Show();
            signup.FormClosed += (s, args) => this.Close();
        }
    }
}
