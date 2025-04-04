USE [master]
GO
/****** Object:  Database [DB_Blog]    Script Date: 07/01/1404 16:08:50 ******/
CREATE DATABASE [DB_Blog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Blog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_Blog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Blog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_Blog_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Blog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Blog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Blog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Blog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Blog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Blog] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Blog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Blog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Blog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Blog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Blog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Blog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Blog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Blog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Blog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Blog] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_Blog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Blog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Blog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Blog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Blog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Blog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Blog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Blog] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_Blog] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Blog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Blog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Blog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Blog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Blog] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_Blog', N'ON'
GO
USE [DB_Blog]
GO
/****** Object:  UserDefinedFunction [dbo].[ASCII]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   FUNCTION [dbo].[ASCII] (@source nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    DECLARE @pattern nvarchar(max)
    SET @pattern = N'rn'
    RETURN REPLACE(@source, @pattern, N' ')
END
GO
/****** Object:  UserDefinedFunction [dbo].[CleanString]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   FUNCTION [dbo].[CleanString] (@str nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    RETURN dbo.Fa2En(dbo.NullIfEmpty(dbo.FixPersianChars(@str)))
END
GO
/****** Object:  UserDefinedFunction [dbo].[En2Fa]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[En2Fa]
(
    @str NVARCHAR(MAX)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    SET @str = REPLACE(@str, '0', N'۰')
    SET @str = REPLACE(@str, '1', N'۱')
    SET @str = REPLACE(@str, '2', N'۲')
    SET @str = REPLACE(@str, '3', N'۳')
    SET @str = REPLACE(@str, '4', N'۴')
    SET @str = REPLACE(@str, '5', N'۵')
    SET @str = REPLACE(@str, '6', N'۶')
    SET @str = REPLACE(@str, '7', N'۷')
    SET @str = REPLACE(@str, '8', N'۸')
    SET @str = REPLACE(@str, '9', N'۹')
    RETURN @str
END
GO
/****** Object:  UserDefinedFunction [dbo].[Fa2En]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Fa2En]
(
    @str NVARCHAR(MAX)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    SET @str = REPLACE(@str, N'۰', '0')
    SET @str = REPLACE(@str, N'۱', '1')
    SET @str = REPLACE(@str, N'۲', '2')
    SET @str = REPLACE(@str, N'۳', '3')
    SET @str = REPLACE(@str, N'۴', '4')
    SET @str = REPLACE(@str, N'۵', '5')
    SET @str = REPLACE(@str, N'۶', '6')
    SET @str = REPLACE(@str, N'۷', '7')
    SET @str = REPLACE(@str, N'۸', '8')
    SET @str = REPLACE(@str, N'۹', '9')
    --iphone numeric
    SET @str = REPLACE(@str, N'٠', '0')
    SET @str = REPLACE(@str, N'١', '1')
    SET @str = REPLACE(@str, N'٢', '2')
    SET @str = REPLACE(@str, N'٣', '3')
    SET @str = REPLACE(@str, N'٤', '4')
    SET @str = REPLACE(@str, N'٥', '5')
    SET @str = REPLACE(@str, N'٦', '6')
    SET @str = REPLACE(@str, N'٧', '7')
    SET @str = REPLACE(@str, N'٨', '8')
    SET @str = REPLACE(@str, N'٩', '9')
    RETURN @str
END
GO
/****** Object:  UserDefinedFunction [dbo].[FixPersianChars]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   FUNCTION [dbo].[FixPersianChars] (@str nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    SET @str = ISNULL(@str, ' ')
    SET @str = CASE WHEN @str = 'string' THEN ' ' ELSE @str END
    SET @str = REPLACE(@str, N'ﮎ', N'ک')
    SET @str = REPLACE(@str, N'ﮏ', N'ک')
    SET @str = REPLACE(@str, N'ﮐ', N'ک')
    SET @str = REPLACE(@str, N'ﮑ', N'ک')
    SET @str = REPLACE(@str, N'ك', N'ک')
    SET @str = REPLACE(@str, N'ي', N'ی')
    SET @str = REPLACE(@str, N' ', N' ')
    SET @str = REPLACE(@str, N'‌', N' ')
    SET @str = REPLACE(@str, N'ھ', N'ه')
    RETURN @str
END
GO
/****** Object:  UserDefinedFunction [dbo].[HasValue]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[HasValue] 
(
    @value NVARCHAR(MAX),
    @ignoreWhiteSpace BIT
)
RETURNS BIT
AS
BEGIN
    RETURN CASE @ignoreWhiteSpace 
        WHEN 1 THEN CASE WHEN RTRIM(LTRIM(@value)) <> '' THEN 1 ELSE 0 END 
        ELSE CASE WHEN @value <> '' THEN 1 ELSE 0 END 
        END
END
GO
/****** Object:  UserDefinedFunction [dbo].[Msg]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   FUNCTION [dbo].[Msg] (@str nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    RETURN REPLACE(@str, N'Core .Net SqlClient Data Provider-', '') + dbo.CleanString(@str)
END
GO
/****** Object:  UserDefinedFunction [dbo].[NullIfEmpty]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   FUNCTION [dbo].[NullIfEmpty] (@str nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    RETURN CASE WHEN LEN(@str) = 0 THEN NULL ELSE @str END
END
GO
/****** Object:  UserDefinedFunction [dbo].[RemovePoint]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   FUNCTION [dbo].[RemovePoint] (@str nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    SET @str = REPLACE(@str, N',', N'')
    SET @str = REPLACE(@str, N'.', N'')
    SET @str = REPLACE(@str, N'/', N'')
    SET @str = REPLACE(@str, N'.', N'')
    RETURN @str
END
GO
/****** Object:  UserDefinedFunction [dbo].[ToDecimal]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ToDecimal]
(
    @value NVARCHAR(MAX)
)
RETURNS DECIMAL(18,2)
AS
BEGIN
    RETURN CONVERT(DECIMAL(18,2), @value)
END
GO
/****** Object:  UserDefinedFunction [dbo].[ToInt]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ToInt]
(
    @value NVARCHAR(MAX)
)
RETURNS INT
AS
BEGIN
    RETURN CONVERT(INT, @value)
END
GO
/****** Object:  UserDefinedFunction [dbo].[ToNumeric]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ToNumeric]
(
    @value INT
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    RETURN FORMAT(@value, N'N0')
END
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[BlogID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NULL,
	[Contents] [nvarchar](4000) NULL,
	[AuthorID] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[BlogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostReactions]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostReactions](
	[PostReactionsID] [int] IDENTITY(1,1) NOT NULL,
	[ThumbsUp] [int] NULL,
	[Hooray] [int] NULL,
	[Heart] [int] NULL,
	[Rocket] [int] NULL,
	[Eyes] [nchar](10) NULL,
	[BlogID] [int] NOT NULL,
 CONSTRAINT [PK_PostReactions] PRIMARY KEY CLUSTERED 
(
	[PostReactionsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Authors] ADD  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Blogs] ADD  CONSTRAINT [DF_Blogs_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[PostReactions] ADD  CONSTRAINT [DF_PostReactions_ThumbsUp]  DEFAULT ((0)) FOR [ThumbsUp]
GO
ALTER TABLE [dbo].[PostReactions] ADD  CONSTRAINT [DF_PostReactions_Hooray]  DEFAULT ((0)) FOR [Hooray]
GO
ALTER TABLE [dbo].[PostReactions] ADD  CONSTRAINT [DF_PostReactions_Heart]  DEFAULT ((0)) FOR [Heart]
GO
ALTER TABLE [dbo].[PostReactions] ADD  CONSTRAINT [DF_PostReactions_Rocket]  DEFAULT ((0)) FOR [Rocket]
GO
ALTER TABLE [dbo].[PostReactions] ADD  CONSTRAINT [DF_PostReactions_Eyes]  DEFAULT ((0)) FOR [Eyes]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_Author] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([AuthorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_Blogs_Author]
GO
ALTER TABLE [dbo].[PostReactions]  WITH CHECK ADD  CONSTRAINT [FK_PostReactions_Blogs] FOREIGN KEY([BlogID])
REFERENCES [dbo].[Blogs] ([BlogID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostReactions] CHECK CONSTRAINT [FK_PostReactions_Blogs]
GO
/****** Object:  StoredProcedure [dbo].[AuthorsDelete]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AuthorsDelete]
  @AuthorID INT
-- پارامتر ورودی: شناسه نویسنده
AS
BEGIN

  SET NOCOUNT ON;

  DECLARE @RowsAffected INT;

  DELETE FROM Authors
  WHERE AuthorID = @AuthorID;

  SET @RowsAffected = @@ROWCOUNT;

  IF @RowsAffected > 0
  BEGIN
    SELECT 1 AS Result;
  END
  ELSE
  BEGIN
    SELECT 0 AS Result;
  END
END;
GO
/****** Object:  StoredProcedure [dbo].[AuthorsGetAll]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[AuthorsGetAll]
as
BEGIN
    SELECT AuthorID, FirstName, LastName, CreatedDate
    FROM Authors
    ORDER BY FirstName, LastName
END
GO
/****** Object:  StoredProcedure [dbo].[AuthorsInsert]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[AuthorsInsert]
  @FirstName NVARCHAR(50),
  @LastName NVARCHAR(50)
AS
BEGIN
  INSERT INTO Authors
    (FirstName, LastName)
  OUTPUT
  INSERTED.*
  VALUES
    (@FirstName, @LastName)
END;

GO
/****** Object:  StoredProcedure [dbo].[AuthorsSearch]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[AuthorsSearch]
    @FirstName NVARCHAR(50) = NULL,
    @LastName NVARCHAR(50) = NULL
AS
BEGIN
    SELECT *
    FROM Authors
    WHERE (@FirstName IS NULL OR FirstName LIKE '%' + @FirstName + '%')
        AND (@LastName IS NULL OR LastName LIKE '%' + @LastName + '%')
END;
GO
/****** Object:  StoredProcedure [dbo].[AuthorsUpdate]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[AuthorsUpdate]
  @AuthorID INT,
  @FirstName NVARCHAR(50),
  @LastName NVARCHAR(50)
AS
BEGIN
  UPDATE Authors
      SET FirstName = @FirstName,
          LastName = @LastName
      OUTPUT INSERTED.*
      WHERE AuthorID = @AuthorID
END;
GO
/****** Object:  StoredProcedure [dbo].[BlogsDelete]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[BlogsDelete]
  @BlogID INT
-- پارامتر ورودی: شناسه پست
AS
BEGIN

  SET NOCOUNT ON;

  DECLARE @RowsAffected INT;

  DELETE FROM Blogs
  WHERE BlogID = @BlogID;

  SET @RowsAffected = @@ROWCOUNT;

  IF @RowsAffected > 0
  BEGIN
    SELECT 1 AS Result;
  END
  ELSE
  BEGIN
    SELECT 0 AS Result;
  END
END;
GO
/****** Object:  StoredProcedure [dbo].[BlogsFindID]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[BlogsFindID]
    @BlogID as int
AS
BEGIN
    SELECT Blogs.BlogID, Blogs.Contents, Blogs.Title, Blogs.AuthorID,
        Blogs.CreatedDate, PostReactions.PostReactionsID, PostReactions.ThumbsUp,
        PostReactions.Hooray, PostReactions.Heart, PostReactions.Rocket,
        PostReactions.Eyes
    FROM Blogs LEFT OUTER JOIN
        PostReactions ON Blogs.BlogID = PostReactions.BlogID
    WHERE Blogs.BlogID=@BlogID

END
GO
/****** Object:  StoredProcedure [dbo].[BlogsGetAll]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BlogsGetAll]
AS
BEGIN

    SELECT Blogs.BlogID,Blogs.Title, Blogs.Contents,  Blogs.AuthorID,
        Blogs.CreatedDate, PostReactions.PostReactionsID, PostReactions.ThumbsUp,
        PostReactions.Hooray, PostReactions.Heart, PostReactions.Rocket,
        PostReactions.Eyes
    FROM Blogs LEFT OUTER JOIN
        PostReactions ON Blogs.BlogID = PostReactions.BlogID
    ORDER BY Blogs.CreatedDate DESC

END
GO
/****** Object:  StoredProcedure [dbo].[BlogsInsert]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BlogsInsert]
  @Title NVARCHAR(500),
  @Contents NVARCHAR(4000),
  @AuthorID INT
AS
BEGIN
  INSERT INTO Blogs
    (Title, Contents,AuthorID)
  VALUES
    (@Title, @Contents, @AuthorID)
  DECLARE @newBlogID INT=SCOPE_IDENTITY();

  INSERT into PostReactions
    (ThumbsUp ,Hooray ,Heart ,Rocket ,Eyes ,BlogID)
  VALUES
    (0, 0, 0, 0, 0, @newBlogID)

  EXECUTE [dbo].[BlogsFindID] @BlogID=@newBlogID;

END;

GO
/****** Object:  StoredProcedure [dbo].[BlogsSearch]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BlogsSearch]
    @Title As NVARCHAR(500)=NULL
AS
BEGIN
    SELECT Blogs.BlogID, Blogs.Contents, Blogs.Title, Blogs.AuthorID,
        Blogs.CreatedDate, PostReactions.PostReactionsID, PostReactions.ThumbsUp,
        PostReactions.Hooray, PostReactions.Heart, PostReactions.Rocket,
        PostReactions.Eyes
    FROM Blogs LEFT OUTER JOIN
        PostReactions ON Blogs.BlogID = PostReactions.BlogID
    WHERE @Title IS NULL OR Title LIKE '%' + @Title + '%'
    ORDER BY Blogs.CreatedDate DESC

END
GO
/****** Object:  StoredProcedure [dbo].[BlogsUpdate]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BlogsUpdate]
  @BlogID INT,
  @Title NVARCHAR(50),
  @Contents NVARCHAR(50)
AS
BEGIN
  UPDATE Blogs
      SET Title = @Title,
          Contents = @Contents
      WHERE BlogID = @BlogID

  EXECUTE[dbo].[BlogsFindID] @BlogID=@BlogID;
END;
GO
/****** Object:  StoredProcedure [dbo].[PostReactionsUpdate]    Script Date: 07/01/1404 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PostReactionsUpdate]
    @BlogID INT,
    @ThumbsUp INT = NULL,
    @Hooray INT = NULL,
    @Heart INT = NULL,
    @Rocket INT = NULL,
    @Eyes INT = NULL

AS
BEGIN
    UPDATE PostReactions
    SET ThumbsUp = COALESCE(NULLIF(@ThumbsUp, 0), ThumbsUp),
        Hooray = COALESCE(NULLIF(@Hooray, 0), Hooray),
        Heart = COALESCE(NULLIF(@Heart, 0), Heart),
        Rocket = COALESCE(NULLIF(@Rocket, 0), Rocket),
        Eyes = COALESCE(NULLIF(@Eyes, 0), Eyes)
    WHERE BlogID = @BlogID
    execute dbo.BlogsFindID @BlogID = @BlogID
END
GO
USE [master]
GO
ALTER DATABASE [DB_Blog] SET  READ_WRITE 
GO
