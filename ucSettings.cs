using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Construction
{
    public partial class ucSettings : UserControl
    {
        //Connection String of the Application
        SQLiteConnection con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;", true);

        public bool hasBeenCreated = false;
        public ucSettings()
        {
            InitializeComponent();

        }

        //create singleton
        private static ucSettings _instance;
        public static ucSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucSettings();
                return _instance;
            }
        }

        public void backupData()
        {
            string sourceFile = "constructionSQLITE.db";
            string backupFile = "constructionSQLITEBackup.db";

            //copy the source file to the backup file
            File.Copy(sourceFile, backupFile, true);
        }

        public void restoreBackup()
        {
            string databaseFile = "constructionSQLITE.db";
            string backupFile = "constructionSQLITEBackup.db";
            string newBackupFile = "constructionSQLITEBackup.db";
            Homepage.Instance.con.Close();
            Homepage.Instance.con.Dispose();
            con.Close();
            con.Dispose();

            GC.Collect();   // yes, really release the db

            bool worked = false;
            int tries = 1;
            while ((tries < 4) && (!worked))
            {
                try
                {
                    Thread.Sleep(tries * 100);
                    File.Delete(databaseFile);
                    worked = true;
                    MessageBox.Show("The database has been restored ", "Operation Success!");
                }
                catch (IOException e)   // delete only throws this on locking
                {
                    MessageBox.Show(e.ToString());
                    tries++;
                }
            }
            if (!worked)
                throw new IOException("Unable to close file" + databaseFile);

            //rename the backup database file to the original name
            File.Move(backupFile, databaseFile);

            //create a new backup by copying the original backup file
            File.Copy(databaseFile, newBackupFile, overwrite: true);

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            DateTime dt = File.GetLastWriteTime("constructionSQLITEBackup.db");
            DialogResult result = MessageBox.Show("Are you sure you want to restore to the backup database to that of " + dt.ToString() + "? \n", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //user confirmed, perform the restore operation
                restoreBackup();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Parent.Parent.Hide();
            //create the login page
            Login toPage = new Login();
            //show the homepage
            toPage.Show();
        }

        private void btnHomepage_Click(object sender, EventArgs e)
        {
            Homepage.Instance.BringToFront();
            this.Parent.SendToBack();
            this.Parent.Visible = false;
            Homepage.Instance.panelTwo.Controls.Clear();
            Homepage.Instance.loadData();
            /*this.Hide();
            Homepage prod = new Homepage();
            prod.Show();*/

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear the backup database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                con = new SQLiteConnection("Data Source=constructionSQLITE.db;Version=3;New=True;Compress=True;", true);

                if (con.State == ConnectionState.Closed)
                    con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        String query1 = "DELETE FROM Company";
                        String query2 = "DELETE FROM HistoryPaymentInvoices WHERE ID <> 'RFA23-000'";
                        String query3 = "DELETE FROM HistoryPaymentSales WHERE ID <> 'RFD23-000'";
                        String query4 = "DELETE FROM HistorySalesReceipts WHERE ID <> 'VND-000'";
                        String query5 = "UPDATE Materials SET Weight_Quantity = 0";
                        String query6 = "DELETE FROM MaterialsRecords";
                        String query7 = "DELETE FROM MiscPayments";
                        String query8 = "DELETE FROM NewInvoices";
                        String query9 = "DELETE FROM NewInvoicesDetails";
                        String query10 = "DELETE FROM PaymentHistory";
                        String query11 = "UPDATE Prices SET Price = 1.0";
                        String query12 = "DELETE FROM SaleHistory";
                        String query13 = "DELETE FROM Sales";
                        String query14 = "DELETE FROM SalesDetails";
                        String query15 = "DELETE FROM SinglePaymentInvoices WHERE ID <> 'DIP22-000'";
                        String query16 = "DELETE FROM SinglePaymentSales WHERE ID <> 'DIV22-000'";



                        SQLiteCommand cmd = new SQLiteCommand(query1, con);
                        SQLiteCommand cmd2 = new SQLiteCommand(query2, con);
                        SQLiteCommand cmd3 = new SQLiteCommand(query3, con);
                        SQLiteCommand cmd4 = new SQLiteCommand(query4, con);
                        SQLiteCommand cmd5 = new SQLiteCommand(query5, con);
                        SQLiteCommand cmd6 = new SQLiteCommand(query6, con);
                        SQLiteCommand cmd7 = new SQLiteCommand(query7, con);
                        SQLiteCommand cmd8 = new SQLiteCommand(query8, con);
                        SQLiteCommand cmd9 = new SQLiteCommand(query9, con);
                        SQLiteCommand cmd10 = new SQLiteCommand(query10, con);
                        SQLiteCommand cmd11 = new SQLiteCommand(query11, con);
                        SQLiteCommand cmd12 = new SQLiteCommand(query12, con);
                        SQLiteCommand cmd13 = new SQLiteCommand(query13, con);
                        SQLiteCommand cmd14 = new SQLiteCommand(query14, con);
                        SQLiteCommand cmd15 = new SQLiteCommand(query15, con);
                        SQLiteCommand cmd16 = new SQLiteCommand(query16, con);

                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        cmd3.ExecuteNonQuery();
                        cmd4.ExecuteNonQuery();
                        cmd5.ExecuteNonQuery();
                        cmd6.ExecuteNonQuery();
                        cmd7.ExecuteNonQuery();
                        cmd8.ExecuteNonQuery();
                        cmd9.ExecuteNonQuery();
                        cmd10.ExecuteNonQuery();
                        cmd11.ExecuteNonQuery();
                        cmd12.ExecuteNonQuery();
                        cmd13.ExecuteNonQuery();
                        cmd14.ExecuteNonQuery();
                        cmd15.ExecuteNonQuery();
                        cmd16.ExecuteNonQuery();

                        trans.Commit();

                        Homepage.Instance.loadData();

                        MessageBox.Show("The database has been cleared!", "Operation Success!");
                    }
                    catch (Exception msg)
                    {
                        trans.Rollback();
                        MessageBox.Show("An error has occured! Please restart the application", "Error!");
                        return;
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                }


                if (con.State == ConnectionState.Open)
                    con.Close();

            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            bool myBool = false;
            if (btnChangePassword.Text.ToString().Equals("Change"))
            {
                btnChangePassword.Text = "Cancel";
                myBool = true;
            }
            else if (btnChangePassword.Text.ToString().Equals("Cancel"))
            {
                btnChangePassword.Text = "Change";
                myBool = false;
            }
            tbOld.ReadOnly = !myBool;
            tbNew.ReadOnly = !myBool;
            btnConfirm.Enabled = myBool;
            cbShowNew.Enabled = myBool;
            cbShowOld.Enabled = myBool;
        }

        private void cbShowOld_CheckedChanged(object sender, EventArgs e)
        {
            //if the checkbox for show password is not checked, remove the stars
            if (cbShowOld.Checked)
            {
                tbOld.PasswordChar = '\0';
            }
            //if the checkbox for show password is checked, change its text to stars
            else
            {
                tbOld.PasswordChar = '*';
            }
        }

        private void cbShowNew_CheckedChanged(object sender, EventArgs e)
        {
            //if the checkbox for show password is not checked, remove the stars
            if (cbShowNew.Checked)
            {
                tbNew.PasswordChar = '\0';
            }
            //if the checkbox for show password is checked, change its text to stars
            else
            {
                tbNew.PasswordChar = '*';
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            String oldPassword = tbOld.Text.ToString().Trim();
            String newPassword = tbNew.Text.ToString().Trim();
            if(newPassword.Length == 0)
            {
                MessageBox.Show("Please enter a valid password!");
                return;
            }
            // confirm that old password is the same as the current one
            if (!confirmPassword(oldPassword))
            {
                MessageBox.Show("Incorrect Password!");
                return;
            }

            if(updatePassword(newPassword))
            {
                bool myBool = false;
                tbOld.ReadOnly = !myBool;
                tbNew.ReadOnly = !myBool;
                btnConfirm.Enabled = myBool;
                cbShowNew.Enabled = myBool;
                cbShowOld.Enabled = myBool;
                tbOld.Text = "";
                tbNew.Text = "";
                MessageBox.Show("Password Successfully Changed!");
                btnChangePassword.Text = "Change";
            }


        }

        private bool confirmPassword(String oldPassword)
        {

            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {

                //create search query string
                string query = "SELECT * FROM Users WHERE Password = @password";

                //create an object SqlCommand that will take the query and the connection string
                //SqlCommand cmd = new SqlCommand(query, con);
                SQLiteCommand cmd = new SQLiteCommand(query, con);

                //explain what the parameters with @ in the conenction string mean
                cmd.Parameters.AddWithValue("@password", oldPassword);


                //create a data reader that will execute the query
                SQLiteDataReader dr = cmd.ExecuteReader();

                //if the data reader finds the row, do this
                if (dr.Read())
                {
                    return true;
                }


                dr.Close();
                dr.Dispose();

            }
            catch (Exception msg)
            {
                MessageBox.Show("An error has occured! Please try again", "Error!");
            }



            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            return false;
        }

        private bool updatePassword (String newPassword)
        {

            //check if connection is closed, if so open it
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {

                //create search query string\
                string query = "UPDATE Users SET Password = @password WHERE Username = @username;";

                //create an object SqlCommand that will take the query and the connection string
                //SqlCommand cmd = new SqlCommand(query, con);
                SQLiteCommand cmd = new SQLiteCommand(query, con);

                //explain what the parameters with @ in the conenction string mean
                cmd.Parameters.AddWithValue("@password", newPassword);
                cmd.Parameters.AddWithValue("@username", "admin");

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception msg)
            {
                MessageBox.Show("An error has occured! Please try again", "Error!");
            }



            //close the connection if it is still open
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return false;
        }
    }
}
