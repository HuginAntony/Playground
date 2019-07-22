using System.Text.RegularExpressions;

namespace ReSharperDemo
{
    class RegurlarExpressions
    {
        public void RegularExpressions()
        {
            //Open the Validate regular expression window by pressing Alt+Enter
            var regex = Regex.Match("uuiwfw", @"[a-z]\d{3}");

            //Auto detects group names. Type r.Group and see smart completion with "name"
            var r = Regex.Match("uuiwfw", @"(?<name>)");
            
        }
    }
}