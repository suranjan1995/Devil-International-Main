namespace Devil_International_Main
{
    partial class log_in_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(log_in_form));
            this.lgiIfLgi_lbl = new System.Windows.Forms.Label();
            this.lgiIfUid_lbl = new System.Windows.Forms.Label();
            this.lgiIfPw_lbl = new System.Windows.Forms.Label();
            this.lgiIfUid_cmbx = new System.Windows.Forms.ComboBox();
            this.lgiIfPw_txtbx = new System.Windows.Forms.TextBox();
            this.lgiIfShwpw_btn = new System.Windows.Forms.Button();
            this.lgiIfLgi_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lgiIfLgi_lbl
            // 
            this.lgiIfLgi_lbl.AutoSize = true;
            this.lgiIfLgi_lbl.BackColor = System.Drawing.Color.Transparent;
            this.lgiIfLgi_lbl.Font = new System.Drawing.Font("Times New Roman", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgiIfLgi_lbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lgiIfLgi_lbl.Location = new System.Drawing.Point(12, 9);
            this.lgiIfLgi_lbl.Name = "lgiIfLgi_lbl";
            this.lgiIfLgi_lbl.Size = new System.Drawing.Size(346, 61);
            this.lgiIfLgi_lbl.TabIndex = 0;
            this.lgiIfLgi_lbl.Text = "Log In Here...";
            this.lgiIfLgi_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lgiIfUid_lbl
            // 
            this.lgiIfUid_lbl.AutoSize = true;
            this.lgiIfUid_lbl.BackColor = System.Drawing.Color.Transparent;
            this.lgiIfUid_lbl.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgiIfUid_lbl.ForeColor = System.Drawing.Color.White;
            this.lgiIfUid_lbl.Location = new System.Drawing.Point(271, 273);
            this.lgiIfUid_lbl.Name = "lgiIfUid_lbl";
            this.lgiIfUid_lbl.Size = new System.Drawing.Size(87, 25);
            this.lgiIfUid_lbl.TabIndex = 0;
            this.lgiIfUid_lbl.Text = "User ID";
            // 
            // lgiIfPw_lbl
            // 
            this.lgiIfPw_lbl.AutoSize = true;
            this.lgiIfPw_lbl.BackColor = System.Drawing.Color.Transparent;
            this.lgiIfPw_lbl.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgiIfPw_lbl.ForeColor = System.Drawing.Color.White;
            this.lgiIfPw_lbl.Location = new System.Drawing.Point(271, 315);
            this.lgiIfPw_lbl.Name = "lgiIfPw_lbl";
            this.lgiIfPw_lbl.Size = new System.Drawing.Size(103, 25);
            this.lgiIfPw_lbl.TabIndex = 0;
            this.lgiIfPw_lbl.Text = "Password";
            // 
            // lgiIfUid_cmbx
            // 
            this.lgiIfUid_cmbx.BackColor = System.Drawing.SystemColors.Window;
            this.lgiIfUid_cmbx.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgiIfUid_cmbx.FormattingEnabled = true;
            this.lgiIfUid_cmbx.Items.AddRange(new object[] {
            "Manager",
            "Administrative",
            "Sales",
            "Finance",
            "Human Resorces",
            "Marketig",
            "Legal",
            "Purchasing & Procurement",
            "Research & Development",
            "Customer Service",
            "Information Technology",
            "Operations"});
            this.lgiIfUid_cmbx.Location = new System.Drawing.Point(395, 266);
            this.lgiIfUid_cmbx.Name = "lgiIfUid_cmbx";
            this.lgiIfUid_cmbx.Size = new System.Drawing.Size(224, 32);
            this.lgiIfUid_cmbx.TabIndex = 0;
            this.lgiIfUid_cmbx.SelectedIndexChanged += new System.EventHandler(this.lgiIfUid_cmbx_SelectedIndexChanged);
            // 
            // lgiIfPw_txtbx
            // 
            this.lgiIfPw_txtbx.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgiIfPw_txtbx.Location = new System.Drawing.Point(395, 308);
            this.lgiIfPw_txtbx.Name = "lgiIfPw_txtbx";
            this.lgiIfPw_txtbx.Size = new System.Drawing.Size(224, 32);
            this.lgiIfPw_txtbx.TabIndex = 1;
            this.lgiIfPw_txtbx.TextChanged += new System.EventHandler(this.lgiIfPw_txtbx_TextChanged);
            // 
            // lgiIfShwpw_btn
            // 
            this.lgiIfShwpw_btn.BackColor = System.Drawing.Color.Transparent;
            this.lgiIfShwpw_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lgiIfShwpw_btn.FlatAppearance.BorderSize = 0;
            this.lgiIfShwpw_btn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgiIfShwpw_btn.ForeColor = System.Drawing.Color.Blue;
            this.lgiIfShwpw_btn.Location = new System.Drawing.Point(525, 346);
            this.lgiIfShwpw_btn.Name = "lgiIfShwpw_btn";
            this.lgiIfShwpw_btn.Size = new System.Drawing.Size(94, 21);
            this.lgiIfShwpw_btn.TabIndex = 0;
            this.lgiIfShwpw_btn.Text = "Show password...";
            this.lgiIfShwpw_btn.UseVisualStyleBackColor = false;
            this.lgiIfShwpw_btn.Click += new System.EventHandler(this.lgiIfShwpw_btn_Click);
            // 
            // lgiIfLgi_btn
            // 
            this.lgiIfLgi_btn.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgiIfLgi_btn.Location = new System.Drawing.Point(519, 395);
            this.lgiIfLgi_btn.Name = "lgiIfLgi_btn";
            this.lgiIfLgi_btn.Size = new System.Drawing.Size(100, 44);
            this.lgiIfLgi_btn.TabIndex = 2;
            this.lgiIfLgi_btn.Text = "Log In";
            this.lgiIfLgi_btn.UseVisualStyleBackColor = true;
            this.lgiIfLgi_btn.Click += new System.EventHandler(this.lgiIfLgi_btn_Click);
            // 
            // log_in_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(811, 467);
            this.Controls.Add(this.lgiIfLgi_btn);
            this.Controls.Add(this.lgiIfShwpw_btn);
            this.Controls.Add(this.lgiIfPw_txtbx);
            this.Controls.Add(this.lgiIfUid_cmbx);
            this.Controls.Add(this.lgiIfPw_lbl);
            this.Controls.Add(this.lgiIfUid_lbl);
            this.Controls.Add(this.lgiIfLgi_lbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "log_in_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.Load += new System.EventHandler(this.lgiIf_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lgiIfLgi_lbl;
        private System.Windows.Forms.Label lgiIfUid_lbl;
        private System.Windows.Forms.Label lgiIfPw_lbl;
        private System.Windows.Forms.ComboBox lgiIfUid_cmbx;
        private System.Windows.Forms.TextBox lgiIfPw_txtbx;
        private System.Windows.Forms.Button lgiIfShwpw_btn;
        private System.Windows.Forms.Button lgiIfLgi_btn;
    }
}