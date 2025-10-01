using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BookShop
{
    public partial class AuthorForm : Form
    {
        DBconnect DBconnect;
        private List<Author> allAuthors => GetAuthors();
        private List<Country> allCountries => new CountryForm().GetCountries();
        public AuthorForm()
        {
            InitializeComponent();
            DBconnect = new DBconnect();

            LoadData();
        }
        public List<Author> GetAuthors()
        {
            return DBconnect.ReadData<Author>(reader => new Author(reader), "Authors");
        }
        private void LoadData()
        {
            List<Author> authors = DBconnect.ReadData<Author>(reader => new Author(reader), "Authors");
            dataGridView1.DataSource = authors;

            CountryForm countryForm = new CountryForm();

            List<Country> countries = countryForm.GetCountries();

            Select_country.DataSource = countries;
            Select_country.DisplayMember = "Name";
            Select_country.ValueMember = "Id";
            clearText();
        }
        private void Insert_button_Click(object sender, EventArgs e)
        {
            if (Validation(out string name, out string surname, out Country selectedCountry))
            {
                Author author = new Author()
                {
                    Name = Input_name.Text,
                    Surname = Input_surname.Text,
                    CountryId = selectedCountry.Id
                };

                DBconnect.InsertData(author, "Authors", new[] { "Id" });
                LoadData();
            }
        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to update");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            if (Validation(out string name, out string surname, out Country selectedCountry))
            {
                Author author = new Author()
                {
                    Id = Convert.ToInt32(row.Cells["Id"].Value),
                    Name = string.IsNullOrWhiteSpace(Input_name.Text) ? row.Cells["Name"].Value.ToString() : Input_name.Text,
                    Surname = string.IsNullOrWhiteSpace(Input_surname.Text) ? row.Cells["Surname"].Value.ToString() : Input_surname.Text,
                    CountryId = selectedCountry.Id
                };

                DBconnect.UpdateData(author, "Authors", "Id");
                LoadData();
            }
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to update");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var row = dataGridView1.SelectedRows[0];
                int value = Convert.ToInt32(row.Cells["Id"].Value);

                DBconnect.DeleteData("Authors", "Id", value);

                LoadData();
            }
            clearText();
        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            clearText();
        }
        private void clearText()
        {
            Input_name.Text = string.Empty;
            Input_surname.Text = string.Empty;
            Select_country.SelectedIndex = -1;
        }
        private bool Validation(out string name, out string surname, out Country selectedCountry)
        {
            name = Input_name.Text;
            surname = Input_surname.Text;
            selectedCountry = null;
            bool isValid = true;

            // Validate Name: it must not be null or empty
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty.");
                isValid = false;
            }

            // Validate Surname: it must not be null or empty
            if (string.IsNullOrWhiteSpace(surname))
            {
                MessageBox.Show("Surname cannot be empty.");
                isValid = false;
            }

            // Validate Country selection: must be selected from a list
            if (Select_country.SelectedItem is Country country)
            {
                selectedCountry = country;
            }
            else
            {
                MessageBox.Show("Select a valid country.");
                isValid = false;
            }

            return isValid;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            Input_name.Text = row.Cells["Name"].Value?.ToString();
            Input_surname.Text = row.Cells["Surname"].Value?.ToString();

            int countryId = Convert.ToInt32(row.Cells["CountryId"].Value);
            Select_country.SelectedValue = countryId;
        }

        private void Input_search_TextChanged(object sender, EventArgs e)
        {
            string searchText = Input_search.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                dataGridView1.DataSource = allAuthors;
            }
            else
            {
                if (searchText.Length > 5)
                    searchText = searchText.Substring(0, 5);

                var filtered = allAuthors
                    .Where(a =>
                        (!string.IsNullOrEmpty(a.Name) && a.Name.ToLower().StartsWith(searchText)) ||
                        (!string.IsNullOrEmpty(a.Surname) && a.Surname.ToLower().StartsWith(searchText)))
                    .ToList();

                dataGridView1.DataSource = filtered;
            }
        }

    }
}
