namespace TRRP0
{
    internal static class DbConst
    {
       
        public static string Database = "Student";
        private const string Host = "127.0.0.1";
        private const int Port = 5432;
        private const string Username = "postgres";
        private const string Password = "kek13524";

        public static readonly string ConnString = $"Server={Host};Database={Database};port={Port};Username={Username};password={Password}";
    }
    
}
