CREATE DATABASE eDecor
go
USE eDecor
go
/******Drzave******/
CREATE TABLE Drzave
(
	DrzavaID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Drzave PRIMARY KEY CLUSTERED,
	Naziv nvarchar(50) NOT NULL
)
GO
/******Gradovi******/
CREATE TABLE Gradovi
(
	GradID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Gradovi PRIMARY KEY CLUSTERED,
	Naziv nvarchar(50) NOT NULL,
	DrzavaID int NOT NULL CONSTRAINT FK_Gradovi_Drzave FOREIGN KEY REFERENCES Drzave(DrzavaID)
)
GO
/******Uloge******/
CREATE TABLE Uloge(
	UlogaID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Uloge PRIMARY KEY CLUSTERED,
	Naziv nvarchar(50) NOT NULL,
	Opis nvarchar(200) NULL
)
GO
/******Korisnici******/
CREATE TABLE Korisnici(
	KorisnikID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Korisnici PRIMARY KEY CLUSTERED,
	Ime nvarchar(50) NOT NULL,
	Prezime nvarchar(50) NOT NULL,
	Email nvarchar(100) NULL,
	Telefon nvarchar(20) NULL,
	GradID int NOT NULL CONSTRAINT FK_Korisnici_Gradovi FOREIGN KEY REFERENCES Gradovi(GradID),
	KorisnickoIme nvarchar(50) NOT NULL ,
	LozinkaHash nvarchar(500) NOT NULL,
	LozinkaSalt nvarchar(500) NULL,
	[Status] bit NOT NULL,
	CONSTRAINT Korisnici_Email UNIQUE(Email),
	CONSTRAINT Korisnici_KorisnickoIme UNIQUE(KorisnickoIme)
)
GO
/******KorisniciUloge******/
CREATE TABLE KorisniciUloge(
	KorisnikUlogaID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_KorisniciUloge PRIMARY KEY CLUSTERED,
	KorisnikID int NOT NULL CONSTRAINT FK_KorisniciUloge_Korisnici FOREIGN KEY REFERENCES Korisnici(KorisnikID),
	UlogaID int NOT NULL CONSTRAINT FK_KorisniciUloge_Uloge FOREIGN KEY REFERENCES Uloge(UlogaID),
	DatumIzmjene datetime NOT NULL
)
GO
/******Klijenti******/
CREATE TABLE Klijenti(
	KlijentID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Klijenti PRIMARY KEY CLUSTERED ,
	Ime nvarchar(50) NOT NULL,
	Prezime nvarchar(50) NOT NULL,
	DatumRegistracije datetime NOT NULL,
	Email nvarchar(100) NOT NULL,
	Telefon nvarchar(20) NOT NULL,
	GradID int NOT NULL CONSTRAINT FK_Klijenti_Gradovi FOREIGN KEY REFERENCES Gradovi(GradID),
	KorisnickoIme nvarchar(50) NOT NULL,
	LozinkaHash nvarchar(50) NOT NULL,
	LozinkaSalt nvarchar(50) NOT NULL,
	[Status] bit NOT NULL,
	CONSTRAINT Klijenti_Email UNIQUE(Email),
	CONSTRAINT Klijenti_KorisnickoIme UNIQUE(KorisnickoIme)
)
GO
/******Notifikacije******/
CREATE TABLE Notifikacije
(
	NotifikacijaID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Notifikacije PRIMARY KEY,
	DatumSlanja datetime NOT NULL,
	Naziv nvarchar(50) NOT NULL,
	Sadrzaj nvarchar(max) NOT NULL,
    Slika varbinary(max) NULL,
	[Status] bit NOT NULL,
	KorisnikID int NOT NULL CONSTRAINT FK_Novosti_Korisnici FOREIGN KEY REFERENCES Korisnici(KorisnikID),
	KlijentID int NULL CONSTRAINT FK_Notifikacije_Klijenti FOREIGN KEY REFERENCES Klijenti(KlijentID)
)
GO
/******Kategorije******/
CREATE TABLE Kategorije
(
	KategorijaID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Kategorije PRIMARY KEY CLUSTERED,
	Naziv nvarchar(50) NOT NULL,
	Opis nvarchar(200) NULL
)
GO
/******Podkategorije******/
CREATE TABLE Podkategorije
(
	PodkategorijaID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Podkategorije PRIMARY KEY CLUSTERED,
	Naziv nvarchar(50) NOT NULL,
	Opis nvarchar(200) NULL,
	KategorijaID int NOT NULL CONSTRAINT FK_Podkategorije_Kategorije FOREIGN KEY REFERENCES Kategorije(KategorijaID)
)
GO
/******Artikli******/
CREATE TABLE Artikli(
	ArtikalID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Artikli PRIMARY KEY CLUSTERED,
	Naziv nvarchar(50) NOT NULL,
	Opis nvarchar(200) NULL,
	Cijena decimal(18, 2) NOT NULL,
	[Status] bit NOT NULL,
	Slika varbinary(max) NULL,
    SlikaThumb varbinary(max) NULL,
	KategorijaID int NOT NULL CONSTRAINT FK_Artikli_Kategorije FOREIGN KEY REFERENCES Kategorije(KategorijaID),
	PodkategorijaID int NOT NULL CONSTRAINT FK_Artikli_Podkategorije FOREIGN KEY REFERENCES Podkategorije(PodkategorijaID)
)
go
/******Ocjene******/
CREATE TABLE Ocjene
(
	OcjenaID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Ocjene PRIMARY KEY CLUSTERED ,
	ArtikalID int NOT NULL CONSTRAINT FK_Ocjene_Atrikli FOREIGN KEY REFERENCES Artikli(ArtikalID),
	KlijentID int NOT NULL CONSTRAINT FK_Ocjene_Klijenti FOREIGN KEY REFERENCES Klijenti(KlijentID),
	Datum datetime NOT NULL,
	Ocjena int NOT NULL
)
GO
/******Pretplate******/
CREATE TABLE Pretplate
(
	PretplataID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Pretplate PRIMARY KEY,
	Datum datetime NOT NULL,
	[Status] bit NOT NULL,
	KlijentID int NOT NULL CONSTRAINT FK_Preplate_Klijenti FOREIGN KEY REFERENCES Klijenti(KlijentID),
	KategorijaID int NOT NULL CONSTRAINT FK_Preplate_Kategorije FOREIGN KEY REFERENCES Kategorije(KategorijaID)
)
GO
/******Popusti******/
CREATE TABLE Popusti
(
	PopustID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Popusti PRIMARY KEY,
	Kod nvarchar(100) NULL,
	Popust decimal(5, 2) NULL,
	Datum datetime NOT NULL,
	[Status] bit NOT NULL,
	CONSTRAINT Popust_PopustKod UNIQUE(Kod)
)
GO
/******Rezervacije******/
CREATE TABLE Rezervacije(
	RezervacijaID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Rezervacije PRIMARY KEY CLUSTERED,
	KlijentID int NULL CONSTRAINT FK_Rezervacije_Klijenti FOREIGN KEY REFERENCES Klijenti(KlijentID),
	KorisnikID int NULL CONSTRAINT FK_Rezervacije_Korisnici FOREIGN KEY REFERENCES Korisnici(KorisnikID),
	PopustID int NULL CONSTRAINT FK_Rezervacije_Popusti FOREIGN KEY REFERENCES Popusti(PopustID),
	GradID int NOT NULL CONSTRAINT FK_Rezervacije_Gradovi FOREIGN KEY REFERENCES Gradovi(GradID),
	Adresa nvarchar(200) NULL,
	DatumKreiranja datetime NOT NULL,
	Napomena nvarchar(200) NULL,
	[Status] bit NOT NULL
)
GO

/******RezervacijeArtikli******/
CREATE TABLE RezervacijeArtikli(
	RezervacijaArtikalID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_RezervacijeArtikli PRIMARY KEY CLUSTERED,
	ArtikalID int NOT NULL CONSTRAINT FK_RezervacijeArtikli_Artikli FOREIGN KEY REFERENCES Artikli(ArtikalID),
	RezervacijaID int NOT NULL CONSTRAINT FK_RezervacijeArtikli_Rezervacije FOREIGN KEY REFERENCES Rezervacije(RezervacijaID),
	Kolicina int NOT NULL,
	[Status] bit NOT NULL
)
GO























