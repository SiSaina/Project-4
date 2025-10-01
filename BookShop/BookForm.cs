using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BookShop
{
    public partial class BookForm : Form
    {
        DBconnect DBconnect;
        private List<Book> allBooks => GetBooks();
        public BookForm()
        {
            InitializeComponent();
            DBconnect = new DBconnect();

            LoadData();
        }
        public List<Book> GetBooks()
        {
            return DBconnect.ReadData<Book>(reader => new Book(reader), "Books");
        }
        private void LoadData()
        {
            List<Book> books = DBconnect.ReadData<Book>(reader => new Book(reader), "Books");
            AuthorForm authorForm = new AuthorForm();
            List<Author> authors = authorForm.GetAuthors();
            ThemeForm themeForm = new ThemeForm();
            List<Theme> themes = themeForm.GetThemes();

            foreach (var book in books)
            {
                var author = authors.FirstOrDefault(a => a.Id == book.AuthorId);
                book.AuthorName = author != null ? author.Name + " " + author.Surname : "Unknown";

                var theme = themes.FirstOrDefault(t => t.Id == book.ThemeId);
                book.ThemeName = theme != null ? theme.Name : "Unknown";
            }

            dataGridView1.DataSource = books;

            Select_author.DataSource = authors;
            Select_author.DisplayMember = "Name";
            Select_author.ValueMember = "Id";

            Select_theme.DataSource = themes;
            Select_theme.DisplayMember = "Name";
            Select_theme.ValueMember = "Id";

            clearText();
        }
        private void Insert_button_Click(object sender, EventArgs e)
        {
            if (Validation(out string name, out int pages, out decimal price, out DateTime publishDate, out Author author, out Theme theme))
            {
                Book book = new Book
                {
                    Name = name,
                    Pages = pages,
                    Price = price,
                    PublishDate = publishDate,
                    AuthorId = author.Id,
                    ThemeId = theme.Id
                };
                DBconnect.InsertData(book, "Books", new[] { "Id", "AuthorName", "ThemeName" });
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
            int bookId = Convert.ToInt32(row.Cells["Id"].Value);

            if (Validation(out string name, out int pages, out decimal price, out DateTime publishDate, out Author author, out Theme theme))
            {
                Book book = new Book
                {
                    Id = bookId,
                    Name = string.IsNullOrWhiteSpace(Input_name.Text) ? row.Cells["Name"].Value.ToString() : name,
                    Pages = string.IsNullOrWhiteSpace(Input_page.Text) ? Convert.ToInt32(row.Cells["Pages"].Value) : pages,
                    Price = string.IsNullOrWhiteSpace(Input_price.Text) ? Convert.ToDecimal(row.Cells["Price"].Value) : price,
                    PublishDate = string.IsNullOrWhiteSpace(Select_date.Text) ? Convert.ToDateTime(row.Cells["PublishDate"].Value) : publishDate,
                    AuthorId = author.Id,
                    ThemeId = theme.Id
                };
                DBconnect.UpdateData(book, "Books", "Id", new string[] { "AuthorName", "ThemeName" });
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

                DBconnect.DeleteData("Books", "Id", value);

                LoadData();
            }
        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            clearText();
        }
        private void clearText()
        {
            Input_name.Text = string.Empty;
            Input_page.Text = string.Empty;
            Input_price.Text = string.Empty;
            Select_date.Text = default;
            Select_author.SelectedIndex = -1;
            Select_theme.SelectedIndex = -1;
        }
        private bool Validation(out string name, out int pages, out decimal price, out DateTime publishDate, out Author authorId, out Theme themeId)
        {
            name = string.Empty;
            pages = 0;
            price = 0;
            publishDate = DateTime.Now;
            authorId = null;
            themeId = null;

            bool isValid = true;

            // Validate book name
            if (string.IsNullOrWhiteSpace(Input_name.Text))
            {
                MessageBox.Show("Name cannot be empty.");
                isValid = false;
            }
            else
            {
                name = Input_name.Text;
            }

            // Validate pages
            if (!int.TryParse(Input_page.Text, out pages) || pages <= 0)
            {
                MessageBox.Show("Pages must be greater than 0.");
                isValid = false;
            }

            // Validate price
            if (!decimal.TryParse(Input_price.Text, out price) || price < 0)
            {
                MessageBox.Show("Price must be a non-negative value.");
                isValid = false;
            }

            // Validate publish date
            if (!DateTime.TryParse(Select_date.Text, out publishDate) || publishDate > DateTime.Now)
            {
                MessageBox.Show("Publish date cannot be in the future.");
                isValid = false;
            }

            // Validate author selection
            if (Select_author.SelectedItem is Author selectedAuthor)
            {
                authorId = selectedAuthor;
            }
            else
            {
                MessageBox.Show("Select a valid author.");
                isValid = false;
            }

            // Validate theme selection
            if (Select_theme.SelectedItem is Theme selectedTheme)
            {
                themeId = selectedTheme;
            }
            else
            {
                MessageBox.Show("Select a valid theme.");
                isValid = false;
            }

            return isValid;
        }

        private void Input_search_TextChanged(object sender, EventArgs e)
        {
            string searchText = Input_search.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                dataGridView1.DataSource = allBooks;
            }
            else
            {
                if (searchText.Length > 5)
                    searchText = searchText.Substring(0, 5);

                var filtered = allBooks
                    .Where(a =>
                        (!string.IsNullOrEmpty(a.Name) && a.Name.ToLower().StartsWith(searchText)))
                    .ToList();

                dataGridView1.DataSource = filtered;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            Input_name.Text = row.Cells["Name"].Value?.ToString();
            Input_page.Text = row.Cells["Pages"].Value?.ToString();
            Input_price.Text = row.Cells["Price"].Value?.ToString();

            if (row.Cells["PublishDate"].Value != null && row.Cells["PublishDate"].Value is DateTime dt)
                Select_date.Value = dt;
            else
                Select_date.Value = DateTime.Now;

            if (int.TryParse(row.Cells["AuthorId"].Value?.ToString(), out int authorId))
                Select_author.SelectedValue = authorId;
            if (int.TryParse(row.Cells["ThemeId"].Value?.ToString(), out int themeId))
                Select_theme.SelectedValue = themeId;
        }
    }
}
