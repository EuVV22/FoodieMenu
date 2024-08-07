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
        // GET: api/<MenuController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
