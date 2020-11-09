IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [Customers] (
        [CustomerId] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        [StreetName] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [HouseNumber] int NOT NULL,
        [ZipCode] int NOT NULL,
        [PhoneNumber] nvarchar(max) NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [Pizzas] (
        [PizzaId] uniqueidentifier NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [Price] float NOT NULL,
        [ImgUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Pizzas] PRIMARY KEY ([PizzaId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [Restaurants] (
        [RestaurantId] uniqueidentifier NOT NULL,
        [RestaurantName] nvarchar(max) NULL,
        [StreetName] nvarchar(max) NULL,
        [HouseNumber] int NOT NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [ZipCode] int NOT NULL,
        [City] nvarchar(max) NULL,
        CONSTRAINT [PK_Restaurants] PRIMARY KEY ([RestaurantId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [Reviews] (
        [ReviewId] uniqueidentifier NOT NULL,
        [Title] nvarchar(200) NULL,
        [Description] nvarchar(500) NULL,
        [Rating] float NOT NULL,
        [Date] datetime2 NOT NULL,
        CONSTRAINT [PK_Reviews] PRIMARY KEY ([ReviewId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [Toppings] (
        [ToppingId] uniqueidentifier NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [Price] float NOT NULL,
        CONSTRAINT [PK_Toppings] PRIMARY KEY ([ToppingId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [Orders] (
        [OrderId] uniqueidentifier NOT NULL,
        [Date] datetime2 NOT NULL,
        [Time] int NOT NULL,
        [Quantity] int NOT NULL,
        [Size] int NOT NULL,
        [PizzaType] int NOT NULL,
        [OrderType] int NOT NULL,
        [PizzaId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
        CONSTRAINT [FK_Orders_Pizzas_PizzaId] FOREIGN KEY ([PizzaId]) REFERENCES [Pizzas] ([PizzaId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [PizzaToppings] (
        [PizzaId] uniqueidentifier NOT NULL,
        [ToppingId] uniqueidentifier NOT NULL,
        [ToppingName] nvarchar(max) NULL,
        [TimeToPrepare] int NOT NULL,
        CONSTRAINT [PK_PizzaToppings] PRIMARY KEY ([PizzaId], [ToppingId]),
        CONSTRAINT [FK_PizzaToppings_Pizzas_PizzaId] FOREIGN KEY ([PizzaId]) REFERENCES [Pizzas] ([PizzaId]) ON DELETE CASCADE,
        CONSTRAINT [FK_PizzaToppings_Toppings_ToppingId] FOREIGN KEY ([ToppingId]) REFERENCES [Toppings] ([ToppingId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [CustomerOrders] (
        [CustomerId] uniqueidentifier NOT NULL,
        [OrderId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_CustomerOrders] PRIMARY KEY ([CustomerId], [OrderId]),
        CONSTRAINT [FK_CustomerOrders_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId]) ON DELETE CASCADE,
        CONSTRAINT [FK_CustomerOrders_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [OrderReviews] (
        [OrderId] uniqueidentifier NOT NULL,
        [ReviewId] uniqueidentifier NOT NULL,
        [Subject] nvarchar(max) NULL,
        [PizzaId] uniqueidentifier NULL,
        CONSTRAINT [PK_OrderReviews] PRIMARY KEY ([OrderId], [ReviewId]),
        CONSTRAINT [FK_OrderReviews_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderReviews_Pizzas_PizzaId] FOREIGN KEY ([PizzaId]) REFERENCES [Pizzas] ([PizzaId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_OrderReviews_Reviews_ReviewId] FOREIGN KEY ([ReviewId]) REFERENCES [Reviews] ([ReviewId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE TABLE [RestaurantOrders] (
        [OrderId] uniqueidentifier NOT NULL,
        [RestaurantId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_RestaurantOrders] PRIMARY KEY ([OrderId], [RestaurantId]),
        CONSTRAINT [FK_RestaurantOrders_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE,
        CONSTRAINT [FK_RestaurantOrders_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([RestaurantId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CustomerId', N'City', N'HouseNumber', N'Name', N'PhoneNumber', N'StreetName', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] ON;
    INSERT INTO [Customers] ([CustomerId], [City], [HouseNumber], [Name], [PhoneNumber], [StreetName], [ZipCode])
    VALUES ('90a28cce-eb65-4e55-a485-3e26bb6869eb', N'Ieper', 373, N'Ronald Steenbruggen', N'0486 70 71 99', N'Stationsstraat', 8900),
    ('691919d7-888f-4ddb-b5cd-83954b2094a9', N'Brakel', 165, N'Jort Langedijk', N'0472 56 03 05', N'Industrieweg', 9660);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CustomerId', N'City', N'HouseNumber', N'Name', N'PhoneNumber', N'StreetName', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PizzaId', N'ImgUrl', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Pizzas]'))
        SET IDENTITY_INSERT [Pizzas] ON;
    INSERT INTO [Pizzas] ([PizzaId], [ImgUrl], [Name], [Price])
    VALUES ('b3117bca-96da-463b-a433-62587fd8bd88', N'https://cdn-catalog.pizzahut.be/images/be/20170830150056964.jpg', N'Margherita', 7.7000000000000002E0),
    ('6bd07325-bda2-451f-bbcb-3bf1025834c4', N'https://cdn-catalog.pizzahut.be/images/be/20170830150118476.jpg', N'Pepperoni Lovers', 8.6999999999999993E0),
    ('0d712c40-b04a-4342-a917-0987a7238df6', N'https://cdn-catalog.pizzahut.be/images/be/20170830145952504.jpg', N'Hawaiian', 9.5E0),
    ('bfddd0b6-bd7f-48f2-8061-c1f36fc97b6e', N'https://cdn-catalog.pizzahut.be/images/be/20170830145601044.jpg', N'Barbecue Chicken', 10.199999999999999E0),
    ('de697af5-de2f-4225-bf11-0b7470e78f94', N'https://cdn-catalog.pizzahut.be/images/be/20170830150015440.jpg', N'Hot ''n Spicy', 10.199999999999999E0),
    ('aa0c01f8-8f8a-499e-a416-e7db817e031b', N'https://cdn-catalog.pizzahut.be/images/be/20170830145444334.jpg', N'4 Cheeses', 10.9E0),
    ('24d65f7c-8424-424a-85ff-c0a77716d73d', N'https://cdn-catalog.pizzahut.be/images/be/20171229145324596.jpg', N'Tuna', 9.4000000000000004E0),
    ('5da832eb-fa3a-464b-8742-6154c63f27c8', N'https://cdn-catalog.pizzahut.be/images/be/20170830145855396.jpg', N'Forestiere', 10.300000000000001E0),
    ('eda48766-fea5-4b5e-8430-d69b8091264e', N'https://cdn-catalog.pizzahut.be/images/be/20170830145618975.jpg', N'Parma', 8.0999999999999996E0),
    ('182ac64a-f6bf-4ed7-88ea-f05c4f2b4f63', N'https://cdn-catalog.pizzahut.be/images/be/20170830145527344.jpg', N'Barbecue', 10.4E0);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PizzaId', N'ImgUrl', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Pizzas]'))
        SET IDENTITY_INSERT [Pizzas] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RestaurantId', N'City', N'HouseNumber', N'PhoneNumber', N'RestaurantName', N'StreetName', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Restaurants]'))
        SET IDENTITY_INSERT [Restaurants] ON;
    INSERT INTO [Restaurants] ([RestaurantId], [City], [HouseNumber], [PhoneNumber], [RestaurantName], [StreetName], [ZipCode])
    VALUES ('e7e2be71-8253-46c8-8006-a4584df72968', N'Brugge', 160, N'0471 32 89746', N'The little italian', N'Lange Elzenstraat', 8200),
    ('56942d34-dec4-47e8-8d57-09950ca7e39d', N'Ieper', 351, N'0491 82 74431', N'Pastasciutta', N'Stationsstraat', 8900),
    ('a3ed2a10-5ffb-4f0f-8931-8fca67d122b6', N'Antwerpen', 399, N'0494 26 36224', N'Mamma in cucina', N'Herentalsebaan', 2000);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RestaurantId', N'City', N'HouseNumber', N'PhoneNumber', N'RestaurantName', N'StreetName', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Restaurants]'))
        SET IDENTITY_INSERT [Restaurants] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ReviewId', N'Date', N'Description', N'Rating', N'Title') AND [object_id] = OBJECT_ID(N'[Reviews]'))
        SET IDENTITY_INSERT [Reviews] ON;
    INSERT INTO [Reviews] ([ReviewId], [Date], [Description], [Rating], [Title])
    VALUES ('0eae9dca-640f-408e-8aa5-325f40cb3eee', '2020-11-08T22:12:06.9840139+01:00', N'Fast delivery and amazingly great taste!', 4.5E0, N'Pizzashop online'),
    ('c456b9e8-d32c-4d6e-8b32-da50c5edc856', '2020-11-08T22:12:06.9838655+01:00', NULL, 4.0E0, N'Amazing pizza!');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ReviewId', N'Date', N'Description', N'Rating', N'Title') AND [object_id] = OBJECT_ID(N'[Reviews]'))
        SET IDENTITY_INSERT [Reviews] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ToppingId', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Toppings]'))
        SET IDENTITY_INSERT [Toppings] ON;
    INSERT INTO [Toppings] ([ToppingId], [Name], [Price])
    VALUES ('26a5832b-0703-4cfd-84ab-2b0dcd06c8b7', N'Ham', 1.3999999999999999E0),
    ('e0e52f4d-dc26-44ed-bef9-c06dcf1deffb', N'Mozzarella', 1.3999999999999999E0),
    ('d7d67226-d4ea-4ffe-a9f1-f02a8e375a23', N'Pepperoni', 1.3999999999999999E0),
    ('8da43f2a-8927-4fab-8ea9-11890145ffb0', N'Champignons', 1.3999999999999999E0),
    ('d255b839-bbdc-4b86-9a0d-6b23cd03dcaa', N'Pineapple', 1.3999999999999999E0),
    ('092cbb78-03bc-4b02-af23-4c0e94b88bdb', N'Chilipepper', 1.3999999999999999E0),
    ('25f4f72a-14dc-42dc-83b3-92c9ee1fb90f', N'Red onion', 1.3999999999999999E0),
    ('e97bfd04-f464-4fa0-9712-85e47f536f64', N'Grilled Chicken', 1.3999999999999999E0),
    ('95a39c80-598e-4a72-85c7-082476b8ba0f', N'Barbecue sauce', 1.3999999999999999E0),
    ('16a1fa18-101d-4f91-ba66-561e6bd8331b', N'Tomato Sauce', 1.3999999999999999E0),
    ('e8396e06-7cb4-4588-b2f6-a91f81624d9b', N'Pork', 1.3999999999999999E0),
    ('3e153375-e8aa-4c4b-8836-c69213111eb0', N'Emmental', 1.3999999999999999E0),
    ('5958ed99-60a4-40b3-858b-c99be491e0a4', N'Goat cheese', 1.3999999999999999E0),
    ('e7bff715-211c-43d9-9873-b395d961cbbf', N'Gorgonzola', 1.3999999999999999E0),
    ('f3b72b4a-a12d-4547-84bd-7cd5a150e918', N'Paprika', 1.3999999999999999E0);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ToppingId', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Toppings]'))
        SET IDENTITY_INSERT [Toppings] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderId', N'Date', N'OrderType', N'PizzaId', N'PizzaType', N'Quantity', N'Size', N'Time') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] ON;
    INSERT INTO [Orders] ([OrderId], [Date], [OrderType], [PizzaId], [PizzaType], [Quantity], [Size], [Time])
    VALUES ('e68a3f79-ba5a-49f3-95c7-5e38298e7fde', '2020-11-08T22:12:06.9802458+01:00', 1, 'b3117bca-96da-463b-a433-62587fd8bd88', 0, 1, 0, 30),
    ('bba2eded-d219-4618-b0ce-c3a983772772', '2020-11-08T22:12:06.9837033+01:00', 0, '6bd07325-bda2-451f-bbcb-3bf1025834c4', 1, 1, 1, 30);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderId', N'Date', N'OrderType', N'PizzaId', N'PizzaType', N'Quantity', N'Size', N'Time') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PizzaId', N'ToppingId', N'TimeToPrepare', N'ToppingName') AND [object_id] = OBJECT_ID(N'[PizzaToppings]'))
        SET IDENTITY_INSERT [PizzaToppings] ON;
    INSERT INTO [PizzaToppings] ([PizzaId], [ToppingId], [TimeToPrepare], [ToppingName])
    VALUES ('b3117bca-96da-463b-a433-62587fd8bd88', '16a1fa18-101d-4f91-ba66-561e6bd8331b', 0, N'Tomato Sauce'),
    ('b3117bca-96da-463b-a433-62587fd8bd88', '3e153375-e8aa-4c4b-8836-c69213111eb0', 0, N'Emmental');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PizzaId', N'ToppingId', N'TimeToPrepare', N'ToppingName') AND [object_id] = OBJECT_ID(N'[PizzaToppings]'))
        SET IDENTITY_INSERT [PizzaToppings] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CustomerId', N'OrderId') AND [object_id] = OBJECT_ID(N'[CustomerOrders]'))
        SET IDENTITY_INSERT [CustomerOrders] ON;
    INSERT INTO [CustomerOrders] ([CustomerId], [OrderId])
    VALUES ('691919d7-888f-4ddb-b5cd-83954b2094a9', 'e68a3f79-ba5a-49f3-95c7-5e38298e7fde'),
    ('90a28cce-eb65-4e55-a485-3e26bb6869eb', 'bba2eded-d219-4618-b0ce-c3a983772772');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CustomerId', N'OrderId') AND [object_id] = OBJECT_ID(N'[CustomerOrders]'))
        SET IDENTITY_INSERT [CustomerOrders] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderId', N'ReviewId', N'PizzaId', N'Subject') AND [object_id] = OBJECT_ID(N'[OrderReviews]'))
        SET IDENTITY_INSERT [OrderReviews] ON;
    INSERT INTO [OrderReviews] ([OrderId], [ReviewId], [PizzaId], [Subject])
    VALUES ('e68a3f79-ba5a-49f3-95c7-5e38298e7fde', 'c456b9e8-d32c-4d6e-8b32-da50c5edc856', NULL, NULL),
    ('bba2eded-d219-4618-b0ce-c3a983772772', '0eae9dca-640f-408e-8aa5-325f40cb3eee', NULL, NULL);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderId', N'ReviewId', N'PizzaId', N'Subject') AND [object_id] = OBJECT_ID(N'[OrderReviews]'))
        SET IDENTITY_INSERT [OrderReviews] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE INDEX [IX_CustomerOrders_OrderId] ON [CustomerOrders] ([OrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE INDEX [IX_OrderReviews_PizzaId] ON [OrderReviews] ([PizzaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE INDEX [IX_OrderReviews_ReviewId] ON [OrderReviews] ([ReviewId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE INDEX [IX_Orders_PizzaId] ON [Orders] ([PizzaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE INDEX [IX_PizzaToppings_ToppingId] ON [PizzaToppings] ([ToppingId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    CREATE INDEX [IX_RestaurantOrders_RestaurantId] ON [RestaurantOrders] ([RestaurantId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201108211207_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201108211207_init', N'3.1.9');
END;

GO

