using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SQLite;
using System.Runtime.InteropServices;

namespace Construction
{
    public partial class Homepage : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public bool hasCreatedSettings = false; 
        //Connection String of the Application
        public SQLiteConnection con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;", true);

        public double SalesNumber = 0, Revenues = 0, Other = 0, Costs = 0;
        public double theoreticalSales = 0, theoreticalCosts = 0, theoreticalRevenues = 0;


        //create singleton
        private static Homepage _instance;
        public static Homepage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Homepage();
                return _instance;
            }
        }

        public int MakeLong(short lowPart, short highPart)
        {
            return (int)(((ushort)lowPart) | (uint)(highPart << 16));
        }

        public void ListViewItem_SetSpacing(ListView listview, short leftPadding, short topPadding)
        {
            const int LVM_FIRST = 0x1000;
            const int LVM_SETICONSPACING = LVM_FIRST + 53;
            SendMessage(listview.Handle, LVM_SETICONSPACING, IntPtr.Zero, (IntPtr)MakeLong(leftPadding, topPadding));
        }

       
        public Homepage()
        {
            InitializeComponent();
           
            DateTime y = dtPickerFrom.Value;
            dtPickerFrom.Value = new DateTime(y.Year, y.Month, 1, 00, 00, 00);

            y = dtPickerTo.Value;
            DateTime lastDayOfMonth = new DateTime(y.Year, y.Month, DateTime.DaysInMonth(y.Year, y.Month));
            dtPickerTo.Value = new DateTime(y.Year, y.Month, lastDayOfMonth.Day, 23, 59, 30);

            loadData();
        }

        public void loadData()

        {
            con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;");
            //check if connection is closed, if so open it
            con.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }


            try
            {
                
                string query = " SELECT IFNULL(SUM(Paid), 0) FROM SaleHistory WHERE PayDate BETWEEN @FromDate AND @ToDate";

                //create an object SqlCommand that will take the query and the connection string
                SQLiteCommand cmd = new SQLiteCommand(query, con);

                String dtFrom = new DateTime(dtPickerFrom.Value.Year, dtPickerFrom.Value.Month, dtPickerFrom.Value.Day, 0, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");
                String dtTo = new DateTime(dtPickerTo.Value.Year, dtPickerTo.Value.Month, dtPickerTo.Value.Day, 23, 59, 59).ToString("yyyy-MM-dd HH:mm:ss");
                //explain what the parameters with @ in the conenction string mean
                cmd.Parameters.AddWithValue("@FromDate", dtFrom);
                cmd.Parameters.AddWithValue("@ToDate", dtTo);

                //create a data reader that will execute the query
                SQLiteDataReader dr = cmd.ExecuteReader();

                //if the data reader finds the row, do this
                if (dr.Read())
                {
                    SalesNumber = dr.GetDouble(0);
                }
                dr.Close();
                dr.Dispose();


                string query2 = "SELECT IFNULL(SUM(Paid), 0) FROM PaymentHistory WHERE PayDate BETWEEN @FromDate AND @ToDate";

                //create an object SqlCommand that will take the query and the connection string
                SQLiteCommand cmd2 = new SQLiteCommand(query2, con);

                //explain what the parameters with @ in the conenction string mean
                cmd2.Parameters.AddWithValue("@FromDate", dtFrom);
                cmd2.Parameters.AddWithValue("@ToDate", dtTo);

                //create a data reader that will execute the query
                SQLiteDataReader dr2 = cmd2.ExecuteReader();

                //if the data reader finds the row, do this
                if (dr2.Read())
                {
                    Costs = dr2.GetDouble(0);
                }
                double x = Costs;
                dr2.Close();
                dr2.Dispose();

                string query3 = "SELECT IFNULL(SUM(Paid),0) FROM MiscPayments WHERE DateTime BETWEEN @FromDate AND @ToDate";

                //create an object SqlCommand that will take the query and the connection string
                SQLiteCommand cmd3 = new SQLiteCommand(query3, con);

                //explain what the parameters with @ in the conenction string mean
                cmd3.Parameters.AddWithValue("@FromDate", dtFrom);
                cmd3.Parameters.AddWithValue("@ToDate", dtTo);

                //create a data reader that will execute the query
                SQLiteDataReader dr3 = cmd3.ExecuteReader();

                //if the data reader finds the row, do this
                if (dr3.Read())
                {
                    Other = dr3.GetDouble(0);
                }
                dr3.Close();
                dr3.Dispose();

                string query4 = "SELECT IFNULL(SUM(Total),0) FROM NewInvoices WHERE DateInv BETWEEN @FromDate AND @ToDate";
                //create an object SqlCommand that will take the query and the connection string
                SQLiteCommand cmd4 = new SQLiteCommand(query4, con);

                //explain what the parameters with @ in the conenction string mean
                cmd4.Parameters.AddWithValue("@FromDate", dtFrom);
                cmd4.Parameters.AddWithValue("@ToDate", dtTo);

                //create a data reader that will execute the query
                SQLiteDataReader dr4 = cmd4.ExecuteReader();

                //if the data reader finds the row, do this
                if (dr4.Read())
                {
                    theoreticalCosts = dr4.GetDouble(0);
                }
                dr4.Close();
                dr4.Dispose();

                string query5 = "SELECT IFNULL(SUM(Total),0) FROM Sales WHERE DateSale BETWEEN @FromDate AND @ToDate";
                //create an object SqlCommand that will take the query and the connection string
                SQLiteCommand cmd5 = new SQLiteCommand(query5, con);

                //explain what the parameters with @ in the conenction string mean
                cmd5.Parameters.AddWithValue("@FromDate", dtFrom);
                cmd5.Parameters.AddWithValue("@ToDate", dtTo);

                //create a data reader that will execute the query
                SQLiteDataReader dr5 = cmd5.ExecuteReader();

                //if the data reader finds the row, do this
                if (dr5.Read())
                {
                    theoreticalSales = dr5.GetDouble(0);
                }
                dr5.Close();
                dr5.Dispose();

                Revenues = SalesNumber - Costs - Other;
                theoreticalRevenues = theoreticalSales - theoreticalCosts - Other;

                labelSales.Text = "F.CFA " + SalesNumber.ToString("#,##0.00");
                labelInvoice.Text = "F.CFA " + Costs.ToString("#,##0.00");
                labelOther.Text = "F.CFA " + Other.ToString("#,##0.00");
                Revenue.Text = "F.CFA " + Revenues.ToString("#,##0.00");

                labelTSales.Text = "F.CFA " + theoreticalSales.ToString("#,##0.00");
                labelTCosts.Text = "F.CFA " + theoreticalCosts.ToString("#,##0.00");
                labelTPayments.Text = "F.CFA " + Other.ToString("#,##0.00");
                labelTRev.Text = "F.CFA " + theoreticalRevenues.ToString("#,##0.00");

                
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

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //create the login page
            Login toPage = new Login();
            //show the homepage
            toPage.Show();
            //hide the current page
            this.Hide();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            Stock.Instance.Show();
            Stock.Instance.loadData();
            //hide the current page
            this.Hide();

        }

        private void btnInvoicing_Click(object sender, EventArgs e)
        {
            //create the invoicing page
            Invoices.Instance.Show();
            Invoices.Instance.loadData();
            Invoices.Instance.loadAutoCompleteData();
            //hide the current page
            this.Hide();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            //create the payments page
            Payments toPage = new Payments();
            //show the payments page
            toPage.Show();
            //hide the current page
            this.Hide();
        }

        private void dtFrom_CloseUp(object sender, EventArgs e)
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

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            DateTime y = dtPickerTo.Value;
            dtPickerTo.Value = new DateTime(y.Year, y.Month, y.Day, 23, 59, 30);
            if (dtPickerTo.Value < dtPickerFrom.Value)
            {

                DateTime x = dtPickerFrom.Value;
                MessageBox.Show("Please note that Date To cannot take place before Date From", "Error!");
                DateTime lastDayOfMonth = new DateTime(x.Year, x.Month, DateTime.DaysInMonth(x.Year, x.Month));
                dtPickerTo.Value = new DateTime(dtPickerFrom.Value.Year, dtPickerFrom.Value.Month, lastDayOfMonth.Day, 23,59,59);
            }
            loadData();
        }

        private void btnPrices_Click(object sender, EventArgs e)
        {
            //create the stock page
            Stock toPage = new Stock();
            //show the stock page
            toPage.Show();
            //hide the current page
            this.Hide();
        }

        private void btnPrices_Click_1(object sender, EventArgs e)
        {
            //create the prices page
            Prices toPage = new Prices();
            //show the prices page
            toPage.Show();
            //hide the current page
            this.Hide();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            /*if (!ucSettings.Instance.hasBeenCreated)
            {*/
                panelTwo.Controls.Add(ucSettings.Instance);
                ucSettings.Instance.Dock = DockStyle.Fill;
                ucSettings.Instance.BringToFront();
                panelTwo.BringToFront();
                panelTwo.Visible = true;
                panelTwo.Focus();
                ucSettings.Instance.hasBeenCreated = true;
            /*}
            else
            {
                panelTwo.Visible = true;
                panelTwo.Show();
                panelTwo.BringToFront();
                ucSettings.Instance.Dock = DockStyle.Fill;
                ucSettings.Instance.Visible = true;
                ucSettings.Instance.BringToFront();
                panelTwo.Focus();
                
            }*/

        }

        private void panelTwo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucSettings.Instance.backupData();
            Application.Exit();
        }

        private void listViewHomepage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            //create the invoicing page
            Sales.Instance.Show();
            Sales.Instance.loadData();
            Sales.Instance.loadAutoCompleteData();
            //hide the current page
            this.Hide();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += .5;
        }
    }
}
