using System;

namespace SQLStatementBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("What type of SQL statement would you like to create? Press D for delete, press I for insert, press S for select, or press U for update:");
            while (true)
            {
                var userQueryTypeInput = Console.ReadLine();
                if (userQueryTypeInput.Equals("D", StringComparison.OrdinalIgnoreCase))
                {
                    var finalDeleteQuery = QueryDeleter.BuildDeleteQuery();
                    System.Console.WriteLine(finalDeleteQuery);
                    QuerySaver.SaveCompletedQuery("Delete", finalDeleteQuery);
                    break;
                }
                else if (userQueryTypeInput.Equals("I", StringComparison.OrdinalIgnoreCase))
                {
                    var finalInsertQuery = QueryInserter.BuildInsertQuery();
                    System.Console.WriteLine(finalInsertQuery);
                    QuerySaver.SaveCompletedQuery("Insert", finalInsertQuery);
                    break;
                }
                else if (userQueryTypeInput.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    var finalSelectQuery = QuerySelector.BuildSelectQuery();
                    System.Console.WriteLine(finalSelectQuery);
                    QuerySaver.SaveCompletedQuery("Select", finalSelectQuery);
                    break;
                }
                else if (userQueryTypeInput.Equals("U", StringComparison.OrdinalIgnoreCase))
                {
                    var finalUpdateQuery = QueryUpdater.BuildUpdateQuery();
                    System.Console.WriteLine(finalUpdateQuery);
                    QuerySaver.SaveCompletedQuery("Update", finalUpdateQuery);
                    break;
                }
                else
                    System.Console.WriteLine("Please make a valid selection");
            }
        }
    }
}