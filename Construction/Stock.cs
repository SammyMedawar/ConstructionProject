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

            this.dgvMaterials.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            this.dgvMaterialsHistory.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
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
        /*private void updateStocks()
        {
            double materialOneWeight, materialTwoWeight, materialThreeWeight;
            String editedText = "You have successfully edited ";
            DateTime currentDateTime = DateTime.Now;
            if (!String.IsNullOrEmpty(tbGrav1.Text.ToString()))
            {


                //check if connection is closed, if so open it
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                try
                {
                    //loop over every textbox


                    materialOneWeight = Double.Parse(tbGrav1.Text.ToString());
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
                    tbGrav1.Text = "";
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
            if (!String.IsNullOrEmpty(tbGrav4.Text.ToString()))
            {


                //check if connection is closed, if so open it
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                try
                {

                    materialTwoWeight = Double.Parse(tbGrav4.Text.ToString());
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
                    tbGrav4.Text = "";

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


            if (!String.IsNullOrEmpty(tbGrav5.Text.ToString()))
            {



                //check if connection is closed, if so open it
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                try
                {
                    materialThreeWeight = Double.Parse(tbGrav5.Text.ToString());
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
                    tbGrav5.Text = "";
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




        }*/

        private void updateStocks()
        {
            DateTime currentDateTime = DateTime.Now;
            String editedText = "You have successfully updated the following stocks \n";
            double materialWeight;
            int materialID;
            String materialDescription;

            if (!String.IsNullOrEmpty(tbGrav1.Text.ToString()))
            {
                if(radioSubtract.Checked)
                    editedText = editedText + "Gravier 0/1: -" + tbGrav1.Text.ToString() + "\n";
                else
                editedText = editedText + "Gravier 0/1: " + tbGrav1.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbGrav1.Text.ToString());
                materialID = 1;
                materialDescription = "Gravier 0/1";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbGrav1.Text = "";
            }

            if (!String.IsNullOrEmpty(tbGrav4.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Gravier 0/4: -" + tbGrav4.Text.ToString() + "\n";
                else
                    editedText = editedText + "Gravier 0/4: " + tbGrav4.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbGrav4.Text.ToString());
                materialID = 2;
                materialDescription = "Gravier 0/4";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbGrav4.Text = "";
            }

            if (!String.IsNullOrEmpty(tbGrav5.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Gravier 0/5: -" + tbGrav5.Text.ToString() + "\n";
                else
                    editedText = editedText + "Gravier 0/5: " + tbGrav5.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbGrav5.Text.ToString());
                materialID = 3;
                materialDescription = "Gravier 0/5";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbGrav5.Text = "";
            }

            if (!String.IsNullOrEmpty(tbGrav15.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Gravier 5/15: -" + tbGrav15.Text.ToString() + "\n";
                else
                    editedText = editedText + "Gravier 5/15: " + tbGrav15.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbGrav15.Text.ToString());
                materialID = 4;
                materialDescription = "Gravier 5/15";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbGrav15.Text = "";
            }
            if (!String.IsNullOrEmpty(tbSable.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Sable: -" + tbSable.Text.ToString() + "\n";
                else
                    editedText = editedText + "Sable: " + tbSable.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbSable.Text.ToString());
                materialID = 5;
                materialDescription = "Sable";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbSable.Text = "";
            }
            if (!String.IsNullOrEmpty(tbCement.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Cement: -" + tbCement.Text.ToString() + "\n";
                else
                    editedText = editedText + "Cement: " + tbCement.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbCement.Text.ToString());
                materialID = 6;
                materialDescription = "Cement";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbCement.Text = "";
            }

            //Out Materials
            if (!String.IsNullOrEmpty(tbC10.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Brique 10cm Creux: -" + tbC10.Text.ToString() + "\n";
                else
                    editedText = editedText + "Brique 10cm Creux: " + tbC10.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbC10.Text.ToString());
                materialID = 7;
                materialDescription = "Brique 10cm Creux";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbC10.Text = "";
            }
            if (!String.IsNullOrEmpty(tbC15.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Brique 15cm Creux: -" + tbC15.Text.ToString() + "\n";
                else
                    editedText = editedText + "Brique 15cm Creux: " + tbC15.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbC15.Text.ToString());
                materialID = 8;
                materialDescription = "Brique 15cm Creux";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbC15.Text = "";
            }
            if (!String.IsNullOrEmpty(tbC20.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Brique 20cm Creux: -" + tbC20.Text.ToString() + "\n";
                else
                    editedText = editedText + "Brique 20cm Creux: " + tbC20.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbC20.Text.ToString());
                materialID = 9;
                materialDescription = "Brique 20cm Creux";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbC20.Text = "";
            }
            if (!String.IsNullOrEmpty(tbP10.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Brique 10cm Pleinne: -" + tbP10.Text.ToString() + "\n";
                else
                    editedText = editedText + "Brique 10cm Pleinne: " + tbP10.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbP10.Text.ToString());
                materialID = 10;
                materialDescription = "Brique 10cm Pleinne";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbP10.Text = "";
            }
            if (!String.IsNullOrEmpty(tbP15.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Brique 15cm Pleinne: -" + tbP15.Text.ToString() + "\n";
                else
                    editedText = editedText + "Brique 15cm Pleinne: " + tbP15.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbP15.Text.ToString());
                materialID = 11;
                materialDescription = "Brique 15cm Pleinne";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbP15.Text = "";
            }
            if (!String.IsNullOrEmpty(tbP20.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Brique 20cm Pleinne: -" + tbP20.Text.ToString() + "\n";
                else
                    editedText = editedText + "Brique 20cm Pleinne: " + tbP20.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbP20.Text.ToString());
                materialID = 12;
                materialDescription = "Brique 20cm Pleinne";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbP20.Text = "";
            }

            MessageBox.Show(editedText);
        }

        private void updateStock(int materialID, double materialWeight, String materialDescription, DateTime currentDateTime, String editedText)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                SqlCommand cmd = new SqlCommand("UpdateStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaterialID", materialID);

                if (radioSubtract.Checked)
                {
                    materialWeight = materialWeight * -1;
                    cmd.Parameters.AddWithValue("@AddedValue", materialWeight);
                    cmd.Parameters.AddWithValue("@AbsoluteValue", Math.Abs(materialWeight));
                    cmd.Parameters.AddWithValue("@Type", '-');
                    editedText = editedText + materialDescription + " by subtracting " + materialWeight * -1 + " ";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AddedValue", materialWeight);
                    cmd.Parameters.AddWithValue("@AbsoluteValue", Math.Abs(materialWeight));
                    cmd.Parameters.AddWithValue("@Type", '+');
                    editedText = editedText + materialDescription + " by adding " + materialWeight + " ";
                }

                cmd.Parameters.AddWithValue("@Description", materialDescription);
                cmd.Parameters.AddWithValue("@DateTime", currentDateTime);

                cmd.ExecuteNonQuery();
                dgvMaterialsHistory.Invalidate();
                dgvMaterialsHistory.Refresh();
                loadData();
                dgvMaterialsHistory.Refresh();
            }
            catch (Exception msg)
            {
                MessageBox.Show("Oops! An error has occurred. Please recheck what you entered");
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
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

        private void Stock_Load(object sender, EventArgs e)
        {

        }
    }
}
