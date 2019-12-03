namespace DbConnectionExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlConnection = new SqlConnection("generic connection string");
            var oracleConnection = new OracleConnection("another generic connection string");

            
            var dbCommand = new DbCommand(oracleConnection, "database command");
            dbCommand.Execute();
            var dbCommand1 = new DbCommand(sqlConnection, "another database command");
            dbCommand1.Execute();
        }
    }
}
