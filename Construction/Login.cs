using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Construction
{
    public partial class Login : Form
    {
        //Connection String of the Application
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ToString());
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {

            //if the checkbox for show password is not checked, remove the stars
            if (cbShowPassword.Checked)
            {
                tbPassword.PasswordChar = '\0';
            }
            //if the checkbox for show password is checked, change its text to stars
            else
            {
                tbPassword.PasswordChar = '*';
            }
        }

        private void login()
        {
            //initialize variables using the values from the textboxes
            string username = tbUsername.Text;
            string password = tbPassword.Text;


            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }


            //create search query string
            string query = "SELECT * FROM Users WHERE Username = @username AND Password = @password";

            //create an object SqlCommand that will take the query and the connection string
            SqlCommand cmd = new SqlCommand(query, con);

            //explain what the parameters with @ in the conenction string mean
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);


            //create a data reader that will execute the query
            SqlDataReader dr = cmd.ExecuteReader();

            //if the data reader finds the row, do this
            if (dr.Read())
            {
                //create the homepage
                Homepage toPage = new Homepage();
                //show the homepage
                toPage.Show();
                //hide the current page
                this.Hide();
            }

            else
            {
                MessageBox.Show("Invalid Username or Password!");

            }

            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

        }

        private void keyDownLogin(object sender, KeyEventArgs e)
        {
            //if enter key is pressed, login
            if (e.KeyCode == Keys.Enter)
                login();
        }

        private void keyDownLoginTBPassword(object sender, KeyEventArgs e)
        {
            //if enter key is pressed, login
            if (e.KeyCode == Keys.Enter)
                login();
        }

        private void keyDownTBUsername(object sender, KeyEventArgs e)
        {
            //if enter key is pressed, login
            if (e.KeyCode == Keys.Enter)
                login();
        }
    }
}
