using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ePizza_JD.Models.Migrations
{
    public partial class removedTimeToPrepare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("1ed1de5b-0bbf-432b-b34f-a249e7a51200"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("26cfe7f5-c67c-4a04-99da-33c0ab68558a"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("5ae266d0-558e-4345-87cd-77b5811b2b0d"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("c79c0a93-09b0-433b-b19b-7e129ef39a24"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("cbb0c4ac-c9d9-496c-834f-f473db1921ac"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("d8e6877b-98bc-4a69-ab23-e3dd76e7a2ff"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("ec51a69a-8572-4968-9878-08739eac738e"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("efa7b3d7-7df4-4295-ab36-c80e80ce4095"));

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: new Guid("30ea1ba0-fbdd-44ff-a487-1f835afc0134"));

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: new Guid("905fd5bc-cd89-4862-817e-a73d80c9330b"));

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: new Guid("b50951e5-0790-46b7-bc15-413fdcaca7b5"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("138c6493-d2fd-4e9e-9fdc-e44b92cbb12e"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("1642d747-bc19-4084-a898-9b39b25002c6"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("22ed4bce-ee33-40b0-9f4c-050cdfc9c799"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("3724ce66-c091-4fcc-aa16-179bb4ad286a"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("3cd57dfa-372a-4683-a5a2-7732bb29b062"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("487283fe-19bc-4d2a-a307-670dc3330a3c"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("4a4cfb2e-42dc-434f-942c-7d66d241bb05"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("67803285-4117-43f1-afa6-fc7c5db54186"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("87fda82d-a1da-4b67-a530-fa9fb8d0f5ea"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("8d17630a-15ac-4d6a-ab71-4d655b9d9dda"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("b8215916-922a-4c84-989e-ceec6a29a095"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("d27997ab-b174-48d8-b3a8-3fc8c0cfcce6"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("fdce7470-88b6-444f-868f-0fc61f4ed027"));

            migrationBuilder.DropColumn(
                name: "TimeToPrepare",
                table: "PizzaToppings");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("bba2eded-d219-4618-b0ce-c3a983772772"),
                column: "Date",
                value: new DateTime(2020, 11, 11, 17, 30, 39, 269, DateTimeKind.Local).AddTicks(647));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e68a3f79-ba5a-49f3-95c7-5e38298e7fde"),
                column: "Date",
                value: new DateTime(2020, 11, 11, 17, 30, 39, 265, DateTimeKind.Local).AddTicks(884));

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaId", "ImgUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("e8c0f7eb-967c-4a5b-9269-577f4d229daa"), "https://cdn-catalog.pizzahut.be/images/be/20170830145527344.jpg", "Barbecue", 10.4 },
                    { new Guid("e98e51c6-74a1-4dbb-8064-9018dc8da5f7"), "https://cdn-catalog.pizzahut.be/images/be/20170830145618975.jpg", "Parma", 8.0999999999999996 },
                    { new Guid("7062017e-de4f-47b1-a033-35dabadb3d2c"), "https://cdn-catalog.pizzahut.be/images/be/20170830145855396.jpg", "Forestiere", 10.300000000000001 },
                    { new Guid("b3f8a9e5-d37d-4d0d-834c-3f4c0eed0f7a"), "https://cdn-catalog.pizzahut.be/images/be/20170830145952504.jpg", "Hawaiian", 9.5 },
                    { new Guid("dc4d4dec-a818-4d7f-b573-597f3b2ae10b"), "https://cdn-catalog.pizzahut.be/images/be/20170830145444334.jpg", "4 Cheeses", 10.9 },
                    { new Guid("11b32453-28ab-4600-a4fb-4dc8eb4a5d22"), "https://cdn-catalog.pizzahut.be/images/be/20170830150015440.jpg", "Hot 'n Spicy", 10.199999999999999 },
                    { new Guid("f7d637d6-22c4-4c57-9b6b-c4bffb33e3ab"), "https://cdn-catalog.pizzahut.be/images/be/20170830145601044.jpg", "Barbecue Chicken", 10.199999999999999 },
                    { new Guid("a6bcedff-523d-4e47-a9f2-93f6533f1dc5"), "https://cdn-catalog.pizzahut.be/images/be/20171229145324596.jpg", "Tuna", 9.4000000000000004 }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "City", "HouseNumber", "PhoneNumber", "RestaurantName", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("455c8610-4d64-4c3f-9b85-4087a9c76bb5"), "Brugge", 160, "0471 32 89746", "The little italian", "Lange Elzenstraat", 8200 },
                    { new Guid("cbe4c636-5368-4829-b593-329988d11fd8"), "Ieper", 351, "0491 82 74431", "Pastasciutta", "Stationsstraat", 8900 },
                    { new Guid("8e129188-72bc-44d5-8f96-9f3182c8be3c"), "Antwerpen", 399, "0494 26 36224", "Mamma in cucina", "Herentalsebaan", 2000 }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("0eae9dca-640f-408e-8aa5-325f40cb3eee"),
                column: "Date",
                value: new DateTime(2020, 11, 11, 17, 30, 39, 269, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("c456b9e8-d32c-4d6e-8b32-da50c5edc856"),
                column: "Date",
                value: new DateTime(2020, 11, 11, 17, 30, 39, 269, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("31dddec6-b32f-4efe-8281-072bbe86b8f5"), "Paprika", 1.3999999999999999 },
                    { new Guid("ca5f9560-779f-41fb-9feb-d08cadfb1cf4"), "Gorgonzola", 1.3999999999999999 },
                    { new Guid("bbbf0223-5104-46f3-80f2-05398458d3ac"), "Goat cheese", 1.3999999999999999 },
                    { new Guid("cf65bf49-92bc-485b-980f-a7ee1bf09341"), "Pork", 1.3999999999999999 },
                    { new Guid("16a56577-8c00-4929-9947-7bfb7d369704"), "Chilipepper", 1.3999999999999999 },
                    { new Guid("7e581024-a794-42b3-826e-de7fd05437d3"), "Grilled Chicken", 1.3999999999999999 },
                    { new Guid("d4940157-b8ac-4549-bef7-44c0dc9dcdcc"), "Red onion", 1.3999999999999999 },
                    { new Guid("4bb06cbe-0c40-4087-854e-a11940143810"), "Pineapple", 1.3999999999999999 },
                    { new Guid("945cff6c-e01e-4690-945e-668f7df707ce"), "Champignons", 1.3999999999999999 },
                    { new Guid("74ecca50-b0dc-4df2-b356-1fecd2b37d5f"), "Mozzarella", 1.3999999999999999 },
                    { new Guid("0bd08daa-d782-483b-baf4-5d0edf06beef"), "Ham", 1.3999999999999999 },
                    { new Guid("924594f2-dd2c-4932-b569-fe35ef217c33"), "Barbecue sauce", 1.3999999999999999 },
                    { new Guid("bc71f9f2-ff80-4701-93db-e4d7b1685624"), "Pepperoni", 1.3999999999999999 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("11b32453-28ab-4600-a4fb-4dc8eb4a5d22"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("7062017e-de4f-47b1-a033-35dabadb3d2c"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("a6bcedff-523d-4e47-a9f2-93f6533f1dc5"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("b3f8a9e5-d37d-4d0d-834c-3f4c0eed0f7a"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("dc4d4dec-a818-4d7f-b573-597f3b2ae10b"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("e8c0f7eb-967c-4a5b-9269-577f4d229daa"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("e98e51c6-74a1-4dbb-8064-9018dc8da5f7"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("f7d637d6-22c4-4c57-9b6b-c4bffb33e3ab"));

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: new Guid("455c8610-4d64-4c3f-9b85-4087a9c76bb5"));

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: new Guid("8e129188-72bc-44d5-8f96-9f3182c8be3c"));

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: new Guid("cbe4c636-5368-4829-b593-329988d11fd8"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("0bd08daa-d782-483b-baf4-5d0edf06beef"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("16a56577-8c00-4929-9947-7bfb7d369704"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("31dddec6-b32f-4efe-8281-072bbe86b8f5"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("4bb06cbe-0c40-4087-854e-a11940143810"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("74ecca50-b0dc-4df2-b356-1fecd2b37d5f"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("7e581024-a794-42b3-826e-de7fd05437d3"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("924594f2-dd2c-4932-b569-fe35ef217c33"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("945cff6c-e01e-4690-945e-668f7df707ce"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("bbbf0223-5104-46f3-80f2-05398458d3ac"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("bc71f9f2-ff80-4701-93db-e4d7b1685624"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("ca5f9560-779f-41fb-9feb-d08cadfb1cf4"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("cf65bf49-92bc-485b-980f-a7ee1bf09341"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("d4940157-b8ac-4549-bef7-44c0dc9dcdcc"));

            migrationBuilder.AddColumn<int>(
                name: "TimeToPrepare",
                table: "PizzaToppings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("bba2eded-d219-4618-b0ce-c3a983772772"),
                column: "Date",
                value: new DateTime(2020, 11, 9, 18, 58, 22, 828, DateTimeKind.Local).AddTicks(2030));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e68a3f79-ba5a-49f3-95c7-5e38298e7fde"),
                column: "Date",
                value: new DateTime(2020, 11, 9, 18, 58, 22, 824, DateTimeKind.Local).AddTicks(5144));

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaId", "ImgUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("efa7b3d7-7df4-4295-ab36-c80e80ce4095"), "https://cdn-catalog.pizzahut.be/images/be/20170830145527344.jpg", "Barbecue", 10.4 },
                    { new Guid("cbb0c4ac-c9d9-496c-834f-f473db1921ac"), "https://cdn-catalog.pizzahut.be/images/be/20170830145618975.jpg", "Parma", 8.0999999999999996 },
                    { new Guid("26cfe7f5-c67c-4a04-99da-33c0ab68558a"), "https://cdn-catalog.pizzahut.be/images/be/20170830145855396.jpg", "Forestiere", 10.300000000000001 },
                    { new Guid("c79c0a93-09b0-433b-b19b-7e129ef39a24"), "https://cdn-catalog.pizzahut.be/images/be/20170830145952504.jpg", "Hawaiian", 9.5 },
                    { new Guid("d8e6877b-98bc-4a69-ab23-e3dd76e7a2ff"), "https://cdn-catalog.pizzahut.be/images/be/20170830145444334.jpg", "4 Cheeses", 10.9 },
                    { new Guid("ec51a69a-8572-4968-9878-08739eac738e"), "https://cdn-catalog.pizzahut.be/images/be/20170830150015440.jpg", "Hot 'n Spicy", 10.199999999999999 },
                    { new Guid("5ae266d0-558e-4345-87cd-77b5811b2b0d"), "https://cdn-catalog.pizzahut.be/images/be/20170830145601044.jpg", "Barbecue Chicken", 10.199999999999999 },
                    { new Guid("1ed1de5b-0bbf-432b-b34f-a249e7a51200"), "https://cdn-catalog.pizzahut.be/images/be/20171229145324596.jpg", "Tuna", 9.4000000000000004 }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "City", "HouseNumber", "PhoneNumber", "RestaurantName", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("b50951e5-0790-46b7-bc15-413fdcaca7b5"), "Brugge", 160, "0471 32 89746", "The little italian", "Lange Elzenstraat", 8200 },
                    { new Guid("30ea1ba0-fbdd-44ff-a487-1f835afc0134"), "Ieper", 351, "0491 82 74431", "Pastasciutta", "Stationsstraat", 8900 },
                    { new Guid("905fd5bc-cd89-4862-817e-a73d80c9330b"), "Antwerpen", 399, "0494 26 36224", "Mamma in cucina", "Herentalsebaan", 2000 }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("0eae9dca-640f-408e-8aa5-325f40cb3eee"),
                column: "Date",
                value: new DateTime(2020, 11, 9, 18, 58, 22, 828, DateTimeKind.Local).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("c456b9e8-d32c-4d6e-8b32-da50c5edc856"),
                column: "Date",
                value: new DateTime(2020, 11, 9, 18, 58, 22, 828, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("8d17630a-15ac-4d6a-ab71-4d655b9d9dda"), "Paprika", 1.3999999999999999 },
                    { new Guid("3724ce66-c091-4fcc-aa16-179bb4ad286a"), "Gorgonzola", 1.3999999999999999 },
                    { new Guid("4a4cfb2e-42dc-434f-942c-7d66d241bb05"), "Goat cheese", 1.3999999999999999 },
                    { new Guid("67803285-4117-43f1-afa6-fc7c5db54186"), "Pork", 1.3999999999999999 },
                    { new Guid("138c6493-d2fd-4e9e-9fdc-e44b92cbb12e"), "Chilipepper", 1.3999999999999999 },
                    { new Guid("d27997ab-b174-48d8-b3a8-3fc8c0cfcce6"), "Grilled Chicken", 1.3999999999999999 },
                    { new Guid("22ed4bce-ee33-40b0-9f4c-050cdfc9c799"), "Red onion", 1.3999999999999999 },
                    { new Guid("fdce7470-88b6-444f-868f-0fc61f4ed027"), "Pineapple", 1.3999999999999999 },
                    { new Guid("3cd57dfa-372a-4683-a5a2-7732bb29b062"), "Champignons", 1.3999999999999999 },
                    { new Guid("1642d747-bc19-4084-a898-9b39b25002c6"), "Mozzarella", 1.3999999999999999 },
                    { new Guid("487283fe-19bc-4d2a-a307-670dc3330a3c"), "Ham", 1.3999999999999999 },
                    { new Guid("b8215916-922a-4c84-989e-ceec6a29a095"), "Barbecue sauce", 1.3999999999999999 },
                    { new Guid("87fda82d-a1da-4b67-a530-fa9fb8d0f5ea"), "Pepperoni", 1.3999999999999999 }
                });
        }
    }
}
