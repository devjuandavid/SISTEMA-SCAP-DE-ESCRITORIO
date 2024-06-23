USE [master]
GO
/****** Object:  Database [BDAsistenciaHuellaDigital]    Script Date: 28/03/2024 2:30:09 ******/
CREATE DATABASE [BDAsistenciaHuellaDigital]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDAsistenciaHuellaDigital', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BDAsistenciaHuellaDigital.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDAsistenciaHuellaDigital_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BDAsistenciaHuellaDigital_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDAsistenciaHuellaDigital].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET RECOVERY FULL 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET  MULTI_USER 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BDAsistenciaHuellaDigital', N'ON'
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET QUERY_STORE = ON
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BDAsistenciaHuellaDigital]
GO
/****** Object:  UserDefinedFunction [dbo].[Auto_Genera_Doc]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Auto_Genera_Doc](@Id_Tipo int)
Returns Char(5)
Begin 
	Declare @Nro as varchar(5)
	Select @Nro=RIGHT('00000' + convert(varchar,Cast(Numero_T AS INT)+1),5)  From TipoDoc  
	Where Idtipo=@Id_tipo
	
	Return(@Nro)
End
GO
/****** Object:  Table [dbo].[Justificacion]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Justificacion](
	[Id_Justi] [char](8) NOT NULL,
	[Id_Pernl] [char](10) NOT NULL,
	[PrincipalMotivo] [nvarchar](50) NULL,
	[Detalle_Justi] [nvarchar](max) NULL,
	[FechaJusti] [date] NULL,
	[EstadoJus] [nvarchar](50) NULL,
	[FechaEmi] [date] NULL,
 CONSTRAINT [PK_jsu] PRIMARY KEY CLUSTERED 
(
	[Id_Justi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERSONAL]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONAL](
	[Id_Pernl] [char](10) NOT NULL,
	[DOC] [char](15) NOT NULL,
	[Nombre_Completo] [varchar](150) NOT NULL,
	[Fec_Naci] [date] NULL,
	[Sexo] [char](1) NULL,
	[Domicilio] [nvarchar](120) NULL,
	[Correo] [varchar](50) NULL,
	[Celular] [varchar](10) NULL,
	[Id_rol] [char](7) NOT NULL,
	[Foto] [nvarchar](200) NULL,
	[Id_Depto] [char](10) NOT NULL,
	[FinguerPrint] [varbinary](2500) NULL,
	[Estado_Per] [varchar](20) NULL,
 CONSTRAINT [PK_person] PRIMARY KEY CLUSTERED 
(
	[Id_Pernl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Personal_Justificacion]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Personal_Justificacion]
AS
SELECT        J.Id_Justi, J.PrincipalMotivo, J.Detalle_Justi, J.FechaJusti, J.EstadoJus, J.FechaEmi, P.Id_Pernl, P.DOC, P.Nombre_Completo
FROM            dbo.Justificacion AS J INNER JOIN
                         dbo.PERSONAL AS P ON J.Id_Pernl = P.Id_Pernl
GO
/****** Object:  Table [dbo].[PUsuario]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PUsuario](
	[Id_Usu] [char](8) NOT NULL,
	[Nombre_Completo] [nvarchar](150) NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[Nom_Usuario] [varchar](20) NOT NULL,
	[Password] [nvarchar](12) NOT NULL,
	[Estado_USu] [varchar](30) NOT NULL,
	[Id_Rol] [char](7) NULL,
 CONSTRAINT [fk_usu2] PRIMARY KEY CLUSTERED 
(
	[Id_Usu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROL]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL](
	[Id_rol] [char](7) NOT NULL,
	[NomRol] [varchar](50) NULL,
 CONSTRAINT [PK_Rols] PRIMARY KEY CLUSTERED 
(
	[Id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Usuarios_Roles]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[V_Usuarios_Roles]
As
Select Id_Usu,Nombre_Completo,Nom_Usuario,Password,Avatar,
U.Id_Rol,R.NomRol ,U.Estado_usu
From PUsuario U, ROL R
Where U.Id_Rol=R.Id_Rol
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[Id_Depto] [char](10) NOT NULL,
	[Depto] [nvarchar](50) NULL,
 CONSTRAINT [Pk_Dis] PRIMARY KEY CLUSTERED 
(
	[Id_Depto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Vista_Personal]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Vista_Personal]
AS
SELECT        P.Id_Pernl, P.DOC, P.Nombre_Completo, P.Fec_Naci, P.Sexo, P.Domicilio, P.Correo, P.Celular, P.Foto, P.FinguerPrint, P.Estado_Per, D.Id_Depto, D.Depto, R.Id_rol, R.NomRol
FROM            dbo.PERSONAL AS P INNER JOIN
                         dbo.Departamento AS D ON P.Id_Depto = D.Id_Depto INNER JOIN
                         dbo.ROL AS R ON P.Id_rol = R.Id_rol
GO
/****** Object:  Table [dbo].[ASISTENCIAPER]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASISTENCIAPER](
	[Id_asis] [char](8) NOT NULL,
	[Id_Pernl] [char](10) NOT NULL,
	[FechaAsis] [date] NULL,
	[Nombre_dia] [varchar](12) NOT NULL,
	[HoIngreso] [varchar](10) NOT NULL,
	[HoSalida] [varchar](10) NOT NULL,
	[Tardanzas] [real] NULL,
	[Total_HrsWorked] [real] NULL,
	[Adelanto] [real] NULL,
	[Justifacion] [nvarchar](max) NULL,
	[EstadoAsis] [varchar](20) NULL,
	[Identificador] [varchar](12) NULL,
 CONSTRAINT [PK_asintcia] PRIMARY KEY CLUSTERED 
(
	[Id_asis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Vista_Personal_Asistencia]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Vista_Personal_Asistencia]
AS
SELECT        P.Id_Pernl, P.DOC, P.Nombre_Completo, P.Sexo, A.Id_asis, A.FechaAsis, A.Nombre_dia, A.HoIngreso, A.HoSalida, A.Tardanzas, A.Total_HrsWorked, A.Adelanto, A.Justifacion, A.EstadoAsis, A.Identificador
FROM            dbo.PERSONAL AS P INNER JOIN
                         dbo.ASISTENCIAPER AS A ON P.Id_Pernl = A.Id_Pernl
GO
/****** Object:  Table [dbo].[CONTRATO_PER]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTRATO_PER](
	[Id_Contrato] [nchar](8) NOT NULL,
	[Id_Pernl] [char](10) NOT NULL,
	[Fecha_EmiCon] [date] NOT NULL,
	[Fecha_Inicio] [date] NOT NULL,
	[Fecha_Cese] [date] NOT NULL,
	[Tipo_Contrato] [varchar](30) NOT NULL,
	[Days_toWork] [varchar](50) NULL,
	[Day_toRest] [varchar](30) NULL,
	[Has_Vacation] [char](2) NOT NULL,
	[Has_AsigFami] [char](2) NOT NULL,
	[Has_Gratifi] [char](2) NOT NULL,
	[Pay_5ta_Catg] [char](2) NOT NULL,
	[Sueldo_Fijo] [real] NULL,
	[Acept_Terms] [char](2) NOT NULL,
	[Estado_contrato] [varchar](30) NULL,
	[Id_Seg] [nchar](4) NOT NULL,
 CONSTRAINT [PK_Cont] PRIMARY KEY CLUSTERED 
(
	[Id_Contrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_BoletaPago]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_BoletaPago](
	[IdPago] [char](8) NOT NULL,
	[Id_Concepto] [char](4) NOT NULL,
	[Detalle_concepto] [varchar](100) NOT NULL,
	[Importe_Pago] [real] NOT NULL,
	[Tipo_Det] [varchar](18) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[Id_Empre] [nchar](4) NOT NULL,
	[Nombre_Empresa] [varchar](250) NOT NULL,
	[Direccion_Empre] [varchar](250) NOT NULL,
	[Nro_Ruc] [nchar](20) NOT NULL,
	[Nombre_Generete] [varchar](150) NOT NULL,
	[Fecha_Creac] [date] NULL,
 CONSTRAINT [PK_emp] PRIMARY KEY CLUSTERED 
(
	[Id_Empre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario](
	[Id_Hor] [nchar](4) NOT NULL,
	[HoEntrada] [datetime] NOT NULL,
	[MiTolrncia] [datetime] NULL,
	[HoLimite] [datetime] NULL,
	[HoSalida] [datetime] NULL,
 CONSTRAINT [PK_horario] PRIMARY KEY CLUSTERED 
(
	[Id_Hor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Planilla]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planilla](
	[Id_Plani] [nchar](8) NOT NULL,
	[Id_Pernl] [char](10) NOT NULL,
	[Nro_CussPP] [nchar](20) NULL,
	[Fecha_IngreTrabj] [date] NULL,
	[Asig_Familr] [char](2) NOT NULL,
	[Sueldo_Basic] [real] NOT NULL,
	[Impor_Asig_Famlr] [real] NOT NULL,
	[Total_Ext25] [real] NOT NULL,
	[Total_Ext35] [real] NOT NULL,
	[Total_ExtDble] [real] NOT NULL,
	[Vacaciones] [real] NOT NULL,
	[Gratifi] [real] NOT NULL,
	[Total_Sueldo_Bruto] [real] NOT NULL,
	[ONP] [real] NOT NULL,
	[ComisionAFP] [real] NULL,
	[PrimaAFP] [real] NULL,
	[AporteAFP] [real] NULL,
	[Rnta_5ta_Catg] [real] NOT NULL,
	[Adelanto] [real] NOT NULL,
	[Tardanza] [real] NOT NULL,
	[Dsct_Falta] [real] NOT NULL,
	[Total_Dscto] [real] NOT NULL,
	[Neto_Pagar] [real] NOT NULL,
	[Essalud] [real] NULL,
	[SCTR] [real] NULL,
	[Total_Aporta_Empldr] [real] NOT NULL,
	[Fecha_Plani] [date] NULL,
	[Periodo_Plani] [varchar](20) NULL,
	[Estado_Planilla] [varchar](20) NOT NULL,
	[Suma_Total_SBasic] [real] NOT NULL,
	[Suma_Total_SlBruto] [real] NOT NULL,
	[Suma_Total_Dscto] [real] NOT NULL,
	[Suma_Total_NetPagr] [real] NOT NULL,
	[Suma_Total_Aportes] [real] NOT NULL,
 CONSTRAINT [PK_plani] PRIMARY KEY CLUSTERED 
(
	[Id_Plani] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro_BoletaPago]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro_BoletaPago](
	[IdPago] [char](8) NOT NULL,
	[Id_Pernl] [char](10) NOT NULL,
	[NetoPagar] [real] NULL,
	[Total_Ingreso] [real] NOT NULL,
	[FechaP] [date] NOT NULL,
	[Total_Aporte] [real] NOT NULL,
	[Total_Dscto] [real] NOT NULL,
	[Inicio_Vaca] [varchar](15) NULL,
	[Fin_Vaca] [varchar](15) NULL,
	[Dias_Vaca] [varchar](2) NULL,
	[Dias_Worked] [char](4) NULL,
	[Hour_Ex25] [real] NOT NULL,
	[Hour_Ex35] [real] NOT NULL,
	[Days_NoWorked] [char](4) NULL,
	[Import_Ex25] [real] NOT NULL,
	[Import_Ex35] [real] NOT NULL,
 CONSTRAINT [PK_RegPago] PRIMARY KEY CLUSTERED 
(
	[IdPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguros]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguros](
	[Id_Seg] [nchar](4) NOT NULL,
	[Nombre_Seguro] [varchar](50) NULL,
	[Aporte_Obligtorio] [real] NULL,
	[Comision_RA] [real] NULL,
	[Prima_Seguro] [real] NULL,
 CONSTRAINT [PK_Sguro] PRIMARY KEY CLUSTERED 
(
	[Id_Seg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Temporal]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temporal](
	[Id_Tem] [int] IDENTITY(1,1) NOT NULL,
	[DniTem] [char](10) NULL,
	[Cod_Asis] [char](8) NOT NULL,
	[Fecha_Tem] [date] NULL,
	[Tipo] [varchar](30) NULL,
 CONSTRAINT [PK_Temp] PRIMARY KEY CLUSTERED 
(
	[Id_Tem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDoc]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDoc](
	[Idtipo] [int] NOT NULL,
	[NombreTipo] [varchar](50) NULL,
	[Serie] [varchar](2) NULL,
	[Numero_T] [varchar](5) NULL,
 CONSTRAINT [PK_TiD] PRIMARY KEY CLUSTERED 
(
	[Idtipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ASISTENCIAPER] ([Id_asis], [Id_Pernl], [FechaAsis], [Nombre_dia], [HoIngreso], [HoSalida], [Tardanzas], [Total_HrsWorked], [Adelanto], [Justifacion], [EstadoAsis], [Identificador]) VALUES (N'AS-00102', N'798-ant   ', CAST(N'2024-03-28' AS Date), N'Jueves', N'02:05:44', N'02:11:06', 0, 8, 0, N'Tardanza no Justificada', N'Asistio', N'No')
GO
INSERT [dbo].[Departamento] ([Id_Depto], [Depto]) VALUES (N'D-1       ', N'Oruro')
INSERT [dbo].[Departamento] ([Id_Depto], [Depto]) VALUES (N'D-2       ', N'La paz')
INSERT [dbo].[Departamento] ([Id_Depto], [Depto]) VALUES (N'D-3       ', N'Chuquisaca')
INSERT [dbo].[Departamento] ([Id_Depto], [Depto]) VALUES (N'D-4       ', N'Cochabamba')
INSERT [dbo].[Departamento] ([Id_Depto], [Depto]) VALUES (N'D-5       ', N'Santa Cruz')
GO
INSERT [dbo].[Horario] ([Id_Hor], [HoEntrada], [MiTolrncia], [HoLimite], [HoSalida]) VALUES (N'H001', CAST(N'2019-01-09T08:00:00.000' AS DateTime), CAST(N'2019-01-09T08:05:00.000' AS DateTime), CAST(N'2019-01-09T09:00:00.000' AS DateTime), CAST(N'2019-01-09T17:00:00.000' AS DateTime))
GO
INSERT [dbo].[Justificacion] ([Id_Justi], [Id_Pernl], [PrincipalMotivo], [Detalle_Justi], [FechaJusti], [EstadoJus], [FechaEmi]) VALUES (N'JC-00011', N'798-ant   ', N'Por Falta', N'Trafico', CAST(N'2024-03-28' AS Date), N'Falta Aprobar', CAST(N'2024-03-28' AS Date))
GO
INSERT [dbo].[PERSONAL] ([Id_Pernl], [DOC], [Nombre_Completo], [Fec_Naci], [Sexo], [Domicilio], [Correo], [Celular], [Id_rol], [Foto], [Id_Depto], [FinguerPrint], [Estado_Per]) VALUES (N'798-ant   ', N'7279828        ', N'Dante Lucas L', CAST(N'2024-03-28' AS Date), N'M', N'Perez', N'dante@gmail.com', N'72458989', N'1      ', N'D:\SistemaCompletos\SistemaAsistenciaHuellaDigital 3 2024\SisCoAsHuellaDigital\bin\Debug\user.png', N'D-1       ', 0x00F86801C82AE3735CC0413709AB7130F8145592E3BEE4D5EC70F24A3CD66F519F4A7DC6489B48F36BE8825C4EF20A0B41CACE025C68BCA577B8EC964985722CC0CD52D273BB1CF23762E1A1505823C686709439F288400B65C5D1BE55B96D43BE7B0B0C5CC90CDABDACAC4A4493317D967447EB1D886981A17AD50FADF2576CFA1FB117BD2F85207ED987A081E45B0E459FCBD14D0997C3820C380D65598496FAB0EF459B1B8E9DC67CFB2DA0D82E65E1EA87CFB790759263A3B496C3F5E73AC9FF2117D7CD32ADAC3C1E68A004D0DBC0C1F4E612B13D9023A32FA9E4ABF3FEE5CB66D9852CA16D0C6A20CC67469DCFDD122591877285344B34112F7B8000D35B1D473C00EA453029702CA1AF7689AE60E36C122FA89A7E2B2196DB8D43E808D8727F23519BBFA2A4072089AF8E02870712AA214AA1442F84F00EB207384CD495B5850CD7C484D1A44F6C5D4513B62864E223483C7991F080BA0846EC04DEE3C16C14206CB8552EAB52ACD16F00F87001C82AE3735CC0413709AB7130F214559235A264222D56E593F6109A65E9D49D7F3117A11813A725055E6056491AF57BFBF488E8AB25DA0F048434029541A70844446F52A08BEF8284F3E0F6A33AAD029AFFC6B1CB718969298DD6C6060979505E56DABBD9EC2008BD956C9244A10B7E38EB08528CD9EFF53D0739240133CEE6C40AA8BC20B50975FD27C3ACBA49D20B1BFB63207285457EF7AFDCC53014BFC7D648861277C86A4C0F33B4C2ADEAADA60DD42FA2184437D50C602F827450B498470156A899819B2AF73BE31BF3B585D7DA46FD754AF50494F4ABAFBC95E8A2F34F7264D9AE5D393AB85E9214DC0BE53C424CC4A9A36CE8882A6AB1AA8817C039F9A130DA15C2B2FF3FF056CB0698347F9F05F9D4A8BD6EC4479DD76AABF9EE29658B661DB66BE693767FFD8A08C49E1A1984514368AD087BA67D80E2B9EAD804C08B1BCC02909A348DB3DBAD967451F837EA2B218008636D2D9114E184A65648AA7A3EB8B2E909011E3FA9AD7435FD21296F00F86301C82AE3735CC0413709AB7130F314559267B193146E6EB79A53485B26DFC29F3E1F565C483545E8DEACE713C7BD5248DE5A1EDFF23681D806DE263BCB5F6414FE14250BCF21A5DC0BA8905583B0646CDF5F33A660224BAD5B00760062DAD9EFFC3DE7BE32A92C14FA7CF89210ED61B52C15C2458E2891B56823589617B7D3EB5A48298964EA35EF1805B06F1DEB640865AF73B3ADF3D6E7AEF2B5A5735B9AA86D675510E07E8BE424DF32295F55F830E34FD6E20016F7DEC52EF06A09E13374C78C5A25A345D7BECBD3ED02F93BAD23470FFEC467D74B2E4B536DA032F4D6755A345E0F09E6986CD439DE00BFBE3BE19077BFDE6A9B23A8DCEBC23B0500580AD713E2C3F95715111A32E87B597A7854FD5D7DFD99B4EABC3EF2E3797478C9C77FF6F1136DF72456C933B95F33CADF2D9E3767AB5CA8C07E0E6AA486D0BB17907E51F7374823DC3BFE68A8CEDCCA42A8E5B8687B1A1DF2D55A7E4DBECCC4FE0F8CD32C796F00E85F01C82AE3735CC0413709AB7170E71455927E0AE7F7DA882D42E3C44B9FFA9383871DB7EC897EBDF117773FC902DD02184FD23341A9416778073C8562B4F93F2CE0A46A3FEDDD3EB5CC398CF56F07297B8F55F99179119F64B7F11956A086E1AD5059C362C3B4353F6CAD03F278307B03E9E5AB60099CBB590E74062062BB851767E9588978CE51ECF038070BFD72F30434B60925B309D89069131DD76639B1FF7C955C5DBFC731F9BD305C2547FDF6760B14F5864AB11642FA8D08BC37191186C756F49C6FC031414907C2C16B6863D3E1A49F2BE696E154FDE58D0342FAA07BEFD7424569912537E67F6DC0404BDE88254AA631DE0D5202D150C5D2680DDF7599429BC1180EEA16325829D681A29C8549008B214E4D8F76AF89CB39BB60D9FFE3FBE915D018E796CEE3ACF4E6AFA381445E60D80779D3C986F745B3371AF00EA6408FFFBA93BBDBF9DFD936DCD544EABDAAA79E0DDDF78C6CA8999F9990241D6F00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, N'Activo')
GO
INSERT [dbo].[PUsuario] ([Id_Usu], [Nombre_Completo], [Avatar], [Nom_Usuario], [Password], [Estado_USu], [Id_Rol]) VALUES (N'1       ', N'Dante Lucas', N'D:\imagenes de diseño de form\erwin_085115.jpg', N'Admin', N'admin', N'Activo', N'1      ')
INSERT [dbo].[PUsuario] ([Id_Usu], [Nombre_Completo], [Avatar], [Nom_Usuario], [Password], [Estado_USu], [Id_Rol]) VALUES (N'US-00001', N'Nilk Mamani M', N'D:\SistemaCompletos\SistemaAsistenciaHuellaDigital 3 2024\SisCoAsHuellaDigital\bin\Debug\user.png', N'sa', N'123', N'Activo', N'2      ')
GO
INSERT [dbo].[ROL] ([Id_rol], [NomRol]) VALUES (N'1      ', N'Administrador')
INSERT [dbo].[ROL] ([Id_rol], [NomRol]) VALUES (N'2      ', N'Cajera')
INSERT [dbo].[ROL] ([Id_rol], [NomRol]) VALUES (N'3      ', N'Secretaria')
INSERT [dbo].[ROL] ([Id_rol], [NomRol]) VALUES (N'4      ', N'Jefe Personal')
GO
INSERT [dbo].[TipoDoc] ([Idtipo], [NombreTipo], [Serie], [Numero_T]) VALUES (1, N'Contrato', N'00', N'00001')
INSERT [dbo].[TipoDoc] ([Idtipo], [NombreTipo], [Serie], [Numero_T]) VALUES (2, N'Planilla', N'PL', N'00003')
INSERT [dbo].[TipoDoc] ([Idtipo], [NombreTipo], [Serie], [Numero_T]) VALUES (3, N'Asistencia', N'AS', N'00103')
INSERT [dbo].[TipoDoc] ([Idtipo], [NombreTipo], [Serie], [Numero_T]) VALUES (4, N'Justificacion', N'JC', N'00012')
INSERT [dbo].[TipoDoc] ([Idtipo], [NombreTipo], [Serie], [Numero_T]) VALUES (5, N'Activar Faltas', N'No', N'00001')
INSERT [dbo].[TipoDoc] ([Idtipo], [NombreTipo], [Serie], [Numero_T]) VALUES (6, N'Usuarios', N'US', N'00002')
GO
ALTER TABLE [dbo].[ASISTENCIAPER]  WITH CHECK ADD  CONSTRAINT [PK_prsnal3] FOREIGN KEY([Id_Pernl])
REFERENCES [dbo].[PERSONAL] ([Id_Pernl])
GO
ALTER TABLE [dbo].[ASISTENCIAPER] CHECK CONSTRAINT [PK_prsnal3]
GO
ALTER TABLE [dbo].[CONTRATO_PER]  WITH CHECK ADD  CONSTRAINT [PK_prsnal2] FOREIGN KEY([Id_Pernl])
REFERENCES [dbo].[PERSONAL] ([Id_Pernl])
GO
ALTER TABLE [dbo].[CONTRATO_PER] CHECK CONSTRAINT [PK_prsnal2]
GO
ALTER TABLE [dbo].[CONTRATO_PER]  WITH CHECK ADD  CONSTRAINT [PK_Segr] FOREIGN KEY([Id_Seg])
REFERENCES [dbo].[Seguros] ([Id_Seg])
GO
ALTER TABLE [dbo].[CONTRATO_PER] CHECK CONSTRAINT [PK_Segr]
GO
ALTER TABLE [dbo].[Justificacion]  WITH CHECK ADD  CONSTRAINT [PK_Jusper] FOREIGN KEY([Id_Pernl])
REFERENCES [dbo].[PERSONAL] ([Id_Pernl])
GO
ALTER TABLE [dbo].[Justificacion] CHECK CONSTRAINT [PK_Jusper]
GO
ALTER TABLE [dbo].[PERSONAL]  WITH CHECK ADD  CONSTRAINT [Pk_Dis1] FOREIGN KEY([Id_Depto])
REFERENCES [dbo].[Departamento] ([Id_Depto])
GO
ALTER TABLE [dbo].[PERSONAL] CHECK CONSTRAINT [Pk_Dis1]
GO
ALTER TABLE [dbo].[PERSONAL]  WITH CHECK ADD  CONSTRAINT [PK_rolss] FOREIGN KEY([Id_rol])
REFERENCES [dbo].[ROL] ([Id_rol])
GO
ALTER TABLE [dbo].[PERSONAL] CHECK CONSTRAINT [PK_rolss]
GO
ALTER TABLE [dbo].[Planilla]  WITH CHECK ADD  CONSTRAINT [PK_planiwork] FOREIGN KEY([Id_Pernl])
REFERENCES [dbo].[PERSONAL] ([Id_Pernl])
GO
ALTER TABLE [dbo].[Planilla] CHECK CONSTRAINT [PK_planiwork]
GO
ALTER TABLE [dbo].[PUsuario]  WITH CHECK ADD  CONSTRAINT [PK_usuRol] FOREIGN KEY([Id_Rol])
REFERENCES [dbo].[ROL] ([Id_rol])
GO
ALTER TABLE [dbo].[PUsuario] CHECK CONSTRAINT [PK_usuRol]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Activar_Desac_RobotFalta]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[Sp_Activar_Desac_RobotFalta]
@IdTipo int,
@serie varchar (2)
As
update TipoDoc 
Set Serie=@serie
Where
Idtipo =@IdTipo 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Actualiza_Tipo_Doc]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Sp_Actualiza_Tipo_Doc](
@Id_Tipo int
)
As

IF NOT EXISTS(SELECT * FROM TIPODOC
		WHERE IdTipo =@Id_Tipo)
	BEGIN		
		RETURN
	END

Begin
	Declare @NuevoNum char(5)
	Set @NuevoNum = dbo.Auto_Genera_Doc(@Id_Tipo)
End

BEGIN TRANSACTION

UPDATE TipoDoc  SET	
	Numero_T = @NuevoNum
WHERE 
	IdTipo=@Id_Tipo
	
IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[Sp_Actualizar_Distrito]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_Actualizar_Distrito]
(
@id_Dis char (7),
@Distrito varchar(50)
)
as
if not exists (select * from Distrito  where Id_Distrito = @id_Dis  )
begin
print 'El Municipio no existe'
return
end
begin tran
update Distrito  set 
Distrito = @Distrito  
where Id_Distrito   = @id_Dis  
if @@ERROR <> 0
begin
print @@error
rollback tran
return
end
commit tran
GO
/****** Object:  StoredProcedure [dbo].[Sp_Actualizar_FinguerPrint]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Actualizar_FinguerPrint] (
@IdPersona char (10),
@finguerPrint varbinary (2500)
)
As
update PERSONAL set
FinguerPrint =@finguerPrint 
where
Id_Pernl =@IdPersona
GO
/****** Object:  StoredProcedure [dbo].[Sp_Aprobar_Justificacion]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Aprobar_Justificacion] (
@IdJusti char (8),
@Id_Personal char (10)
)
As
Begin tran
Update Justificacion set
EstadoJus='Aprobado'
where
Id_Justi =@IdJusti and
Id_Pernl=@Id_Personal 
if @@ERROR <> 0
begin
print @@error
rollback tran
return
end
commit tran
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscar_Asistencia_paraExplorador]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Buscar_Asistencia_paraExplorador] (
@Id_Asis varchar (150)
)
As
Select * from Vista_Personal_Asistencia
where
Id_asis =@Id_Asis or
Id_Pernl=@Id_Asis or
DOC=@Id_Asis or

Nombre_Completo  like + '%'+ @Id_Asis or Nombre_Completo like + '%' + @Id_Asis + '%' or
Nombre_Completo like @Id_Asis + '%' 
order by FechaAsis asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscar_Asistencia_xPersona_Fechas]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[Sp_Buscar_Asistencia_xPersona_Fechas] (
@Id_Asis varchar (150),
@FechaIni date,
@FechaFin date
)
As
Select * from Vista_Personal_Asistencia
where
Id_Pernl=@Id_Asis and
FechaAsis between @FechaIni and @FechaFin
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscar_Asistencia_xPersona_Reporte]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Buscar_Asistencia_xPersona_Reporte] (
@Id_Asis varchar (150),
@FechaMes date
)
As
Select * from Vista_Personal_Asistencia
where
Id_Pernl=@Id_Asis and
DATEPART (YEAR,FechaAsis)= DATEPART (YEAR, @FechaMes) AND
DATEPART (MONTH,FechaAsis )= DATEPART (MONTH ,@FechaMes) 
--DATEPART (DAYOFYEAR,FechaAsis )= DATEPART (DAYOFYEAR,@FechaMes)
order by FechaAsis asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscar_Todos_Horarios]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Buscar_Todos_Horarios] 
As
Select * from Horario 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cargar_Asistencia_deldia]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Cargar_Asistencia_deldia]
@fecha date
as
Select *  from  Vista_Personal_Asistencia
where
DATEPART (YEAR,FechaAsis)= DATEPART (YEAR, @fecha ) AND
DATEPART (DAYOFYEAR,FechaAsis )= DATEPART (DAYOFYEAR,@fecha )
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cargar_Asistencia_xFecha]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Cargar_Asistencia_xFecha]
@fecha date
as
Select *  from  Vista_Personal_Asistencia
where
DATEPART (YEAR,FechaAsis)= DATEPART (YEAR, @fecha) AND
DATEPART (MONTH ,FechaAsis )= DATEPART (MONTH ,@fecha )
order by FechaAsis asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cargar_ContratoxDni]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Cargar_ContratoxDni]
@Dni char (10)
As
Select * from V_Contrato_Person_Inssure
where
DNIPR=@Dni 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cargar_Justificacion_xDoc]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Cargar_Justificacion_xDoc]
@Id_Personal varchar (150)
As
Select * from Personal_Justificacion
where 
Id_Pernl  = @Id_Personal  or
DOC=@Id_Personal or
Id_Justi=@Id_Personal or
Nombre_Completo  like + '%'+ @Id_Personal or Nombre_Completo like + '%' + @Id_Personal + '%' or
Nombre_Completo like @Id_Personal + '%' 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cargar_PersonalxDOC]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_Cargar_PersonalxDOC]
@DOC varchar (150)
As

select * from V_Vista_Personal 
where
DOC =@DOC or
Nombre_Completo  like + '%'+ @DOC or Nombre_Completo like + '%' + @DOC + '%' or
Nombre_Completo like @DOC + '%' or
Id_Pernl=@DOC or
NomRol=@DOC 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cargar_Temporal_xIdPersonal]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Cargar_Temporal_xIdPersonal]
@Id_Personal char (10)
As
Select * from Temporal
Where DniTem =@Id_Personal  and
DATEPART(YEAR, Fecha_Tem ) = DATEPART (YEAR, GETDATE()) AND
DATEPART (DAYOFYEAR,Fecha_Tem)= DATEPART (DAYOFYEAR,GETDATE()) and
Tipo ='Entrada'
 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cargar_Todas_Asistencias]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Cargar_Todas_Asistencias]
As
Select * from Vista_Personal_Asistencia
order by FechaAsis asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cargar_Todas_Justificaciones]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Cargar_Todas_Justificaciones]
as
Select * from Personal_Justificacion
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cargar_UsuarioxUSER]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_Cargar_UsuarioxUSER]
@USER varchar (150)
As

select * from PUsuario 
where
Nom_Usuario =@USER or
Nombre_Completo  like + '%'+ @USER or 
Nombre_Completo like + '%' + @USER + '%' or
Nombre_Completo like @USER + '%' or
Id_Usu=@USER or
Id_Rol=@USER 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Asistencia]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Delete_Asistencia] (
@Id_Asis char (8)
)
As
Delete from ASISTENCIAPER 
where
Id_asis =@Id_Asis 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Deal]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Delete_Deal] (
@Id_Per char (10)
)
AS
Delete from CONTRATO_PER 
Where 
Id_Pernl =@Id_Per 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Justificacion]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Delete_Justificacion] 
@Id_Justi char (8)
As
Delete from Justificacion 
Where
Id_Justi =@Id_Justi 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_rol]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--4
Create Proc [dbo].[Sp_Delete_rol]
(
@Id_Rol char (7)
)
As
Delete from ROL 
where
Id_rol =@Id_Rol 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Temp]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Delete_Temp]
@Id_Personal char (10)
As
Delete from Temporal
Where 
DniTem =@Id_Personal and
DATEPART(YEAR, Fecha_Tem ) = DATEPART (YEAR, GETDATE()) AND
DATEPART (DAYOFYEAR,Fecha_Tem)= DATEPART (DAYOFYEAR,GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[Sp_Desaprobar_Justificacion]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Desaprobar_Justificacion] (
@IdJusti char (8),
@Id_Personal char (10)
)
As
Begin tran
Update Justificacion set
EstadoJus='Falta Aprobar'
where
Id_Justi =@IdJusti and
Id_Pernl=@Id_Personal 
if @@ERROR <> 0
begin
print @@error
rollback tran
return
end
commit tran
GO
/****** Object:  StoredProcedure [dbo].[Sp_Edit_Rol]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--2
Create Proc [dbo].[Sp_Edit_Rol] (
@Id_rol char (7),
@NomRol varchar (50)
)
As
Update ROL set
NomRol =@NomRol 
where
Id_rol =  @Id_rol 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Eliminar_Distrito]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Eliminar_Distrito]
(
@Id_Depto  char (7)
)
as
delete from Departamento 
where
Id_Depto =@Id_Depto 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Eliminar_Personal]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[Sp_Eliminar_Personal]
(
@DOC char (10)
)
as
if not exists (select * from PERSONAL  where DOC =@DOC  )
begin
print 'El id ingresado no existe'
return
end
begin tran
update PERSONAL   set
Estado_Per   = 'Eliminado'
where 
DOC =@DOC  
if @@ERROR <> 0
begin
print @@error
rollback tran
return
end
commit tran
GO
/****** Object:  StoredProcedure [dbo].[Sp_Eliminar_Usuario]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[Sp_Eliminar_Usuario]
(
@Id_Usu char (10)
)
as
if not exists (select * from PUsuario  where Id_Usu =@Id_Usu )
begin
print 'El id ingresado no existe'
return
end
begin tran
update PUsuario   set
Estado_USu   = 'Eliminado'
where 
Id_Usu =@Id_Usu  
if @@ERROR <> 0
begin
print @@error
rollback tran
return
end
commit tran
GO
/****** Object:  StoredProcedure [dbo].[Sp_Filtrar_Personal_XNombre]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Filtrar_Personal_XNombre]
@Name varchar (50)
As
select * from V_Vista_Personal 
where
Nombre_Completo  like @Name +'%'
GO
/****** Object:  StoredProcedure [dbo].[Sp_ingresar_Distrito]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_ingresar_Distrito]
(
@Id_Distrito char (7),
@Distrito nvarchar(50)
)	
as
begin tran 
insert into Distrito (Id_Distrito , Distrito )
values
(
@Id_Distrito ,
@Distrito 
)
if @@ERROR <> 0
begin
print @@error
rollback tran
return
end
commit tran
GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_Justification]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Insert_Justification] (
@Id_Justi char (8),
@Id_Personal char (10),
@Principalmoti nvarchar (50),
@Detalle nvarchar (max),
@FechaJusti date
)
As
Insert Into Justificacion 
values (
@Id_Justi,
@Id_Personal  ,
@Principalmoti ,
@Detalle ,
@FechaJusti ,
'Falta Aprobar',
getdate()
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_Personal]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Insert_Personal] (
@Id_Person char (10),
@DOC char (15),
@nombreComplto varchar (50),
@FechaNacmnto Date,
@Sexo char (1),
@Domicilio nvarchar (120),
@Correo varchar (50),
@Celular varchar (9),
@Id_rol char (7),
@Foto nvarchar (max),
@Id_Depto char (7)
)
As
Begin Tran
Insert Into PERSONAL  (id_Pernl,DOC ,Nombre_Completo, Fec_Naci, Sexo,Domicilio ,Correo,Celular,Id_rol,Foto,Id_Depto,FinguerPrint, Estado_Per )
Values
(
@Id_Person ,
@DOC,
@nombreComplto ,
@FechaNacmnto ,
@Sexo,
@Domicilio,
@Correo,
@Celular,
@Id_rol,
@Foto ,
@Id_Depto,
0,
'Activo'
)
if @@ERROR <> 0
begin
print @@error
rollback tran
return
end
commit tran
GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_Rol]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--1
Create Proc [dbo].[Sp_Insert_Rol] (
@Id_rol char (7),
@NomRol varchar (50)
)
As
Insert Into ROL 
Values (
@Id_rol,
@NomRol 
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_Temp]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Insert_Temp] (
@Id_Personal char (10),
@Id_ASis char (8),
@TipoTem varchar (30)
)
As
Insert Into Temporal 
values
(
@Id_Personal  ,
@Id_ASis ,
GetDate(),
@TipoTem 
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_Usuario]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Insert_Usuario] (
@Id_Usu char (10),
@nombreComplto varchar (150),
@Avatar nvarchar (max),
@NomUsuario varchar (20),
@Password nvarchar (12),
@Id_rol char (7)
)

As

Insert Into PUsuario(Id_Usu,Nombre_Completo,Avatar,Nom_Usuario,Password,Estado_USu,Id_Rol)
Values
(
@Id_Usu,
@nombreComplto,
@Avatar,
@NomUsuario,
@Password,
'Activo',
@Id_rol
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Leer_asistencia_reciente]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Leer_asistencia_reciente]
@idper char (10)
As
select  *  from ASISTENCIAPER
where
Id_Pernl =@idper and
Datepart (year,FechaAsis)=Datepart (year,getdate()) and
Datepart (dayofYear,FechaAsis)=Datepart (dayofyear,getdate()) and
EstadoAsis ='Entrada'
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listado_Tipo]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Sp_Listado_Tipo]
	@Id_Tipo as Int	
AS
	Select Serie + '-' + Numero_t as Nro from TipoDoc 
	Where IdTipo=@Id_Tipo
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listado_TipoFalta]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Sp_Listado_TipoFalta]
	@Id_Tipo as Int	
AS
	Select Serie from TipoDoc 
	Where IdTipo=@Id_Tipo
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_Personal]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[SP_Listar_Personal]
  AS
 Select *
  From V_Vista_Personal
 Where Estado_Per ='Activo'
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Seguro_xId]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Listar_Seguro_xId]
@Id_Seg nchar (4)
as
Select * from Seguros 
where
Id_Seg = @Id_Seg 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Todos_Seguros]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Listar_Todos_Seguros] 
As
Select * from Seguros 
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_Usuario]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE Proc [dbo].[SP_Listar_Usuario]
  AS
 Select *
  From V_Usuarios_Roles
 Where Estado_USu ='Activo'
GO
/****** Object:  StoredProcedure [dbo].[Sp_Load_All_rol]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--3
Create Proc [dbo].[Sp_Load_All_rol] 
As
Select * from ROL
GO
/****** Object:  StoredProcedure [dbo].[Sp_Login]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Sp_Login]
@Usuario nvarchar(20),
@Contraseña nvarchar(12)
As
	Select Count(*)from PUsuario 
	Where Nom_Usuario =@Usuario and Password =@Contraseña
GO
/****** Object:  StoredProcedure [dbo].[Sp_Modificar_Contrato]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Modificar_Contrato] (
@IdContra char (8),
@Id_Pers char (10),
@Fecha_emi Date,
@FechaIni date,
@FechaFin date,
@TipoContra nchar (30),
@Days_toWork char (50),
@Day_toRest char (30),
@Has_Vacation char (2),
@Has_AsigFami char (2),
@Has_Gratifi char (2),
@Pay_5ta_Catg char (2),
@Sueldo_Fijo Real,
@Acept_Terms char (2),
@Estado_contrato char (30),
@Id_Seg nchar (4)
)
As
Update CONTRATO_PER set
Id_Pernl  =@Id_Pers ,
--fecha
Fecha_Inicio = @FechaIni ,
Fecha_Cese=@FechaFin ,
Tipo_Contrato = @TipoContra ,
Days_toWork = @Days_toWork ,
Day_toRest=@Day_toRest ,
Has_Vacation=@Has_Vacation ,
Has_AsigFami=@Has_AsigFami ,
Has_Gratifi=@Has_Gratifi ,
Pay_5ta_Catg=@Pay_5ta_Catg ,
Sueldo_Fijo=@Sueldo_Fijo ,
Acept_Terms=@Acept_Terms ,
Estado_contrato=@Estado_contrato ,
Id_Seg=@Id_Seg 
where
Id_Contrato =@IdContra 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Modificar_justificacion]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Modificar_justificacion] (
@Id_Justi char (8),
@Id_Personal char (10),
@Principalmoti nvarchar (50),
@Detalle nvarchar (max),
@FechaJusti date
)
As
update Justificacion set
Id_Pernl =@Id_Personal ,
PrincipalMotivo =@Principalmoti ,
Detalle_Justi =@Detalle ,
FechaJusti =@FechaJusti 
where
Id_Justi =@Id_Justi 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Modificar_Seguro]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Modificar_Seguro]
(
@Id_Seg nchar (4) ,
@Nombre_Seg varchar (50),
@Aporte_Comi Real,
@Comision Real,
@Prima_Seg Real
)
as
Begin Tran
Update Seguros Set
Nombre_Seguro =@Nombre_Seg ,
Aporte_Obligtorio =@Aporte_Comi ,
Comision_RA = @Comision ,
Prima_Seguro = @Prima_Seg
where
Id_Seg =@Id_Seg 
IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[Sp_Registrar_Adelanto]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Registrar_Adelanto] (
@IdAsis char (8),
@Id_Personal char (10),
@Adelanto Real
)
As
if not exists (select * from ASISTENCIAPER
where Id_asis=@IdAsis)
    begin 
    return 
    end
begin transaction
Update ASISTENCIAPER set
Adelanto =@Adelanto 
where
Id_asis =@IdAsis  and Id_Pernl  =@Id_Personal  
if @@error <>0
begin
print @@error
rollback tran
return
end
 commit tran
GO
/****** Object:  StoredProcedure [dbo].[Sp_Registrar_Contrato]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Registrar_Contrato] (
@IdContra char (8),
@Id_Pers char (10),
@Fecha_emi Date,
@FechaIni date,
@FechaFin date,
@TipoContra nchar (30),
@Days_toWork char (50),
@Day_toRest char (30),
@Has_Vacation char (2),
@Has_AsigFami char (2),
@Has_Gratifi char (2),
@Pay_5ta_Catg char (2),
@Sueldo_Fijo Real,
@Acept_Terms char (2),
@Estado_contrato char (30),
@Id_Seg nchar (4)

)
As
insert into CONTRATO_PER values
(
@IdContra ,
@Id_Pers  ,
@Fecha_emi ,
@FechaIni ,
@FechaFin ,
@TipoContra ,
@Days_toWork ,
@Day_toRest ,
@Has_Vacation ,
@Has_AsigFami ,
@Has_Gratifi ,
@Pay_5ta_Catg ,
@Sueldo_Fijo ,
@Acept_Terms ,
@Estado_contrato ,
@Id_Seg 
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Registrar_Entrada]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[Sp_Registrar_Entrada] (
@IdAsis char (8),
@Id_Persol char (10),
--FECHA
--NOMDIA
@Hoingre varchar (10),
@tardanza Real,
@TotalHora Int,
@justificado nvarchar (max)
)
As
Insert Into ASISTENCIAPER values 
(
@IdAsis ,
@Id_Persol  ,
GETDATE (),
DATENAME (dw,getdate()),
@Hoingre ,
'00:00:00',  --hora de salisa
@tardanza , 
@TotalHora , --total de horas trabajas
'00',  --adelanto
@justificado , --
'Entrada',
'No'
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Registrar_Falta]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Registrar_Falta] (
@IdAsis char (8),
@Id_Personal char (10),
@justificacion nvarchar (max)
)
As
Insert Into ASISTENCIAPER values 
(
@IdAsis ,
@Id_Personal  ,
GETDATE (),
DATENAME (dw,getdate()),
'00:00:00' ,  --hora ingreso
'00:00:00', --hora de salida
'00', --tardnza
'00' , --total hroas trabahjadas
'00', --adelanto
@justificacion ,
'Falta',  --Estado
'No' --identificador
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Registrar_Salida]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Registrar_Salida] (
@IdAsis char (8),
@Id_Personal char (10),
@HoSalida varchar (10),
@TotalHora Real
)
As
if not exists (select * from ASISTENCIAPER
where Id_asis=@IdAsis)
    begin 
    return 
    end
begin transaction
Update ASISTENCIAPER set
Id_Pernl  = @Id_Personal  ,
HoSalida =@HoSalida ,
Total_Hrsworked = @TotalHora ,
EstadoAsis ='Asistio'
where
Id_asis =@IdAsis 
if @@error <>0
begin
print @@error
rollback tran
return
end
 commit tran
GO
/****** Object:  StoredProcedure [dbo].[Sp_Registrar_Seguros]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Registrar_Seguros] (
@Id_Seg nchar (4) ,
@Nombre_Seg varchar (50),
@Aporte_Comi Real,
@Comision Real,
@Prima_Seg Real
)
as
begin tran
Insert Into Seguros values (
@Id_Seg ,
@Nombre_Seg ,
@Aporte_Comi ,
@Comision ,
@Prima_Seg )
IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[Sp_Update_Horario]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Update_Horario] (
@Idhor nchar (4),
@HoEntrada datetime,
@HoTolere datetime,
@Holimite datetime,
@HoraSalida datetime
)
As
BEGIN TRANSACTION
update Horario set
HoEntrada =@HoEntrada ,
MiTolrncia  =@HoTolere ,
HoLimite =@Holimite ,
HoSalida =@HoraSalida 
where
Id_Hor = @Idhor 
IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[Sp_Update_Personal]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Update_Personal] (
@Id_Person char (10),
@DOC char (15),
@nombreComplto varchar (150),
@FechaNacmnto Date,
@Sexo char (1),
@Domicilio nvarchar (120),
@Correo varchar (50),
@Celular varchar (10),
@Id_rol char (7),
@Foto nvarchar (200),
@Id_Depto char (7)
)
AS
UPDATE PERSONAL
SET
DOC = @DOC ,
Nombre_Completo  =@nombreComplto  ,
Fec_Naci  =@FechaNacmnto ,
Sexo =@Sexo ,
Domicilio  =@Domicilio ,
Correo  =@Correo ,
Celular  =@Celular ,
Id_rol=@Id_rol ,
Foto =@Foto ,
Id_Depto =@Id_Depto ,
Estado_Per  = 'Activo'

Where
Id_Pernl=@Id_Person 

GO
/****** Object:  StoredProcedure [dbo].[Sp_Update_Usuario]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Update_Usuario] (
@Id_Usu char (10),
@nombreComplto varchar (150),
@Avatar nvarchar (250),
@Nom_Usuario nvarchar (50),
@Password nvarchar (120),
@Id_rol char (7)

)
AS
UPDATE PUsuario
SET
Nombre_Completo  =@nombreComplto,
Avatar  =@Avatar,
Nom_Usuario =@Nom_Usuario,
Password  =@Password ,
Estado_USu  = 'Activo',
Id_rol=@Id_rol 

Where
Id_Usu=@Id_Usu 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Usuario_Login]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Sp_Usuario_Login](
	@Usuario nvarchar(50)=''
)
As
	Select * from V_Usuarios_Roles
	Where
	Nom_Usuario=@Usuario and Estado_usu = 'Activo'
GO
/****** Object:  StoredProcedure [dbo].[Sp_Validar_DOC]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[Sp_Validar_DOC]
@DOC char (8)
as
select count( *) from PERSONAL 
Where DOC =@DOC 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Validar_No_Tener2Contrato]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Validar_No_Tener2Contrato]
@Id_Pernl char (10)
As
select COUNT (*) from CONTRATO_PER 
where
Id_Pernl=@Id_Pernl 
and 
Estado_contrato='Activo' and
Getdate() between Fecha_Inicio and Fecha_Cese 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Validar_RegistroAsistencia]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Validar_RegistroAsistencia]
@Id_Personal char (10)
as
Select COUNT (*) from ASISTENCIAPER 
where
Id_Pernl  =@Id_Personal  and EstadoAsis  ='Asistio' and
DATEPART (YEAR,FechaAsis)= DATEPART (YEAR, GETDATE()) AND
DATEPART (DAYOFYEAR,FechaAsis )= DATEPART (DAYOFYEAR,GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[Sp_Validar_USUARIO]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Validar_USUARIO]
@Nom_Usuario char (20)
as
select count( *) from PUsuario 
Where Nom_Usuario =@Nom_Usuario
GO
/****** Object:  StoredProcedure [dbo].[Sp_Ver_sihay_Registro]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Ver_sihay_Registro]
@Id_Personal char (10)
As
Select COUNT (*) from ASISTENCIAPER 
where
Id_Pernl=@Id_Personal  and
DATEPART (YEAR,FechaAsis)= DATEPART (YEAR, GETDATE()) AND
DATEPART (DAYOFYEAR,FechaAsis )= DATEPART (DAYOFYEAR,GETDATE()) 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Ver_Todo_Depto]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_Ver_Todo_Depto]
as
select * from Departamento   
GO
/****** Object:  StoredProcedure [dbo].[Sp_Ver_Todo_Distrito]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_Ver_Todo_Distrito]
as
select * from Distrito   
GO
/****** Object:  StoredProcedure [dbo].[Sp_Verificar_IfExist_Justifi]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Verificar_IfExist_Justifi] (
@Id_Personal char (10),
@Fecha date
)
As
Select COUNT ( *) from Justificacion 
Where
Id_Pernl =@Id_Personal and
DATEPART (YEAR,FechaJusti )= DATEPART (year,@Fecha) and
DATEPART (Dayofyear, FechaJusti)= DATEPART (dayofyear,@Fecha)
GO
/****** Object:  StoredProcedure [dbo].[Sp_verificar_IngresoAsis]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_verificar_IngresoAsis]
@Id_Personal char (10)
As
Select COUNT (*) from ASISTENCIAPER 
where
Id_Pernl  =@Id_Personal  and EstadoAsis  ='Entrada' and
DATEPART (YEAR,FechaAsis)= DATEPART (YEAR, GETDATE()) AND
DATEPART (DAYOFYEAR,FechaAsis )= DATEPART (DAYOFYEAR,GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[Sp_Verificar_siMarco_Falta]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Verificar_siMarco_Falta]
@Id_Personal char (10)
as
Select COUNT (*) from ASISTENCIAPER 
where
Id_Pernl  =@Id_Personal  and
EstadoAsis ='Falta' and
DATEPART (YEAR,FechaAsis)= DATEPART (YEAR, GETDATE()) AND
DATEPART (DAYOFYEAR,FechaAsis )= DATEPART (DAYOFYEAR,GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[SP_VerificarJustificacion_Aprobada]    Script Date: 28/03/2024 2:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[SP_VerificarJustificacion_Aprobada] (
@Id_Personal char (10)
)
As
Select COUNT (*) from Justificacion 
where
Id_Pernl  =@Id_Personal  and
DATEPART (YEAR,FechaJusti )= DATEPART (YEAR, GETDATE()) AND
DATEPART (DAYOFYEAR,FechaJusti  )= DATEPART (DAYOFYEAR,GETDATE()) and 
EstadoJus ='Aprobado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[31] 2[10] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "J"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "P"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Personal_Justificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Personal_Justificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "P"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 211
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "D"
            Begin Extent = 
               Top = 6
               Left = 285
               Bottom = 124
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "R"
            Begin Extent = 
               Top = 6
               Left = 532
               Bottom = 176
               Right = 741
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Vista_Personal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Vista_Personal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "P"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 196
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "A"
            Begin Extent = 
               Top = 28
               Left = 489
               Bottom = 331
               Right = 698
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_Personal_Asistencia'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_Personal_Asistencia'
GO
USE [master]
GO
ALTER DATABASE [BDAsistenciaHuellaDigital] SET  READ_WRITE 
GO
