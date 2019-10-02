using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.Motorcycle;
using static Ex03.GarageLogic.VehicleCreation;

namespace Ex03.GarageLogic
{
    public class Validation
    {
        public static bool TypeOfVehicle(string i_VehicleType)
        {
            eVehicleType tryToParse;
            bool vehicleType = Enum.TryParse<eVehicleType>(i_VehicleType, out tryToParse);
            if (!vehicleType)
            {
                throw new ArgumentException("This vehicle is not supported by our garage.");
            }
            return true;
        }

        public static bool RangeValidation(string i_CurArgument, string I_MaxValue)
        {
            float tryToParse;
            bool validPressure = float.TryParse(i_CurArgument, out tryToParse) && tryToParse < float.Parse(I_MaxValue);
            if (!validPressure)
            {
                throw new ArgumentException("Please enter a value benith " + I_MaxValue);
            }
            return true;
        }

        public static bool SpecValidation(eVehicleType i_VehicleType, Dictionary<string, string> i_SpecInfo)
        {
            bool isValid = true;
            StringBuilder msg = new StringBuilder();
            Exception e = new Exception();
            bool isNum = !true;

            switch (i_VehicleType)
            {
                case eVehicleType.Truck:
                    i_SpecInfo.TryGetValue("Cargo Volume", out string cargoVolumeParse);
                    i_SpecInfo.TryGetValue("Danguroes Matiriels", out string danguroesMatirielsParse);
                    if (!float.TryParse(cargoVolumeParse, out float parse))
                    {
                        isValid = !true;
                        msg.Append("Plase make sure you enter a valid number for Cargo volume. ");
                    }
                    if ((!(danguroesMatirielsParse.ToLower().Equals("false") || danguroesMatirielsParse.ToLower().Equals("true"))))
                    {
                        isValid = !true;
                        msg.Append("Choose (Flase / True) for Danguroes Matiriels");
                    }
                    e = new FormatException(msg.ToString());
                    break;
                case eVehicleType.ElectricCar:
                case eVehicleType.RegularCar:
                    i_SpecInfo.TryGetValue("Door Color", out string doorColorParse);
                    i_SpecInfo.TryGetValue("Number Of Doors", out string numberOfDoorsParse);
                    bool isEnum = Enum.TryParse(doorColorParse, out eDoorsColor parseDoor);
                    isNum = int.TryParse(doorColorParse, out int tryToParse);
                    int numOfExeption = 0;
                    if (!isEnum || isNum)
                    {
                        isValid = !true;
                        msg.Append("please choose a valid color. ");
                        foreach (eDoorsColor type in Enum.GetValues(typeof(eDoorsColor)))
                        {
                            msg.Append(type.ToString() + " ");
                        }
                        numOfExeption++;
                        msg.Append(".");
                        e = new FormatException(msg.ToString());
                    }
                    if (!(int.TryParse(numberOfDoorsParse, out int numOfdoors)) || numOfdoors > 5 || numOfdoors < 2)
                    {
                        isValid = !true;
                        e = new ValueOutOfRangeException(2, 5);
                        numOfExeption++;
                        msg.Append(e.Message);
                    }
                    if (numOfExeption == 2)
                    {
                        e = new FormatException(msg.ToString());
                    }
                    break;
                case eVehicleType.ElectricMotorcycle:
                case eVehicleType.RegularMotorcycle:
                    i_SpecInfo.TryGetValue("License Type", out string licenseTypeParse);
                    i_SpecInfo.TryGetValue("Engine Volume", out string ccParse);
                    isNum = int.TryParse(licenseTypeParse, out int tryToParseLicense);
                    if (!Enum.TryParse(licenseTypeParse, out eLicenseType parseLisence) || isNum)
                    {
                        isValid = !true;
                        msg.Append("please enter your license type. ");
                        foreach (Motorcycle.eLicenseType type in Enum.GetValues(typeof(Motorcycle.eLicenseType)))
                        {
                            msg.Append(type.ToString() + " ");
                        }
                        msg.Append(".");
                    }
                    if (!int.TryParse(ccParse, out int tryToparse))
                    {
                        isValid = !true;
                        msg.Append("Plase make sure you enter a valid number for engine volume. ");
                    }
                    e = new FormatException(msg.ToString());
                    break;
            }
            if (!isValid)
            {
                throw e;
            }

            return isValid;
        }
    }
}