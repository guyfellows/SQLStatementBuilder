using System;
using System.Collections.Generic;
using System.Text;

namespace SQLStatementBuilder
{
    public class QueryUpdater
    {
        static private string _updateQueryTable;
        static private string _updateQueryColumn;
        static private string _insertQueryColumnFinal;
        static private string _updateQueryFilter;

        public static string BuildUpdateQuery()
        {
            SetUpdateQueryTable();
            SetUpdateQueryColumns();
            SetUpdateQueryValues();
            SetDeleteQueryFilter();
            return ReturnCompleteUpdateQuery();
        }
        public static void SetUpdateQueryTable()
        {
            while (true)
            {
                System.Console.WriteLine("What table would you like to update:");
                var userDeleteTableInput = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(userDeleteTableInput))
                    System.Console.WriteLine("!!YOU MUST ENTER THE NAME OF A TABLE!!");
                else
                {
                    _updateQueryTable = userDeleteTableInput;
                    return;
                }
            }
        }
        private static void SetUpdateQueryColumns()
        {
            while (true)
            {
                System.Console.WriteLine("Which columns would you like to update? Add these columns as a comma separated string:");
                var userInsertQueryColumnInput = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(userInsertQueryColumnInput))
                    System.Console.WriteLine("!!YOU MUST ENTER A COMMA SEPARATED COLUMN LIST!!");
                else
                {
                    _updateQueryColumn = userInsertQueryColumnInput;
                    return;
                }
            }
        }
        private static void SetUpdateQueryValues()
        {
            string[] userUpdateQueryColumnInput = _updateQueryColumn.Split(",");
            List<string> userUpdateValueOutput = new List<string>();
            foreach (string s in userUpdateQueryColumnInput)
            {
                while (true)
                {
                    System.Console.WriteLine($"What data would you like to update in {_updateQueryTable}.{s}:");
                    var userUpdateValueInput = Console.ReadLine();
                    if (userUpdateValueInput.Contains(','))
                        System.Console.WriteLine("Please enter a value without a comma");
                    else
                    {
                        var isValueNumeric = false;
                        if (String.IsNullOrEmpty(userUpdateValueInput))
                            userUpdateValueOutput.Add($"{s} = NULL");
                        else if (isValueNumeric = int.TryParse(userUpdateValueInput, out int numbericOutputValue))
                            userUpdateValueOutput.Add($"{s} = {userUpdateValueInput}");
                        else
                            userUpdateValueOutput.Add($"{s} = '{userUpdateValueInput}'");
                        break;
                    }
                }
            }
            _insertQueryColumnFinal = String.Join(", ", userUpdateValueOutput);
        }
        private static void SetDeleteQueryFilter()
        {
            System.Console.WriteLine("What filter would you like to use in the query:");
            _updateQueryFilter = Console.ReadLine();
        }
        private static string ReturnCompleteUpdateQuery ()
        {
            if (String.IsNullOrWhiteSpace(_updateQueryFilter))
                return ($"UPDATE {_updateQueryTable} SET {_insertQueryColumnFinal}");
            else
                return ($"UPDATE {_updateQueryTable} SET {_insertQueryColumnFinal} WHERE {_updateQueryFilter}");
        }

    }

}