namespace Construction
{
    partial class Stock
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
            this.tbMOne = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMTwo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMThree = new System.Windows.Forms.TextBox();
            this.radioAdd = new System.Windows.Forms.RadioButton();
            this.radioSubtract = new System.Windows.Forms.RadioButton();
            this.btnStockUpdate = new System.Windows.Forms.Button();
            this.btnHomepage = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dgvMaterials = new System.Windows.Forms.DataGridView();
            this.dgvMaterialsHistory = new System.Windows.Forms.DataGridView();
            this.tbStockLimit = new System.Windows.Forms.TextBox();
            this.Limit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialsHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMOne
            // 
            this.tbMOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMOne.Location = new System.Drawing.Point(180, 114);
            this.tbMOne.Name = "tbMOne";
            this.tbMOne.Size = new System.Drawing.Size(103, 26);
            this.tbMOne.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Material One";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Material Two";
            // 
            // tbMTwo
            // 
            this.tbMTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMTwo.Location = new System.Drawing.Point(180, 160);
            this.tbMTwo.Name = "tbMTwo";
            this.tbMTwo.Size = new System.Drawing.Size(103, 26);
            this.tbMTwo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Material Three";
            // 
            // tbMThree
            // 
            this.tbMThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMThree.Location = new System.Drawing.Point(180, 208);
            this.tbMThree.Name = "tbMThree";
            this.tbMThree.Size = new System.Drawing.Size(103, 26);
            this.tbMThree.TabIndex = 9;
            // 
            // radioAdd
            // 
            this.radioAdd.AutoSize = true;
            this.radioAdd.Checked = true;
            this.radioAdd.Location = new System.Drawing.Point(119, 252);
            this.radioAdd.Name = "radioAdd";
            this.radioAdd.Size = new System.Drawing.Size(44, 17);
            this.radioAdd.TabIndex = 12;
            this.radioAdd.TabStop = true;
            this.radioAdd.Text = "Add";
            this.radioAdd.UseVisualStyleBackColor = true;
            // 
            // radioSubtract
            // 
            this.radioSubtract.AutoSize = true;
            this.radioSubtract.Location = new System.Drawing.Point(180, 252);
            this.radioSubtract.Name = "radioSubtract";
            this.radioSubtract.Size = new System.Drawing.Size(70, 17);
            this.radioSubtract.TabIndex = 13;
            this.radioSubtract.TabStop = true;
            this.radioSubtract.Text = "Substract";
            this.radioSubtract.UseVisualStyleBackColor = true;
            // 
            // btnStockUpdate
            // 
            this.btnStockUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockUpdate.Location = new System.Drawing.Point(68, 286);
            this.btnStockUpdate.Name = "btnStockUpdate";
            this.btnStockUpdate.Size = new System.Drawing.Size(215, 37);
            this.btnStockUpdate.TabIndex = 14;
            this.btnStockUpdate.Text = "Update";
            this.btnStockUpdate.UseVisualStyleBackColor = true;
            this.btnStockUpdate.Click += new System.EventHandler(this.btnStockUpdate_Click);
            // 
            // btnHomepage
            // 
            this.btnHomepage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomepage.Location = new System.Drawing.Point(133, 422);
            this.btnHomepage.Name = "btnHomepage";
            this.btnHomepage.Size = new System.Drawing.Size(128, 65);
            this.btnHomepage.TabIndex = 15;
            this.btnHomepage.Text = "Homepage";
            this.btnHomepage.UseVisualStyleBackColor = true;
            this.btnHomepage.Click += new System.EventHandler(this.btnHomepage_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(12, 422);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(111, 65);
            this.btnLogout.TabIndex = 16;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterials.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMaterials.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMaterials.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterials.Location = new System.Drawing.Point(473, 63);
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.RowHeadersVisible = false;
            this.dgvMaterials.Size = new System.Drawing.Size(463, 97);
            this.dgvMaterials.TabIndex = 17;
            // 
            // dgvMaterialsHistory
            // 
            this.dgvMaterialsHistory.AllowUserToAddRows = false;
            this.dgvMaterialsHistory.AllowUserToDeleteRows = false;
            this.dgvMaterialsHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterialsHistory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMaterialsHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMaterialsHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterialsHistory.Location = new System.Drawing.Point(473, 214);
            this.dgvMaterialsHistory.Name = "dgvMaterialsHistory";
            this.dgvMaterialsHistory.RowHeadersVisible = false;
            this.dgvMaterialsHistory.Size = new System.Drawing.Size(463, 242);
            this.dgvMaterialsHistory.TabIndex = 18;
            // 
            // tbStockLimit
            // 
            this.tbStockLimit.Location = new System.Drawing.Point(506, 188);
            this.tbStockLimit.Name = "tbStockLimit";
            this.tbStockLimit.Size = new System.Drawing.Size(29, 20);
            this.tbStockLimit.TabIndex = 19;
            this.tbStockLimit.Text = "25";
            this.tbStockLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbStockLimit_KeyDown);
            this.tbStockLimit.Leave += new System.EventHandler(this.tbStockLimit_Leave);
            // 
            // Limit
            // 
            this.Limit.AutoSize = true;
            this.Limit.Location = new System.Drawing.Point(472, 190);
            this.Limit.Name = "Limit";
            this.Limit.Size = new System.Drawing.Size(28, 13);
            this.Limit.TabIndex = 20;
            this.Limit.Text = "Limit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(115, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Your Stock";
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 511);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Limit);
            this.Controls.Add(this.tbStockLimit);
            this.Controls.Add(this.dgvMaterialsHistory);
            this.Controls.Add(this.dgvMaterials);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnHomepage);
            this.Controls.Add(this.btnStockUpdate);
            this.Controls.Add(this.radioSubtract);
            this.Controls.Add(this.radioAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMThree);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMTwo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMOne);
            this.Name = "Stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialsHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbMOne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMTwo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMThree;
        private System.Windows.Forms.RadioButton radioAdd;
        private System.Windows.Forms.RadioButton radioSubtract;
        private System.Windows.Forms.Button btnStockUpdate;
        private System.Windows.Forms.Button btnHomepage;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dgvMaterials;
        private System.Windows.Forms.DataGridView dgvMaterialsHistory;
        private System.Windows.Forms.TextBox tbStockLimit;
        private System.Windows.Forms.Label Limit;
        private System.Windows.Forms.Label label4;
    }
}