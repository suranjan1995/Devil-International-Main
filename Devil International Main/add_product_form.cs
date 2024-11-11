using DocumentFormat.OpenXml.ExtendedProperties;
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
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace Devil_International_Main
{
    public partial class add_product_form : Form
    {
        private string file_path_1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Product Details.txt");

        private string file_path_2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Product Category.txt");

        private Dictionary<string, List<string>> categories;

        public add_product_form()
        {
            InitializeComponent();

            LoadCategories(); 
            
            PopulateComboBoxes();

            LoadAllProductNames(); 
        }

        private void LoadCategories() // Load categories to combo box calculation method 
        {
            categories = new Dictionary<string, List<string>>(); 
            string currentLevel = null;
            string filePath = file_path_2;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (line.StartsWith("Level"))
                {
                    currentLevel = line.TrimEnd(';'); 
                    categories[currentLevel] = new List<string>();
                }

                else if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("-"))
                {
                    categories[currentLevel].Add(line.Trim());
                }
            }
        }

        private void PopulateComboBoxes() // Load categories to dropdown box
        {
            if (categories.ContainsKey("Level 1"))
                level_1_combo_box.Items.AddRange(categories["Level 1"].ToArray());

            if (categories.ContainsKey("Level 2"))
                level_2_combo_box.Items.AddRange(categories["Level 2"].ToArray());

            if (categories.ContainsKey("Level 3"))
                level_3_combo_box.Items.AddRange(categories["Level 3"].ToArray());

            if (categories.ContainsKey("Level 4"))
                level_4_combo_box.Items.AddRange(categories["Level 4"].ToArray());

            if (categories.ContainsKey("Level 5"))
                level_5_combo_box.Items.AddRange(categories["Level 5"].ToArray());
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e) // Genarate Product ID method 1
        { 
            GenerateProductID(); 
        }

        private string GetSelectedNumbers(ComboBox comboBox) // Genarate Product ID method 2
        {
            if (comboBox.SelectedItem != null)
            {
                return comboBox.SelectedItem.ToString().Split('.')[0];
            }

            return string.Empty;
        }

        private void GenerateProductID() // Genarate Product ID method 3
        {
            string level1Number = GetSelectedNumbers(level_1_combo_box); 
            string level2Number = GetSelectedNumbers(level_2_combo_box); 
            string level3Number = GetSelectedNumbers(level_3_combo_box); 
            string level4Number = GetSelectedNumbers(level_4_combo_box);
            string level5Number = GetSelectedNumbers(level_5_combo_box);

            string selectedComboBoxNumbers = $"{level1Number}.{level2Number}.{level3Number}.{level4Number}.{level5Number}".Trim('.');

            string filePath = file_path_1; 
            string categoryToFind = level_1_combo_box.Text; // Adjust as necessary

            string lastNumber = "001"; // Default starting number in case we don't find any prior entries

            string[] lines = File.ReadAllLines(filePath); 
            bool categoryFound = false;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(categoryToFind))
                {
                    categoryFound = true;
                }

                if (categoryFound && lines[i].StartsWith("*"))
                {
                    string previousLine = lines[i - 12]; 
                    string[] parts = previousLine.Split(','); 
                    string[] subParts = parts[0].Split('.');

                    if (subParts.Length > 1)
                    {
                        string numberStr = subParts[subParts.Length - 1].Trim();
                        int number = int.Parse(numberStr); 
                        number++; 
                        
                        lastNumber = number.ToString("D3"); // Ensuring it's 3 digits
                    }
                    break;
                }
            }

            product_id_text_box.Text = $"{selectedComboBoxNumbers}.{lastNumber}";
        }

        private void LoadAllProductNames()
        {
            // Step 1: Set the file path
            string filePath = file_path_1; // Replace with your actual file path

            // Step 2: Clear the existing items in the combo box
            product_name_combo_box.Items.Clear();

            // Step 3: Read all lines from the file
            var lines = File.ReadAllLines(filePath).ToList();

            // Step 4: Loop through all lines in the file
            foreach (string line in lines)
            {
                // Step 5: Check for "Product Name:" in each line
                if (line.StartsWith("Product Name: "))
                {
                    // Extract the product name and add it to the combo box
                    string productName = line.Substring("Product Name: ".Length);
                    product_name_combo_box.Items.Add(productName);
                }
            }

            // Optional: Set the first item as the selected item
            if (product_name_combo_box.Items.Count > 0)
            {
                product_name_combo_box.SelectedIndex = -1;
            }
        }

        private void product_name_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Temporarily disable the SelectedIndexChanged event for the ComboBox you want to bypass
            level_1_combo_box.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;  // Unsubscribe from the event
            level_2_combo_box.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
            level_3_combo_box.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
            level_4_combo_box.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
            level_5_combo_box.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;

            try
            {
                // Your logic for handling the product_name_combo_box selection
                string selectedProductName = product_name_combo_box.SelectedItem.ToString();

                // Load the product details based on the selected product name
                LoadProductDetails(selectedProductName);
            }
            finally
            {
                // Re-enable the SelectedIndexChanged event for the ComboBox
                level_1_combo_box.SelectedIndexChanged += ComboBox_SelectedIndexChanged;  // Re-subscribe to the event
                level_2_combo_box.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                level_3_combo_box.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                level_4_combo_box.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                level_5_combo_box.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
        }


        private void LoadProductDetails(string productName)
        {
            // Step 1: Set the file path
            string filePath = file_path_1; // Replace with your actual file path

            // Step 2: Read all lines from the file
            var lines = File.ReadAllLines(filePath).ToList();

            // Step 3: Find the product block based on the product name
            bool productFound = false;
            for (int i = 0; i < lines.Count; i++)
            {
                // Look for the line that matches "Product Name: <selected product>"
                if (lines[i].Contains("Product Name: " + productName))
                {
                    productFound = true;

                    // Step 4: Extract product details from the lines below the "Product Name" line
                    string productId = "", costPrice = "", discount = "", retailPrice = "", wholesalePrice = "",
                           level1 = "", level2 = "", level3 = "", level4 = "", level5 = "";

                    // Start reading from the current line to the next few lines to get all details
                    for (int j = i - 1; j < i + 10 && j < lines.Count; j++)
                    {
                        if (lines[j].StartsWith("Product ID: "))
                            productId = lines[j].Substring("Product ID: ".Length);
                        if (lines[j].StartsWith("Cost Price: "))
                            costPrice = lines[j].Substring("Cost Price: ".Length);
                        if (lines[j].StartsWith("Discount: "))
                            discount = lines[j].Substring("Discount: ".Length);
                        if (lines[j].StartsWith("Retail Price: "))
                            retailPrice = lines[j].Substring("Retail Price: ".Length);
                        if (lines[j].StartsWith("Wholesale Price: "))
                            wholesalePrice = lines[j].Substring("Wholesale Price: ".Length);
                        if (lines[j].StartsWith("Level 1: "))
                            level1 = lines[j].Substring("Level 1: ".Length);
                        if (lines[j].StartsWith("Level 2: "))
                            level2 = lines[j].Substring("Level 2: ".Length);
                        if (lines[j].StartsWith("Level 3: "))
                            level3 = lines[j].Substring("Level 3: ".Length);
                        if (lines[j].StartsWith("Level 4: "))
                            level4 = lines[j].Substring("Level 4: ".Length);
                        if (lines[j].StartsWith("Level 5: "))
                            level5 = lines[j].Substring("Level 5: ".Length);

                        // Break the loop once we encounter the line with "-" separator or "*"
                        if (lines[j].StartsWith("-") || lines[j].StartsWith("*"))
                            break;
                    }

                    // Step 5: Populate the relevant text boxes with the extracted details
                    product_id_text_box.Text = productId;
                    cost_price_text_box.Text = costPrice;
                    discount_text_box.Text = discount;
                    retail_price_text_box.Text = retailPrice;
                    wholesale_price_text_box.Text = wholesalePrice;
                    level_1_combo_box.Text = level1;
                    level_2_combo_box.Text = level2;
                    level_3_combo_box.Text = level3;
                    level_4_combo_box.Text = level4;
                    level_5_combo_box.Text = level5;

                    break;  // Exit the loop once the product is found and details are loaded
                }
            }

            // If the product is not found, display a message
            if (!productFound)
            {
                MessageBox.Show("Product details not found.");
            }
        }


        private void ProductNameComboBox_Leave(object sender, EventArgs e) // Convert 1st letter to capital
        {
            if (!string.IsNullOrWhiteSpace(product_name_combo_box.Text))
            {
                // Capitalize the first letter of the product name
                product_name_combo_box.Text = char.ToUpper(product_name_combo_box.Text[0]) + product_name_combo_box.Text.Substring(1);
            }
        }

        private void PriceTextBox_Leave(object sender, EventArgs e) // Set price format "0,000.00"
        {
            TextBox textBox = sender as TextBox;

            if (decimal.TryParse(textBox.Text, out decimal value))
            {
                textBox.Text = value.ToString("N2"); // Format as a number with 2 decimal places
                textBox.SelectionStart = textBox.Text.Length; // Keep cursor at the end
            }
        }

        private void DiscountTextBox_Leave(object sender, EventArgs e) // Set discount format "00.00%"
        {
            if (decimal.TryParse(discount_text_box.Text, out decimal value))
            {                            
                if (value > 100)
                {
                    // Error massage box show
                    error_massage_box form1 = new error_massage_box();
                    form1.error_massage_label.Text = "Discount value over than 100. Please enter a valid discount";
                    form1.Show();
                }

                else
                {
                    discount_text_box.Text = value.ToString("F2") + "%"; // Format as percentage with 2 decimal places
                    discount_text_box.SelectionStart = discount_text_box.Text.Length; // Keep cursor at the end
                }               
            }
        }

        private void add_category_button_Click(object sender, EventArgs e) // Load add category form
        {
            product_category_add_form form1 = new product_category_add_form();
            form1.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Step 1: Check if "Product ID" is empty
            if (string.IsNullOrWhiteSpace(product_id_text_box.Text))
            {
                error_massage_box form2 = new error_massage_box();
                form2.error_massage_label.Text = "Please select product category...!";
                form2.Show();
                return;
            }

            // Step 2: Check if "Product Name" is empty
            if (string.IsNullOrWhiteSpace(product_name_combo_box.Text))
            {
                error_massage_box form3 = new error_massage_box();
                form3.error_massage_label.Text = "Please enter a valid product name...!";
                form3.Show();
                return;
            }

            // Step 3: Set the file path
            string filePath = file_path_1; // Replace with your actual file path

            // Step 4: Read all lines from the file
            var lines = File.ReadAllLines(filePath).ToList();

            // Step 5: Find the line matching the category level (Level 1)
            string categoryStartLine = level_1_combo_box.Text;
            int categoryStartIndex = lines.FindIndex(line => line.Equals(categoryStartLine, StringComparison.OrdinalIgnoreCase));

            // Step 9: If category is not found, create new category
            if (categoryStartIndex == -1)
            {
                // Show comformation box
                action_form form4 = new action_form();
                form4.action_label.Text = "Are you sure you want to save product details?";
                var result = form4.ShowDialog(); // Show as a dialog and get result

                if (result == DialogResult.Yes)
                {
                    // Add the new category to the file
                    lines.Add($"{level_1_combo_box.Text}");
                    lines.Add("= ===============================================================================");

                    // Add product details to the newly created category
                    lines.Add(FormatProductDetails());

                    // Add the end of category marker
                    lines.Add("* *******************************************************************************");

                    // Save and exit after creating the new category and product
                    File.WriteAllLines(filePath, lines);

                    massage_box form5 = new massage_box();
                    form5.massage_label.Text = "Product category and product details saved succussesfully...!";
                    form5.Show();

                    // Clear fields
                    product_id_text_box.Clear();
                    cost_price_text_box.Clear();
                    discount_text_box.Clear();
                    retail_price_text_box.Clear();
                    wholesale_price_text_box.Clear();

                    product_name_combo_box.Text = string.Empty;
                    level_1_combo_box.Text = string.Empty;
                    level_2_combo_box.Text = string.Empty;
                    level_3_combo_box.Text = string.Empty;
                    level_4_combo_box.Text = string.Empty;
                    level_5_combo_box.Text = string.Empty;

                    return;
                }
            }

            // Step 6: Continue reading within the category to find product by ID
            bool productFound = false;
            int productStartIndex = -1;
            for (int i = categoryStartIndex + 1; i < lines.Count; i++)
            {
                // Stop if we reach the end of the category (indicated by *)
                if (lines[i].StartsWith("*"))
                    break;

                if (lines[i].Contains("Product ID: " + product_id_text_box.Text))
                {
                    productFound = true;
                    productStartIndex = i;
                    break;
                }
            }

            // Step 7: Update the product details if found
            if (productFound)
            {
                // Show comformation box
                action_form form6 = new action_form();
                form6.action_label.Text = "Are you sure you want to update product details?";
                var result = form6.ShowDialog(); // Show as a dialog and get result

                if (result == DialogResult.Yes)
                {
                    // Remove the old product details block
                    int detailsEndIndex = productStartIndex;
                    while (detailsEndIndex < lines.Count && !lines[detailsEndIndex].Contains("- -------------------------------------------------------"))
                    {
                        detailsEndIndex++;
                    }

                    // Replace old product details with the updated details
                    lines.RemoveRange(productStartIndex, detailsEndIndex - productStartIndex + 1);
                    lines.Insert(productStartIndex, FormatProductDetails());

                    massage_box form7 = new massage_box();
                    form7.massage_label.Text = "Product details updated succussesfully...!";
                    form7.Show();

                    return;
                }
            }
            else
            {
                // Step 8: If product ID is not found, add product details at the end of the category
                for (int i = categoryStartIndex + 1; i < lines.Count; i++)
                {
                    if (lines[i].StartsWith("*"))
                    {
                        // Show comformation box
                        action_form form8 = new action_form();
                        form8.action_label.Text = "Are you sure you want to save product details?";
                        var result = form8.ShowDialog(); // Show as a dialog and get result

                        if (result == DialogResult.Yes)
                        {
                            lines.Insert(i, FormatProductDetails());

                            massage_box form9 = new massage_box();
                            form9.massage_label.Text = "Product details saved succussesfully...!";
                            form9.Show();

                            break;
                        }
                    }
                }
            }

            // Step 10: Write the updated lines back to the file
            File.WriteAllLines(filePath, lines);

            // Clear fields
            product_id_text_box.Clear();
            cost_price_text_box.Clear();
            discount_text_box.Clear();
            retail_price_text_box.Clear();
            wholesale_price_text_box.Clear();

            product_name_combo_box.Text = string.Empty;
            level_1_combo_box.Text = string.Empty;
            level_2_combo_box.Text = string.Empty;
            level_3_combo_box.Text = string.Empty;
            level_4_combo_box.Text = string.Empty;
            level_5_combo_box.Text = string.Empty;
        }

        // Helper function to format product details as a string
        private string FormatProductDetails()
        {
            return $"Product ID: {product_id_text_box.Text}\n" +
                   $"Product Name: {product_name_combo_box.Text}\n" +
                   $"Cost Price: {cost_price_text_box.Text}\n" +
                   $"Discount: {discount_text_box.Text}\n" +
                   $"Retail Price: {retail_price_text_box.Text}\n" +
                   $"Wholesale Price: {wholesale_price_text_box.Text}\n" +
                   $"Level 1: {level_1_combo_box.Text}\n" +
                   $"Level 2: {level_2_combo_box.Text}\n" +
                   $"Level 3: {level_3_combo_box.Text}\n" +
                   $"Level 4: {level_4_combo_box.Text}\n" +
                   $"Level 5: {level_5_combo_box.Text}\n" +
                   "- -------------------------------------------------------";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Step 1: Check if "Product ID" is empty
            if (string.IsNullOrWhiteSpace(product_id_text_box.Text))
            {
                error_massage_box form1 = new error_massage_box();
                form1.error_massage_label.Text = "Please select any product and try again...!";
                form1.Show();
                return; // Exit if no Product ID is entered
            }

            // Step 2: Set the file path
            string filePath = file_path_1; // Replace with your actual file path

            // Step 3: Read all lines from the file
            var lines = File.ReadAllLines(filePath).ToList();

            // Step 4: Find the line matching the category level (Level 1)
            string categoryStartLine = level_1_combo_box.Text;
            int categoryStartIndex = lines.FindIndex(line => line.Equals(categoryStartLine, StringComparison.OrdinalIgnoreCase));

            // Step 5: Search for the product ID in the category and delete the product details block
            bool productFound = false;
            int productStartIndex = -1;
            for (int i = categoryStartIndex + 1; i < lines.Count; i++)
            {
                // Stop if we reach the end of the category (indicated by "*")
                if (lines[i].StartsWith("*"))
                {
                    break;
                }

                if (lines[i].Contains("Product ID: " + product_id_text_box.Text))
                {
                    productFound = true;
                    productStartIndex = i;
                    break;
                }
            }

            // Step 6: If product is found, delete the product block
            if (productFound)
            {
                // Find the end of the product block (until "- -------------------------------------------------------")
                int productEndIndex = productStartIndex;
                while (productEndIndex < lines.Count && !lines[productEndIndex].Contains("- -------------------------------------------------------"))
                {
                    productEndIndex++;
                }

                // Show comformation box
                action_form form2 = new action_form();
                form2.action_label.Text = "Are you sure you want to delete product details?";
                var result = form2.ShowDialog(); // Show as a dialog and get result

                if (result == DialogResult.Yes)
                {
                    // Remove the entire product block
                    lines.RemoveRange(productStartIndex, productEndIndex - productStartIndex + 1);
                }

                // Save the updated file
                File.WriteAllLines(filePath, lines);

                massage_box form3 = new massage_box();
                form3.massage_label.Text = "Product details deleted succussesfully...!";
                form3.Show();

                // Clear fields
                product_id_text_box.Clear();
                cost_price_text_box.Clear();
                discount_text_box.Clear();
                retail_price_text_box.Clear();
                wholesale_price_text_box.Clear();

                product_name_combo_box.Text = string.Empty;
                level_1_combo_box.Text = string.Empty;
                level_2_combo_box.Text = string.Empty;
                level_3_combo_box.Text = string.Empty;
                level_4_combo_box.Text = string.Empty;
                level_5_combo_box.Text = string.Empty;
            }
        }
    }
}
