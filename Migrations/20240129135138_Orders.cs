using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItem_Car_carId",
                table: "ShopCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem");
            /*
            migrationBuilder.RenameTable(
                name: "ShopCart",
                newName: "ShopCart");
            */
            /*
            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItems_carId",
                table: "ShopCart",
                newName: "IX_ShopCartItem_carId");
            */
            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderID = table.Column<int>(type: "int", nullable: false),
                    carID = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Car_carID",
                        column: x => x.carID,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_orderID",
                        column: x => x.orderID,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_carID",
                table: "OrderDetails",
                column: "carID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_orderID",
                table: "OrderDetails",
                column: "orderID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_Car_carId",
                table: "ShopCartItem",
                column: "carId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItem_Car_carId",
                table: "ShopCartItem");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem");
            /*
            migrationBuilder.RenameTable(
                name: "ShopCartItem",
                newName: "ShopCartItems");
            */
            /*
            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItem_carId",
                table: "ShopCartItems",
                newName: "IX_ShopCartItems_carId");
            */
            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_Car_carId",
                table: "ShopCartItem",
                column: "carId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
