using System.Linq;

namespace ReSharperDemo
{
    class Emirates : Booking
    {
        public string AssignRandomSeating(int i)
        {
            //Extract to variable. Ctrl+Alt+V. Then move unreachable code up

            if (i % 3 == 0)
                return "A2";

            if (i % 5 == 0)
                return "B2";

            if (i % 3 == 0 && i % 5 == 0)
                return "F5";

            return "A1";
        }

        public override decimal CalculateDiscount()
        {
            return Total * 1.2m;
        }

        public override string GetLocation()
        {
            return "Emirates" + base.GetLocation();
        }
    }

    class SAA : Booking
    {
        public override decimal CalculateDiscount()
        {
            return Total * 1.2m;
        }

        public override string GetLocation()
        {
            return "Emirates" + base.GetLocation();
        }
    }

    public class Booking
    {
        public string GdsReference { get; set; }
        public int NumOfPax { get; set; }
        public decimal Total { get; set; }
        public bool FrequentFlyer { get; set; }

        public void CreateBooking()
        {
            GdsReference = "JD67HD";
        }

        public void CreateBooking(int num)
        {
            GdsReference = "JD67HD" + num;
        }

        public void CreateBooking(int num, string name)
        {
            GdsReference = "JD67HD" + name + num;
        }

        public virtual decimal CalculateDiscount()
        {
            //Can do Complete statement
            if (FrequentFlyer)
            {
                return Total * 1.1m;
            }

            return Total;
        }

        public virtual string GetLocation()
        {
            return "Here";
        }
    }
}