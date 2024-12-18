namespace _046_caranguian_pattaguan_F2
{
    partial class frmPirateGroups
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
            this.dtgPirateGroups = new System.Windows.Forms.DataGridView();
            this.cboCRUD = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtPirateGroupName = new System.Windows.Forms.TextBox();
            this.txtShipName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPirateGroupId = new System.Windows.Forms.TextBox();
            this.btnDisplayAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPirateGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPirateGroups
            // 
            this.dtgPirateGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPirateGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPirateGroups.Location = new System.Drawing.Point(312, 69);
            this.dtgPirateGroups.Name = "dtgPirateGroups";
            this.dtgPirateGroups.RowHeadersWidth = 62;
            this.dtgPirateGroups.RowTemplate.Height = 28;
            this.dtgPirateGroups.Size = new System.Drawing.Size(444, 228);
            this.dtgPirateGroups.TabIndex = 1;
            // 
            // cboCRUD
            // 
            this.cboCRUD.FormattingEnabled = true;
            this.cboCRUD.Items.AddRange(new object[] {
            "Insert",
            "Search",
            "Update"});
            this.cboCRUD.Location = new System.Drawing.Point(69, 310);
            this.cboCRUD.Name = "cboCRUD";
            this.cboCRUD.Size = new System.Drawing.Size(145, 28);
            this.cboCRUD.TabIndex = 2;
            this.cboCRUD.SelectedIndexChanged += new System.EventHandler(this.cboCRUD_SelectedIndexChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(102, 357);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 34);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtPirateGroupName
            // 
            this.txtPirateGroupName.Location = new System.Drawing.Point(69, 153);
            this.txtPirateGroupName.Name = "txtPirateGroupName";
            this.txtPirateGroupName.Size = new System.Drawing.Size(145, 26);
            this.txtPirateGroupName.TabIndex = 4;
            // 
            // txtShipName
            // 
            this.txtShipName.Location = new System.Drawing.Point(73, 222);
            this.txtShipName.Name = "txtShipName";
            this.txtShipName.Size = new System.Drawing.Size(141, 26);
            this.txtShipName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pirate Group Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ship name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Select CRUD Operation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Pirate Group ID";
            // 
            // txtPirateGroupId
            // 
            this.txtPirateGroupId.Location = new System.Drawing.Point(69, 81);
            this.txtPirateGroupId.Name = "txtPirateGroupId";
            this.txtPirateGroupId.Size = new System.Drawing.Size(145, 26);
            this.txtPirateGroupId.TabIndex = 9;
            // 
            // btnDisplayAll
            // 
            this.btnDisplayAll.Location = new System.Drawing.Point(485, 357);
            this.btnDisplayAll.Name = "btnDisplayAll";
            this.btnDisplayAll.Size = new System.Drawing.Size(112, 34);
            this.btnDisplayAll.TabIndex = 11;
            this.btnDisplayAll.Text = "Display All";
            this.btnDisplayAll.UseVisualStyleBackColor = true;
            this.btnDisplayAll.Click += new System.EventHandler(this.btnDisplayAll_Click);
            // 
            // frmPirateGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Controls.Add(this.btnDisplayAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPirateGroupId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtShipName);
            this.Controls.Add(this.txtPirateGroupName);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cboCRUD);
            this.Controls.Add(this.dtgPirateGroups);
            this.Name = "frmPirateGroups";
            this.Text = "frmPirateGroups";
            this.Load += new System.EventHandler(this.frmPirateGroups_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPirateGroups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgPirateGroups;
        private System.Windows.Forms.ComboBox cboCRUD;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtPirateGroupName;
        private System.Windows.Forms.TextBox txtShipName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPirateGroupId;
        private System.Windows.Forms.Button btnDisplayAll;
    }
}