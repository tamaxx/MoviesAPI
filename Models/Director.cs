using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaAPI.Models
{
    public class Director
    {
        public int ID_D { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public int Age { get; set; }

        public Director()
        {

        }
        public Director(int id_d, string name, string picture, int age)
        {
            ID_D = id_d;
            Name = name;
            Picture = picture;
            Age = age;
        }
        public MySqlParameter[] getParameters()
        {
            return new MySqlParameter[] {
                new MySqlParameter("id_d", ID_D),
                new MySqlParameter("name", Name),
                new MySqlParameter("picture", Picture),
                new MySqlParameter("age", Age)};
        }
    }
}