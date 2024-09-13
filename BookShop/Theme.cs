using System.Data.SqlClient;

namespace BookShop
{
    public class Theme
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Theme() { }
        public Theme(SqlDataReader reader)
        {
            this.Id = reader.GetInt32(0);
            this.Name = reader.GetString(1);
        }
    }
}
