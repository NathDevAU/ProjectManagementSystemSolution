USE [ProjectManagementSystem]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 4/16/2017 6:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](15) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 4/16/2017 6:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](50) NULL,
	[ProjectDesc] [nvarchar](300) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectPerson]    Script Date: 4/16/2017 6:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectPerson](
	[ProjectPersonID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectPerson] PRIMARY KEY CLUSTERED 
(
	[ProjectPersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [MobileNo]) VALUES (1, N'Dharmesh', N'Patel', NULL)
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [MobileNo]) VALUES (2, N'John', N'Black', NULL)
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [MobileNo]) VALUES (3, N'Gary', N'Hart', NULL)
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [MobileNo]) VALUES (4, N'Steven', N'Maleca', NULL)
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [MobileNo]) VALUES (5, N'Martin', N'Luther', NULL)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([ProjectID], [ProjectName], [ProjectDesc]) VALUES (1, N'Project 1', N'Project 1')
INSERT [dbo].[Project] ([ProjectID], [ProjectName], [ProjectDesc]) VALUES (2, N'Project 2', N'Project 2')
INSERT [dbo].[Project] ([ProjectID], [ProjectName], [ProjectDesc]) VALUES (3, N'Project 3', N'Project 3')
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[ProjectPerson] ON 

INSERT [dbo].[ProjectPerson] ([ProjectPersonID], [ProjectID], [PersonID]) VALUES (1, 1, 1)
INSERT [dbo].[ProjectPerson] ([ProjectPersonID], [ProjectID], [PersonID]) VALUES (2, 1, 3)
INSERT [dbo].[ProjectPerson] ([ProjectPersonID], [ProjectID], [PersonID]) VALUES (3, 2, 4)
INSERT [dbo].[ProjectPerson] ([ProjectPersonID], [ProjectID], [PersonID]) VALUES (4, 2, 5)
INSERT [dbo].[ProjectPerson] ([ProjectPersonID], [ProjectID], [PersonID]) VALUES (5, 3, 2)
SET IDENTITY_INSERT [dbo].[ProjectPerson] OFF
ALTER TABLE [dbo].[ProjectPerson]  WITH CHECK ADD  CONSTRAINT [FK_ProjectPerson_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ProjectPerson] CHECK CONSTRAINT [FK_ProjectPerson_Person]
GO
ALTER TABLE [dbo].[ProjectPerson]  WITH CHECK ADD  CONSTRAINT [FK_ProjectPerson_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectPerson] CHECK CONSTRAINT [FK_ProjectPerson_Project]
GO
USE [master]
GO
ALTER DATABASE [ProjectManagementSystem] SET  READ_WRITE 
GO
