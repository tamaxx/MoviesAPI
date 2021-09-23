using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesAPI.Models
{
    public class Movie
    {
        public int ID_F { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public string Cast { get; set; }
        public string Plot { get; set; }
        public int Year { get; set; }
        public string Producer { get; set; }
        public string Duration { get; set; }
        public List<Genre> Genre { get; set; }
        public List<Platform> Platform { get; set; }
        public int ID_D { get; set; }

        public Movie()
        {

        }
        public Movie(int id_f, string name, string poster, string cast, string plot, int year, string producer, string duration, List<Genre> genero, List<Platform> plataforma, int id_d)
        {
            ID_F = id_f;
            Name = name;
            Poster = poster;
            Cast = cast;
            Plot = plot;
            Year = year;
            Producer = producer;
            Duration = duration;
            Genre = genero;
            Platform = plataforma;
            ID_D = id_d;
        }

        public MySqlParameter[] getParameters()
        {
            return new MySqlParameter[] {new MySqlParameter("id_f", ID_F),
                new MySqlParameter("name", Name),
                new MySqlParameter("poster", Poster),
                new MySqlParameter("cast", Cast),
                new MySqlParameter("plot", Plot),
                new MySqlParameter("year", Year),
                new MySqlParameter("producer", Producer),
                new MySqlParameter("duration", Duration),
                new MySqlParameter("genre", Genre),
                new MySqlParameter("platform", Platform),
                new MySqlParameter("id_d", ID_D)};
        }
    }
}