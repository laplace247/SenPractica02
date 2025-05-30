USE [Senati]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dni] [varchar](8) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uc_DNI] UNIQUE NONCLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instructor]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dni] [varchar](8) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[edad] [varchar](50) NOT NULL,
	[curso] [varchar](50) NOT NULL,
	[genero] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[contrasenia] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[buscarAlumnoByTipoAndParametro]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarAlumnoByTipoAndParametro] 
(
	@Tipo int,
    @Parametro varchar(50)
)   
AS  
BEGIN  
    
    SET NOCOUNT ON;

	-- DNI
	IF @Tipo = 1  
    BEGIN
		SELECT * FROM Alumno WHERE dni LIKE '%'+@Parametro+'%' ORDER BY id DESC;
	END
    IF @Tipo = 2  
    BEGIN
		SELECT * FROM Alumno WHERE nombres LIKE '%'+@Parametro+'%' ORDER BY id DESC;
	END
	IF @Tipo = 3  
    BEGIN
		SELECT * FROM Alumno WHERE apellidos LIKE '%'+@Parametro+'%' ORDER BY id DESC;
	END

END  

GO
/****** Object:  StoredProcedure [dbo].[buscarInstructorByTipoAndParametro]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[buscarInstructorByTipoAndParametro] 
	-- Add the parameters for the stored procedure here
	@Tipo int,
    @Parametro varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- DNI
	IF @Tipo = 1  
    BEGIN
		SELECT * FROM Instructor WHERE dni LIKE '%'+@Parametro+'%' ORDER BY id DESC;
	END
    IF @Tipo = 2  
    BEGIN
		SELECT * FROM Instructor WHERE nombres LIKE '%'+@Parametro+'%' ORDER BY id DESC;
	END
	IF @Tipo = 3  
    BEGIN
		SELECT * FROM Instructor WHERE apellidos LIKE '%'+@Parametro+'%' ORDER BY id DESC;
	END
	IF @Tipo = 4  
    BEGIN
		SELECT * FROM Instructor WHERE edad LIKE '%'+@Parametro+'%' ORDER BY id DESC;
	END
	IF @Tipo = 5  
    BEGIN
		SELECT * FROM Instructor WHERE curso LIKE '%'+@Parametro+'%' ORDER BY id DESC;
	END
	IF @Tipo = 6
    BEGIN
		SELECT * FROM Instructor WHERE genero LIKE '%'+@Parametro+'%' ORDER BY id DESC;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[editarAlumno]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editarAlumno] 
	-- Add the parameters for the stored procedure here
	@Id int,
	@Dni varchar(8),
    @Nombres varchar(50),
    @Apellidos varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	UPDATE Alumno SET dni =@Dni , nombres = @Nombres,apellidos=@Apellidos WHERE id=@Id
END

GO
/****** Object:  StoredProcedure [dbo].[editarInstructor]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editarInstructor]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Dni varchar(8),
    @Nombres varchar(50),
    @Apellidos varchar(50),
	@Edad varchar(50),
	@Curso varchar(50),
	@Genero varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	UPDATE Instructor SET dni =@Dni , nombres = @Nombres,apellidos=@Apellidos,edad=@Edad,curso=@Curso,genero=@Genero WHERE id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[eliminarAlumno]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminarAlumno]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	DELETE FROM Alumno WHERE id=@Id;
END

GO
/****** Object:  StoredProcedure [dbo].[eliminarInstructor]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[eliminarInstructor] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here

END
GO
/****** Object:  StoredProcedure [dbo].[insertarAlumno]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--PROCEDIMIENTOS ALMACENADOS
CREATE PROCEDURE [dbo].[insertarAlumno] 
(
    @Dni varchar(8),
    @Nombres varchar(50),
    @Apellidos varchar(50)
)   
AS  
BEGIN  
    
    SET NOCOUNT OFF;

    INSERT INTO Alumno VALUES(@Dni,@Nombres,@Apellidos)

END

GO
/****** Object:  StoredProcedure [dbo].[insertarInstructor]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insertarInstructor] 
	-- Add the parameters for the stored procedure here
	@Dni varchar(8),
    @Nombres varchar(50),
    @Apellidos varchar(50),
	@Edad varchar(50),
	@Curso varchar(50),
	@Genero varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	INSERT INTO Alumno VALUES(@Dni,@Nombres,@Apellidos)
END
GO
/****** Object:  StoredProcedure [dbo].[Logeo]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Logeo]
(
    @Usuario varchar(20),
    @Contrasenia varchar(20)
)    
AS  
BEGIN  
    
    SET NOCOUNT ON;

    SELECT *  FROM Usuario WHERE usuario=@Usuario and contrasenia=@Contrasenia

END

GO
/****** Object:  StoredProcedure [dbo].[obtenerTodosAlumnos]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[obtenerTodosAlumnos]    
AS  
BEGIN  
    
    SET NOCOUNT ON;

    SELECT * from Alumno ORDER BY id DESC;

END  

GO
/****** Object:  StoredProcedure [dbo].[obtenerTodosInstructores]    Script Date: 02/10/2023 02:29:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[obtenerTodosInstructores]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    SELECT * from Instructor ORDER BY id DESC;
END
GO
