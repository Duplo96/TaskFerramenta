CREATE TABLE Prodotto(
	prodottoId INT PRIMARY KEY IDENTITY (1,1),
	codice VARCHAR(250) NOT NULL DEFAULT NEWID(),
	nome VARCHAR(250) NOT NULL,
	descrizione TEXT,
	prezzo DECIMAL NOT NULL CHECK (prezzo >=0),
	quantita INT NOT NULL CHECK (quantita >= 0),
	categoria VARCHAR(250) NOT NULL,
	dataCreazione DATE DEFAULT CURRENT_TIMESTAMP

);

INSERT INTO Prodotto(nome,descrizione,prezzo,quantita,categoria) VALUES ('Chiodi','Bei chiodi d''alluminio',12,10,'Bricolage')

SELECT * FROM Prodotto