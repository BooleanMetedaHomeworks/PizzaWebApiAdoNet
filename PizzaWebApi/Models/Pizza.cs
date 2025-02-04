using System.ComponentModel.DataAnnotations;

namespace PizzaWebApi.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(20, ErrorMessage = "Il titolo non può avere più di 20 caratteri")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0.1, 10000)]
        public decimal Price { get; set; }
        public int? CategoryId { get; set; } // Chiave esterna (può essere NULL, i.e. una pizza può non avere una categoria)
        public Category? Category { get; set; } // Proprietà di navigazione (? => non richiesta)

        public Pizza()
        {
        }

        public Pizza(int id, string name, string description, decimal price) : this(name, description, price)
        {
            this.Id = id;
        }
        public Pizza(string name, string description, decimal price) : this()
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }
    }
}
