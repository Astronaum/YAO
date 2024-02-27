using System.Data.SqlClient;

namespace DBManager
{
    public static class DBManager
    {
        private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\astro\\Desktop\\Projects\\YAO\\todolist.mdf;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}