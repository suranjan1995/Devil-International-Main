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
using static System.Net.Mime.MediaTypeNames;

namespace Devil_International_Main
{
    public partial class change_password_form : Form
    {
        public change_password_form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void chngPwUiNpw_txtbx_TextChanged(object sender, EventArgs e)
        {
            chngPwUiNpw_txtbx.UseSystemPasswordChar = true;

        }

        private void chngPwUiNpwa_txtbx_TextChanged(object sender, EventArgs e)
        {
            chngPwUiNpwa_txtbx.UseSystemPasswordChar = true;
        }

        private void lgiIfShwpw_btn_Click(object sender, EventArgs e)
        {
            // Toggle the UseSystemPasswordChar property
            chngPwUiNpw_txtbx.UseSystemPasswordChar = !chngPwUiNpw_txtbx.UseSystemPasswordChar;

            // Optionally, change the button text to indicate the current state
            if (chngPwUiNpw_txtbx.UseSystemPasswordChar)
            {
                chngPwUiShwpw_btn.Text = "Show Password";
            }
            else
            {
                chngPwUiShwpw_btn.Text = "Hide Password";
            }

            // Toggle the UseSystemPasswordChar property
            chngPwUiNpwa_txtbx.UseSystemPasswordChar = !chngPwUiNpwa_txtbx.UseSystemPasswordChar;

            // Optionally, change the button text to indicate the current state
            if (chngPwUiNpwa_txtbx.UseSystemPasswordChar)
            {
                chngPwUiShwpw_btn.Text = "Show Password";
            }
            else
            {
                chngPwUiShwpw_btn.Text = "Hide Password";
            }
        }

        private void chngPwUiSve_btn_Click(object sender, EventArgs e)
        {
            string userId = chngPwUiUid_cmbx.Text;
            string oldPassword = chngPwUiOpw_txtbx.Text;
            string newPassword = chngPwUiNpw_txtbx.Text;
            string confirmPassword = chngPwUiNpwa_txtbx.Text;
            string filePath = @"D:\Projects of Visual Studio\Devil International MUI\Save Passward\Save Passward.txt"; // Change to your file path

            // Check if new passwords match
            if (newPassword != confirmPassword)
            {
                error_massage_box_form form1 = new error_massage_box_form();
                form1.Show();
                return;
            }

            // Read the file and check for the user ID
            bool userExists = false;
            string existingPassword = "";
            List<string> lines = new List<string>();

            if (File.Exists(filePath))
            {
                lines = File.ReadAllLines(filePath).ToList();
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts[0] == userId)
                    {
                        userExists = true;
                        existingPassword = parts[1];
                        break;
                    }
                }
            }

            // If user ID exists, check the old password
            if (userExists)
            {
                if (oldPassword != existingPassword)
                {
                    change_password_form form2 = new change_password_form();
                    form2.Show();
                    return;
                }
                else
                {
                    // Update the password
                    for (int i = 0; i < lines.Count; i++)
                    {
                        string[] parts = lines[i].Split(',');
                        if (parts[0] == userId)
                        {
                            lines[i] = $"{userId},{newPassword}";
                            break;
                        }
                    }
                    File.WriteAllLines(filePath, lines);
                    massage_box_form form1 = new massage_box_form();
                    form1.Show();
                }
            }
            else
            {
                // Save the new user ID and password
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine($"{userId},{newPassword}");
                }
                massage_box_form form1 = new massage_box_form();
                form1.Show();
            }


            // Clear all text boxes
            chngPwUiOpw_txtbx.Clear();
            chngPwUiNpw_txtbx.Clear();
            chngPwUiNpwa_txtbx.Clear();

        }

        private void change_password_form_Load(object sender, EventArgs e)
        {

        }
    }
}
