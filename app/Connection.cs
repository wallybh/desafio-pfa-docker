using System;
using MySql.Data.MySqlClient;

namespace desafio_docker
{
    public static class Connection
    {
        private static readonly string server = Environment.GetEnvironmentVariable("MYSQL_SERVER") ?? "localhost";
        private static readonly string port = Environment.GetEnvironmentVariable("MYSQL_PORT") ?? "3306";
        private static readonly string database = Environment.GetEnvironmentVariable("MYSQL_DB") ?? "desafio_pfa_docker";
        private static readonly string user = Environment.GetEnvironmentVariable("MYSQL_USER") ?? "root";
        private static readonly string password = Environment.GetEnvironmentVariable("MYSQL_PSW") ?? "";
        private static readonly string ConnectionString = $"host={server};port={port};Database={database};User Id={user};password={password};";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}