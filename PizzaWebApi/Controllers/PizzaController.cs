using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using PizzaWebApi.Models;
using PizzaWebApi.Repositories;

namespace PizzaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        // NO HO DIMENTICATO LA DEPENCY INJECTION NEL CARRELLO!
        private readonly PizzaRepository _pizzaRepo = new PizzaRepository();
        
        
        [HttpGet]
        public async Task<IActionResult> Get(string? name)
        {
            try
            {
                if (name != null) return Ok(await _pizzaRepo.GetPizzasByName(name));
                return Ok(await _pizzaRepo.GetAllPizzas());
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
                Pizza pizza = await _pizzaRepo.GetPizzaById(id);
                if (pizza == null)
                    return NotFound();
                return Ok(pizza);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pizza newPizza)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState.Values);
                }
                newPizza.Id = 0; // Mi assicuro che il Pizza venga inserito
                int affectedRows = await _pizzaRepo.InsertPizza(newPizza);
                return Ok(affectedRows);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Pizza newPizza)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState.Values);
                }
                int affectedRows = await _pizzaRepo.UpdatePizza(id, newPizza);
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
                int affectedRows = await _pizzaRepo.DeletePizza(id);
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
