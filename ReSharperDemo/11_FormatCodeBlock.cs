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

            //Ctrl+Alt+J
            Console.WriteLine(message);
            Console.WriteLine(message);
        }
    }
}