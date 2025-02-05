using System.Data.SqlClient;
using PizzaWebApi.Models;

namespace PizzaWebApi.Repositories
{
    public class IngredientRepository
    {
        public const string CONNECTION_STRING = "Data Source=localhost;Initial Catalog=PizzaDB;Integrated Security=True;";
        // CONSEGNA 05/02/2025
        // DA IMPLEMENTARE!
        public async Task<List<Ingredient>> GetAllIngredients()
        {
            string query = @"SELECT * FROM Ingredients";
            using SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            await conn.OpenAsync();

            List<Ingredient> Ingredients = new List<Ingredient>();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
       
                }
            }

            return Ingredients;
        }

        public async Task<Ingredient> GetIngredientById(int id)
        {
            string query = @"";
            using SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            await conn.OpenAsync();

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@id", id));
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
               
                }
            }

            return null;
        }

        public async Task<int> InsertIngredient(Ingredient Ingredient)
        {
            using SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            await conn.OpenAsync();

            string query = $"";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {

            }
        }

        public async Task<int> UpdateIngredient(int id, Ingredient Ingredient)
        {
            using SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            await conn.OpenAsync();

            string query = $"";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {

            }

            return -1; // da rimuovere!
        }

        public async Task<int> DeleteIngredient(int id)
        {
            using SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            await conn.OpenAsync();

            await ClearPostIngredients(id); // QUESTA COSA È IMPORTANTE!!!
            string query = $"";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                
            }
            return -1;
        }

        private async Task<int> ClearPostIngredients(int id)
        {
            using SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            await conn.OpenAsync();

            string query = $"";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
        
            }
            return -1; // da rimuovere 
        }

        private Ingredient GetIngredientFromData(SqlDataReader reader)
        {
       
            return new Ingredient();
        }
    }
}