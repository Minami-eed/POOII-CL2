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