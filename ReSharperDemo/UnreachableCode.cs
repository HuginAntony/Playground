namespace ReSharperDemo
{
    class UnreachableCode
    {
        public string FizzBuzzUnreachableCode(int i)
        {
            //Extract to variable. Ctrl+Alt+V. Then move unreachable code up

            if (i % 3 == 0)
                return "Fizz";

            if (i % 5 == 0)
                return "Buzz";

            if (i % 3 == 0 && i % 5 == 0)
                return "FizzBuzz";

            return null;
        }
    }
}