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
using System.Data.SQLite;

namespace Construction
{
    public partial class ucSalesAdd : UserControl
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;", true);
        public bool isSearching = false;
        public PlaceholderTextBox[,] tbArray;
        public Label[] labels;
        public double globalDiscount = 0;
        public double[] priceArray;

        public String generateID()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            //Get latest number and year from records
            String lastID = "";
            String query = "SELECT ID FROM HistorySalesReceipts ORDER BY DateAdd DESC Limit 1";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lastID = dr.GetString(0);
            }
            dr.Close();
            dr.Dispose();
            String lastIDNumber = lastID.Substring(6);
            int currentYearInt = DateTime.Now.Year;
            String currentYear = currentYearInt.ToString();
            currentYear = currentYear.Substring(2);
            int newestIDNumberInt = Int32.Parse(lastIDNumber) + 1;
            String newestIDNumber = newestIDNumberInt.ToString("D3");
            String newestID = "VND" + currentYear + "-" + newestIDNumber;

            if (con.State == ConnectionState.Open)
                con.Close();

            return newestID;
        }

        private void loadDataOntoCombo()
        {
            con.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                string query = "SELECT DISTINCT CompanyName FROM SaleHistory;";
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
                MessageBox.Show("Oops! An error has occured. Please restart the application", "Error!");
            }

            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public ucSalesAdd()
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
            priceArray = new double[10];
            loadData();
        }

        public void loadData()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            String query = "SELECT Price from Prices";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            SQLiteDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                priceArray[i] = dr.GetFloat(0);
                i++;
            }

            if (con.State == ConnectionState.Open)
                con.Close();
        }

        //create singleton
        private static ucSalesAdd _instance;
        public static ucSalesAdd Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucSalesAdd();
                return _instance;
            }
        }

        private void ucSalesAdd_Load(object sender, EventArgs e)
        {
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Parent.SendToBack();
            Sales.Instance.PanelOne.BringToFront();
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
            Sales.Instance.loadAutoCompleteData();
            Sales.Instance.PanelOne.BringToFront();
        }

        private void btnHomepage_Click(object sender, EventArgs e)
        {
            this.Parent.SendToBack();
            Sales.Instance.PanelOne.BringToFront();
            //show the homepage
            Homepage.Instance.Show();
            Homepage.Instance.loadData();
            //hide the current page
            this.Parent.Hide();
            Sales.Instance.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetText();
        }

        private void resetText()
        {
            tbDiscount.Text = "0";
            btnAdd.Text = "Add";
            //reset text of all placeholders
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
            tbCompanyName.Text = "";
            dtInvoiceDate.Value = DateTime.Now;
            isSearching = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //check if some textboxes are empty
            if (tbCompanyName.Text.ToString().Length == 0
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

            
            String companyName = tbCompanyName.Text.ToString();
            DateTime dt1 = dtInvoiceDate.Value;
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

            String ID = generateID();

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            using (var trans = con.BeginTransaction())
            {
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


                    //check if selling anything leads to a negative stock
                    for (int i = 1; i <= 20; i++)
                    {
                        if (i >= 1 && i <= 6)
                            continue;
                        if (i >= 13 && i <= 16)
                            continue;
                        String queryCheck = "SELECT WEIGHT_QUANTITY FROM MATERIALS where ID = " + i.ToString();
                        SQLiteCommand cmdCheck = new SQLiteCommand(queryCheck, con);
                        SQLiteDataReader drCheck = cmdCheck.ExecuteReader();
                        double temp = 0;
                        if (drCheck.Read())
                        {
                            temp = drCheck.GetFloat(0);
                        }
                        drCheck.Close();
                        drCheck.Dispose();
                        double tempM = 0;
                        String tempString = "";
                        if (i == 7)
                        {
                            tempM = M1;
                            tempString = lab0.Text;
                        }
                        if (i == 8)
                        {
                            tempM = M2;
                            tempString = lab1.Text;
                        }
                        if (i == 9)
                        {
                            tempM = M3;
                            tempString = lab2.Text;
                        }
                        if (i == 17)
                        {
                            tempM = M4;
                            tempString = lab3.Text;
                        }
                        if (i == 18)
                        {
                            tempM = M5;
                            tempString = lab4.Text;
                        }
                        if (i == 19)
                        {
                            tempM = M6;
                            tempString = lab5.Text;
                        }
                        if (i == 20)
                        {
                            tempM = M7;
                            tempString = lab6.Text;
                        }
                        if (i == 10)
                        {
                            tempString = lab7.Text;
                            tempM = M8;
                        }
                        if (i == 11)
                        {
                            tempM = M9;
                            tempString = lab8.Text;
                        }
                        if (i == 12)
                        {
                            tempM = M10;
                            tempString = lab9.Text;
                        }

                        if (temp - tempM < 0)
                        {
                            MessageBox.Show("There is not enough " + tempString + " to sell! We only have " + temp + " to sell", "Error!");
                            trans.Rollback();
                            con.Close();
                            return;
                        }

                    }
                    
                    //Add invoice
                    String query1 = "INSERT INTO Sales VALUES(@ID, @CompanyName,@DateSale, @Total, @ToPay, @Paid);";
                    SQLiteCommand cmd = new SQLiteCommand(query1, con);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@CompanyName", companyName);
                    cmd.Parameters.AddWithValue("@DateSale", dt);
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
                                    materialID = 7;
                                    materialName = "Creux 10CM";
                                    break;
                                case 1:
                                    materialID = 8;
                                    materialName = "Creux 15CM";
                                    break;
                                case 2:
                                    materialID = 9;
                                    materialName = "Creux 20CM";
                                    break;
                                case 3:
                                    materialID = 17;
                                    materialName = "Pavé 6CM";
                                    break;
                                case 4:
                                    materialID = 18;
                                    materialName = "Pavé 8CM";
                                    break;
                                case 5:
                                    materialID = 19;
                                    materialName = "Pavé 10CM";
                                    break;
                                case 6:
                                    materialID = 20;
                                    materialName = "Pavé 13CM";
                                    break;
                                case 7:
                                    materialID = 10;
                                    materialName = "Pleinne 10CM";
                                    break;
                                case 8:
                                    materialID = 11;
                                    materialName = "Pleinne 15CM";
                                    break;
                                case 9:
                                    materialID = 12;
                                    materialName = "Pleinne 20CM";
                                    break;

                            }

                            String query2 = "UPDATE Materials Set Weight_Quantity = Weight_Quantity - @Quantity WHERE ID = @ID";
                            SQLiteCommand cmd2 = new SQLiteCommand(query2, con);
                            cmd2.Parameters.AddWithValue("@Quantity", z);
                            cmd2.Parameters.AddWithValue("@ID", materialID);
                            cmd2.ExecuteNonQuery();

                            String query3 = "INSERT INTO MaterialsRecords (Description, Amount, Type, DateTime) " +
                                " VALUES (@Description, @Amount, @Type, @DateTime)";
                            SQLiteCommand cmd3 = new SQLiteCommand(query3, con);
                            cmd3.Parameters.AddWithValue("@Description", materialName);
                            cmd3.Parameters.AddWithValue("@Amount", z);
                            cmd3.Parameters.AddWithValue("@Type", "-");
                            cmd3.Parameters.AddWithValue("@DateTime", dt);
                            cmd3.ExecuteNonQuery();

                            String query4 = "INSERT INTO SalesDetails VALUES (@ID, @MaterialID, @Quantity, @Price)";
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
                        String query6 = "INSERT INTO Company VALUES (@CompanyName, 0, 0)";
                        SQLiteCommand cmd6 = new SQLiteCommand(query6, con);
                        cmd6.Parameters.AddWithValue("@CompanyName", companyName);
                        cmd6.ExecuteNonQuery();
                    }
                    dr.Close();
                    dr.Dispose();
                    String query7 = "INSERT INTO SaleHistory (ID, PayDate, ToPay, Paid, CumulativeTotal, CompanyName) VALUES (@ID, @PayDate, @ToPay, @Paid, IFNULL((SELECT CumulativeTotal FROM SaleHistory WHERE CompanyName like @CompanyName ORDER BY PayDate DESC LIMIT 1), 0) + @Total, @CompanyName)";
                    SQLiteCommand cmd7 = new SQLiteCommand(query7, con);
                    cmd7.Parameters.AddWithValue("@ID", ID);
                    cmd7.Parameters.AddWithValue("@PayDate", dt);
                    cmd7.Parameters.AddWithValue("@ToPay", total);
                    cmd7.Parameters.AddWithValue("@Paid", 0);
                    cmd7.Parameters.AddWithValue("@Total", total);
                    cmd7.Parameters.AddWithValue("@CompanyName", companyName);
                    cmd7.ExecuteNonQuery();

                    string query8 = "UPDATE Company SET CumulativeOwedToUs = (SELECT CumulativeTotal FROM SaleHistory WHERE CompanyName = @CompanyNames ORDER BY CompanyName DESC LIMIT 1) WHERE CompanyName = @CompanyNames;";
                    SQLiteCommand cmd8 = new SQLiteCommand(query8, con);
                    cmd8.Parameters.AddWithValue("@CompanyNames", companyName);
                    cmd8.ExecuteNonQuery();

                    String query9 = "INSERT INTO HistorySalesReceipts VALUES (@ID, @CompanyName, @DateAdd)";
                    SQLiteCommand cmd9 = new SQLiteCommand(query9, con);
                    cmd9.Parameters.AddWithValue("@ID", ID);
                    cmd9.Parameters.AddWithValue("@CompanyName", companyName);
                    cmd9.Parameters.AddWithValue("@DateAdd", DateTime.Now);
                    cmd9.ExecuteNonQuery();

                    trans.Commit();
                    loadDataOntoCombo();
                    Sales.Instance.loadAutoCompleteData();
                    ucSalesPayment.Instance.loadData();
                    ucSalesPayment.Instance.loadDataOntoCombo();

                    MessageBox.Show("Sale of ID " + ID + " has been added with the following information:"
                        + "\nTotal: " + total + "\nBuyer Name: " + companyName, "Operation Successful");
                    resetText();

                    con.Close();

                    Form parentForm = this.ParentForm;
                    //check if the parent form is not null and is of the correct type
                    if (parentForm != null && parentForm is Sales)
                    {
                        //caast the parent form to the correct type
                        Sales myParentForm = (Sales)parentForm;

                        //call the public method on the parent form
                        myParentForm.loadData();
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show("An Error has occured! Please make sure everything is correct", "Error!");
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
                    MessageBox.Show("You're not supposed to see this", "Error!");
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
                        if (tempDiscount > 100)
                        {
                            MessageBox.Show("Please change the discount, it cannot be over 100%!", "Error!");
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
                            MessageBox.Show("Please change the discount, it cannot be over 100%!", "Error!");
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
                        if (tempPrice < tempDiscount)
                        {
                            MessageBox.Show("Please change the discount, it cannot be higher than the price!", "Error!");
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

        private void tbM1_KeyPress(object sender, KeyPressEventArgs e)
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
            catch (Exception msg)
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

        private void tbDiscount_TextChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void tbM1P_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void tbM1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbM1.Text.Trim()))
            {
                tbM1P.Text = "";
                tbM1P.setPlaceholder();
                tbM1P.isPlaceHolder = true;
            }
            else
            {
                double price = priceArray[0];
                if (double.TryParse(tbM1.Text, out double quantity))
                {
                    tbM1P.removePlaceHolder();
                    double totalPrice = price * quantity;
                    tbM1P.Text = totalPrice.ToString();
                }
                else
                {
                    // Handle invalid input in tbM1
                    tbM1P.Text = "";
                    tbM1P.setPlaceholder();
                    tbM1P.isPlaceHolder = true;
                }
            }
        }

        private void tbM2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbM2.Text.Trim()))
            {
                tbM2P.Text = "";
                tbM2P.setPlaceholder();
                tbM2P.isPlaceHolder = true;
            }
            else
            {
                double price = priceArray[1];
                if (double.TryParse(tbM2.Text, out double quantity))
                {
                    tbM2P.removePlaceHolder();
                    double totalPrice = price * quantity;
                    tbM2P.Text = totalPrice.ToString();
                }
                else
                {
                    // Handle invalid input in tbM1
                    tbM2P.Text = "";
                    tbM2P.setPlaceholder();
                    tbM2P.isPlaceHolder = true;
                }
            }
        }

        private void tbM3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbM3.Text.Trim()))
            {
                tbM3P.Text = "";
                tbM3P.setPlaceholder();
                tbM3P.isPlaceHolder = true;
            }
            else
            {
                double price = priceArray[2];
                if (double.TryParse(tbM3.Text, out double quantity))
                {
                    tbM3P.removePlaceHolder();
                    double totalPrice = price * quantity;
                    tbM3P.Text = totalPrice.ToString();
                }
                else
                {
                    // Handle invalid input in tbM1
                    tbM3P.Text = "";
                    tbM3P.setPlaceholder();
                    tbM3P.isPlaceHolder = true;
                }
            }
        }

        private void tbM8_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbM8.Text.Trim()))
            {
                tbM8P.Text = "";
                tbM8P.setPlaceholder();
                tbM8P.isPlaceHolder = true;
            }
            else
            {
                double price = priceArray[3];
                if (double.TryParse(tbM8.Text, out double quantity))
                {
                    tbM8P.removePlaceHolder();
                    double totalPrice = price * quantity;
                    tbM8P.Text = totalPrice.ToString();
                }
                else
                {
                    // Handle invalid input in tbM1
                    tbM8P.Text = "";
                    tbM8P.setPlaceholder();
                    tbM8P.isPlaceHolder = true;
                }
            }
        }

        private void tbM9_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbM9.Text.Trim()))
            {
                tbM9P.Text = "";
                tbM9P.setPlaceholder();
                tbM9P.isPlaceHolder = true;
            }
            else
            {
                double price = priceArray[4];
                if (double.TryParse(tbM9.Text, out double quantity))
                {
                    tbM9P.removePlaceHolder();
                    double totalPrice = price * quantity;
                    tbM9P.Text = totalPrice.ToString();
                }
                else
                {
                    // Handle invalid input in tbM1
                    tbM9P.Text = "";
                    tbM9P.setPlaceholder();
                    tbM9P.isPlaceHolder = true;
                }
            }
        }

        private void tbM10_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbM10.Text.Trim()))
            {
                tbM10P.Text = "";
                tbM10P.setPlaceholder();
                tbM10P.isPlaceHolder = true;
            }
            else
            {
                double price = priceArray[5];
                if (double.TryParse(tbM10.Text, out double quantity))
                {
                    tbM10P.removePlaceHolder();
                    double totalPrice = price * quantity;
                    tbM10P.Text = totalPrice.ToString();
                }
                else
                {
                    // Handle invalid input in tbM1
                    tbM10P.Text = "";
                    tbM10P.setPlaceholder();
                    tbM10P.isPlaceHolder = true;
                }
            }
        }

        private void tbM4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbM4.Text.Trim()))
            {
                tbM4P.Text = "";
                tbM4P.setPlaceholder();
                tbM4P.isPlaceHolder = true;
            }
            else
            {
                double price = priceArray[6];
                if (double.TryParse(tbM4.Text, out double quantity))
                {
                    tbM4P.removePlaceHolder();
                    double totalPrice = price * quantity;
                    tbM4P.Text = totalPrice.ToString();
                }
                else
                {
                    // Handle invalid input in tbM1
                    tbM4P.Text = "";
                    tbM4P.setPlaceholder();
                    tbM4P.isPlaceHolder = true;
                }
            }
        }

        private void tbM5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbM5.Text.Trim()))
            {
                tbM5P.Text = "";
                tbM5P.setPlaceholder();
                tbM5P.isPlaceHolder = true;
            }
            else
            {
                double price = priceArray[7];
                if (double.TryParse(tbM5.Text, out double quantity))
                {
                    tbM5P.removePlaceHolder();
                    double totalPrice = price * quantity;
                    tbM5P.Text = totalPrice.ToString();
                }
                else
                {
                    // Handle invalid input in tbM1
                    tbM5P.Text = "";
                    tbM5P.setPlaceholder();
                    tbM5P.isPlaceHolder = true;
                }
            }
        }

        private void tbM6_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbM6.Text.Trim()))
            {
                tbM6P.Text = "";
                tbM6P.setPlaceholder();
                tbM6P.isPlaceHolder = true;
            }
            else
            {
                double price = priceArray[8];
                if (double.TryParse(tbM6.Text, out double quantity)) { 
                
                    tbM6P.removePlaceHolder();
                    double totalPrice = price * quantity;
                    tbM6P.Text = totalPrice.ToString();
                }
                else
                {
                    // Handle invalid input in tbM1
                    tbM6P.Text = "";
                    tbM6P.setPlaceholder();
                    tbM6P.isPlaceHolder = true;
                }
            }
        }

        private void tbM7_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbM7.Text.Trim()))
            {
                tbM7P.Text = "";
                tbM7P.setPlaceholder();
                tbM7P.isPlaceHolder = true;
            }
            else
            {
                double price = priceArray[9];
                if (double.TryParse(tbM7.Text, out double quantity))
                {

                    tbM7P.removePlaceHolder();
                    double totalPrice = price * quantity;
                    tbM7P.Text = totalPrice.ToString();
                }
                else
                {
                    // Handle invalid input in tbM1
                    tbM7P.Text = "";
                    tbM7P.setPlaceholder();
                    tbM7P.isPlaceHolder = true;
                }
            }
        }
    }
}
