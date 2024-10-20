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
    public partial class add_customer_form : Form
    {
        private string filePath = @"D:\Projects of Visual Studio\Devil International MUI\Customer Details\Customer Details.txt";
        private List<CustomerDetails> customers;
        private ComboBox comboBoxCustomerName;

        public add_customer_form()
        {
            InitializeComponent();

            GenerateCustomerID();

            customer_name_combx.TextChanged += CustomerNameCombx_TextChanged;
            customer_name_combx.SelectedIndexChanged += CustomerNameCombx_SelectedIndexChanged;
            customers = LoadCustomerDetails(@"D:\Projects of Visual Studio\Devil International MUI\Customer Details\Customer Details.txt");
        }

        private void add_customer_ui_Load(object sender, EventArgs e)
        {
            
        }

        private void GenerateCustomerID()
        {
            string customerID = "00001"; // Default ID if file is empty

            if (File.Exists(filePath))
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    if (lines.Length >= 8)
                    {
                        string targetLine = lines[lines.Length - 9];
                        if (targetLine.Length >= 5)
                        {
                            string lastCustomerID = targetLine.Substring(targetLine.Length - 5);
                            if (int.TryParse(lastCustomerID, out int lastID))
                            {
                                int newID = lastID + 1;
                                customerID = newID.ToString("D5"); // Format to 5 digits
                            }
                            else
                            {
                                MessageBox.Show("The last Customer ID in the file is not in the correct format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The target line does not contain enough characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }

            customer_id_txtbx.Text = customerID; // Display the generated ID
        }

        public class CustomerDetails // Search box methord 1
        {
            public string Customer_id { get; set; }
            public string salesrep { get; set; }
            public string Name { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string AddressLine3 { get; set; }
            public string Email { get; set; }
            public string ContactNo { get; set; }
        }

        public List<CustomerDetails> LoadCustomerDetails(string filePath) // Search box methord 2
        {
            var customerList = new List<CustomerDetails>();
            var lines = File.ReadAllLines(filePath);

            for (int i = 3; i < lines.Length -1; i++)
            {
                if (lines[i].StartsWith("Customer Name: "))
                {
                    var customer = new CustomerDetails();
                    
                    customer.Customer_id = lines[i - 2].Split(':')[1].Trim();
                    customer.salesrep = lines[i - 1].Split(':')[1].Trim();
                    customer.Name = lines[i].Split(':')[1].Trim();
                    customer.AddressLine1 = lines[i + 1].Split(':')[1].Trim();
                    customer.AddressLine2 = lines[i + 2].Split(':')[1].Trim();
                    customer.AddressLine3 = lines[i + 3].Split(':')[1].Trim();
                    customer.Email = lines[i + 4].Split(':')[1].Trim();
                    customer.ContactNo = lines[i + 5].Split(':')[1].Trim();
                    customerList.Add(customer);
                    i += 7; // Move to the next customer entry
                }

            }
            return customerList;
        }

        private void CustomerNameCombx_TextChanged(object sender, EventArgs e)
        {
            string searchText = customer_name_combx.Text.ToLower();
            var filteredCustomers = customers.Where(c => c.Name.ToLower().Contains(searchText)).ToList();
            customer_name_combx.Items.Clear();
            customer_name_combx.Items.AddRange(filteredCustomers.Select(c => c.Name).ToArray());
            customer_name_combx.DroppedDown = true;
            customer_name_combx.SelectionStart = searchText.Length;
            customer_name_combx.SelectionLength = 0;
        }

        private void CustomerNameCombx_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCustomer = customers.FirstOrDefault(c => c.Name == customer_name_combx.Text);
            if (selectedCustomer != null)
            {
                customer_id_txtbx.Text = selectedCustomer.Customer_id;
                sales_rep_combx.Text = selectedCustomer.salesrep;
                address_line_1_txtbx.Text = selectedCustomer.AddressLine1;
                address_line_2_txtbx.Text = selectedCustomer.AddressLine2;
                address_line_3_txtbx.Text = selectedCustomer.AddressLine3;
                e_mail_txtbx.Text = selectedCustomer.Email;
                contact_no_txtbx.Text = selectedCustomer.ContactNo;
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            // Find text file to save Customer Details
            String filePath = @"D:\Projects of Visual Studio\Devil International MUI\Customer Details\Customer Details.txt"; 

            string customerID = customer_id_txtbx.Text;
            string sales_rep = sales_rep_combx.Text;
            string customerName = customer_name_combx.Text;
            string addressLine1 = address_line_1_txtbx.Text;
            string addressLine2 = address_line_2_txtbx.Text;
            string addressLine3 = address_line_3_txtbx.Text;
            string email = e_mail_txtbx.Text;
            string contactNo = contact_no_txtbx.Text;

            string tempFile = @"D:\Projects of Visual Studio\Devil International MUI\Customer Details Tempory";  // Temp file for updates
            bool customerExists = false;

            // Read 9 lines at a time and process
            using (StreamReader reader = new StreamReader(filePath))
            using (StreamWriter writer = new StreamWriter(tempFile))
            {
                string line;
                int lineCounter = 0;
                string[] customerBlock = new string[9];  // To store 9 lines per customer

                while ((line = reader.ReadLine()) != null)
                {
                    customerBlock[lineCounter % 9] = line;
                    lineCounter++;

                    // When a full block (9 lines) is read
                    if (lineCounter % 9 == 0)
                    {
                        string customerIdLine = customerBlock[0];  // First line contains the Customer ID
                        string existingCustomerId = customerIdLine.Substring(customerIdLine.Length - 5);  // Extract last 5 characters

                        // Check if the entered Customer ID matches this block's Customer ID
                        if (existingCustomerId == customer_id_txtbx.Text)
                        {
                            // Update the details in the block
                            customerBlock[1] = $"Sales Rep: {sales_rep}";
                            customerBlock[2] = $"Customer Name: {customerName}";
                            customerBlock[3] = $"Address Line 1: {addressLine1}";
                            customerBlock[4] = $"Address Line 2: {addressLine2}";
                            customerBlock[5] = $"Address Line 3: {addressLine3}";
                            customerBlock[6] = $"Email: {email}";
                            customerBlock[7] = $"Contact No: {contactNo}";

                            customerExists = true;  // Mark that the customer exists and was updated
                        }

                        // Write the (updated or unchanged) block back to the temp file
                        foreach (string blockLine in customerBlock)
                        {
                            writer.WriteLine(blockLine);
                        }
                    }
                }
            }

            if (customerExists)
            {
                // Replace the original file with the updated temp file
                File.Delete(filePath);
                File.Move(tempFile, filePath);

                // Display updated succusessfull massage box
                massage_box_form form3 = new massage_box_form();
                form3.Show();
            }

            else
            {
                // If Customer ID not found, add a new customer to the file
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine($"Customer ID: {customerID}");
                    sw.WriteLine($"Sales Rep: {sales_rep}");
                    sw.WriteLine($"Customer Name: {customerName}");
                    sw.WriteLine($"Address Line 1: {addressLine1}");
                    sw.WriteLine($"Address Line 2: {addressLine2}");
                    sw.WriteLine($"Address Line 3: {addressLine3}");
                    sw.WriteLine($"Email: {email}");
                    sw.WriteLine($"Contact No: {contactNo}");
                    sw.WriteLine("------------------------------------------------------------------------------------------------");
                }
                // Display saved succusessfull massage box
                massage_box_form form2 = new massage_box_form();
                form2.Show();
            }

            // Extract the numeric part of the Customer ID
            string numericPart = customerID.Substring(1); // Assuming the prefix is one character long
            int numericId = int.Parse(numericPart);

            // Increment the numeric part
            numericId++;

            // Format the new Customer ID with the prefix and 5-digit numeric part
            customerID = numericId.ToString("D5");

            // Display the new Customer ID
            customer_id_txtbx.Text = customerID;

            // Clear all text boxes
            address_line_1_txtbx.Clear();
            address_line_2_txtbx.Clear();
            address_line_3_txtbx.Clear();
            e_mail_txtbx.Clear();
            contact_no_txtbx.Clear();

            // Clear the text in the ComboBox
            customer_name_combx.Text = string.Empty;
            sales_rep_combx.Text = string.Empty;
        }


    }
}
