using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ePizza_JD.Models.Migrations
{
    public partial class connectionDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("0d712c40-b04a-4342-a917-0987a7238df6"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("182ac64a-f6bf-4ed7-88ea-f05c4f2b4f63"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("24d65f7c-8424-424a-85ff-c0a77716d73d"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("5da832eb-fa3a-464b-8742-6154c63f27c8"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("aa0c01f8-8f8a-499e-a416-e7db817e031b"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("bfddd0b6-bd7f-48f2-8061-c1f36fc97b6e"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("de697af5-de2f-4225-bf11-0b7470e78f94"));

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: new Guid("eda48766-fea5-4b5e-8430-d69b8091264e"));

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: new Guid("56942d34-dec4-47e8-8d57-09950ca7e39d"));

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: new Guid("a3ed2a10-5ffb-4f0f-8931-8fca67d122b6"));

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: new Guid("e7e2be71-8253-46c8-8006-a4584df72968"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("092cbb78-03bc-4b02-af23-4c0e94b88bdb"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("25f4f72a-14dc-42dc-83b3-92c9ee1fb90f"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("26a5832b-0703-4cfd-84ab-2b0dcd06c8b7"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("5958ed99-60a4-40b3-858b-c99be491e0a4"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("8da43f2a-8927-4fab-8ea9-11890145ffb0"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("95a39c80-598e-4a72-85c7-082476b8ba0f"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("d255b839-bbdc-4b86-9a0d-6b23cd03dcaa"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("d7d67226-d4ea-4ffe-a9f1-f02a8e375a23"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("e0e52f4d-dc26-44ed-bef9-c06dcf1deffb"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("e7bff715-211c-43d9-9873-b395d961cbbf"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("e8396e06-7cb4-4588-b2f6-a91f81624d9b"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("e97bfd04-f464-4fa0-9712-85e47f536f64"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("f3b72b4a-a12d-4547-84bd-7cd5a150e918"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("bba2eded-d219-4618-b0ce-c3a983772772"),
                column: "Date",
                value: new DateTime(2020, 11, 8, 22, 12, 6, 983, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e68a3f79-ba5a-49f3-95c7-5e38298e7fde"),
                column: "Date",
                value: new DateTime(2020, 11, 8, 22, 12, 6, 980, DateTimeKind.Local).AddTicks(2458));

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaId", "ImgUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("182ac64a-f6bf-4ed7-88ea-f05c4f2b4f63"), "https://cdn-catalog.pizzahut.be/images/be/20170830145527344.jpg", "Barbecue", 10.4 },
                    { new Guid("eda48766-fea5-4b5e-8430-d69b8091264e"), "https://cdn-catalog.pizzahut.be/images/be/20170830145618975.jpg", "Parma", 8.0999999999999996 },
                    { new Guid("5da832eb-fa3a-464b-8742-6154c63f27c8"), "https://cdn-catalog.pizzahut.be/images/be/20170830145855396.jpg", "Forestiere", 10.300000000000001 },
                    { new Guid("0d712c40-b04a-4342-a917-0987a7238df6"), "https://cdn-catalog.pizzahut.be/images/be/20170830145952504.jpg", "Hawaiian", 9.5 },
                    { new Guid("aa0c01f8-8f8a-499e-a416-e7db817e031b"), "https://cdn-catalog.pizzahut.be/images/be/20170830145444334.jpg", "4 Cheeses", 10.9 },
                    { new Guid("de697af5-de2f-4225-bf11-0b7470e78f94"), "https://cdn-catalog.pizzahut.be/images/be/20170830150015440.jpg", "Hot 'n Spicy", 10.199999999999999 },
                    { new Guid("bfddd0b6-bd7f-48f2-8061-c1f36fc97b6e"), "https://cdn-catalog.pizzahut.be/images/be/20170830145601044.jpg", "Barbecue Chicken", 10.199999999999999 },
                    { new Guid("24d65f7c-8424-424a-85ff-c0a77716d73d"), "https://cdn-catalog.pizzahut.be/images/be/20171229145324596.jpg", "Tuna", 9.4000000000000004 }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "City", "HouseNumber", "PhoneNumber", "RestaurantName", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("e7e2be71-8253-46c8-8006-a4584df72968"), "Brugge", 160, "0471 32 89746", "The little italian", "Lange Elzenstraat", 8200 },
                    { new Guid("56942d34-dec4-47e8-8d57-09950ca7e39d"), "Ieper", 351, "0491 82 74431", "Pastasciutta", "Stationsstraat", 8900 },
                    { new Guid("a3ed2a10-5ffb-4f0f-8931-8fca67d122b6"), "Antwerpen", 399, "0494 26 36224", "Mamma in cucina", "Herentalsebaan", 2000 }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("0eae9dca-640f-408e-8aa5-325f40cb3eee"),
                column: "Date",
                value: new DateTime(2020, 11, 8, 22, 12, 6, 984, DateTimeKind.Local).AddTicks(139));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("c456b9e8-d32c-4d6e-8b32-da50c5edc856"),
                column: "Date",
                value: new DateTime(2020, 11, 8, 22, 12, 6, 983, DateTimeKind.Local).AddTicks(8655));

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("f3b72b4a-a12d-4547-84bd-7cd5a150e918"), "Paprika", 1.3999999999999999 },
                    { new Guid("e7bff715-211c-43d9-9873-b395d961cbbf"), "Gorgonzola", 1.3999999999999999 },
                    { new Guid("5958ed99-60a4-40b3-858b-c99be491e0a4"), "Goat cheese", 1.3999999999999999 },
                    { new Guid("e8396e06-7cb4-4588-b2f6-a91f81624d9b"), "Pork", 1.3999999999999999 },
                    { new Guid("092cbb78-03bc-4b02-af23-4c0e94b88bdb"), "Chilipepper", 1.3999999999999999 },
                    { new Guid("e97bfd04-f464-4fa0-9712-85e47f536f64"), "Grilled Chicken", 1.3999999999999999 },
                    { new Guid("25f4f72a-14dc-42dc-83b3-92c9ee1fb90f"), "Red onion", 1.3999999999999999 },
                    { new Guid("d255b839-bbdc-4b86-9a0d-6b23cd03dcaa"), "Pineapple", 1.3999999999999999 },
                    { new Guid("8da43f2a-8927-4fab-8ea9-11890145ffb0"), "Champignons", 1.3999999999999999 },
                    { new Guid("e0e52f4d-dc26-44ed-bef9-c06dcf1deffb"), "Mozzarella", 1.3999999999999999 },
                    { new Guid("26a5832b-0703-4cfd-84ab-2b0dcd06c8b7"), "Ham", 1.3999999999999999 },
                    { new Guid("95a39c80-598e-4a72-85c7-082476b8ba0f"), "Barbecue sauce", 1.3999999999999999 },
                    { new Guid("d7d67226-d4ea-4ffe-a9f1-f02a8e375a23"), "Pepperoni", 1.3999999999999999 }
                });
        }
    }
}
