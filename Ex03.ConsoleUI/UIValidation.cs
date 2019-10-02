using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.ConsoleUI
{
    class UIValidation
    {

        public static eFuel FuelTypeValidation(string i_FuelType)
        {
            eFuel fuelType;
            bool isValid = Enum.TryParse(i_FuelType , out fuelType);

            if (!isValid)
            {
                throw new FormatException("Fuel type doesnt exist");
            }

            return fuelType;
        }

        public static bool IsANumberValidation(string i_LicensNumber)
        {
            long numOfLicens = 0;
            bool isValid = long.TryParse(i_LicensNumber, out numOfLicens);

            if (!isValid)
            {
                throw new FormatException("This is not a number");
            }

            return isValid;
        }

        public static int EnergyAmount(string i_EnergyAmount)
        {
            int energyAmount = 0;
            bool isValid = int.TryParse(i_EnergyAmount, out energyAmount);

            if (!isValid)
            {
                throw new FormatException("Invalid Input, amount contain only digit");
            }

            return energyAmount;
        }

        public static string UserStringValidation(string i_UserName)
        {
            bool isValid = true;

            for (int i = 0; i < i_UserName.Length; i++)
            {
                if (!Char.IsLetter(i_UserName[i]))
                {
                    isValid = false;
                }
            }

            if (!isValid)
            {
                throw new FormatException("Invalid Input, name contain only letter");
            }

            return i_UserName;
        }

    }
}
