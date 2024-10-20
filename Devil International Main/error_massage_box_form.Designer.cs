namespace Devil_International_Main
{
    partial class error_massage_box_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(error_massage_box_form));
            this.chngPwSveEr1_ui_pcbx = new System.Windows.Forms.PictureBox();
            this.chngPwSveEr1_ui_lbl = new System.Windows.Forms.Label();
            this.chngPwSveEr1_ui_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chngPwSveEr1_ui_pcbx)).BeginInit();
            this.SuspendLayout();
            // 
            // chngPwSveEr1_ui_pcbx
            // 
            this.chngPwSveEr1_ui_pcbx.BackColor = System.Drawing.Color.Transparent;
            this.chngPwSveEr1_ui_pcbx.Image = ((System.Drawing.Image)(resources.GetObject("chngPwSveEr1_ui_pcbx.Image")));
            this.chngPwSveEr1_ui_pcbx.Location = new System.Drawing.Point(22, 43);
            this.chngPwSveEr1_ui_pcbx.Name = "chngPwSveEr1_ui_pcbx";
            this.chngPwSveEr1_ui_pcbx.Size = new System.Drawing.Size(59, 49);
            this.chngPwSveEr1_ui_pcbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.chngPwSveEr1_ui_pcbx.TabIndex = 0;
            this.chngPwSveEr1_ui_pcbx.TabStop = false;
            // 
            // chngPwSveEr1_ui_lbl
            // 
            this.chngPwSveEr1_ui_lbl.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chngPwSveEr1_ui_lbl.ForeColor = System.Drawing.Color.Red;
            this.chngPwSveEr1_ui_lbl.Location = new System.Drawing.Point(95, 43);
            this.chngPwSveEr1_ui_lbl.Name = "chngPwSveEr1_ui_lbl";
            this.chngPwSveEr1_ui_lbl.Size = new System.Drawing.Size(427, 49);
            this.chngPwSveEr1_ui_lbl.TabIndex = 1;
            this.chngPwSveEr1_ui_lbl.Text = "Password you enterd is not equal...!";
            this.chngPwSveEr1_ui_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chngPwSveEr1_ui_btn
            // 
            this.chngPwSveEr1_ui_btn.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chngPwSveEr1_ui_btn.Location = new System.Drawing.Point(236, 119);
            this.chngPwSveEr1_ui_btn.Name = "chngPwSveEr1_ui_btn";
            this.chngPwSveEr1_ui_btn.Size = new System.Drawing.Size(96, 39);
            this.chngPwSveEr1_ui_btn.TabIndex = 2;
            this.chngPwSveEr1_ui_btn.Text = "Ok";
            this.chngPwSveEr1_ui_btn.UseVisualStyleBackColor = true;
            this.chngPwSveEr1_ui_btn.Click += new System.EventHandler(this.chngPwSveEr1_ui_btn_Click);
            // 
            // error_massage_box_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 184);
            this.Controls.Add(this.chngPwSveEr1_ui_btn);
            this.Controls.Add(this.chngPwSveEr1_ui_lbl);
            this.Controls.Add(this.chngPwSveEr1_ui_pcbx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "error_massage_box_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            ((System.ComponentModel.ISupportInitialize)(this.chngPwSveEr1_ui_pcbx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox chngPwSveEr1_ui_pcbx;
        private System.Windows.Forms.Label chngPwSveEr1_ui_lbl;
        private System.Windows.Forms.Button chngPwSveEr1_ui_btn;
    }
}