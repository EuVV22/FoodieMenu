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

        // GET api/<ItemController>
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

        // POST api/<ItemController>
        [HttpPost]
        public void Post([FromBody] Item item)
        {
            _repository.AddItem(item);
        }

        // PUT api/<ItemController>
        [HttpPut]
        public void Put([FromBody] Item item)
        {
            _repository.UpdateItem(item);
        }

        // DELETE api/<ItemController>
        [HttpDelete]
        public void Delete([FromBody] Item item)
        {
            _repository.RemoveItem(item);
        }
    }
}
