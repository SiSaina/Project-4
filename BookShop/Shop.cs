using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Shop() { }
        public Shop(SqlDataReader reader)
        {
            this.Id = reader.GetInt32(0);
            this.Name = reader.GetString(1);
            this.CountryId = reader.GetInt32(2);
        }
    }
}
