using System;
using System.Collections.Generic;
using System.Text;

namespace SQLStatementBuilder
{
    public class QueryBuilder
    {
        protected string _queryTable;
        protected string _queryColumn;
        protected string _queryValues;
        protected string _queryFilter;

        protected InputOutput newQueryInputOutput = new InputOutput();

        protected void SetQueryTable()
        {
            while (true)
            {
                newQueryInputOutput.WriteStringOuput("What table would you like to use:");
                var userTableInput = newQueryInputOutput.ReadStringInput();
                if (String.IsNullOrWhiteSpace(userTableInput))
                    newQueryInputOutput.WriteStringOuput("!!YOU MUST ENTER THE NAME OF A TABLE!!");
                else if (userTableInput.Contains(" "))
                    newQueryInputOutput.WriteStringOuput("!!YOU MUST ENTER A SINGLE TABLE NAME (NO SPACES)!!");
                else
                {
                    _queryTable = userTableInput;
                    return;
                }
            }
        }
        protected void SetQueryColumn()
        {
            while (true)
            {
                newQueryInputOutput.WriteStringOuput("What column(s) would you like to use? Add columns as a comma separated list:");
                var userColumnInput = newQueryInputOutput.ReadStringInput();
                if (String.IsNullOrWhiteSpace(userColumnInput))
                    newQueryInputOutput.WriteStringOuput("!!YOU MUST ENTER THE NAME OF A COLUMN!!");
                else
                {
                    var scrubbedUserColumnInput = userColumnInput.Replace(" ", string.Empty);
                    _queryColumn = scrubbedUserColumnInput;
                    return;
                }
            }
        }
        protected void SetQueryFilter()
        {
            newQueryInputOutput.WriteStringOuput("What filter(s) would you like to use in the query:");
            _queryFilter = newQueryInputOutput.ReadStringInput();
        }

        protected void SetQueryValues()
        {
            string[] userQueryColumnInput = _queryColumn.Split(',');
            List<string> userValueOutput = new List<string>();
            foreach (string s in userQueryColumnInput)
            {
                while (true)
                {
                    newQueryInputOutput.WriteStringOuput($"What data would you like to use in {_queryTable}.{s}:");
                    var userValueInput = newQueryInputOutput.ReadStringInput();
                    if (userValueInput.Contains(","))
                        newQueryInputOutput.WriteStringOuput("Please enter a value without a comma");
                    else
                    {   var scubbedUserValueInput = userValueInput.Replace(" ", string.Empty);
                        var isValueNumeric = false;
                        if (String.IsNullOrEmpty(userValueInput))
                            userValueOutput.Add("NULL");
                        else if (isValueNumeric = int.TryParse(userValueInput, out int numbericOutputValue))
                            userValueOutput.Add(scubbedUserValueInput); //Should capture strictly numeric value without quotation for SQL processing; not infallible!!!
                        else
                            userValueOutput.Add("'" + scubbedUserValueInput + "'");
                        break;
                    }
                }
            }
            _queryValues = String.Join(", ", userValueOutput);
        }
    }
}