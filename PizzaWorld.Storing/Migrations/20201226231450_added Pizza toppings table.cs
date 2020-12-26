using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class addedPizzatoppingstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Toppings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APizzaModelEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_PizzaModels_APizzaModelEntityId",
                        column: x => x.APizzaModelEntityId,
                        principalTable: "PizzaModels",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_APizzaModelEntityId",
                table: "PizzaTopping",
                column: "APizzaModelEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaTopping");
        }
    }
}
