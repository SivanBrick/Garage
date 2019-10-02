using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.FuelEngine;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GarageUI garage = new GarageUI();
            garage.GargeOpen();
        }
    }
}
