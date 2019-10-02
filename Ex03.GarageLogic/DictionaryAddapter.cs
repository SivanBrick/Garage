using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.VehicleCreation;

namespace Ex03.GarageLogic
{
   public class DictionaryAddapter
    {

        public static Dictionary<string, string> AditionalInfo(eVehicleType i_VehicleType)
        {
            Dictionary<string, string> aditionalInfo = null;

            if (i_VehicleType == eVehicleType.ElectricCar || i_VehicleType == eVehicleType.RegularCar)
            {

                aditionalInfo = generalCarInfo(i_VehicleType);
            }

            if (i_VehicleType == eVehicleType.ElectricMotorcycle || i_VehicleType == eVehicleType.RegularMotorcycle)
            {
                aditionalInfo = generalMotorcycleInfo(i_VehicleType);
            }

            if (i_VehicleType == eVehicleType.Truck)
            {
                aditionalInfo = generalTruckInfo();
            }

            return aditionalInfo;

        }


        private static Dictionary<string, string> generalCarInfo(eVehicleType i_VehicleType)
        {
            string color = string.Empty;
            string numOfDoor = string.Empty;
            Dictionary<string, string> carInfo = new Dictionary<string, string>() { { "Door Color", color }, { "Number Of Doors", numOfDoor } };

            return carInfo;
        }

        private static Dictionary<string, string> generalMotorcycleInfo(eVehicleType i_VehicleType)
        {
            string cc = string.Empty;
            string licenseType = string.Empty;
            Dictionary<string, string> motorcycleInfo = new Dictionary<string, string>() { { "Engine Volume", cc }, { "License Type", licenseType } };

            return motorcycleInfo;
        }
        
        private static Dictionary<string, string> generalTruckInfo()
        {
            string danguroesMatiriels = string.Empty;
            string cargoVolume = string.Empty;
            Dictionary<string, string> truckInfo = new Dictionary<string, string>() { { "Danguroes Matiriels", danguroesMatiriels }, { "Cargo Volume", cargoVolume } };

            return truckInfo;
        }
    }
}
