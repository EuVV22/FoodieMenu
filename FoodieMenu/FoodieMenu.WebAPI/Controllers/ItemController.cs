using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodieMenu.Domain.Menu;
using FoodieMenu.Data;
using FoodieMenu.Data.Repositories;

namespace FoodieMenu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IRestaurantRepository _repository { get; set; }

        public ItemController(IRestaurantRepository Repository)
        {
            _repository = Repository;
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            List<Item> items = _repository.GetAllItems();
            if (items == null || items.Count == 0)
            {
                return NotFound();
            }
            return Ok(items);
        }

        


    }
}
