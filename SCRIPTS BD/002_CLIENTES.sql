USE [DB_SistemaClientes]
GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 10/10/2022 13:19:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Endereco] [nvarchar](255) NOT NULL,
	[CPF] [nvarchar](15) NOT NULL,
	[DataNascimento] [nvarchar](max) NOT NULL,
	[IdEstado] [int] NOT NULL,
	[IdCidade] [int] NOT NULL,
	[Sexo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


