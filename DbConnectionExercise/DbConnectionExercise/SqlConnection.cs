using System;

namespace DbConnectionExercise
{
    public class SqlConnection : DbConnection
    {
        // Constructor which calls upon the base class to pass a connection string during instantiation
        public SqlConnection(string connectionString, double timeout = 1500) 
            : base(connectionString, timeout)
        {
        }

        public override void OpenConnection()
        {
            Console.WriteLine("Trying to connect to database via SQL API");

            if (IsConnected)
                throw new InvalidOperationException("Connection is already open.");
            else
            {
                UpdateTimeoutStatus();

                if (DidTimeout)
                    OnTimeout();
                else
                {
                    // SQL connection logic
                    IsConnected = true;
                    Console.WriteLine("Successfully connected to database via SQL API.");
                }
            }
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Closing connection to database via SQL API.");

            if (!IsConnected)
                throw new InvalidOperationException("Connection is not open so cannot be closed.");
            else
            {
                UpdateTimeoutStatus();


                if (DidTimeout)
                    OnTimeout();
                else
                {
                    // SQL disconnection logic
                    IsConnected = false;
                    Console.WriteLine("Successfully disconnected from database via SQL API.");
                }
                

            }
        }

    }
}