using System;
using System.Data.SqlClient;

namespace TicTacToeDiscordBot.External_Dependencies
{
    public class Database
    {
        public SqlConnection connection = new SqlConnection(Bot.ReadFromJson("connectionString"));
        public SqlCommand command;

        public void PrepareSql(string sqlString)
        {
            try
            {
                connection.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = sqlString;
        }

        public void ExecuteSql(string sqlString)
        {
            PrepareSql(sqlString);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public string GetId(string sqlSelect)
        {
            command.CommandText = sqlSelect;
            SqlDataReader sqldr = command.ExecuteReader();

            if (sqldr.HasRows)
                while (sqldr.Read())
                {
                    string id = sqldr["userId"].ToString();
                    connection.Close();
                    return id;
                }

            connection.Close();
            return null;
        }
    }
}
