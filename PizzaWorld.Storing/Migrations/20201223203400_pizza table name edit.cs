using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class pizzatablenameedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Order_OrderEntityId",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "PizzaModels");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_OrderEntityId",
                table: "PizzaModels",
                newName: "IX_PizzaModels_OrderEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaModels",
                table: "PizzaModels",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaModels_Order_OrderEntityId",
                table: "PizzaModels",
                column: "OrderEntityId",
                principalTable: "Order",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaModels_Order_OrderEntityId",
                table: "PizzaModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaModels",
                table: "PizzaModels");

            migrationBuilder.RenameTable(
                name: "PizzaModels",
                newName: "Pizzas");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaModels_OrderEntityId",
                table: "Pizzas",
                newName: "IX_Pizzas_OrderEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Order_OrderEntityId",
                table: "Pizzas",
                column: "OrderEntityId",
                principalTable: "Order",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
