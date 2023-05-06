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

namespace Construction
{
    public partial class UpdateInvoice : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ToString());
        public bool isSearching = false;
        public PlaceholderTextBox[,] tbArray;
        public Label[] labels;
        public UpdateInvoice()
        {
            InitializeComponent();
            tbArray = new PlaceholderTextBox[6, 6];
            tbArray[0, 0] = tbM1;
            tbArray[0, 1] = tbM1P;
            tbArray[1, 0] = tbM2;
            tbArray[1, 1] = tbM2P;
            tbArray[2, 0] = tbM3;
            tbArray[2, 1] = tbM3P;
            tbArray[3, 0] = tbM4;
            tbArray[3, 1] = tbM4P;
            tbArray[4, 0] = tbM5;
            tbArray[4, 1] = tbM5P;
            tbArray[5, 0] = tbM6;
            tbArray[5, 1] = tbM6P;

            labels = new Label[6] { lab0, lab1, lab2, lab3, lab4, lab5 };
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIDSearch_Click(object sender, EventArgs e)
        {
            isSearching = true;
            dtInvoiceDate.Enabled = false;
            tbM1.Enabled = false;
            tbM1P.Enabled = false;
            tbM2.Enabled = false;
            tbM2P.Enabled = false;
            tbM3.Enabled = false;
            tbM3P.Enabled = false;
            tbM4.Enabled = false;
            tbM4P.Enabled = false;
            tbM5.Enabled = false;
            tbM5P.Enabled = false;
            tbM6.Enabled = false;
            tbM6P.Enabled = false;
            tbPrice.Enabled = false;
            String searchString = tbID.Text.ToString();
            searchForID(searchString);
        }

        private void searchForID(String searchString)
        {
            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }


            try
            {
                bool hasDoneOne = false;
                //create search query string
                string query = "SELECT NewInvoices.* , NewInvoicesDetails.MaterialID, NewInvoicesDetails.Quantity, NewInvoicesDetails.Price FROM NewInvoices INNER JOIN NewInvoicesDetails ON NewInvoices.ID = NewInvoicesDetails.InvoiceID where NewInvoices.ID = '" + searchString + "';";

                //create an object SqlCommand that will take the query and the connection string
                SqlCommand cmd = new SqlCommand(query, con);


                //create a data reader that will execute the query
                SqlDataReader dr = cmd.ExecuteReader();

                //if the data reader finds the row, do this
                while (dr.Read())
                {
                    if (!hasDoneOne)
                    {
                        tbID.Text = dr.GetString(0);
                        tbCompanyName.Text = dr.GetString(1);
                        DateTime newDate = dr.GetDateTime(2);
                        dtInvoiceDate.Value = newDate;
                        tbPrice.Text = dr.GetFloat(3).ToString();
                        //kl
                        tbPaid.Text = dr.GetFloat(5).ToString();
                        hasDoneOne = true;
                    }
                    if (dr.GetInt32(6) == 1)
                    {
                        tbM1.removePlaceHolder();
                        tbM1.Text = dr.GetFloat(7).ToString();
                        tbM1P.removePlaceHolder();
                        tbM1P.Text = dr.GetFloat(8).ToString();
                    }
                    else if (dr.GetInt32(6) == 2)
                    {
                        tbM2.removePlaceHolder();
                        tbM2.Text = dr.GetFloat(7).ToString();
                        tbM2P.removePlaceHolder();
                        tbM2P.Text = dr.GetFloat(8).ToString();
                    }
                    else if (dr.GetInt32(6) == 3)
                    {
                        tbM3.removePlaceHolder();
                        tbM3.Text = dr.GetFloat(7).ToString();
                        tbM3P.removePlaceHolder();
                        tbM3P.Text = dr.GetFloat(8).ToString();
                    }
                    else if (dr.GetInt32(6) == 4)
                    {
                        tbM4.removePlaceHolder();
                        tbM4.Text = dr.GetFloat(7).ToString();
                        tbM4P.removePlaceHolder();
                        tbM4P.Text = dr.GetFloat(8).ToString();
                    }
                    else if (dr.GetInt32(6) == 5)
                    {
                        tbM5.removePlaceHolder();
                        tbM5.Text = dr.GetFloat(7).ToString();
                        tbM5P.removePlaceHolder();
                        tbM5P.Text = dr.GetFloat(8).ToString();
                    }
                    else if (dr.GetInt32(6) == 6)
                    {
                        tbM6.removePlaceHolder();
                        tbM6.Text = dr.GetFloat(7).ToString();
                        tbM6P.removePlaceHolder();
                        tbM6P.Text = dr.GetFloat(8).ToString();
                    }
                }

                labelPaid.Text = "Add Payment";
                btnAdd.Text = "Update";


                if (!hasDoneOne)
                {
                    MessageBox.Show("An Invoice with the ID " + searchString + " doesn't exist!");

                }
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

        private void tbID_KeyDown(object sender, KeyEventArgs e)
        {
            if (isSearching)
            {
                isSearching = false;
                dtInvoiceDate.Enabled = true;
                tbM1.Enabled = true;
                tbM1P.Enabled = true;
                tbM2.Enabled = true;
                tbM2P.Enabled = true;
                tbM3.Enabled = true;
                tbM3P.Enabled = true;
                tbM4.Enabled = true;
                tbM4P.Enabled = true;
                tbM5.Enabled = true;
                tbM5P.Enabled = true;
                tbM6.Enabled = true;
                tbM6P.Enabled = true;
                tbPrice.Enabled = true;
                labelPaid.Text = "Paid";
                btnAdd.Text = "Add";
            }
        }

        private void tbID_Leave(object sender, EventArgs e)
        {
            if (doesIDExists(tbID.Text.ToString()))
            {
                isSearching = true;
                dtInvoiceDate.Enabled = false;
                tbM1.Enabled = false;
                tbM1P.Enabled = false;
                tbM2.Enabled = false;
                tbM2P.Enabled = false;
                tbM3.Enabled = false;
                tbM3P.Enabled = false;
                tbM4.Enabled = false;
                tbM4P.Enabled = false;
                tbM5.Enabled = false;
                tbM5P.Enabled = false;
                tbM6.Enabled = false;
                tbM6P.Enabled = false;
                tbPrice.Enabled = false;

                labelPaid.Text = "Add Payment";
                btnAdd.Text = "Update";
            }
        }

        private bool doesIDExists(String searchString)
        {
            bool doesExist = false;

            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }


            try
            {
                //create search query string
                string query = "SELECT * FROM NewInvoices where ID = @ID;";

                //create an object SqlCommand that will take the query and the connection string
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ID", searchString);


                //create a data reader that will execute the query
                SqlDataReader dr = cmd.ExecuteReader();

                //if the data reader finds the row, do this
                if (dr.Read())
                {
                    doesExist = true;
                }
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

            return doesExist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetText();
        }

        private void resetText()
        {
            labelPaid.Text = "Paid";
            btnAdd.Text = "Add";
            tbM1.Text = "";
            tbM1.setPlaceholder();
            tbM1.isPlaceHolder = true;
            tbM1P.Text = "";
            tbM1P.setPlaceholder();
            tbM1P.isPlaceHolder = true;
            tbM2.Text = "";
            tbM2.setPlaceholder();
            tbM2.isPlaceHolder = true;
            tbM2P.Text = "";
            tbM2P.setPlaceholder();
            tbM2P.isPlaceHolder = true;
            tbM3.Text = "";
            tbM3.setPlaceholder();
            tbM3.isPlaceHolder = true;
            tbM3P.Text = "";
            tbM3P.setPlaceholder();
            tbM3P.isPlaceHolder = true;
            tbM4.Text = "";
            tbM4.setPlaceholder();
            tbM4.isPlaceHolder = true;
            tbM4P.Text = "";
            tbM4P.setPlaceholder();
            tbM4P.isPlaceHolder = true;
            tbM5.Text = "";
            tbM5.setPlaceholder();
            tbM5.isPlaceHolder = true;
            tbM5P.Text = "";
            tbM5P.setPlaceholder();
            tbM5P.isPlaceHolder = true;
            tbM6.Text = "";
            tbM6.setPlaceholder();
            tbM6.isPlaceHolder = true;
            tbM6P.Text = "";
            tbM6P.setPlaceholder();
            tbM6P.isPlaceHolder = true;

            tbPrice.Text = "";
            tbPaid.Text = "";
            tbID.Text = "";
            tbCompanyName.Text = "";
            dtInvoiceDate.Value = DateTime.Now;
            isSearching = false;
            dtInvoiceDate.Enabled = true;
            tbM1.Enabled = true;
            tbM1P.Enabled = true;
            tbM2.Enabled = true;
            tbM2P.Enabled = true;
            tbM3.Enabled = true;
            tbM3P.Enabled = true;
            tbM4.Enabled = true;
            tbM4P.Enabled = true;
            tbM5.Enabled = true;
            tbM5P.Enabled = true;
            tbM6.Enabled = true;
            tbM6P.Enabled = true;
            tbPrice.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //check, please god just check

            //check if some textboxes are empty
            if (tbID.Text.ToString().Length == 0 || tbCompanyName.Text.ToString().Length == 0
                || dtInvoiceDate.Text.ToString().Length == 0 || tbPrice.Text.ToString().Length == 0
                || tbPaid.Text.ToString().Length == 0)
            {
                MessageBox.Show("Please make sure all textboxes are filled in!");
                return;
            }

            double z = 0, y = 0;

            String ID = tbID.Text.ToString(), companyName = tbCompanyName.Text.ToString();
            DateTime dt = dtInvoiceDate.Value;
            String x = tbM1.Text.ToString();
            double M1 = 0, M1P = 0;
            double M2 = 0, M2P = 0;
            double M3 = 0, M3P = 0;
            double M4 = 0, M4P = 0;
            double M5 = 0, M5P = 0;
            double M6 = 0, M6P = 0;
            double total = 0, paid = 0, toPay = 0;
            //this should be double.tryparse, inout string error occurs here
            try
            {
                if (!string.IsNullOrEmpty(tbM1.Text))
                    M1 = Convert.ToDouble(tbM1.Text);

                if (!string.IsNullOrEmpty(tbM2.Text))
                    M2 = Convert.ToDouble(tbM2.Text);

                if (!string.IsNullOrEmpty(tbM3.Text))
                    M3 = Convert.ToDouble(tbM3.Text);

                if (!string.IsNullOrEmpty(tbM4.Text))
                    M4 = Convert.ToDouble(tbM4.Text);

                if (!string.IsNullOrEmpty(tbM5.Text))
                    M5 = Convert.ToDouble(tbM5.Text);

                if (!string.IsNullOrEmpty(tbM6.Text))
                    M6 = Convert.ToDouble(tbM6.Text);
                //same here
                 total = Double.Parse(tbPrice.Text.ToString());
                 paid = Double.Parse(tbPaid.Text.ToString());
                 toPay = total - paid;
            }
            catch(Exception msg)
            {
                MessageBox.Show("Please make sure the Materials, Price, and Paid have only numbers in them");
                return;
            }

            if(paid > total || toPay > total)
            {
                MessageBox.Show("Paid or To Pay cannot be bigger than total! Please fix this");
                return;
            }

            if (doesIDExists(tbID.Text.ToString()))
            {
                //check if connection is closed, if so open it
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                try
                {
                   
                    //update invoice
                    String query1 = "Update NewInvoices set CompanyName = @CompanyName, Paid = @Paid, ToPay = @ToPay where ID = @ID";
                    SqlCommand cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@CompanyName", companyName);
                    cmd.Parameters.AddWithValue("@Paid", paid);
                    cmd.Parameters.AddWithValue("@ToPay", toPay);
                    cmd.Parameters.AddWithValue("@ID", ID);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Invoice " + ID + " has been updated with the following information:" 
                        + "\nAmount Paid: " + paid +"\nAmount To Pay: " + toPay +"\nTotal: "+total);
                    resetText();

                }
                catch (Exception msg)
                {
                    MessageBox.Show("An Error has occured! Please make sure everything is correct");
                }

            }
            else
            {
                bool hasCounted = false;
                //check if connection is closed, if so open it
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                try
                {

                    for (int i = 0; i < 6; i++)
                    {
                        //If weight is filled, price should be filled too otherwise give error
                        if ((tbArray[i, 0].Text.ToString().Length != 0 && tbArray[i, 1].Text.ToString().Length == 0) ||
                            (tbArray[i, 0].Text.ToString().Length == 0 && tbArray[i, 1].Text.ToString().Length != 0))
                        {
                            MessageBox.Show("Please sure you have filled in the boxes for " + labels[i] + " correctly!");
                            return;
                        }

                        //check if any inputs are not numbers
                        if (Double.TryParse(tbArray[i, 0].Text.ToString(), out z))
                        {
                            if (Double.TryParse(tbArray[i, 1].Text.ToString(), out y))
                            {
                                //do nothing :P, I don't want to execute a cmd here because later on errors might occur and Im not using transactions
                            }
                            else
                            {
                                MessageBox.Show("Please make sure to fill in the information correctly for " + labels[i]);
                                return;
                            }
                        }
                        else
                        {
                            continue;
                        }

                    }

                    if(M1 == 0 && M1P == 0 && M2 == 0 && M2P == 0 && M3 == 0 && M3P == 0 && M4 == 0 && M4P == 0 &&
                        M5 == 0 && M5P == 0 && M6 == 0 && M6P == 0)
                    {
                        MessageBox.Show("Please fill in at least 1 material");
                        return;
                    }

                    //Add invoice
                    String query1 = "INSERT INTO NewInvoices VALUES(@ID, @CompanyName,@DateInv, @Total, @ToPay, @Paid);";
                    SqlCommand cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@CompanyName", companyName);
                    cmd.Parameters.AddWithValue("@DateInv", dt);
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@ToPay", toPay);
                    cmd.Parameters.AddWithValue("@Paid", paid);
                    cmd.ExecuteNonQuery();

                    for(int i = 0; i < 6; i++)
                    {
                        //if field is not empty, that means this field should be inserted
                        //We already made sure that the field next to it has a number (Hopefully!)
                        if (Double.TryParse(tbArray[i,0].Text.ToString(), out z))
                        {
                            String materialName = "";
                            int materialID = 0;
                            y = Double.Parse(tbArray[i, 1].Text.ToString());

                            switch (i)
                            {
                                case 0:
                                    materialID = 1;
                                    materialName = "Gravier 0/1";
                                    break;
                                case 1:
                                    materialID = 2;
                                    materialName = "Gravier 0/4";
                                    break;
                                case 2:
                                    materialID = 3;
                                    materialName = "Gravier 0/5";
                                    break;
                                case 3:
                                    materialID = 4;
                                    materialName = "Gravier 5/15";
                                    break;
                                case 4:
                                    materialID = 5;
                                    materialName = "Sable";
                                    break;
                                case 5:
                                    materialID = 6;
                                    materialName = "Cement";
                                    break;

                            }

                            String query2 = "UPDATE Materials Set Weight_Quantity = Weight_Quantity + @Quantity WHERE ID = @ID";
                            SqlCommand cmd2 = new SqlCommand(query2, con);
                            cmd2.Parameters.AddWithValue("@Quantity", z);
                            cmd2.Parameters.AddWithValue("@ID", materialID);
                            cmd2.ExecuteNonQuery();

                            String query3 = "INSERT INTO MaterialsRecords (Description, Amount, Type, DateTime) " +
                                " VALUES (@Description, @Amount, @Type, @DateTime)";
                            SqlCommand cmd3 = new SqlCommand(query3, con);
                            cmd3.Parameters.AddWithValue("@Description", materialName);
                            cmd3.Parameters.AddWithValue("@Amount", z);
                            cmd3.Parameters.AddWithValue("@Type", "+");
                            cmd3.Parameters.AddWithValue("@DateTime", dt);
                            cmd3.ExecuteNonQuery();

                            String query4 = "INSERT INTO NewInvoicesDetails VALUES (@ID, @MaterialID, @Quantity, @Price)";
                            SqlCommand cmd4 = new SqlCommand(query4, con);
                            cmd4.Parameters.AddWithValue("@ID", ID);
                            cmd4.Parameters.AddWithValue("@MaterialID", materialID);
                            cmd4.Parameters.AddWithValue("@Quantity", z);
                            cmd4.Parameters.AddWithValue("@Price", y);
                            cmd4.ExecuteNonQuery();

                        }
                    }

                    MessageBox.Show("Invoice " + ID + " has been added with the following information:"
                        + "\nAmount Paid: " + paid + "\nAmount To Pay: " + toPay + "\nTotal: " + total);
                    resetText();

                }
                catch (Exception msg)
                {
                    MessageBox.Show("An Error has occured! Please make sure everything is correct");
                }
            }
        }

        private void UpdateInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
