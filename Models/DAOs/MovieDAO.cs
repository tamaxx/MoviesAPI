using CinemaAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesAPI.Models.DAOs
{
    public class MovieDAO
    {
        public Database db;

        public List<Movie> SelectByPlatform(string namePlatform)
        {
            using (db = new Database())
            {
                var strQuery = string.Format("SELECT * FROM Plataforma_Filme INNER JOIN Filme ON Plataforma_Filme.ID_F = Filme.ID_F INNER JOIN Plataforma ON Plataforma_Filme.ID_P = Plataforma.ID_P WHERE Plataforma.Nome = '{0}'", namePlatform);
                var queryReturn = db.ReturnCommand(strQuery);
                return ListMovie(queryReturn);
            }
        }

        public string SelectPoster(int id)
        {
            using (db = new Database())
            {
                var strQuery = string.Format("SELECT cartaz FROM Filme WHERE ID_F = {0}", id);
                var queryReturn = db.ReturnCommand(strQuery);
                queryReturn.Read();
                string poster = queryReturn["cartaz"].ToString();
                queryReturn.Close();
                return poster;
            }
        }

        public List<Movie> List()
        {
            using (db = new Database())
            {
                MySqlDataReader reader = db.ReturnCommand("SELECT * FROM Filme");
                return ListMovie(reader);
            }
        }

        public List<Movie> ListSingleMovie(int id)
        {
            using (db = new Database())
            {
                var strQuery = string.Format("SELECT * FROM Filme WHERE ID_F = {0}", id);
                var queryReturn = db.ReturnCommand(strQuery);
                return ListMovie(queryReturn);
            }
        }

        public List<Movie> ListMovie(MySqlDataReader queryReturn)
        {
            var movies = new List<Movie>();

            while (queryReturn.Read())
            {
                var TempMovie = new Movie()
                {
                    ID_F = int.Parse(queryReturn["ID_F"].ToString()),
                    Name = queryReturn["nome"].ToString(),
                    Poster = queryReturn["cartaz"].ToString(),
                    Plot = queryReturn["sinopse"].ToString(),
                    Cast = queryReturn["elenco"].ToString(),
                    Year = int.Parse(queryReturn["ano"].ToString()),
                    Producer = queryReturn["produtora"].ToString(),
                    Duration = queryReturn["duracao"].ToString(),
                    ID_D = int.Parse(queryReturn["ID_D"].ToString())
                };
                movies.Add(TempMovie);
            }
            queryReturn.Close();
            foreach (Movie movie in movies)
            {
                MySqlDataReader reader = db.ReturnCommand("SELECT Genero_Filme.ID_G, Genero.Nome FROM Genero_Filme INNER JOIN Genero ON Genero.ID_G = Genero_Filme.ID_G WHERE Genero_Filme.ID_F = @id_f;", movie.getParameters());
                var genres = new List<Genre>();
                while (reader.Read())
                {
                    var TempGenre = new Genre
                    {
                        ID_G = int.Parse(reader["ID_G"].ToString()),
                        Name = reader["nome"].ToString()
                    };
                    genres.Add(TempGenre);
                }
                reader.Close();
                reader = db.ReturnCommand("SELECT Plataforma_Filme.ID_P, Plataforma.Nome, Plataforma.Icone FROM Plataforma_Filme INNER JOIN Plataforma ON Plataforma.ID_P = Plataforma_Filme.ID_P WHERE Plataforma_Filme.ID_F = @id_f;", movie.getParameters());
                var platforms = new List<Platform>();
                while (reader.Read())
                {
                    var TempPlatform = new Platform
                    {
                        ID_P = int.Parse(reader["ID_P"].ToString()),
                        Name = reader["nome"].ToString(),
                        Icon = reader["icone"].ToString()
                    };
                    platforms.Add(TempPlatform);
                }
                movie.Genre = genres;
                movie.Platform = platforms;
                reader.Close();
            }
            return movies;
        }
    }
}