using System;


namespace SQLStatementBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var programInputOutput = new InputOutput();
            programInputOutput.WriteStringOuput("What type of SQL statement would you like to create? Press D for delete, press I for insert, press S for select, or press U for update:");

            while (true)
            {
                var userQueryTypeInput = programInputOutput.ReadKeyInput();
                if (userQueryTypeInput.Key == ConsoleKey.D)
                {
                    Console.WriteLine();
                    var newDeleteQuery = new QueryDeleter();
                    newDeleteQuery.BuildDeleteQuery();
                    break;
                }
                if (userQueryTypeInput.Key == ConsoleKey.I)
                {
                    Console.WriteLine();
                    var newInsertQuery = new QueryInserter();
                    newInsertQuery.BuildInsertQuery();
                    break;
                }
                if (userQueryTypeInput.Key == ConsoleKey.S)
                {
                    Console.WriteLine();
                    var newSelectQuery = new QuerySelector();
                    newSelectQuery.BuildSelectQuery();
                    break;
                }
                if (userQueryTypeInput.Key == ConsoleKey.U)
                {
                    Console.WriteLine();
                    var newUpdateQuery = new QueryUpdater();
                    newUpdateQuery.BuildUpdateQuery();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    programInputOutput.WriteStringOuput("Please make a valid selection");
                }
            }
        }
    }
}