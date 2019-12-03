using System;

namespace DbConnectionExercise
{
    public class DbCommand
    {
        // Properties
        private DbConnection DbConnection { get; set; }
        private string InstructionCommand { get; set; }

        // Constructor requires a DbConnection and a command
        public DbCommand(DbConnection dbConnection, string instructionCommand)
        {
            if (dbConnection == null || String.IsNullOrEmpty(instructionCommand))
                throw new InvalidOperationException("Attempted to instantiate DbCommand without a DbConnection or a command.");
            else
            {
                DbConnection = dbConnection;
                InstructionCommand = instructionCommand;
            }
        }

        // Methods
        public void Execute()
        {
            DbConnection.OpenConnection();
            Console.WriteLine(InstructionCommand); // Instruction logic
            DbConnection.CloseConnection();
        }
    }
}