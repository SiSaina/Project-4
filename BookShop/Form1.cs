using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
            {
                if (activeForm.GetType() == childForm.GetType())
                {
                    activeForm.BringToFront();
                    return;
                }
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Panel_main.Controls.Add(childForm);
            Panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Home_button_Click(object sender, EventArgs e)
        {
            if(activeForm != null)
            {
                activeForm.Hide();
                activeForm = null;
            }
            Panel_main.BringToFront();
        }

        private void Country_button_Click(object sender, EventArgs e)
        {
            openChildForm(new CountryForm());
        }

        private void Theme_button_Click(object sender, EventArgs e)
        {
            openChildForm(new ThemeForm());
        }

        private void Author_button_Click(object sender, EventArgs e)
        {
            openChildForm(new AuthorForm());
        }

        private void Book_button_Click(object sender, EventArgs e)
        {
            openChildForm(new BookForm());
        }

        private void Sale_button_Click(object sender, EventArgs e)
        {
            openChildForm(new SaleForm());
        }

        private void Shop_button_Click(object sender, EventArgs e)
        {
            openChildForm(new ShopForm());
        }
    }
}
