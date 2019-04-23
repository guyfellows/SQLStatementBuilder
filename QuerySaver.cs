using System;
using System.IO;

namespace SQLStatementBuilder
{
    public class QuerySaver
    {
        InputOutput newQuerySaverInputOutput = new InputOutput();
        public void SaveCompletedQuery(string queryType, string completedQuery)
        {
            newQuerySaverInputOutput.WriteStringOuput($"The completed query is: {completedQuery}");
            File.WriteAllText($"C:\\temp\\{queryType}.{DateTime.Now.ToString("MMddyyyy.HHmmss")}.sql",completedQuery);
            newQuerySaverInputOutput.WriteStringOuput("The query has been saved successfully. Please press any key to close this window");
            Console.ReadKey();
            return;
        }
    }
}