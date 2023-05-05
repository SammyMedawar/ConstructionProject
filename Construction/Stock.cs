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
using System.Net;
using System.Globalization;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Data.Common;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Construction
{
    public partial class Stock : Form
    {
        //Connection String of the Application
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ToString());

        public Stock()
        {
            InitializeComponent();
            loadData();

            //make columns unsortable
            foreach (DataGridViewColumn column in dgvMaterialsHistory.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void loadData()
        {
            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                if (String.IsNullOrEmpty(tbStockLimit.Text.ToString()))
                    return;
                int limit = Int32.Parse(tbStockLimit.Text.ToString());
                string query = "SELECT Name, Weight_Quantity FROM Materials";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvMaterials.DataSource = dt;

                string query2 = "SELECT TOP " + limit + " Description, Amount, Type FROM MaterialsRecords ORDER BY DateTime DESC";
                SqlDataAdapter adapter2 = new SqlDataAdapter(query2, con);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                dgvMaterialsHistory.DataSource = dt2;
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
        private void btnStockUpdate_Click(object sender, EventArgs e)
        {
            updateStocks();
        }
        private void updateStocks()
        {
            double materialOneWeight, materialTwoWeight, materialThreeWeight;
            String editedText = "You have successfully edited ";
            DateTime currentDateTime = DateTime.Now;
            if (!String.IsNullOrEmpty(tbMOne.Text.ToString()))
            {


                //check if connection is closed, if so open it
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                try
                {

                    materialOneWeight = Double.Parse(tbMOne.Text.ToString());
                    SqlCommand cmd = new SqlCommand("UpdateStock", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaterialID", 1);
                    if (radioSubtract.Checked)
                    {
                        materialOneWeight = materialOneWeight * -1;
                        cmd.Parameters.AddWithValue("@AddedValue", materialOneWeight);
                        cmd.Parameters.AddWithValue("@AbsoluteValue", Math.Abs(materialOneWeight));
                        cmd.Parameters.AddWithValue("@Description", "Material One");
                        cmd.Parameters.AddWithValue("@Type", '-');
                        cmd.Parameters.AddWithValue("@DateTime", currentDateTime);
                        editedText = editedText + "Material One by subtracting " + materialOneWeight * -1 + " ";
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@AddedValue", materialOneWeight);
                        cmd.Parameters.AddWithValue("@AbsoluteValue", Math.Abs(materialOneWeight));
                        cmd.Parameters.AddWithValue("@Description", "Material One");
                        cmd.Parameters.AddWithValue("@Type", '+');
                        cmd.Parameters.AddWithValue("@DateTime", currentDateTime);

                        editedText = editedText + "Material One by adding " + materialOneWeight + " ";
                    }
                    cmd.ExecuteNonQuery();
                    tbMOne.Text = "";
                    dgvMaterialsHistory.Invalidate();
                    dgvMaterialsHistory.Refresh();
                    loadData();
                    dgvMaterialsHistory.Refresh();
                }

                catch (Exception msg)
                {
                    MessageBox.Show("Oops! An error has occured. Please recheck what you entered");
                }

                //close the connection if it is still open
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


            }
            if (!String.IsNullOrEmpty(tbMTwo.Text.ToString()))
            {


                //check if connection is closed, if so open it
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                try
                {

                    materialTwoWeight = Double.Parse(tbMTwo.Text.ToString());
                    SqlCommand cmd = new SqlCommand("UpdateStock", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaterialID", 2);
                    if (radioSubtract.Checked)
                    {
                        materialTwoWeight = materialTwoWeight * -1;
                        cmd.Parameters.AddWithValue("@AddedValue", materialTwoWeight);
                        cmd.Parameters.AddWithValue("@AbsoluteValue", Math.Abs(materialTwoWeight));
                        cmd.Parameters.AddWithValue("@Description", "Material Two");
                        cmd.Parameters.AddWithValue("@Type", '-');

                        editedText = editedText + "Material Two by subtracting " + materialTwoWeight * -1 + " ";
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@AddedValue", materialTwoWeight);
                        cmd.Parameters.AddWithValue("@AbsoluteValue", Math.Abs(materialTwoWeight));
                        cmd.Parameters.AddWithValue("@Description", "Material Two");
                        cmd.Parameters.AddWithValue("@Type", "+");


                        editedText = editedText + "Material Two by adding " + materialTwoWeight + " ";
                    }
                    cmd.Parameters.AddWithValue("@DateTime", currentDateTime);
                    cmd.ExecuteNonQuery();
                    tbMTwo.Text = "";

                    dgvMaterialsHistory.Invalidate();
                    dgvMaterialsHistory.Refresh();
                    loadData();
                    dgvMaterialsHistory.Refresh();
                }

                catch (Exception msg)
                {
                    MessageBox.Show("Oops! An error has occured. Please recheck what you entered");
                }

                //close the connection if it is still open
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }


            if (!String.IsNullOrEmpty(tbMThree.Text.ToString()))
            {



                //check if connection is closed, if so open it
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                try
                {
                    materialThreeWeight = Double.Parse(tbMThree.Text.ToString());
                    SqlCommand cmd = new SqlCommand("UpdateStock", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaterialID", 3);
                    if (radioSubtract.Checked)
                    {
                        materialThreeWeight = materialThreeWeight * -1;
                        cmd.Parameters.AddWithValue("@AddedValue", materialThreeWeight);
                        cmd.Parameters.AddWithValue("@AbsoluteValue", Math.Abs(materialThreeWeight));
                        cmd.Parameters.AddWithValue("@Description", "Material Three");
                        cmd.Parameters.AddWithValue("@Type", "-");

                        editedText = editedText + "Material Three by subtracting " + materialThreeWeight * -1 + " ";
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@AddedValue", materialThreeWeight);
                        cmd.Parameters.AddWithValue("@AbsoluteValue", Math.Abs(materialThreeWeight));
                        cmd.Parameters.AddWithValue("@Description", "Material Three");
                        cmd.Parameters.AddWithValue("@Type", "+");


                        editedText = editedText + "Material Three by adding " + materialThreeWeight + " ";
                    }
                    cmd.Parameters.AddWithValue("@DateTime", currentDateTime);
                    cmd.ExecuteNonQuery();
                    tbMThree.Text = "";
                    dgvMaterialsHistory.Invalidate();
                    dgvMaterialsHistory.Refresh();
                    loadData();
                    dgvMaterialsHistory.Refresh();



                    MessageBox.Show(editedText);
                }

                catch (Exception msg)
                {
                    MessageBox.Show("Oops! An error has occured. Please recheck what you entered");
                }

                //close the connection if it is still open
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }





            }




        }

        private void tbStockLimit_KeyDown(object sender, KeyEventArgs e)
        {
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

        private void tbStockLimit_Leave(object sender, EventArgs e)
        {
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
