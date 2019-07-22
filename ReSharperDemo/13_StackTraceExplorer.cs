using System;

namespace ReSharperDemo
{
    public class StackTraceExplorer
    {
        //Call this method and an exception is thrown. Copy the exception to the clipboard
        //Press Ctrl+Shift+E to invoke the StackTrace Explorer
        public static int GetNumber()
        {
            var n = 0;
            var ans = 10 / n;

            return ans;
        }
    }
}