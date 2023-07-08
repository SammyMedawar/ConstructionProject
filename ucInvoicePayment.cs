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
    public partial class ucInvoicePayment : UserControl
    {
        //Connection String of the Application
        SQLiteConnection con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;", true);
        private bool isLoading = true;
        public ucInvoicePayment()
        {
            isLoading = true;
            InitializeComponent();
            DateTime newFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01, 00, 00, 00);
            dtPickerFrom.Value = newFrom;
            dtPickerTo.Value = DateTime.Now;
            loadDataOntoCombo();
            isLoading = false;
            loadData();
        }
        //create singleton
        private static ucInvoicePayment _instance;
        public static ucInvoicePayment Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucInvoicePayment();
                return _instance;
            }
        }


        public void loadDataOntoCombo()
        {
            con.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                string query = "SELECT DISTINCT CompanyName FROM PaymentHistory;";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader dr = cmd.ExecuteReader();
                comboCompany.Items.Clear();

                //if the data reader finds the row, do this
                while (dr.Read())
                {
                    comboCompany.Items.Add(dr.GetString(0));
                }
                dr.Close();
                dr.Dispose();

                if(comboCompany.Text.ToString().Length == 0)
                {
                    if(comboCompany.Items.Count != 0)
                        comboCompany.SelectedIndex = 0;
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


        public void loadData()
        {
            if (isLoading)
                return;
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
                    MessageBox.Show("Please make sure the limit box has numbers in it");
                    tbPaymentLimit.Text = "25";
                    return;
                }

                if (!Int32.TryParse(tbPaymentLimit.Text, out int j))
                {
                    MessageBox.Show("Please make sure the limit box has numbers in it");
                    tbPaymentLimit.Text = "25";
                    return;

                }

                double total = 0;
                int limit = Int32.Parse(tbPaymentLimit.Text.ToString());
                DateTime oldTo = dtPickerTo.Value;
                DateTime newTo = new DateTime(oldTo.Year, oldTo.Month, oldTo.Day, 23, 59, 59);
                string query = "SELECT ID, CompanyName, PayDate, ToPay, Paid, CumulativeTotal FROM PaymentHistory WHERE CompanyName like '"+comboCompany.Text+"' AND PayDate BETWEEN '" + dtPickerFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + newTo.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY PayDate ASC, ToPay DESC, CumulativeTotal DESC  LIMIT " + limit + ";";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvPayments.DataSource = dt;
                loadLabelData();
            }
            catch (Exception msg)
            {
                MessageBox.Show("Oops! An error has occured. Please restart the application");
                con.Close();
                return;
            }


            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void loadLabelData()
        {
            foreach(Label c in this.Controls.OfType<Label>())
            {
                if (c.Text.ToString().Contains("F.CFA"))
                    this.Controls.Remove(c);
            }

            Label mylabel = new Label();
            int lastRowIndex = dgvPayments.Rows.Count - 1;
            Rectangle lastRowRectangle = dgvPayments.GetCellDisplayRectangle(0, lastRowIndex, true);
            Point lastRowLocation = new Point(lastRowRectangle.X, lastRowRectangle.Y + lastRowRectangle.Height);
            Point locationRelativeToForm = dgvPayments.PointToScreen(lastRowLocation);
            double x = 0;
            try { double.TryParse(dgvPayments.Rows[lastRowIndex].Cells[5].Value.ToString(), out x); }
            catch (Exception msg)
            { //do nothing
            }
            mylabel.Text = "Cumulative Total: F.CFA " + x.ToString("#,##0.00"); ;
            //mylabel.Location = new Point(953, locationRelativeToForm.Y);
            mylabel.Location = new Point(75, 411);
            mylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mylabel.BackColor = Color.AliceBlue;
            mylabel.Padding = new Padding(10);
            mylabel.AutoSize = true; // Enable AutoSize property
            this.Controls.Add(mylabel);
            mylabel.BringToFront();

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

        private void tbLimitInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbLimitInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            loadData();
        }

        private void tbLimitInvoice_Leave(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Parent.Parent.Controls.Remove(this.Parent);
            this.Parent.SendToBack();
            Invoices.Instance.PanelOne.BringToFront();

        }

        private void btnHomepage_Click(object sender, EventArgs e)
        {
            this.Parent.SendToBack();
            Invoices.Instance.PanelOne.BringToFront();
            Homepage.Instance.loadData();
            //show the homepage
            Homepage.Instance.Show();
            //hide the current page
            this.Parent.Hide();
            Invoices.Instance.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Parent.SendToBack();
            Invoices.Instance.PanelOne.BringToFront();
            //create the login page
            Login toPage = new Login();
            //show the login page
            toPage.Show();
            //hide the current page
            this.Parent.Hide();
        }

        private void ucInvoicePayment_Load(object sender, EventArgs e)
        {

        }

        private void comboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private String generateID()
        {

            if (con.State == ConnectionState.Closed)
                con.Open();

            //Get latest number and year from records
            String lastID = "";
            String query = "SELECT ID FROM SinglePaymentInvoices ORDER BY DateNow DESC Limit 1";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lastID = dr.GetString(0);
            }
            dr.Close();
            dr.Dispose();
            String lastIDNumber = lastID.Substring(6);
            int currentYearInt = DateTime.Now.Year;
            String currentYear = currentYearInt.ToString();
            currentYear = currentYear.Substring(2);
            int newestIDNumberInt = Int32.Parse(lastIDNumber) + 1;
            String newestIDNumber = newestIDNumberInt.ToString("D3");
            String newestID;
            newestID = "DIP" + currentYear + "-" + newestIDNumber;

            if (con.State == ConnectionState.Open)
                con.Close();

            return newestID;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //check if any textboxes are null
            if (comboCompany.Text.Length == 0 ||  tbPaid.Text.Length == 0)
            {
                MessageBox.Show("Please make sure all inputs are filled!");
                return;
            }

            //just in case, make sure company exists
            if (!comboCompany.Items.Contains(comboCompany.Text))
            {
                MessageBox.Show(comboCompany.Text + " does not exist!");
                return;
            }

            //check if a negative number has been entered to paid
            if(Double.Parse(tbPaid.Text) <= 0)
            {
                MessageBox.Show("Please enter a valid Paid value!");
                return;
            }

            //check if paid can be converted to double
            double paid = 0;
            try
            {
                paid = double.Parse(tbPaid.Text);
            }catch(Exception MSG)
            {
                MessageBox.Show("Please make sure Paid only has numbers in it!");
                return;
            }
            if (con.State == ConnectionState.Open)
                con.Close();

            String newID = generateID();

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            Double cum = 0;

            try
            {

                
                //check if paid is larger than cumulative total
                string query = "SELECT CumulativeTotal FROM PaymentHistory WHERE CompanyName LIKE '" + comboCompany.Text + "' ORDER BY PayDate DESC LIMIT 1";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetFloat(0) < paid)
                    {
                        MessageBox.Show("Please note that Paid cannot be larger than the Cumulative Total!");
                        dr.Close();
                        dr.Dispose();
                        con.Close();
                        return;
                    }
                    cum = dr.GetFloat(0);
                }
                dr.Close();
                dr.Dispose();

            }
            catch(Exception MSG)
            {
                MessageBox.Show("An error has occured! Please restart the application", "Error!");
                con.Close();
                return;
            }

            if (con.State == ConnectionState.Open)
                con.Close();


            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            using (var trans = con.BeginTransaction())
            {

                try
                {


                    


                    //Insert into payment history
                    string query2 = "INSERT INTO PaymentHistory VALUES (@ID, @PayDate, 0, @Paid, @cum - @Paid, @CompanyName )";
                    SQLiteCommand cmd2 = new SQLiteCommand(query2, con);
                    cmd2.Parameters.AddWithValue("@ID", newID);
                    DateTime newPayDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute + 1, DateTime.Now.Second);
                    cmd2.Parameters.AddWithValue("@Paydate", newPayDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd2.Parameters.AddWithValue("@cum", cum);
                    cmd2.Parameters.AddWithValue("@Paid", paid);
                    cmd2.Parameters.AddWithValue("@CompanyName", comboCompany.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("A payment of ID " + newID + " to " + comboCompany.Text + " was made with the following details: "
                        + "\nAmount Paid: " + paid.ToString("#,##0.00") + "\nAmount Left to Pay: " + (cum - paid).ToString("#,##0.00"));

                    //Update company info
                    string query3 = "UPDATE Company SET CumulativeOwed = @cum WHERE CompanyName LIKE @CompanyName";
                    SQLiteCommand cmd3 = new SQLiteCommand(query3, con);
                    cmd3.Parameters.AddWithValue("@cum", cum - paid);
                    cmd3.Parameters.AddWithValue("@CompanyName", comboCompany.Text);
                    cmd3.ExecuteNonQuery();

                    string query4 = "INSERT INTO SinglePaymentInvoices VALUES (@ID, @Now, @CompanyName)";
                    SQLiteCommand cmd4 = new SQLiteCommand(query4, con);
                    cmd4.Parameters.AddWithValue("@ID", newID);
                    cmd4.Parameters.AddWithValue("@Now", DateTime.Now);
                    cmd4.Parameters.AddWithValue("@CompanyName", CompanyName);

                    cmd4.ExecuteNonQuery();

                    trans.Commit();
                    loadData();
                    tbPaid.Text = "";
                }
                catch(Exception MSG)
                {
                    trans.Rollback();
                    MessageBox.Show("An Error has occured! Please restart the application!");
                }
                finally
                {
                    //close the connection if it is still open
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }

            con.Close();

        }

        private void tbPaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.Handled = true;
            }
        }

        private void tbPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '%'))
            {
                e.Handled = true;
            }

            //only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgvPayments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPayments.Columns[1].HeaderCell.Value = "Company Name";
            dgvPayments.Columns[2].HeaderCell.Value = "Date of Payment";
            dgvPayments.Columns[3].HeaderCell.Value = "Fracture";
            dgvPayments.Columns[5].HeaderCell.Value = "Cumulative Total";
            dgvPayments.Columns[3].DefaultCellStyle.Format = "N2";
            dgvPayments.Columns[4].DefaultCellStyle.Format = "N2";
            dgvPayments.Columns[5].DefaultCellStyle.Format = "N2";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPayments.CurrentCell.ColumnIndex.Equals(0) &&
                    dgvPayments.Rows[dgvPayments.CurrentCell.RowIndex].Cells[3].Value.ToString() == "0")
                {
                    try
                    {
                        String ID = dgvPayments.CurrentCell.Value.ToString();
                        int rowIndex = dgvPayments.CurrentCell.RowIndex;
                        String companyName = dgvPayments.Rows[rowIndex].Cells[1].Value.ToString();
                        DateTime date = DateTime.Parse(dgvPayments.Rows[rowIndex].Cells[2].Value.ToString());

                        double paid = Double.Parse(dgvPayments.Rows[rowIndex].Cells[4].Value.ToString());
                        double balance = Double.Parse(dgvPayments.Rows[rowIndex].Cells[5].Value.ToString());
                        double due = paid + balance;

                        frmPrntRow prod = new frmPrntRow(ID);
                        prod.isSale = false;
                        prod.setID(ID);
                        prod.SetCompanyName(companyName);
                        prod.SetDate(date);
                        prod.setDue(due);
                        prod.setBalance(balance);
                        prod.SetPaid(paid);
                        DialogResult dr = prod.ShowDialog(this);
                    }
                    catch (NullReferenceException msg)
                    {
                        MessageBox.Show("There are no payments to print!");
                    }
                }
                else
                {
                    String companyName = dgvPayments.Rows[0].Cells[1].Value.ToString();
                    DateTime dtTo = dtPickerTo.Value;
                    DateTime dtToNew = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);
                    DateTime dtFrom = dtPickerFrom.Value;
                    DateTime dtFromNew = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, 0, 1, 0);
                    int limit = Int32.Parse(tbPaymentLimit.Text);


                    frmPrintRecordPayments prod = new frmPrintRecordPayments();
                    prod.setSale(false);
                    prod.setCompany(companyName);
                    prod.setdtFrom(dtFromNew);
                    prod.setdtTo(dtToNew);
                    prod.setLimit(limit);
                    prod.loadData();
                    DialogResult dr = prod.ShowDialog(this);
                }
            }
            catch(Exception msg)
            {
                MessageBox.Show("Please make sure you have at least one payment to print!");
            }
        }

        private void tbPaymentLimit_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
