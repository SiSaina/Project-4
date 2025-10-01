using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Sale
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public Sale() { }
        public Sale(SqlDataReader reader)
        {
            this.Id = reader.GetInt32(0);
            this.Price = reader.GetDecimal(1);
            this.Quantity = reader.GetInt32(2);
            this.SaleDate = reader.GetDateTime(3);
            this.BookId = reader.GetInt32(4);
            this.ShopId = reader.GetInt32(5);
        }
    }
}
