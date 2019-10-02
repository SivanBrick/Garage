using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.ConsoleUI
{
    class FillUpEnergyUI
    {
        public static void FuelVehical(Garage i_MyGarage)
        {

            string userAnswer = string.Empty;
            string licenseNum = GarageUI.AskForLicenseNum();
            bool validFuel = !true;
            eFuel fuelType = 0;

            Console.WriteLine("Please enter fuel type <Octan98, Octan96, Octan95, Soler>");
            while (!validFuel)
            {
                try
                {
                    validFuel = true;
                    userAnswer = Console.ReadLine();
                    fuelType = UIValidation.FuelTypeValidation(userAnswer);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message + "Wrong choise, please select fuel type <Octan98, Octan96, Octan95, Soler> ");
                    validFuel = !true;
                }
            }

            int fuelAmount = 0;

            Console.WriteLine("Please enter fuel amount");
            fuelAmount = GarageUI.AskForAmount();

            try
            {
                bool fuelSucceses = i_MyGarage.FuelingVehicle(licenseNum, fuelType, fuelAmount);
                Console.WriteLine("Fuel success \n");
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("The car is not in the garage \n");
            }
            catch (ArgumentException ax)
            {
                Console.WriteLine(ax.Message + "Fuel faild");
            }
            catch (ValueOutOfRangeException vor)
            {
                Console.WriteLine(vor.Message + "Fuel faild");
            }
        }

        public static void ChargeYourVehicle(Garage i_MyGarage)
        {

            string licenseNum = GarageUI.AskForLicenseNum();
            Console.WriteLine("How many minutes do you want to charge");
            int amountToCharge = GarageUI.AskForAmount();

            try
            {
                bool tryToCharge = i_MyGarage.ChargeTheVehicle(licenseNum, amountToCharge);
                Console.WriteLine("Charge success\n");
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message + "Charge faild \n");
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message + "Charge faild \n");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message + "Charge faild \n");
            }
        }
    }
}
