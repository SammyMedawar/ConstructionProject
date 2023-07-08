namespace Construction
{
    partial class ucSalesAdd
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbCompanyName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnHomepage = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab9 = new System.Windows.Forms.Label();
            this.lab8 = new System.Windows.Forms.Label();
            this.lab7 = new System.Windows.Forms.Label();
            this.lab6 = new System.Windows.Forms.Label();
            this.lab3 = new System.Windows.Forms.Label();
            this.lab2 = new System.Windows.Forms.Label();
            this.lab4 = new System.Windows.Forms.Label();
            this.lab1 = new System.Windows.Forms.Label();
            this.lab5 = new System.Windows.Forms.Label();
            this.lab0 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbM10 = new Construction.PlaceholderTextBox();
            this.tbM9 = new Construction.PlaceholderTextBox();
            this.tbM10P = new Construction.PlaceholderTextBox();
            this.tbM9P = new Construction.PlaceholderTextBox();
            this.tbM7 = new Construction.PlaceholderTextBox();
            this.tbM7P = new Construction.PlaceholderTextBox();
            this.tbM8 = new Construction.PlaceholderTextBox();
            this.tbM1 = new Construction.PlaceholderTextBox();
            this.tbM2 = new Construction.PlaceholderTextBox();
            this.tbM8P = new Construction.PlaceholderTextBox();
            this.tbM3P = new Construction.PlaceholderTextBox();
            this.tbM4 = new Construction.PlaceholderTextBox();
            this.tbM3 = new Construction.PlaceholderTextBox();
            this.tbM4P = new Construction.PlaceholderTextBox();
            this.tbM2P = new Construction.PlaceholderTextBox();
            this.tbM5P = new Construction.PlaceholderTextBox();
            this.tbM1P = new Construction.PlaceholderTextBox();
            this.tbM6 = new Construction.PlaceholderTextBox();
            this.tbM6P = new Construction.PlaceholderTextBox();
            this.tbM5 = new Construction.PlaceholderTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbCompanyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tbCompanyName.DropDownHeight = 600;
            this.tbCompanyName.DropDownWidth = 150;
            this.tbCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCompanyName.FormattingEnabled = true;
            this.tbCompanyName.IntegralHeight = false;
            this.tbCompanyName.Location = new System.Drawing.Point(218, 67);
            this.tbCompanyName.MaxDropDownItems = 30;
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(166, 28);
            this.tbCompanyName.TabIndex = 2;
            this.tbCompanyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCompanyName_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 489);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 1096;
            this.label5.Text = "Total";
            // 
            // tbTotal
            // 
            this.tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.Location = new System.Drawing.Point(218, 486);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(166, 26);
            this.tbTotal.TabIndex = 7;
            this.tbTotal.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 1094;
            this.label3.Text = "Discount";
            // 
            // tbDiscount
            // 
            this.tbDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDiscount.Location = new System.Drawing.Point(218, 438);
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.Size = new System.Drawing.Size(166, 26);
            this.tbDiscount.TabIndex = 6;
            this.tbDiscount.Text = "0";
            this.tbDiscount.TextChanged += new System.EventHandler(this.tbDiscount_TextChanged);
            this.tbDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            this.tbDiscount.Leave += new System.EventHandler(this.tbDiscount_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(395, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 60);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clear ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(297, 579);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(128, 65);
            this.btnBack.TabIndex = 1085;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(36, 578);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(111, 65);
            this.btnLogout.TabIndex = 1087;
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
            this.btnHomepage.TabIndex = 1086;
            this.btnHomepage.Text = "Homepage";
            this.btnHomepage.UseVisualStyleBackColor = true;
            this.btnHomepage.Click += new System.EventHandler(this.btnHomepage_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(72, 528);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(312, 37);
            this.btnAdd.TabIndex = 1084;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(68, 394);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 1091;
            this.label8.Text = "Price";
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrice.Location = new System.Drawing.Point(218, 391);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.ReadOnly = true;
            this.tbPrice.Size = new System.Drawing.Size(166, 26);
            this.tbPrice.TabIndex = 5;
            this.tbPrice.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 1090;
            this.label4.Text = "Date";
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInvoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInvoiceDate.Location = new System.Drawing.Point(218, 111);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Size = new System.Drawing.Size(166, 26);
            this.dtInvoiceDate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 1089;
            this.label1.Text = "Company Name";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lab9);
            this.panel1.Controls.Add(this.lab8);
            this.panel1.Controls.Add(this.tbM10);
            this.panel1.Controls.Add(this.tbM9);
            this.panel1.Controls.Add(this.tbM10P);
            this.panel1.Controls.Add(this.tbM9P);
            this.panel1.Controls.Add(this.lab7);
            this.panel1.Controls.Add(this.lab6);
            this.panel1.Controls.Add(this.tbM7);
            this.panel1.Controls.Add(this.tbM7P);
            this.panel1.Controls.Add(this.tbM8);
            this.panel1.Controls.Add(this.tbM1);
            this.panel1.Controls.Add(this.tbM2);
            this.panel1.Controls.Add(this.lab3);
            this.panel1.Controls.Add(this.tbM8P);
            this.panel1.Controls.Add(this.tbM3P);
            this.panel1.Controls.Add(this.tbM4);
            this.panel1.Controls.Add(this.tbM3);
            this.panel1.Controls.Add(this.tbM4P);
            this.panel1.Controls.Add(this.lab2);
            this.panel1.Controls.Add(this.lab4);
            this.panel1.Controls.Add(this.tbM2P);
            this.panel1.Controls.Add(this.tbM5P);
            this.panel1.Controls.Add(this.lab1);
            this.panel1.Controls.Add(this.lab5);
            this.panel1.Controls.Add(this.tbM1P);
            this.panel1.Controls.Add(this.tbM6);
            this.panel1.Controls.Add(this.tbM6P);
            this.panel1.Controls.Add(this.lab0);
            this.panel1.Controls.Add(this.tbM5);
            this.panel1.Location = new System.Drawing.Point(37, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 227);
            this.panel1.TabIndex = 4;
            // 
            // lab9
            // 
            this.lab9.AutoSize = true;
            this.lab9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab9.Location = new System.Drawing.Point(31, 404);
            this.lab9.Name = "lab9";
            this.lab9.Size = new System.Drawing.Size(107, 20);
            this.lab9.TabIndex = 1079;
            this.lab9.Text = "Pleinne 20CM";
            // 
            // lab8
            // 
            this.lab8.AutoSize = true;
            this.lab8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab8.Location = new System.Drawing.Point(31, 360);
            this.lab8.Name = "lab8";
            this.lab8.Size = new System.Drawing.Size(107, 20);
            this.lab8.TabIndex = 1082;
            this.lab8.Text = "Pleinne 15CM";
            // 
            // lab7
            // 
            this.lab7.AutoSize = true;
            this.lab7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab7.Location = new System.Drawing.Point(31, 312);
            this.lab7.Name = "lab7";
            this.lab7.Size = new System.Drawing.Size(107, 20);
            this.lab7.TabIndex = 1079;
            this.lab7.Text = "Pleinne 10CM";
            // 
            // lab6
            // 
            this.lab6.AutoSize = true;
            this.lab6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab6.Location = new System.Drawing.Point(31, 265);
            this.lab6.Name = "lab6";
            this.lab6.Size = new System.Drawing.Size(90, 20);
            this.lab6.TabIndex = 1076;
            this.lab6.Text = "Pavé 13CM";
            // 
            // lab3
            // 
            this.lab3.AutoSize = true;
            this.lab3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab3.Location = new System.Drawing.Point(31, 136);
            this.lab3.Name = "lab3";
            this.lab3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lab3.Size = new System.Drawing.Size(81, 20);
            this.lab3.TabIndex = 1073;
            this.lab3.Text = "Pavé 6CM";
            // 
            // lab2
            // 
            this.lab2.AutoSize = true;
            this.lab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab2.Location = new System.Drawing.Point(31, 92);
            this.lab2.Name = "lab2";
            this.lab2.Size = new System.Drawing.Size(96, 20);
            this.lab2.TabIndex = 1046;
            this.lab2.Text = "Creux 20CM";
            // 
            // lab4
            // 
            this.lab4.AutoSize = true;
            this.lab4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab4.Location = new System.Drawing.Point(31, 179);
            this.lab4.Name = "lab4";
            this.lab4.Size = new System.Drawing.Size(81, 20);
            this.lab4.TabIndex = 1049;
            this.lab4.Text = "Pavé 8CM";
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab1.Location = new System.Drawing.Point(31, 47);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(96, 20);
            this.lab1.TabIndex = 1048;
            this.lab1.Text = "Creux 15CM";
            // 
            // lab5
            // 
            this.lab5.AutoSize = true;
            this.lab5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab5.Location = new System.Drawing.Point(31, 222);
            this.lab5.Name = "lab5";
            this.lab5.Size = new System.Drawing.Size(90, 20);
            this.lab5.TabIndex = 1050;
            this.lab5.Text = "Pavé 10CM";
            // 
            // lab0
            // 
            this.lab0.AutoSize = true;
            this.lab0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab0.Location = new System.Drawing.Point(31, 0);
            this.lab0.Name = "lab0";
            this.lab0.Size = new System.Drawing.Size(96, 20);
            this.lab0.TabIndex = 1060;
            this.lab0.Text = "Creux 10CM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(189, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 1097;
            this.label2.Text = "Add a Sale";
            // 
            // tbM10
            // 
            this.tbM10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM10.ForeColor = System.Drawing.Color.Gray;
            this.tbM10.Location = new System.Drawing.Point(181, 401);
            this.tbM10.Name = "tbM10";
            this.tbM10.PlaceHolderText = "Amount";
            this.tbM10.Size = new System.Drawing.Size(80, 26);
            this.tbM10.TabIndex = 10771;
            this.tbM10.Text = "Amount";
            this.tbM10.TextChanged += new System.EventHandler(this.tbM10_TextChanged);
            this.tbM10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            // 
            // tbM9
            // 
            this.tbM9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM9.ForeColor = System.Drawing.Color.Gray;
            this.tbM9.Location = new System.Drawing.Point(181, 357);
            this.tbM9.Name = "tbM9";
            this.tbM9.PlaceHolderText = "Amount";
            this.tbM9.Size = new System.Drawing.Size(80, 26);
            this.tbM9.TabIndex = 1080;
            this.tbM9.Text = "Amount";
            this.tbM9.TextChanged += new System.EventHandler(this.tbM9_TextChanged);
            this.tbM9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            // 
            // tbM10P
            // 
            this.tbM10P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM10P.ForeColor = System.Drawing.Color.Gray;
            this.tbM10P.Location = new System.Drawing.Point(267, 401);
            this.tbM10P.Name = "tbM10P";
            this.tbM10P.PlaceHolderText = "Price";
            this.tbM10P.Size = new System.Drawing.Size(80, 26);
            this.tbM10P.TabIndex = 10781;
            this.tbM10P.Text = "Price";
            this.tbM10P.TextChanged += new System.EventHandler(this.tbDiscount_TextChanged);
            this.tbM10P.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM10P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            this.tbM10P.Leave += new System.EventHandler(this.tbM1P_Leave);
            // 
            // tbM9P
            // 
            this.tbM9P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM9P.ForeColor = System.Drawing.Color.Gray;
            this.tbM9P.Location = new System.Drawing.Point(267, 357);
            this.tbM9P.Name = "tbM9P";
            this.tbM9P.PlaceHolderText = "Price";
            this.tbM9P.Size = new System.Drawing.Size(80, 26);
            this.tbM9P.TabIndex = 1081;
            this.tbM9P.Text = "Price";
            this.tbM9P.TextChanged += new System.EventHandler(this.tbDiscount_TextChanged);
            this.tbM9P.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM9P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            this.tbM9P.Leave += new System.EventHandler(this.tbM1P_Leave);
            // 
            // tbM7
            // 
            this.tbM7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM7.ForeColor = System.Drawing.Color.Gray;
            this.tbM7.Location = new System.Drawing.Point(181, 262);
            this.tbM7.Name = "tbM7";
            this.tbM7.PlaceHolderText = "Amount";
            this.tbM7.Size = new System.Drawing.Size(80, 26);
            this.tbM7.TabIndex = 1074;
            this.tbM7.Text = "Amount";
            this.tbM7.TextChanged += new System.EventHandler(this.tbM7_TextChanged);
            this.tbM7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            // 
            // tbM7P
            // 
            this.tbM7P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM7P.ForeColor = System.Drawing.Color.Gray;
            this.tbM7P.Location = new System.Drawing.Point(267, 262);
            this.tbM7P.Name = "tbM7P";
            this.tbM7P.PlaceHolderText = "Price";
            this.tbM7P.Size = new System.Drawing.Size(80, 26);
            this.tbM7P.TabIndex = 1075;
            this.tbM7P.Text = "Price";
            this.tbM7P.TextChanged += new System.EventHandler(this.tbDiscount_TextChanged);
            this.tbM7P.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM7P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            this.tbM7P.Leave += new System.EventHandler(this.tbM1P_Leave);
            // 
            // tbM8
            // 
            this.tbM8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM8.ForeColor = System.Drawing.Color.Gray;
            this.tbM8.Location = new System.Drawing.Point(181, 309);
            this.tbM8.Name = "tbM8";
            this.tbM8.PlaceHolderText = "Amount";
            this.tbM8.Size = new System.Drawing.Size(80, 26);
            this.tbM8.TabIndex = 1077;
            this.tbM8.Text = "Amount";
            this.tbM8.TextChanged += new System.EventHandler(this.tbM8_TextChanged);
            this.tbM8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            // 
            // tbM1
            // 
            this.tbM1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM1.ForeColor = System.Drawing.Color.Gray;
            this.tbM1.Location = new System.Drawing.Point(181, 0);
            this.tbM1.Name = "tbM1";
            this.tbM1.PlaceHolderText = "Amount";
            this.tbM1.Size = new System.Drawing.Size(80, 26);
            this.tbM1.TabIndex = 5;
            this.tbM1.Text = "Amount";
            this.tbM1.TextChanged += new System.EventHandler(this.tbM1_TextChanged);
            this.tbM1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            // 
            // tbM2
            // 
            this.tbM2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM2.ForeColor = System.Drawing.Color.Gray;
            this.tbM2.Location = new System.Drawing.Point(181, 44);
            this.tbM2.Name = "tbM2";
            this.tbM2.PlaceHolderText = "Amount";
            this.tbM2.Size = new System.Drawing.Size(80, 26);
            this.tbM2.TabIndex = 7;
            this.tbM2.Text = "Amount";
            this.tbM2.TextChanged += new System.EventHandler(this.tbM2_TextChanged);
            this.tbM2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            // 
            // tbM8P
            // 
            this.tbM8P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM8P.ForeColor = System.Drawing.Color.Gray;
            this.tbM8P.Location = new System.Drawing.Point(267, 309);
            this.tbM8P.Name = "tbM8P";
            this.tbM8P.PlaceHolderText = "Price";
            this.tbM8P.Size = new System.Drawing.Size(80, 26);
            this.tbM8P.TabIndex = 1078;
            this.tbM8P.Text = "Price";
            this.tbM8P.TextChanged += new System.EventHandler(this.tbDiscount_TextChanged);
            this.tbM8P.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM8P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            this.tbM8P.Leave += new System.EventHandler(this.tbM1P_Leave);
            // 
            // tbM3P
            // 
            this.tbM3P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM3P.ForeColor = System.Drawing.Color.Gray;
            this.tbM3P.Location = new System.Drawing.Point(267, 89);
            this.tbM3P.Name = "tbM3P";
            this.tbM3P.PlaceHolderText = "Price";
            this.tbM3P.Size = new System.Drawing.Size(80, 26);
            this.tbM3P.TabIndex = 10;
            this.tbM3P.Text = "Price";
            this.tbM3P.TextChanged += new System.EventHandler(this.tbDiscount_TextChanged);
            this.tbM3P.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM3P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            this.tbM3P.Leave += new System.EventHandler(this.tbM1P_Leave);
            // 
            // tbM4
            // 
            this.tbM4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM4.ForeColor = System.Drawing.Color.Gray;
            this.tbM4.Location = new System.Drawing.Point(181, 133);
            this.tbM4.Name = "tbM4";
            this.tbM4.PlaceHolderText = "Amount";
            this.tbM4.Size = new System.Drawing.Size(80, 26);
            this.tbM4.TabIndex = 11;
            this.tbM4.Text = "Amount";
            this.tbM4.TextChanged += new System.EventHandler(this.tbM4_TextChanged);
            this.tbM4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            // 
            // tbM3
            // 
            this.tbM3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM3.ForeColor = System.Drawing.Color.Gray;
            this.tbM3.Location = new System.Drawing.Point(181, 89);
            this.tbM3.Name = "tbM3";
            this.tbM3.PlaceHolderText = "Amount";
            this.tbM3.Size = new System.Drawing.Size(80, 26);
            this.tbM3.TabIndex = 9;
            this.tbM3.Text = "Amount";
            this.tbM3.TextChanged += new System.EventHandler(this.tbM3_TextChanged);
            this.tbM3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            // 
            // tbM4P
            // 
            this.tbM4P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM4P.ForeColor = System.Drawing.Color.Gray;
            this.tbM4P.Location = new System.Drawing.Point(267, 133);
            this.tbM4P.Name = "tbM4P";
            this.tbM4P.PlaceHolderText = "Price";
            this.tbM4P.Size = new System.Drawing.Size(80, 26);
            this.tbM4P.TabIndex = 12;
            this.tbM4P.Text = "Price";
            this.tbM4P.TextChanged += new System.EventHandler(this.tbDiscount_TextChanged);
            this.tbM4P.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM4P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            this.tbM4P.Leave += new System.EventHandler(this.tbM1P_Leave);
            // 
            // tbM2P
            // 
            this.tbM2P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM2P.ForeColor = System.Drawing.Color.Gray;
            this.tbM2P.Location = new System.Drawing.Point(267, 44);
            this.tbM2P.Name = "tbM2P";
            this.tbM2P.PlaceHolderText = "Price";
            this.tbM2P.Size = new System.Drawing.Size(80, 26);
            this.tbM2P.TabIndex = 8;
            this.tbM2P.Text = "Price";
            this.tbM2P.TextChanged += new System.EventHandler(this.tbDiscount_TextChanged);
            this.tbM2P.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM2P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            this.tbM2P.Leave += new System.EventHandler(this.tbM1P_Leave);
            // 
            // tbM5P
            // 
            this.tbM5P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM5P.ForeColor = System.Drawing.Color.Gray;
            this.tbM5P.Location = new System.Drawing.Point(267, 176);
            this.tbM5P.Name = "tbM5P";
            this.tbM5P.PlaceHolderText = "Price";
            this.tbM5P.Size = new System.Drawing.Size(80, 26);
            this.tbM5P.TabIndex = 14;
            this.tbM5P.Text = "Price";
            this.tbM5P.TextChanged += new System.EventHandler(this.tbDiscount_TextChanged);
            this.tbM5P.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM5P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            this.tbM5P.Leave += new System.EventHandler(this.tbM1P_Leave);
            // 
            // tbM1P
            // 
            this.tbM1P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM1P.ForeColor = System.Drawing.Color.Gray;
            this.tbM1P.Location = new System.Drawing.Point(267, 0);
            this.tbM1P.Name = "tbM1P";
            this.tbM1P.PlaceHolderText = "Price";
            this.tbM1P.Size = new System.Drawing.Size(80, 26);
            this.tbM1P.TabIndex = 6;
            this.tbM1P.Text = "Price";
            this.tbM1P.TextChanged += new System.EventHandler(this.tbDiscount_TextChanged);
            this.tbM1P.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM1P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            this.tbM1P.Leave += new System.EventHandler(this.tbM1P_Leave);
            // 
            // tbM6
            // 
            this.tbM6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM6.ForeColor = System.Drawing.Color.Gray;
            this.tbM6.Location = new System.Drawing.Point(181, 219);
            this.tbM6.Name = "tbM6";
            this.tbM6.PlaceHolderText = "Amount";
            this.tbM6.Size = new System.Drawing.Size(80, 26);
            this.tbM6.TabIndex = 15;
            this.tbM6.Text = "Amount";
            this.tbM6.TextChanged += new System.EventHandler(this.tbM6_TextChanged);
            this.tbM6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            // 
            // tbM6P
            // 
            this.tbM6P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM6P.ForeColor = System.Drawing.Color.Gray;
            this.tbM6P.Location = new System.Drawing.Point(267, 219);
            this.tbM6P.Name = "tbM6P";
            this.tbM6P.PlaceHolderText = "Price";
            this.tbM6P.Size = new System.Drawing.Size(80, 26);
            this.tbM6P.TabIndex = 16;
            this.tbM6P.Text = "Price";
            this.tbM6P.TextChanged += new System.EventHandler(this.tbDiscount_TextChanged);
            this.tbM6P.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM6P.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            this.tbM6P.Leave += new System.EventHandler(this.tbM1P_Leave);
            // 
            // tbM5
            // 
            this.tbM5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbM5.ForeColor = System.Drawing.Color.Gray;
            this.tbM5.Location = new System.Drawing.Point(181, 176);
            this.tbM5.Name = "tbM5";
            this.tbM5.PlaceHolderText = "Amount";
            this.tbM5.Size = new System.Drawing.Size(80, 26);
            this.tbM5.TabIndex = 13;
            this.tbM5.Text = "Amount";
            this.tbM5.TextChanged += new System.EventHandler(this.tbM5_TextChanged);
            this.tbM5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbM1P_KeyDown);
            this.tbM5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbM1_KeyPress);
            // 
            // ucSalesAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCompanyName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDiscount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnHomepage);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtInvoiceDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "ucSalesAdd";
            this.Size = new System.Drawing.Size(473, 667);
            this.Load += new System.EventHandler(this.ucSalesAdd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PlaceholderTextBox tbM4;
        private System.Windows.Forms.ComboBox tbCompanyName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDiscount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnHomepage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtInvoiceDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lab9;
        private System.Windows.Forms.Label lab8;
        private PlaceholderTextBox tbM10;
        private PlaceholderTextBox tbM9;
        private PlaceholderTextBox tbM10P;
        private PlaceholderTextBox tbM9P;
        private System.Windows.Forms.Label lab7;
        private System.Windows.Forms.Label lab6;
        private PlaceholderTextBox tbM7;
        private PlaceholderTextBox tbM7P;
        private PlaceholderTextBox tbM8;
        private PlaceholderTextBox tbM1;
        private PlaceholderTextBox tbM2;
        private System.Windows.Forms.Label lab3;
        private PlaceholderTextBox tbM8P;
        private PlaceholderTextBox tbM3P;
        private PlaceholderTextBox tbM3;
        private PlaceholderTextBox tbM4P;
        private System.Windows.Forms.Label lab2;
        private System.Windows.Forms.Label lab4;
        private PlaceholderTextBox tbM2P;
        private PlaceholderTextBox tbM5P;
        private System.Windows.Forms.Label lab1;
        private System.Windows.Forms.Label lab5;
        private PlaceholderTextBox tbM1P;
        private PlaceholderTextBox tbM6;
        private PlaceholderTextBox tbM6P;
        private System.Windows.Forms.Label lab0;
        private PlaceholderTextBox tbM5;
        private System.Windows.Forms.Label label2;
    }
}
