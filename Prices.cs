using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Construction
{
    public partial class Prices : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;", true);
        private bool decimalPointEntered = false;
        public TextBox[] tbArray;

        public Prices()
        {
            InitializeComponent();
            tbArray = new TextBox[] { tbCr10, tbCr15, tbCr20, tbPl10, tbPl15, tbPl20, tbP6, tbP8, tbP10, tbP13 };
            loadData();
        }

        public void loadData()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            String query = "SELECT MaterialName, Price FROM Prices";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvPrices.DataSource = dt;


            if (con.State == ConnectionState.Open)
                con.Close();
        }

        private void dgvPrices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPrices.Columns[1].DefaultCellStyle.Format = "N2";
            dgvPrices.Columns[0].HeaderCell.Value = "Product";
            dgvPrices.Columns[1].HeaderCell.Value = "Price";
        }

        private void tbCr10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && decimalPointEntered)
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && !decimalPointEntered)
            {
                decimalPointEntered = true;
            }

            if (e.KeyChar == (char)22) // Ctrl+V
            {
                // Disable pasting
                e.Handled = true;
            }
        }

        private void tbCr10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.X))
            {
                // Disable copying and cutting
                e.SuppressKeyPress = true;
            }

            base.OnKeyDown(e);
        }

        private void tbCr10_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox1 = (TextBox)sender;
            if (!textBox1.Text.Contains("."))
            {
                decimalPointEntered = false;
            }
        }

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            foreach(TextBox tb in tbArray)
            {
                if(tb.Text == "0")
                {
                    MessageBox.Show("0 is an invalid number! Please change any boxes that contain 0", "Error!");
                    return;
                }
            }

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            using (var trans = con.BeginTransaction())
            {
                try
                {

                    double temp = 0;
                    int count = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        if (Double.TryParse(tbArray[i].Text, out temp))
                        {
                            int materialID = 0;
                            if (i == 0)
                                materialID = 7;
                            else if (i == 1)
                                materialID = 8;
                            else if (i == 2)
                                materialID = 9;
                            else if (i == 3)
                                materialID = 10;
                            else if (i == 4)
                                materialID = 11;
                            else if (i == 5)
                                materialID = 12;
                            else if (i == 6)
                                materialID = 17;
                            else if (i == 7)
                                materialID = 18;
                            else if (i == 8)
                                materialID = 19;
                            else if (i == 9)
                                materialID = 20;


                            String query = "Update Prices SET Price = @Price WHERE MaterialID = @ID";
                            SQLiteCommand cmd = new SQLiteCommand(query, con);
                            cmd.Parameters.AddWithValue("@Price", temp);
                            cmd.Parameters.AddWithValue("@ID", materialID);
                            cmd.ExecuteNonQuery();
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        trans.Commit();
                        MessageBox.Show("Update Successful!", "Operation Successful!");
                        for (int i = 0; i < 10; i++)
                        {
                            tbArray[i].Text = "";
                        }
                        loadData();
                    }
                    else
                    {
                        trans.Rollback();
                        MessageBox.Show("Please fill in the price of at least 1 material", "Error!");
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("An error has occured! Please restart the application", "Error!");
                    return;
                }
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void btnHomepage_Click(object sender, EventArgs e)
        {

            //show the homepage
            Homepage.Instance.Show();
            Homepage.Instance.loadData();
            //hide the current page
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login toPage = new Login();
            //show the Login
            toPage.Show();
            //hide the current page
            this.Hide();
        }

        private void Prices_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucSettings.Instance.backupData();
            Application.Exit();
        }
    }
}
