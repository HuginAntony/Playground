using System;

namespace ReSharperDemo
{
    public class StructuralSearchAndReplace
    {
        public void GetUtcTime()
        {
            //Invoke Structural Search, type DateTime.Today and click on Find. See usages of DateTime.Today
            var today = DateTime.Today;
        }

        public void FormatDateSouthAfrica()
        {
            var today = DateTime.Today.ToString("d");
        }
    }
}