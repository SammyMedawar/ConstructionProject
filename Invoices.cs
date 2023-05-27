using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Construction
{
    public partial class Invoices : Form
    {
        //Connection String of the Application
        SQLiteConnection con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;", true);
        public bool hasCreatedAddUC = false, hasCreatedPaymentUC = false;
        public Panel panelTwo;
        private static Invoices _instance;
        public static Invoices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Invoices();
                return _instance;
            }
        }

        public Invoices()
        {
            InitializeComponent();
            DateTime newFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01, 00, 00, 00);
            dtPickerFrom.Value = newFrom;
            dtPickerTo.Value = DateTime.Now;
            loadData();
            loadAutoCompleteData();
        }

        public void loadAutoCompleteData()
        {
            con.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                string query = "";
                if (radioCompany.Checked)
                    query = "SELECT DISTINCT CompanyName FROM PaymentHistory;";
                else
                    query = "SELECT ID FROM NewInvoices";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader dr = cmd.ExecuteReader();
                tbSearch.Items.Clear();

                //if the data reader finds the row, do this
                while (dr.Read())
                {
                    tbSearch.Items.Add(dr.GetString(0));
                }
                dr.Close();
                dr.Dispose();
            }
            catch (Exception msg)
            {
                MessageBox.Show("Oops! An error has occured. Please restart the application", "Error!");
            }

            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void Invoices_Load(object sender, EventArgs e)
        {
            tbSearch.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += 0.2;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!hasCreatedAddUC)
            {
                PanelOne.SendToBack();
                panelTwo = new Panel();
                panelTwo.Size = new Size(473, 667);
                panelTwo.Location = new Point(2, 1);
                panelTwo.Controls.Add(ucInvoiceAdd.Instance);
                this.Controls.Add(panelTwo);
                ucInvoiceAdd.Instance.Dock = DockStyle.Fill;
                ucInvoiceAdd.Instance.BringToFront();
                panelTwo.BringToFront();
                panelTwo.Focus();
                panelTwo.ControlRemoved += new ControlEventHandler(removePanel2);
                hasCreatedAddUC = true;
            }
            else
            {
                panelTwo.Show();
                panelTwo.BringToFront();
                ucInvoiceAdd.Instance.Dock = DockStyle.Fill;
                ucInvoiceAdd.Instance.BringToFront();
                panelTwo.Focus();
                PanelOne.SendToBack();
            }

        }
        private void removePanel2(object sender, ControlEventArgs e)
        {
            PanelOne.BringToFront();
            loadData();
            loadAutoCompleteData();
        }
        private void btnHomepage_Click(object sender, EventArgs e)
        {
            Homepage.Instance.Show();
            Homepage.Instance.loadData();
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

        public void loadData()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Close();

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
                    fromDate = new DateTime(fromDateOr.Year, fromDateOr.Month, fromDateOr.Day, 00, 00, 00);
                }

                toDate = new DateTime(toDateOr.Year, toDateOr.Month, toDateOr.Day, 23, 59, 0);

                if (toDate < fromDate)
                {
                    MessageBox.Show("Please make sure the To Date is higher than the From Date", "Error!");
                    DateTime newFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01, 00, 00, 00);
                    dtPickerFrom.Value = newFrom;
                    dtPickerTo.Value = DateTime.Now;
                    con.Close();
                    return;
                }
                int limitInvoiceInt, limitInvoiceDetailsInt;

                //End of Initialization of variables


                //Check if limit boxes are filled, if not return
                if (String.IsNullOrEmpty(limitInvoice) || String.IsNullOrEmpty(limitInvoiceDetails))
                {
                    MessageBox.Show("Please make sure the limit boxes have numbers in them", "Error!");
                    tbLimitInvoice.Text = "25";
                    tbLimitInvoiceDetails.Text = "50";
                    con.Close();
                    return;
                }

                //if the limit boxes have words in them and not letters, give an error
                if (Int32.TryParse(limitInvoice, out limitInvoiceInt) && Int32.TryParse(limitInvoiceDetails, out limitInvoiceDetailsInt))
                {
                    //begin of load data for invoices table
                    StringBuilder queryBuilderOne = new StringBuilder();
                    queryBuilderOne.Append("SELECT ");
                    queryBuilderOne.Append(" ID, CompanyName, DateInv, Total FROM NewInvoices WHERE DateInv BETWEEN \'");
                    queryBuilderOne.Append(fromDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    queryBuilderOne.Append("\' AND \'");
                    queryBuilderOne.Append(toDate.ToString("yyyy-MM-dd HH:mm:ss"));
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
                    queryBuilderOne.Append(" ORDER BY DateInv DESC LIMIT ");
                    queryBuilderOne.Append(limitInvoiceInt);

                    //begin of load data for invoices details table
                    StringBuilder queryBuilderTwo = new StringBuilder();
                    queryBuilderTwo.Append("SELECT ");
                    queryBuilderTwo.Append(" NewInvoicesDetails.InvoiceID, Materials.Name, Quantity, Price ");
                    queryBuilderTwo.Append(" FROM NewInvoicesDetails INNER JOIN Materials ON NewInvoicesDetails.MaterialID = Materials.ID ");
                    queryBuilderTwo.Append(" INNER JOIN NewInvoices ON NewInvoicesDetails.InvoiceID = NewInvoices.ID ");
                    queryBuilderTwo.Append(" WHERE NewInvoices.DateInv BETWEEN \'");
                    queryBuilderTwo.Append(fromDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    queryBuilderTwo.Append("\' AND \'");
                    queryBuilderTwo.Append(toDate.ToString("yyyy-MM-dd HH:mm:ss"));
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
                    queryBuilderTwo.Append(" ORDER BY DateInv DESC LIMIT ");
                    queryBuilderTwo.Append(limitInvoiceDetailsInt);


                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(queryBuilderOne.ToString(), con);
                    SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(queryBuilderTwo.ToString(), con);
                    DataTable dt = new DataTable();
                    DataTable dt2 = new DataTable();
                    adapter.Fill(dt);
                    adapter2.Fill(dt2);
                    dgvInvoices.DataSource = dt;
                    dgvInvoicesDetails.DataSource = dt2;

                }
                else
                {
                    MessageBox.Show("Please make sure the limit boxes have numbers in them", "Error!");
                    tbLimitInvoice.Text = "25";
                    tbLimitInvoiceDetails.Text = "50";
                    con.Close();
                    return;
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show("Oops! An error has occured. Please restart the application", "Error!");
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
            con.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                String query = "";
                SQLiteCommand cmd3 = null;
                //check if that searched item exists
                //create search query string
                if (radioCompany.Checked)
                {
                    query = "SELECT CompanyName FROM NewInvoices WHERE CompanyName = @CompanyName";
                    //create an object SqlCommand that will take the query and the connection string
                    cmd3 = new SQLiteCommand(query, con);
                    //explain what the parameters with @ in the conenction string mean
                    cmd3.Parameters.AddWithValue("@CompanyName", tbSearch.Text.ToString());
                }
                else if (radioID.Checked)
                {
                    query = "SELECT ID FROM NewInvoices WHERE ID = @ID";
                    cmd3 = new SQLiteCommand(query, con);
                    //explain what the parameters with @ in the conenction string mean
                    cmd3.Parameters.AddWithValue("@ID", tbSearch.Text.ToString());
                }


                //create a data reader that will execute the query
                SQLiteDataReader dr2 = cmd3.ExecuteReader();

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
                        MessageBox.Show("An Invoice with the ID " + tbSearch.Text + " doesn't exist so far!", "Search Not Found");
                    }
                    else if (radioCompany.Checked)
                    {
                        MessageBox.Show("A Company with the name " + tbSearch.Text + " doesn't exist so far!", "Search Not Found");
                    }
                    dr2.Dispose();
                    con.Close();
                    return;
                }

            }
            catch (Exception msg)
            {
                MessageBox.Show("Please make sure the search bar is filled in correctly!", "Error!");
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
            DateTime y = dtPickerFrom.Value;
            dtPickerFrom.Value = new DateTime(y.Year, y.Month, y.Day, 00, 00, 00);
            if (dtPickerTo.Value < dtPickerFrom.Value)
            {
                DateTime x = dtPickerTo.Value;
                MessageBox.Show("Please note that Date To cannot take place before Date From", "Error!");
                DateTime lastDayOfMonth = new DateTime(x.Year, x.Month, DateTime.DaysInMonth(x.Year, x.Month));
                dtPickerFrom.Value = new DateTime(dtPickerTo.Value.Year, dtPickerTo.Value.Month, 1, 0, 0, 0);
            }
            loadData();
        }

        private void dtPickerTo_CloseUp(object sender, EventArgs e)
        {
            DateTime y = dtPickerTo.Value;
            dtPickerTo.Value = new DateTime(y.Year, y.Month, y.Day, 23, 59, 30);
            if (dtPickerTo.Value < dtPickerFrom.Value)
            {
                DateTime x = dtPickerFrom.Value;
                MessageBox.Show("Please note that Date To cannot take place before Date From", "Error!");
                DateTime lastDayOfMonth = new DateTime(x.Year, x.Month, DateTime.DaysInMonth(x.Year, x.Month));
                dtPickerTo.Value = new DateTime(dtPickerFrom.Value.Year, dtPickerFrom.Value.Month, lastDayOfMonth.Day, 23, 59, 59);
            }
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

            tbSearch.Text = "";
            tbLimitInvoice.Text = "25";
            tbLimitInvoiceDetails.Text = "50";
            //tbSearch.setPlaceholder();
            //tbSearch.isPlaceHolder = true;
            //tbSearch.Text = "Search...";

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
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            tbSearch.Text = "";
            reload();
        }

        private void dgvInvoices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvInvoices.ClearSelection();
            //Make columns of datagridview unsortable
            /*foreach (DataGridViewColumn column in dgvInvoices.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }*/

            dgvInvoices.Columns[1].HeaderCell.Value = "Company Name";
            dgvInvoices.Columns[2].HeaderCell.Value = "Date of Invoice";
            dgvInvoices.Columns[3].HeaderCell.Value = "Price";
            dgvInvoices.Columns[3].DefaultCellStyle.Format = "N2";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
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
                fromDate = new DateTime(fromDateOr.Year, fromDateOr.Month, fromDateOr.Day, 23, 59, 0);
            }

            toDate = new DateTime(toDateOr.Year, toDateOr.Month, toDateOr.Day, 23, 59, 59);

            if (toDate < fromDate)
            {
                MessageBox.Show("Please make sure the To Date is higher than the From Date", "Error!");
                DateTime newFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01, 00, 00, 00);
                dtPickerFrom.Value = newFrom;
                dtPickerTo.Value = DateTime.Now;
                return;
            }


            if (dgvInvoices.CurrentCell.ColumnIndex.Equals(0))
            {
                String ID = dgvInvoices.CurrentCell.Value.ToString();
                StringBuilder queryBuilderTwo = new StringBuilder();
                queryBuilderTwo.Append("SELECT ");
                queryBuilderTwo.Append(" NewInvoicesDetails.InvoiceID, Materials.Name, Quantity, Price ");
                queryBuilderTwo.Append(" FROM NewInvoicesDetails INNER JOIN Materials ON NewInvoicesDetails.MaterialID = Materials.ID ");
                queryBuilderTwo.Append(" INNER JOIN NewInvoices ON NewInvoicesDetails.InvoiceID = NewInvoices.ID ");
                queryBuilderTwo.Append(" WHERE NewInvoices.DateInv BETWEEN \'");
                queryBuilderTwo.Append(fromDate.ToString("yyyy-MM-dd HH:mm:ss"));
                queryBuilderTwo.Append("\' AND \'");
                queryBuilderTwo.Append(toDate.ToString("yyyy-MM-dd HH:mm:ss"));
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
                queryBuilderTwo.Append("\' ORDER BY DateInv DESC LIMIT ");
                queryBuilderTwo.Append(tbLimitInvoiceDetails.Text.ToString());


                SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(queryBuilderTwo.ToString(), con);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                dgvInvoicesDetails.DataSource = dt2;
            }
        }

        private void tbLimitInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            if (!hasCreatedPaymentUC)
            {
                PanelOne.SendToBack();
                Panel panelThree = new Panel();
                panelThree.Size = new Size(1500, 667);
                panelThree.BackColor = Color.FromArgb(240, 240, 240);
                panelThree.Location = new Point(2, 1);
                panelThree.Controls.Add(ucInvoicePayment.Instance);
                this.Controls.Add(panelThree);
                ucInvoicePayment.Instance.Dock = DockStyle.Fill;
                ucInvoicePayment.Instance.BringToFront();
                ucInvoicePayment.Instance.loadDataOntoCombo();
                panelThree.BringToFront();
                panelThree.Focus();
                panelThree.ControlRemoved += new ControlEventHandler(removePanel3);
            }
            else {
                panelTwo.Show();
                panelTwo.BringToFront();
                ucInvoicePayment.Instance.Dock = DockStyle.Fill;
                ucInvoicePayment.Instance.BringToFront();
                panelTwo.Focus();
                PanelOne.SendToBack();
            }
        }
        private void removePanel3(object sender, ControlEventArgs e)
        {
            PanelOne.BringToFront();
            loadData();
            loadAutoCompleteData();
        }

        private void radioCompany_CheckedChanged(object sender, EventArgs e)
        {
            if(radioCompany.Checked)
                loadAutoCompleteData();
        }

        private void btnReload_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void Invoices_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucSettings.Instance.backupData();
            Application.Exit();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tbLimitInvoice_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void tbLimitInvoiceDetails_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void radioCompany2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioID.Checked)
                loadAutoCompleteData();
        }
    }
}
