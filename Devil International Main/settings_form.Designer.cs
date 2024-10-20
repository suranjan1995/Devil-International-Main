namespace Devil_International_Main
{
    partial class settings_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settings_form));
            this.stngUiChngPw_btn = new System.Windows.Forms.Button();
            this.stngUiAcssCntrl_btn = new System.Windows.Forms.Button();
            this.stngUiCmpnyNme_btn = new System.Windows.Forms.Button();
            this.stngUiChngPrc_btn = new System.Windows.Forms.Button();
            this.stngUiAdDscnt_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stngUiChngPw_btn
            // 
            this.stngUiChngPw_btn.BackColor = System.Drawing.Color.Maroon;
            this.stngUiChngPw_btn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stngUiChngPw_btn.ForeColor = System.Drawing.Color.White;
            this.stngUiChngPw_btn.Location = new System.Drawing.Point(169, 374);
            this.stngUiChngPw_btn.Name = "stngUiChngPw_btn";
            this.stngUiChngPw_btn.Size = new System.Drawing.Size(206, 44);
            this.stngUiChngPw_btn.TabIndex = 2;
            this.stngUiChngPw_btn.Text = "Change Password";
            this.stngUiChngPw_btn.UseVisualStyleBackColor = false;
            this.stngUiChngPw_btn.Click += new System.EventHandler(this.stngUiChngPw_btn_Click);
            // 
            // stngUiAcssCntrl_btn
            // 
            this.stngUiAcssCntrl_btn.BackColor = System.Drawing.Color.Maroon;
            this.stngUiAcssCntrl_btn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stngUiAcssCntrl_btn.ForeColor = System.Drawing.Color.White;
            this.stngUiAcssCntrl_btn.Location = new System.Drawing.Point(104, 312);
            this.stngUiAcssCntrl_btn.Name = "stngUiAcssCntrl_btn";
            this.stngUiAcssCntrl_btn.Size = new System.Drawing.Size(206, 44);
            this.stngUiAcssCntrl_btn.TabIndex = 1;
            this.stngUiAcssCntrl_btn.Text = "Acsess Control";
            this.stngUiAcssCntrl_btn.UseVisualStyleBackColor = false;
            // 
            // stngUiCmpnyNme_btn
            // 
            this.stngUiCmpnyNme_btn.BackColor = System.Drawing.Color.Maroon;
            this.stngUiCmpnyNme_btn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stngUiCmpnyNme_btn.ForeColor = System.Drawing.Color.White;
            this.stngUiCmpnyNme_btn.Location = new System.Drawing.Point(30, 248);
            this.stngUiCmpnyNme_btn.Name = "stngUiCmpnyNme_btn";
            this.stngUiCmpnyNme_btn.Size = new System.Drawing.Size(206, 44);
            this.stngUiCmpnyNme_btn.TabIndex = 0;
            this.stngUiCmpnyNme_btn.Text = "Company Name";
            this.stngUiCmpnyNme_btn.UseVisualStyleBackColor = false;
            this.stngUiCmpnyNme_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // stngUiChngPrc_btn
            // 
            this.stngUiChngPrc_btn.BackColor = System.Drawing.Color.Maroon;
            this.stngUiChngPrc_btn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stngUiChngPrc_btn.ForeColor = System.Drawing.Color.White;
            this.stngUiChngPrc_btn.Location = new System.Drawing.Point(250, 443);
            this.stngUiChngPrc_btn.Name = "stngUiChngPrc_btn";
            this.stngUiChngPrc_btn.Size = new System.Drawing.Size(206, 44);
            this.stngUiChngPrc_btn.TabIndex = 3;
            this.stngUiChngPrc_btn.Text = "Change Price";
            this.stngUiChngPrc_btn.UseVisualStyleBackColor = false;
            // 
            // stngUiAdDscnt_btn
            // 
            this.stngUiAdDscnt_btn.BackColor = System.Drawing.Color.Maroon;
            this.stngUiAdDscnt_btn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stngUiAdDscnt_btn.ForeColor = System.Drawing.Color.White;
            this.stngUiAdDscnt_btn.Location = new System.Drawing.Point(324, 508);
            this.stngUiAdDscnt_btn.Name = "stngUiAdDscnt_btn";
            this.stngUiAdDscnt_btn.Size = new System.Drawing.Size(206, 44);
            this.stngUiAdDscnt_btn.TabIndex = 4;
            this.stngUiAdDscnt_btn.Text = "Add Discount";
            this.stngUiAdDscnt_btn.UseVisualStyleBackColor = false;
            // 
            // settings_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(580, 634);
            this.Controls.Add(this.stngUiCmpnyNme_btn);
            this.Controls.Add(this.stngUiAcssCntrl_btn);
            this.Controls.Add(this.stngUiAdDscnt_btn);
            this.Controls.Add(this.stngUiChngPrc_btn);
            this.Controls.Add(this.stngUiChngPw_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "settings_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.stngUi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button stngUiChngPw_btn;
        private System.Windows.Forms.Button stngUiAcssCntrl_btn;
        private System.Windows.Forms.Button stngUiCmpnyNme_btn;
        private System.Windows.Forms.Button stngUiChngPrc_btn;
        private System.Windows.Forms.Button stngUiAdDscnt_btn;
    }
}