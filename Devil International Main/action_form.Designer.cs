namespace Devil_International_Main
{
    partial class action_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(action_form));
            this.action_form_no_button = new System.Windows.Forms.Button();
            this.action_label = new System.Windows.Forms.Label();
            this.action_form_yes_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // action_form_no_button
            // 
            this.action_form_no_button.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.action_form_no_button.Location = new System.Drawing.Point(139, 119);
            this.action_form_no_button.Name = "action_form_no_button";
            this.action_form_no_button.Size = new System.Drawing.Size(96, 39);
            this.action_form_no_button.TabIndex = 5;
            this.action_form_no_button.Text = "No";
            this.action_form_no_button.UseVisualStyleBackColor = true;
            this.action_form_no_button.Click += new System.EventHandler(this.action_form_no_button_Click);
            // 
            // action_label
            // 
            this.action_label.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.action_label.ForeColor = System.Drawing.Color.Black;
            this.action_label.Location = new System.Drawing.Point(23, 35);
            this.action_label.Name = "action_label";
            this.action_label.Size = new System.Drawing.Size(505, 67);
            this.action_label.TabIndex = 6;
            this.action_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // action_form_yes_button
            // 
            this.action_form_yes_button.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.action_form_yes_button.Location = new System.Drawing.Point(315, 119);
            this.action_form_yes_button.Name = "action_form_yes_button";
            this.action_form_yes_button.Size = new System.Drawing.Size(96, 39);
            this.action_form_yes_button.TabIndex = 5;
            this.action_form_yes_button.Text = "Yes";
            this.action_form_yes_button.UseVisualStyleBackColor = true;
            this.action_form_yes_button.Click += new System.EventHandler(this.action_form_yes_button_Click);
            // 
            // action_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 184);
            this.Controls.Add(this.action_label);
            this.Controls.Add(this.action_form_yes_button);
            this.Controls.Add(this.action_form_no_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "action_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yes or No";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button action_form_no_button;
        public System.Windows.Forms.Label action_label;
        private System.Windows.Forms.Button action_form_yes_button;
    }
}