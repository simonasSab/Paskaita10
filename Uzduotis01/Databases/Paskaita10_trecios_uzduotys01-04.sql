--Užduotis: Sukurkite lentelę Authors
--Ši lentelė turės šiuos laukus:
--Id - tai bus pirminis raktas, INT tipo.
--FirstName - autoriaus vardas, NVARCHAR(100) tipo.
--LastName - autoriaus pavardė, NVARCHAR(100) tipo.
--BirthDate - autoriaus gimimo data, DATE tipo.
--Country - šalis, iš kurios autorius yra kilęs, NVARCHAR(50) tipo.

USE Paskaita10;
CREATE TABLE Author (
	ID int IDENTITY(1,1) PRIMARY KEY,
	FirstName nvarchar(100),
	LastName nvarchar(100),
	BirthDate date,
	Country nvarchar(50)
);

--Užduotis: Sukurkite lentelę Books
--Ši lentelė turės šiuos laukus:
--Id - tai bus pirminis raktas, INT tipo.
--Title - knygos pavadinimas, NVARCHAR(255) tipo.
--PublicationYear - knygos leidimo metai, INT tipo.
--Genre - knygos žanras, NVARCHAR(50) tipo.
--AuthorID - tai bus svetimasis raktas, susijęs su Authors lentelės AuthorID.

USE Paskaita10;
CREATE TABLE Book (
	ID int IDENTITY(1,1) PRIMARY KEY,
	Title nvarchar(255),
	PublicationYear int,
	Genre nvarchar(50),
	AuthorID int FOREIGN KEY REFERENCES Author(Id)
);

--Užduotis: Sukurkite lentelę BookCopies
--Ši lentelė turės šiuos laukus:
--Id - tai bus pirminis raktas, INT tipo.
--BookId - tai bus svetimasis raktas, susijęs su Books lentelės BookID.
--Condition - knygos būklė (pvz., New, Good, Worn), NVARCHAR(50) tipo.
--Price - knygos kaina, DECIMAL(10,2) tipo.
--InStock - kiekis sandėlyje, INT tipo.

USE Paskaita10;
CREATE TABLE BookCopies (
	ID int IDENTITY(1,1) PRIMARY KEY,
	BookID int FOREIGN KEY REFERENCES Book(Id),
	Condition nvarchar(50),
	Price decimal(10,2),
	InStock int
);

--Užduotis: Įterpkite duomenų į lenteles Author, Books, BookCopies
--Pasibandykite filtravimo užklausų su SELECT

USE Paskaita10;
INSERT INTO Author (FirstName, LastName, BirthDate, Country)
VALUES
('Petras', 'Petraitis', '1979-01-14', 'Lithuania'),
('Ketrs', 'Ketraits', '1980-03-14', 'Latvia'),
('Cetras', 'Cetraitis', '1981-05-14', 'Estonia'),
('Retras', 'Retraitis', '1982-07-14', 'Poland'),
('Tetras', 'Tetraitis', '1983-09-14', 'Ukraine'),
('Netras', 'Netraitis', '1984-11-14', 'Germany');

SELECT * FROM Author;
SELECT * FROM Author
WHERE BirthDate < '1982-07-15'
ORDER BY BirthDate DESC;

USE Paskaita10;
INSERT INTO Book (Title, PublicationYear, Genre, AuthorID)
VALUES
('Carwash', 2012, 'Crime', 3),
('Carwash 2', 2014, 'Crime', 3),
('Carwash 3', 2018, 'Crime', 3),
('Trees of Hell', 1998, 'Fairytale', 2),
('The Minor Fail', 2005, 'Detective', 4),
('The Major Fail', 2005, 'Detective', 4),
('The Epic Fail', 2005, 'Detective', 4),
('Apples: Origins', 2007, 'Fantasy Drama', 1),
('The Return of the Apples', 2009, 'Fantasy Drama', 1),
('Apples: The Reckoning', 2010, 'Fantasy Drama', 1),
('1995', 1996, 'Fantasy', 5),
('1997', 1998, 'Fantasy', 5),
('2000', 2001, 'Fantasy', 5),
('Parry Hotter and the Boulder', 2009, 'Crime', 6),
('Parry Hotter and the Toilet of Ambiguity', 2012, 'Crime', 6),
('Parry Hotter and the Rescue of the Butterfly', 2013, 'Crime', 6);

SELECT * FROM Book;
SELECT * FROM Book
WHERE PublicationYear >= 2010
ORDER BY PublicationYear ASC;

USE Paskaita10;
INSERT INTO BookCopies (BookID, Condition, Price, InStock)
VALUES
(1, 'New', 12.51, 18),
(1, 'Good', 10.45, 35),
(1, 'Worn', 8.99, 61),
(2, 'New', 13.99, 66),
(2, 'Good', 11.99, 19),
(2, 'Worn', 7.45, 7),
(3, 'New', 13.99, 23),
(3, 'Good', 11.19, 18),
(3, 'Worn', 9.19, 6),
(4, 'New', 39.99, 51),
(4, 'Good', 20.39, 100),
(4, 'Worn', 15.00, 19),
(5, 'New', 32.10, 70),
(5, 'Good', 21.99, 85),
(5, 'Worn', 16.99, 100),
(6, 'New', 13.99, 102),
(6, 'Good', 11.45, 146),
(6, 'Worn', 9.13, 75),
(7, 'New', 79.49, 75),
(7, 'Good', 65.99, 82),
(7, 'Worn', 40.45, 26),
(8, 'New', 26.99, 24),
(8, 'Good', 17.69, 45),
(8, 'Worn', 12.19, 35),
(9, 'New', 4.99, 19),
(9, 'Good', 2.99, 25),
(9, 'Worn', 0.99, 16),
(10, 'New', 14.49, 39),
(10, 'Good', 12.49, 41),
(10, 'Worn', 8.59, 24),
(11, 'New', 8.95, 81),
(11, 'Good', 6.99, 47),
(11, 'Worn', 5.49, 36),
(12, 'New', 10.64, 36),
(12, 'Good', 9.95, 26),
(12, 'Worn', 7.32, 10),
(13, 'New', 9.99, 21),
(13, 'Good', 7.95, 41),
(13, 'Worn', 5.19, 35),
(14, 'New', 9.99, 51),
(14, 'Good', 7.99, 41),
(14, 'Worn', 4.59, 30),
(15, 'New', 8.99, 95),
(15, 'Good', 5.55, 95),
(15, 'Worn', 4.45, 95),
(16, 'New', 4.55, 32),
(16, 'Good', 3.21, 52),
(16, 'Worn', 2.99, 42);

SELECT * FROM BookCopies;
SELECT * FROM BookCopies
WHERE Price < 5;
