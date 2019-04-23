using System;

namespace SQLStatementBuilder
{
    public class InputOutput
    {
        public ConsoleKeyInfo ReadKeyInput()
        {
            return Console.ReadKey();
        }
        public string ReadStringInput()
        {
            return Console.ReadLine();
        }
        public void WriteStringOuput(string writeOutput)
        {
            Console.WriteLine(writeOutput);
        }
    }
}
