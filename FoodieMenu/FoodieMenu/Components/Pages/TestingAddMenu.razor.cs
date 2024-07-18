namespace FoodieMenu.Components.Pages
{
    public partial class TestingAddMenu
    {
        private List<CategoryFormModel> Forms = new List<CategoryFormModel>();

        private void AddNewForm()
        {
            Forms.Add(new CategoryFormModel());
        }

        private class CategoryFormModel
        {
            public string CategoryName { get; set; }
            public string Description { get; set; }
        }
    }
}
