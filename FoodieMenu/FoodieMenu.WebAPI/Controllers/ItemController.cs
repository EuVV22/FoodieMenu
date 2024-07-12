using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodieMenu.Domain.Menu;
using FoodieMenu.Data;

namespace FoodieMenu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private FoodieContext _foodieContext;
        [HttpGet]
        public Item Get()
        {
            _foodieContext = new FoodieContext();

            return _foodieContext.Items.Single; 
        }
    }
}
