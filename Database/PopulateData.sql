USE [MMTShop]
GO

INSERT [dbo].[Products] ([Sku], [Name], [Description], [Price]) VALUES (N'10001', N'Armchair', N'Comfy chair', 99.99)
INSERT [dbo].[Products] ([Sku], [Name], [Description], [Price]) VALUES (N'10002', N'Coffee Table', N'Coffee table with decorative book', 119.95)
INSERT [dbo].[Products] ([Sku], [Name], [Description], [Price]) VALUES (N'20001', N'Garden chair', N'Reclining wicker chair', 149.99)
INSERT [dbo].[Products] ([Sku], [Name], [Description], [Price]) VALUES (N'20002', N'Garden table', N'Weatherproof table for alfresco dining', 420.21)
INSERT [dbo].[Products] ([Sku], [Name], [Description], [Price]) VALUES (N'30001', N'Headphones', N'Noise cancelling over-ear eadphones', 280)
INSERT [dbo].[Products] ([Sku], [Name], [Description], [Price]) VALUES (N'30002', N'Fan', N'Rotating floor-standing fan', 58.01)
INSERT [dbo].[Products] ([Sku], [Name], [Description], [Price]) VALUES (N'40001', N'Yoga mat', N'Luxury deep-pile yoga mat', 19.85)
INSERT [dbo].[Products] ([Sku], [Name], [Description], [Price]) VALUES (N'40002', N'Bike trainer', N'Flywheel with bike mount', 325)
INSERT [dbo].[Products] ([Sku], [Name], [Description], [Price]) VALUES (N'50001', N'Swingball set', N'3m radius swingball pole with two bats', 14.99)
INSERT [dbo].[Products] ([Sku], [Name], [Description], [Price]) VALUES (N'50002', N'Adventure Time Monopoly', N'Monopoly featuring your favourite characters from Adventure Time', 29.99)

INSERT INTO [dbo].[Categories] ([Id],[Name]) VALUES (newid(), 'Home')
INSERT INTO [dbo].[Categories] ([Id],[Name]) VALUES (newid(), 'Garden')
INSERT INTO [dbo].[Categories] ([Id],[Name]) VALUES (newid(), 'Electronics')
INSERT INTO [dbo].[Categories] ([Id],[Name]) VALUES (newid(), 'Fitness')
INSERT INTO [dbo].[Categories] ([Id],[Name]) VALUES (newid(), 'Toys')

INSERT INTO [dbo].[CategoryFilters] ([Id], [Filter], [CategoryId])SELECT newid(), '1', [Id] FROM [dbo].[Categories] WHERE [Name] = 'Home'
INSERT INTO [dbo].[CategoryFilters] ([Id], [Filter], [CategoryId])SELECT newid(), '2', [Id] FROM [dbo].[Categories] WHERE [Name] = 'Garden'
INSERT INTO [dbo].[CategoryFilters] ([Id], [Filter], [CategoryId])SELECT newid(), '3', [Id] FROM [dbo].[Categories] WHERE [Name] = 'Electronics'
INSERT INTO [dbo].[CategoryFilters] ([Id], [Filter], [CategoryId])SELECT newid(), '4', [Id] FROM [dbo].[Categories] WHERE [Name] = 'Fitness'
INSERT INTO [dbo].[CategoryFilters] ([Id], [Filter], [CategoryId])SELECT newid(), '5', [Id] FROM [dbo].[Categories] WHERE [Name] = 'Toys'


