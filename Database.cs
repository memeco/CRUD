using MySql.Data.MySqlClient;

namespace Crud
{
    public static class Database
    {
        private static string connectionString = "Server=localhost;Database=dbPerson;User Id=root;Password=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}