using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesAPI.Models
{
    public class User
    {
        public int ID_U { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Password { get; set; }

        public User()
        {

        }
        public User(int id_u, string name, string picture, string password)
        {
            ID_U = id_u;
            Name = name;
            Picture = picture;
            Password = password;
        }
        public MySqlParameter[] getParameters()
        {
            return new MySqlParameter[] {
                new MySqlParameter("id_u", ID_U),
                new MySqlParameter("name", Name),
                new MySqlParameter("picture", Picture),
                new MySqlParameter("password", Password)};
        }
    }
}