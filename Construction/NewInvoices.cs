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
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Construction
{
    public partial class NewInvoices : Form
    {
        //Connection String of the Application
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ToString());
        
        public NewInvoices()
        {
            InitializeComponent();
            DateTime newFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01, 00, 00, 00);
            dtPickerFrom.Value = newFrom;
            dtPickerTo.Value = DateTime.Now;
            loadData();
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

        private void loadData()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                //Intitiaize the variables to be used
                String limitInvoice = tbLimitInvoice.Text.ToString();
                String limitInvoiceDetails = tbLimitInvoiceDetails.Text.ToString();
                String searchString = tbSearch.Text.ToString();

                
                DateTime fromDateOr = dtPickerFrom.Value;
                DateTime toDateOr = dtPickerTo.Value;
                DateTime fromDate, toDate;

                //If the user makes it so that toDate = fromDate, make sure toDate starts at 12am
                if (fromDateOr == toDateOr)
                {
                    fromDate = new DateTime(fromDateOr.Year, fromDateOr.Month, fromDateOr.Day, 00, 00, 00);
                }
                else
                {
                    fromDate = new DateTime(fromDateOr.Year, fromDateOr.Month, fromDateOr.Day, 23, 59, 0);
                }

                 toDate = new DateTime(toDateOr.Year, toDateOr.Month, toDateOr.Day, 23, 59, 0);

                if(toDate < fromDate)
                {
                    MessageBox.Show("Please make sure the To Date is higher than the From Date");
                    DateTime newFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01, 00, 00, 00);
                    dtPickerFrom.Value = newFrom;
                    dtPickerTo.Value = DateTime.Now;
                    return;
                }
                int limitInvoiceInt, limitInvoiceDetailsInt;

                //End of Initialization of variables


                //Check if limit boxes are filled, if not return
                if (String.IsNullOrEmpty(limitInvoice) || String.IsNullOrEmpty(limitInvoiceDetails))
                {
                    MessageBox.Show("Please make sure the limit boxes have numbers in them");
                    return;
                }

                //if the limit boxes have words in them and not letters, give an error
                if (Int32.TryParse(limitInvoice, out limitInvoiceInt) && Int32.TryParse(limitInvoiceDetails, out limitInvoiceDetailsInt))
                {
                    //begin of load data for invoices table
                    StringBuilder queryBuilderOne = new StringBuilder();
                    queryBuilderOne.Append("SELECT TOP ");
                    queryBuilderOne.Append(limitInvoice);
                    queryBuilderOne.Append(" * FROM NewInvoices WHERE DateInv BETWEEN \'");
                    queryBuilderOne.Append(fromDate);
                    queryBuilderOne.Append("\' AND \'");
                    queryBuilderOne.Append(toDate);
                    queryBuilderOne.Append("\'");
                    //If the user is searching something
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        if (radioID.Checked)
                        {
                            queryBuilderOne.Append(" AND ID = \'");
                        }
                        else if (radioCompany.Checked)
                        {
                            queryBuilderOne.Append(" AND CompanyName = \'");
                        }
                        queryBuilderOne.Append(searchString);
                        queryBuilderOne.Append("\'");
                    }
                    //For the payment radio buttons, if any are chosen]
                    else if (radioPaid.Checked)
                    {
                        queryBuilderOne.Append(" AND ToPay = 0 ");
                    }
                    else if (radioNotPaid.Checked)
                    {
                        queryBuilderOne.Append(" AND Paid != Total ");
                    }
                    queryBuilderOne.Append(" ORDER BY DateInv DESC");

                    //begin of load data for invoices details table
                    StringBuilder queryBuilderTwo = new StringBuilder();
                    queryBuilderTwo.Append("SELECT TOP ");
                    queryBuilderTwo.Append(limitInvoiceDetails);
                    queryBuilderTwo.Append(" NewInvoicesDetails.InvoiceID, Materials.Name, Quantity, Price ");
                    queryBuilderTwo.Append(" FROM NewInvoicesDetails INNER JOIN Materials ON NewInvoicesDetails.MaterialID = Materials.ID ");
                    queryBuilderTwo.Append(" INNER JOIN NewInvoices ON NewInvoicesDetails.InvoiceID = NewInvoices.ID ");
                    queryBuilderTwo.Append(" WHERE NewInvoices.DateInv BETWEEN \'");
                    queryBuilderTwo.Append(fromDate);
                    queryBuilderTwo.Append("\' AND \'");
                    queryBuilderTwo.Append(toDate);
                    queryBuilderTwo.Append("\'");
                    //If the user is searching something
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        if (radioID.Checked)
                        {
                            queryBuilderTwo.Append(" AND NewInvoices.ID = \'");
                        }
                        else if (radioCompany.Checked)
                        {
                            queryBuilderTwo.Append(" AND CompanyName = \'");
                        }
                        queryBuilderTwo.Append(searchString);
                        queryBuilderTwo.Append("\' ");
                    }
                    //For the payment radio buttons, if any are chosen]
                    else if (radioPaid.Checked)
                    {
                        queryBuilderTwo.Append(" AND ToPay = 0 ");
                    }
                    else if (radioNotPaid.Checked)
                    {
                        queryBuilderTwo.Append(" AND Paid != Total ");
                    }
                    queryBuilderTwo.Append(" ORDER BY DateInv DESC");


                    SqlDataAdapter adapter = new SqlDataAdapter(queryBuilderOne.ToString(), con);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(queryBuilderTwo.ToString(), con);
                    DataTable dt = new DataTable();
                    DataTable dt2 = new DataTable();
                    adapter.Fill(dt);
                    adapter2.Fill(dt2);
                    dgvInvoices.DataSource = dt;
                    dgvInvoicesDetails.DataSource = dt2;

                    loadFinances();

                }
                else
                {
                    MessageBox.Show("Please make sure the limit boxes have numbers in them");
                    return;
                }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                String query = "";
                SqlCommand cmd3 = null;
                //check if that searched item exists
                //create search query string
                if (radioCompany.Checked)
                {
                    query = "SELECT CompanyName FROM NewInvoices WHERE CompanyName = @CompanyName";
                    //create an object SqlCommand that will take the query and the connection string
                    cmd3 = new SqlCommand(query, con);
                    //explain what the parameters with @ in the conenction string mean
                    cmd3.Parameters.AddWithValue("@CompanyName", tbSearch.Text.ToString());
                }
                else if (radioID.Checked)
                {
                    query = "SELECT ID FROM NewInvoices WHERE ID = @ID";
                    cmd3 = new SqlCommand(query, con);
                    //explain what the parameters with @ in the conenction string mean
                    cmd3.Parameters.AddWithValue("@ID", tbSearch.Text.ToString());
                }


                //create a data reader that will execute the query
                SqlDataReader dr2 = cmd3.ExecuteReader();

                //if the data reader finds the row, do this
                if (dr2.Read())
                {
                    con.Close();
                    loadData();
                }

                else
                {
                    if (radioID.Checked)
                    {
                        MessageBox.Show("An invoice with the ID " + tbSearch.Text + " doesn't exist so far!");
                    }
                    else if (radioCompany.Checked)
                    {
                        MessageBox.Show("A Company with the name " + tbSearch.Text + " doesn't exist so far!");
                    }
                    return;
                }

            }catch(Exception msg)
            {
                MessageBox.Show("Please make sure the search bar is filled in correctly!");
            }

            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void radioCompany_Click(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            loadData();
        }

        private void radioID_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
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

        private void radioAll_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void radioPaid_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void radioNotPaid_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void tbLimitInvoice_Leave(object sender, EventArgs e)
        {
            if (tbLimitInvoice.Text.ToString().Length == 0)
                return;
            loadData();
        }

        private void tbLimitInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbLimitInvoice.Text.ToString().Length == 0)
                return;
            loadData();
        }

        private void tbLimitInvoiceDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbLimitInvoiceDetails.Text.ToString().Length == 0)
                return;
            loadData();
        }

        private void tbLimitInvoiceDetails_Leave(object sender, EventArgs e)
        {
            if (tbLimitInvoiceDetails.Text.ToString().Length == 0)
                return;
            loadData();
        }

        private void reload()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            tbLimitInvoice.Text = "25";
            tbLimitInvoiceDetails.Text = "50";
            tbSearch.setPlaceholder();
            tbSearch.isPlaceHolder = true;
            tbSearch.Text = "Search...";

            radioCompany.Checked = true;
            radioID.Checked = false;
            DateTime newFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01, 00, 00, 00);
            dtPickerFrom.Value = newFrom;
            dtPickerTo.Value = DateTime.Now;
            radioAll.Checked = true;
            radioPaid.Checked = false;
            radioNotPaid.Checked = false;
            loadData();
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            reload();
        }

        private void loadFinances()
        {
            Double toPay = 0, paid = 0, total = 0;
            foreach (DataGridViewRow row in dgvInvoices.Rows)
            {
                total = total + Convert.ToDouble(row.Cells[3].Value);
                toPay = toPay + Convert.ToDouble(row.Cells[4].Value);
                paid = paid + Convert.ToDouble(row.Cells[5].Value);
            }

            //round the numbers and set them as the texts of the label
            labelTotal.Text = String.Format("{0:0.00}", total);
            labelToPay.Text = String.Format("{0:0.00}", toPay);
            labelPaid.Text = String.Format("{0:0.00}", paid);
        }

        private void dgvInvoices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvInvoices.ClearSelection();
            //Make columns of datagridview unsortable
            foreach (DataGridViewColumn column in dgvInvoices.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvInvoices.Columns[1].HeaderCell.Value = "Company Name";
            dgvInvoices.Columns[2].HeaderCell.Value = "Date of Invoice";
            dgvInvoices.Columns[3].HeaderCell.Value = "Price";
            dgvInvoices.Columns[4].HeaderCell.Value = "To Pay";
            dgvInvoices.Columns[5].HeaderCell.Value = "Paid So Far";
        }

        private void dgvInvoicesDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvInvoicesDetails.ClearSelection();
            //Make columns of datagridview unsortable
            foreach (DataGridViewColumn column in dgvInvoicesDetails.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvInvoicesDetails.Columns[0].HeaderCell.Value = "Invoice ID";
            dgvInvoicesDetails.Columns[1].HeaderCell.Value = "Name of Material";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UpdateInvoice prod = new UpdateInvoice();
            prod.StartPosition = FormStartPosition.Manual;
            prod.Location = new Point(this.Left, this.Top);
            prod.ShowDialog();
            loadData();
        }

        private void dgvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInvoices.CurrentCell.ColumnIndex.Equals(0))
            {

            }
            String limitInvoice = tbLimitInvoice.Text.ToString();
            String limitInvoiceDetails = tbLimitInvoiceDetails.Text.ToString();
            String searchString = tbSearch.Text.ToString();


            DateTime fromDateOr = dtPickerFrom.Value;
            DateTime toDateOr = dtPickerTo.Value;
            DateTime fromDate, toDate;

            //If the user makes it so that toDate = fromDate, make sure toDate starts at 12am
            if (fromDateOr == toDateOr)
            {
                fromDate = new DateTime(fromDateOr.Year, fromDateOr.Month, fromDateOr.Day, 00, 00, 00);
            }
            else
            {
                fromDate = new DateTime(fromDateOr.Year, fromDateOr.Month, fromDateOr.Day, 00, 00, 00);
            }

            toDate = new DateTime(toDateOr.Year, toDateOr.Month, toDateOr.Day, 23, 59, 0);

            if (toDate < fromDate)
            {
                MessageBox.Show("Please make sure the To Date is higher than the From Date");
                DateTime newFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01, 00, 00, 00);
                dtPickerFrom.Value = newFrom;
                dtPickerTo.Value = DateTime.Now;
                return;
            }


            if (dgvInvoices.CurrentCell.ColumnIndex.Equals(0))
            {
                String ID = dgvInvoices.CurrentCell.Value.ToString();
                StringBuilder queryBuilderTwo = new StringBuilder();
                queryBuilderTwo.Append("SELECT TOP ");
                queryBuilderTwo.Append(tbLimitInvoiceDetails.Text.ToString());
                queryBuilderTwo.Append(" NewInvoicesDetails.InvoiceID, Materials.Name, Quantity, Price ");
                queryBuilderTwo.Append(" FROM NewInvoicesDetails INNER JOIN Materials ON NewInvoicesDetails.MaterialID = Materials.ID ");
                queryBuilderTwo.Append(" INNER JOIN NewInvoices ON NewInvoicesDetails.InvoiceID = NewInvoices.ID ");
                queryBuilderTwo.Append(" WHERE NewInvoices.DateInv BETWEEN \'");
                queryBuilderTwo.Append(fromDate);
                queryBuilderTwo.Append("\' AND \'");
                queryBuilderTwo.Append(toDate);
                queryBuilderTwo.Append("\'");
                //If the user is searching something
                if (!String.IsNullOrEmpty(searchString))
                {
                    if (radioCompany.Checked)
                    {
                        queryBuilderTwo.Append(" AND CompanyName = \'");
                        queryBuilderTwo.Append(searchString);
                        queryBuilderTwo.Append("\' ");
                    }
                }
                //For the payment radio buttons, if any are chosen]
                else if (radioPaid.Checked)
                {
                    queryBuilderTwo.Append(" AND ToPay = 0 ");
                }
                else if (radioNotPaid.Checked)
                {
                    queryBuilderTwo.Append(" AND Paid != Total ");
                }
                queryBuilderTwo.Append(" AND NewInvoices.ID = \'");
                queryBuilderTwo.Append(dgvInvoices.CurrentCell.Value.ToString());
                queryBuilderTwo.Append("\' ORDER BY DateInv DESC");


                SqlDataAdapter adapter2 = new SqlDataAdapter(queryBuilderTwo.ToString(), con);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                dgvInvoicesDetails.DataSource = dt2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            loadData();
        }

        private void NewInvoices_Load(object sender, EventArgs e)
        {

        }
    }
}
