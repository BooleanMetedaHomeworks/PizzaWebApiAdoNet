using Microsoft.AspNetCore.Mvc;
using PizzaWebApi.Models;
using PizzaWebApi.Repositories;

namespace PizzaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        // For depency injection click here --> https://rb.gy/2rcncm
        //  If first link is not enough --> https://rb.gy/9utf06
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();

        /*
         * Da implementare
         */
        [HttpGet]
        public async Task<IActionResult> Get(string? name)
        {
            
            try
            {
                if (name != null)
                {
                    
                }
                
                return Ok();
            }
            catch (Exception e)
            {
                
            }
            return BadRequest(); // da togliere da qui
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Category? category = null;
                if (category == null)
                {
                    
                }
                
            }
            catch (Exception e)
            {
                
            }

            return BadRequest(); // da togliere da qui
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category newCategory)
        {
            try
            {
                if (!ModelState.IsValid == false)
                { 
                    
                }

                /* newCategory.Qualcosa = Altro */ // Qui mi dovrei assicurare che la categoria venga inserita, ma come?
                int affectedRows = -1;
                
            }
            catch (Exception e)
            {
                
            }
            
            return BadRequest(); // da togliere da qui
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Category newCategory)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    
                }

                int affectedRows = -1;
                if ( affectedRows == 0)
                {
                    
                }
                
            }
            catch (Exception e)
            {
            }
            return BadRequest(); // da togliere da qui
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                int affectedRows = -1;
                if (affectedRows == 0)
                {
                   
                }
                
            }
            catch (Exception e)
            {
                
            }
            return BadRequest(); // da togliere da qui
        }
    }
}
