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
using System.Data.SQLite;

namespace Construction
{
    public partial class Payments : Form
    {
        //Connection String of the Application
        SQLiteConnection con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;", true);
        public Payments()
        {
            InitializeComponent();
            DateTime newFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01, 00, 00, 00);
            dtPickerFrom.Value = newFrom;
            dtPickerTo.Value = DateTime.Now;
            loadData();

        }

        private void loadData()
        {

            //check if connection is closed, if so open it
            con.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                if (String.IsNullOrEmpty(tbPaymentLimit.Text.ToString()))
                {
                    MessageBox.Show("Please make sure the limit box has numbers in it", "Error!");
                    tbPaymentLimit.Text = "25";
                    con.Close();
                    return;
                }

                if (!Int32.TryParse(tbPaymentLimit.Text, out int j))
                {
                    MessageBox.Show("Please make sure the limit box has numbers in it", "Error");
                    tbPaymentLimit.Text = "25";
                    con.Close();
                    return;

                }

                double total = 0;
                int limit = Int32.Parse(tbPaymentLimit.Text.ToString());
                DateTime oldTo = dtPickerTo.Value;
                DateTime newTo = new DateTime(oldTo.Year, oldTo.Month, oldTo.Day, 23, 59, 59);
                string query = "SELECT Description, Paid, DateTime FROM MiscPayments WHERE DateTime BETWEEN '" + dtPickerFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + newTo.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY DateTime DESC LIMIT " +limit + ";";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, con);
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
                MessageBox.Show("Oops! An error has occured. Please restart the application", "Error");
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
            Homepage.Instance.Show();
            Homepage.Instance.loadData();
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
            DateTime y = dtPickerFrom.Value;
            dtPickerFrom.Value = new DateTime(y.Year, y.Month, y.Day, 00, 00, 00);
            if (dtPickerTo.Value < dtPickerFrom.Value)
            {
                DateTime x = dtPickerFrom.Value;
                MessageBox.Show("Date To cannot take place before Date From", "Error");
                dtPickerTo.Value = new DateTime(x.Year, x.Month, x.Day, 23, 59, 59);
            }
            loadData();
        }

        private void dtPickerTo_CloseUp(object sender, EventArgs e)
        {
            DateTime y = dtPickerTo.Value;
            dtPickerTo.Value = new DateTime(y.Year, y.Month, y.Day, 23, 59, 30);
            if(dtPickerTo.Value < dtPickerFrom.Value)
            {
                DateTime x = dtPickerFrom.Value;
                MessageBox.Show("Date To cannot take place before Date From", "Error");
                dtPickerTo.Value = new DateTime(x.Year, x.Month, x.Day, 23, 59, 59);
            }
            loadData();
        }

        private void btnPaymentUpdate_Click(object sender, EventArgs e)
        {
            bool hasErred = false;

            if (String.IsNullOrEmpty(tbPPaid.Text.ToString()) || String.IsNullOrEmpty(tbPDesc.Text.ToString()))
            {
                MessageBox.Show("Please fill in all the fields correctly", "Error");
                return; 
            }

            //check if connection is closed, if so open it
            con.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO MiscPayments (Description, Paid, DateTime) VALUES (@Description, @Paid, @DateTime);", con);
      
                cmd.Parameters.AddWithValue("@Description", tbPDesc.Text.ToString());
                cmd.Parameters.AddWithValue("@Paid", Double.Parse(tbPPaid.Text.ToString()));
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                cmd.ExecuteNonQuery();
            }

            catch (Exception msg)
            {
                MessageBox.Show("Oops! An error has occured. Please recheck what you entered", "Error");
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

            MessageBox.Show("Payment of " + tbPPaid.Text.ToString() + " has been successfully added", "Operation Successful!");
            tbPPaid.Text = "";
            tbPDesc.Text = "";
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
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT Description, Paid, DateTime FROM MiscPayments  WHERE DateTime BETWEEN '" + dtPickerFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59,59).ToString("yyyy-MM-dd HH:mm:ss") + "' OR DateTime = '"+ newDateTime.ToString("yyyy-MM-dd HH:mm:ss")+"' ORDER BY DateTime DESC LIMIT " +limit+ "; ", con);
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
            dgvPayments.Columns[2].HeaderCell.Value = "Date of Payment";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += 0.2;
        }

        private void tbPaymentLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Payments_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucSettings.Instance.backupData();
            Application.Exit();
        }

        private void tbPaymentLimit_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
