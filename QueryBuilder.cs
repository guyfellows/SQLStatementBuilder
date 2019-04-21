using System;

namespace SQLStatementBuilder
{
    public class QueryBuilder
    {
        static protected string _queryTable;

         static protected void SetQueryTable()
        {
            while (true)
            {
                System.Console.WriteLine("What table would you like to use:");
                var userInputTable = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(userInputTable))
                    System.Console.WriteLine("!!YOU MUST ENTER THE NAME OF A TABLE!!");
                else
                {
                    _queryTable = userInputTable;
                    return;
                }
            }
        }
    }