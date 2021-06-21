USE [master]
GO
/****** Object:  Database [SISAP-DEV]    Script Date: 19/06/2021 14:38:14 ******/
CREATE DATABASE [SISAP-DEV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SISAP-DEV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SISAP-DEV.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SISAP-DEV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SISAP-DEV_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SISAP-DEV] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SISAP-DEV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SISAP-DEV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SISAP-DEV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SISAP-DEV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SISAP-DEV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SISAP-DEV] SET ARITHABORT OFF 
GO
ALTER DATABASE [SISAP-DEV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SISAP-DEV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SISAP-DEV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SISAP-DEV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SISAP-DEV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SISAP-DEV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SISAP-DEV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SISAP-DEV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SISAP-DEV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SISAP-DEV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SISAP-DEV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SISAP-DEV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SISAP-DEV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SISAP-DEV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SISAP-DEV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SISAP-DEV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SISAP-DEV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SISAP-DEV] SET RECOVERY FULL 
GO
ALTER DATABASE [SISAP-DEV] SET  MULTI_USER 
GO
ALTER DATABASE [SISAP-DEV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SISAP-DEV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SISAP-DEV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SISAP-DEV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SISAP-DEV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SISAP-DEV] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SISAP-DEV] SET QUERY_STORE = OFF
GO
USE [SISAP-DEV]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[CategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[TipoCategoria] [varchar](100) NULL,
	[ClaseId] [int] NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciclos]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciclos](
	[CiclosId] [int] IDENTITY(1,1) NOT NULL,
	[Annio] [int] NULL,
	[Mes] [int] NULL,
	[LecturaInicial] [datetime] NULL,
	[LecturaFinal] [datetime] NULL,
	[EmisionInicial] [datetime] NULL,
	[EmisionFinal] [datetime] NULL,
	[DistribucionInicial] [datetime] NULL,
	[DistribucionFinal] [datetime] NULL,
	[CorteInicial] [datetime] NULL,
	[CorteFinal] [datetime] NULL,
 CONSTRAINT [PK_Ciclos] PRIMARY KEY CLUSTERED 
(
	[CiclosId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clase]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clase](
	[ClaseId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [PK_Clase] PRIMARY KEY CLUSTERED 
(
	[ClaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioCreacion] [varchar](50) NULL,
	[CodigoCliente] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[DNI] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Direccion] [varchar](200) NULL,
	[UrbanizacionId] [int] NULL,
	[ManzanaId] [int] NULL,
	[ServicioId] [int] NULL,
	[CategoriaId] [int] NULL,
	[NumeroMedidor] [varchar](50) NULL,
	[EstadoServicioId] [int] NULL,
	[Complemento] [varchar](100) NULL,
	[Observaciones] [varchar](500) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsumoServicio]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsumoServicio](
	[ConsumoServicioId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NULL,
	[CategoriaId] [int] NULL,
	[ServicioId] [int] NULL,
	[PagoId] [int] NULL,
 CONSTRAINT [PK_ConsumoServicio] PRIMARY KEY CLUSTERED 
(
	[ConsumoServicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleEstadoPago]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleEstadoPago](
	[DetalleEstadoPagoId] [int] IDENTITY(1,1) NOT NULL,
	[DetalleEstadoPago] [int] NOT NULL,
 CONSTRAINT [PK_DetalleEstadoPago] PRIMARY KEY CLUSTERED 
(
	[DetalleEstadoPagoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[DetalleFacturaId] [int] IDENTITY(1,1) NOT NULL,
	[ConsumoServicioId] [int] NOT NULL,
	[ServicioId] [int] NOT NULL,
	[UsuarioCreacion] [varchar](50) NULL,
	[Cantidad] [varchar](50) NULL,
	[CostoCubo] [varchar](50) NULL,
	[CostoRefacturacion] [varchar](50) NULL,
	[CostoIGV] [varchar](50) NULL,
	[CostoTotal] [varchar](50) NULL,
 CONSTRAINT [PK_DetalleFactura] PRIMARY KEY CLUSTERED 
(
	[DetalleFacturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direccion](
	[DireccionId] [int] IDENTITY(1,1) NOT NULL,
	[Manzana] [varchar](50) NULL,
	[NumeroLote] [varchar](50) NULL,
	[Asignacion] [varchar](50) NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[DireccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DireccionDato]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DireccionDato](
	[DireccionDatoId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NULL,
	[DireccionId] [int] NULL,
	[UrbanizacionId] [int] NULL,
 CONSTRAINT [PK_DireccionDato] PRIMARY KEY CLUSTERED 
(
	[DireccionDatoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[EstadoId] [int] IDENTITY(1,1) NOT NULL,
	[EstadoMedidor] [int] NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoPago]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoPago](
	[EstadoPagoId] [int] IDENTITY(1,1) NOT NULL,
	[EstadoNombre] [varchar](50) NULL,
 CONSTRAINT [PK_EstadoPago] PRIMARY KEY CLUSTERED 
(
	[EstadoPagoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoServicio]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoServicio](
	[EstadoServicioId] [int] IDENTITY(1,1) NOT NULL,
	[EstadoDescripcion] [varchar](50) NULL,
 CONSTRAINT [PK_EstadoServicio] PRIMARY KEY CLUSTERED 
(
	[EstadoServicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[FacturaId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NULL,
	[Annio] [int] NULL,
	[Mes] [int] NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[FacturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturacion]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturacion](
	[FacturacionId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NULL,
	[Annio] [int] NULL,
	[Mes] [int] NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[NroBoleta] [int] NULL,
	[FechaEmision] [datetime] NULL,
	[EstadoPagado] [int] NULL,
 CONSTRAINT [PK_Facturacion] PRIMARY KEY CLUSTERED 
(
	[FacturacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lectura]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lectura](
	[LecturaId] [int] IDENTITY(1,1) NOT NULL,
	[Annio] [int] NULL,
	[Mes] [int] NULL,
	[CantidadLectura] [decimal](18, 4) NULL,
	[Consumo] [decimal](18, 4) NULL,
	[Promedio] [decimal](18, 4) NULL,
	[Alerta] [varchar](100) NULL,
	[ClienteId] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[CiclosId] [int] NULL,
	[CantidadLecturaAntigua] [decimal](18, 4) NULL,
	[Procesado] [int] NULL,
	[Actualizado] [int] NULL,
 CONSTRAINT [PK_Lectura] PRIMARY KEY CLUSTERED 
(
	[LecturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manzana]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manzana](
	[ManzanaId] [int] IDENTITY(1,1) NOT NULL,
	[UrbanizacionId] [int] NULL,
	[NombreManzana] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medidor]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medidor](
	[MeidorId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NULL,
	[EstadoId] [int] NULL,
	[LecturaId] [int] NULL,
	[NumeroMedidor] [int] NULL,
 CONSTRAINT [PK_Medidor] PRIMARY KEY CLUSTERED 
(
	[MeidorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Opcion]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Opcion](
	[OpcionId] [int] IDENTITY(1,1) NOT NULL,
	[Etiqueta] [varchar](50) NULL,
	[Url] [varchar](50) NULL,
	[ParentId] [int] NULL,
	[Orden] [int] NULL,
	[Icono] [varchar](20) NULL,
	[CreadoPor] [varchar](50) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ModificadoPor] [varchar](50) NULL,
	[FechaModificacion] [datetime2](7) NULL,
 CONSTRAINT [PK_Opcion] PRIMARY KEY CLUSTERED 
(
	[OpcionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 19/06/2021 14:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[PagoId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NULL,
	[Total] [decimal](18, 2) NULL,
	[PeriodoAnnio] [int] NULL,
	[PeriodoMes] [int] NULL,
	[FechaPago] [datetime] NULL,
	[ServicioId] [int] NULL,
	[Observaciones] [varchar](150) NULL,
	[FacturacionId] [int] NULL,
	[EstadoPago] [int] NULL,
	[EstadoPagoDesc] [varchar](100) NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[PagoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rangos]    Script Date: 19/06/2021 14:38:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rangos](
	[RangosId] [int] IDENTITY(1,1) NOT NULL,
	[CategoriaId] [int] NULL,
	[RangoMin] [decimal](18, 2) NULL,
	[RangoMax] [decimal](18, 2) NULL,
	[TarifaAgua] [decimal](18, 2) NULL,
	[TarifaAlcantarillado] [decimal](18, 2) NULL,
	[CargoFijo] [decimal](18, 2) NULL,
	[ClaseId] [int] NULL,
 CONSTRAINT [PK_Rangos] PRIMARY KEY CLUSTERED 
(
	[RangosId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 19/06/2021 14:38:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[ServicioId] [int] IDENTITY(1,1) NOT NULL,
	[ServicioNombre] [varchar](100) NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[ServicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarifario]    Script Date: 19/06/2021 14:38:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarifario](
	[TarifarioId] [int] IDENTITY(1,1) NOT NULL,
	[CategoriaId] [int] NULL,
	[RangoMin] [decimal](18, 2) NULL,
	[RangoMax] [decimal](18, 2) NULL,
	[TarifaAgua] [decimal](18, 2) NULL,
	[TarifaAlcantarillado] [decimal](18, 2) NULL,
	[CargoFijo] [decimal](18, 2) NULL,
	[ClaseId] [int] NULL,
 CONSTRAINT [PK_Tarifario] PRIMARY KEY CLUSTERED 
(
	[TarifarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCategoria]    Script Date: 19/06/2021 14:38:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCategoria](
	[TipoCategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[TipoCategoria] [int] NULL,
 CONSTRAINT [PK_TipoCategoria] PRIMARY KEY CLUSTERED 
(
	[TipoCategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urbanizacion]    Script Date: 19/06/2021 14:38:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urbanizacion](
	[UrbanizacionId] [int] IDENTITY(1,1) NOT NULL,
	[NombreUrbanizacion] [varchar](100) NULL,
	[Codigo] [int] NULL,
 CONSTRAINT [PK_Urbanizacion] PRIMARY KEY CLUSTERED 
(
	[UrbanizacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 19/06/2021 14:38:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Rol] [int] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([CategoriaId], [TipoCategoria], [ClaseId]) VALUES (1, N'Social', 1)
INSERT [dbo].[Categoria] ([CategoriaId], [TipoCategoria], [ClaseId]) VALUES (2, N'Domestico', 1)
INSERT [dbo].[Categoria] ([CategoriaId], [TipoCategoria], [ClaseId]) VALUES (3, N'Comercial', 2)
INSERT [dbo].[Categoria] ([CategoriaId], [TipoCategoria], [ClaseId]) VALUES (4, N'Industrial', 2)
INSERT [dbo].[Categoria] ([CategoriaId], [TipoCategoria], [ClaseId]) VALUES (5, N'Estatal', 2)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Ciclos] ON 

INSERT [dbo].[Ciclos] ([CiclosId], [Annio], [Mes], [LecturaInicial], [LecturaFinal], [EmisionInicial], [EmisionFinal], [DistribucionInicial], [DistribucionFinal], [CorteInicial], [CorteFinal]) VALUES (1, 2021, 11, CAST(N'2021-06-02T00:00:00.000' AS DateTime), CAST(N'2021-06-09T00:00:00.000' AS DateTime), CAST(N'2021-06-04T00:00:00.000' AS DateTime), CAST(N'2021-06-08T00:00:00.000' AS DateTime), CAST(N'2021-06-14T00:00:00.000' AS DateTime), CAST(N'2021-06-14T00:00:00.000' AS DateTime), CAST(N'2021-06-10T00:00:00.000' AS DateTime), CAST(N'2021-06-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Ciclos] ([CiclosId], [Annio], [Mes], [LecturaInicial], [LecturaFinal], [EmisionInicial], [EmisionFinal], [DistribucionInicial], [DistribucionFinal], [CorteInicial], [CorteFinal]) VALUES (2, 2021, 12, CAST(N'2021-06-24T00:00:00.000' AS DateTime), CAST(N'2021-06-15T00:00:00.000' AS DateTime), CAST(N'2021-06-05T00:00:00.000' AS DateTime), CAST(N'2021-06-19T00:00:00.000' AS DateTime), CAST(N'2021-06-08T00:00:00.000' AS DateTime), CAST(N'2021-06-13T00:00:00.000' AS DateTime), CAST(N'2021-06-11T00:00:00.000' AS DateTime), CAST(N'2021-06-09T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Ciclos] OFF
GO
SET IDENTITY_INSERT [dbo].[Clase] ON 

INSERT [dbo].[Clase] ([ClaseId], [Nombre]) VALUES (1, N'Residencial')
INSERT [dbo].[Clase] ([ClaseId], [Nombre]) VALUES (2, N'No residencial')
SET IDENTITY_INSERT [dbo].[Clase] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ClienteId], [UsuarioCreacion], [CodigoCliente], [Nombre], [Apellido], [DNI], [Telefono], [Direccion], [UrbanizacionId], [ManzanaId], [ServicioId], [CategoriaId], [NumeroMedidor], [EstadoServicioId], [Complemento], [Observaciones]) VALUES (1, N'Admin', N'0001', N'Victor Nandito', N'DIESTRA ESPIRITU', N'72087837', N'938492085', N'90', 17, 1, 1, 1, N'KNN-90', 1, N'complemento', N'Ninguna')
INSERT [dbo].[Cliente] ([ClienteId], [UsuarioCreacion], [CodigoCliente], [Nombre], [Apellido], [DNI], [Telefono], [Direccion], [UrbanizacionId], [ManzanaId], [ServicioId], [CategoriaId], [NumeroMedidor], [EstadoServicioId], [Complemento], [Observaciones]) VALUES (2, N'Admin', N'0002', N'Evelin ', N'Valdivia Espinoza', N'7298787', N'8767656', N'231', 1, 2, 2, 2, N'CL-32', 1, N'complemento', N'Ninguna')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[ConsumoServicio] ON 

INSERT [dbo].[ConsumoServicio] ([ConsumoServicioId], [ClienteId], [CategoriaId], [ServicioId], [PagoId]) VALUES (1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[ConsumoServicio] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalleEstadoPago] ON 

INSERT [dbo].[DetalleEstadoPago] ([DetalleEstadoPagoId], [DetalleEstadoPago]) VALUES (1, 1)
INSERT [dbo].[DetalleEstadoPago] ([DetalleEstadoPagoId], [DetalleEstadoPago]) VALUES (2, 2)
INSERT [dbo].[DetalleEstadoPago] ([DetalleEstadoPagoId], [DetalleEstadoPago]) VALUES (3, 3)
SET IDENTITY_INSERT [dbo].[DetalleEstadoPago] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalleFactura] ON 

INSERT [dbo].[DetalleFactura] ([DetalleFacturaId], [ConsumoServicioId], [ServicioId], [UsuarioCreacion], [Cantidad], [CostoCubo], [CostoRefacturacion], [CostoIGV], [CostoTotal]) VALUES (1, 1, 2, N'Admin', N'900', N'30', N'12', NULL, N'12')
SET IDENTITY_INSERT [dbo].[DetalleFactura] OFF
GO
SET IDENTITY_INSERT [dbo].[Estado] ON 

INSERT [dbo].[Estado] ([EstadoId], [EstadoMedidor]) VALUES (1, 1)
INSERT [dbo].[Estado] ([EstadoId], [EstadoMedidor]) VALUES (2, 2)
INSERT [dbo].[Estado] ([EstadoId], [EstadoMedidor]) VALUES (3, 3)
INSERT [dbo].[Estado] ([EstadoId], [EstadoMedidor]) VALUES (4, 4)
SET IDENTITY_INSERT [dbo].[Estado] OFF
GO
SET IDENTITY_INSERT [dbo].[EstadoServicio] ON 

INSERT [dbo].[EstadoServicio] ([EstadoServicioId], [EstadoDescripcion]) VALUES (1, N'Activo')
INSERT [dbo].[EstadoServicio] ([EstadoServicioId], [EstadoDescripcion]) VALUES (2, N'Cortada')
INSERT [dbo].[EstadoServicio] ([EstadoServicioId], [EstadoDescripcion]) VALUES (3, N'Clausurada')
INSERT [dbo].[EstadoServicio] ([EstadoServicioId], [EstadoDescripcion]) VALUES (4, N'Levantada')
SET IDENTITY_INSERT [dbo].[EstadoServicio] OFF
GO
SET IDENTITY_INSERT [dbo].[Facturacion] ON 

INSERT [dbo].[Facturacion] ([FacturacionId], [ClienteId], [Annio], [Mes], [SubTotal], [Total], [NroBoleta], [FechaEmision], [EstadoPagado]) VALUES (1, 2, 2021, 11, CAST(160.00 AS Decimal(18, 2)), CAST(160.00 AS Decimal(18, 2)), NULL, NULL, 1)
INSERT [dbo].[Facturacion] ([FacturacionId], [ClienteId], [Annio], [Mes], [SubTotal], [Total], [NroBoleta], [FechaEmision], [EstadoPagado]) VALUES (2, 2, 2021, 12, CAST(240.00 AS Decimal(18, 2)), CAST(240.00 AS Decimal(18, 2)), NULL, NULL, 1)
INSERT [dbo].[Facturacion] ([FacturacionId], [ClienteId], [Annio], [Mes], [SubTotal], [Total], [NroBoleta], [FechaEmision], [EstadoPagado]) VALUES (3, 1, 2021, 11, CAST(20.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), NULL, NULL, 1)
INSERT [dbo].[Facturacion] ([FacturacionId], [ClienteId], [Annio], [Mes], [SubTotal], [Total], [NroBoleta], [FechaEmision], [EstadoPagado]) VALUES (4, 1, 2021, 12, CAST(240.00 AS Decimal(18, 2)), CAST(240.00 AS Decimal(18, 2)), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Facturacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Lectura] ON 

INSERT [dbo].[Lectura] ([LecturaId], [Annio], [Mes], [CantidadLectura], [Consumo], [Promedio], [Alerta], [ClienteId], [FechaRegistro], [CiclosId], [CantidadLecturaAntigua], [Procesado], [Actualizado]) VALUES (1, 2021, 11, CAST(200.0000 AS Decimal(18, 4)), CAST(200.0000 AS Decimal(18, 4)), NULL, NULL, 2, CAST(N'2021-06-17T10:35:01.043' AS DateTime), NULL, CAST(0.0000 AS Decimal(18, 4)), 1, 1)
INSERT [dbo].[Lectura] ([LecturaId], [Annio], [Mes], [CantidadLectura], [Consumo], [Promedio], [Alerta], [ClienteId], [FechaRegistro], [CiclosId], [CantidadLecturaAntigua], [Procesado], [Actualizado]) VALUES (2, 2021, 12, CAST(300.0000 AS Decimal(18, 4)), CAST(100.0000 AS Decimal(18, 4)), NULL, NULL, 2, CAST(N'2021-06-17T10:35:22.693' AS DateTime), NULL, CAST(200.0000 AS Decimal(18, 4)), 0, 1)
INSERT [dbo].[Lectura] ([LecturaId], [Annio], [Mes], [CantidadLectura], [Consumo], [Promedio], [Alerta], [ClienteId], [FechaRegistro], [CiclosId], [CantidadLecturaAntigua], [Procesado], [Actualizado]) VALUES (3, 2021, 11, CAST(100.0000 AS Decimal(18, 4)), CAST(100.0000 AS Decimal(18, 4)), NULL, NULL, 1, CAST(N'2021-06-17T10:35:40.753' AS DateTime), NULL, CAST(0.0000 AS Decimal(18, 4)), 1, 1)
INSERT [dbo].[Lectura] ([LecturaId], [Annio], [Mes], [CantidadLectura], [Consumo], [Promedio], [Alerta], [ClienteId], [FechaRegistro], [CiclosId], [CantidadLecturaAntigua], [Procesado], [Actualizado]) VALUES (4, 2021, 12, CAST(1200.0000 AS Decimal(18, 4)), CAST(1100.0000 AS Decimal(18, 4)), NULL, NULL, 1, CAST(N'2021-06-17T10:35:53.163' AS DateTime), NULL, CAST(100.0000 AS Decimal(18, 4)), 0, 1)
SET IDENTITY_INSERT [dbo].[Lectura] OFF
GO
SET IDENTITY_INSERT [dbo].[Manzana] ON 

INSERT [dbo].[Manzana] ([ManzanaId], [UrbanizacionId], [NombreManzana]) VALUES (1, 17, N'C')
INSERT [dbo].[Manzana] ([ManzanaId], [UrbanizacionId], [NombreManzana]) VALUES (2, 1, N'DA')
INSERT [dbo].[Manzana] ([ManzanaId], [UrbanizacionId], [NombreManzana]) VALUES (3, 2, N'C')
INSERT [dbo].[Manzana] ([ManzanaId], [UrbanizacionId], [NombreManzana]) VALUES (4, 1, N'A')
SET IDENTITY_INSERT [dbo].[Manzana] OFF
GO
SET IDENTITY_INSERT [dbo].[Medidor] ON 

INSERT [dbo].[Medidor] ([MeidorId], [ClienteId], [EstadoId], [LecturaId], [NumeroMedidor]) VALUES (1, 1, 1, 1, 2658)
SET IDENTITY_INSERT [dbo].[Medidor] OFF
GO
SET IDENTITY_INSERT [dbo].[Opcion] ON 

INSERT [dbo].[Opcion] ([OpcionId], [Etiqueta], [Url], [ParentId], [Orden], [Icono], [CreadoPor], [FechaCreacion], [ModificadoPor], [FechaModificacion]) VALUES (2, N'Clientes', N'~/Cliente/Clientes', NULL, 2, NULL, N'Admin', CAST(N'2021-02-13T09:29:16.1830000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Opcion] ([OpcionId], [Etiqueta], [Url], [ParentId], [Orden], [Icono], [CreadoPor], [FechaCreacion], [ModificadoPor], [FechaModificacion]) VALUES (7, N'Manzana', N'~/Manzana/Manzana', NULL, 4, N'fas fa-users', N'Admin', CAST(N'2021-02-13T09:29:16.1830000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Opcion] ([OpcionId], [Etiqueta], [Url], [ParentId], [Orden], [Icono], [CreadoPor], [FechaCreacion], [ModificadoPor], [FechaModificacion]) VALUES (8, N'Ciclos', N'~/Ciclos/Ciclos', NULL, 5, N'fas fa-users', N'Admin', CAST(N'2021-02-13T09:29:16.1830000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Opcion] ([OpcionId], [Etiqueta], [Url], [ParentId], [Orden], [Icono], [CreadoPor], [FechaCreacion], [ModificadoPor], [FechaModificacion]) VALUES (9, N'Lectura', N'~/Lectura/Lectura', NULL, 6, N'fas fa-users', N'Admin', CAST(N'2021-02-13T09:29:16.1830000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Opcion] ([OpcionId], [Etiqueta], [Url], [ParentId], [Orden], [Icono], [CreadoPor], [FechaCreacion], [ModificadoPor], [FechaModificacion]) VALUES (10, N'Facturacion', N'~/Facturacion/Facturacion', NULL, 7, N'fas fa-users', N'Admin', CAST(N'2021-02-13T09:29:16.1830000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Opcion] ([OpcionId], [Etiqueta], [Url], [ParentId], [Orden], [Icono], [CreadoPor], [FechaCreacion], [ModificadoPor], [FechaModificacion]) VALUES (11, N'Pagos', N'~/Pagos/Pagos', NULL, 8, N'fas fa-users', N'Admin', CAST(N'2021-02-13T09:29:16.1830000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Opcion] ([OpcionId], [Etiqueta], [Url], [ParentId], [Orden], [Icono], [CreadoPor], [FechaCreacion], [ModificadoPor], [FechaModificacion]) VALUES (12, N'Reportes', N'~/Reportes/Reportes', NULL, 9, N'fas fa-users', N'Admin', CAST(N'2021-02-13T09:29:16.1830000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Opcion] ([OpcionId], [Etiqueta], [Url], [ParentId], [Orden], [Icono], [CreadoPor], [FechaCreacion], [ModificadoPor], [FechaModificacion]) VALUES (13, N'Urbanizacion', N'~/Urbanizacion/Urbanizacion', NULL, 2, NULL, N'Admin', CAST(N'2021-02-13T09:29:16.1830000' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Opcion] OFF
GO
SET IDENTITY_INSERT [dbo].[Pago] ON 

INSERT [dbo].[Pago] ([PagoId], [ClienteId], [Total], [PeriodoAnnio], [PeriodoMes], [FechaPago], [ServicioId], [Observaciones], [FacturacionId], [EstadoPago], [EstadoPagoDesc]) VALUES (1, 2, CAST(160.00 AS Decimal(18, 2)), 2021, 11, CAST(N'2021-06-17T10:37:29.307' AS DateTime), NULL, N'Pago de Noviembre', 1, 1, N'Pagado')
INSERT [dbo].[Pago] ([PagoId], [ClienteId], [Total], [PeriodoAnnio], [PeriodoMes], [FechaPago], [ServicioId], [Observaciones], [FacturacionId], [EstadoPago], [EstadoPagoDesc]) VALUES (2, 2, CAST(240.00 AS Decimal(18, 2)), 2021, 12, CAST(N'2021-06-17T10:37:51.723' AS DateTime), NULL, N'Pago de Diciembre', 2, 1, N'Pagado')
INSERT [dbo].[Pago] ([PagoId], [ClienteId], [Total], [PeriodoAnnio], [PeriodoMes], [FechaPago], [ServicioId], [Observaciones], [FacturacionId], [EstadoPago], [EstadoPagoDesc]) VALUES (3, 1, CAST(240.00 AS Decimal(18, 2)), 2021, 12, CAST(N'2021-06-17T10:38:19.450' AS DateTime), NULL, N'Pago de Diestra Noviembre', 4, 1, N'Pagado')
INSERT [dbo].[Pago] ([PagoId], [ClienteId], [Total], [PeriodoAnnio], [PeriodoMes], [FechaPago], [ServicioId], [Observaciones], [FacturacionId], [EstadoPago], [EstadoPagoDesc]) VALUES (4, 1, CAST(20.00 AS Decimal(18, 2)), 2021, 11, CAST(N'2021-06-17T10:38:29.787' AS DateTime), NULL, N'Pago de Diestra Diciembre', 3, 1, N'Pagado')
SET IDENTITY_INSERT [dbo].[Pago] OFF
GO
SET IDENTITY_INSERT [dbo].[Rangos] ON 

INSERT [dbo].[Rangos] ([RangosId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (1, 1, CAST(0.00 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), CAST(0.20 AS Decimal(18, 2)), CAST(0.10 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Rangos] ([RangosId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (2, 2, CAST(0.00 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), CAST(0.30 AS Decimal(18, 2)), CAST(0.20 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Rangos] ([RangosId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (3, 2, CAST(25.10 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), CAST(0.40 AS Decimal(18, 2)), CAST(0.20 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Rangos] ([RangosId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (4, 2, CAST(30.10 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), CAST(0.50 AS Decimal(18, 2)), CAST(0.30 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Rangos] ([RangosId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (5, 3, CAST(0.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), CAST(0.70 AS Decimal(18, 2)), CAST(0.30 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 2)
INSERT [dbo].[Rangos] ([RangosId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (6, 3, CAST(30.10 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), CAST(0.80 AS Decimal(18, 2)), CAST(0.30 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 2)
INSERT [dbo].[Rangos] ([RangosId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (7, 4, CAST(0.00 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(0.40 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 2)
INSERT [dbo].[Rangos] ([RangosId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (8, 5, CAST(0.00 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), CAST(0.30 AS Decimal(18, 2)), CAST(0.10 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 2)
SET IDENTITY_INSERT [dbo].[Rangos] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicio] ON 

INSERT [dbo].[Servicio] ([ServicioId], [ServicioNombre]) VALUES (1, N'Agua')
INSERT [dbo].[Servicio] ([ServicioId], [ServicioNombre]) VALUES (2, N'Agua Alcantarillado')
SET IDENTITY_INSERT [dbo].[Servicio] OFF
GO
SET IDENTITY_INSERT [dbo].[Tarifario] ON 

INSERT [dbo].[Tarifario] ([TarifarioId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (1, 1, CAST(0.00 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), CAST(0.20 AS Decimal(18, 2)), CAST(0.10 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tarifario] ([TarifarioId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (2, 2, CAST(0.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), CAST(0.30 AS Decimal(18, 2)), CAST(0.20 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tarifario] ([TarifarioId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (3, 2, CAST(25.10 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), CAST(0.40 AS Decimal(18, 2)), CAST(0.20 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tarifario] ([TarifarioId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (4, 2, CAST(30.10 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), CAST(0.50 AS Decimal(18, 2)), CAST(0.30 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tarifario] ([TarifarioId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (5, 3, CAST(0.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), CAST(0.70 AS Decimal(18, 2)), CAST(0.30 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 2)
INSERT [dbo].[Tarifario] ([TarifarioId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (6, 3, CAST(30.10 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), CAST(0.80 AS Decimal(18, 2)), CAST(0.30 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 2)
INSERT [dbo].[Tarifario] ([TarifarioId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (7, 4, CAST(0.00 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(0.40 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 2)
INSERT [dbo].[Tarifario] ([TarifarioId], [CategoriaId], [RangoMin], [RangoMax], [TarifaAgua], [TarifaAlcantarillado], [CargoFijo], [ClaseId]) VALUES (8, 5, CAST(0.00 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), CAST(0.30 AS Decimal(18, 2)), CAST(0.10 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), 2)
SET IDENTITY_INSERT [dbo].[Tarifario] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoCategoria] ON 

INSERT [dbo].[TipoCategoria] ([TipoCategoriaId], [TipoCategoria]) VALUES (1, 1)
INSERT [dbo].[TipoCategoria] ([TipoCategoriaId], [TipoCategoria]) VALUES (2, 2)
INSERT [dbo].[TipoCategoria] ([TipoCategoriaId], [TipoCategoria]) VALUES (3, 3)
INSERT [dbo].[TipoCategoria] ([TipoCategoriaId], [TipoCategoria]) VALUES (4, 4)
INSERT [dbo].[TipoCategoria] ([TipoCategoriaId], [TipoCategoria]) VALUES (5, 5)
SET IDENTITY_INSERT [dbo].[TipoCategoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Urbanizacion] ON 

INSERT [dbo].[Urbanizacion] ([UrbanizacionId], [NombreUrbanizacion], [Codigo]) VALUES (1, N'Santa Beatriz', 1012)
INSERT [dbo].[Urbanizacion] ([UrbanizacionId], [NombreUrbanizacion], [Codigo]) VALUES (2, N'Santa Luzmila', 1013)
INSERT [dbo].[Urbanizacion] ([UrbanizacionId], [NombreUrbanizacion], [Codigo]) VALUES (3, N'Bellavista', 1014)
INSERT [dbo].[Urbanizacion] ([UrbanizacionId], [NombreUrbanizacion], [Codigo]) VALUES (17, N'Lima', 1016)
SET IDENTITY_INSERT [dbo].[Urbanizacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([UsuarioId], [usuario], [Password], [Nombre], [Rol], [Estado]) VALUES (1, N'Admin', N'admin', N'Nando', 0, 0)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
USE [master]
GO
ALTER DATABASE [SISAP-DEV] SET  READ_WRITE 
GO
