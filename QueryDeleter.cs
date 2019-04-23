using System;

namespace SQLStatementBuilder
{
    public class QueryDeleter : QueryBuilder
    {
        public void BuildDeleteQuery()
        {
            SetQueryTable();
            SetQueryFilter();
            SaveCompleteDeleteQuery();
        }
        private void SaveCompleteDeleteQuery()
        {
            if (String.IsNullOrWhiteSpace(_queryFilter))
            {
                var newSaveQuery = new QuerySaver();
                newSaveQuery.SaveCompletedQuery("DELETE", ($"DELETE FROM {_queryTable}"));
            }
            else
            {
                var newSaveQuery = new QuerySaver();
                newSaveQuery.SaveCompletedQuery("DELETE", ($"DELETE FROM {_queryTable} WHERE {_queryFilter}"));
            }
        }
    }
}