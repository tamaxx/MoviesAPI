using CinemaAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesAPI.Models
{
    public class GenreDAO
    {
        public Database db;

        public List<Genre> List()
        {
            using (db = new Database())
            {
                MySqlDataReader reader = db.ReturnCommand("SELECT * FROM Genero");
                return ListGenre(reader);
            }
        }

        public List<Genre> ListSingleGenre(int id)
        {
            using (db = new Database())
            {
                var strQuery = string.Format("SELECT * FROM Genero WHERE ID_G = {0}", id);
                var queryReturn = db.ReturnCommand(strQuery);
                return ListGenre(queryReturn);
            }
        }

        public List<Genre> ListGenre(MySqlDataReader queryReturn)
        {
            var genres = new List<Genre>();

            while (queryReturn.Read())
            {
                var TempGenre = new Genre()
                {
                    ID_G = int.Parse(queryReturn["ID_G"].ToString()),
                    Name = queryReturn["nome"].ToString(),
                };
                genres.Add(TempGenre);
            }
            queryReturn.Close();
            return genres;
        }
    }
}