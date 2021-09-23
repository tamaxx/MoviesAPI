using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesAPI.Models
{
    public class Genre
    {
        public int ID_G { get; set; }
        public string Name { get; set; }

        public Genre()
        {

        }
        public Genre(int id_g, string name)
        {
            ID_G = id_g;
            Name = name;
        }
        public MySqlParameter[] getParameters()
        {
            return new MySqlParameter[] {
                new MySqlParameter("id_g", ID_G),
                new MySqlParameter("name", Name)};
        }
    }
}