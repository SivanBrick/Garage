using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.VehicleCreation;

namespace Ex03.ConsoleUI
{
    public class EnterNewCar
    {
        public static void EnterNewCarUI(Garage i_MyGarage)
        {
            Vehicle userVehicle = SetNewVehicle();
            bool validName = true;
            string ownerName = string.Empty;
            Console.WriteLine("please enter your name:");

            while (validName)
            {
                try
                {
                    validName = !true;
                    ownerName = Console.ReadLine();
                    ownerName = UIValidation.UserStringValidation(ownerName);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                    validName = true;
                }
            }

            bool validPhone = true;
            string phoneNumber = string.Empty;

            Console.WriteLine("please enter your Phone number:");
            while (validPhone)
            {
                try
                {
                    validPhone = !true;
                    phoneNumber = Console.ReadLine();
                    UIValidation.IsANumberValidation(phoneNumber);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                    validPhone = true;
                }
            }

            bool carInGarage = i_MyGarage.EnterNewCar(ownerName, phoneNumber, userVehicle);

            if (!carInGarage)
            {
                Console.WriteLine("Your vehicle is already in the garage \n");
            }
            else
            {
                Console.WriteLine("Thank you, now your car is in the garage \n");
            }

        }

        public static Vehicle SetNewVehicle()
        {
            string vehicle = string.Empty;
            Dictionary<string, string> parametrs = new Dictionary<string, string>();
            string currentWheelPressure = string.Empty;
            string currentEnergy = string.Empty;
            string licenseNumber = string.Empty;
            string typeOfWheel = string.Empty;
            string modelType = string.Empty;
            bool validationFlag = !true;

            System.Console.WriteLine("Hello! Please enter your vehicle type, those are the vehicle we support:");
            int i = 0;

            foreach (eVehicleType type in Enum.GetValues(typeof(eVehicleType)))
            {
                System.Console.WriteLine("* For " + type.ToString() + " Press " + i);
                i++;
            }

            while (!validationFlag)
            {
                try
                {
                    vehicle = System.Console.ReadLine();
                    validationFlag = Validation.TypeOfVehicle(vehicle);
                }
                catch (ArgumentException e)
                {
                    validationFlag = false;
                    System.Console.WriteLine(e.Message);
                }
            } 

            validationFlag = !true;
            parametrs.Add("Vehicle Type", vehicle.ToString());
            Enum.TryParse<eVehicleType>(vehicle, out eVehicleType eVehicle);
            VehicleCreation.AddSpecInfo(eVehicle, parametrs);

            System.Console.WriteLine("Please enter your number of license:");

            while (!validationFlag)
            {
                try
                {
                    licenseNumber = System.Console.ReadLine();
                    validationFlag = UIValidation.IsANumberValidation(licenseNumber);
                }
                catch (FormatException e)
                {
                    validationFlag = false;
                    System.Console.WriteLine(e.Message);
                }
            }
            validationFlag = !true;
            Console.Clear();
            parametrs.Add("Licence Number", licenseNumber);

            System.Console.WriteLine("Please enter the current pressure in your wheele:");

            while (!validationFlag)
            {
                try
                {
                    parametrs.TryGetValue("Maximal Air Pressure", out string maxAirPressue);
                    validationFlag = Validation.RangeValidation(currentWheelPressure = System.Console.ReadLine(), maxAirPressue);
                }
                catch (ArgumentException e)
                {
                    validationFlag = !true;
                    System.Console.WriteLine(e.Message);
                }
            }

            validationFlag = !true;
            parametrs.Add("Current Wheel Pressure", currentWheelPressure);

            System.Console.WriteLine("Please enter the type of the wheele:");

            while (!validationFlag)
            {
                try
                {
                    typeOfWheel = UIValidation.UserStringValidation(System.Console.ReadLine());
                    validationFlag = true;
                }
                catch (FormatException e)
                {
                    validationFlag = !true;
                    System.Console.WriteLine(e.Message);
                }
            }

            validationFlag = !true;
            parametrs.Add("Type Of Wheele", typeOfWheel);

            System.Console.WriteLine("Please enter your current amount of eneregy left (Whether it's an" +
                " electric or a fuel engine):");

            while (!validationFlag)
            {
                try
                {
                    parametrs.TryGetValue("Engine Capacity", out string engineCapacity);
                    validationFlag = Validation.RangeValidation(currentEnergy = System.Console.ReadLine(), engineCapacity);
                }
                catch (ArgumentException e)
                {
                    validationFlag = !true;
                    System.Console.WriteLine(e.Message);
                }
            }

            validationFlag = !true;
            parametrs.Add("Amount Of Energy Left", currentEnergy);

            System.Console.WriteLine("Please enter the model of your car:");

            while (!validationFlag)
            {
                try
                {
                    modelType = UIValidation.UserStringValidation(System.Console.ReadLine());
                    validationFlag = true;
                }
                catch (FormatException e)
                {
                    validationFlag = !true;
                    System.Console.WriteLine(e.Message);
                }
            }

            parametrs.Add("Model Type", modelType);
            parametrs = expendVehicleParameter(eVehicle, parametrs);
            VehicleCreation vehicleBuilder = new VehicleCreation(parametrs, eVehicle);
            Vehicle newVehicle = vehicleBuilder.vehicle;

            return newVehicle;
        }

        private static Dictionary<string, string> expendVehicleParameter(eVehicleType i_VehicleType, Dictionary<string, string> i_Parameters)
        {
            Dictionary<string, string> aditionalInfo = DictionaryAddapter.AditionalInfo(i_VehicleType);
            bool validationFlag = !true;

            while (!validationFlag)
            {
                foreach (KeyValuePair<string, string> info in aditionalInfo)
                {
                    System.Console.WriteLine(info.Key.ToString() + "?");
                    i_Parameters[info.Key] = System.Console.ReadLine();
                }
                try
                {
                    validationFlag = Validation.SpecValidation(i_VehicleType, i_Parameters);
                }
                catch (Exception e)
                {
                    validationFlag = !true;
                    System.Console.WriteLine(e.Message);
                }
            }

            return i_Parameters;
        }
    }
}
