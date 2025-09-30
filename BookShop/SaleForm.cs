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
    public partial class SaleForm : Form
    {
        DBconnect DBconnect;
        private List<Sale> allSales => new SaleForm().GetSale();
        public SaleForm()
        {
            InitializeComponent();
            DBconnect = new DBconnect();

            LoadData();
        }
        private List<Sale> GetSale()
        {
            return DBconnect.ReadData<Sale>(reader => new Sale(reader), "Sales");
        }
        private void LoadData()
        {
            List<Sale> sales = DBconnect.ReadData<Sale>(reader => new Sale(reader), "Sales");
            dataGridView1.DataSource = sales;
            
            if (dataGridView1.Columns["Price"] != null)
            {
                dataGridView1.Columns["Price"].DefaultCellStyle.Format = "N2";
            }

            BookForm bookForm = new BookForm();
            List<Book> books = bookForm.GetBooks();
            Select_book.DataSource = books;
            Select_book.DisplayMember = "Name";
            Select_book.ValueMember = "Id";

            ShopForm shopForm = new ShopForm();
            List<Shop> shops = shopForm.GetShops();
            Select_shop.DataSource = shops;
            Select_shop.DisplayMember = "Name";
            Select_shop.ValueMember = "Id";

            clearText();
        }
        private void Insert_button_Click(object sender, EventArgs e)
        {
            if (validation(out decimal price, out int quantity, out DateTime saleDate, out Book book, out Shop shop))
            {
                Sale sale = new Sale
                {
                    Price = price,
                    Quantity = quantity,
                    SaleDate = saleDate,
                    BookId = book.Id,
                    ShopId = shop.Id
                };
                DBconnect.InsertData(sale, "Sales", new[] { "Id" });
                LoadData();
            }
        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Did you select the date correctly??", "Confirm update",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select a row to update");
                    return;
                }

                DataGridViewRow row = dataGridView1.SelectedRows[0];

                if (validation(out decimal price, out int quantity, out DateTime saleDate, out Book book, out Shop shop))
                {
                    Sale sale = new Sale()
                    {
                        Id = Convert.ToInt32(row.Cells["Id"].Value),
                        Price = string.IsNullOrWhiteSpace(Input_price.Text) ? Convert.ToDecimal(row.Cells["Price"].Value) : decimal.Parse(Input_price.Text),
                        Quantity = string.IsNullOrWhiteSpace(Input_quantity.Text) ? Convert.ToInt32(row.Cells["Quantity"].Value) : int.Parse(Input_quantity.Text),
                        SaleDate = string.IsNullOrWhiteSpace(Select_date.Text) ? Convert.ToDateTime(row.Cells["SaleDate"].Value) : DateTime.Parse(Select_date.Text),
                        BookId = Select_book.SelectedItem == null ? Convert.ToInt32(row.Cells["BookId"].Value) : ((Book)Select_book.SelectedItem).Id,
                        ShopId = Select_shop.SelectedItem == null ? Convert.ToInt32(row.Cells["ShopId"].Value) : ((Shop)Select_shop.SelectedItem).Id
                    };
                    DBconnect.UpdateData(sale, "Sales", "Id");
                    LoadData();
                }
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

                DBconnect.DeleteData("Sales", "Id", value);

                LoadData();
            }
        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            clearText();
        }
        private void clearText()
        {
            Input_price.Text = string.Empty;
            Input_quantity.Text = string.Empty;
            Select_date.Text = default;
            Select_book.SelectedIndex = -1;
            Select_shop.SelectedIndex = -1;
        }

        private bool validation(out decimal price, out int quantity, out DateTime saleDate, out Book bookId, out Shop shopId)
        {
            price = 0;
            quantity = 0;
            saleDate = DateTime.Now;
            bookId = null;
            shopId = null;

            bool isValid = true;

            if (!string.IsNullOrWhiteSpace(Input_price.Text) &&
                (!decimal.TryParse(Input_price.Text, out price) || price < 0))
            {
                MessageBox.Show("Price must be greater than 0");
                isValid = false;
            }

            if (!string.IsNullOrWhiteSpace(Input_quantity.Text) &&
                (!int.TryParse(Input_quantity.Text, out quantity) || quantity <= 0))
            {
                MessageBox.Show("Quantity must be greater than 0");
                isValid = false;
            }

            if (!string.IsNullOrWhiteSpace(Select_date.Text) &&
                (!DateTime.TryParse(Select_date.Text, out saleDate) || saleDate > DateTime.Now))
            {
                MessageBox.Show("Sale date cannot be in the future");
                isValid = false;
            }

            if (Select_book.SelectedItem is Book book)
            {
                bookId = book;
            }
            else if (Select_book.SelectedIndex != -1)
            {
                MessageBox.Show("Select a book");
                isValid = false;
            }

            if (Select_shop.SelectedItem is Shop shop)
            {
                shopId = shop;
            }
            else if (Select_shop.SelectedIndex != -1)
            {
                MessageBox.Show("Select a shop");
                isValid = false;
            }

            return isValid;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;

            var filtered = allSales
                .Where(a => a.SaleDate.Date == selectedDate)
                .ToList();

            dataGridView1.DataSource = filtered;
        }
    }
}
