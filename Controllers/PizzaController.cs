using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;
using PizzaApi.Services;

namespace PizzaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        // GET all action
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll()
        {
            return PizzaService.GetAll();

        }

        // GET by Id action
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if(pizza == null)
            {
                return NotFound($"The requested pizza of id {id} was not found");
            }

            return Ok(pizza);

        }

        // POST action
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);

            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if(pizza == null)
            {
                return BadRequest();
            }else if(pizza.Id != id)
            {
                return BadRequest();
            }

            var existingPizza = PizzaService.Get(id);
            //check if there is an existing item with the same id
            if(existingPizza != null)
            {
                return NotFound();
            }

            PizzaService.Update(pizza);

            return NoContent();

        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPizza = PizzaService.Get(id);
            if(existingPizza == null)
            {
                return NotFound();
            }

            PizzaService.Remove(id);

            return NoContent();
        }
    }
}
