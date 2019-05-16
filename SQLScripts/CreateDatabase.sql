USE [master]
GO

/****** Object:  Database [elmhurstjaycees]    Script Date: 5/23/2014 9:03:17 AM ******/
CREATE DATABASE [elmhurstjaycees] ON  PRIMARY 
( NAME = N'elmhurstjaycees', FILENAME = N'C:\DatabaseFiles\DATA\elmhurstjaycees.mdf' , SIZE = 10240KB , MAXSIZE = 204800KB , FILEGROWTH = 5120KB )
 LOG ON 
( NAME = N'elmhurstjaycees_log', FILENAME = N'C:\DatabaseFiles\Log\elmhurstjaycees_log.LDF' , SIZE = 7168KB , MAXSIZE = 102400KB , FILEGROWTH = 5120KB )
GO

ALTER DATABASE [elmhurstjaycees] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [elmhurstjaycees].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [elmhurstjaycees] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET ARITHABORT OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [elmhurstjaycees] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [elmhurstjaycees] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [elmhurstjaycees] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET  DISABLE_BROKER 
GO

ALTER DATABASE [elmhurstjaycees] SET AUTO_UPDATE_STATISTICS_ASYNC ON 
GO

ALTER DATABASE [elmhurstjaycees] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [elmhurstjaycees] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [elmhurstjaycees] SET  MULTI_USER 
GO

ALTER DATABASE [elmhurstjaycees] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [elmhurstjaycees] SET DB_CHAINING OFF 
GO

ALTER DATABASE [elmhurstjaycees] SET  READ_WRITE 
GO


