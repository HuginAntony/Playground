using System;

namespace ReSharperDemo
{
    public class StructuralSearchAndReplace
    {
        public void GetUtcTime()
        {
            var today = DateTime.Today;
        }

        public void FormatDateSouthAfrica()
        {
            var today = DateTime.Today.ToString("d");
        }
    }
}