using System;
using System.Collections.Generic;
using System.Text;

namespace SQLStatementBuilder
{
    public class QueryInserter : QueryBuilder
    {
        static private string _insertQueryColumn;
        static private string _insertQueryColumnFinal;

        public static string BuildInsertQuery()
        {
            SetQueryTable();
            SetInsertQueryColumns();
            SetInsertQueryValues();
            return ReturnCompleteInsertQuery();
        }
        private static void SetInsertQueryColumns()
        {
            while (true)
            {
                System.Console.WriteLine("Which columns would you like to insert data into? Add these columns as a comma separated string:");
                var userInsertQueryColumnInput = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(userInsertQueryColumnInput))
                    System.Console.WriteLine("!!YOU MUST ENTER A COMMA SEPARATED COLUMN LIST!!");
                else
                {
                    _insertQueryColumn = userInsertQueryColumnInput;
                    return;
                }
            }
        }
        private static void SetInsertQueryValues()
        {
            string[] userInsertQueryColumnInput = _insertQueryColumn.Split(",");
            List<string> userInsertValueOutput = new List<string>();
            foreach (string s in userInsertQueryColumnInput)
            {
                while (true)
                {
                    System.Console.WriteLine($"What data would you like to insert into {_queryTable}.{s}:");
                    var userInsertValueInput = Console.ReadLine();
                    if (userInsertValueInput.Contains(','))
                        System.Console.WriteLine("Please enter a value without a comma");
                    else
                    {
                        var isValueNumeric = false;
                        if (String.IsNullOrEmpty(userInsertValueInput))
                            userInsertValueOutput.Add("NULL");
                        else if (isValueNumeric = int.TryParse(userInsertValueInput, out int numbericOutputValue))
                            userInsertValueOutput.Add(userInsertValueInput); //Should capture strictly numeric value without commas for SQL processing; not infallible!!!
                        else
                            userInsertValueOutput.Add("'" + userInsertValueInput + "'");
                        break;
                    }
                }
            }
            _insertQueryColumnFinal = String.Join(", ", userInsertValueOutput);
        }
        private static string ReturnCompleteInsertQuery()
        {
            return ($"INSERT INTO {_queryTable} ({_insertQueryColumn}) VALUES ({_insertQueryColumnFinal})");
        }
    }
}