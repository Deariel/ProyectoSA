USE [ENTIDAD_CPXGT]
GO
/****** Object:  Table [dbo].[BITACORA_CPXGT]    Script Date: 6/28/2016 3:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BITACORA_CPXGT](
	[idBitacora] [int] IDENTITY(1,1) NOT NULL,
	[tramaEnviada] [nchar](1500) NULL,
	[tramaRecivida] [nchar](1500) NULL,
	[numTransaccion] [int] NULL,
	[detalle] [nchar](150) NULL,
 CONSTRAINT [PK_BITACORA_CPXGT] PRIMARY KEY CLUSTERED 
(
	[idBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetalleFormulario]    Script Date: 6/28/2016 3:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFormulario](
	[idItem] [int] IDENTITY(1,1) NOT NULL,
	[idFormulario] [int] NOT NULL,
	[Categoria] [int] NULL,
	[Cantidad] [int] NULL,
	[Precio] [decimal](18, 2) NULL,
	[Descripcion] [nchar](50) NULL,
	[Peso] [decimal](18, 2) NULL,
 CONSTRAINT [PK_DetalleFormulario] PRIMARY KEY CLUSTERED 
(
	[idItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Formulario]    Script Date: 6/28/2016 3:22:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formulario](
	[idFormulario] [int] NOT NULL,
	[NumeroManifiesto] [int] NULL,
	[Monto] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Formulario] PRIMARY KEY CLUSTERED 
(
	[idFormulario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DetalleFormulario]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFormulario_Formulario] FOREIGN KEY([idFormulario])
REFERENCES [dbo].[Formulario] ([idFormulario])
GO
ALTER TABLE [dbo].[DetalleFormulario] CHECK CONSTRAINT [FK_DetalleFormulario_Formulario]
GO
