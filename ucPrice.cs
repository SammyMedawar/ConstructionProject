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
    public partial class ucPrice : UserControl
    {

        SQLiteConnection con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;", true);

        private static ucPrice _instance;
        public static ucPrice Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucPrice();
                return _instance;
            }
        }

        public ucPrice()
        {
            InitializeComponent();
            loadData();
        }


        public void loadData()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            String query = "SELECT Price FROM Prices";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader dr = cmd.ExecuteReader();
            float[] myArray = new float[10];
            int i = 0;
            while (dr.Read())
            {
                myArray[i] = dr.GetFloat(0);
                i++;
            }
            dr.Close();
            dr.Dispose();

            TextBox[] tbArray = { tbCr10, tbCr15, tbCr20, tbPl10, tbPl15, tbPl20, tbP6, tbP8, tbP10, tbP13 };

            for(i = 0; i < 10; i++)
            {
                tbArray[i].Text = myArray[i].ToString("#,##0.00");
            }

            if (con.State == ConnectionState.Open)
                con.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Stock.Instance.panelOne.BringToFront();
            Stock.Instance.panelOne.Focus();
        }

        private void tbCr10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
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
    }
}
