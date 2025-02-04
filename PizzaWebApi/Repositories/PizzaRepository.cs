using System.Data.SqlClient;
using PizzaWebApi.Models;

// Informazioni Classe:
// Bug presenti: 


namespace PizzaWebApi.Repositories
{
    public class PizzaRepository
    {
        public const string ConnectionString = "Data Source=localhost;Initial Catalog=PizzaDB;Integrated Security=True;";

        public async Task<List<Pizza>> GetAllPizzas()
        {
            string query = @"SELECT p.*, c.Id AS CategoryId, c.Name AS CategoryName 
                        FROM Pizzas p
                        LEFT JOIN Categories c ON p.CategoryId = c.Id";
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            List<Pizza> pizzas = new List<Pizza>();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        pizzas.Add(GetPizzaFromData(reader));
                    }
                }
            }

            return pizzas;
        }
        public async Task<List<Pizza>> GetPizzasByName(string name)
        {
            string query = @"SELECT p.*, c.Id AS CategoryId, c.Name AS CategoryName 
                          FROM Pizzas p
                          LEFT JOIN Categories c ON p.CategoryId = c.Id
                          WHERE p.name=@name";
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            List<Pizza> pizzas = new List<Pizza>();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@name", name));
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        pizzas.Add(GetPizzaFromData(reader));
                    }
                }
            }

            return pizzas;
        }
        public async Task<Pizza> GetPizzaById(int id)
        {
            string query = @"SELECT TOP 1 p.*, c.Id AS CategoryId, c.Name AS CategoryName 
                          FROM Pizzas p
                          LEFT JOIN Categories c ON p.CategoryId = c.Id
                          WHERE p.id=@id";
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@id", id));
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return GetPizzaFromData(reader);
                    }
                    return null;
                }
            }
        }
        public async Task<int> InsertPizza(Pizza pizza)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            string query = $"INSERT INTO Pizzas (Name, Description, Price, CategoryId) VALUES (@name, @description, @price, @categoryId)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@name", pizza.Name));
                cmd.Parameters.Add(new SqlParameter("@description", pizza.Description));
                cmd.Parameters.Add(new SqlParameter("@price", pizza.Price));
                cmd.Parameters.Add(new SqlParameter("@categoryId", pizza.CategoryId));

                return await cmd.ExecuteNonQueryAsync();
            }
        }
        
        // Houston we have a bug here!
        public async Task<int> UpdatePizza(int id, Pizza pizza)  
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            string query = $"UPDATE Pizzas SET Name = @name, Description = @description, Price = @price, CategoryId = @categoryId WHERE id = @id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@name", pizza.Name));
                cmd.Parameters.Add(new SqlParameter("@description", pizza.Description));
                cmd.Parameters.Add(new SqlParameter("@price", pizza.Price));
                

                return await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> DeletePizza(int id)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            string query = $"DELETE FROM Pizzas WHERE id = @id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@id", id));

                return await cmd.ExecuteNonQueryAsync();
            }
        }
        
        // Da completare
        public async Task<int> OnCategoryDelete(int id)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            string query = ""; 
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                return -1; // Beccate sto -1, non può ritornare, Non penso proprio!
            }
        }
        private Pizza GetPizzaFromData(SqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("id"));
            string name = reader.GetString(reader.GetOrdinal("Name"));
            string description = reader.GetString(reader.GetOrdinal("Description"));
            decimal price = reader.GetDecimal(reader.GetOrdinal("Price"));
            Pizza pizza = new Pizza(id, name, description, price);
            if (reader.IsDBNull(reader.GetOrdinal("CategoryId")) == false)
            {
               // Da implementare
            }
            return pizza;
        }
    }
}
