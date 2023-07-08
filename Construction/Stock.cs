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
using System.Data.SQLite;

namespace Construction
{
    public partial class Stock : Form
    {
        public bool hasCreatedPrices = false;
        //Connection String of the Application
        SQLiteConnection con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;", true);

        private static Stock _instance;
        public static Stock Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Stock();
                return _instance;
            }
        }

        public Stock()
        {

            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            loadData();
            
        }

        public void loadData()
        {
            //check if connection is closed, if so open it
            con.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                if (String.IsNullOrEmpty(tbStockLimit.Text.ToString()))
                {
                    MessageBox.Show("Please make sure the limit box has numbers in it");
                    tbStockLimit.Text = "25";
                    return;
                }

                if (!Int32.TryParse(tbStockLimit.Text, out int j))
                {
                    MessageBox.Show("Please make sure the limit box has numbers in it");
                    tbStockLimit.Text = "25";
                    return;

                }

                

                if (String.IsNullOrEmpty(tbStockLimit.Text.ToString()))
                {
                    con.Close();
                    return;
                }
                int limit = Int32.Parse(tbStockLimit.Text.ToString());
                string query = "SELECT Name, Weight_Quantity FROM Materials";
                string query2 = "SELECT Description, Amount, Type FROM MaterialsRecords ";
                if (radioRaw.Checked)
                {
                    query = query + " WHERE Type = 1";
                    query2 = query2 + " WHERE Type = '+'";
                }
                else if (radioBriques.Checked)
                {
                    query = query + " WHERE Type = 0";
                    query2 = query2 + " WHERE Type = '-'";
                }
                query = query + " ORDER BY Name";
                query2 = query2 + " ORDER BY DateTime DESC LIMIT " + limit;
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvMaterials.DataSource = dt;

                SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(query2, con);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                dgvMaterialsHistory.DataSource = dt2;

                dgvMaterialsHistory.Columns[0].FillWeight = 150;
                dgvMaterialsHistory.Columns[2].FillWeight = 50;
                // dgvMaterialsHistory.CurrentCell.Selected = false;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
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
            
            //show the homepage
            Homepage.Instance.Show();
            Homepage.Instance.loadData();
            //hide the current page
            this.Hide();

        }
        private void btnStockUpdate_Click(object sender, EventArgs e)
        {
            updateStocks();
        }

        private void updateStocks()
        {
            int count = 0;
            DateTime currentDateTime = DateTime.Now;
            String editedText = "You have successfully updated the following stocks \n";
            double materialWeight;
            int materialID;
            String materialDescription;
            foreach (TextBox tv in panelBriques.Controls.OfType<TextBox>())
            {
                double jpop = 0;
                if(tv.Text.ToString().Length != 0)
                {
                    if (!Double.TryParse(tv.Text, out jpop))
                    {
                        MessageBox.Show("Please make sure the boxes have numbers in them!");
                        return;
                    }
                }

                else
                {
                    if (jpop < 0)
                    {
                        MessageBox.Show("Negative numbers are not allowed as values inside the textboxes!");
                        return;
                    }
                }
            }
            String query = "";
            foreach (TextBox tv in panelRaw.Controls.OfType<TextBox>())
            {
                double jpop = 0;
                if (tv.Text.ToString().Length != 0)
                {
                    if (!Double.TryParse(tv.Text, out jpop))
                    {
                        MessageBox.Show("Please make sure the boxes have numbers in them!");
                        return;
                    }
                    if (radioSubtract.Checked) {
                        int ID = 0;
                        if (tv.Name == "tbCement") ID = 6;
                        else if (tv.Name == "tbBlank") ID = 16;
                        else if (tv.Name == "tbColorant") ID = 15;
                        else if (tv.Name == "tbGrav1") ID = 1;
                        else if (tv.Name == "tbGrav4") ID = 2;
                        else if (tv.Name == "tbGrav5") ID = 3;
                        else if (tv.Name == "tbGrav6") ID = 13;
                        else if (tv.Name == "tbGrav8") ID = 14;
                        else if (tv.Name == "tbGrav15") ID = 4;
                        else if (tv.Name == "tbSable") ID = 5;

                        if(con.State == ConnectionState.Closed)
                            con.Open();

                        query = "SELECT Weight_Quantity, Name FROM Materials WHERE ID = @ID";
                        SQLiteCommand cmd = new SQLiteCommand(query, con);
                        cmd.Parameters.AddWithValue("@ID", ID);
                        SQLiteDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            if (dr.GetFloat(0) - jpop < 0)
                            {
                                MessageBox.Show(dr.GetString(1) + " only has " + dr.GetFloat(0) +"! You cannot subtract " + jpop +" from it");
                                dr.Dispose();
                                con.Close();
                                return;
                            }
                        }

                        dr.Close();
                        dr.Dispose();

                        if(con.State == ConnectionState.Open)
                            con.Close();
                    }
                }

                else
                {
                    if (jpop < 0)
                    {
                        MessageBox.Show("Negative numbers are not allowed as values inside the textboxes!");
                        con.Close();
                        return;
                    }
                }
            }

            if (!String.IsNullOrEmpty(tbGrav1.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Gravier 0/1: -" + tbGrav1.Text.ToString() + "\n";
                else
                    editedText = editedText + "Gravier 0/1: " + tbGrav1.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbGrav1.Text.ToString());
                materialID = 1;
                materialDescription = "Gravier 0/1";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbGrav1.Text = "";
            }
            else
                count++;

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
            else
                count++;

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
            else
                count++;

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
            else
                count++;
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
            else
                count++;
            if (!String.IsNullOrEmpty(tbCement.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Ciment: -" + tbCement.Text.ToString() + "\n";
                else
                    editedText = editedText + "Ciment: " + tbCement.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbCement.Text.ToString());
                materialID = 6;
                materialDescription = "Ciment";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbCement.Text = "";
            }
            else
                count++;
            if (!String.IsNullOrEmpty(tbGrav6.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Gravier 0/6: -" + tbGrav6.Text.ToString() + "\n";
                else
                    editedText = editedText + "Gravier 0/6: " + tbGrav6.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbGrav6.Text.ToString());
                materialID = 13;
                materialDescription = "Gravier 0/6";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbGrav6.Text = "";
            }
            else
                count++;
            if (!String.IsNullOrEmpty(tbGrav8.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Gravier 0/8: -" + tbGrav8.Text.ToString() + "\n";
                else
                    editedText = editedText + "Gravier 0/8: " + tbGrav8.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbGrav8.Text.ToString());
                materialID = 14;
                materialDescription = "Gravier 0/8";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbGrav8.Text = "";
            }
            else
                count++;
            if (!String.IsNullOrEmpty(tbColorant.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Colorant: -" + tbColorant.Text.ToString() + "\n";
                else
                    editedText = editedText + "Colorant: " + tbColorant.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbColorant.Text.ToString());
                materialID = 15;
                materialDescription = "Colorant";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbColorant.Text = "";
            }
            else
                count++;
            if (!String.IsNullOrEmpty(tbBlank.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Ciment Blanc: -" + tbBlank.Text.ToString() + "\n";
                else
                    editedText = editedText + "Ciment Blanc: " + tbBlank.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbBlank.Text.ToString());
                materialID = 16;
                materialDescription = "Ciment Blanc";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbBlank.Text = "";
            }
            else
                count++;


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
            else
                count++;
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
            else
                count++;
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
            else
                count++;
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
            else
                count++;
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
            else
                count++;
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
            else
                count++;
            if (!String.IsNullOrEmpty(tbPav6.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Pavé 6cm: -" + tbPav6.Text.ToString() + "\n";
                else
                    editedText = editedText + "Pavé 6cm: " + tbPav6.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbPav6.Text.ToString());
                materialID = 17;
                materialDescription = "Pavé 6cm";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbPav6.Text = "";
            }
            else
                count++;
            if (!String.IsNullOrEmpty(tbPav8.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Pavé 8cm: -" + tbPav8.Text.ToString() + "\n";
                else
                    editedText = editedText + "Pavé 8cm: " + tbPav8.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbPav8.Text.ToString());
                materialID = 18;
                materialDescription = "Pavé 8cm";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbPav8.Text = "";
            }
            else
                count++;
            if (!String.IsNullOrEmpty(tbPav10.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Pavé 10cm: -" + tbPav10.Text.ToString() + "\n";
                else
                    editedText = editedText + "Pavé 10cm: " + tbPav10.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbPav10.Text.ToString());
                materialID = 19;
                materialDescription = "Pavé 10cm";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbPav10.Text = "";
            }
            else
                count++;
            if (!String.IsNullOrEmpty(tbPav13.Text.ToString()))
            {
                if (radioSubtract.Checked)
                    editedText = editedText + "Pavé 13cm: -" + tbPav13.Text.ToString() + "\n";
                else
                    editedText = editedText + "Pavé 13cm: " + tbPav13.Text.ToString() + "\n";
                materialWeight = Double.Parse(tbPav13.Text.ToString());
                materialID = 20;
                materialDescription = "Pavé 13cm";
                updateStock(materialID, materialWeight, materialDescription, currentDateTime, editedText);
                tbPav13.Text = "";
            }
            else
                count++;

            if (count >= 20)
            {
                MessageBox.Show("Please fill in at least one of the boxes!");
                return;
            }

            MessageBox.Show(editedText);
            if (!radioSubtract.Enabled)
                radioSubtract.Enabled = true;
        }

        private void updateStock(int materialID, double materialWeight, String materialDescription, DateTime currentDateTime, String editedText)
        {
            con.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        String query1 = "";
                        if (radioAdd.Checked)
                            query1 = "UPDATE Materials SET Weight_Quantity = Weight_Quantity + @AddedValue WHERE ID = @MaterialID;";
                        else if (radioSubtract.Checked)
                            query1 = "UPDATE Materials SET Weight_Quantity = Weight_Quantity - @AddedValue WHERE ID = @MaterialID;";
                        String query2 = "INSERT INTO MaterialsRecords (Description, Amount, Type, DateTime) VALUES (@Description, @AbsoluteValue, @Type, @DateTime);";

                        SQLiteCommand cmd = new SQLiteCommand(query1, con);
                        SQLiteCommand cmd2 = new SQLiteCommand(query2, con);

                        cmd.Parameters.AddWithValue("@MaterialID", materialID);
                        cmd.Parameters.AddWithValue("@AddedValue", materialWeight);

                        cmd2.Parameters.AddWithValue("@Description", materialDescription);
                        cmd2.Parameters.AddWithValue("@DateTime", currentDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        if (radioSubtract.Checked)
                        {
                            materialWeight = materialWeight * -1;
                            cmd2.Parameters.AddWithValue("@AbsoluteValue", Math.Abs(materialWeight));
                            cmd2.Parameters.AddWithValue("@Type", "-");
                            editedText = editedText + materialDescription + " by subtracting " + materialWeight * -1 + " ";
                        }
                        else
                        {
                            cmd2.Parameters.AddWithValue("@AbsoluteValue", Math.Abs(materialWeight));
                            cmd2.Parameters.AddWithValue("@Type", "+");
                            editedText = editedText + materialDescription + " by adding " + materialWeight + " ";
                        }

                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Console.WriteLine("Transaction rolled back. Reason: " + ex.Message);
                    }
                }

                radioAll.Checked = true;
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

        private void dgvMaterialsHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvMaterialsHistory.ClearSelection();
            //make columns unsortable
            foreach (DataGridViewColumn column in dgvMaterialsHistory.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dgvMaterialsHistory.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgvMaterialsHistory.Columns[1].DefaultCellStyle.Format = "N2";
        }

        private void dgvMaterials_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvMaterials.ClearSelection();
            //make columns unsortable
            foreach (DataGridViewColumn column in dgvMaterialsHistory.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dgvMaterials.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dgvMaterials.Columns[1].DefaultCellStyle.Format = "N2";
            dgvMaterials.Columns[1].HeaderCell.Value = "Weight/Quantity";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
                timer1.Stop();
            Opacity += .9;
        }

        private void radioSubtract_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSubtract.Checked)
            {
                foreach (TextBox tb in panelBriques.Controls.OfType<TextBox>())
                {
                    tb.Enabled = false;
                }
            }
            else
            {
                foreach(TextBox tb in panelBriques.Controls.OfType<TextBox>())
                {
                    tb.Enabled = true;
                }
            }
        }

        private void tbC10_Leave(object sender, EventArgs e)
        {
            bool hasAtLeastOneBoxFilled = false;
            foreach(TextBox tv in panelBriques.Controls.OfType<TextBox>())
            {
                if(tv.Text.ToString().Length != 0)
                {
                    hasAtLeastOneBoxFilled = true;
                    radioSubtract.Enabled = false;
                    if (radioSubtract.Checked == true)
                    {
                        radioAdd.Checked = true;
                    }
                }
            }

            if (!hasAtLeastOneBoxFilled)
            {
                radioSubtract.Enabled = true;
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbC10_TextChanged(object sender, EventArgs e)
        {
            bool hasAtLeastOneBoxFilled = false;
            foreach (TextBox tv in panelBriques.Controls.OfType<TextBox>())
            {
                if (tv.Text.ToString().Length != 0)
                {
                    hasAtLeastOneBoxFilled = true;
                    radioSubtract.Enabled = false;
                    if (radioSubtract.Checked == true)
                    {
                        radioAdd.Checked = true;
                    }
                }
            }

            if (!hasAtLeastOneBoxFilled)
            {
                radioSubtract.Enabled = true;
            }
        }

        private void radioAll_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void tbCement_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbBlank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Stock_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucSettings.Instance.backupData();
            System.Windows.Forms.Application.Exit();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void tbP20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.X))
            {
                // Disable copying and cutting
                e.SuppressKeyPress = true;
            }

            base.OnKeyDown(e);
        }

        private void tbStockLimit_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
