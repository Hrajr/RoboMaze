using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using MySql.Data;
using MySql.Data.MySqlClient;
//using Renci.SshNet;

namespace DatabaseConnector
{
    public class DBConnection
    {
        private string Host { get; set; }
        private string Database { get; set; }
        private string DbUsername { get; set; }
        private string DbPassword { get; set; }
        private string masterUsername { get; set; }
        private string masterPassword { get; set; }

        private MySqlConnection connection = null;

        public DBConnection(string host, string database, string dbusername, string dbpassword)
        {
            Host = host;
            Database = database;
            DbUsername = dbusername;
            DbPassword = dbpassword;
        }

        public bool Connect()
        {
            string connstring = $"Server={Host}; database={Database}; UID={DbUsername}; password={DbPassword}; persistsecurityinfo=True; port=3306; SslMode=none";

            connection = new MySqlConnection(connstring);
            connection.Open();

            return true;
        }

        public bool insertHighscore(string name, string email, int score, TimeSpan time)
        {
            if (Connect())
            {
                string query = 
                    $"INSERT INTO highscores (name, email, score, time ) VALUES('{name}', '{email}', '{score}', '{time}'); ";

                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();

                connection.Close();
            }

            return true;
        }


        public List<List<string>> getAllHighscores()
        {
            List<List<string>> allRows = new List<List<string>>();
            if (Connect())
            {
                string query = "SELECT * FROM highscores";
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    List<string> thisRow = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        thisRow.Add(reader.GetString(i));
                    }

                    allRows.Add(thisRow);
                    thisRow.ForEach(Console.WriteLine);
                }
                connection.Close();
            }
                
            return allRows;
        }
    }
}
