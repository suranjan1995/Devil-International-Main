namespace Devil_International_Main
{
    partial class massage_box
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(massage_box));
            this.massage_label = new System.Windows.Forms.Label();
            this.chngPwSveMsg_ui_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // massage_label
            // 
            this.massage_label.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.massage_label.ForeColor = System.Drawing.Color.Black;
            this.massage_label.Location = new System.Drawing.Point(23, 35);
            this.massage_label.Name = "massage_label";
            this.massage_label.Size = new System.Drawing.Size(505, 67);
            this.massage_label.TabIndex = 3;
            this.massage_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chngPwSveMsg_ui_btn
            // 
            this.chngPwSveMsg_ui_btn.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chngPwSveMsg_ui_btn.Location = new System.Drawing.Point(236, 119);
            this.chngPwSveMsg_ui_btn.Name = "chngPwSveMsg_ui_btn";
            this.chngPwSveMsg_ui_btn.Size = new System.Drawing.Size(96, 39);
            this.chngPwSveMsg_ui_btn.TabIndex = 4;
            this.chngPwSveMsg_ui_btn.Text = "Ok";
            this.chngPwSveMsg_ui_btn.UseVisualStyleBackColor = true;
            this.chngPwSveMsg_ui_btn.Click += new System.EventHandler(this.chngPwSveMsg_ui_btn_Click);
            // 
            // massage_box
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 184);
            this.Controls.Add(this.chngPwSveMsg_ui_btn);
            this.Controls.Add(this.massage_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "massage_box";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Massage";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button chngPwSveMsg_ui_btn;
        public System.Windows.Forms.Label massage_label;
    }
}