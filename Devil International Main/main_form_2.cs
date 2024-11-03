using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Devil_International_Main

{
    public partial class main_form_2 : Form
    {

        private int originalFormWidth;
        private int originalFormHeight;
        private Dictionary<Control, Rectangle> originalControlBounds;


        public main_form_2()
        {
            InitializeComponent();

            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;

            muif_2Tmr.Interval = 1000; // Set the timer interval to 1 second
            muif_2Tmr.Tick += new EventHandler(muif_2Tmr_Tick); // Link the Tick event to the event handler
            muif_2Tmr.Start(); // Start the timer
        }

       
        private void MainForm_Load(object sender, EventArgs e)
        {

            originalFormWidth = this.Width;
            originalFormHeight = this.Height;
            originalControlBounds = new Dictionary<Control, Rectangle>();

            foreach (Control control in this.Controls)
            {
            originalControlBounds[control] = control.Bounds;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            float widthRatio = (float)this.Width / originalFormWidth;
            float heightRatio = (float)this.Height / originalFormHeight;

            foreach (Control control in this.Controls)
            {
                Rectangle originalBounds = originalControlBounds[control];
                control.SetBounds(
                    (int)(originalBounds.X * widthRatio),
                    (int)(originalBounds.Y * heightRatio),
                    (int)(originalBounds.Width * widthRatio),
                    (int)(originalBounds.Height * heightRatio)
                );
            }
        }

        private void muif_2Tmr_Tick(object sender, EventArgs e)
        {
            muif_2Tm_lbl.Text = DateTime.Now.ToString("HH:mm:ss"); // Update the TextBox with the current time
            muif_2Dt_lbl.Text = DateTime.Now.ToString("yyyy-MM-dd"); // Update the second TextBox with the current date
        }

        private void muif_2stng_btn_Click(object sender, EventArgs e)
        {
            settings_form form2 = new settings_form();
            form2.Show();  
        }

        private void muif_2_Load(object sender, EventArgs e)
        {

        }

        private void transectionsInterBranchesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void planingOutstandingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void muif_2Dte_txtbx_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Child Window " + this.MdiChildren.Length;
            childForm.Show();
        }

        private void addCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            add_customer_form form3 = new add_customer_form();
            form3.Show();
        }

        private void addProductToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            add_product_form form4 = new add_product_form();
            form4.Show();
        }
    }
}
