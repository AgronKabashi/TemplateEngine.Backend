USE Cerberus;
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Cerberus.CMS.Article](
	[ArticleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[SEOName] [nvarchar](255) NOT NULL,
	[FolderId] [int] NULL,
	[TemplateId] [int] NOT NULL,
	[Image] [nvarchar](100) NOT NULL,
	[Thumbnail] [nvarchar](100) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Cerberus.CMS.Article] PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Cerberus.CMS.ArticlePublication](
	[PublicationId] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NOT NULL,
	[PublishStartDate] [datetime] NOT NULL,
	[PublishEndDate] [datetime] NOT NULL,
	[IsPublished] [bit] NOT NULL,
 CONSTRAINT [PK_DocumentPublication] PRIMARY KEY CLUSTERED 
(
	[PublicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Cerberus.CMS.Folder](
	[FolderId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[SEOName] [nvarchar](255) NOT NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_Cerberus.CMS.Folder] PRIMARY KEY CLUSTERED 
(
	[FolderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Cerberus.Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Cerberus.Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Cerberus.TemplateEngine.ControlPlugin](
	[ControlPluginId] [int] IDENTITY NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[ControlType] [nvarchar](255) NOT NULL,
	[ImageUrl] [nvarchar](255) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_Template.ControlPlugin] PRIMARY KEY CLUSTERED 
(
	[ControlPluginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Cerberus.TemplateEngine.DocumentType](
	[DocumentTypeId] [int] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Cerberus.TemplateEngine.DocumentType] PRIMARY KEY CLUSTERED 
(
	[DocumentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Cerberus.TemplateEngine.Resolution](
	[ResolutionId] [int] IDENTITY(1,1) NOT NULL,
	[Width] [int] NOT NULL,
	[TemplateId] [int] NOT NULL,
 CONSTRAINT [PK_Template.Resolution] PRIMARY KEY CLUSTERED 
(
	[ResolutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Cerberus.TemplateEngine.Template](
	[TemplateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[VisualProperties] [nvarchar](1024) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_Template] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Cerberus.TemplateEngine.TemplateControl](
	[TemplateControlId] [int] IDENTITY(1,1) NOT NULL,
	[ControlPluginId] [int] NOT NULL,
	[TemplateId] [int] NOT NULL,
	[FriendlyName] [nvarchar](50) NULL,
	[Content] [nvarchar](max) NOT NULL,
	[VisualProperties] [nvarchar](1024) NOT NULL,
	[CreationGUID] [int] NULL,
	[Class] [nvarchar](50) NULL,
 CONSTRAINT [PK_TemplateControl] PRIMARY KEY CLUSTERED 
(
	[TemplateControlId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Cerberus.TemplateEngine.TemplateControlContent](
	[ControlContentId] [int] IDENTITY(1,1) NOT NULL,
	[TemplateControlId] [int] NOT NULL,
	[DocumentId] [int] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[DocumentTypeId] [int] NOT NULL,
 CONSTRAINT [PK_TemplateControlContent] PRIMARY KEY CLUSTERED 
(
	[ControlContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Cerberus.TemplateEngine.TemplateControlResolution](
	[TemplateControlResolutionId] [int] IDENTITY(1,1) NOT NULL,
	[TemplateControlId] [int] NOT NULL,
	[ResolutionId] [int] NOT NULL,
	[VisualProperties] [nvarchar](1024) NOT NULL,
 CONSTRAINT [PK_Template.TemplateControlResolution] PRIMARY KEY CLUSTERED 
(
	[TemplateControlResolutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Cerberus.User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](64) NOT NULL,
	[Password] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_Cerberus.User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Cerberus.UserRoles](
	[UniqueId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Cerberus.UserRoles] PRIMARY KEY CLUSTERED 
(
	[UniqueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE NONCLUSTERED INDEX [IX_Cerberus.TemplateEngine.TemplateControlContent] ON [dbo].[Cerberus.TemplateEngine.TemplateControlContent]
(
	[DocumentId] ASC,
	[DocumentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE [dbo].[Cerberus.CMS.Article] ADD  CONSTRAINT [DF_Cerberus.CMS.Article_Image]  DEFAULT ('') FOR [Image]

ALTER TABLE [dbo].[Cerberus.CMS.Article] ADD  CONSTRAINT [DF_Cerberus.CMS.Article_Thumbnail]  DEFAULT ('') FOR [Thumbnail]

ALTER TABLE [dbo].[Cerberus.CMS.Article] ADD  CONSTRAINT [DF_Cerberus.CMS.Article_OrderId]  DEFAULT ((0)) FOR [OrderId]

ALTER TABLE [dbo].[Cerberus.CMS.Article] ADD  CONSTRAINT [DF_Cerberus.CMS.Article_Description]  DEFAULT ('') FOR [Description]

ALTER TABLE [dbo].[Cerberus.CMS.ArticlePublication] ADD  CONSTRAINT [DF_Cerberus.CMS.ArticlePublication_PublishStartDate]  DEFAULT ('1901-01-01') FOR [PublishStartDate]

ALTER TABLE [dbo].[Cerberus.CMS.ArticlePublication] ADD  CONSTRAINT [DF_Cerberus.CMS.ArticlePublication_PublishEndDate]  DEFAULT ('2050-01-01') FOR [PublishEndDate]

ALTER TABLE [dbo].[Cerberus.CMS.ArticlePublication] ADD  CONSTRAINT [DF_Cerberus.CMS.ArticlePublication_Published]  DEFAULT ((0)) FOR [IsPublished]

ALTER TABLE [dbo].[Cerberus.CMS.Folder] ADD  CONSTRAINT [DF_Cerberus.CMS.Folder_SEOName]  DEFAULT ('') FOR [SEOName]

ALTER TABLE [dbo].[Cerberus.TemplateEngine.Resolution] ADD  CONSTRAINT [DF_TemplateEngine.Resolution_Width]  DEFAULT ((10000)) FOR [Width]

ALTER TABLE [dbo].[Cerberus.TemplateEngine.Template] ADD  CONSTRAINT [DF_TemplateEngine.Template_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]

ALTER TABLE [dbo].[Cerberus.TemplateEngine.Template] ADD  CONSTRAINT [DF_Cerberus.TemplateEngine.Template_CreatedByUserId]  DEFAULT ((0)) FOR [CreatedByUserId]

ALTER TABLE [dbo].[Cerberus.TemplateEngine.TemplateControl] ADD  CONSTRAINT [DF_TemplateEngine.TemplateControl_CreationGUID]  DEFAULT (NULL) FOR [CreationGUID]

ALTER TABLE [dbo].[Cerberus.CMS.Article]  WITH CHECK ADD  CONSTRAINT [FK_Cerberus.CMS.Article_Cerberus.CMS.Folder] FOREIGN KEY([FolderId])
REFERENCES [dbo].[Cerberus.CMS.Folder] ([FolderId])
ON DELETE SET NULL

ALTER TABLE [dbo].[Cerberus.CMS.Article] CHECK CONSTRAINT [FK_Cerberus.CMS.Article_Cerberus.CMS.Folder]

ALTER TABLE [dbo].[Cerberus.CMS.ArticlePublication]  WITH CHECK ADD  CONSTRAINT [FK_Cerberus.CMS.ArticlePublication_Cerberus.CMS.Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Cerberus.CMS.Article] ([ArticleId])
ON DELETE CASCADE

ALTER TABLE [dbo].[Cerberus.CMS.ArticlePublication] CHECK CONSTRAINT [FK_Cerberus.CMS.ArticlePublication_Cerberus.CMS.Article]

ALTER TABLE [dbo].[Cerberus.CMS.Folder]  WITH CHECK ADD  CONSTRAINT [FK_Cerberus.CMS.Folder_Cerberus.CMS.Folder] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Cerberus.CMS.Folder] ([FolderId])

ALTER TABLE [dbo].[Cerberus.CMS.Folder] CHECK CONSTRAINT [FK_Cerberus.CMS.Folder_Cerberus.CMS.Folder]

ALTER TABLE [dbo].[Cerberus.TemplateEngine.TemplateControl]  WITH CHECK ADD  CONSTRAINT [FK_TemplateEngine.TemplateControl_TemplateEngine.ControlPlugin] FOREIGN KEY([ControlPluginId])
REFERENCES [dbo].[Cerberus.TemplateEngine.ControlPlugin] ([ControlPluginId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Cerberus.TemplateEngine.TemplateControl] CHECK CONSTRAINT [FK_TemplateEngine.TemplateControl_TemplateEngine.ControlPlugin]

ALTER TABLE [dbo].[Cerberus.TemplateEngine.TemplateControl]  WITH CHECK ADD  CONSTRAINT [FK_TemplateEngine.TemplateControl_TemplateEngine.Template] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[Cerberus.TemplateEngine.Template] ([TemplateId])
ON DELETE CASCADE

ALTER TABLE [dbo].[Cerberus.TemplateEngine.TemplateControl] CHECK CONSTRAINT [FK_TemplateEngine.TemplateControl_TemplateEngine.Template]

ALTER TABLE [dbo].[Cerberus.TemplateEngine.TemplateControlContent]  WITH CHECK ADD  CONSTRAINT [FK_Cerberus.TemplateEngine.TemplateControlContent_Cerberus.TemplateEngine.TemplateControl] FOREIGN KEY([TemplateControlId])
REFERENCES [dbo].[Cerberus.TemplateEngine.TemplateControl] ([TemplateControlId])
ON DELETE CASCADE

ALTER TABLE [dbo].[Cerberus.TemplateEngine.TemplateControlContent] CHECK CONSTRAINT [FK_Cerberus.TemplateEngine.TemplateControlContent_Cerberus.TemplateEngine.TemplateControl]

ALTER TABLE [dbo].[Cerberus.TemplateEngine.TemplateControlResolution]  WITH CHECK ADD  CONSTRAINT [FK_TemplateEngine.TemplateControlResolution_TemplateEngine.Resolution] FOREIGN KEY([ResolutionId])
REFERENCES [dbo].[Cerberus.TemplateEngine.Resolution] ([ResolutionId])
ON DELETE CASCADE

ALTER TABLE [dbo].[Cerberus.TemplateEngine.TemplateControlResolution] CHECK CONSTRAINT [FK_TemplateEngine.TemplateControlResolution_TemplateEngine.Resolution]

ALTER TABLE [dbo].[Cerberus.TemplateEngine.TemplateControlResolution]  WITH CHECK ADD  CONSTRAINT [FK_TemplateEngine.TemplateControlResolution_TemplateEngine.TemplateControl] FOREIGN KEY([TemplateControlId])
REFERENCES [dbo].[Cerberus.TemplateEngine.TemplateControl] ([TemplateControlId])
ON DELETE CASCADE

ALTER TABLE [dbo].[Cerberus.TemplateEngine.TemplateControlResolution] CHECK CONSTRAINT [FK_TemplateEngine.TemplateControlResolution_TemplateEngine.TemplateControl]

ALTER TABLE [dbo].[Cerberus.UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_Cerberus.UserRoles_Cerberus.Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Cerberus.Role] ([RoleId])
ON DELETE CASCADE

ALTER TABLE [dbo].[Cerberus.UserRoles] CHECK CONSTRAINT [FK_Cerberus.UserRoles_Cerberus.Role]

ALTER TABLE [dbo].[Cerberus.UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_Cerberus.UserRoles_Cerberus.User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Cerberus.User] ([UserId])
ON DELETE CASCADE

ALTER TABLE [dbo].[Cerberus.UserRoles] CHECK CONSTRAINT [FK_Cerberus.UserRoles_Cerberus.User]

