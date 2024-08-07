using FoodieMenu.Data;
using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using Microsoft.EntityFrameworkCore;
using FoodieMenu.Web.Components.Pages;
namespace FoodieMenu.Tests
{
    [TestClass]
    public class RestaurantRepositoryTest
    {
        private FoodieContext _dbContext;

        public RestaurantRepositoryTest()
        {
             _dbContext = new FoodieContext();
        }

        [TestMethod]
        public void AddARestaurant()
        {

        }

        private void DeleteMockData()
        {
            RestaurantRepository repository = new RestaurantRepository();
            List<Item> items = repository.GetAllItems();
            foreach (Item item in items)
            {
                _dbContext.Items.Remove(item);
            }

        }
    }
}