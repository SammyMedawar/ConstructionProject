using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Construction
{
    public partial class frmPrntRow : Form
    {
        public String newID, companyName;
        public DateTime date;
        public double balance, paid, due;
        public bool isSale = false;
        public frmPrntRow(String _ID)
        {
            newID = _ID;
            InitializeComponent();
            btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += 0.2;
        }
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panelPrint.Width / 2), this.panelPrint.Location.Y);
        }

        private Bitmap memoryimg;
        private void getPrintArea(Panel pn1)
        {
            memoryimg = new Bitmap(pn1.Width, pn1.Height);
            pn1.DrawToBitmap(memoryimg, new Rectangle(0, 0, pn1.Width, pn1.Height));
        }

        public void setID(String _ID)
        {
            newID = _ID;
            labelID.Text = newID;
        }
        public String getID()
        {
            return newID;
        }
        public void SetDate(DateTime _date)
        {
            date = _date;
            labelDate.Text = date.ToString();
        }

        public DateTime GetDate()
        {
            return date;
        }

        public void SetCompanyName(string _companyName)
        {
            companyName = _companyName;
            if (isSale)
            {
                labelTo.Text = "Dosage";
                labelFrom.Text = _companyName;
            }
            else
            {
                labelTo.Text = _companyName;
                labelFrom.Text = "Dosage";
            }
        }

        public string GetCompanyName()
        {
            return companyName;
        }

        public void SetPaid(double _paid)
        {
            paid = _paid;
            labelPaid.Text = "F.CFA " + paid.ToString("#,##0.00");
            labelPaid2.Text = "F.CFA " + paid.ToString("#,##0.00");
        }

        public double GetPaid()
        {
            return paid;
        }

        public void setDue(double _due)
        {
            due = _due;
            labelDue.Text = "F.CFA " + due.ToString("#,##0.00");
        }

        public double getDue()
        {
            return due;
        }

        public void setBalance(double _balance)
        {
            balance = _balance;
            labelBalance.Text = "F.CFA " + balance.ToString("#,##0.00");
        }
        public double getBalance()
        {
            return balance;
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

    }
}
