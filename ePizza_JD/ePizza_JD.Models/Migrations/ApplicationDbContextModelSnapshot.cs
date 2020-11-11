﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ePizza_JD.WebApp.Data;

namespace ePizza_JD.Models.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ePizza_JD.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = new Guid("90a28cce-eb65-4e55-a485-3e26bb6869eb"),
                            City = "Ieper",
                            HouseNumber = 373,
                            Name = "Ronald Steenbruggen",
                            PhoneNumber = "0486 70 71 99",
                            StreetName = "Stationsstraat",
                            ZipCode = 8900
                        },
                        new
                        {
                            CustomerId = new Guid("691919d7-888f-4ddb-b5cd-83954b2094a9"),
                            City = "Brakel",
                            HouseNumber = 165,
                            Name = "Jort Langedijk",
                            PhoneNumber = "0472 56 03 05",
                            StreetName = "Industrieweg",
                            ZipCode = 9660
                        });
                });

            modelBuilder.Entity("ePizza_JD.Models.CustomerOrders", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("CustomerOrders");

                    b.HasData(
                        new
                        {
                            CustomerId = new Guid("90a28cce-eb65-4e55-a485-3e26bb6869eb"),
                            OrderId = new Guid("bba2eded-d219-4618-b0ce-c3a983772772")
                        },
                        new
                        {
                            CustomerId = new Guid("691919d7-888f-4ddb-b5cd-83954b2094a9"),
                            OrderId = new Guid("e68a3f79-ba5a-49f3-95c7-5e38298e7fde")
                        });
                });

            modelBuilder.Entity("ePizza_JD.Models.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderType")
                        .HasColumnType("int");

                    b.Property<Guid>("PizzaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PizzaType")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = new Guid("e68a3f79-ba5a-49f3-95c7-5e38298e7fde"),
                            Date = new DateTime(2020, 11, 11, 17, 30, 39, 265, DateTimeKind.Local).AddTicks(884),
                            OrderType = 1,
                            PizzaId = new Guid("b3117bca-96da-463b-a433-62587fd8bd88"),
                            PizzaType = 0,
                            Quantity = 1,
                            Size = 0,
                            Time = 30
                        },
                        new
                        {
                            OrderId = new Guid("bba2eded-d219-4618-b0ce-c3a983772772"),
                            Date = new DateTime(2020, 11, 11, 17, 30, 39, 269, DateTimeKind.Local).AddTicks(647),
                            OrderType = 0,
                            PizzaId = new Guid("6bd07325-bda2-451f-bbcb-3bf1025834c4"),
                            PizzaType = 1,
                            Quantity = 1,
                            Size = 1,
                            Time = 30
                        });
                });

            modelBuilder.Entity("ePizza_JD.Models.OrderReviews", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReviewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PizzaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId", "ReviewId");

                    b.HasIndex("PizzaId");

                    b.HasIndex("ReviewId");

                    b.ToTable("OrderReviews");

                    b.HasData(
                        new
                        {
                            OrderId = new Guid("e68a3f79-ba5a-49f3-95c7-5e38298e7fde"),
                            ReviewId = new Guid("c456b9e8-d32c-4d6e-8b32-da50c5edc856")
                        },
                        new
                        {
                            OrderId = new Guid("bba2eded-d219-4618-b0ce-c3a983772772"),
                            ReviewId = new Guid("0eae9dca-640f-408e-8aa5-325f40cb3eee")
                        });
                });

            modelBuilder.Entity("ePizza_JD.Models.Pizza", b =>
                {
                    b.Property<Guid>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            PizzaId = new Guid("b3117bca-96da-463b-a433-62587fd8bd88"),
                            ImgUrl = "https://cdn-catalog.pizzahut.be/images/be/20170830150056964.jpg",
                            Name = "Margherita",
                            Price = 7.7000000000000002
                        },
                        new
                        {
                            PizzaId = new Guid("6bd07325-bda2-451f-bbcb-3bf1025834c4"),
                            ImgUrl = "https://cdn-catalog.pizzahut.be/images/be/20170830150118476.jpg",
                            Name = "Pepperoni Lovers",
                            Price = 8.6999999999999993
                        },
                        new
                        {
                            PizzaId = new Guid("b3f8a9e5-d37d-4d0d-834c-3f4c0eed0f7a"),
                            ImgUrl = "https://cdn-catalog.pizzahut.be/images/be/20170830145952504.jpg",
                            Name = "Hawaiian",
                            Price = 9.5
                        },
                        new
                        {
                            PizzaId = new Guid("f7d637d6-22c4-4c57-9b6b-c4bffb33e3ab"),
                            ImgUrl = "https://cdn-catalog.pizzahut.be/images/be/20170830145601044.jpg",
                            Name = "Barbecue Chicken",
                            Price = 10.199999999999999
                        },
                        new
                        {
                            PizzaId = new Guid("11b32453-28ab-4600-a4fb-4dc8eb4a5d22"),
                            ImgUrl = "https://cdn-catalog.pizzahut.be/images/be/20170830150015440.jpg",
                            Name = "Hot 'n Spicy",
                            Price = 10.199999999999999
                        },
                        new
                        {
                            PizzaId = new Guid("dc4d4dec-a818-4d7f-b573-597f3b2ae10b"),
                            ImgUrl = "https://cdn-catalog.pizzahut.be/images/be/20170830145444334.jpg",
                            Name = "4 Cheeses",
                            Price = 10.9
                        },
                        new
                        {
                            PizzaId = new Guid("a6bcedff-523d-4e47-a9f2-93f6533f1dc5"),
                            ImgUrl = "https://cdn-catalog.pizzahut.be/images/be/20171229145324596.jpg",
                            Name = "Tuna",
                            Price = 9.4000000000000004
                        },
                        new
                        {
                            PizzaId = new Guid("7062017e-de4f-47b1-a033-35dabadb3d2c"),
                            ImgUrl = "https://cdn-catalog.pizzahut.be/images/be/20170830145855396.jpg",
                            Name = "Forestiere",
                            Price = 10.300000000000001
                        },
                        new
                        {
                            PizzaId = new Guid("e98e51c6-74a1-4dbb-8064-9018dc8da5f7"),
                            ImgUrl = "https://cdn-catalog.pizzahut.be/images/be/20170830145618975.jpg",
                            Name = "Parma",
                            Price = 8.0999999999999996
                        },
                        new
                        {
                            PizzaId = new Guid("e8c0f7eb-967c-4a5b-9269-577f4d229daa"),
                            ImgUrl = "https://cdn-catalog.pizzahut.be/images/be/20170830145527344.jpg",
                            Name = "Barbecue",
                            Price = 10.4
                        });
                });

            modelBuilder.Entity("ePizza_JD.Models.PizzaToppings", b =>
                {
                    b.Property<Guid>("PizzaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ToppingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ToppingName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PizzaId", "ToppingId");

                    b.HasIndex("ToppingId");

                    b.ToTable("PizzaToppings");

                    b.HasData(
                        new
                        {
                            PizzaId = new Guid("b3117bca-96da-463b-a433-62587fd8bd88"),
                            ToppingId = new Guid("16a1fa18-101d-4f91-ba66-561e6bd8331b"),
                            ToppingName = "Tomato Sauce"
                        },
                        new
                        {
                            PizzaId = new Guid("b3117bca-96da-463b-a433-62587fd8bd88"),
                            ToppingId = new Guid("3e153375-e8aa-4c4b-8836-c69213111eb0"),
                            ToppingName = "Emmental"
                        });
                });

            modelBuilder.Entity("ePizza_JD.Models.Restaurant", b =>
                {
                    b.Property<Guid>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            RestaurantId = new Guid("455c8610-4d64-4c3f-9b85-4087a9c76bb5"),
                            City = "Brugge",
                            HouseNumber = 160,
                            PhoneNumber = "0471 32 89746",
                            RestaurantName = "The little italian",
                            StreetName = "Lange Elzenstraat",
                            ZipCode = 8200
                        },
                        new
                        {
                            RestaurantId = new Guid("cbe4c636-5368-4829-b593-329988d11fd8"),
                            City = "Ieper",
                            HouseNumber = 351,
                            PhoneNumber = "0491 82 74431",
                            RestaurantName = "Pastasciutta",
                            StreetName = "Stationsstraat",
                            ZipCode = 8900
                        },
                        new
                        {
                            RestaurantId = new Guid("8e129188-72bc-44d5-8f96-9f3182c8be3c"),
                            City = "Antwerpen",
                            HouseNumber = 399,
                            PhoneNumber = "0494 26 36224",
                            RestaurantName = "Mamma in cucina",
                            StreetName = "Herentalsebaan",
                            ZipCode = 2000
                        });
                });

            modelBuilder.Entity("ePizza_JD.Models.RestaurantOrder", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderId", "RestaurantId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantOrders");
                });

            modelBuilder.Entity("ePizza_JD.Models.Review", b =>
                {
                    b.Property<Guid>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            ReviewId = new Guid("c456b9e8-d32c-4d6e-8b32-da50c5edc856"),
                            Date = new DateTime(2020, 11, 11, 17, 30, 39, 269, DateTimeKind.Local).AddTicks(2340),
                            Rating = 4.0,
                            Title = "Amazing pizza!"
                        },
                        new
                        {
                            ReviewId = new Guid("0eae9dca-640f-408e-8aa5-325f40cb3eee"),
                            Date = new DateTime(2020, 11, 11, 17, 30, 39, 269, DateTimeKind.Local).AddTicks(3780),
                            Description = "Fast delivery and amazingly great taste!",
                            Rating = 4.5,
                            Title = "Pizzashop online"
                        });
                });

            modelBuilder.Entity("ePizza_JD.Models.Topping", b =>
                {
                    b.Property<Guid>("ToppingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ToppingId");

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            ToppingId = new Guid("0bd08daa-d782-483b-baf4-5d0edf06beef"),
                            Name = "Ham",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("74ecca50-b0dc-4df2-b356-1fecd2b37d5f"),
                            Name = "Mozzarella",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("bc71f9f2-ff80-4701-93db-e4d7b1685624"),
                            Name = "Pepperoni",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("945cff6c-e01e-4690-945e-668f7df707ce"),
                            Name = "Champignons",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("4bb06cbe-0c40-4087-854e-a11940143810"),
                            Name = "Pineapple",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("16a56577-8c00-4929-9947-7bfb7d369704"),
                            Name = "Chilipepper",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("d4940157-b8ac-4549-bef7-44c0dc9dcdcc"),
                            Name = "Red onion",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("7e581024-a794-42b3-826e-de7fd05437d3"),
                            Name = "Grilled Chicken",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("924594f2-dd2c-4932-b569-fe35ef217c33"),
                            Name = "Barbecue sauce",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("16a1fa18-101d-4f91-ba66-561e6bd8331b"),
                            Name = "Tomato Sauce",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("cf65bf49-92bc-485b-980f-a7ee1bf09341"),
                            Name = "Pork",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("3e153375-e8aa-4c4b-8836-c69213111eb0"),
                            Name = "Emmental",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("bbbf0223-5104-46f3-80f2-05398458d3ac"),
                            Name = "Goat cheese",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("ca5f9560-779f-41fb-9feb-d08cadfb1cf4"),
                            Name = "Gorgonzola",
                            Price = 1.3999999999999999
                        },
                        new
                        {
                            ToppingId = new Guid("31dddec6-b32f-4efe-8281-072bbe86b8f5"),
                            Name = "Paprika",
                            Price = 1.3999999999999999
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ePizza_JD.Models.CustomerOrders", b =>
                {
                    b.HasOne("ePizza_JD.Models.Customer", "Customer")
                        .WithMany("CustomerOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ePizza_JD.Models.Order", "Order")
                        .WithMany("CustomerOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ePizza_JD.Models.Order", b =>
                {
                    b.HasOne("ePizza_JD.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ePizza_JD.Models.OrderReviews", b =>
                {
                    b.HasOne("ePizza_JD.Models.Order", "Order")
                        .WithMany("OrderReviews")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ePizza_JD.Models.Pizza", null)
                        .WithMany("OrderReviews")
                        .HasForeignKey("PizzaId");

                    b.HasOne("ePizza_JD.Models.Review", "Review")
                        .WithMany("OrderReviews")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ePizza_JD.Models.PizzaToppings", b =>
                {
                    b.HasOne("ePizza_JD.Models.Pizza", "Pizza")
                        .WithMany("PizzaToppings")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ePizza_JD.Models.Topping", "Topping")
                        .WithMany("PizzaToppings")
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ePizza_JD.Models.RestaurantOrder", b =>
                {
                    b.HasOne("ePizza_JD.Models.Order", "Order")
                        .WithMany("RestaurantOrder")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ePizza_JD.Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantOrder")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
