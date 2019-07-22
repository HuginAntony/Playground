using System;

namespace ReSharperDemo
{
    public class FormatCodeBlock
    {
        public string DisplayMessage(string name, string message)
        {
            if (name == null) name = "Name cannot be null";
            if (message == null) message = "Message cannot be null";
            return $"{message}, {name}!";
        }

        public void SurroundWithQuotes()
        {
            const string message = "This is the message";

            //Create custom surround with template using ReSharper. Ctrl+Alt+J select Quotes.
            //Visual Studio requires multiple lines of XML to create a simple snippet
            Console.WriteLine(message);
            Console.WriteLine(message);
        }
    }
}