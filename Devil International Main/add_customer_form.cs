using GMap.NET.WindowsForms;
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
    public partial class add_customer_form : Form
    {
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customer Details.txt");

        private Dictionary<string, List<string>> districtTowns = new Dictionary<string, List<string>>();

        private Dictionary<string, (double Latitude, double Longitude)> townCoordinates = new Dictionary<string, (double Latitude, double Longitude)>();

        public add_customer_form()
        {
            InitializeComponent();

            Load += add_customer_form_Load;

            customer_name_combo_box.Leave += new EventHandler(comboBox1_Leave);
            LoadCustomerNames();

            LoadDistrictTowns(); // Load district-town data from file

            InitializeDistrictComboBox(); // Initialize district combo box

            InitializeGMap(); // Customer location map controller

            town_combo_box.SelectedIndexChanged += TownComboBox_SelectedIndexChanged; // To zoom map according to town

            LoadTownCoordinates();

            GenerateNextCustomerID();
        }

        private void add_customer_form_Load(object sender, EventArgs e)
        {
            // Check if file exists and generate or retrieve customer ID
            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            {
                // File does not exist or is empty, generate first customer ID "00001"
                string firstCustomerId = "00001";
                customer_id_text_box.Text = firstCustomerId; // Display the first customer id
            }
            else
            {
                // File exists and is not empty, get the last customer ID
                int lastCustomerId = GetLastCustomerId();
                string newCustomerId = (lastCustomerId + 1).ToString("D5"); // Generate the next customer ID, formatted as 5 digits
                customer_id_text_box.Text = newCustomerId; // Display the next customer id
            }
        }

        private int GetLastCustomerId()  // way to find last customer id
        {
            int lastCustomerId = 0;
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                for (int i = lines.Length - 1; i >= 0; i--) // Read file starting from end
                {
                    if (lines[i].StartsWith("Customer ID:"))
                    {
                        lastCustomerId = int.Parse(lines[i].Substring(12).Trim());
                        break;
                    }
                }
            }
            return lastCustomerId;
        }

        private void comboBox1_Leave(object sender, EventArgs e) // Covert 1st letter to Capital
        {
            if (customer_name_combo_box.Text.Length > 0)
            {
                customer_name_combo_box.Text = char.ToUpper(customer_name_combo_box.Text[0]) + customer_name_combo_box.Text.Substring(1).ToLower();
            }
        }

        private void LoadCustomerNames()
        {
            List<string> customerNames = new List<string>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (line.StartsWith("Customer Name: "))
                {
                    string customerName = line.Substring(15); // Extract the name after "Customer Name: "
                    customerNames.Add(customerName);
                }
            }

            customer_name_combo_box.DataSource = customerNames;
            customer_name_combo_box.SelectedIndex = -1; // Keep combo box empty 
        }

        private void ClearCustomerFields()
        {
            customer_id_text_box.Clear();
            sales_rep_combo_box.SelectedIndex = -1;
            address_line_1_text_box.Clear();
            address_line_2_text_box.Clear();
            address_line_3_text_box.Clear();
            e_mail_text_box.Clear();
            contact_no_text_box.Clear();
            district_combo_box.SelectedIndex = -1;
            town_combo_box.SelectedIndex = -1;
            customer_location_gmap.Position = new GMap.NET.PointLatLng(0, 0); // Clear map position if needed
            customer_location_gmap.Overlays.Clear();
        }

        private void customer_name_combo_box_SelectedIndexChanged(object sender, EventArgs e) // Load other field according to selected customer name
        {

            if (string.IsNullOrEmpty(customer_name_combo_box.Text))
            {
                // Clear all fields if no customer name is selected
                ClearCustomerFields();
                return;
            }
                var lines = File.ReadAllLines(filePath);
            var selectedCustomer = customer_name_combo_box.Text;
            bool customerFound = false;

            // Initialize variables for customer details
            string customerID = string.Empty, salesRep = string.Empty, address1 = string.Empty,
                address2 = string.Empty, address3 = string.Empty, email = string.Empty,
                contactNo = string.Empty, district = string.Empty, town = string.Empty,
                location = string.Empty;

            // Search for the selected customer in the file
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("Customer Name: ") && lines[i].Substring("Customer Name: ".Length).Trim() == selectedCustomer)
                {
                    customerFound = true;
                    customerID = lines[i - 2].Substring("Customer ID: ".Length).Trim();
                    salesRep = lines[i - 1].Substring("Sales Rep: ".Length).Trim();
                    address1 = lines[i + 1].Substring("Address line 1: ".Length).Trim();
                    address2 = lines[i + 2].Substring("Address line 2: ".Length).Trim();
                    address3 = lines[i + 3].Substring("Address line 3: ".Length).Trim();
                    email = lines[i + 4].Substring("Email: ".Length).Trim();
                    contactNo = lines[i + 5].Substring("Contact No: ".Length).Trim();
                    district = lines[i + 6].Substring("District: ".Length).Trim();
                    town = lines[i + 7].Substring("Town: ".Length).Trim();
                    location = lines[i + 8].Substring("Location: ".Length).Trim();
                    break;
                }
            }

            if (customerFound)
            {
                customer_id_text_box.Text = customerID;
                sales_rep_combo_box.Text = salesRep;
                address_line_1_text_box.Text = address1;
                address_line_2_text_box.Text = address2;
                address_line_3_text_box.Text = address3;
                e_mail_text_box.Text = email;
                contact_no_text_box.Text = contactNo;
                district_combo_box.Text = district;
                town_combo_box.Text = town;

                var coordinates = location.Split(',');
                if (coordinates.Length == 2)
                {
                    double latitude, longitude;
                    if (double.TryParse(coordinates[0], out latitude) && double.TryParse(coordinates[1], out longitude))
                    {
                        customer_location_gmap.Position = new GMap.NET.PointLatLng(latitude, longitude);
                        var point_2 = new GMap.NET.PointLatLng(latitude, longitude);
                       
                        // Optionally, you can add a marker at the clicked location
                        var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(point_2, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);
                        var markersOverlay = new GMap.NET.WindowsForms.GMapOverlay("markers");
                        markersOverlay.Markers.Add(marker);
                        customer_location_gmap.Overlays.Clear();
                        customer_location_gmap.Overlays.Add(markersOverlay);
                    }
                }
            }
        }

        private void LoadDistrictTowns()  // Load towns according to the district - methord 1
        {
            string[] lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "towns.txt"));
            foreach (string line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string district = parts[0].Trim();
                    var townData = parts[1].Trim().Split('/')
                        .Select(t =>
                        {
                            int index = t.IndexOf('(');
                            return index >= 0 ? t.Substring(0, index).Trim() : t.Trim();
                        })
                        .ToList();
                    districtTowns[district] = townData;
                }
            }
        }

        private void InitializeDistrictComboBox() // Load towns according to the district - methord 2
        {
            district_combo_box.Items.AddRange(districtTowns.Keys.ToArray());
            district_combo_box.SelectedIndexChanged += district_combo_box_SelectedIndexChanged;
        }

        private void district_combo_box_SelectedIndexChanged(object sender, EventArgs e) // Load towns according to the district - methord 3
        {
            string selectedDistrict = district_combo_box.SelectedItem.ToString();
            if (districtTowns.ContainsKey(selectedDistrict))
            {
                town_combo_box.Items.Clear();
                town_combo_box.Items.AddRange(districtTowns[selectedDistrict].ToArray());
            }

        }

        private void InitializeGMap() // Customer location map installation
        {
            customer_location_gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            customer_location_gmap.Position = new GMap.NET.PointLatLng(7.8731, 80.7718);
            customer_location_gmap.MinZoom = 1;
            customer_location_gmap.MaxZoom = 20;
            customer_location_gmap.Zoom = 6;
            customer_location_gmap.DragButton = MouseButtons.Left; // Set drag button

            customer_location_gmap.MouseDown += new MouseEventHandler(CustomerLocationGmap_MouseDown);
        }

        private void LoadTownCoordinates() // Extract latitude and Longitude from text file
        {
            string[] lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "towns.txt"));
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string district = parts[0].Trim();
                    string[] towns = parts[1].Split('/');
                    foreach (string town in towns)
                    {
                        string[] townParts = town.Trim().Split('(', ')');
                        if (townParts.Length == 3)
                        {
                            string townName = townParts[0].Trim();
                            string[] coordinates = townParts[1].Split(',');
                            if (coordinates.Length == 2)
                            {
                                if (double.TryParse(coordinates[0], out double latitude) && double.TryParse(coordinates[1], out double longitude))
                                {
                                    townCoordinates[townName] = (latitude, longitude);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void TownComboBox_SelectedIndexChanged(object sender, EventArgs e) // Adjust to the town location
        {
            string selectedTown = town_combo_box.SelectedItem.ToString();
            if (townCoordinates.TryGetValue(selectedTown, out var coordinates))
            {
                customer_location_gmap.Position = new GMap.NET.PointLatLng(coordinates.Latitude, coordinates.Longitude);
                customer_location_gmap.Zoom = 13; // Adjust the zoom level as needed
            }
        }

        private void CustomerLocationGmap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Get the coordinates of the click
                var point = customer_location_gmap.FromLocalToLatLng(e.X, e.Y);
                customer_location_gmap.Position = point;
                customer_location_gmap.Zoom = 13; // Adjust zoom level as needed

                // Optionally, you can add a marker at the clicked location
                var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(point, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);
                var markersOverlay = new GMap.NET.WindowsForms.GMapOverlay("markers");
                markersOverlay.Markers.Add(marker);
                customer_location_gmap.Overlays.Clear();
                customer_location_gmap.Overlays.Add(markersOverlay);
            }
        }

        private string GenerateNextCustomerID()
        {
            var lines = File.ReadAllLines(filePath);
            int maxID = 0;

            foreach (var line in lines)
            {
                if (line.StartsWith("Customer ID:"))
                {
                    int currentID = int.Parse(line.Replace("Customer ID:", "").Trim());
                    if (currentID > maxID)
                    {
                        maxID = currentID;
                    }
                }
            }

            return (maxID + 1).ToString("D5"); // Format the ID as a 5-digit number
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            // Assuming mapControl is your GMapControl instance
            var position = customer_location_gmap.Position;
            string location = $"{position.Lat}, {position.Lng}";

            var lines = File.ReadAllLines(filePath).ToList();
            bool customerExists = false;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith("Customer ID:") && lines[i].Contains(customer_id_text_box.Text))
                {
                    customerExists = true;

                    // Show comformation box
                    action_form form3 = new action_form();
                    form3.action_label.Text = "Are you sure you want to update your password?";
                    var result = form3.ShowDialog(); // Show as a dialog and get result

                    if (result == DialogResult.Yes)
                    {
                        // Update customer details
                        lines[i + 1] = $"Sales Rep: {sales_rep_combo_box.Text}";
                        lines[i + 2] = $"Customer Name: {customer_name_combo_box.Text}";
                        lines[i + 3] = $"Address line 1: {address_line_1_text_box.Text}";
                        lines[i + 4] = $"Address line 2: {address_line_2_text_box.Text}";
                        lines[i + 5] = $"Address line 3: {address_line_3_text_box.Text}";
                        lines[i + 6] = $"Email: {e_mail_text_box.Text}";
                        lines[i + 7] = $"Contact No: {contact_no_text_box.Text}";
                        lines[i + 8] = $"District: {district_combo_box.Text}";
                        lines[i + 9] = $"Town: {town_combo_box.Text}";
                        lines[i + 10] = $"Location: {location}";
                        
                        // Show Massage Box
                        massage_box form2 = new massage_box();
                        form2.massage_label.Text = "Customer details is updated successfully.";
                        form2.Show();

                        // Clear text boxes 
                        customer_id_text_box.Clear();
                        address_line_1_text_box.Clear();
                        address_line_2_text_box.Clear();
                        address_line_3_text_box.Clear();
                        e_mail_text_box.Clear();
                        contact_no_text_box.Clear();

                        // Clear combo boxes
                        sales_rep_combo_box.Text = string.Empty;
                        customer_name_combo_box.Text = string.Empty;
                        district_combo_box.Text = string.Empty;
                        town_combo_box.Text = string.Empty;

                        // Assign next customer ID
                        customer_id_text_box.Text = GenerateNextCustomerID();

                        // Reset map location and clear markers
                        customer_location_gmap.Position = new GMap.NET.PointLatLng(7.8731, 80.7718);
                        customer_location_gmap.Overlays.Clear();
                        customer_location_gmap.Zoom = 6;
                        customer_location_gmap.Overlays.Clear();

                        break;
                    }
                }
            }

            if (!customerExists)
            {
                // Show comformation box
                action_form form3 = new action_form();
                form3.action_label.Text = "Are you sure you want to save customer details?";
                var result = form3.ShowDialog(); // Show as a dialog and get result

                if (result == DialogResult.Yes)
                {
                    // Add new customer details
                    lines.Add($"Customer ID: {customer_id_text_box.Text}");
                    lines.Add($"Sales Rep: {sales_rep_combo_box.Text}");
                    lines.Add($"Customer Name: {customer_name_combo_box.Text}");
                    lines.Add($"Address line 1: {address_line_1_text_box.Text}");
                    lines.Add($"Address line 2: {address_line_2_text_box.Text}");
                    lines.Add($"Address line 3: {address_line_3_text_box.Text}");
                    lines.Add($"Email: {e_mail_text_box.Text}");
                    lines.Add($"Contact No: {contact_no_text_box.Text}");
                    lines.Add($"District: {district_combo_box.Text}");
                    lines.Add($"Town: {town_combo_box.Text}");
                    lines.Add($"Location: {location}");
                    lines.Add("------------------------------------------------------------------------------------------");

                    // Show Massage Box
                    massage_box form4 = new massage_box();
                    form4.massage_label.Text = "Customer details is saved successfully.";
                    form4.Show();
                }
            }

            File.WriteAllLines(filePath, lines);

            // Clear text boxes 
            customer_id_text_box.Clear();
            address_line_1_text_box.Clear();
            address_line_2_text_box.Clear();
            address_line_3_text_box.Clear();
            e_mail_text_box.Clear();
            contact_no_text_box.Clear();

            // Clear combo boxes
            sales_rep_combo_box.Text = string.Empty;
            customer_name_combo_box.Text = string.Empty;           
            district_combo_box.Text = string.Empty;
            town_combo_box.Text = string.Empty;

            // Assign next customer ID
            customer_id_text_box.Text = GenerateNextCustomerID();

            // Reset map location and clear markers
            customer_location_gmap.Position = new GMap.NET.PointLatLng(7.8731, 80.7718);
            customer_location_gmap.Overlays.Clear();
            customer_location_gmap.Zoom = 6;
            customer_location_gmap.Overlays.Clear();
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {    
            var lines = File.ReadAllLines(filePath).ToList();
            var selectedCustomerId = customer_id_text_box.Text;
            bool customerFound = true;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith("Customer ID: ") && lines[i].Substring("Customer ID: ".Length).Trim() == selectedCustomerId)
                {
                    if (customerFound)
                    {
                        // Show comformation box
                        action_form form3 = new action_form();
                        form3.action_label.Text = "Are you sure you want to delete customer details?";
                        var result = form3.ShowDialog(); // Show as a dialog and get result

                        if (result == DialogResult.Yes)
                        {
                            // Remove customer details
                            lines.RemoveRange(i, 12); // Assumes fixed number of lines for each customer's details

                            // Show Massage Box
                            massage_box form5 = new massage_box();
                            form5.massage_label.Text = "Customer deleted successfully.";
                            form5.Show();                           
                        }
                    }
                }
            }
            File.WriteAllLines(filePath, lines);

            // Clear text boxes 
            customer_id_text_box.Clear();
            address_line_1_text_box.Clear();
            address_line_2_text_box.Clear();
            address_line_3_text_box.Clear();
            e_mail_text_box.Clear();
            contact_no_text_box.Clear();

            // Clear combo boxes
            sales_rep_combo_box.Text = string.Empty;
            customer_name_combo_box.Text = string.Empty;
            district_combo_box.Text = string.Empty;
            town_combo_box.Text = string.Empty;

            // Assign next customer ID
            customer_id_text_box.Text = GenerateNextCustomerID();

            // Reset map location and clear markers
            customer_location_gmap.Position = new GMap.NET.PointLatLng(7.8731, 80.7718);
            customer_location_gmap.Overlays.Clear();
            customer_location_gmap.Zoom = 6;
            customer_location_gmap.Overlays.Clear();
        }
    }
}
