﻿using MySql.Data.MySqlClient;

namespace Shop_ELECTRO.Data.Common
{
    public class Connection
    {
        readonly static string ConnectionData = "server=localhost;uid=root1;pwd=;database=shop_e;";

        public static MySqlConnection MySqlOpen()
        {
            MySqlConnection NewMySqlConnection = new MySqlConnection(ConnectionData);
            NewMySqlConnection.Open();
            return NewMySqlConnection;
        }

        public static MySqlDataReader MySqlQuery(string Query, MySqlConnection Connection)
        {
            MySqlCommand NewMySqlCommand = new MySqlCommand(Query, Connection);
            return NewMySqlCommand.ExecuteReader();
        }
        public static void MySqlClose(MySqlConnection connection)
        {
            connection.Close();
        }
    }
}
