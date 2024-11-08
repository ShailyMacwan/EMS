using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace firstProject
{
    public partial class signup : Form
    {
        private IMongoCollection<BsonDocument> user_collection;
            
        public signup()
        {
            InitializeComponent();

            var client = new MongoClient("mongodb://localhost:27017/");
            var database = client.GetDatabase("Register");
            user_collection = database.GetCollection<BsonDocument>("user");
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            string email = textEmail.Text;
            string password = textPassword.Text;
            string name = textName.Text;

            var filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            var endResult = user_collection.Find(filter).FirstOrDefault();

            if (endResult != null)
            {
                MessageBox.Show("An account already exists with this email");
                return;
            }

            var document = new BsonDocument
            {

                {"Name"  , name },
                { "Password" , password },
                {"Email" , email }

            };

            user_collection.InsertOne(document);
            MessageBox.Show("Account created");
            ClearForm();     

        }

        private void ClearForm()
        {
            textEmail.Clear();
            textPassword.Clear();
            textName.Clear();
        }

        private void loginONSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login login = new login();
            login.Show();
            login.FormClosed += (s, args) => this.Close();
        }
    }
}
