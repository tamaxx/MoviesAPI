using CinemaAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesAPI.Models.DAOs
{
    public class UserDAO
    {
        public Database db;

        public string SelectPicture(int id)
        {
            using (db = new Database())
            {
                var strQuery = string.Format("SELECT foto FROM Usuario WHERE ID_U = {0}", id);
                var queryReturn = db.ReturnCommand(strQuery);
                queryReturn.Read();
                string picture = queryReturn["foto"].ToString();
                queryReturn.Close();
                return picture;
            }
        }

        public List<User> List()
        {
            using (db = new Database())
            {
                MySqlDataReader reader = db.ReturnCommand("SELECT * FROM Usuario");
                return ListUser(reader);
            }
        }

        public List<User> ListSingleUser(int id)
        {
            using (db = new Database())
            {
                var strQuery = string.Format("SELECT * FROM Usuario WHERE ID_U = {0}", id);
                var queryReturn = db.ReturnCommand(strQuery);
                return ListUser(queryReturn);
            }
        }

        public List<User> ListUser(MySqlDataReader queryReturn)
        {
            var users = new List<User>();

            while (queryReturn.Read())
            {
                var TempUser = new User()
                {
                    ID_U = int.Parse(queryReturn["ID_U"].ToString()),
                    Name = queryReturn["nome"].ToString(),
                    Picture = queryReturn["foto"].ToString(),
                    Password = queryReturn["senha"].ToString()
                };
                users.Add(TempUser);
            }
            queryReturn.Close();
            return users;
        }

        public Boolean SignUp(User user)
        {
            using (db = new Database())
            {
                MySqlDataReader reader = db.ReturnCommand("SELECT * FROM Usuario WHERE Nome = @name", user.getParameters());

                if (ListUser(reader).Count() != 0)
                {
                    return false;
                };

                db.ExecuteCommand("INSERT INTO Usuario (nome, foto, senha) VALUES (@name, @picture, @password)", user.getParameters());
                return true;
            }
        }

        public Boolean Update(User user, MySqlParameter[] parameters)
        {
            using (db = new Database())
            {
                MySqlDataReader reader = db.ReturnCommand("SELECT * FROM Usuario WHERE Nome = @name", user.getParameters());

                if (ListUser(reader).Count() != 0)
                {
                    return false;
                };

                db.ExecuteCommand($"UPDATE Usuario SET nome = @name, foto = @picture, senha = @password WHERE ID_U = {user.ID_U}", parameters);

                return true;
            }
        }

        public void Delete(int id)
        {
            using (db = new Database())
            {
                var strQuery = string.Format("DELETE FROM Usuario WHERE ID_U = {0}", id);
                db.ExecuteCommand(strQuery);
            }
        }
    }
}