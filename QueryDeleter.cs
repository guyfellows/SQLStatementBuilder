using System;

namespace SQLStatementBuilder
{
    public class QueryDeleter : QueryBuilder
    {
        static private string _deleteQueryFilter;

        public static string BuildDeleteQuery()
        {
            SetQueryTable();
            SetDeleteQueryFilter();
            return ReturnCompleteDeleteQuery();
        }
        private static void SetDeleteQueryFilter()
        {
            System.Console.WriteLine("What filter would you like to use in the query:");
            _deleteQueryFilter = Console.ReadLine();
        }
        private static string ReturnCompleteDeleteQuery()
        {
            if (String.IsNullOrWhiteSpace(_deleteQueryFilter))
                return ($"DELETE FROM {_queryTable}");
            else
                return ($"DELETE FROM {_queryTable} WHERE {_deleteQueryFilter}");
        }

    }
}