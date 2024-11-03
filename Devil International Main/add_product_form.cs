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

namespace Devil_International_Main
{
    public partial class add_product_form : Form
    {
        private string file_path_1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Product Details.txt");

        private string file_path_2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Product Category.txt");

        public add_product_form()
        {
            InitializeComponent();
        }

        private void add_category_button_Click(object sender, EventArgs e)
        {
            product_category_add_form form1 = new product_category_add_form();
            form1.Show();
        }
    }
}
