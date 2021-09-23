using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CinemaAPI.Models
{
    public class Database : IDisposable
    {
        private readonly MySqlConnection connection;

        public Database()
        {
            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
        }

        public void ExecuteCommand(string cmd, MySqlParameter[] parameters)
        {

            MySqlCommand command = new MySqlCommand(cmd, connection);

            foreach (MySqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            command.ExecuteNonQuery();
        }

        public void ExecuteCommand(string cmd)
        {
            new MySqlCommand(cmd, connection).ExecuteNonQuery();
        }

        public MySqlDataReader ReturnCommand(string cmd, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(cmd, connection);

            foreach (MySqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command.ExecuteReader();
        }

        public MySqlDataReader ReturnCommand(string cmd)
        {
            return new MySqlCommand(cmd, connection).ExecuteReader();
        }

        public void Dispose()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}