using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodieMenu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IRestaurantRepository _repository {  get; set; }
        public MenuController(IRestaurantRepository restaurantRepository)
        {
            _repository = restaurantRepository;
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public Menu Get(int id)
        {
            Menu menu = _repository.GetMenuByID(id);
            if (menu == null)
            {
                return null;
            }
            menu.Categories.Clear();
            return menu;
        }

        // POST api/<MenuController>
        [HttpPost]
        public void Post([FromBody] Menu menu)
        {
            _repository.AddMenu(menu);
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Menu menu)
        {
            Menu foundMenu = _repository.GetMenuByID(id);
            if (foundMenu == null)
            {
                return NotFound();
            }
            _repository.UpdateMenu(menu);
            return Ok(_repository.GetMenuByID(id));
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Menu menu = _repository.GetMenuByID(id);
            if(menu == null)
            {
                return BadRequest();
            }
            _repository.RemoveMenu(menu);
            return Ok();
        }
    }
}
