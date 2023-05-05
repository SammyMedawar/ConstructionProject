using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.CodeDom;

namespace Construction
{
    public partial class Invoices : Form
    {
        //Connection String of the Application
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ToString());

        public Invoices()
        {
            InitializeComponent();
            loadData();
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //create the login page
            Login toPage = new Login();
            //show the login page
            toPage.Show();
            //hide the current page
            this.Hide();
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
                String searchString = tbSearch.Text.ToString();
                if (String.IsNullOrEmpty(tbPaymentLimit.Text.ToString()))
                    return;
                int limit = Int32.Parse(tbPaymentLimit.Text.ToString());
                string query = "SELECT TOP " + limit + " * FROM Invoices WHERE Date BETWEEN '" + dtPickerFrom.Value + "' AND '" + dtPickerTo.Value + "' ";// ORDER BY Date DESC;";
                if (!String.IsNullOrEmpty(searchString))
                    query = query + "AND CompanyName like '"+searchString+"' ";
                if (radioPaid.Checked)
                    query = query + "AND ToPay = 0 ";
                if (radioNotPaid.Checked)
                    query = query + "AND Paid != Total ";
                query = query + "ORDER BY Date DESC;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvInvoices.DataSource = dt;

                //formatting of the datagridview
                DataGridViewColumn x = dgvInvoices.Columns[0];
                x.FillWeight = 70;
                dgvInvoices.Columns[1].FillWeight = 190;
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

        private void reloadData()
        {
            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                if (String.IsNullOrEmpty(tbPaymentLimit.Text.ToString()))
                    return;
                int limit = Int32.Parse(tbPaymentLimit.Text.ToString());
                string query = "SELECT TOP " + limit + " * FROM Invoices WHERE Date BETWEEN '" + dtPickerFrom.Value + "' AND '" + DateTime.Now + "' ORDER BY Date DESC;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvInvoices.DataSource = dt;

                //formatting of the datagridview
                DataGridViewColumn x = dgvInvoices.Columns[0];
                x.FillWeight = 70;
                dgvInvoices.Columns[1].FillWeight = 190;
                tbSearch.Text = "";
                radioAll.Checked = true;
                radioNotPaid.Checked = false;
                radioPaid.Checked = false;
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

        private void tbPaymentLimit_Leave(object sender, EventArgs e)
        {
            loadData();
        }

        private void tbPaymentLimit_KeyDown_1(object sender, KeyEventArgs e)
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            radioAll.Checked = true;
            radioNotPaid.Checked = false;
            radioPaid.Checked = false;
            loadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String searchQuery = tbSearch.Text.ToString();
            searchByCompany(searchQuery);
        }

        private void searchByCompany(String searchQuery)
        {
            string query = "";
            if (String.IsNullOrEmpty(tbPaymentLimit.Text.ToString()))
                return;
            int limit = Int32.Parse(tbPaymentLimit.Text.ToString());

            if(radioAll.Checked)
                query = "SELECT TOP " + limit + " * FROM Invoices WHERE CompanyName like '"+searchQuery+"' AND Date BETWEEN '" + dtPickerFrom.Value + "' AND '" + dtPickerTo.Value + "' ORDER BY Date DESC";
            else if (radioPaid.Checked)
                query = "SELECT TOP " + limit + " * FROM Invoices WHERE ToPay = 0 AND CompanyName like '"+searchQuery+"' AND Date BETWEEN '" + dtPickerFrom.Value + "' AND '" + dtPickerTo.Value + "' ORDER BY Date DESC;";
            else if(radioNotPaid.Checked)
                query = "SELECT TOP " + limit + " * FROM Invoices WHERE Paid != Total AND CompanyName like '" + searchQuery + "' AND Date BETWEEN '" + dtPickerFrom.Value + "' AND '" + dtPickerTo.Value + "' ORDER BY Date DESC;";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvInvoices.DataSource = dt;

            //formatting of the datagridview
            DataGridViewColumn x = dgvInvoices.Columns[0];
            x.FillWeight = 70;
            dgvInvoices.Columns[1].FillWeight = 190;
        }

        private void radioAll_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void radioPaid_Click(object sender, EventArgs e)
        {
            loadDataAllPaid();
        }

        private void loadDataAllPaid()
        {
            String searchQuery = tbSearch.Text.ToString();
            String query = "";
            if (String.IsNullOrEmpty(tbPaymentLimit.Text.ToString()))
                return;
            int limit = Int32.Parse(tbPaymentLimit.Text.ToString());
            if (!String.IsNullOrEmpty(searchQuery)) 
                query = "SELECT TOP " + limit + " * FROM Invoices WHERE ToPay = 0 AND CompanyName like '" + searchQuery + "' AND Date BETWEEN '" + dtPickerFrom.Value + "' AND '" + dtPickerTo.Value + "' ORDER BY Date DESC;"; 
            else
                query = "SELECT TOP " + limit + " * FROM Invoices WHERE ToPay = 0 AND Date BETWEEN '" + dtPickerFrom.Value + "' AND '" + dtPickerTo.Value + "' ORDER BY Date DESC;";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvInvoices.DataSource = dt;

            //formatting of the datagridview
            DataGridViewColumn x = dgvInvoices.Columns[0];
            x.FillWeight = 70;
            dgvInvoices.Columns[1].FillWeight = 190;
        }

        private void radioNotPaid_Click(object sender, EventArgs e)
        {
            loadAllNotPaidData();
        }

        private void loadAllNotPaidData()
        {
            String searchQuery = tbSearch.Text.ToString();
            String query = "";
            if (String.IsNullOrEmpty(tbPaymentLimit.Text.ToString()))
                return;
            int limit = Int32.Parse(tbPaymentLimit.Text.ToString());
            if (!String.IsNullOrEmpty(searchQuery))
                query = "SELECT TOP " + limit + " * FROM Invoices WHERE Paid != Total AND CompanyName like '" + searchQuery + "' AND Date BETWEEN '" + dtPickerFrom.Value + "' AND '" + dtPickerTo.Value + "' ORDER BY Date DESC;";
            else
                query = "SELECT TOP " + limit + " * FROM Invoices WHERE Paid != Total AND Date BETWEEN '" + dtPickerFrom.Value + "' AND '" + dtPickerTo.Value + "' ORDER BY Date DESC;";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvInvoices.DataSource = dt;

            //formatting of the datagridview
            DataGridViewColumn x = dgvInvoices.Columns[0];
            x.FillWeight = 70;
            dgvInvoices.Columns[1].FillWeight = 190;
        }

        private void btnIDSearch_Click(object sender, EventArgs e)
        {
            String searchString = tbID.Text.ToString();
            searchForID(searchString);
        }

        private void searchForID(String searchString)
        {
            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }


            try
            {
                //create search query string
                string query = "SELECT * FROM Invoices where ID = @ID;";

                //create an object SqlCommand that will take the query and the connection string
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ID", searchString);


                //create a data reader that will execute the query
                SqlDataReader dr = cmd.ExecuteReader();

                //if the data reader finds the row, do this
                if (dr.Read())
                {
                    tbID.Text = dr.GetString(0);
                    tbCompanyName.Text = dr.GetString(1);
                    DateTime newDate = dr.GetDateTime(2);
                    dtInvoiceDate.Value = newDate;

                    tbM1Weight.isPlaceHolder = true;
                    tbM1Weight.removePlaceHolder();
                    tbM1Weight.Text = dr.GetFloat(3).ToString();

                    tbM1Price.isPlaceHolder = true;
                    tbM1Price.removePlaceHolder();
                    tbM1Price.Text = dr.GetFloat(4).ToString();

                    tbM2Amount.isPlaceHolder = true;
                    tbM2Amount.removePlaceHolder();
                    tbM2Amount.Text = dr.GetFloat(5).ToString();

                    tbM2Price.isPlaceHolder = true;
                    tbM2Price.removePlaceHolder();
                    tbM2Price.Text = dr.GetFloat(6).ToString();

                    tbM3Weight.isPlaceHolder = true;
                    tbM3Weight.removePlaceHolder();
                    tbM3Weight.Text = dr.GetFloat(7).ToString();

                    tbM3Price.isPlaceHolder = true;
                    tbM3Price.removePlaceHolder();
                    tbM3Price.Text = dr.GetFloat(8).ToString();

                    tbPrice.Text = dr.GetFloat(9).ToString();
                    tbPaid.Text = dr.GetFloat(11).ToString();
                }


                else
                {
                    MessageBox.Show("An Invoice with the ID " + searchString + " doesn't exist!");

                }
            }
            catch(Exception msg)
            {
                MessageBox.Show("An error has occured! Please try again");
            }

            

            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if(Double.Parse(tbPrice.Text.ToString()) < Double.Parse(tbPaid.Text.ToString()))
            {
                MessageBox.Show("Please fill in the pricing correctly");
                return;
            }
            if (checkForEmptyTextBoxes())
            {
                MessageBox.Show("Please Fill in All the Boxes");
                return;
            }

            if (tbCompanyName.Text.ToString().Contains("\"") || tbCompanyName.Text.ToString().Contains("\'"))
            {
                MessageBox.Show("Quotations (\") and Apostrophes (\') are not Allowed ");
                return;
            }
            
            String ID = tbID.Text.ToString();
            if (checkIfIDExists(ID))
            {
                updateInvoice();
            }
            else
            {
                insertInvoice();
            }
        }

        private void updateInvoice()
        {
            bool hasErred = false;
            String totalPay = "", toPayStr = "", paid = "", ID = "";

            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                SqlCommand cmd = new SqlCommand("UpdateInvoice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tbID.Text.ToString());
                cmd.Parameters.AddWithValue("@CompanyName", tbCompanyName.Text.ToString());
                cmd.Parameters.AddWithValue("@Date", dtInvoiceDate.Value);
                if (String.IsNullOrEmpty(tbM1Weight.Text.ToString()))
                    cmd.Parameters.AddWithValue("@M1Weight", 0);
                else
                    cmd.Parameters.AddWithValue("@M1Weight", Double.Parse(tbM1Weight.Text.ToString()));

                if (String.IsNullOrEmpty(tbM1Price.Text.ToString()))
                    cmd.Parameters.AddWithValue("@M1Price", 0);
                else
                    cmd.Parameters.AddWithValue("@M1Price", Double.Parse(tbM1Price.Text.ToString()));

                if (String.IsNullOrEmpty(tbM2Amount.Text.ToString()))
                    cmd.Parameters.AddWithValue("@M2Amount", 0);
                else
                    cmd.Parameters.AddWithValue("@M2Amount", Double.Parse(tbM2Amount.Text.ToString()));

                if (String.IsNullOrEmpty(tbM2Price.Text.ToString()))
                    cmd.Parameters.AddWithValue("@M2Price", 0);
                else
                    cmd.Parameters.AddWithValue("@M2Price", Double.Parse(tbM2Price.Text.ToString()));

                if (String.IsNullOrEmpty(tbM3Weight.Text.ToString()))
                    cmd.Parameters.AddWithValue("@M3Weight", 0);
                else
                    cmd.Parameters.AddWithValue("@M3Weight", Double.Parse(tbM3Weight.Text.ToString()));

                if (String.IsNullOrEmpty(tbM3Price.Text.ToString()))
                    cmd.Parameters.AddWithValue("@M3Price", 0);
                else
                    cmd.Parameters.AddWithValue("@M3Price", Double.Parse(tbM3Price.Text.ToString()));

                cmd.Parameters.AddWithValue("@Total", Double.Parse(tbPrice.Text.ToString()));
                cmd.Parameters.AddWithValue("@Paid", Double.Parse(tbPaid.Text.ToString()));
                double toPay = Double.Parse(tbPrice.Text.ToString()) - Double.Parse(tbPaid.Text.ToString());
                cmd.Parameters.AddWithValue("@ToPay", toPay);


                totalPay = tbPrice.Text.ToString();
                paid = tbPaid.Text.ToString();
                ID = tbID.Text.ToString();
                toPayStr = toPay.ToString();

                cmd.ExecuteNonQuery();
                tbID.Text = "";
                tbCompanyName.Text = "";
                tbM1Weight.Text = "";
                tbM1Weight.setPlaceholder();
                tbM1Price.Text = "";
                tbM1Price.setPlaceholder();
                tbM2Amount.Text = "";
                tbM2Amount.setPlaceholder();
                tbM2Price.Text = "";
                tbM2Price.setPlaceholder();
                tbM3Weight.Text = "";
                tbM3Weight.setPlaceholder();
                tbM3Price.Text = "";
                tbM3Price.setPlaceholder();
                tbPaid.Text = "";
                tbPrice.Text = "";
            }

            catch (Exception msg)
            {
                MessageBox.Show("Oops! An error has occured. Please recheck what you entered");
                hasErred = true;
            }

            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (hasErred)
                return;


            dgvInvoices.Invalidate();
            dgvInvoices.Refresh();
            dgvInvoices.DataSource = null;
            dgvInvoices.Refresh();

            MessageBox.Show("Invoice of ID " + ID + " has been updated with the following details \nTotal Price: " + totalPay +
                " \nAmount Paid: " + paid + " \nAmount Left: " + toPayStr);
            loadData();
        }

        private void insertInvoice()
        {
            bool hasErred = false;
            String totalPay = "", toPayStr = "", paid = "", ID = "";

            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                SqlCommand cmd = new SqlCommand("InsertInvoice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tbID.Text.ToString());
                cmd.Parameters.AddWithValue("@CompanyName", tbCompanyName.Text.ToString());
                cmd.Parameters.AddWithValue("@Date", dtInvoiceDate.Value);

                if (String.IsNullOrEmpty(tbM1Weight.Text.ToString()))
                    cmd.Parameters.AddWithValue("@M1Weight", 0);
                else
                    cmd.Parameters.AddWithValue("@M1Weight", Double.Parse(tbM1Weight.Text.ToString()));

                if (String.IsNullOrEmpty(tbM1Price.Text.ToString()))
                    cmd.Parameters.AddWithValue("@M1Price", 0);
                else
                    cmd.Parameters.AddWithValue("@M1Price", Double.Parse(tbM1Price.Text.ToString()));

                if (String.IsNullOrEmpty(tbM2Amount.Text.ToString()))
                    cmd.Parameters.AddWithValue("@M2Weight", 0);
                else
                    cmd.Parameters.AddWithValue("@M2Weight", Double.Parse(tbM2Amount.Text.ToString()));

                if (String.IsNullOrEmpty(tbM2Price.Text.ToString()))
                    cmd.Parameters.AddWithValue("@M2Price", 0);
                else
                    cmd.Parameters.AddWithValue("@M2Price", Double.Parse(tbM2Price.Text.ToString()));

                if (String.IsNullOrEmpty(tbM3Weight.Text.ToString()))
                    cmd.Parameters.AddWithValue("@M3Weight", 0);
                else
                    cmd.Parameters.AddWithValue("@M3Weight", Double.Parse(tbM3Weight.Text.ToString()));


                if (String.IsNullOrEmpty(tbM3Price.Text.ToString()))
                    cmd.Parameters.AddWithValue("@M3Price", 0);
                else
                    cmd.Parameters.AddWithValue("@M3Price", Double.Parse(tbM3Price.Text.ToString()));

                cmd.Parameters.AddWithValue("@Total", Double.Parse(tbPrice.Text.ToString()));
                cmd.Parameters.AddWithValue("@Paid", Double.Parse(tbPaid.Text.ToString()));
                double toPay = Double.Parse(tbPrice.Text.ToString()) - Double.Parse(tbPaid.Text.ToString());
                cmd.Parameters.AddWithValue("@ToPay", toPay);


                totalPay = tbPrice.Text.ToString();
                paid = tbPaid.Text.ToString();
                ID = tbID.Text.ToString();
                toPayStr = toPay.ToString();

                cmd.ExecuteNonQuery();
                tbID.Text = "";
                tbCompanyName.Text = "";
                tbM1Weight.Text = "";
                tbM1Weight.setPlaceholder();
                tbM1Price.Text = "";
                tbM1Price.setPlaceholder();
                tbM2Amount.Text = "";
                tbM2Amount.setPlaceholder();
                tbM2Price.Text = "";
                tbM2Price.setPlaceholder();
                tbM3Weight.Text = "";
                tbM3Weight.setPlaceholder();
                tbM3Price.Text = "";
                tbM3Price.setPlaceholder();
                tbPaid.Text = "";
                tbPrice.Text = "";
            }

            catch (Exception msg)
            {
                MessageBox.Show("Oops! An error has occured. Please recheck what you entered");
                hasErred = true;
            }

            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (hasErred)
                return;


            dgvInvoices.Invalidate();
            dgvInvoices.Refresh();
            dgvInvoices.DataSource = null;
            dgvInvoices.Refresh();

            MessageBox.Show("Invoice of ID " + ID + " has been added with the following details \nTotal Price: " + totalPay +
                " \nAmount Paid: " + paid + " \nAmount Left: " + toPayStr);
            loadData();
        }

        private bool checkForEmptyTextBoxes()
        {
            if(String.IsNullOrEmpty(tbID.Text) || String.IsNullOrEmpty(tbCompanyName.Text) || dtInvoiceDate.Text.Length == 0
                || String.IsNullOrEmpty(tbPrice.Text) || String.IsNullOrEmpty(tbPaid.Text))
            {
                return true;
            }

            return false;
        }

        private bool checkIfIDExists(String ID)
        {

            bool doesExist = false;

            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }


            try
            {
                //create search query string
                string query = "SELECT * FROM Invoices where ID = @ID;";

                //create an object SqlCommand that will take the query and the connection string
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ID", ID);


                //create a data reader that will execute the query
                SqlDataReader dr = cmd.ExecuteReader();

                //if the data reader finds the row, do this
                if (dr.Read())
                {
                    doesExist = true;
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show("An error has occured! Please try again");
            }



            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            return doesExist;
        }
    }
}
