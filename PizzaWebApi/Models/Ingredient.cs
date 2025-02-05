namespace PizzaWebApi.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Ingredient() { }

        public Ingredient(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
