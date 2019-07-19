using System.Text.RegularExpressions;

namespace ReSharperDemo
{
    class RegurlarExpressions
    {
        public void RegularExpressions()
        {
            //Open the Validate regular expression window
            var regex = Regex.Match("uuiwfw", @"[a-z]\d{3}");

            //Auto detects group names
            var r = Regex.Match("uuiwfw", @"(?<name>)");

        }
    }
}