USE Cerberus;
SET IDENTITY_INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ON

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (1, N'Text', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Basic.Text', N'Text.png', N'Basic', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (2, N'RTF', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Basic.RTF', N'RTF.png', N'Basic', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (3, N'Video', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Basic.Video', N'Video.png', N'Basic', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (4, N'YouTube', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Basic.YouTube', N'YouTube.png', N'Basic', 1)


INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (101, N'Link', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Navigation.Link', N'Link.png', N'Navigation', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (102, N'ArticleList', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Navigation.ArticleList', N'ArticleList.png', N'Navigation', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (103, N'TableOfContents', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.Navigation.TableOfContents', N'TableOfContents.png', N'Navigation', 1)


INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (201, N'RSS', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.SocialMedia.RSS', N'RSS.png', N'SocialMedia', 1)

INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId], [Name], [ControlType], [ImageUrl], [Category], [Enabled]) VALUES (202, N'Sharer', N'Cerberus.Tool.TemplateEngine.Controller.ControlPlugin.SocialMedia.Sharer', N'Sharer.png', N'SocialMedia', 1)


SET IDENTITY_INSERT [dbo].[Cerberus.TemplateEngine.ControlPlugin] OFF

INSERT [dbo].[Cerberus.TemplateEngine.DocumentType] ([DocumentTypeId], [Description]) VALUES (1, N'Web Articles')