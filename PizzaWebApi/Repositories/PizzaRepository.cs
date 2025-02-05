using System.Data.SqlClient;
using PizzaWebApi.Models;

// Informazioni Classe:
// Bug presenti: 


namespace PizzaWebApi.Repositories
{
    public class PizzaRepository
    {
        public const string ConnectionString = "Data Source=localhost;Initial Catalog=PizzaDB;Integrated Security=True;";

        // CONSEGNA 05/02/2025
        public async Task<List<Pizza>> GetAllPizzas()
        {
            // Manca qualcosa e vedo pochi Join qui dentro :/
            string query = @"SELECT p.*, c.Id AS CategoryId, c.Name AS CategoryName 
                        FROM Pizzas p
                        LEFT JOIN Categories c ON p.CategoryId = c.Id";
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            Dictionary<int, Pizza> Pizzas = new Dictionary<int, Pizza>();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        GetPizzaFromData(reader, Pizzas);
                    }
                }
            }

            return Pizzas.Values.ToList();
        }
        // CONSEGNA 05/02/2025
        public async Task<List<Pizza>> GetPizzasByName(string name)
        {
            // Manca qualcosa e vedo pochi Join qui dentro :/
            string query = @"SELECT p.*, c.Id AS CategoryId, c.Name AS CategoryName 
                          FROM Pizzas p
                          LEFT JOIN Categories c ON p.CategoryId = c.Id
                          WHERE p.name=@name";
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            Dictionary<int, Pizza> Pizzas = new Dictionary<int, Pizza>();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@name", name));
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        GetPizzaFromData(reader, Pizzas);
                    }
                }
            }

            return Pizzas.Values.ToList();
        }
        // CONSEGNA 05/02/2025
        // Houston we have a problem!
        public async Task<Pizza> GetPizzaById(int id)
        {
             // sai che vedo pochi join qui? :/
            string query = @"SELECT TOP 1 p.*, c.Id AS CategoryId, c.Name AS CategoryName 
                          FROM Pizzas p
                          LEFT JOIN Categories c ON p.CategoryId = c.Id
                          WHERE p.id=@id";
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            Dictionary<int, Pizza> Pizzas = new Dictionary<int, Pizza>();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@id", id));
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        GetPizzaFromData(reader, Pizzas);
                    }
                }
            }
            return Pizzas.Values.FirstOrDefault();
        
        }
        // CONSEGNA 05/02/2025
        // houston we have bugs!
        public async Task<int> InsertPizza(Pizza pizza)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            string query = $"INSERT INTO Pizzas (Name, Description, Price, CategoryId) VALUES (@name, @description, @price, @categoryId)" +
                        $"SELECT SCOPE_IDENTITY();"; // SCOPE_IDENTITY: ci serve per ottenere l'ID appena inserito
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@name", pizza.Name));
                cmd.Parameters.Add(new SqlParameter("@description", pizza.Description));
                cmd.Parameters.Add(new SqlParameter("@price", pizza.Price));
                cmd.Parameters.Add(new SqlParameter("@categoryId", pizza.CategoryId ?? (object)DBNull.Value));

                int pizzaId = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                await HandleIngredients(new List<int>(), pizzaId, conn); //qualquadra non cosa 

                return pizzaId;
            }
        }

        // CONSEGNA 05/02/2025:
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


                int rowsAfected = await cmd.ExecuteNonQueryAsync();

                await HandleIngredients(new List<int>(), id, conn); //qualquadra non cosa 

                return rowsAfected;
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

        // CONSEGNA 05/02/2025
        // DA IMPLEMENTARE!
        private async Task<int> ClearPizzaIngredients(int PizzaId)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            string query = $"";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // da implementare
            }

            return -1; // da rimuovere
        }
        private async Task<int> AddPizzaIngredients(int PizzaId, List<int> Ingredients)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            int inserted = 0;
            foreach (int IngredientId in Ingredients)
            {
                // da implementare
            }
            return inserted;
        }

        private async Task HandleIngredients(List<int> Ingredients, int PizzaId, SqlConnection conn)
        {
            // Utility per gestire gli ingredienti aggiunti alla pizza
            
        }


        // CONSEGNA 05/02/2025
        private Pizza GetPizzaFromData(SqlDataReader reader, Dictionary<int, Pizza> pizzas)
        {
            int id = reader.GetInt32(reader.GetOrdinal("id"));
            if (pizzas.TryGetValue(id, out Pizza pizza) == false)
            {
                string name = reader.GetString(reader.GetOrdinal("Name"));
                string description = reader.GetString(reader.GetOrdinal("Description"));
                decimal price = reader.GetDecimal(reader.GetOrdinal("Price"));
                pizza = new Pizza(id, name, description, price);
                pizzas.Add(id, pizza);
            }

            if (reader.IsDBNull(reader.GetOrdinal("CategoryId")) == false)
            {
               // Da implementare
            }
            // CONSEGNA 2: Da implementare
            if (reader.IsDBNull(reader.GetOrdinal("IngredientId")) == false)
            {
                
            }
            return pizza;
        }
    }
}
