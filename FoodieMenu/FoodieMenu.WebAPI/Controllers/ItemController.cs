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
        [HttpGet]
        public Item Get()
        {

            return new Item();
        }
    }
}
