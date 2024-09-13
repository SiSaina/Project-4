using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class ShopForm : Form
    {
        DBconnect DBconnect;
        public ShopForm()
        {
            InitializeComponent();
            DBconnect = new DBconnect();

            LoadData();
        }
        public List<Shop> GetShops()
        {
            return DBconnect.ReadData<Shop>(reader => new Shop(reader), "Shops");
        }
        private void LoadData()
        {
            List<Shop> shops = DBconnect.ReadData<Shop>(reader => new Shop(reader), "Shops");
            dataGridView1.DataSource = shops;

            CountryForm countryForm = new CountryForm();

            List<Country> countries = countryForm.GetCountries();

            Select_country.DataSource = countries;
            Select_country.DisplayMember = "Name";
            Select_country.ValueMember = "Id";
            clearText();
        }
        private void Insert_button_Click(object sender, EventArgs e)
        {
            if (Validation(out string name, out Country selectedCountry))
            {
                Shop shop = new Shop
                {
                    Name = name,
                    CountryId = selectedCountry.Id
                };

                DBconnect.InsertData(shop, "Shops", new[] { "Id" });
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

            var confirm = MessageBox.Show("Did you select the date correctly?", "Confirm update",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int shopId = Convert.ToInt32(row.Cells["Id"].Value);

            if (Validation(out string name, out Country selectedCountry))
            {
                Shop shop = new Shop
                {
                    Id = shopId,
                    Name = string.IsNullOrWhiteSpace(Input_name.Text) ? row.Cells["Name"].Value.ToString() : name,
                    CountryId = Select_country.SelectedItem == null ? Convert.ToInt32(row.Cells["CountryId"].Value) : selectedCountry.Id
                };

                DBconnect.UpdateData(shop, "Shops", "Id");
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

                DBconnect.DeleteData("Shops", "Id", value);

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
            Select_country.SelectedIndex = -1;
        }
        private bool Validation(out string name, out Country countryId)
        {
            name = Input_name.Text;
            countryId = null;
            bool isValid = true;

            // Validate Name: it must not be null or empty
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty.");
                isValid = false;
            }

            // Validate Country selection: must be a valid foreign key (i.e., selected from a list)
            if (Select_country.SelectedItem is Country selectedCountry)
            {
                countryId = selectedCountry;
            }
            else
            {
                MessageBox.Show("Select a valid country.");
                isValid = false;
            }

            return isValid;
        }

    }
}
