using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devil_International_Main
{
    public partial class main_form_1 : Form
    {
        
        private Color originalColor;

        private bool isTabChanging = false;

        public main_form_1()
        {
            InitializeComponent();

            AttachHoverEventsToButtons();

            AttachTabEventsToButtons();
        }

        private void AttachHoverEventsToButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.MouseEnter += Button_MouseEnter;
                    button.MouseLeave += Button_MouseLeave;
                }
            }
        }

        private void AttachTabEventsToButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Enter += Button_Enter;
                    button.Leave += Button_Leave;
                }
            }
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (!isTabChanging)
            {
                if (sender is Button button)
                {
                    originalColor = button.BackColor;
                    button.BackColor = Color.Red; // Change to your desired highlight color
                }
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (!isTabChanging)
            {
                if (sender is Button button)
                {
                    button.BackColor = originalColor;
                }
            }
        }

        private void Button_Enter(object sender, EventArgs e)
        {
            isTabChanging = true;
            if (sender is Button button)
            {
                originalColor = button.BackColor;
                button.BackColor = Color.Red; // Change to your desired color for tab change
            }
            isTabChanging = false;
        }

        private void Button_Leave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = originalColor;
            }
        }

        private void muiMngr_btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            log_in_form form2 = new log_in_form("Manager");

            // Show the new form
            form2.Show();
        }

        private void muiDorad_btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            log_in_form form2 = new log_in_form("Research & Development");

            // Show the new form
            form2.Show();
        }

        private void muiDol_btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            log_in_form form2 = new log_in_form("Legal");

            // Show the new form
            form2.Show();
        }

        private void muiDos_btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            log_in_form form2 = new log_in_form("Sales");

            // Show the new form
            form2.Show();
        }

        private void muiDopp_btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            log_in_form form2 = new log_in_form("Purchasing & Procurement");

            // Show the new form
            form2.Show();
        }

        private void muiDohr_btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            log_in_form form2 = new log_in_form("Human Resorces");

            // Show the new form
            form2.Show();
        }

        private void muiDoo_btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            log_in_form form2 = new log_in_form("Operations");

            // Show the new form
            form2.Show();
        }

        private void muiDom_btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            log_in_form form2 = new log_in_form("Marketig");

            // Show the new form
            form2.Show();
        }

        private void muiDocs_btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            log_in_form form2 = new log_in_form("Customer Service");

            // Show the new form
            form2.Show();
        }

        private void muiDof_btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            log_in_form form2 = new log_in_form("Finance");

            // Show the new form
            form2.Show();
        }

        private void muiDoit_btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            log_in_form form2 = new log_in_form("Information Technology");

            // Show the new form
            form2.Show();
        }

        private void muiDoa_btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            log_in_form form2 = new log_in_form("Administrative");

            // Show the new form
            form2.Show();
        }

    }
}
