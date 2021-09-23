using CinemaAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesAPI.Models
{
    public class DirectorDAO
    {
        public Database db;

        public string SelectPicture(int id)
        {
            using (db = new Database())
            {
                var strQuery = string.Format("SELECT foto FROM Diretor WHERE ID_D = {0}", id);
                var queryReturn = db.ReturnCommand(strQuery);
                queryReturn.Read();
                string picture = queryReturn["foto"].ToString();
                queryReturn.Close();
                return picture;
            }
        }

        public List<Director> List()
        {
            using (db = new Database())
            {
                MySqlDataReader reader = db.ReturnCommand("SELECT * FROM Diretor");
                return ListDirector(reader);
            }
        }

        public List<Director> ListSingleDirector(int id)
        {
            using (db = new Database())
            {
                var strQuery = string.Format("SELECT * FROM Diretor WHERE ID_D = {0}", id);
                var queryReturn = db.ReturnCommand(strQuery);
                return ListDirector(queryReturn);
            }
        }

        public List<Director> ListDirector(MySqlDataReader queryReturn)
        {
            var directors = new List<Director>();

            while (queryReturn.Read())
            {
                var TempDirector = new Director()
                {
                    ID_D = int.Parse(queryReturn["ID_D"].ToString()),
                    Name = queryReturn["nome"].ToString(),
                    Picture = queryReturn["foto"].ToString(),
                    Age = int.Parse(queryReturn["idade"].ToString())
                };
                directors.Add(TempDirector);
            }
            queryReturn.Close();
            return directors;
        }
    }
}