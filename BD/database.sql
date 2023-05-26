use master;
GO

CREATE DATABASE POOCL2;
GO

USE POOCL2
GO

CREATE TABLE Producto(
	id INT IDENTITY(1,1) PRIMARY KEY,
	nombre varchar(50),
	tipo INT,
	precio DECIMAL(10,2),
	fecha DATE
);
GO

INSERT INTO Producto (nombre, tipo, precio, fecha)
VALUES
   ('teclado', 1, 40.00, '2023-01-01'),
   ('mouse', 1, 35.00, '2022-07-28'),
   ('monitor', 1, 200.00, '2023-12-24'),
   ('memoria', 2, 120.00, '2023-10-08'),
   ('impresora', 1, 300.00, '2022-05-01'),
   ('procesador', 2, 800.00, '2023.07.29'),
   ('parlantes', 1, 180.00, '2023-06-07'),
   ('tarjeta de red', 2, 150.00, '2022-12-31'),
   ('microfono', 1, 60.00, '2022-06-24'),
   ('disco duro', 2, 350.00, '2022-08-30');
Go

CREATE or ALTER PROCEDURE usp_productos_por_año
    @año INT
AS
BEGIN
    SELECT id, nombre, tipo, precio, CONVERT(date, fecha) AS fecha
    FROM Producto
    WHERE YEAR(fecha) = @año;
END
GO

exec usp_productos_por_año @año = 2023;

CREATE or ALTER PROCEDURE usp_crear
    @nombre varchar(50),
    @tipo int,
    @precio decimal(10, 2),
    @fecha date
AS
BEGIN
    INSERT INTO Producto (nombre, tipo, precio, fecha)
    VALUES (@nombre, @tipo, @precio, CONVERT(date, @fecha));
END
GO

CREATE OR ALTER PROCEDURE usp_actualizar
    @id INT,
    @nombre NVARCHAR(100),
    @idTipo INT,
    @precio DECIMAL(10, 2),
    @fecha DATE
AS
BEGIN
    UPDATE Producto
    SET nombre = @nombre,
        tipo = @idTipo,
        precio = @precio,
        fecha = @fecha
    WHERE id = @id
END


CREATE PROCEDURE usp_obtener_producto_por_id
    @id INT
AS
BEGIN
    SELECT id, nombre, tipo, precio, fecha
    FROM Producto
    WHERE id = @id
END
GO

SELECT * FROM Producto;