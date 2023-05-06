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
using Microsoft.SqlServer.Server;
using System.Collections;

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
                double total = 0;
                if (String.IsNullOrEmpty(tbPaymentLimit.Text.ToString()))
                    return;
                int limit = Int32.Parse(tbPaymentLimit.Text.ToString());
                DateTime oldTo = dtPickerTo.Value;
                DateTime newTo = new DateTime(oldTo.Year, oldTo.Month, oldTo.Day, 23, 59, 59);
                string query = "SELECT TOP " + limit + " Description, Paid, DateTime FROM MiscPayments WHERE DateTime BETWEEN '" + dtPickerFrom.Value + "' AND '" + newTo + "' ORDER BY DateTime DESC;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvPayments.DataSource = dt;

                foreach (DataGridViewRow row in dgvPayments.Rows)
                {
                    total = total + Convert.ToDouble(row.Cells[1].Value);
                }

                labelTotalPaid.Text = String.Format("{0:0.00}", total);
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
            bool hasErred = false;

            if (String.IsNullOrEmpty(tbPPaid.Text.ToString()) || String.IsNullOrEmpty(tbPDesc.Text.ToString()))
            {
                MessageBox.Show("Please fill in all the fields correctly");
                return; 
            }

            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                SqlCommand cmd = new SqlCommand("Procedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Description", tbPDesc.Text.ToString());
                cmd.Parameters.AddWithValue("@Paid", Double.Parse(tbPPaid.Text.ToString()));
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);

                cmd.ExecuteNonQuery();
                tbPPaid.Text = "";
                tbPDesc.Text = "";
            }

            catch (Exception msg)
            {
                MessageBox.Show("Oops! An error has occured. Please recheck what you entered");
                con.Close();
                return;
            }

            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }


            dgvPayments.Invalidate();
            dgvPayments.Refresh();
            dgvPayments.DataSource = null;
            dgvPayments.Refresh();

            MessageBox.Show("Payment of " + tbPPaid.Text.ToString() + " has been successfully added");
            reloadData();
            


        }


        //For some reason, select query is not showing the latest result if I use a normal loadData() after inserting
        //I found the problem was related to the datetimepicker
        private void reloadData()
        {
            double total = 0;

            if (String.IsNullOrEmpty(tbPaymentLimit.Text.ToString()))
                return;
            int limit = Int32.Parse(tbPaymentLimit.Text.ToString());
            con.Open();
            DateTime now = DateTime.Now;
            DateTime newDateTime = new DateTime(now.Year, now.Month, now.Day, 23, 59, 0);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP " + limit + " Description, Paid, DateTime FROM MiscPayments  WHERE DateTime BETWEEN '" + dtPickerFrom.Value + "' AND '" + new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59,59) + "' OR DateTime = '"+newDateTime+"' ORDER BY DateTime DESC; ", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvPayments.DataSource = null;
            dgvPayments.DataSource = dt;
            con.Close();

            foreach (DataGridViewRow row in dgvPayments.Rows)
            {
                total = total + Convert.ToDouble(row.Cells[1].Value);
            }

            labelTotalPaid.Text = String.Format("{0:0.00}", total);

        }

        private void Payments_Load(object sender, EventArgs e)
        {

        }

        private void dgvPayments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPayments.ClearSelection();
            //Make columns of datagridview unsortable
            foreach (DataGridViewColumn column in dgvPayments.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
