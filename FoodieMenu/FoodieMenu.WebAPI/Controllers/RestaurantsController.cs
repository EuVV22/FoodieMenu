using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
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
            return Ok(restaurants);
        }

        // GET api/<RestaurantsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Restaurant restaurant = _repository.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            DepopulateItemCategoryFromRestaurant(ref restaurant);
            return Ok(restaurant);
        }

        // GET api/<RestaurantsController>/5/menus
        [HttpGet("{id}/menus")]
        public IActionResult GetMenus(int id)
        {
            Restaurant restaurant = _repository.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            DepopulateItemCategoryFromRestaurant(ref restaurant);
            return Ok(restaurant.Menus);
        }

        // POST api/<RestaurantsController>
        [HttpPost]
        public void Post([FromBody] Restaurant restaurant)
        {
            _repository.AddRestaurant(restaurant);
        }

        // PUT api/<RestaurantsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Restaurant restaurant)
        {
            Restaurant foundRestaurant = _repository.GetRestaurantById(id);
            if (foundRestaurant == null)
            {
                return BadRequest();
            }
            _repository.UpdateRestaurant(restaurant);
            return Ok(_repository.GetRestaurantById(id));
        }

        // DELETE api/<RestaurantsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Restaurant restaurant = _repository.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            _repository.RemoveRestaurant(restaurant);
            return Ok();
        }

        private void DepopulateItemCategoryFromMenu(ref Menu menu)
        {
            foreach (Category category in menu.Categories)
            {
                foreach (Item item in category.Items)
                {
                    item.Categories = [];
                }
            }
        }

        private void DepopulateItemCategoryFromRestaurant(ref Restaurant restaurant)
        {
            foreach (Item item in  restaurant.Items)
            {
                item.Categories = [];
            }

            foreach (Menu menu in restaurant.Menus)
            {
                foreach (Category category in menu.Categories)
                {
                    foreach (Item item in category.Items)
                    {
                        item.Categories = [];
                    }
                }
            }
        }
    }
}
