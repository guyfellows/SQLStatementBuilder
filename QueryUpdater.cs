using System;

namespace SQLStatementBuilder
{
    public class QueryUpdater : QueryBuilder
    {

        public void BuildUpdateQuery()
        {
            SetQueryTable();
            SetQueryColumn();
            SetQueryValues();
            SetQueryFilter();
            SaveCompleteUpdateQuery();
        }
        private void SaveCompleteUpdateQuery()
        {
            if (String.IsNullOrWhiteSpace(_queryFilter))
            {
                var newSaveQuery = new QuerySaver();
                newSaveQuery.SaveCompletedQuery("UPDATE", $"UPDATE {_queryTable} SET {_queryValues}");
            }
            else
            {
                var newSaveQuery = new QuerySaver();
                newSaveQuery.SaveCompletedQuery("UPDATE", $"UPDATE {_queryTable} SET {_queryValues} WHERE {_queryFilter}");
            }
        }

    }

}