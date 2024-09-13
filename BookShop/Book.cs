using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public int ThemeId { get; set; }
        public Book() { }
        public Book(SqlDataReader Reader)
        {
            this.Id = Reader.GetInt32(0);
            this.Name = Reader.GetString(1);
            this.Pages = Reader.GetInt32(2);
            this.Price = Reader.GetDecimal(3);
            this.PublishDate = Reader.GetDateTime(4);
            this.AuthorId = Reader.GetInt32(5);
            this.ThemeId = Reader.GetInt32(6);

        }
    }
}
