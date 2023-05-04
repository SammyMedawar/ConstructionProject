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
    public partial class Payments : Form
    {
        //Connection String of the Application
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ToString());
        public Payments()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {

            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                int limit = Int32.Parse(tbPaymentLimit.Text.ToString());
                string query = "SELECT TOP " + limit + " * FROM MiscPayments WHERE DateTime BETWEEN '" + dtPickerFrom.Value + "' AND '" + dtPickerTo.Value + "';";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvPayments.DataSource = null;
                dgvPayments.DataSource = dt;
            }
            catch (Exception msg)
            {
                MessageBox.Show("Oops! An error has occured. Please restart the application");
            }

            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //create the login page
            Login toPage = new Login();
            //show the login page
            toPage.Show();
            //hide the current page
            this.Hide();
        }

        private void btnHomepage_Click(object sender, EventArgs e)
        {
            //create the homepage
            Homepage toPage = new Homepage();
            //show the homepage
            toPage.Show();
            //hide the current page
            this.Hide();
        }

        private void tbPaymentLimit_KeyDown(object sender, KeyEventArgs e)
        {
            loadData();
        }

        private void tbPaymentLimit_Leave(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtPickerFrom_CloseUp(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtPickerTo_CloseUp(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnPaymentUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbPPaid.Text.ToString()) || String.IsNullOrEmpty(tbPDesc.Text.ToString()))
            { return; }

            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                String query = "INSERT INTO MiscPayments (Description, Paid, DateTime) VALUES (@Description, @Paid, @DateTime)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Description", tbPDesc.Text.ToString());
                cmd.Parameters.AddWithValue("@Paid", Double.Parse(tbPPaid.Text.ToString()));
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.ExecuteNonQuery();
                dgvPayments.Invalidate();
                dgvPayments.Refresh();
                loadData();
                dgvPayments.Refresh();
                MessageBox.Show("Payment of " + tbPPaid.Text.ToString() + " has been successfully added");
                tbPPaid.Text = "";
                tbPDesc.Text = "";
            }

            catch (Exception msg)
            {
                MessageBox.Show("Oops! An error has occured. Please recheck what you entered");
            }

            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }


            loadData();
        }
    }
}
