USE MASTER;
GO


-- Crear la base de datos nuevamente
CREATE DATABASE DB_VOTACION;
GO

-- Usar la base de datos correcta antes de crear la tabla
USE DB_VOTACION;
GO

-- Crear la tabla TB_USUARIOS con más espacio en NOMBRE
CREATE TABLE TB_USUARIOS (
    ID INT IDENTITY (1001,1) PRIMARY KEY,
    NOMBRE VARCHAR(50), -- Aumenté de 30 a 50 caracteres para evitar truncado
    DESCRIPCION VARCHAR(150), -- Aumenté para evitar problemas con descripciones largas
    GRADO NUMERIC
);
GO

-- Insertar datos corregidos
INSERT INTO TB_USUARIOS (NOMBRE, DESCRIPCION, GRADO) VALUES
('Juan Perez', 'Estudiante de primer grado', 1),
('Mari Gil', 'Estudiante de segundo grado', 2),
('Pedro Perez', 'Estudiante de primer año de bachillerato en comercio', 1); -- "ano" corregido a "año"
GO

-- Verificar si la tabla se creó correctamente
SELECT * FROM TB_USUARIOS;
GO
ALTER TABLE TB_USUARIOS
ADD Cartnet NVARCHAR(100) UNIQUE
;

DROP TABLE IF EXISTS Usuarios;
USE DB_VOTACION;
GO
CREATE TABLE Usuario(
    ID INT PRIMARY KEY IDENTITY(1,1),  -- ID autoincrementable
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Grado NVARCHAR(50),
    Cartnet NVARCHAR(100) UNIQUE NOT NULL  -- Campo para logueo, debe ser único
);