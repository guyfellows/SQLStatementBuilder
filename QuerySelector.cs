using System;

namespace SQLStatementBuilder
{
    public class QuerySelector : QueryBuilder
    {
        static private string _selectQueryColumn;
        static private string _selectQueryFilter;

        public static string BuildSelectQuery()
        {
            SetQueryTable();
            SetSelectQueryColumn();
            SetSelectQueryFilter();
            return ReturnCompletedSelectQuery();
        }
        private static void SetSelectQueryColumn()
        {
            while (true)
            {
                System.Console.WriteLine("What column(s) would you like to read data from? Add columns as a comma separated list:");
                var userColumnInput = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(userColumnInput))
                    System.Console.WriteLine("!!YOU MUST ENTER THE NAME OF A COLUMN!!");
                else
                {
                    _selectQueryColumn = userColumnInput;
                    return;
                }
            }
        }
        private static void SetSelectQueryFilter()
        {
            System.Console.WriteLine("What filter would you like to use in the query:");
            _selectQueryFilter = Console.ReadLine();
        }

        private static string ReturnCompletedSelectQuery()
        {
            if (String.IsNullOrWhiteSpace(_selectQueryFilter))
                return ($"SELECT {_selectQueryColumn} FROM {_queryTable}");
            else
                return ($"SELECT {_selectQueryColumn} FROM {_queryTable} WHERE {_selectQueryFilter}");
        }
    }
}
