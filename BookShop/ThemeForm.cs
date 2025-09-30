using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BookShop
{
    public partial class ThemeForm : Form
    {
        private DBconnect DBconnect;
        private List<Theme> allThemes => GetThemes();
        public ThemeForm()
        {
            InitializeComponent();
            DBconnect = new DBconnect();

            LoadData();
        }
        public List<Theme> GetThemes()
        {
            return DBconnect.ReadData<Theme>(reader => new Theme(reader), "Themes");
        }
        private void LoadData()
        {
            List<Theme> themes = DBconnect.ReadData<Theme>(reader => new Theme(reader), "Themes");
            dataGridView1.DataSource = themes;
            clearText();
        }
        private void Insert_button_Click(object sender, EventArgs e)
        {
            if(Validation(out string name))
            {
                Theme theme = new Theme()
                {
                    Name = name
                };
                DBconnect.InsertData(theme, "Themes", new[] { "Id" });
                LoadData();
            }
        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to update)");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            if(Validation(out string name))
            {
                Theme theme = new Theme()
                {
                    Id = Convert.ToInt32(row.Cells["Id"].Value),
                    Name = name
                };
                DBconnect.UpdateData(theme, "Themes", "Id");
                LoadData();
            }
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to delete");
                return;
            }
            var confirm = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var row = dataGridView1.SelectedRows[0];
                int value = Convert.ToInt32(row.Cells["Id"].Value);

                DBconnect.DeleteData("Themes", "Id", value);

                LoadData();
            }
        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            Input_name.Text = string.Empty;
        }
        private void clearText()
        {
            Input_name.Text = string.Empty;
        }
        private bool Validation(out string name)
        {
            // Initialize the output variable
            name = Input_name.Text;
            bool isValid = true;

            // Validate that Name is not null or empty
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty.");
                isValid = false;
            }
            else
            {
                // Check for uniqueness of the Name (assuming DBconnect has a method to check for existing names)
                List<string> existingNames = DBconnect.ReadData<string>(reader => reader["Name"].ToString(), "Themes");

                if (existingNames.Contains(name))
                {
                    MessageBox.Show("Name must be unique.");
                    isValid = false;
                }
            }

            return isValid;
        }

        private void Input_search_TextChanged(object sender, EventArgs e)
        {
            string searchText = Input_search.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                dataGridView1.DataSource = allThemes;
            }
            else
            {
                if (searchText.Length > 5)
                    searchText = searchText.Substring(0, 5);

                var filtered = allThemes
                    .Where(a =>
                        (!string.IsNullOrEmpty(a.Name) && a.Name.ToLower().Contains(searchText)))
                    .ToList();

                dataGridView1.DataSource = filtered;
            }
        }
    }
}
