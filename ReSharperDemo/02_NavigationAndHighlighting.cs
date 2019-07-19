using System.Linq;

namespace ReSharperDemo
{
    //Navigate to overriding members
    public class Emirates : Booking
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

        //Alt+` navigate to base symbols.
        public override decimal CalculateDiscount()
        {
            return Total * 1.2m;
        }

        public decimal CalculateReward()
        {
            return Total * 1.2m;
        }

        public override string GetLocation()
        {
            return "Emirates" + base.GetLocation();
        }

        public void GetLatitude()
        {

        }

        public void GetLongitude()
        {
            
        }
    }

    //Navigate to overriding members
    //Navigate to Extension Methods. See .ToXml() which is custom to this project
    public class SAA : Booking
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

                //Invoke the Navigate To menu and select Control Flow on each of the for loop keywords below
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

    //Navigate to Derived Symbols
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
            //Perform Complete statement by typing the first few characters of the if statement below. Then Ctrl+Shift+Enter
            if (FrequentFlyer)
            {
                return Total * 1.1m;
            }

            //Invoke Highlight Usages of Total. Place the cursor on Total below and press Ctrl+Shift+F7
            //See read and write usages highlighted in different colours
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

    /// <summary>
    /// This class needs to be implemented
    /// </summary>
    /// <remarks>
    /// <para>You can add your own implementation</para>
    /// <para>similar to the Emirates class</para>
    /// </remarks>
    /// <seealso cref="Emirates"/>
    class Mango : Booking
    {

        /// <summary>
        /// Gets the detailed flight information
        /// </summary>
        /// <param name="carrier">The 2 letter carrier code</param>
        /// <param name="log">Enable logging</param>
        /// <returns>Flight information if the operation completes successfully</returns>
        public string FlightInfo(string carrier, bool log)
        {
            return "";
        }
    }
}