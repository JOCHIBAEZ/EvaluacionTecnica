CREATE DATABASE EvaluacionTecnicaDB;

USE EvaluacionTecnicaDB;

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY,
    RoleId INT,
    Nombre NVARCHAR(100),
    Apellido NVARCHAR(100),
    Cedula NVARCHAR(11),
    Usuario_Nombre NVARCHAR(100),
    Contraseña NVARCHAR(100),
    Fecha_Nacimiento DATETIME,
    Usuario_Transaccion NVARCHAR(100) DEFAULT 'USER',
    Fecha_Transaccion DATETIME DEFAULT GETDATE()
);

CREATE UNIQUE INDEX IX_Usuarios_Cedula ON Usuarios (Cedula);
CREATE UNIQUE INDEX IX_Usuarios_Usuario_Nombre ON Usuarios (Usuario_Nombre);
CREATE INDEX IX_Usuarios_Fecha_Nacimiento ON Usuarios (Fecha_Nacimiento);

USE EvaluacionTecnicaDB;

CREATE TABLE Roles (
    Id INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Usuario_Transaccion NVARCHAR(100) DEFAULT 'USER',
    Fecha_Transaccion DATETIME DEFAULT GETDATE()
);

CREATE UNIQUE INDEX IX_Roles_Nombre ON Roles (Nombre);

-- Script para insertar registros en la tabla Roles
INSERT INTO Rols (Id, Nombre)
VALUES (1, 'ADMIN'),
       (2, 'DESARROLLADOR');

-- Script para insertar registros en la tabla Usuarios
INSERT INTO Usuarios (Id, RoleId, Nombre, Apellido, Usuario_Nombre, Contraseña, Cedula, Fecha_Nacimiento)
VALUES (1, 1, 'Simetrica', 'Consulting', 'ADMIN', 'ADMIN', '25322522135', '1990-01-01'),
       (2, 2, 'JOSUE', 'Consulting', 'DESARROLLADOR', 'APLICANTE', '00000000000', '2000-02-25');
