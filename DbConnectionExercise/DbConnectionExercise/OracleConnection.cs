using System;

namespace DbConnectionExercise
{
    public class OracleConnection : DbConnection
    {
        // Constructor which calls upon the base class to pass a connection string during instantiation
        public OracleConnection(string connectionString, double timeout = 1500) 
            : base(connectionString, timeout)
        {
        }

        public override void OpenConnection()
        {
            if(IsConnected)
                throw new InvalidOperationException("Connection is already open.");
            else
            {
                Console.WriteLine("Trying to connect to database via Oracle framework.");
                this.UpdateTimeoutStatus();

                if (DidTimeout)
                    this.OnTimeout();
                else
                {
                    // Oracle connection logic
                    Console.WriteLine("Successfully connected to database via oracle framework.");
                    IsConnected = true;
                }
            }
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Closing connection to database via Oracle framework.");

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
                    Console.WriteLine("Successfully disconnected from database via Oracle framework.");
                }


            }
        }

    }
}