using FoodieMenu.Data.Repositories;
using FoodieMenu.Data;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Components;
using FoodieMenu.Domain.Menu;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace FoodieMenu.Web.Components.Pages.RestaurantDashboard
{
    public partial class UpdateMenu
    {
        [Parameter]
        public int MenuID { get; set; }
        [Inject]
        IRestaurantRepository repository { get; set; }
        private Restaurant restaurant { get; set; }
        private Menu menu { get; set; }
        private Item? ItemToEdit { get; set; }
        private Category? CategoryToEdit { get; set; }
        private Category? CategoryToDelete { get; set; }
        protected override Task OnInitializedAsync()
        {
            menu = repository.GetMenuByID(MenuID);
            restaurant = repository.GetRestaurantById(menu.RestaurantID);
            menu = restaurant.Menus.Single(x => x.MenuID == MenuID);
            return base.OnInitializedAsync();
        }

        private void DeleteCategoryWithoutMovingItems()
        {
            List<Item> itemsToDelete = [];
            foreach (Item item in CategoryToDelete.Items)
            {
                if (item.Categories.Count == 1)
                {
                    itemsToDelete.Add(item);
                }
            }
            foreach (Item item in itemsToDelete)
            {
                repository.RemoveItem(item);
            }
            repository.RemoveCategory(CategoryToDelete);
            return;
        }
        private void UpdateItem()
        {
            repository.UpdateItem(ItemToEdit);
            ItemToEdit = null;
        }
        private void DeleteItem(Item itemToRemove, Category categoryToRemoveFrom)
        {
            // This method Deletes an item from the category of the menu, if the Item only appears in that category the method will 
            // remove the item entity
            if (itemToRemove.Categories.Count == 1)
            {
                repository.RemoveItem(itemToRemove);
            } else
            {
                itemToRemove.Categories.Remove(categoryToRemoveFrom);
                categoryToRemoveFrom.Items.Remove(itemToRemove);
                repository.UpdateRestaurant(restaurant);
            }
            ItemToEdit = null;
        }
        private void MoveItemsToExistingCategory(Category DestinationCategory)
        {
            foreach (Item item in CategoryToDelete.Items)
            {
                DestinationCategory.Items.Add(item);
            }
            menu.Categories.Remove(CategoryToDelete);
            repository.UpdateRestaurant(restaurant);
        }
        private void UpdateCategory(Category category)
        {
            repository.UpdateCategory(category);
            CategoryToEdit = null;
        }
    }
}
