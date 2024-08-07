using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodieMenu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IRestaurantRepository _repository;
        public CategoryController(IRestaurantRepository restaurantRepository)
        {
            _repository = restaurantRepository;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<CategoryController>/5/items
        [HttpGet("{id}/items")]
        public IActionResult GetItems(int id)
        {
            List<Item> items = _repository.GetItemsByCategoryID(id);
            if (items.Count == 0)
            {
                return NotFound();
            }
            return Ok(_repository.GetItemsByCategoryID(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
