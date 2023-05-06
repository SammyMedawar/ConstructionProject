namespace Construction
{
    partial class NewInvoices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewInvoices));
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.dgvInvoicesDetails = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.radioGroupSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.radioCompany = new System.Windows.Forms.RadioButton();
            this.radioID = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtPickerTo = new System.Windows.Forms.DateTimePicker();
            this.dtPickerFrom = new System.Windows.Forms.DateTimePicker();
            this.radioGroupMoney = new System.Windows.Forms.FlowLayoutPanel();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioPaid = new System.Windows.Forms.RadioButton();
            this.radioNotPaid = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelPaid = new System.Windows.Forms.Label();
            this.labelToPay = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLimitInvoice = new System.Windows.Forms.TextBox();
            this.labelidk = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLimitInvoiceDetails = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnHomepage = new System.Windows.Forms.Button();
            this.tbSearch = new Construction.PlaceholderTextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicesDetails)).BeginInit();
            this.radioGroupSearch.SuspendLayout();
            this.radioGroupMoney.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.AllowUserToAddRows = false;
            this.dgvInvoices.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.dgvInvoices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInvoices.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoices.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvInvoices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInvoices.Location = new System.Drawing.Point(509, 61);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.ReadOnly = true;
            this.dgvInvoices.RowHeadersVisible = false;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoices.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvInvoices.Size = new System.Drawing.Size(749, 193);
            this.dgvInvoices.TabIndex = 18;
            this.dgvInvoices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoices_CellDoubleClick);
            this.dgvInvoices.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvInvoices_DataBindingComplete);
            // 
            // dgvInvoicesDetails
            // 
            this.dgvInvoicesDetails.AllowUserToAddRows = false;
            this.dgvInvoicesDetails.AllowUserToDeleteRows = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            this.dgvInvoicesDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvInvoicesDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoicesDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInvoicesDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInvoicesDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoicesDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvInvoicesDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoicesDetails.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvInvoicesDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInvoicesDetails.Location = new System.Drawing.Point(509, 295);
            this.dgvInvoicesDetails.Name = "dgvInvoicesDetails";
            this.dgvInvoicesDetails.ReadOnly = true;
            this.dgvInvoicesDetails.RowHeadersVisible = false;
            this.dgvInvoicesDetails.Size = new System.Drawing.Size(749, 349);
            this.dgvInvoicesDetails.TabIndex = 19;
            this.dgvInvoicesDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvInvoicesDetails_DataBindingComplete);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(351, 69);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(27, 27);
            this.btnSearch.TabIndex = 68;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReload.BackgroundImage")));
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Location = new System.Drawing.Point(377, 69);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(27, 27);
            this.btnReload.TabIndex = 69;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(204, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 70;
            this.label3.Text = "Invoices";
            // 
            // radioGroupSearch
            // 
            this.radioGroupSearch.Controls.Add(this.radioCompany);
            this.radioGroupSearch.Controls.Add(this.radioID);
            this.radioGroupSearch.Location = new System.Drawing.Point(98, 102);
            this.radioGroupSearch.Name = "radioGroupSearch";
            this.radioGroupSearch.Size = new System.Drawing.Size(306, 32);
            this.radioGroupSearch.TabIndex = 71;
            // 
            // radioCompany
            // 
            this.radioCompany.AutoSize = true;
            this.radioCompany.Checked = true;
            this.radioCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCompany.Location = new System.Drawing.Point(3, 3);
            this.radioCompany.Name = "radioCompany";
            this.radioCompany.Size = new System.Drawing.Size(162, 24);
            this.radioCompany.TabIndex = 0;
            this.radioCompany.TabStop = true;
            this.radioCompany.Text = "By Company Name";
            this.radioCompany.UseVisualStyleBackColor = true;
            this.radioCompany.Click += new System.EventHandler(this.radioCompany_Click);
            // 
            // radioID
            // 
            this.radioID.AutoSize = true;
            this.radioID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioID.Location = new System.Drawing.Point(171, 3);
            this.radioID.Name = "radioID";
            this.radioID.Size = new System.Drawing.Size(66, 24);
            this.radioID.TabIndex = 1;
            this.radioID.Text = "By ID";
            this.radioID.UseVisualStyleBackColor = true;
            this.radioID.Click += new System.EventHandler(this.radioID_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(98, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 20);
            this.label10.TabIndex = 75;
            this.label10.Text = "To";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(98, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 20);
            this.label11.TabIndex = 74;
            this.label11.Text = "From";
            // 
            // dtPickerTo
            // 
            this.dtPickerTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerTo.Location = new System.Drawing.Point(172, 198);
            this.dtPickerTo.Name = "dtPickerTo";
            this.dtPickerTo.Size = new System.Drawing.Size(232, 26);
            this.dtPickerTo.TabIndex = 73;
            this.dtPickerTo.CloseUp += new System.EventHandler(this.dtPickerTo_CloseUp);
            // 
            // dtPickerFrom
            // 
            this.dtPickerFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerFrom.Location = new System.Drawing.Point(172, 155);
            this.dtPickerFrom.Name = "dtPickerFrom";
            this.dtPickerFrom.Size = new System.Drawing.Size(232, 26);
            this.dtPickerFrom.TabIndex = 72;
            this.dtPickerFrom.Value = new System.DateTime(2023, 5, 1, 0, 0, 0, 0);
            this.dtPickerFrom.CloseUp += new System.EventHandler(this.dtPickerFrom_CloseUp);
            // 
            // radioGroupMoney
            // 
            this.radioGroupMoney.Controls.Add(this.radioAll);
            this.radioGroupMoney.Controls.Add(this.radioPaid);
            this.radioGroupMoney.Controls.Add(this.radioNotPaid);
            this.radioGroupMoney.Location = new System.Drawing.Point(102, 248);
            this.radioGroupMoney.Name = "radioGroupMoney";
            this.radioGroupMoney.Size = new System.Drawing.Size(302, 39);
            this.radioGroupMoney.TabIndex = 76;
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAll.Location = new System.Drawing.Point(3, 3);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(44, 24);
            this.radioAll.TabIndex = 0;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.Click += new System.EventHandler(this.radioAll_Click);
            // 
            // radioPaid
            // 
            this.radioPaid.AutoSize = true;
            this.radioPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPaid.Location = new System.Drawing.Point(53, 3);
            this.radioPaid.Name = "radioPaid";
            this.radioPaid.Size = new System.Drawing.Size(58, 24);
            this.radioPaid.TabIndex = 1;
            this.radioPaid.Text = "Paid";
            this.radioPaid.UseVisualStyleBackColor = true;
            this.radioPaid.Click += new System.EventHandler(this.radioPaid_Click);
            // 
            // radioNotPaid
            // 
            this.radioNotPaid.AutoSize = true;
            this.radioNotPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNotPaid.Location = new System.Drawing.Point(117, 3);
            this.radioNotPaid.Name = "radioNotPaid";
            this.radioNotPaid.Size = new System.Drawing.Size(87, 24);
            this.radioNotPaid.TabIndex = 2;
            this.radioNotPaid.Text = "Not Paid";
            this.radioNotPaid.UseVisualStyleBackColor = true;
            this.radioNotPaid.Click += new System.EventHandler(this.radioNotPaid_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(105, 314);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(299, 46);
            this.btnAdd.TabIndex = 77;
            this.btnAdd.Text = "Update or Add an Invoice";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.labelTotal);
            this.panel1.Controls.Add(this.labelPaid);
            this.panel1.Controls.Add(this.labelToPay);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(105, 403);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 113);
            this.panel1.TabIndex = 78;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(139, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 20);
            this.label13.TabIndex = 89;
            this.label13.Text = "F.CFA";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(139, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 20);
            this.label12.TabIndex = 89;
            this.label12.Text = "F.CFA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(139, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 88;
            this.label9.Text = "F.CFA";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(193, 80);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(49, 20);
            this.labelTotal.TabIndex = 82;
            this.labelTotal.Text = "1000";
            // 
            // labelPaid
            // 
            this.labelPaid.AutoSize = true;
            this.labelPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaid.Location = new System.Drawing.Point(193, 50);
            this.labelPaid.Name = "labelPaid";
            this.labelPaid.Size = new System.Drawing.Size(49, 20);
            this.labelPaid.TabIndex = 82;
            this.labelPaid.Text = "1000";
            // 
            // labelToPay
            // 
            this.labelToPay.AutoSize = true;
            this.labelToPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToPay.Location = new System.Drawing.Point(193, 17);
            this.labelToPay.Name = "labelToPay";
            this.labelToPay.Size = new System.Drawing.Size(49, 20);
            this.labelToPay.TabIndex = 81;
            this.labelToPay.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 80;
            this.label5.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 80;
            this.label4.Text = "Total Paid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total To Pay";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 79;
            this.label1.Text = "Payments";
            // 
            // tbLimitInvoice
            // 
            this.tbLimitInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLimitInvoice.Location = new System.Drawing.Point(553, 29);
            this.tbLimitInvoice.Name = "tbLimitInvoice";
            this.tbLimitInvoice.Size = new System.Drawing.Size(37, 26);
            this.tbLimitInvoice.TabIndex = 80;
            this.tbLimitInvoice.Text = "25";
            this.tbLimitInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLimitInvoice_KeyDown);
            this.tbLimitInvoice.Leave += new System.EventHandler(this.tbLimitInvoice_Leave);
            // 
            // labelidk
            // 
            this.labelidk.AutoSize = true;
            this.labelidk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelidk.Location = new System.Drawing.Point(505, 32);
            this.labelidk.Name = "labelidk";
            this.labelidk.Size = new System.Drawing.Size(42, 20);
            this.labelidk.TabIndex = 81;
            this.labelidk.Text = "Limit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(796, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 20);
            this.label6.TabIndex = 82;
            this.label6.Text = "Invoice Records";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(781, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 20);
            this.label7.TabIndex = 85;
            this.label7.Text = "Invoice Details Records";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(505, 263);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 20);
            this.label8.TabIndex = 84;
            this.label8.Text = "Limit";
            // 
            // tbLimitInvoiceDetails
            // 
            this.tbLimitInvoiceDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLimitInvoiceDetails.Location = new System.Drawing.Point(553, 260);
            this.tbLimitInvoiceDetails.Name = "tbLimitInvoiceDetails";
            this.tbLimitInvoiceDetails.Size = new System.Drawing.Size(37, 26);
            this.tbLimitInvoiceDetails.TabIndex = 83;
            this.tbLimitInvoiceDetails.Text = "50";
            this.tbLimitInvoiceDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLimitInvoiceDetails_KeyDown);
            this.tbLimitInvoiceDetails.Leave += new System.EventHandler(this.tbLimitInvoiceDetails_Leave);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(38, 579);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(111, 65);
            this.btnLogout.TabIndex = 87;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnHomepage
            // 
            this.btnHomepage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomepage.Location = new System.Drawing.Point(159, 579);
            this.btnHomepage.Name = "btnHomepage";
            this.btnHomepage.Size = new System.Drawing.Size(128, 65);
            this.btnHomepage.TabIndex = 86;
            this.btnHomepage.Text = "Homepage";
            this.btnHomepage.UseVisualStyleBackColor = true;
            this.btnHomepage.Click += new System.EventHandler(this.btnHomepage_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbSearch.ForeColor = System.Drawing.Color.Gray;
            this.tbSearch.Location = new System.Drawing.Point(98, 70);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PlaceHolderText = "Search...";
            this.tbSearch.Size = new System.Drawing.Size(261, 26);
            this.tbSearch.TabIndex = 20;
            this.tbSearch.Text = "Search...";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(596, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 27);
            this.button1.TabIndex = 88;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 668);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnHomepage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbLimitInvoiceDetails);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelidk);
            this.Controls.Add(this.tbLimitInvoice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.radioGroupMoney);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtPickerTo);
            this.Controls.Add(this.dtPickerFrom);
            this.Controls.Add(this.radioGroupSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.dgvInvoicesDetails);
            this.Controls.Add(this.dgvInvoices);
            this.MaximizeBox = false;
            this.Name = "NewInvoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewInvoices";
            this.Load += new System.EventHandler(this.NewInvoices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicesDetails)).EndInit();
            this.radioGroupSearch.ResumeLayout(false);
            this.radioGroupSearch.PerformLayout();
            this.radioGroupMoney.ResumeLayout(false);
            this.radioGroupMoney.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.DataGridView dgvInvoicesDetails;
        private PlaceholderTextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel radioGroupSearch;
        private System.Windows.Forms.RadioButton radioCompany;
        private System.Windows.Forms.RadioButton radioID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtPickerTo;
        private System.Windows.Forms.DateTimePicker dtPickerFrom;
        private System.Windows.Forms.FlowLayoutPanel radioGroupMoney;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioPaid;
        private System.Windows.Forms.RadioButton radioNotPaid;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelPaid;
        private System.Windows.Forms.Label labelToPay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLimitInvoice;
        private System.Windows.Forms.Label labelidk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbLimitInvoiceDetails;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnHomepage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
    }
}