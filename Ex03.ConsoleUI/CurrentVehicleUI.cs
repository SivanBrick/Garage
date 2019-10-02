using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class CurrentVehiclesUI
    {
        public static void GetCurrentVehiclesUI(Garage i_MyGarage)
        {
            string carSituation = string.Empty;
            Console.WriteLine("which vehicles status do you want? \n" +
                "1 - Repire \n" +
                "2 - Fixed \n" +
                "3 - Paid \n" +
                "4 - All \n " +
                "please chose a number");
            string userAnswer = Console.ReadLine();
            int userChoise = 0;
            bool tryToParse = int.TryParse(userAnswer, out userChoise);

            while (!tryToParse || tryToParse && !(userChoise > 0 && userChoise < 5))
            {
                Console.WriteLine("You enter wrong choise , please chose a number 1-4: ");
                userAnswer = Console.ReadLine();
                tryToParse = int.TryParse(userAnswer, out userChoise);
            }

            Console.Clear();

            switch (userChoise)
            {
                case 1:
                    carSituation = "Repair";
                    break;
                case 2:
                    carSituation = "Fixed";
                    break;
                case 3:
                    carSituation = "Paid";
                    break;
                case 4:
                    carSituation = "default";
                    break;
            }

            List<string> currentVehicles = i_MyGarage.GetCurrentVehicleInGarage(carSituation);

            if (currentVehicles.Count == 0)
            {
                if (carSituation.Equals("default"))
                {
                    Console.WriteLine("There is no vehicle in the garage \n");
                }
                else
                {
                    Console.WriteLine("There is no vehicle in this condition in the garage \n");
                }
                
            }
            else
            {
                Console.WriteLine("The vehicles in the garage : " + string.Join(",", currentVehicles));
            }
        }

        public static void GetVehicleInformation(Garage i_MyGarage)
        {
            string licenseNumber = GarageUI.AskForLicenseNum();
            string vehicleInformation = string.Empty;

            try
            {
                vehicleInformation = i_MyGarage.GetVehicleInformation(licenseNumber);
                Console.WriteLine(vehicleInformation);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
        }
    }
}
