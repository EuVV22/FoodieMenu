using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodieMenu.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingTheRestaurantClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Menus_RestaurantID",
                table: "Menus",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_RestaurantID",
                table: "Items",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_RestaurantID",
                table: "Address",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Restaurants_RestaurantID",
                table: "Address",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "RestaurantID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Restaurants_RestaurantID",
                table: "Items",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "RestaurantID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurants_RestaurantID",
                table: "Menus",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "RestaurantID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Restaurants_RestaurantID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Restaurants_RestaurantID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_RestaurantID",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_RestaurantID",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Items_RestaurantID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Address_RestaurantID",
                table: "Address");
        }
    }
}
