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
    public partial class product_category_add_form : Form
    {
        private string file_Path_1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Product Category.txt");

        public product_category_add_form()
        {
            InitializeComponent();
        }

        private void category_level_combo_box_SelectedIndexChanged(object sender, EventArgs e) // load category numeber method 1
        {
            string selectedLevel = category_level_combo_box.SelectedItem.ToString(); 
            string filePath = file_Path_1; 
            
            int nextCategoryNumber = GetNextCategoryNumber(selectedLevel, filePath); 
            category_number_text_box.Text = nextCategoryNumber.ToString("D2");
        }

        private int GetNextCategoryNumber(string level, string filePath) // load category numeber method 2
        {
            int highestNumber = 0; 
            
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath); 
                bool isLevelMatch = false; 
                
                foreach (string line in lines)
                {
                    if (line.Contains(level))
                    {
                        isLevelMatch = true; 
                        continue;
                    }

                    if (isLevelMatch)
                    {
                        if (line.StartsWith("-"))
                        {
                            break;
                        }

                        string[] parts = line.Split('.'); 
                        
                        if (parts.Length > 1)
                        {
                            int number; 
                            
                            if (int.TryParse(parts[0].Trim(), out number))
                            {
                                highestNumber = Math.Max(highestNumber, number);
                            }
                        }
                    }
                }
            }
            return highestNumber + 1;
        }

        private void category_number_text_box_TextChanged(object sender, EventArgs e) // load category name method 1
        {
            if (category_level_combo_box.SelectedItem != null && !string.IsNullOrEmpty(category_number_text_box.Text))
            {
                string selectedLevel = category_level_combo_box.SelectedItem.ToString(); 
                string categoryNumber = category_number_text_box.Text; 
                string filePath = file_Path_1;

                string categoryName = GetCategoryName(selectedLevel, categoryNumber, filePath); 
                category_name_text_box.Text = categoryName;
            }
        }

        private string GetCategoryName(string level, string number, string filePath) // load category name method 2
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath); 
                bool isLevelMatch = false; 
                
                foreach (string line in lines)
                {
                    if (line.Contains(level))
                    {
                        isLevelMatch = true; 
                        continue;
                    }

                    if (isLevelMatch)
                    {
                        if (line.StartsWith("-"))
                        {
                            break;
                        }

                        string[] parts = line.Split('.'); 
                        if (parts.Length > 1 && parts[0].Trim() == number)
                        {
                            return parts[1].Trim();
                        }
                    }
                }
            }
            return string.Empty;
        }

        private void save_button_click(object sender, EventArgs e)
        {
            string selectedLevel = category_level_combo_box.SelectedItem?.ToString();
            string categoryName = category_name_text_box.Text.Trim();
            string categoryNumber = category_number_text_box.Text.Trim();
            string filePath = file_Path_1;

            if (string.IsNullOrEmpty(selectedLevel) || string.IsNullOrEmpty(categoryName))
            {
                error_massage_box form1 = new error_massage_box();
                form1.error_massage_label.Text = "Please select a category level and enter a category name.";
                form1.Show();
            }

            SaveOrUpdateCategory(selectedLevel, categoryNumber, categoryName, filePath);
        }

        private void SaveOrUpdateCategory(string level, string number, string name, string filePath)
        {
            bool categoryUpdated = false; 
            List<string> lines = new List<string>();
            bool isLevelMatch = false;

            if (File.Exists(filePath))
            {
                lines = File.ReadAllLines(filePath).ToList();
                //bool isLevelMatch = false; 

                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Contains(level))
                    {
                        isLevelMatch = true;

                        continue;
                    }

                    if (isLevelMatch)
                    {                       
                         if (lines[i].StartsWith("-"))
                         {
                             break;
                         }

                         string[] parts = lines[i].Split('.');

                        if (parts.Length > 1 && parts[0].Trim() == number)
                        {

                            // Show comformation box
                            action_form form2 = new action_form();
                            form2.action_label.Text = "Are you sure you want to update category name?";
                            var result = form2.ShowDialog(); // Show as a dialog and get result

                            if (result == DialogResult.Yes)
                            {

                                lines[i] = $"{number}. {name}";
                                categoryUpdated = true;

                                massage_box form3 = new massage_box();
                                form3.massage_label.Text = "Category name is updated successfully.";
                                form3.Show();

                                break;
                            }
                        }                       
                    }
                }
            }

            if (!categoryUpdated && isLevelMatch) // save category
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Contains(level))
                    {
                        // Show comformation box
                        action_form form4 = new action_form();
                        form4.action_label.Text = "Are you sure you want to save new category?";
                        var result = form4.ShowDialog(); // Show as a dialog and get result

                        if (result == DialogResult.Yes)
                        {

                            while (!lines[i + 1].StartsWith("-"))
                            {
                                i++;
                            }

                            lines.Insert(i + 1, $"{number}. {name}");

                            massage_box form5 = new massage_box();
                            form5.massage_label.Text = "New category is saved successfully.";
                            form5.Show();

                            break;
                        }
                    }
                }
            }   
            

            File.WriteAllLines(filePath, lines);

            // Clear fields
            category_name_text_box.Clear();
            category_number_text_box.Clear();
            category_level_combo_box.Text = string.Empty;
        }

        private void delete_button_click(object sender, EventArgs e)
        {
            string selectedLevel = category_level_combo_box.SelectedItem?.ToString();
            string categoryName = category_name_text_box.Text.Trim();
            string categoryNumber = category_number_text_box.Text.Trim();
            string filePath = file_Path_1;           

            if (string.IsNullOrEmpty(category_level_combo_box.Text) || string.IsNullOrEmpty(category_name_text_box.Text))
            {
                error_massage_box form6 = new error_massage_box();
                form6.error_massage_label.Text = "Please select a category level and enter a category name.";
                form6.Show();
            }

            DeleteCategory(selectedLevel, categoryNumber, filePath);
        }

        private void DeleteCategory(string level, string number, string filePath)
        {
            List<string> lines = new List<string>();

            if (File.Exists(filePath))
            {
                lines = File.ReadAllLines(filePath).ToList();
                bool isLevelMatch = false;

                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Contains(level))
                    {
                        isLevelMatch = true;
                        continue;
                    }

                    if (isLevelMatch)
                    {                                                                    
                        if (lines[i].StartsWith("-"))
                        {
                            break;
                        }

                        string[] parts = lines[i].Split('.');

                        if (parts.Length > 1 && parts[0].Trim() == number)
                        {
                            // Show comformation box
                            action_form form7 = new action_form();
                            form7.action_label.Text = "Are you sure you want to delete category?";
                            var result = form7.ShowDialog(); // Show as a dialog and get result

                            if (result == DialogResult.Yes)
                            {

                                lines.RemoveAt(i);

                                massage_box form8 = new massage_box();
                                form8.massage_label.Text = "Category is deleted successfully.";
                                form8.Show();

                                break;
                            }
                        }                        
                    }
                }
            }
            File.WriteAllLines(filePath, lines);

            // Clear fields
            category_name_text_box.Clear();
            category_number_text_box.Clear();
            category_level_combo_box.Text = string.Empty;
        }
    }
}