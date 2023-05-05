namespace Construction
{
    partial class Payments
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbPPaid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPDesc = new System.Windows.Forms.TextBox();
            this.btnPaymentUpdate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtPickerTo = new System.Windows.Forms.DateTimePicker();
            this.dtPickerFrom = new System.Windows.Forms.DateTimePicker();
            this.Limit = new System.Windows.Forms.Label();
            this.tbPaymentLimit = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnHomepage = new System.Windows.Forms.Button();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTotalPaid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Paid";
            // 
            // tbPPaid
            // 
            this.tbPPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPPaid.Location = new System.Drawing.Point(119, 115);
            this.tbPPaid.Name = "tbPPaid";
            this.tbPPaid.Size = new System.Drawing.Size(103, 26);
            this.tbPPaid.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Description";
            // 
            // tbPDesc
            // 
            this.tbPDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPDesc.Location = new System.Drawing.Point(119, 165);
            this.tbPDesc.Multiline = true;
            this.tbPDesc.Name = "tbPDesc";
            this.tbPDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPDesc.Size = new System.Drawing.Size(208, 118);
            this.tbPDesc.TabIndex = 9;
            // 
            // btnPaymentUpdate
            // 
            this.btnPaymentUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaymentUpdate.Location = new System.Drawing.Point(119, 309);
            this.btnPaymentUpdate.Name = "btnPaymentUpdate";
            this.btnPaymentUpdate.Size = new System.Drawing.Size(208, 37);
            this.btnPaymentUpdate.TabIndex = 15;
            this.btnPaymentUpdate.Text = "Add";
            this.btnPaymentUpdate.UseVisualStyleBackColor = true;
            this.btnPaymentUpdate.Click += new System.EventHandler(this.btnPaymentUpdate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(708, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "From";
            // 
            // dtPickerTo
            // 
            this.dtPickerTo.Location = new System.Drawing.Point(732, 77);
            this.dtPickerTo.Name = "dtPickerTo";
            this.dtPickerTo.Size = new System.Drawing.Size(200, 20);
            this.dtPickerTo.TabIndex = 26;
            this.dtPickerTo.CloseUp += new System.EventHandler(this.dtPickerTo_CloseUp);
            // 
            // dtPickerFrom
            // 
            this.dtPickerFrom.Location = new System.Drawing.Point(502, 77);
            this.dtPickerFrom.Name = "dtPickerFrom";
            this.dtPickerFrom.Size = new System.Drawing.Size(200, 20);
            this.dtPickerFrom.TabIndex = 25;
            this.dtPickerFrom.Value = new System.DateTime(2023, 5, 1, 0, 0, 0, 0);
            this.dtPickerFrom.CloseUp += new System.EventHandler(this.dtPickerFrom_CloseUp);
            // 
            // Limit
            // 
            this.Limit.AutoSize = true;
            this.Limit.Location = new System.Drawing.Point(396, 81);
            this.Limit.Name = "Limit";
            this.Limit.Size = new System.Drawing.Size(28, 13);
            this.Limit.TabIndex = 30;
            this.Limit.Text = "Limit";
            // 
            // tbPaymentLimit
            // 
            this.tbPaymentLimit.Location = new System.Drawing.Point(430, 77);
            this.tbPaymentLimit.Name = "tbPaymentLimit";
            this.tbPaymentLimit.Size = new System.Drawing.Size(29, 20);
            this.tbPaymentLimit.TabIndex = 29;
            this.tbPaymentLimit.Text = "25";
            this.tbPaymentLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPaymentLimit_KeyDown);
            this.tbPaymentLimit.Leave += new System.EventHandler(this.tbPaymentLimit_Leave);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(12, 422);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(111, 65);
            this.btnLogout.TabIndex = 32;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnHomepage
            // 
            this.btnHomepage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomepage.Location = new System.Drawing.Point(133, 422);
            this.btnHomepage.Name = "btnHomepage";
            this.btnHomepage.Size = new System.Drawing.Size(128, 65);
            this.btnHomepage.TabIndex = 31;
            this.btnHomepage.Text = "Homepage";
            this.btnHomepage.UseVisualStyleBackColor = true;
            this.btnHomepage.Click += new System.EventHandler(this.btnHomepage_Click);
            // 
            // dgvPayments
            // 
            this.dgvPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayments.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPayments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayments.Location = new System.Drawing.Point(431, 107);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.RowHeadersVisible = false;
            this.dgvPayments.Size = new System.Drawing.Size(463, 308);
            this.dgvPayments.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(153, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Other Payments";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(565, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 35;
            this.label6.Text = "Total Paid:";
            // 
            // labelTotalPaid
            // 
            this.labelTotalPaid.AutoSize = true;
            this.labelTotalPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPaid.Location = new System.Drawing.Point(665, 38);
            this.labelTotalPaid.Name = "labelTotalPaid";
            this.labelTotalPaid.Size = new System.Drawing.Size(39, 20);
            this.labelTotalPaid.TabIndex = 36;
            this.labelTotalPaid.Text = "100";
            // 
            // Payments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 511);
            this.Controls.Add(this.labelTotalPaid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvPayments);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnHomepage);
            this.Controls.Add(this.Limit);
            this.Controls.Add(this.tbPaymentLimit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtPickerTo);
            this.Controls.Add(this.dtPickerFrom);
            this.Controls.Add(this.btnPaymentUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPPaid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPDesc);
            this.MaximizeBox = false;
            this.Name = "Payments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payments";
            this.Load += new System.EventHandler(this.Payments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPPaid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPDesc;
        private System.Windows.Forms.Button btnPaymentUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtPickerTo;
        private System.Windows.Forms.DateTimePicker dtPickerFrom;
        private System.Windows.Forms.Label Limit;
        private System.Windows.Forms.TextBox tbPaymentLimit;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnHomepage;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTotalPaid;
    }
}