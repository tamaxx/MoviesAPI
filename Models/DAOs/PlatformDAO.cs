using CinemaAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesAPI.Models.DAOs
{
    public class PlatformDAO
    {
        public Database db;

        public string SelectIcon(int id)
        {
            using (db = new Database())
            {
                var strQuery = string.Format("SELECT icone FROM Plataforma WHERE ID_P = {0}", id);
                var queryReturn = db.ReturnCommand(strQuery);
                queryReturn.Read();
                string icon = queryReturn["icone"].ToString();
                queryReturn.Close();
                return icon;
            }
        }

        public List<Platform> List()
        {
            using (db = new Database())
            {
                MySqlDataReader reader = db.ReturnCommand("SELECT * FROM Plataforma");
                return ListPlatform(reader);
            }
        }

        public List<Platform> ListSinglePlatform(int id)
        {
            using (db = new Database())
            {
                var strQuery = string.Format("SELECT * FROM Plataforma WHERE ID_P = {0}", id);
                var queryReturn = db.ReturnCommand(strQuery);
                return ListPlatform(queryReturn);
            }
        }

        public List<Platform> ListPlatform(MySqlDataReader queryReturn)
        {
            var platforms = new List<Platform>();

            while (queryReturn.Read())
            {
                var TempPlatform = new Platform()
                {
                    ID_P = int.Parse(queryReturn["ID_P"].ToString()),
                    Name = queryReturn["nome"].ToString(),
                    Icon = queryReturn["icone"].ToString()
                };
                platforms.Add(TempPlatform);
            }
            queryReturn.Close();
            return platforms;
        }
    }
}