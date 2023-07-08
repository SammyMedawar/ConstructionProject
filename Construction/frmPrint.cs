using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Construction
{
    public partial class frmPrint : Form
    {
        //Connection String of the Application
        SQLiteConnection con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;", true);

        public String ID, newID, companyName;
        public DateTime date;
        public double total, toPay, paid;

        private void Print(Panel panelOne)
        {
            PrinterSettings ps = new PrinterSettings();
            panelPrint = panelOne;
            getPrintArea(panelOne);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            float scale = Math.Min((float)e.PageBounds.Width / panelPrint.Width, (float)e.PageBounds.Height / panelPrint.Height);

            Bitmap memoryimg = new Bitmap((int)(panelPrint.Width * scale), (int)(panelPrint.Height * scale));
            using (Graphics memoryGraphics = Graphics.FromImage(memoryimg))
            {
                memoryGraphics.Clear(Color.White);
                memoryGraphics.ScaleTransform(scale, scale);
                panelPrint.DrawToBitmap(memoryimg, new Rectangle(0, 0, panelPrint.Width, panelPrint.Height));
            }

            int x = (int)((e.PageBounds.Width - memoryimg.Width) / 2f);
            int y = (int)((e.PageBounds.Height - memoryimg.Height) / 2f);
            e.Graphics.DrawImage(memoryimg, x, y);
        }

        private Bitmap memoryimg;
        private void getPrintArea(Panel pn1)
        {
            memoryimg = new Bitmap(pn1.Width, pn1.Height);
            pn1.DrawToBitmap(memoryimg, new Rectangle(0, 0, pn1.Width, pn1.Height));
        }

        public void setID(String _ID)
        {
            ID = _ID;
            labelRef.Text = ID;
        }
        public String getID()
        {
            return ID;
        }
        public void SetCompanyName(string _companyName)
        {
            companyName = _companyName;
            labelCompanyName.Text = companyName;
        }

        public string GetCompanyName()
        {
            return companyName;
        }

        public void SetDate(DateTime _date)
        {
            date = _date;
            labelDateInv.Text = date.ToString("dd-MM-yyyy");
        }

        public DateTime GetDate()
        {
            return date;
        }

        public void SetTotal(double _total)
        {
            total = _total;
            
        }

        public double GetTotal()
        {
            return total;
        }

        public void SetToPay(double _toPay)
        {
            toPay = _toPay;
        }

        public double GetToPay()
        {
            return toPay;
        }

        public void SetPaid(double _paid)
        {
            paid = _paid;
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv.ClearSelection();
            //Make columns of datagridview unsortable
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //columns stretching
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgv.Columns[2].DefaultCellStyle.Format = "N2";
            dgv.Columns[1].DefaultCellStyle.Format = "N2";
            Double materialsTotal = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                materialsTotal = materialsTotal + Convert.ToDouble(row.Cells[2].Value);
            }
            labelPrice.Text = materialsTotal.ToString("#,##0.00");
            double x = materialsTotal - total;
            double percentage = 100 * total / materialsTotal;
            percentage = 100 - percentage;
            labelOthers.Text = (x).ToString("#,##0.00") + " ("+percentage.ToString("#,##0.00")+"%)";
            labelTotal.Text = "F.CFA " + total.ToString("#,##0.00");
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
            catch(Exception msg)
            {
                //dont do anything
            }
            this.Close();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void panelPrint_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += 0.2;
        }

        public double GetPaid()
        {
            return paid;
        }
        public frmPrint(String _ID)
        {
            newID = _ID;
            InitializeComponent();
            loadData();
            btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }

        private void loadData()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            //check if connection is closed, if so open it
            con.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            String x = newID;
            //String query = "select * from SalesDetails where SaleID = '"+labelRef.Text.ToString()+"';";
            String query = "select Materials.Name, SalesDetails.Quantity, SalesDetails.Price from SalesDetails INNER JOIN Materials ON Materials.ID = SalesDetails.MaterialID where SaleID = '"+newID+"';";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgv.DataSource = dt;

            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
