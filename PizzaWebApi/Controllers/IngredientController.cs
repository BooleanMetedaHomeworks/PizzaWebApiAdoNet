using Microsoft.AspNetCore.Mvc;
using PizzaWebApi.Models;
using PizzaWebApi.Repositories;

namespace PizzaWebApi.Controllers
{

    // CONSEGNA 05/02/2025 
    // Da implementare! :)
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IngredientRepository _ingredientRepository;

        public IngredientController(IngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Ingredient newIngredient)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                   
                }
                // Mi assicuro che Ingredient venga inserito, ma come?
                
                // Inserisci quel come sulla riga sopra
                
                int affectedRows = -1;
                return Ok(affectedRows);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Ingredient newIngredient)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    
                }
                int affectedRows = -1;
                if (affectedRows == 0)
                {
                    return NotFound();
                }
                return Ok(affectedRows);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                int affectedRows = -1;
                if (affectedRows == 0)
                {
                    return NotFound();
                }
                return Ok(affectedRows);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
