using System.Linq;

namespace ReSharperDemo
{
    //Navigate to overriding members
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

        public void PrintMessage()
        {
            for (int i = 0; i < NumOfPax; i++)
            {

                if (FrequentFlyer)
                    continue;

                if (!FrequentFlyer)
                    break;

                if (Total > 2000)
                    return;
            }

            var message = "After the for loop";
        }
    }

    public interface IBooking
    {
        void CreateBooking();
    }

    public class Booking : IBooking
    {
        public string GdsReference { get; set; }
        public int NumOfPax { get; set; }
        public decimal Total { get; set; }
        public bool FrequentFlyer { get; set; }

        //Navigate to member overloads
        //Left gutter states which interface is implemented
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

            //Highlight usages ot Total
            var newTotal = Total + 100;

            CreateBooking();

            Total = Total - CalculateDiscount();

            if (GdsReference != null)
            {
                Total = newTotal * 2;
            }

            return Total;
        }

        public virtual string GetLocation()
        {
            return "Here";
        }

        public void CallOtherMethods()
        {
            CalculateDiscount();
        }
    }
}