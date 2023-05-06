using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Construction
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
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
            //create the stocks page
            Stock toPage = new Stock();
            //show the stocks page
            toPage.Show();
            //hide the current page
            this.Hide();

        }

        private void btnInvoicing_Click(object sender, EventArgs e)
        {
            //create the invoicing page
            NewInvoices toPage = new NewInvoices();
            //show the invoicing page
            toPage.Show();
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

        private void btnSales_Click(object sender, EventArgs e)
        {
            //create the sales page
            Sales toPage = new Sales();
            //show the sales page
            toPage.Show();
            //hide the current page
            this.Hide();
        }
    }
}
