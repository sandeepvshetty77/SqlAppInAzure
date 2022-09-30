using SqlApp.Models;
using System.Data.SqlClient;

namespace SqlApp.Services
{
    public class ProductServices
    {
        private readonly string dbsource = "demoserver77.database.windows.net";
        private readonly string dbdatabase = "demodb77";
        private readonly string dbusername = "sqladmin";
        private readonly string dbpassword = "Azureuser1234";

        private SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = dbsource;
            _builder.InitialCatalog = dbdatabase;
            _builder.UserID = dbusername;
            _builder.Password = dbpassword;

            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            string cmdText = "Select ProductID, ProductName, Quantity from Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            List<Product> lstProducts = new List<Product>();
            
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };

                    lstProducts.Add(product);
                }
            }

            conn.Close();
            return lstProducts;
        }
            
    }
}
