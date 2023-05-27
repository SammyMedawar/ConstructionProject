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
using System.Linq.Expressions;
using System.Data.SQLite;

namespace Construction
{
    public partial class ucInvoiceAdd : UserControl
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;", true);
        public bool isSearching = false;
        public PlaceholderTextBox[,] tbArray;
        public Label[] labels;
        public double globalDiscount = 0;

        private void loadDataOntoCombo()
        {
            con.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                string query = "SELECT DISTINCT CompanyName FROM PaymentHistory;";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader dr = cmd.ExecuteReader();
                tbCompanyName.Items.Clear();

                //if the data reader finds the row, do this
                while (dr.Read())
                {
                    tbCompanyName.Items.Add(dr.GetString(0));
                }
                dr.Close();
                dr.Dispose();
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
        public ucInvoiceAdd()
        {
            InitializeComponent();
            loadDataOntoCombo();
            tbArray = new PlaceholderTextBox[10, 10];
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
            tbArray[6, 0] = tbM7;
            tbArray[6, 1] = tbM7P;
            tbArray[7, 0] = tbM8;
            tbArray[7, 1] = tbM8P;
            tbArray[8, 0] = tbM9;
            tbArray[8, 1] = tbM9P;
            tbArray[9, 0] = tbM10;
            tbArray[9, 1] = tbM10P;

            labels = new Label[10] { lab0, lab1, lab2, lab3, lab4, lab5, lab6, lab7, lab8, lab9 };
        }

        //create singleton
        private static ucInvoiceAdd _instance;
        public static ucInvoiceAdd Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucInvoiceAdd();
                return _instance;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Parent.SendToBack();
            Invoices.Instance.PanelOne.BringToFront();
            //this.Parent.Parent.Controls.Remove(this.Parent);
            //create the login page
            Login toPage = new Login();
            //show the login page
            toPage.Show();
            //hide the current page
            this.Parent.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //kinda looks like jquery haha
            this.Parent.SendToBack();
            Invoices.Instance.loadAutoCompleteData();
            Invoices.Instance.PanelOne.BringToFront();
        }

        private void btnHomepage_Click(object sender, EventArgs e)
        {
            this.Parent.SendToBack();
            Invoices.Instance.PanelOne.BringToFront();
            //this.Parent.Parent.Controls.Remove(this.Parent);
            //show the homepage
            Homepage.Instance.Show();
            Homepage.Instance.loadData();
            //hide the current page
            this.Parent.Hide();
            Invoices.Instance.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            resetText();
        }
        private void resetText()
        {
            tbDiscount.Text = "0";
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
            tbM7.Text = "";
            tbM7.setPlaceholder();
            tbM7.isPlaceHolder = true;
            tbM7P.Text = "";
            tbM7P.setPlaceholder();
            tbM7P.isPlaceHolder = true;
            tbM8.Text = "";
            tbM8.setPlaceholder();
            tbM8.isPlaceHolder = true;
            tbM8P.Text = "";
            tbM8P.setPlaceholder();
            tbM8P.isPlaceHolder = true;
            tbM9.Text = "";
            tbM9.setPlaceholder();
            tbM9.isPlaceHolder = true;
            tbM9P.Text = "";
            tbM9P.setPlaceholder();
            tbM9P.isPlaceHolder = true;
            tbM10.Text = "";
            tbM10.setPlaceholder();
            tbM10.isPlaceHolder = true;
            tbM10P.Text = "";
            tbM10P.setPlaceholder();
            tbM10P.isPlaceHolder = true;

            tbPrice.Text = "0";
            tbTotal.Text = "0";
            tbID.Text = "";
            tbCompanyName.Text = "";
            dtInvoiceDate.Value = DateTime.Now;
            isSearching = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //check if some textboxes are empty
            if (tbID.Text.ToString().Length == 0 || tbCompanyName.Text.ToString().Length == 0
                || dtInvoiceDate.Text.ToString().Length == 0 || tbPrice.Text.ToString().Length == 0)
            {
                MessageBox.Show("Please make sure all textboxes are filled in!", "Error!");
                return;
            }

            //apostrophes and quotations crash the app
            if (tbCompanyName.Text.ToString().Contains("\"") || tbCompanyName.Text.ToString().Contains("\'"))
            {
                MessageBox.Show("Please note that the Company Name textbox should not contain any apostrophes (\') or quotations (\")!", "Error!");
                return;
            }

            double z = 0, y = 0;

            String ID = tbID.Text.ToString(), companyName = tbCompanyName.Text.ToString();
            DateTime dt1 = new DateTime(dtInvoiceDate.Value.Year, dtInvoiceDate.Value.Month, dtInvoiceDate.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute + 1, DateTime.Now.Second);
            String dt = dt1.ToString("yyyy-MM-dd HH:mm:ss");
            String x = tbM1.Text.ToString();
            double M1 = 0, M1P = 0;
            double M2 = 0, M2P = 0;
            double M3 = 0, M3P = 0;
            double M4 = 0, M4P = 0;
            double M5 = 0, M5P = 0;
            double M6 = 0, M6P = 0;
            double M7 = 0, M7P = 0;
            double M8 = 0, M8P = 0;
            double M9 = 0, M9P = 0;
            double M10 = 0, M10P = 0;
            double total = 0, discount = 0, price = 0;
            //this shoul9d be double.tryparse, inout string error occurs here
            if(con.State == ConnectionState.Closed)
                con.Open();
            try
            {
                if (!string.IsNullOrEmpty(tbM1.Text))
                    Double.TryParse(tbM1.Text, out M1);
                if (!string.IsNullOrEmpty(tbM1P.Text))
                    Double.TryParse(tbM1P.Text, out M1P);

                if (!string.IsNullOrEmpty(tbM2.Text))
                    Double.TryParse(tbM2.Text, out M2);
                if (!string.IsNullOrEmpty(tbM2P.Text))
                    Double.TryParse(tbM2P.Text, out M2P);

                if (!string.IsNullOrEmpty(tbM3.Text))
                    Double.TryParse(tbM3.Text, out M3);
                if (!string.IsNullOrEmpty(tbM3P.Text))
                    Double.TryParse(tbM3P.Text, out M3P);

                if (!string.IsNullOrEmpty(tbM4.Text))
                    Double.TryParse(tbM4.Text, out M4);
                if (!string.IsNullOrEmpty(tbM4P.Text))
                    Double.TryParse(tbM4P.Text, out M4P);

                if (!string.IsNullOrEmpty(tbM5.Text))
                    Double.TryParse(tbM5.Text, out M5);
                if (!string.IsNullOrEmpty(tbM5P.Text))
                    Double.TryParse(tbM5P.Text, out M5P);

                if (!string.IsNullOrEmpty(tbM6.Text))
                    Double.TryParse(tbM6.Text, out M6);
                if (!string.IsNullOrEmpty(tbM6P.Text))
                    Double.TryParse(tbM6P.Text, out M6P);

                if (!string.IsNullOrEmpty(tbM7.Text))
                    Double.TryParse(tbM7.Text, out M7);
                if (!string.IsNullOrEmpty(tbM7P.Text))
                    Double.TryParse(tbM7P.Text, out M7P);

                if (!string.IsNullOrEmpty(tbM8.Text))
                    Double.TryParse(tbM8.Text, out M8);
                if (!string.IsNullOrEmpty(tbM8P.Text))
                    Double.TryParse(tbM8P.Text, out M8P);

                if (!string.IsNullOrEmpty(tbM9.Text))
                    Double.TryParse(tbM9.Text, out M9);
                if (!string.IsNullOrEmpty(tbM9P.Text))
                    Double.TryParse(tbM9P.Text, out M9P);

                if (!string.IsNullOrEmpty(tbM10.Text))
                    Double.TryParse(tbM10.Text, out M10);
                if (!string.IsNullOrEmpty(tbM10P.Text))
                    Double.TryParse(tbM10P.Text, out M10P);

                if (!string.IsNullOrEmpty(tbPrice.Text))
                    Double.TryParse(tbPrice.Text, out price);

                if (!string.IsNullOrEmpty(tbPrice.Text))
                    Double.TryParse(tbPrice.Text, out price);

                if (!string.IsNullOrEmpty(tbDiscount.Text))
                {
                    Double.TryParse(tbDiscount.Text, out discount);

                }

                if (!string.IsNullOrEmpty(tbTotal.Text))
                    Double.TryParse(tbTotal.Text, out total);
                //same here

                //Negative NUmbers are banned, but just in case
                if (M1 < 0 || M1P < 0 || M2 < 0 || M2P < 0 || M3 < 0 || M3P < 0 || M4 < 0 || M4P < 0 || M5 < 0 || M5P < 0 || M6 < 0 || M6P < 0
                    || M7 < 0 || M7P < 0 || M8 < 0 || M8P < 0 || M9 < 0 || M9P < 0 || M10 < 0 || M10P < 0 || discount < 0)
                {
                    MessageBox.Show("Please make sure none of the textboxes have negative numbers in them!", "Error!");
                    con.Close();
                    return;
                }

            }
            catch (Exception msg)
            {
                MessageBox.Show("Please make sure the Materials, Price, and Paid have only numbers in them", "Error!");
                con.Close();
                return;
            }

            bool hasCounted = false;
            //check if connection is closed, if so open it
            con.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            using (var trans = con.BeginTransaction()) {
                try
                {

                    for (int i = 0; i < 10; i++)
                    {
                        //If weight is filled, price should be filled too otherwise give error
                        if ((tbArray[i, 0].Text.ToString().Length != 0 && tbArray[i, 1].Text.ToString().Length == 0) ||
                            (tbArray[i, 0].Text.ToString().Length == 0 && tbArray[i, 1].Text.ToString().Length != 0))
                        {
                            MessageBox.Show("Please sure you have filled in the boxes for " + labels[i].Text + " correctly!", "Error!");
                            trans.Rollback();
                            con.Close();
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
                                MessageBox.Show("Please make sure to fill in the information correctly for " + labels[i].Text, "Error!");
                                trans.Rollback();
                                con.Close();
                                return;
                            }
                        }
                        else
                        {
                            continue;
                        }

                    }

                    if (M1 == 0 && M1P == 0 && M2 == 0 && M2P == 0 && M3 == 0 && M3P == 0 && M4 == 0 && M4P == 0 &&
                        M5 == 0 && M5P == 0 && M6 == 0 && M6P == 0 && M7 == 0 && M7P == 0 && M8 == 0 && M8P == 0 && M9 == 0 && M9P == 0 && M10 == 0
                        && M10P == 0)
                    {
                        MessageBox.Show("Please fill in at least 1 material", "Error!");
                        trans.Rollback();
                        con.Close();
                        return;
                    }

                    //Add invoice
                    
                    String query1 = "INSERT INTO NewInvoices VALUES(@ID, @CompanyName,@DateInv, @Total, @ToPay, @Paid);";
                    SQLiteCommand cmd = new SQLiteCommand(query1, con);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@CompanyName", companyName);
                    cmd.Parameters.AddWithValue("@DateInv", dt);
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@ToPay", total);
                    cmd.Parameters.AddWithValue("@Paid", 0);
                    cmd.ExecuteNonQuery();


                    for (int i = 0; i < 10; i++)
                    {
                        //if field is not empty, that means this field should be inserted
                        //We already made sure that the field next to it has a number (Hopefully!)
                        if (Double.TryParse(tbArray[i, 0].Text.ToString(), out z))
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
                                    materialID = 13;
                                    materialName = "Gravier 0/6";
                                    break;
                                case 4:
                                    materialID = 14;
                                    materialName = "Gravier 0/8";
                                    break;
                                case 5:
                                    materialID = 4;
                                    materialName = "Gravier 5/15";
                                    break;
                                case 6:
                                    materialID = 6;
                                    materialName = "Ciment";
                                    break;
                                case 7:
                                    materialID = 16;
                                    materialName = "Ciment Blanc";
                                    break;
                                case 8:
                                    materialID = 15;
                                    materialName = "Colorant";
                                    break;
                                case 9:
                                    materialID = 5;
                                    materialName = "Sable";
                                    break;

                            }

                            String query2 = "UPDATE Materials Set Weight_Quantity = Weight_Quantity + @Quantity WHERE ID = @ID";
                            SQLiteCommand cmd2 = new SQLiteCommand(query2, con);
                            cmd2.Parameters.AddWithValue("@Quantity", z);
                            cmd2.Parameters.AddWithValue("@ID", materialID);
                            cmd2.ExecuteNonQuery();

                            String query3 = "INSERT INTO MaterialsRecords (Description, Amount, Type, DateTime) " +
                                " VALUES (@Description, @Amount, @Type, @DateTime)";
                            SQLiteCommand cmd3 = new SQLiteCommand(query3, con);
                            cmd3.Parameters.AddWithValue("@Description", materialName);
                            cmd3.Parameters.AddWithValue("@Amount", z);
                            cmd3.Parameters.AddWithValue("@Type", "+");
                            cmd3.Parameters.AddWithValue("@DateTime", dt);
                            cmd3.ExecuteNonQuery();

                            String query4 = "INSERT INTO NewInvoicesDetails VALUES (@ID, @MaterialID, @Quantity, @Price)";
                            SQLiteCommand cmd4 = new SQLiteCommand(query4, con);
                            cmd4.Parameters.AddWithValue("@ID", ID);
                            cmd4.Parameters.AddWithValue("@MaterialID", materialID);
                            cmd4.Parameters.AddWithValue("@Quantity", z);
                            cmd4.Parameters.AddWithValue("@Price", y);
                            cmd4.ExecuteNonQuery();
                        }
                    }

                    


                    //check if company exists in database
                    String query5 = "SELECT * FROM Company WHERE CompanyName = @CompanyName";
                    SQLiteCommand cmd5 = new SQLiteCommand(query5, con);
                    cmd5.Parameters.AddWithValue("@CompanyName", companyName);
                    SQLiteDataReader dr = cmd5.ExecuteReader();
                    if (dr.Read())
                    {
                        //update cumulative owed
                    }
                    else
                    {
                        dr.Close();
                        dr.Dispose();
                        String query6 = "INSERT INTO Company VALUES (@CompanyName, 0, 0)";
                        SQLiteCommand cmd6 = new SQLiteCommand(query6, con);
                        cmd6.Parameters.AddWithValue("@CompanyName", companyName);
                        cmd6.ExecuteNonQuery();
                    }

                    if(!dr.IsClosed)
                        dr.Close();
                    String query7 = "INSERT INTO PaymentHistory (ID, PayDate, ToPay, Paid, CumulativeTotal, CompanyName) VALUES (@ID, @PayDate, @ToPay, @Paid, IFNULL((SELECT CumulativeTotal FROM PaymentHistory WHERE CompanyName like @CompanyName ORDER BY PayDate DESC LIMIT 1), 0) + @Total, @CompanyName)";
                    SQLiteCommand cmd7 = new SQLiteCommand(query7, con);
                    cmd7.Parameters.AddWithValue("@ID", ID);
                    cmd7.Parameters.AddWithValue("@PayDate", dt);
                    cmd7.Parameters.AddWithValue("@ToPay", total);
                    cmd7.Parameters.AddWithValue("@Paid", 0);
                    cmd7.Parameters.AddWithValue("@Total", total);
                    cmd7.Parameters.AddWithValue("@CompanyName", companyName);
                    cmd7.ExecuteNonQuery();

                    string query8 = "UPDATE Company SET CumulativeOwed = (SELECT CumulativeTotal FROM PaymentHistory WHERE CompanyName = @CompanyNames ORDER BY CompanyName DESC LIMIT 1) WHERE CompanyName = @CompanyNames;";
                    SQLiteCommand cmd8 = new SQLiteCommand(query8, con);
                    cmd8.Parameters.AddWithValue("@CompanyNames", companyName);
                    cmd8.ExecuteNonQuery();

                    trans.Commit();

                    loadDataOntoCombo();
                    Invoices.Instance.loadAutoCompleteData();
                    ucInvoicePayment.Instance.loadData();
                    ucInvoicePayment.Instance.loadDataOntoCombo();

                    MessageBox.Show("Invoice of ID " + ID + " has been added with the following information:"
                        + "\nTotal: " + total + "\nBuyer Name: " + companyName);
                    resetText();


                    con.Close();

                    Form parentForm = this.ParentForm;
                    //check if the parent form is not null and is of the correct type
                    if (parentForm != null && parentForm is Invoices)
                    {
                        //caast the parent form to the correct type
                        Invoices myParentForm = (Invoices)parentForm;

                        //call the public method on the parent form
                        myParentForm.loadData();
                    }

                }
                catch (Exception msg)
                {
                    MessageBox.Show("An Error has occured! Please make sure everything is correct", "Error!");
                    trans.Rollback();
                    con.Close();
                    return;
                }
            }

            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

        }
        private void tbM1P_Leave(object sender, EventArgs e)
        {

            calculateTotal();

        }

        private void tbDiscount_Leave(object sender, EventArgs e)
        {

            calculateTotal();
        }

        private void calculateTotal()
        {
            double total = 0, number = 0;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    if (tbArray[i, 1].Text.Length != 0)
                    {
                        if (double.TryParse(tbArray[i, 1].Text.ToString(), out number))
                        {
                            total = total + number;
                        }
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show("You're not supposed to see this");
                }
            }
            tbPrice.Text = total.ToString();

            if (tbDiscount.Text.ToString().Length != 0)
            {
                globalDiscount = 0;
                String mystr = tbDiscount.Text.ToString();
                double tempDiscount = 0, tempPrice = 0;
                if (mystr.EndsWith("%"))
                {
                    mystr = mystr.TrimEnd('%');
                    if (double.TryParse(mystr, out tempDiscount))
                    {
                        if(tempDiscount > 100)
                        {
                            MessageBox.Show("Please change the discount, it cannot be over 100%!");
                            tbDiscount.Text = "0";
                            tbTotal.Text = tbPrice.Text;
                        }
                        tempDiscount = tempDiscount / 100;
                        globalDiscount = tempDiscount;
                        if (double.TryParse(tbPrice.Text.ToString(), out tempPrice))
                        {
                            tbTotal.Text = (tempPrice - (globalDiscount * tempPrice)).ToString();
                        }
                    }

                }
                else if (mystr.StartsWith("%"))
                {
                    mystr = mystr.TrimStart('%');
                    if (double.TryParse(mystr, out tempDiscount))
                    {
                        if (tempDiscount > 100)
                        {
                            MessageBox.Show("Please change the discount, it cannot be over 100%!");
                            tbDiscount.Text = "0";
                            tbTotal.Text = tbPrice.Text;
                        }
                        tempDiscount = tempDiscount / 100;
                        globalDiscount = tempDiscount;
                        if (double.TryParse(tbPrice.Text.ToString(), out tempPrice))
                        {
                            tbTotal.Text = (tempPrice - (globalDiscount * tempPrice)).ToString();
                        }
                    }
                }
                else if (double.TryParse(mystr, out tempDiscount))
                {
                    globalDiscount = tempDiscount;
                    if (double.TryParse(tbPrice.Text.ToString(), out tempPrice))
                    {
                        if(tempPrice < tempDiscount)
                        {
                            MessageBox.Show("Please change the discount, it cannot be higher than the price!");
                            tbDiscount.Text = "0";
                            tbTotal.Text = tbPrice.Text;
                        }
                        else
                            tbTotal.Text = (tempPrice - globalDiscount).ToString();
                    }
                }
            }
            else
            {
                tbDiscount.Text = "0";
            }

        }

        private void tbM2P_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '%'))
            {
                e.Handled = true;
            }

            //only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            PlaceholderTextBox x;
            try
            {
                x = (PlaceholderTextBox)sender;
                if ((e.KeyChar == '%'))
                {
                    e.Handled = true;
                }
            }
            catch(Exception msg)
            {
                if ((e.KeyChar == '%') && ((sender as TextBox).Text.IndexOf('%') > -1))
                {
                    e.Handled = true;
                }
            }

        }

        private void tbCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'' || e.KeyChar == '\"')
            {
                e.Handled = true;
            }
        }

        private void tbDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void tbM2P_TextChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void tbCompanyName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\"' || e.KeyChar == '\'')
            {
                e.Handled = true;
            }
        }
    }
}
