﻿using ReSharperDemo;

public class Flights
{
    public void CallEmirates()
    {
        var emirates = new Emirates();

        emirates.GetLocation();
        emirates.CalculateReward();

        //Ctrl+Space x2 will find the Controller reference from the CoreMvcWebsite project and import it
        //Controller

        //Invoke quick info by pressing Ctrl+Q on the class and the method name
        var mango = new Mango();
        mango.FlightInfo("JE", true);
    }
}