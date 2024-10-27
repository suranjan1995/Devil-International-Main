using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Devil_International_Main
{
    public partial class log_in_form : Form
    {
        public log_in_form(string selectedItem)
        {
            InitializeComponent();

            lgiIfUid_cmbx.SelectedItem = selectedItem;
        }

        private void log_in_form_Load(object sender, EventArgs e)
        {
            lgiIfPw_txtbx.Focus();
            lgiIfPw_txtbx.Select();
        }

        private void lgiIfUid_cmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lgiIfUid_cmbx.Items.AddRange(new object[] {"Manager"});
        }

        private void lgiIfPw_txtbx_TextChanged(object sender, EventArgs e)
        {
            lgiIfPw_txtbx.UseSystemPasswordChar = true;
        }

        private void lgiIfShwpw_btn_Click(object sender, EventArgs e)
        {
            // Toggle the UseSystemPasswordChar property
            lgiIfPw_txtbx.UseSystemPasswordChar = !lgiIfPw_txtbx.UseSystemPasswordChar;

            // Optionally, change the button text to indicate the current state
            if (lgiIfPw_txtbx.UseSystemPasswordChar)
            {
                lgiIfShwpw_btn.Text = "Show Password";
            }
            else
            {
                lgiIfShwpw_btn.Text = "Hide Password";
            }
        }

        private void lgiIfLgi_btn_Click(object sender, EventArgs e)
        {

            string userId = lgiIfUid_cmbx.Text;
            string password = lgiIfPw_txtbx.Text;
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Save Passward.txt"); // Change to your file path

            // Read the file and check for the user ID and password
            bool loginSuccess = false;
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath); 
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts[0] == userId && parts[1] == password)
                    {
                        loginSuccess = true;
                        break;
                    }
                }
            }

            if (loginSuccess)
            {
                main_form_2 form3 = new main_form_2();
                form3.Show();
                this.Close(); // Close the login form
            }
            else
            {
                error_massage_box form4 = new error_massage_box();
                form4.error_massage_label.Text = "Invaild username or password. Please try again.";
                form4.Show();
            }
        }
    }
}
