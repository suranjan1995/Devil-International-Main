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
    public partial class settings_form : Form
    {
        private Color originalColor;

        public settings_form()
        {
            InitializeComponent();
            AttachHoverEventsToButtons();
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

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                originalColor = button.BackColor;
                button.BackColor = Color.DarkSlateBlue; // Change to your desired highlight color
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = originalColor;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void stngUi_Load(object sender, EventArgs e)
        {

        }

        private void stngUiChngPw_btn_Click(object sender, EventArgs e)
        {
            change_password_form form2 = new change_password_form();
            form2.Show();
        }
    }
}
