namespace Construction
{
    partial class Invoices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Invoices));
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCompanyName = new System.Windows.Forms.TextBox();
            this.dtInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPaid = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnHomepage = new System.Windows.Forms.Button();
            this.btnIDSearch = new System.Windows.Forms.Button();
            this.Limit = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtPickerTo = new System.Windows.Forms.DateTimePicker();
            this.dtPickerFrom = new System.Windows.Forms.DateTimePicker();
            this.tbPaymentLimit = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioPaid = new System.Windows.Forms.RadioButton();
            this.radioNotPaid = new System.Windows.Forms.RadioButton();
            this.tbSearch = new Construction.PlaceholderTextBox();
            this.tbM2Amount = new Construction.PlaceholderTextBox();
            this.tbM3Price = new Construction.PlaceholderTextBox();
            this.tbM3Weight = new Construction.PlaceholderTextBox();
            this.tbM2Price = new Construction.PlaceholderTextBox();
            this.tbM1Price = new Construction.PlaceholderTextBox();
            this.tbM1Weight = new Construction.PlaceholderTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoices.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Location = new System.Drawing.Point(423, 93);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.RowHeadersVisible = false;
            this.dgvInvoices.Size = new System.Drawing.Size(829, 428);
            this.dgvInvoices.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(158, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Invoices";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "ID";
            // 
            // tbID
            // 
            this.tbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbID.Location = new System.Drawing.Point(161, 47);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(142, 26);
            this.tbID.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Company Name";
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCompanyName.Location = new System.Drawing.Point(161, 97);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(166, 26);
            this.tbCompanyName.TabIndex = 38;
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInvoiceDate.Location = new System.Drawing.Point(161, 144);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Size = new System.Drawing.Size(166, 20);
            this.dtInvoiceDate.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "Material 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "Material 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 48;
            this.label7.Text = "Material 3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 330);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 53;
            this.label8.Text = "Price";
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrice.Location = new System.Drawing.Point(161, 327);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(166, 26);
            this.tbPrice.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 377);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 20);
            this.label9.TabIndex = 55;
            this.label9.Text = "Paid";
            // 
            // tbPaid
            // 
            this.tbPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPaid.Location = new System.Drawing.Point(161, 374);
            this.tbPaid.Name = "tbPaid";
            this.tbPaid.Size = new System.Drawing.Size(166, 26);
            this.tbPaid.TabIndex = 54;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(15, 424);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(312, 37);
            this.btnAdd.TabIndex = 56;
            this.btnAdd.Text = "Update";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(12, 477);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(111, 65);
            this.btnLogout.TabIndex = 58;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnHomepage
            // 
            this.btnHomepage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomepage.Location = new System.Drawing.Point(133, 477);
            this.btnHomepage.Name = "btnHomepage";
            this.btnHomepage.Size = new System.Drawing.Size(128, 65);
            this.btnHomepage.TabIndex = 57;
            this.btnHomepage.Text = "Homepage";
            this.btnHomepage.UseVisualStyleBackColor = true;
            this.btnHomepage.Click += new System.EventHandler(this.btnHomepage_Click);
            // 
            // btnIDSearch
            // 
            this.btnIDSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIDSearch.BackgroundImage")));
            this.btnIDSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIDSearch.Location = new System.Drawing.Point(300, 46);
            this.btnIDSearch.Name = "btnIDSearch";
            this.btnIDSearch.Size = new System.Drawing.Size(27, 27);
            this.btnIDSearch.TabIndex = 59;
            this.btnIDSearch.UseVisualStyleBackColor = true;
            this.btnIDSearch.Click += new System.EventHandler(this.btnIDSearch_Click);
            // 
            // Limit
            // 
            this.Limit.AutoSize = true;
            this.Limit.Location = new System.Drawing.Point(420, 71);
            this.Limit.Name = "Limit";
            this.Limit.Size = new System.Drawing.Size(28, 13);
            this.Limit.TabIndex = 64;
            this.Limit.Text = "Limit";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(740, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "To";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(498, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 62;
            this.label11.Text = "From";
            // 
            // dtPickerTo
            // 
            this.dtPickerTo.Location = new System.Drawing.Point(764, 67);
            this.dtPickerTo.Name = "dtPickerTo";
            this.dtPickerTo.Size = new System.Drawing.Size(200, 20);
            this.dtPickerTo.TabIndex = 61;
            this.dtPickerTo.CloseUp += new System.EventHandler(this.dtPickerTo_CloseUp);
            // 
            // dtPickerFrom
            // 
            this.dtPickerFrom.Location = new System.Drawing.Point(534, 67);
            this.dtPickerFrom.Name = "dtPickerFrom";
            this.dtPickerFrom.Size = new System.Drawing.Size(200, 20);
            this.dtPickerFrom.TabIndex = 60;
            this.dtPickerFrom.Value = new System.DateTime(2023, 5, 1, 0, 0, 0, 0);
            this.dtPickerFrom.CloseUp += new System.EventHandler(this.dtPickerFrom_CloseUp);
            // 
            // tbPaymentLimit
            // 
            this.tbPaymentLimit.Location = new System.Drawing.Point(454, 67);
            this.tbPaymentLimit.Name = "tbPaymentLimit";
            this.tbPaymentLimit.Size = new System.Drawing.Size(29, 20);
            this.tbPaymentLimit.TabIndex = 65;
            this.tbPaymentLimit.Text = "25";
            this.tbPaymentLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPaymentLimit_KeyDown_1);
            this.tbPaymentLimit.Leave += new System.EventHandler(this.tbPaymentLimit_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(649, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(27, 27);
            this.btnSearch.TabIndex = 67;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReload.BackgroundImage")));
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Location = new System.Drawing.Point(675, 25);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(27, 27);
            this.btnReload.TabIndex = 68;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Location = new System.Drawing.Point(979, 69);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(36, 17);
            this.radioAll.TabIndex = 69;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.Click += new System.EventHandler(this.radioAll_Click);
            // 
            // radioPaid
            // 
            this.radioPaid.AutoSize = true;
            this.radioPaid.Location = new System.Drawing.Point(1021, 69);
            this.radioPaid.Name = "radioPaid";
            this.radioPaid.Size = new System.Drawing.Size(46, 17);
            this.radioPaid.TabIndex = 70;
            this.radioPaid.Text = "Paid";
            this.radioPaid.UseVisualStyleBackColor = true;
            this.radioPaid.Click += new System.EventHandler(this.radioPaid_Click);
            // 
            // radioNotPaid
            // 
            this.radioNotPaid.AutoSize = true;
            this.radioNotPaid.Location = new System.Drawing.Point(1073, 70);
            this.radioNotPaid.Name = "radioNotPaid";
            this.radioNotPaid.Size = new System.Drawing.Size(66, 17);
            this.radioNotPaid.TabIndex = 71;
            this.radioNotPaid.Text = "Not Paid";
            this.radioNotPaid.UseVisualStyleBackColor = true;
            this.radioNotPaid.Click += new System.EventHandler(this.radioNotPaid_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbSearch.ForeColor = System.Drawing.Color.Gray;
            this.tbSearch.Location = new System.Drawing.Point(423, 25);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PlaceHolderText = "Search Company...";
            this.tbSearch.Size = new System.Drawing.Size(227, 26);
            this.tbSearch.TabIndex = 66;
            this.tbSearch.Text = "Search Company...";
            // 
            // tbM2Amount
            // 
            this.tbM2Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM2Amount.ForeColor = System.Drawing.Color.Gray;
            this.tbM2Amount.Location = new System.Drawing.Point(161, 233);
            this.tbM2Amount.Name = "tbM2Amount";
            this.tbM2Amount.PlaceHolderText = "Weight";
            this.tbM2Amount.Size = new System.Drawing.Size(80, 26);
            this.tbM2Amount.TabIndex = 51;
            this.tbM2Amount.Text = "Weight";
            // 
            // tbM3Price
            // 
            this.tbM3Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM3Price.ForeColor = System.Drawing.Color.Gray;
            this.tbM3Price.Location = new System.Drawing.Point(247, 281);
            this.tbM3Price.Name = "tbM3Price";
            this.tbM3Price.PlaceHolderText = "Price";
            this.tbM3Price.Size = new System.Drawing.Size(80, 26);
            this.tbM3Price.TabIndex = 50;
            this.tbM3Price.Text = "Price";
            // 
            // tbM3Weight
            // 
            this.tbM3Weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM3Weight.ForeColor = System.Drawing.Color.Gray;
            this.tbM3Weight.Location = new System.Drawing.Point(161, 281);
            this.tbM3Weight.Name = "tbM3Weight";
            this.tbM3Weight.PlaceHolderText = "Weight";
            this.tbM3Weight.Size = new System.Drawing.Size(80, 26);
            this.tbM3Weight.TabIndex = 49;
            this.tbM3Weight.Text = "Weight";
            // 
            // tbM2Price
            // 
            this.tbM2Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM2Price.ForeColor = System.Drawing.Color.Gray;
            this.tbM2Price.Location = new System.Drawing.Point(247, 233);
            this.tbM2Price.Name = "tbM2Price";
            this.tbM2Price.PlaceHolderText = "Price";
            this.tbM2Price.Size = new System.Drawing.Size(80, 26);
            this.tbM2Price.TabIndex = 47;
            this.tbM2Price.Text = "Price";
            // 
            // tbM1Price
            // 
            this.tbM1Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM1Price.ForeColor = System.Drawing.Color.Gray;
            this.tbM1Price.Location = new System.Drawing.Point(247, 186);
            this.tbM1Price.Name = "tbM1Price";
            this.tbM1Price.PlaceHolderText = "Price";
            this.tbM1Price.Size = new System.Drawing.Size(80, 26);
            this.tbM1Price.TabIndex = 44;
            this.tbM1Price.Text = "Price";
            // 
            // tbM1Weight
            // 
            this.tbM1Weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM1Weight.ForeColor = System.Drawing.Color.Gray;
            this.tbM1Weight.Location = new System.Drawing.Point(161, 186);
            this.tbM1Weight.Name = "tbM1Weight";
            this.tbM1Weight.PlaceHolderText = "Weight";
            this.tbM1Weight.Size = new System.Drawing.Size(80, 26);
            this.tbM1Weight.TabIndex = 43;
            this.tbM1Weight.Text = "Weight";
            // 
            // Invoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 554);
            this.Controls.Add(this.radioNotPaid);
            this.Controls.Add(this.radioPaid);
            this.Controls.Add(this.radioAll);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.tbPaymentLimit);
            this.Controls.Add(this.Limit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtPickerTo);
            this.Controls.Add(this.dtPickerFrom);
            this.Controls.Add(this.btnIDSearch);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnHomepage);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbPaid);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbM2Amount);
            this.Controls.Add(this.tbM3Price);
            this.Controls.Add(this.tbM3Weight);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbM2Price);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbM1Price);
            this.Controls.Add(this.tbM1Weight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtInvoiceDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCompanyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvInvoices);
            this.Name = "Invoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoices";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCompanyName;
        private System.Windows.Forms.DateTimePicker dtInvoiceDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private PlaceholderTextBox tbM1Weight;
        private PlaceholderTextBox tbM1Price;
        private PlaceholderTextBox tbM2Price;
        private System.Windows.Forms.Label label6;
        private PlaceholderTextBox tbM3Price;
        private PlaceholderTextBox tbM3Weight;
        private System.Windows.Forms.Label label7;
        private PlaceholderTextBox tbM2Amount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbPaid;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnHomepage;
        private System.Windows.Forms.Button btnIDSearch;
        private System.Windows.Forms.Label Limit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtPickerTo;
        private System.Windows.Forms.DateTimePicker dtPickerFrom;
        private System.Windows.Forms.TextBox tbPaymentLimit;
        private PlaceholderTextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioPaid;
        private System.Windows.Forms.RadioButton radioNotPaid;
    }
}