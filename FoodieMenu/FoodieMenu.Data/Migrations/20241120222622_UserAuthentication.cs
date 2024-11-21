using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodieMenu.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserAuthentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantUserAccount",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "INTEGER", nullable: false),
                    restaurantsRestaurantID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantUserAccount", x => new { x.UsersId, x.restaurantsRestaurantID });
                    table.ForeignKey(
                        name: "FK_RestaurantUserAccount_Restaurants_restaurantsRestaurantID",
                        column: x => x.restaurantsRestaurantID,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantUserAccount_UserAccounts_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantUserAccount_restaurantsRestaurantID",
                table: "RestaurantUserAccount",
                column: "restaurantsRestaurantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantUserAccount");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
