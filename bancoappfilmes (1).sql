DROP DATABASE IF EXISTS bancoappfilmes;
CREATE DATABASE IF NOT EXISTS bancoappfilmes;
USE bancoappfilmes;

CREATE TABLE IF NOT EXISTS Diretor(
ID_D int NOT NULL AUTO_INCREMENT,
nome varchar(80) NOT NULL,
foto varchar(255),
idade int,
PRIMARY KEY (ID_D)
);

INSERT INTO Diretor VALUES (default, "James Gunn", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/de/James_Gunn_by_Gage_Skidmore_2.jpg/1200px-James_Gunn_by_Gage_Skidmore_2.jpg", 55);
INSERT INTO Diretor VALUES (default, "Chloé Zhao", "https://upload.wikimedia.org/wikipedia/commons/9/95/Chloe_Zhao_by_Gage_Skidmore.jpg", 39);
INSERT INTO Diretor VALUES (default, "Thomas Vinterberg", "https://upload.wikimedia.org/wikipedia/commons/a/a6/Thomas_Vinterberg_Berlinale_2010_%28cropped%29.jpg", 52);
INSERT INTO Diretor VALUES (default, "Christopher Nolan", "https://upload.wikimedia.org/wikipedia/commons/9/95/Christopher_Nolan_Cannes_2018.jpg", 51);
INSERT INTO Diretor VALUES (default, "Steven Soderbergh", "https://upload.wikimedia.org/wikipedia/commons/8/8f/Steven_Soderbergh_66%C3%A8me_Festival_de_Venise_%28Mostra%29.jpg", 58);
INSERT INTO Diretor VALUES (default, "Michael Mann", "https://upload.wikimedia.org/wikipedia/commons/9/9d/Michael_Mann_SDCC_2014.jpg", 78);
INSERT INTO Diretor VALUES (default, "Chloé Zhao", "http://www.purplereels.com/pr/wp-content/uploads/2019/02/Peter-Thorwarth-photo-1.jpg", 50);

CREATE TABLE IF NOT EXISTS Filme(
ID_F int NOT NULL AUTO_INCREMENT,
nome varchar(80) NOT NULL,
cartaz varchar(255),
sinopse varchar(255) NOT NULL,
elenco varchar(255) NOT NULL,
ano int not null,
produtora varchar(80) NOT NULL,
duracao varchar(5) NOT NULL,
ID_D int,
FOREIGN KEY (ID_D) REFERENCES Diretor (ID_D),
PRIMARY KEY(ID_F)
);

INSERT INTO Filme VALUES(default, "The Suicide Squad", "https://m.media-amazon.com/images/M/MV5BNGM3YzdlOWYtNjViZS00MTE2LWE1MWUtZmE2ZTcxZjcyMmU3XkEyXkFqcGdeQXVyODEyMTI1MjA@._V1_SX300.jpg", "Supervillains Harley Quinn, Bloodsport, Peacemaker and a collection of nutty cons at Belle Reve prison join the super-secret, super-shady Task Force X as they are dropped off at the remote, enemy-infused island of Corto Maltese.", "Margot Robbie, Idris Elba, John Cena", 2021, "DC Films", "01:47", 1);
INSERT INTO Filme VALUES(default, "Nomadland", "https://m.media-amazon.com/images/M/MV5BMDRiZWUxNmItNDU5Yy00ODNmLTk0M2ItZjQzZTA5OTJkZjkyXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SX300.jpg", "A woman in her sixties, after losing everything in the Great Recession, embarks on a journey through the American West, living as a van-dwelling modern-day nomad.", "Frances McDormand, David Strathairn, Linda May", 2020, "Highwayman Films", "02:12", 2);
INSERT INTO Filme VALUES(default, "Druk", "https://m.media-amazon.com/images/M/MV5BOTNjM2Y2ZjgtMDc5NS00MDQ1LTgyNGYtYzYwMTAyNWQwYTMyXkEyXkFqcGdeQXVyMjE4NzUxNDA@._V1_SX300.jpg", "Four high school teachers consume alcohol on a daily basis to see how it affects their social and professional lives.", "Mads Mikkelsen, Thomas Bo Larsen, Magnus Millang", 2020, "Zentropa", "01:57", 3);
INSERT INTO Filme VALUES(default, "Tenet", "https://m.media-amazon.com/images/M/MV5BYzg0NGM2NjAtNmIxOC00MDJmLTg5ZmYtYzM0MTE4NWE2NzlhXkEyXkFqcGdeQXVyMTA4NjE0NjEy._V1_SX300.jpg", "Armed with only one word, Tenet, and fighting for the survival of the entire world, a Protagonist journeys through a twilight world of international espionage on a mission that will unfold in something beyond real time.", "John David Washington, Robert Pattinson, Elizabeth Debicki", 2020, "Syncopy Films", "02:30", 4);
INSERT INTO Filme VALUES(default, "Traffic", "https://m.media-amazon.com/images/M/MV5BNDA2YjNkMjEtZjcwNy00ZTc5LWEzNDItMjE0ODlmMDAzNDFkXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg", "A conservative judge is appointed by the President to spearhead America's escalating war against drugs, only to discover that his teenage daughter is a crack addict. Two DEA agents protect an informant. A jailed drug baron's wife att", "Michael Douglas, Benicio Del Toro, Catherine Zeta-Jones", 2000, "Europa Filmes", "02:27", 5);
INSERT INTO Filme VALUES(default, "Ali", "https://m.media-amazon.com/images/M/MV5BZjA3OTUxNTktN2FlNC00NGUyLWI1NDktY2FlZTc5MDlmOGFhXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg", "A biography of sports legend Muhammad Ali, focusing on his triumphs and controversies between 1964 and 1974.", "Will Smith, Jamie Foxx, Jon Voight", 2001, "Overbrook Entertainment", "02:37", 6);
INSERT INTO Filme VALUES(default, "Blood Red Sky", "https://m.media-amazon.com/images/M/MV5BMDQ0MWEzMDEtMGZmNC00NjQ0LWJlNDItZDMyNDc5MmFkODJjXkEyXkFqcGdeQXVyODk4OTc3MTY@._V1_SX300.jpg", "A woman with a mysterious illness is forced into action when a group of terrorists attempt to hijack a transatlantic overnight flight.", "Peri Baumeister, Carl Anton Koch, Alexander Scheer", 2021, "Rat Pack Filmproduktion", "02:01", 7);


CREATE TABLE IF NOT EXISTS Usuario(
ID_U int not null auto_increment,
nome varchar(80) not null,
foto varchar(255),
senha varchar(15) not null,
PRIMARY KEY(ID_U)
);

CREATE TABLE IF NOT EXISTS Plataforma(
ID_P int NOT NULL AUTO_INCREMENT,
nome varchar(80) NOT NULL,
icone varchar(255) NOT NULL,
PRIMARY KEY(ID_P)
);

INSERT INTO Plataforma VALUES (default, "Netflix", "https://upload.wikimedia.org/wikipedia/commons/f/ff/Netflix-new-icon.png");
INSERT INTO Plataforma VALUES (default, "Amazon Prime Video", "https://tudosobretudo.net/wp-content/uploads/2020/03/Amazon-Prime-Video.png");
INSERT INTO Plataforma VALUES (default, "Telecine play", "https://is3-ssl.mzstatic.com/image/thumb/Purple117/v4/78/bd/df/78bddf3a-0c0d-0ea7-24a5-cf07c47d184a/source/512x512bb.jpg");
INSERT INTO Plataforma VALUES (default, "Youtube Filmes", "https://cdn2.iconfinder.com/data/icons/social-flat-buttons-3/512/youtube_v2-512.png");
INSERT INTO Plataforma VALUES (default, "HBO Max", "https://techgara.com/uploads/2021/7/hbo-max-icon.jpg");

CREATE TABLE IF NOT EXISTS Plataforma_Filme(
ID_PF int NOT NULL AUTO_INCREMENT,
ID_P int,
ID_F int,
FOREIGN KEY (ID_P) REFERENCES Plataforma (ID_P),
FOREIGN KEY (ID_F) REFERENCES Filme (ID_F),
PRIMARY KEY (ID_PF)
);

INSERT INTO Plataforma_Filme VALUES(default, 1, 7), (default, 2, 5), (default, 2, 6), (default, 3, 2), (default, 3, 3), (default, 4, 1), (default, 4, 3), (default, 4, 4), (default, 5, 1);

CREATE TABLE IF NOT EXISTS Genero(
ID_G int NOT NULL AUTO_INCREMENT,
nome varchar(80),
PRIMARY KEY (ID_G)
);

INSERT INTO Genero VALUES (default, "Ação"), (default, "Comédia"), (default, "Terror"), (default, "Drama"), (default, "Suspense");

CREATE TABLE IF NOT EXISTS Genero_Filme(
ID_GF int NOT NULL AUTO_INCREMENT,
ID_G int,
ID_F int,
FOREIGN KEY (ID_G) REFERENCES Genero (ID_G),
FOREIGN KEY (ID_F) REFERENCES Filme (ID_F),
PRIMARY KEY(ID_GF)
);

INSERT INTO Genero_Filme VALUES (default, 1, 1), (default, 2, 1);
INSERT INTO Genero_Filme VALUES (default, 4, 2);
INSERT INTO Genero_Filme VALUES (default, 2, 3), (default, 4, 3);
INSERT INTO Genero_Filme VALUES (default, 1, 4), (default, 4, 4);
INSERT INTO Genero_Filme VALUES (default, 4, 5);
INSERT INTO Genero_Filme VALUES (default, 4, 6);
INSERT INTO Genero_Filme VALUES (default, 1, 7), (default, 5, 7);

SELECT * FROM Usuario;