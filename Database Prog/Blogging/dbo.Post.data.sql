SET IDENTITY_INSERT [dbo].[Post] ON
INSERT INTO [dbo].[Post] ([PostId], [Title], [Content], [BlogId]) VALUES (3, N'Test', N'Test', 1)
SET IDENTITY_INSERT [dbo].[Post] OFF
