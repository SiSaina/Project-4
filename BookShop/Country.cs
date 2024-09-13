using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country() { }
        public Country(SqlDataReader reader) 
        {
            this.Id = reader.GetInt32(0);
            this.Name = reader.GetString(1);
        }
    }
}
