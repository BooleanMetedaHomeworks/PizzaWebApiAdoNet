using System.Data.SqlClient;
using PizzaWebApi.Models;

namespace PizzaWebApi.Repositories
{
    public class CategoryRepository
    {
        public const string ConnectionString = "Data Source=localhost;Initial Catalog=PizzaDB;Integrated Security=True;";

        private readonly PizzaRepository _pizzaRepo = new PizzaRepository(); // Dipende, da che dipende, da che punto tu lo guardi tutto dipende!
                                                                             // Ah... no... non dovrebbe dipendere
        
                                                                             
        /*
         * DA COMPLETARE:
         * GET
         * CREATE
         * UPDATE
         * DELETE
         */
        public async Task<Category> GetCategoryById(int id)
        {
            string query = @"";
            using SqlConnection conn = new SqlConnection();
            await conn.OpenAsync();

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                
            }
            return null;
        }
        public async Task<int> InsertCategory(Category category)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            string query = $"";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
           
            }
            return -1;
        }
        public async Task<int> UpdateCategory(int id, Category category)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            string query = $"";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
            }

            return -1;
        }
        
        public async Task<int> DeleteCategory(int id)
        {
            await //... ma cosa?
                
            using SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            string query = $"";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
            }

            return -1;
        }
        
        
        // Questa funzione non è molto ottimizzata :(!
        // Houston we have a bug!
        public async Task<List<Category>> GetAllCategories()
        {
            string query = @"SELECT *
                        FROM Categories";
            
            SqlConnection conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync();

            List<Category> categories = new List<Category>();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            do 
            {
                categories.Add(GetCategoryFromData(reader));
            }
            while(await reader.ReadAsync());
            return categories;
        }
        
        // Houston we have a bug! 
        public async Task<List<Category>> GetCategoriesByName(string name)
        {
            string query = @"SELECT *
                          FROM PizzaCategories
                          WHERE Name=@name";
            using SqlConnection conn = new SqlConnection();
            await conn.OpenAsync();

            List<Category> categories = new List<Category>();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                await conn.CloseAsync();
                cmd.Parameters.Add(new SqlParameter("@n", name));
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        categories.Add(GetCategoryFromData(reader));
                    }
                }
            }

            return categories;
        }
        
        // Da completare - Potrei essere tanto utile come funzione per fare meno lavoro nelle altre....
        private Category GetCategoryFromData(SqlDataReader reader)
        {
            return new(); // 
        }
    }
}
