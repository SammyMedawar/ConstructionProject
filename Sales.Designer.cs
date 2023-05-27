namespace Construction
{
    partial class Sales
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLimitInvoiceDetails = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelidk = new System.Windows.Forms.Label();
            this.tbLimitInvoice = new System.Windows.Forms.TextBox();
            this.dgvInvoicesDetails = new System.Windows.Forms.DataGridView();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.PanelOne = new System.Windows.Forms.Panel();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnHomepage = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.radioGroupSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.radioCompany = new System.Windows.Forms.RadioButton();
            this.radioID = new System.Windows.Forms.RadioButton();
            this.dtPickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtPickerTo = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.ComboBox();
            this.radioGroupMoney = new System.Windows.Forms.FlowLayoutPanel();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioPaid = new System.Windows.Forms.RadioButton();
            this.radioNotPaid = new System.Windows.Forms.RadioButton();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicesDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.PanelOne.SuspendLayout();
            this.radioGroupSearch.SuspendLayout();
            this.radioGroupMoney.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(595, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 27);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(806, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 20);
            this.label7.TabIndex = 147;
            this.label7.Text = "Sales Details Records";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(504, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 20);
            this.label8.TabIndex = 146;
            this.label8.Text = "Limit";
            // 
            // tbLimitInvoiceDetails
            // 
            this.tbLimitInvoiceDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLimitInvoiceDetails.Location = new System.Drawing.Point(552, 340);
            this.tbLimitInvoiceDetails.Name = "tbLimitInvoiceDetails";
            this.tbLimitInvoiceDetails.Size = new System.Drawing.Size(37, 26);
            this.tbLimitInvoiceDetails.TabIndex = 3;
            this.tbLimitInvoiceDetails.Text = "50";
            this.tbLimitInvoiceDetails.TextChanged += new System.EventHandler(this.tbLimitInvoiceDetails_TextChanged);
            this.tbLimitInvoiceDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLimitInvoiceDetails_KeyDown);
            this.tbLimitInvoiceDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLimitInvoice_KeyPress);
            this.tbLimitInvoiceDetails.Leave += new System.EventHandler(this.tbLimitInvoiceDetails_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(828, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 20);
            this.label6.TabIndex = 145;
            this.label6.Text = "Sales Records";
            // 
            // labelidk
            // 
            this.labelidk.AutoSize = true;
            this.labelidk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelidk.Location = new System.Drawing.Point(504, 32);
            this.labelidk.Name = "labelidk";
            this.labelidk.Size = new System.Drawing.Size(42, 20);
            this.labelidk.TabIndex = 144;
            this.labelidk.Text = "Limit";
            // 
            // tbLimitInvoice
            // 
            this.tbLimitInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLimitInvoice.Location = new System.Drawing.Point(552, 29);
            this.tbLimitInvoice.Name = "tbLimitInvoice";
            this.tbLimitInvoice.Size = new System.Drawing.Size(37, 26);
            this.tbLimitInvoice.TabIndex = 1;
            this.tbLimitInvoice.Text = "25";
            this.tbLimitInvoice.TextChanged += new System.EventHandler(this.tbLimitInvoice_TextChanged);
            this.tbLimitInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLimitInvoice_KeyDown);
            this.tbLimitInvoice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLimitInvoice_KeyPress);
            this.tbLimitInvoice.Leave += new System.EventHandler(this.tbLimitInvoice_Leave);
            // 
            // dgvInvoicesDetails
            // 
            this.dgvInvoicesDetails.AllowUserToAddRows = false;
            this.dgvInvoicesDetails.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.dgvInvoicesDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInvoicesDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoicesDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInvoicesDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInvoicesDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoicesDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvInvoicesDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "32";
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoicesDetails.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvInvoicesDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInvoicesDetails.Location = new System.Drawing.Point(477, 369);
            this.dgvInvoicesDetails.Name = "dgvInvoicesDetails";
            this.dgvInvoicesDetails.ReadOnly = true;
            this.dgvInvoicesDetails.RowHeadersVisible = false;
            this.dgvInvoicesDetails.Size = new System.Drawing.Size(782, 275);
            this.dgvInvoicesDetails.TabIndex = 143;
            this.dgvInvoicesDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvInvoicesDetails_DataBindingComplete);
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.AllowUserToAddRows = false;
            this.dgvInvoices.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            this.dgvInvoices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInvoices.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoices.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvInvoices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInvoices.Location = new System.Drawing.Point(477, 61);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.ReadOnly = true;
            this.dgvInvoices.RowHeadersVisible = false;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoices.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvInvoices.Size = new System.Drawing.Size(782, 273);
            this.dgvInvoices.TabIndex = 142;
            this.dgvInvoices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoices_CellDoubleClick);
            this.dgvInvoices.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvInvoices_DataBindingComplete);
            // 
            // PanelOne
            // 
            this.PanelOne.Controls.Add(this.btnPayments);
            this.PanelOne.Controls.Add(this.btnSearch);
            this.PanelOne.Controls.Add(this.btnLogout);
            this.PanelOne.Controls.Add(this.btnHomepage);
            this.PanelOne.Controls.Add(this.btnReload);
            this.PanelOne.Controls.Add(this.label3);
            this.PanelOne.Controls.Add(this.btnAdd);
            this.PanelOne.Controls.Add(this.radioGroupSearch);
            this.PanelOne.Controls.Add(this.dtPickerFrom);
            this.PanelOne.Controls.Add(this.label10);
            this.PanelOne.Controls.Add(this.dtPickerTo);
            this.PanelOne.Controls.Add(this.label11);
            this.PanelOne.Controls.Add(this.tbSearch);
            this.PanelOne.Location = new System.Drawing.Point(2, 1);
            this.PanelOne.Name = "PanelOne";
            this.PanelOne.Size = new System.Drawing.Size(473, 667);
            this.PanelOne.TabIndex = 0;
            // 
            // btnPayments
            // 
            this.btnPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayments.Location = new System.Drawing.Point(79, 414);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(303, 46);
            this.btnPayments.TabIndex = 12;
            this.btnPayments.Text = "Add a Payment";
            this.btnPayments.UseVisualStyleBackColor = true;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(328, 166);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(27, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(36, 578);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(111, 65);
            this.btnLogout.TabIndex = 18;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnHomepage
            // 
            this.btnHomepage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomepage.Location = new System.Drawing.Point(157, 578);
            this.btnHomepage.Name = "btnHomepage";
            this.btnHomepage.Size = new System.Drawing.Size(128, 65);
            this.btnHomepage.TabIndex = 17;
            this.btnHomepage.Text = "Homepage";
            this.btnHomepage.UseVisualStyleBackColor = true;
            this.btnHomepage.Click += new System.EventHandler(this.btnHomepage_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReload.BackgroundImage")));
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Location = new System.Drawing.Point(354, 166);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(27, 28);
            this.btnReload.TabIndex = 3;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(188, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 116;
            this.label3.Text = "Sales";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(78, 350);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(303, 46);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add a Sale";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // radioGroupSearch
            // 
            this.radioGroupSearch.Controls.Add(this.radioCompany);
            this.radioGroupSearch.Controls.Add(this.radioID);
            this.radioGroupSearch.Location = new System.Drawing.Point(75, 200);
            this.radioGroupSearch.Name = "radioGroupSearch";
            this.radioGroupSearch.Size = new System.Drawing.Size(306, 32);
            this.radioGroupSearch.TabIndex = 4;
            this.radioGroupSearch.TabStop = true;
            // 
            // radioCompany
            // 
            this.radioCompany.AutoSize = true;
            this.radioCompany.Checked = true;
            this.radioCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCompany.Location = new System.Drawing.Point(3, 3);
            this.radioCompany.Name = "radioCompany";
            this.radioCompany.Size = new System.Drawing.Size(162, 24);
            this.radioCompany.TabIndex = 4;
            this.radioCompany.TabStop = true;
            this.radioCompany.Text = "By Company Name";
            this.radioCompany.UseVisualStyleBackColor = true;
            this.radioCompany.CheckedChanged += new System.EventHandler(this.radioCompany2_CheckedChanged);
            this.radioCompany.Click += new System.EventHandler(this.radioCompany_Click);
            // 
            // radioID
            // 
            this.radioID.AutoSize = true;
            this.radioID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioID.Location = new System.Drawing.Point(171, 3);
            this.radioID.Name = "radioID";
            this.radioID.Size = new System.Drawing.Size(66, 24);
            this.radioID.TabIndex = 5;
            this.radioID.TabStop = true;
            this.radioID.Text = "By ID";
            this.radioID.UseVisualStyleBackColor = true;
            this.radioID.CheckedChanged += new System.EventHandler(this.radioCompany_CheckedChanged);
            this.radioID.Click += new System.EventHandler(this.radioID_Click);
            // 
            // dtPickerFrom
            // 
            this.dtPickerFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerFrom.Location = new System.Drawing.Point(149, 253);
            this.dtPickerFrom.Name = "dtPickerFrom";
            this.dtPickerFrom.Size = new System.Drawing.Size(232, 26);
            this.dtPickerFrom.TabIndex = 6;
            this.dtPickerFrom.Value = new System.DateTime(2023, 5, 1, 0, 0, 0, 0);
            this.dtPickerFrom.ValueChanged += new System.EventHandler(this.dtPickerFrom_CloseUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(75, 301);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 20);
            this.label10.TabIndex = 121;
            this.label10.Text = "To";
            // 
            // dtPickerTo
            // 
            this.dtPickerTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerTo.Location = new System.Drawing.Point(149, 296);
            this.dtPickerTo.Name = "dtPickerTo";
            this.dtPickerTo.Size = new System.Drawing.Size(232, 26);
            this.dtPickerTo.TabIndex = 7;
            this.dtPickerTo.ValueChanged += new System.EventHandler(this.dtPickerTo_CloseUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(75, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 20);
            this.label11.TabIndex = 120;
            this.label11.Text = "From";
            // 
            // tbSearch
            // 
            this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tbSearch.DropDownHeight = 600;
            this.tbSearch.DropDownWidth = 150;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.FormattingEnabled = true;
            this.tbSearch.IntegralHeight = false;
            this.tbSearch.Location = new System.Drawing.Point(75, 166);
            this.tbSearch.MaxDropDownItems = 30;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(253, 28);
            this.tbSearch.TabIndex = 0;
            // 
            // radioGroupMoney
            // 
            this.radioGroupMoney.Controls.Add(this.radioAll);
            this.radioGroupMoney.Controls.Add(this.radioPaid);
            this.radioGroupMoney.Controls.Add(this.radioNotPaid);
            this.radioGroupMoney.Location = new System.Drawing.Point(439, 1);
            this.radioGroupMoney.Name = "radioGroupMoney";
            this.radioGroupMoney.Size = new System.Drawing.Size(11, 39);
            this.radioGroupMoney.TabIndex = 138;
            this.radioGroupMoney.Visible = false;
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAll.Location = new System.Drawing.Point(3, 3);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(44, 24);
            this.radioAll.TabIndex = 8;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            // 
            // radioPaid
            // 
            this.radioPaid.AutoSize = true;
            this.radioPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPaid.Location = new System.Drawing.Point(3, 33);
            this.radioPaid.Name = "radioPaid";
            this.radioPaid.Size = new System.Drawing.Size(58, 24);
            this.radioPaid.TabIndex = 9;
            this.radioPaid.TabStop = true;
            this.radioPaid.Text = "Paid";
            this.radioPaid.UseVisualStyleBackColor = true;
            // 
            // radioNotPaid
            // 
            this.radioNotPaid.AutoSize = true;
            this.radioNotPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNotPaid.Location = new System.Drawing.Point(3, 63);
            this.radioNotPaid.Name = "radioNotPaid";
            this.radioNotPaid.Size = new System.Drawing.Size(87, 24);
            this.radioNotPaid.TabIndex = 10;
            this.radioNotPaid.TabStop = true;
            this.radioNotPaid.Text = "Not Paid";
            this.radioNotPaid.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(595, 29);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(27, 27);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 668);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbLimitInvoiceDetails);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelidk);
            this.Controls.Add(this.tbLimitInvoice);
            this.Controls.Add(this.dgvInvoicesDetails);
            this.Controls.Add(this.dgvInvoices);
            this.Controls.Add(this.PanelOne);
            this.Controls.Add(this.radioGroupMoney);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Sales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Sales_FormClosed);
            this.Load += new System.EventHandler(this.Sales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicesDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.PanelOne.ResumeLayout(false);
            this.PanelOne.PerformLayout();
            this.radioGroupSearch.ResumeLayout(false);
            this.radioGroupSearch.PerformLayout();
            this.radioGroupMoney.ResumeLayout(false);
            this.radioGroupMoney.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbLimitInvoiceDetails;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelidk;
        private System.Windows.Forms.TextBox tbLimitInvoice;
        private System.Windows.Forms.DataGridView dgvInvoicesDetails;
        private System.Windows.Forms.DataGridView dgvInvoices;
        public System.Windows.Forms.Panel PanelOne;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnHomepage;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.FlowLayoutPanel radioGroupSearch;
        private System.Windows.Forms.RadioButton radioCompany;
        private System.Windows.Forms.RadioButton radioID;
        private System.Windows.Forms.DateTimePicker dtPickerFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtPickerTo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.FlowLayoutPanel radioGroupMoney;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioPaid;
        private System.Windows.Forms.RadioButton radioNotPaid;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox tbSearch;
    }
}