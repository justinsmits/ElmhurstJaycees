
USE [elmhurstjaycees]
GO
/****** Object:  User [elmhurstjaycees]    Script Date: 5/23/2014 11:05:03 AM ******/
CREATE USER [elmhurstjaycees] FOR LOGIN [elmhurstjaycees] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [gd_execprocs]    Script Date: 5/23/2014 11:05:04 AM ******/
CREATE ROLE [gd_execprocs]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [elmhurstjaycees]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [elmhurstjaycees]
GO
ALTER ROLE [db_datareader] ADD MEMBER [elmhurstjaycees]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [elmhurstjaycees]
GO
/****** Object:  FullTextCatalog [elmhurstjaycees]    Script Date: 5/23/2014 11:05:04 AM ******/
CREATE FULLTEXT CATALOG [elmhurstjaycees]WITH ACCENT_SENSITIVITY = ON
AS DEFAULT

GO
/****** Object:  Table [dbo].[About]    Script Date: 5/23/2014 11:05:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[Id] [int] IDENTITY(1000000,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Board]    Script Date: 5/23/2014 11:05:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board](
	[MemberID] [int] NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[FileID] [int] NOT NULL,
 CONSTRAINT [PK_Board] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC,
	[FileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Charity]    Script Date: 5/23/2014 11:05:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Charity](
	[Id] [int] IDENTITY(1000000,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_Charity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 5/23/2014 11:05:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1000000,1) NOT NULL,
	[FileID] [int] NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Event]    Script Date: 5/23/2014 11:05:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[EventID] [int] IDENTITY(1000000,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Date] [datetime] NULL,
	[DisplayStartDate] [datetime] NULL,
	[DisplayEndDate] [datetime] NULL,
	[Description] [nvarchar](max) NULL,
	[FileID] [int] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[File]    Script Date: 5/23/2014 11:05:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[File](
	[FileID] [int] IDENTITY(1000000,1) NOT NULL,
	[FileName] [nvarchar](200) NOT NULL,
	[FileData] [varbinary](max) NOT NULL,
	[Length] [bigint] NOT NULL,
	[Extension] [nchar](5) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Public] [bit] NOT NULL,
	[Form] [bit] NOT NULL,
	[Photo] [bit] NOT NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[FileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Home]    Script Date: 5/23/2014 11:05:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Home](
	[Id] [int] IDENTITY(1000000,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Content] [nvarchar](max) NULL,
	[FileId] [int] NULL,
 CONSTRAINT [PK_Home] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Member]    Script Date: 5/23/2014 11:05:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Member](
	[MemberID] [int] IDENTITY(1000000,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Hash] [varchar](50) NULL,
	[Salt] [varchar](16) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Minutes]    Script Date: 5/23/2014 11:05:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Minutes](
	[Id] [int] IDENTITY(1000000,1) NOT NULL,
	[MeetingDate] [date] NOT NULL,
	[MeetingMinutes] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Minutes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Press]    Script Date: 5/23/2014 11:05:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Press](
	[Id] [int] IDENTITY(1000000,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Content] [nvarchar](max) NULL,
	[FileID] [int] NULL,
 CONSTRAINT [PK_Press] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[File] ADD  CONSTRAINT [DF_File_Public]  DEFAULT ((1)) FOR [Public]
GO
ALTER TABLE [dbo].[File] ADD  CONSTRAINT [DF_File_Form]  DEFAULT ((0)) FOR [Form]
GO
ALTER TABLE [dbo].[Board]  WITH CHECK ADD  CONSTRAINT [FK_Board_File] FOREIGN KEY([FileID])
REFERENCES [dbo].[File] ([FileID])
GO
ALTER TABLE [dbo].[Board] CHECK CONSTRAINT [FK_Board_File]
GO
ALTER TABLE [dbo].[Board]  WITH CHECK ADD  CONSTRAINT [FK_Board_Member] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Member] ([MemberID])
GO
ALTER TABLE [dbo].[Board] CHECK CONSTRAINT [FK_Board_Member]
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_File] FOREIGN KEY([FileID])
REFERENCES [dbo].[File] ([FileID])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_File]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_File] FOREIGN KEY([FileID])
REFERENCES [dbo].[File] ([FileID])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_File]
GO
ALTER TABLE [dbo].[Home]  WITH CHECK ADD  CONSTRAINT [FK_Home_File] FOREIGN KEY([FileId])
REFERENCES [dbo].[File] ([FileID])
GO
ALTER TABLE [dbo].[Home] CHECK CONSTRAINT [FK_Home_File]
GO
ALTER TABLE [dbo].[Press]  WITH CHECK ADD  CONSTRAINT [FK_Press_File] FOREIGN KEY([FileID])
REFERENCES [dbo].[File] ([FileID])
GO
ALTER TABLE [dbo].[Press] CHECK CONSTRAINT [FK_Press_File]
GO
USE [master]
GO
ALTER DATABASE [elmhurstjaycees] SET  READ_WRITE 
GO
