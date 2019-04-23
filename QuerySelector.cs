using System;

namespace SQLStatementBuilder
{
    public class QuerySelector : QueryBuilder
    {
        public void BuildSelectQuery()
        {
            SetQueryTable();
            SetQueryColumn();
            SetQueryFilter();
            SaveCompletedSelectQuery();
        }

        private void SaveCompletedSelectQuery()
        {
            if (String.IsNullOrWhiteSpace(_queryFilter))
            {
                var newSaveQuery = new QuerySaver();
                newSaveQuery.SaveCompletedQuery("SELECT", ($"SELECT {_queryColumn} FROM {_queryTable}"));
            }
            else
            {
                var newSaveQuery = new QuerySaver();
                newSaveQuery.SaveCompletedQuery("SELECT", ($"SELECT {_queryColumn} FROM {_queryTable} WHERE {_queryFilter}"));
            }
        }
    }
}
