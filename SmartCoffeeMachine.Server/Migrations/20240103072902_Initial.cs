using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCoffeeMachine.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoffeeMachineStatus",
                columns: table => new
                {
                    CoffeeMachineID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOn = table.Column<bool>(type: "bit", nullable: false),
                    IsMakingCoffee = table.Column<bool>(type: "bit", nullable: false),
                    WaterLevelState = table.Column<int>(type: "int", nullable: false),
                    BeanFeedState = table.Column<int>(type: "int", nullable: false),
                    WasteCoffeeState = table.Column<int>(type: "int", nullable: false),
                    WaterTrayState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeMachineStatus", x => x.CoffeeMachineID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeMachineStatus");
        }
    }
}
