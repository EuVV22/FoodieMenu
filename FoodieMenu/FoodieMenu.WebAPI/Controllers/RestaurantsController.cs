using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodieMenu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private IRestaurantRepository _repository {  get; set; }
        public RestaurantsController(IRestaurantRepository restaurantRepository)
        {
            _repository = restaurantRepository;
        }
        // GET: api/<RestaurantsController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Restaurant> restaurants = _repository.GetAllRestaurant();
            if (restaurants == null || restaurants.Count == 0)
            {
                return NotFound();
            }
            return Ok(_repository.GetAllRestaurant());
        }

        // GET api/<RestaurantsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RestaurantsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RestaurantsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestaurantsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
