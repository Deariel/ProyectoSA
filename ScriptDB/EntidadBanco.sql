USE [master]
GO
/****** Object:  Database [ENTIDAD_BANCO]    Script Date: 6/22/2016 5:38:26 PM ******/
CREATE DATABASE [ENTIDAD_BANCO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ENTIDAD_BANCO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER2\MSSQL\DATA\ENTIDAD_BANCO.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ENTIDAD_BANCO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER2\MSSQL\DATA\ENTIDAD_BANCO_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ENTIDAD_BANCO] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ENTIDAD_BANCO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ENTIDAD_BANCO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET ARITHABORT OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET RECOVERY FULL 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET  MULTI_USER 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ENTIDAD_BANCO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ENTIDAD_BANCO] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ENTIDAD_BANCO]
GO
/****** Object:  Table [dbo].[BITACORA_BANCO]    Script Date: 6/22/2016 5:38:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BITACORA_BANCO](
	[idBitacora] [int] IDENTITY(1,1) NOT NULL,
	[tramaEnviada] [nchar](500) NULL,
	[tramaRecivida] [nchar](500) NULL,
	[numTransaccion] [int] NULL,
	[detalle] [nchar](150) NULL,
 CONSTRAINT [PK_BITACORA_BANCO] PRIMARY KEY CLUSTERED 
(
	[idBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CUENTA]    Script Date: 6/22/2016 5:38:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUENTA](
	[idCuenta] [int] IDENTITY(1,1) NOT NULL,
	[tipoCuenta] [int] NULL,
	[numCuenta] [nchar](10) NULL,
	[saldo] [decimal](18, 2) NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_CUENTA] PRIMARY KEY CLUSTERED 
(
	[idCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PAGO]    Script Date: 6/22/2016 5:38:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAGO](
	[idPago] [int] IDENTITY(1,1) NOT NULL,
	[cuentaOrigen] [int] NULL,
	[cuentaDestino] [int] NULL,
	[monto] [decimal](18, 2) NULL,
	[formulario] [nchar](50) NULL,
	[tipoFormulario] [int] NULL,
 CONSTRAINT [PK_PAGO] PRIMARY KEY CLUSTERED 
(
	[idPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TARJETA]    Script Date: 6/22/2016 5:38:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TARJETA](
	[idTarjeta] [int] IDENTITY(1,1) NOT NULL,
	[numTarjeta] [nchar](50) NULL,
	[tipoTarjeta] [int] NULL,
	[idCuenta] [int] NOT NULL,
 CONSTRAINT [PK_TARJETA] PRIMARY KEY CLUSTERED 
(
	[idTarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 6/22/2016 5:38:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[primerNombre] [nchar](50) NULL,
	[segundoNombre] [nchar](50) NULL,
	[primerApellido] [nchar](50) NULL,
	[segundoApellido] [nchar](50) NULL,
	[direccion] [nchar](50) NULL,
	[fechaNacimiento] [date] NULL,
	[telefono] [nchar](10) NULL,
	[password] [nchar](20) NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CUENTA] ON 

INSERT [dbo].[CUENTA] ([idCuenta], [tipoCuenta], [numCuenta], [saldo], [idUsuario]) VALUES (1, 1, N'103005028 ', CAST(300.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[CUENTA] ([idCuenta], [tipoCuenta], [numCuenta], [saldo], [idUsuario]) VALUES (2, 1, N'50281030  ', CAST(500.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[CUENTA] ([idCuenta], [tipoCuenta], [numCuenta], [saldo], [idUsuario]) VALUES (3, 1, N'f8d3c60c  ', CAST(175.25 AS Decimal(18, 2)), 7)
INSERT [dbo].[CUENTA] ([idCuenta], [tipoCuenta], [numCuenta], [saldo], [idUsuario]) VALUES (4, 1, N'f8d3c60c  ', CAST(175.25 AS Decimal(18, 2)), 8)
INSERT [dbo].[CUENTA] ([idCuenta], [tipoCuenta], [numCuenta], [saldo], [idUsuario]) VALUES (5, 1, N'7dd8d612  ', CAST(175.25 AS Decimal(18, 2)), 9)
INSERT [dbo].[CUENTA] ([idCuenta], [tipoCuenta], [numCuenta], [saldo], [idUsuario]) VALUES (6, 1, N'7dd8d612  ', CAST(175.25 AS Decimal(18, 2)), 10)
INSERT [dbo].[CUENTA] ([idCuenta], [tipoCuenta], [numCuenta], [saldo], [idUsuario]) VALUES (7, 1, N'624441    ', CAST(175.25 AS Decimal(18, 2)), 11)
INSERT [dbo].[CUENTA] ([idCuenta], [tipoCuenta], [numCuenta], [saldo], [idUsuario]) VALUES (8, 1, N'358735    ', CAST(175.25 AS Decimal(18, 2)), 12)
INSERT [dbo].[CUENTA] ([idCuenta], [tipoCuenta], [numCuenta], [saldo], [idUsuario]) VALUES (9, 1, N'143034    ', CAST(175.25 AS Decimal(18, 2)), 13)
SET IDENTITY_INSERT [dbo].[CUENTA] OFF
SET IDENTITY_INSERT [dbo].[USUARIO] ON 

INSERT [dbo].[USUARIO] ([idUsuario], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [direccion], [fechaNacimiento], [telefono], [password]) VALUES (3, N'Dennis                                            ', N'Ariel                                             ', N'Ordoñez                                           ', N'Per                                               ', N'Ciudad                                            ', CAST(0x883B0B00 AS Date), N'54875698  ', NULL)
INSERT [dbo].[USUARIO] ([idUsuario], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [direccion], [fechaNacimiento], [telefono], [password]) VALUES (5, N'Pablo                                             ', N'Ali                                               ', N'Gonzales                                          ', N'Oliva                                             ', N'Ciudad                                            ', CAST(0x22170B00 AS Date), N'54875698  ', NULL)
INSERT [dbo].[USUARIO] ([idUsuario], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [direccion], [fechaNacimiento], [telefono], [password]) VALUES (6, N'prueba                                            ', N'prueba                                            ', N'prueba                                            ', N'prueba                                            ', N'Ciudad Guatemala                                  ', CAST(0x883B0B00 AS Date), N'58745698  ', NULL)
INSERT [dbo].[USUARIO] ([idUsuario], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [direccion], [fechaNacimiento], [telefono], [password]) VALUES (7, N'Usuario1                                          ', NULL, N'Usuario1                                          ', NULL, NULL, CAST(0x22170B00 AS Date), NULL, N'usuario1            ')
INSERT [dbo].[USUARIO] ([idUsuario], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [direccion], [fechaNacimiento], [telefono], [password]) VALUES (8, N'Usuario1                                          ', NULL, N'Usuario1                                          ', NULL, NULL, CAST(0x22170B00 AS Date), NULL, N'usuario1            ')
INSERT [dbo].[USUARIO] ([idUsuario], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [direccion], [fechaNacimiento], [telefono], [password]) VALUES (9, N'Usuario1                                          ', NULL, N'Usuario1                                          ', NULL, NULL, CAST(0x22170B00 AS Date), NULL, N'usuario1            ')
INSERT [dbo].[USUARIO] ([idUsuario], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [direccion], [fechaNacimiento], [telefono], [password]) VALUES (10, N'Usuario1                                          ', NULL, N'Usuario1                                          ', NULL, NULL, CAST(0x22170B00 AS Date), NULL, N'usuario1            ')
INSERT [dbo].[USUARIO] ([idUsuario], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [direccion], [fechaNacimiento], [telefono], [password]) VALUES (11, N'Usuario1                                          ', NULL, N'Usuario1                                          ', NULL, NULL, CAST(0x22170B00 AS Date), NULL, N'usuario1            ')
INSERT [dbo].[USUARIO] ([idUsuario], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [direccion], [fechaNacimiento], [telefono], [password]) VALUES (12, N'Usuario1                                          ', NULL, N'Usuario1                                          ', NULL, NULL, CAST(0x22170B00 AS Date), NULL, N'usuario1            ')
INSERT [dbo].[USUARIO] ([idUsuario], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [direccion], [fechaNacimiento], [telefono], [password]) VALUES (13, N'Usuario1                                          ', NULL, N'Usuario1                                          ', NULL, NULL, CAST(0x22170B00 AS Date), NULL, N'usuario1            ')
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
ALTER TABLE [dbo].[CUENTA]  WITH CHECK ADD  CONSTRAINT [FK_CUENTA_USUARIO] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[USUARIO] ([idUsuario])
GO
ALTER TABLE [dbo].[CUENTA] CHECK CONSTRAINT [FK_CUENTA_USUARIO]
GO
ALTER TABLE [dbo].[TARJETA]  WITH CHECK ADD  CONSTRAINT [FK_TARJETA_CUENTA] FOREIGN KEY([idCuenta])
REFERENCES [dbo].[CUENTA] ([idCuenta])
GO
ALTER TABLE [dbo].[TARJETA] CHECK CONSTRAINT [FK_TARJETA_CUENTA]
GO
USE [master]
GO
ALTER DATABASE [ENTIDAD_BANCO] SET  READ_WRITE 
GO




USE [ENTIDAD_BANCO]
GO

/****** Object:  Table [dbo].[TASACAMBIO]    Script Date: 06/27/2016 02:06:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TASACAMBIO](
	[IDFechCambio] [datetime] NOT NULL,
	[IDMoneda] [int] NULL,
	[Valor] [decimal](6, 2) NULL,
 CONSTRAINT [PK_TASACAMBIO] PRIMARY KEY CLUSTERED 
(
	[IDFechCambio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


insert into TASACAMBIO   ( IDFechCambio,IDMoneda,Valor ) VALUES ('20160101',1,7.8);






