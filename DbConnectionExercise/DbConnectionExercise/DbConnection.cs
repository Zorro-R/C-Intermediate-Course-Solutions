using System;
using System.Threading.Channels;

namespace DbConnectionExercise
{
    public abstract class DbConnection
    {

        // Properties
        public string ConnectionString { get; private set; }
        protected bool DidTimeout { get; private set; }
        public bool IsConnected { get; set; }
        private TimeSpan Timeout { get; set; } 
        private TimeSpan ConnectionTime { get; set; }


        // Base constructor 
        public DbConnection(string connectionString, double timeout = 1500)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Tried to instantiate DbConnection without a connection string.");
            else
            {
                //Set properties
                ConnectionString = connectionString;
                Timeout = TimeSpan.FromMilliseconds(timeout);
                DidTimeout = false;
                IsConnected = false;

                // Evaluate connection time -> currently set to constant.
                ConnectionTime = TimeSpan.FromMilliseconds(800); // This could be replaced with some logic for receiving the actual connection time
            }
        }

        // General Methods
        protected void OnTimeout() // Throw an error on timeout
        {
            string timeoutMilliseconds = Timeout.TotalMilliseconds.ToString();
            throw new TimeoutException($"Connection could not connect within specified connection time ({timeoutMilliseconds}).");
        }

        protected void UpdateTimeoutStatus() // FIX: Avoid use of protected access modifier
        {
            DidTimeout = ConnectionTime > Timeout; // Checks if the timeout limit has been exceeded by the connection time
        }

        // Abstract methods
        public abstract void OpenConnection();
        public abstract void CloseConnection();
    }
}