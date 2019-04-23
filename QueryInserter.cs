using System;

namespace SQLStatementBuilder
{
    public class QueryInserter : QueryBuilder
    {
        public void BuildInsertQuery()
        {
            SetQueryTable();
            SetQueryColumn();
            SetQueryValues();
            SaveCompleteInsertQuery();
        }
        private void SaveCompleteInsertQuery()
        {
            var newSaveQuery = new QuerySaver();
            newSaveQuery.SaveCompletedQuery("INSERT", $"INSERT INTO {_queryTable} ({_queryColumn}) VALUES ({_queryValues})");
        }
    }
}