USE [master]
GO
/****** Object:  Database [KutuphaneOtomasyonu]    Script Date: 20.02.2021 22:56:23 ******/
CREATE DATABASE [KutuphaneOtomasyonu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KutuphaneOtomasyonu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\KutuphaneOtomasyonu.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KutuphaneOtomasyonu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\KutuphaneOtomasyonu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KutuphaneOtomasyonu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET ARITHABORT OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET RECOVERY FULL 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET  MULTI_USER 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'KutuphaneOtomasyonu', N'ON'
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET QUERY_STORE = OFF
GO
USE [KutuphaneOtomasyonu]
GO
/****** Object:  Table [dbo].[EmanetKitaplar]    Script Date: 20.02.2021 22:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmanetKitaplar](
	[tc] [nvarchar](50) NOT NULL,
	[adsoyad] [nvarchar](50) NOT NULL,
	[yas] [nvarchar](50) NOT NULL,
	[telefon   ] [nvarchar](50) NOT NULL,
	[barkodno] [nvarchar](50) NOT NULL,
	[kitapadi] [nvarchar](50) NOT NULL,
	[yazari] [nvarchar](50) NOT NULL,
	[yayinevi] [nvarchar](50) NOT NULL,
	[sayfasayisi] [nvarchar](50) NOT NULL,
	[kitapsayisi] [int] NOT NULL,
	[teslimtarihi] [nchar](20) NOT NULL,
	[iadetarihi] [nchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kitap]    Script Date: 20.02.2021 22:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kitap](
	[barkodno] [nvarchar](50) NOT NULL,
	[kitapadi] [nvarchar](50) NOT NULL,
	[yazari] [nvarchar](50) NOT NULL,
	[yayinevi] [nvarchar](50) NOT NULL,
	[sayfasayisi] [nvarchar](50) NOT NULL,
	[turu] [nvarchar](50) NOT NULL,
	[stoksayisi] [int] NOT NULL,
	[rafno] [nvarchar](50) NOT NULL,
	[aciklama] [nvarchar](50) NOT NULL,
	[kayittarihi] [nchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sepet]    Script Date: 20.02.2021 22:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sepet](
	[barkodno] [nvarchar](50) NOT NULL,
	[kitapadi] [nvarchar](50) NOT NULL,
	[yazari] [nvarchar](50) NOT NULL,
	[yayinevi] [nvarchar](50) NOT NULL,
	[sayfasayisi] [nvarchar](50) NOT NULL,
	[kitapsayisi] [int] NOT NULL,
	[teslimtarihi] [nchar](20) NOT NULL,
	[iadetarihi] [nchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uye]    Script Date: 20.02.2021 22:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uye](
	[tc] [nvarchar](50) NOT NULL,
	[adsoyad] [nvarchar](50) NOT NULL,
	[yas] [nvarchar](50) NOT NULL,
	[cinsiyet] [nvarchar](50) NOT NULL,
	[telefon] [nvarchar](50) NOT NULL,
	[adres] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[okukitapsayisi] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[EmanetKitaplar] ([tc], [adsoyad], [yas], [telefon   ], [barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [kitapsayisi], [teslimtarihi], [iadetarihi]) VALUES (N'100', N'Meryem Çevik', N'14', N'(537) 678-6767', N'77', N'Aşk', N'Elif Şafak', N' Penguin Books', N'487', 1, N'18.02.2021          ', N'18.02.2021          ')
INSERT [dbo].[EmanetKitaplar] ([tc], [adsoyad], [yas], [telefon   ], [barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [kitapsayisi], [teslimtarihi], [iadetarihi]) VALUES (N'100', N'Meryem Çevik', N'14', N'(537) 678-6767', N'19', N'Kardeşimin Hikayesi', N'Zülfü Livaneli', N'DK', N'250', 1, N'18.02.2021          ', N'18.02.2021          ')
INSERT [dbo].[EmanetKitaplar] ([tc], [adsoyad], [yas], [telefon   ], [barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [kitapsayisi], [teslimtarihi], [iadetarihi]) VALUES (N'44322346787', N'Pınar Sezgin', N'20', N'(544) 875-4455', N'13', N'Serenad', N'Serenad', N'DK', N'190', 1, N'18.02.2021          ', N'21.02.2021          ')
INSERT [dbo].[EmanetKitaplar] ([tc], [adsoyad], [yas], [telefon   ], [barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [kitapsayisi], [teslimtarihi], [iadetarihi]) VALUES (N'4432234678744322346787', N'Pınar Sezgin', N'20', N'(544) 875-4455', N'77', N'Aşk', N'Elif Şafak', N' Penguin Books', N'487', 1, N'18.02.2021          ', N'21.02.2021          ')
INSERT [dbo].[EmanetKitaplar] ([tc], [adsoyad], [yas], [telefon   ], [barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [kitapsayisi], [teslimtarihi], [iadetarihi]) VALUES (N'55656555543', N'Rabia Çevik', N'20', N'(531) 724-3435', N'500', N'Robinson Crusoe', N'Daniel Defoe', N'Bilgi', N'160', 1, N'18.02.2021          ', N'28.02.2021          ')
GO
INSERT [dbo].[Kitap] ([barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [turu], [stoksayisi], [rafno], [aciklama], [kayittarihi]) VALUES (N'500', N'Robinson Crusoe', N'Daniel Defoe', N'Bilgi', N'160', N'Hikaye', 14, N'1', N'', N'17.02.2021          ')
INSERT [dbo].[Kitap] ([barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [turu], [stoksayisi], [rafno], [aciklama], [kayittarihi]) VALUES (N'620', N'Felatun Bey ile Rakım Efendi', N'Ahmet Midhat', N'Özgür', N'168', N'Hikaye', 17, N'2', N'', N'17.02.2021          ')
INSERT [dbo].[Kitap] ([barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [turu], [stoksayisi], [rafno], [aciklama], [kayittarihi]) VALUES (N'625', N'Sefiller', N'Victor Hugo', N'Kapadokya', N'390', N'Roman', 20, N'3', N'', N'17.02.2021          ')
INSERT [dbo].[Kitap] ([barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [turu], [stoksayisi], [rafno], [aciklama], [kayittarihi]) VALUES (N'535', N'Son Ada', N'Zülfü Livaneli ', N'DK', N'167', N'Roman', 20, N'4', N'', N'18.02.2021          ')
INSERT [dbo].[Kitap] ([barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [turu], [stoksayisi], [rafno], [aciklama], [kayittarihi]) VALUES (N'77', N'Aşk', N'Elif Şafak', N' Penguin Books', N'487', N'Roman', 18, N'5', N'', N'18.02.2021          ')
INSERT [dbo].[Kitap] ([barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [turu], [stoksayisi], [rafno], [aciklama], [kayittarihi]) VALUES (N'13', N'Serenad', N'Serenad', N'DK', N'190', N'Roman', 19, N'6', N'', N'18.02.2021          ')
INSERT [dbo].[Kitap] ([barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [turu], [stoksayisi], [rafno], [aciklama], [kayittarihi]) VALUES (N'19', N'Kardeşimin Hikayesi', N'Zülfü Livaneli', N'DK', N'250', N'Roman', 19, N'7', N'', N'18.02.2021          ')
INSERT [dbo].[Kitap] ([barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [turu], [stoksayisi], [rafno], [aciklama], [kayittarihi]) VALUES (N'37', N'İnsan Ne İle Yaşar', N'Lev Tolstoy', N'Türkiye İş Bankası', N'176', N'Hikaye', 20, N'8', N'', N'18.02.2021          ')
INSERT [dbo].[Kitap] ([barkodno], [kitapadi], [yazari], [yayinevi], [sayfasayisi], [turu], [stoksayisi], [rafno], [aciklama], [kayittarihi]) VALUES (N'25', N'Araba Sevdası', N'Recaizade Mahmut Ekrem', N'Realist Roman', N'140', N'Roman', 20, N'9', N'', N'18.02.2021          ')
GO
INSERT [dbo].[Uye] ([tc], [adsoyad], [yas], [cinsiyet], [telefon], [adres], [email], [okukitapsayisi]) VALUES (N'34', N'Ahmet Hakan', N'18', N'Erkek', N'(531) 876-5678', N'Bakırköy/İstanbul', N'ahmet567@hotmail.com', 0)
INSERT [dbo].[Uye] ([tc], [adsoyad], [yas], [cinsiyet], [telefon], [adres], [email], [okukitapsayisi]) VALUES (N'100', N'Meryem Çevik', N'14', N'Kadın', N'(537) 678-6767', N'Başakşehir/İstanbul', N'meryemcev@gmail.com', 5)
INSERT [dbo].[Uye] ([tc], [adsoyad], [yas], [cinsiyet], [telefon], [adres], [email], [okukitapsayisi]) VALUES (N'66666666666', N'Gülin Yıldırım', N'20', N'Kadın', N'(536) 578-9654', N'Başakşehir/İstanbul', N'gulinyıldırım@hotmail.com', 1)
INSERT [dbo].[Uye] ([tc], [adsoyad], [yas], [cinsiyet], [telefon], [adres], [email], [okukitapsayisi]) VALUES (N'55656555543', N'Rabia Çevik', N'20', N'Kadın', N'(531) 724-3435', N'Başakşehir/İstanbul', N'rcevikk65@hotmail.com', 3)
INSERT [dbo].[Uye] ([tc], [adsoyad], [yas], [cinsiyet], [telefon], [adres], [email], [okukitapsayisi]) VALUES (N'44322346787', N'Pınar Sezgin', N'20', N'Kadın', N'(544) 875-4455', N'Bahçelievler/İstanbul', N'pinarr677@hotmail.com', 3)
GO
USE [master]
GO
ALTER DATABASE [KutuphaneOtomasyonu] SET  READ_WRITE 
GO
