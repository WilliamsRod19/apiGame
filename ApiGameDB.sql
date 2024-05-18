CREATE DATABASE apiGameDB
GO

USE apiGameDB
GO

-- Tabla Desarrolladores (Developers)
CREATE TABLE Developers (
    DeveloperID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    DeveloperName VARCHAR(100) NOT NULL,
    DeveloperCountry VARCHAR(50)
);
GO

-- Tabla Categorias (Categories)
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    CategoryName VARCHAR(50) NOT NULL
);
GO

-- Tabla Juegos (Games)
CREATE TABLE Games (
    GameID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    GameName VARCHAR(100) NOT NULL,
    GameDescription VARCHAR(255),
    GameReleaseDate DATE,
    GamePrice MONEY,
    GameDeveloperID INT FOREIGN KEY REFERENCES Developers(DeveloperID),
    GameCategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID)
);
GO

-- Registros Developers
INSERT INTO Developers (DeveloperName, DeveloperCountry)
VALUES ('Rockstar Games', 'Estados Unidos');
INSERT INTO Developers (DeveloperName, DeveloperCountry)
VALUES ('Naughty Dog', 'Estados Unidos');
GO

-- Registros Categories
INSERT INTO Categories (CategoryName)
VALUES ('Acción');
INSERT INTO Categories (CategoryName)
VALUES ('Aventura');
GO

-- Registros Games
INSERT INTO Games
VALUES ('Grand Theft Auto V', 'Juego de acción y aventura en mundo abierto', '2013-09-17', 59.99, 1, 1);
INSERT INTO Games
VALUES ('Uncharted 4: A Thiefs End', 'Aventura de acción y plataformas', '2016-05-10', 49.99, 2, 2);
GO

-------------------------------- STORES PROCEDURES -------------------------------- 

-- Procedimiento almacenado para insertar una nueva categoría
CREATE OR ALTER PROCEDURE spCategories_Insert
    @CategoryName VARCHAR(50)
AS
BEGIN
    INSERT INTO Categories (CategoryName)
    VALUES (@CategoryName)
END
GO

-- Procedimiento almacenado para obtener todas las categorías
CREATE OR ALTER PROCEDURE spCategories_GetAll
AS
BEGIN
    SELECT CategoryID, CategoryName
    FROM Categories
END
GO

-- Procedimiento almacenado para obtener una categoría por su ID
CREATE OR ALTER PROCEDURE spCategories_GetById
    @CategoryID INT
AS
BEGIN
    SELECT CategoryID, CategoryName
    FROM Categories
    WHERE CategoryID = @CategoryID
END
GO

-- Procedimiento almacenado para actualizar una categoría
CREATE OR ALTER PROCEDURE spCategories_Update
    @CategoryID INT,
    @CategoryName VARCHAR(50)
AS
BEGIN
    UPDATE Categories
    SET CategoryName = @CategoryName
    WHERE CategoryID = @CategoryID
END
GO

-- Procedimiento almacenado para eliminar una categoría
CREATE OR ALTER PROCEDURE spCategories_Delete
    @CategoryID INT
AS
BEGIN
    DELETE FROM Categories
    WHERE CategoryID = @CategoryID
END
GO

------------------------------------------------------------------------------------
-- Procedimiento para insertar un nuevo desarrollador
CREATE OR ALTER PROCEDURE spDeveloper_Insert
    @DeveloperName VARCHAR(100),
    @DeveloperCountry VARCHAR(50)
AS
BEGIN
    INSERT INTO Developers (DeveloperName, DeveloperCountry)
    VALUES (@DeveloperName, @DeveloperCountry)
END
GO

-- Procedimiento para obtener todos los desarrolladores
CREATE OR ALTER PROCEDURE spDeveloper_GetAll
AS
BEGIN
    SELECT DeveloperID, DeveloperName, DeveloperCountry
    FROM Developers
END
GO

-- Procedimiento para obtener un desarrollador por su ID
CREATE OR ALTER PROCEDURE spDeveloper_GetById
    @DeveloperID INT
AS
BEGIN
    SELECT DeveloperID, DeveloperName, DeveloperCountry
    FROM Developers
    WHERE DeveloperID = @DeveloperID
END
GO

-- Procedimiento para actualizar un desarrollador
CREATE OR ALTER PROCEDURE spDeveloper_Update
    @DeveloperID INT,
    @DeveloperName VARCHAR(100),
    @DeveloperCountry VARCHAR(50)
AS
BEGIN
    UPDATE Developers
    SET DeveloperName = @DeveloperName,
        DeveloperCountry = @DeveloperCountry
    WHERE DeveloperID = @DeveloperID
END
GO

-- Procedimiento para eliminar un desarrollador
CREATE OR ALTER PROCEDURE spDeveloper_Delete
    @DeveloperID INT
AS
BEGIN
    DELETE FROM Developers
    WHERE DeveloperID = @DeveloperID
END
GO
------------------------------------------------------------------------------------
-- Procedimiento para insertar un nuevo juego
CREATE OR ALTER PROCEDURE spGame_Insert
    @GameName VARCHAR(100),
    @GameDescription VARCHAR(255),
    @GameReleaseDate DATE,
    @GamePrice MONEY,
    @GameDeveloperID INT,
    @GameCategoryID INT
AS
BEGIN
    INSERT INTO Games (GameName, GameDescription, GameReleaseDate, GamePrice, GameDeveloperID, GameCategoryID)
    VALUES (@GameName, @GameDescription, @GameReleaseDate, @GamePrice, @GameDeveloperID, @GameCategoryID)
END
GO

-- Procedimiento para obtener todos los juegos
CREATE OR ALTER PROCEDURE spGame_GetAll
AS
BEGIN
    SELECT g.GameID, g.GameName, g.GameDescription, g.GameReleaseDate, g.GamePrice, d.DeveloperName, c.CategoryName
    FROM Games g
    JOIN Developers d ON g.GameDeveloperID = d.DeveloperID
    JOIN Categories c ON g.GameCategoryID = c.CategoryID
END
GO

-- Procedimiento para obtener un juego por su ID
CREATE OR ALTER PROCEDURE spGame_GetById
    @GameID INT
AS
BEGIN
    SELECT g.GameID, g.GameName, g.GameDescription, g.GameReleaseDate, g.GamePrice, d.DeveloperName, c.CategoryName
    FROM Games g
    JOIN Developers d ON g.GameDeveloperID = d.DeveloperID
    JOIN Categories c ON g.GameCategoryID = c.CategoryID
    WHERE g.GameID = @GameID
END
GO

-- Procedimiento para actualizar un juego
CREATE OR ALTER PROCEDURE spGame_Update
    @GameID INT,
    @GameName VARCHAR(100),
    @GameDescription VARCHAR(255),
    @GameReleaseDate DATE,
    @GamePrice MONEY,
    @GameDeveloperID INT,
    @GameCategoryID INT
AS
BEGIN
    UPDATE Games
    SET GameName = @GameName,
        GameDescription = @GameDescription,
        GameReleaseDate = @GameReleaseDate,
        GamePrice = @GamePrice,
        GameDeveloperID = @GameDeveloperID,
        GameCategoryID = @GameCategoryID
    WHERE GameID = @GameID
END
GO

-- Procedimiento para eliminar un juego
CREATE OR ALTER PROCEDURE spGame_Delete
    @GameID INT
AS
BEGIN
    DELETE FROM Games
    WHERE GameID = @GameID
END
GO