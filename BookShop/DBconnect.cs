using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;

namespace BookShop
{
    public class DBconnect
    {
        string connection = @"data source=LAPTOP-I65UB9QR\SQLSERVERDEV;database=BookShop;integrated security=true;";
        private static string DatabaseName = "BookShop";
        private static string DbConnection = $@"data source=LAPTOP-I65UB9QR\SQLSERVERDEV;database={DatabaseName};integrated security=true;";

        public DBconnect()
        {
            EnsureDatabaseExists();
        }

        private void EnsureDatabaseExists()
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                string checkDb = $"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{DatabaseName}') " +
                                 $"CREATE DATABASE [{DatabaseName}]";

                using (SqlCommand cmd = new SqlCommand(checkDb, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public SqlConnection GetDBConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            return sqlConnection;
        }
        public List<T> ReadData<T>(Func<SqlDataReader, T> func, string tableName) 
        {
            List<T> list = new List<T>();
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = GetDBConnection();
                string command = $"select * from {tableName} order by Id";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    T item = func(reader);
                    list.Add(item);
                }
            }
            finally
            {
                sqlConnection?.Close();
            }
            return list;
        }

        public void InsertData<T>(T item, string tableName, string[] exclude = null)
        {
            SqlConnection sqlConnection = null;
            try
            {
                using (sqlConnection = GetDBConnection())
                {
                    PropertyInfo[] properties = typeof(T).GetProperties();

                    var exProperty = exclude == null ? properties : properties.Where(p => !exclude.Contains(p.Name)).ToArray();

                    string column = string.Join(", ", exProperty.Select(p => p.Name));
                    string para = string.Join(", ", exProperty.Select(p => "@" + p.Name));

                    string command = $"insert into {tableName} ({column}) values ({para})";

                    using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
                    {
                        foreach (var property in properties)
                        {
                            var value = property.GetValue(item);
                            sqlCommand.Parameters.AddWithValue("@" + property.Name, value ?? DBNull.Value);
                        }
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            finally
            {
                sqlConnection?.Close();
            }
        }

        public void UpdateData<T>(T item, string tableName, string key)
        {
            SqlConnection sqlConnection = null;
            try
            {
                using (sqlConnection = GetDBConnection())
                {
                    PropertyInfo[] properties = typeof(T).GetProperties();

                    string setClause = string.Join(", ", properties.Where(p => p.Name != key).Select(p => $"{p.Name} = @{p.Name}"));

                    string command = $"update {tableName} set {setClause} where {key} = @{key}";

                    using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
                    {
                        foreach (var property in properties)
                        {
                            var value = property.GetValue(item);
                            sqlCommand.Parameters.AddWithValue("@" + property.Name, value ?? DBNull.Value);
                        }

                        var keyValue = typeof(T).GetProperty(key)?.GetValue(item);

                        if(!sqlCommand.Parameters.Contains("@" + key))
                        {
                            sqlCommand.Parameters.AddWithValue("@" + key, keyValue ?? DBNull.Value);
                        }
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            finally 
            {
                sqlConnection?.Close();
            }
        }

        public void DeleteData(string tableName, string key, int value)
        {
            SqlConnection sqlConnection = null;
            try
            {
                using (sqlConnection = GetDBConnection())
                {
                    string command = $"delete from {tableName} where {key} = @value";
                    using (SqlCommand sqlCommand = new SqlCommand(command , sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@value", value);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            finally
            {
                sqlConnection?.Close();
            }
        }
    }
}
