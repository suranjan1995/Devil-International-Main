namespace Devil_International_Main
{
    partial class product_category_add_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(product_category_add_form));
            this.add_product_here_label = new System.Windows.Forms.Label();
            this.category_level_label = new System.Windows.Forms.Label();
            this.category_level_combo_box = new System.Windows.Forms.ComboBox();
            this.category_name_label = new System.Windows.Forms.Label();
            this.category_name_text_box = new System.Windows.Forms.TextBox();
            this.save_button = new System.Windows.Forms.Button();
            this.Delete_button = new System.Windows.Forms.Button();
            this.category_number_text_box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // add_product_here_label
            // 
            this.add_product_here_label.AutoSize = true;
            this.add_product_here_label.BackColor = System.Drawing.Color.Transparent;
            this.add_product_here_label.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_product_here_label.ForeColor = System.Drawing.Color.Red;
            this.add_product_here_label.Location = new System.Drawing.Point(12, 9);
            this.add_product_here_label.Name = "add_product_here_label";
            this.add_product_here_label.Size = new System.Drawing.Size(496, 54);
            this.add_product_here_label.TabIndex = 2;
            this.add_product_here_label.Text = "Add Product Category...";
            // 
            // category_level_label
            // 
            this.category_level_label.AutoSize = true;
            this.category_level_label.BackColor = System.Drawing.Color.Transparent;
            this.category_level_label.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_level_label.ForeColor = System.Drawing.Color.White;
            this.category_level_label.Location = new System.Drawing.Point(16, 108);
            this.category_level_label.Name = "category_level_label";
            this.category_level_label.Size = new System.Drawing.Size(156, 25);
            this.category_level_label.TabIndex = 3;
            this.category_level_label.Text = "Category Level";
            // 
            // category_level_combo_box
            // 
            this.category_level_combo_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.category_level_combo_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.category_level_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.category_level_combo_box.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_level_combo_box.FormattingEnabled = true;
            this.category_level_combo_box.Items.AddRange(new object[] {
            "Level 1",
            "Level 2",
            "Level 3",
            "Level 4",
            "Level 5"});
            this.category_level_combo_box.Location = new System.Drawing.Point(205, 101);
            this.category_level_combo_box.Name = "category_level_combo_box";
            this.category_level_combo_box.Size = new System.Drawing.Size(204, 32);
            this.category_level_combo_box.TabIndex = 20;
            this.category_level_combo_box.SelectedIndexChanged += new System.EventHandler(this.category_level_combo_box_SelectedIndexChanged);
            // 
            // category_name_label
            // 
            this.category_name_label.AutoSize = true;
            this.category_name_label.BackColor = System.Drawing.Color.Transparent;
            this.category_name_label.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_name_label.ForeColor = System.Drawing.Color.White;
            this.category_name_label.Location = new System.Drawing.Point(12, 163);
            this.category_name_label.Name = "category_name_label";
            this.category_name_label.Size = new System.Drawing.Size(158, 25);
            this.category_name_label.TabIndex = 3;
            this.category_name_label.Text = "Category Name";
            // 
            // category_name_text_box
            // 
            this.category_name_text_box.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_name_text_box.Location = new System.Drawing.Point(205, 156);
            this.category_name_text_box.Name = "category_name_text_box";
            this.category_name_text_box.Size = new System.Drawing.Size(348, 32);
            this.category_name_text_box.TabIndex = 21;
            // 
            // save_button
            // 
            this.save_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.save_button.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_button.Location = new System.Drawing.Point(452, 246);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(101, 57);
            this.save_button.TabIndex = 22;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = false;
            this.save_button.Click += new System.EventHandler(this.save_button_click);
            // 
            // Delete_button
            // 
            this.Delete_button.BackColor = System.Drawing.Color.OrangeRed;
            this.Delete_button.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_button.Location = new System.Drawing.Point(313, 256);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(96, 47);
            this.Delete_button.TabIndex = 23;
            this.Delete_button.Text = "Delete";
            this.Delete_button.UseVisualStyleBackColor = false;
            this.Delete_button.Click += new System.EventHandler(this.delete_button_click);
            // 
            // category_number_text_box
            // 
            this.category_number_text_box.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_number_text_box.Location = new System.Drawing.Point(493, 101);
            this.category_number_text_box.Name = "category_number_text_box";
            this.category_number_text_box.Size = new System.Drawing.Size(60, 32);
            this.category_number_text_box.TabIndex = 24;
            this.category_number_text_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.category_number_text_box.TextChanged += new System.EventHandler(this.category_number_text_box_TextChanged);
            // 
            // product_category_add_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Devil_International_Main.Properties.Resources.add_product_wallpaper;
            this.ClientSize = new System.Drawing.Size(572, 338);
            this.Controls.Add(this.category_number_text_box);
            this.Controls.Add(this.Delete_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.category_name_text_box);
            this.Controls.Add(this.category_level_combo_box);
            this.Controls.Add(this.category_name_label);
            this.Controls.Add(this.category_level_label);
            this.Controls.Add(this.add_product_here_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "product_category_add_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product Category";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label add_product_here_label;
        private System.Windows.Forms.Label category_level_label;
        private System.Windows.Forms.ComboBox category_level_combo_box;
        private System.Windows.Forms.Label category_name_label;
        private System.Windows.Forms.TextBox category_name_text_box;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button Delete_button;
        private System.Windows.Forms.TextBox category_number_text_box;
    }
}