using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesAPI.Models
{
    public class Platform
    {
        public int ID_P { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public Platform()
        {

        }
        public Platform(int id_p, string name, string icon)
        {
            ID_P = id_p;
            Name = name;
            Icon = icon;
        }
        public MySqlParameter[] getParameters()
        {
            return new MySqlParameter[] {
                new MySqlParameter("id_p", ID_P),
                new MySqlParameter("name", Name),
                new MySqlParameter("icon", Icon)};
        }
    }
}