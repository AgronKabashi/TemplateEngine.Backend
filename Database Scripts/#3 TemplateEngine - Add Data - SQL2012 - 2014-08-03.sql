USE Cerberus;
SET IDENTITY_INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ON

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (1, N'Text', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Basic.Text', N'Text.png', N'Basic', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (2, N'RTF', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Basic.RTF', N'RTF.png', N'Basic', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (3, N'YouTube', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Basic.YouTube', N'YouTube.png', N'Basic', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (4, N'Link', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Navigation.Link', N'Link.png', N'Navigation', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (5, N'TableOfContents', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Navigation.TableOfContents', N'TableOfContents.png', N'Navigation', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (6, N'Menu', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Navigation.Menu', N'Menu.png', N'Navigation', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (7, N'RSS', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.SocialMedia.RSS', N'RSS.png', N'SocialMedia', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (8, N'Sharer', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.SocialMedia.Sharer', N'Sharer.png', N'SocialMedia', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (9, N'ArticleList', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Navigation.ArticleList', N'ArticleList.png', N'Navigation', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (10, N'Video', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Basic.Video', N'Video.png', N'Basic', 1)

SET IDENTITY_INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] OFF


SET IDENTITY_INSERT [dbo].[Cerberus.User] ON 

INSERT [dbo].[Cerberus.User] ([UserId], [FirstName], [LastName], [UserName], [Password]) VALUES (1, N'Super', N'User', N'super', LOWER(CONVERT(VARCHAR(32), HashBytes('MD5', N'YOUR_PASSWORD_HERE'), 2)))

SET IDENTITY_INSERT [dbo].[Cerberus.User] OFF

SET IDENTITY_INSERT [dbo].[Cerberus.Role] ON

INSERT [dbo].[Cerberus.Role] ([RoleId], [Name]) VALUES (1, N'AdministrateUsers')

INSERT [dbo].[Cerberus.Role] ([RoleId], [Name]) VALUES (2, N'AdministrateTemplates')

INSERT [dbo].[Cerberus.Role] ([RoleId], [Name]) VALUES (3, N'AdministrateArticles')

INSERT [dbo].[Cerberus.Role] ([RoleId], [Name]) VALUES (4, N'CreateUsers')

INSERT [dbo].[Cerberus.Role] ([RoleId], [Name]) VALUES (5, N'CreateTemplates')

INSERT [dbo].[Cerberus.Role] ([RoleId], [Name]) VALUES (6, N'CreateArticles')

SET IDENTITY_INSERT [dbo].[Cerberus.Role] OFF

INSERT [dbo].[Cerberus.UserRoles] ([UserId], [RoleId]) VALUES (1, 1)

INSERT [dbo].[Cerberus.UserRoles] ([UserId], [RoleId]) VALUES (1, 2)

INSERT [dbo].[Cerberus.UserRoles] ([UserId], [RoleId]) VALUES (1, 3)

INSERT [dbo].[Cerberus.UserRoles] ([UserId], [RoleId]) VALUES (1, 4)

INSERT [dbo].[Cerberus.UserRoles] ([UserId], [RoleId]) VALUES (1, 5)

INSERT [dbo].[Cerberus.UserRoles] ([UserId], [RoleId]) VALUES (1, 6)

SET IDENTITY_INSERT [dbo].[Cerberus.UserRoles] OFF

INSERT [dbo].[Cerberus.TemplateEngine.DocumentType] ([DocumentTypeId], [Description]) VALUES (1, N'Web Articles')

