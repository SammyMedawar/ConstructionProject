using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Construction
{
    public partial class frmPrintRecordPayments : Form
    {
        //Connection String of the Application
        SQLiteConnection con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;", true);

        public String CompanyName;
        public DateTime dtFrom, dtTo;
        public int limit;
        public bool isSale;

        public void setSale(bool _isSale)
        {
            isSale = _isSale;
        }

        public frmPrintRecordPayments()
        {
            InitializeComponent();
            btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }

        private String generateID()
        {

            if (con.State == ConnectionState.Closed)
                con.Open();

            //Get latest number and year from records
            String lastID = "";
            String query = "";
            if (!isSale)
                query = "SELECT ID FROM HistoryPaymentInvoices ORDER BY DatePrint DESC Limit 1";
            else
                query = "SELECT ID FROM HistoryPaymentSales ORDER BY DatePrint DESC Limit 1";
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
            if (!isSale)
                newestID = "RFA" + currentYear + "-" + newestIDNumber;
            else
                newestID = "RFD" + currentYear + "-" + newestIDNumber;

            if (con.State == ConnectionState.Open)
                con.Close();

            return newestID;
        }

        public void loadData()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            //check if connection is closed, if so open i
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            //String query = "select * from SalesDetails where SaleID = '"+labelRef.Text.ToString()+"';";
            String query = "";
            if (isSale == true)
            {
                query = "SELECT ID, PayDate, ToPay, Paid, CumulativeTotal FROM SaleHistory WHERE CompanyName like '" + CompanyName + "' AND PayDate BETWEEN '" + dtFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtTo.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY PayDate ASC, ToPay DESC, CumulativeTotal DESC LIMIT " + limit + ";";
            }
            else
            {
                query = "SELECT ID, PayDate, ToPay, Paid, CumulativeTotal FROM PaymentHistory WHERE CompanyName like '" + CompanyName + "' AND PayDate BETWEEN '" + dtFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dtTo.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY PayDate ASC, ToPay DESC, CumulativeTotal DESC LIMIT " + limit + ";";
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgv.DataSource = dt;
            //labelCompany.Text = "Financial Record for " + CompanyName + " Between " + dtFrom.ToString("yyyy-MM-dd") + " and " + dtTo.ToString("yyyy-MM-dd");
            labelReceipt.Text = "placeholder";
            labelCompany.Text = CompanyName;
            labelPrint.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            labelAU.Text = dtFrom.ToString("dd-MM-yyyy");
            labelPeriode.Text = dtTo.ToString("dd-MM-yyyy");

            double debit = 0, credit = 0, sold = 0;
            dgv.Columns[1].DefaultCellStyle.Format = "d";

            foreach (DataGridViewRow row in dgv.Rows)
            {
                debit = debit + Double.Parse(row.Cells[2].Value.ToString());
                credit = credit + Double.Parse(row.Cells[3].Value.ToString());
            }

            sold = debit - credit;

            labelDebit.Text = "F.CFA " + debit.ToString("#,##0.00");
            labelCredit.Text = "F.CFA " + credit.ToString("#,##0.00");
            labelSold.Text = "F.CFA " + sold.ToString("#,##0.00");
            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            labelReceipt.Text = generateID();


        }

        public void setLimit(int _limit)
        {
            limit = _limit;
        }

        public void setCompany(String _companyName)
        {
            CompanyName = _companyName;
        }
        public String getCompanyName() { return CompanyName; }

        public void setdtFrom(DateTime _dtFrom)
        {
            dtFrom = _dtFrom;
        }

        public DateTime getdtFrom() { return dtFrom; }
        public void setdtTo(DateTime _dtTo)
        {
            dtTo = _dtTo;
        }
        public DateTime getdtTo() { return dtTo; }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Get the printable area of the page
            Rectangle pagearea = e.PageBounds;

            // Calculate the scale factor needed to fit the entire panel onto the page
            float scaleWidth = (float)e.PageBounds.Width / panelPrint.Width;
            float scaleHeight = (float)e.PageBounds.Height / panelPrint.Height;
            float scale = Math.Min(scaleWidth, scaleHeight);

            // If the panel is taller than the page, scale it to fit the height of the page and leave some white space at the top and bottom
            if (scaleHeight < scaleWidth)
            {
                scale = scaleHeight;
            }

            // Create a bitmap with dimensions equal to the scaled panel size
            Bitmap memoryimg = new Bitmap((int)(panelPrint.Width * scale), (int)(panelPrint.Height * scale));

            // Create a new graphics object associated with the bitmap
            using (Graphics memoryGraphics = Graphics.FromImage(memoryimg))
            {
                // Clear the bitmap with a white background
                memoryGraphics.Clear(Color.White);

                // Apply the scale factor to the graphics object
                memoryGraphics.ScaleTransform(scale, scale);

                // Draw the panel onto the bitmap
                panelPrint.DrawToBitmap(memoryimg, new Rectangle(0, 0, panelPrint.Width, panelPrint.Height));
            }

            // Calculate the position to draw the bitmap on the page
            int x = (int)((e.PageBounds.Width - memoryimg.Width - 10) / 2f);
            int y = (int)((e.PageBounds.Height - memoryimg.Height) / 2f);

            // Draw the bitmap on the page
            e.Graphics.DrawImage(memoryimg, x, y);
        }

        private Bitmap memoryimg;

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv.Columns[1].HeaderCell.Value = "Date of Payment";
            dgv.Columns[2].HeaderCell.Value = "Fracture (F.CFA)";
            dgv.Columns[3].HeaderCell.Value = "Paid (F.CFA)";
            dgv.Columns[4].HeaderCell.Value = "Balance (F.CFA)";
            dgv.Columns[2].DefaultCellStyle.Format = "N2";
            dgv.Columns[3].DefaultCellStyle.Format = "N2";
            dgv.Columns[4].DefaultCellStyle.Format = "N2";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //Print(this.panelPrint);
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintController = new StandardPrintController(); // Suppress the print dialog
            getPrintArea(panelPrint);
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            try
            {
                printDocument.Print();
            }
            catch (Exception msg)
            {
                //dont do anything
            }
            this.Close();

            //Insert into history
            //check if connection is closed, if so open i
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            String query2;
            if (isSale)
                query2 = "INSERT INTO HistoryPaymentSales VALUES (@ID, @Now, @From, @To, @CompanyName)";
            else
                query2 = "INSERT INTO HistoryPaymentInvoices VALUES (@ID, @Now, @From, @To, @CompanyName)";

            SQLiteCommand cmd2 = new SQLiteCommand(query2, con);
            cmd2.Parameters.AddWithValue("@ID", labelReceipt.Text.Trim());
            cmd2.Parameters.AddWithValue("@Now", DateTime.Now);
            cmd2.Parameters.AddWithValue("@From", dtFrom);
            cmd2.Parameters.AddWithValue("@To", dtTo);
            cmd2.Parameters.AddWithValue("@CompanyName", CompanyName);

            cmd2.ExecuteNonQuery();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += 0.2;
        }

        private void panelPrint_Paint(object sender, PaintEventArgs e)
        {

        }

        private void getPrintArea(Panel pn1)
        {
            memoryimg = new Bitmap(pn1.Width, pn1.Height);
            pn1.DrawToBitmap(memoryimg, new Rectangle(0, 0, pn1.Width, pn1.Height));
        }


    }
}
