using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SQLStatementBuilder
{
    public class QuerySaver
    {
        public static void SaveCompletedQuery(string queryType, string completedQuery)
        {
            File.WriteAllText($"C:\\temp\\{queryType}.{DateTime.Now.ToString("MMddyyyy.HHmmss")}.sql",completedQuery);
            System.Console.WriteLine("The query has been saved successfully.");
        }
    }
}