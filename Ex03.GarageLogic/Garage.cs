using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
     public class Garage
    {
        private Dictionary<string, UserDetails> m_GarageList = new Dictionary<string, UserDetails>();

        public enum eCarCondition
        {
            Repair,
            Fix,
            Paid
        }

        public bool VehicleInGarage(string i_LicenseNumber)
        {
            bool inGarage = m_GarageList.ContainsKey(i_LicenseNumber);

            return inGarage;
        }

        public bool EnterNewCar(string i_OwnerName , string i_PhoneNumber , Vehicle i_Vehicle)  
        {
            string vehicleCondition = eCarCondition.Repair.ToString();
            string licenseNumber = i_Vehicle.LicenseNumber;
            bool itsNewVehicle = true;

            if (!VehicleInGarage(licenseNumber))
            {
                UserDetails newUser = new UserDetails(i_OwnerName, i_PhoneNumber, i_Vehicle, vehicleCondition);
                m_GarageList.Add(licenseNumber, newUser);
            }
            else 
            {
                itsNewVehicle = !true;
                m_GarageList[licenseNumber].vehicleCondition = vehicleCondition;
            }

            return itsNewVehicle;
        }
        
        public List<string> GetCurrentVehicleInGarage(string i_VehicleCondition = "default")
        {
        
            List<string> currentVehicle = new List<string>();
            foreach (KeyValuePair<string, UserDetails> item in m_GarageList)
            {
                if (item.Value.vehicleCondition.Equals(i_VehicleCondition))
                {
                    currentVehicle.Add(item.Key);
                }
                else if (i_VehicleCondition == "default")
                {
                    currentVehicle.Add(item.Key);
                }
            }

            return currentVehicle;
        }
        
        public void ChangeVehicleCondition(string i_LicenseNumber, string i_Condition)
        {
            if (!VehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentNullException("This Vehicle doesn't exist in the garage \n");
            }

            UserDetails newConditionObj = m_GarageList[i_LicenseNumber];
            newConditionObj.vehicleCondition = i_Condition;
            m_GarageList[i_LicenseNumber] = newConditionObj;

        }

        public void FillUpTires(string i_LicenseNumber)
        {
            if (!VehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentNullException("This Vehicle doesn't exist in the garage \n");
            }

            UserDetails currentUserDetails = m_GarageList[i_LicenseNumber];
            Vehicle vehicleToBlow = currentUserDetails.Vehicle;
            List <Wheel> wheelToBlow = vehicleToBlow.WheelList;
            List<Wheel> afterBlowing = new List<Wheel>();

            foreach (Wheel wheel in wheelToBlow) {
                float maxPressure = wheel.MaximalAirPressure;
                float currentPressure = wheel.CurrentAirPressure;
                float toBlow = maxPressure - currentPressure;
                wheel.FillAirPressure(toBlow);
                afterBlowing.Add(wheel);
            }

            vehicleToBlow.WheelList = afterBlowing;
            currentUserDetails.Vehicle = vehicleToBlow;
            m_GarageList[i_LicenseNumber] = currentUserDetails;
        }

        public bool FuelingVehicle(string i_LicenseNumber, eFuel i_Fual, int i_AmountToFaul)
        {
            if (!VehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentNullException("This Vehicle doesn't exist in the garage \n");
            }

            UserDetails currentUserDetails = m_GarageList[i_LicenseNumber];
            Vehicle vehicleToFaul = currentUserDetails.Vehicle;
            Engine engineToFaul = vehicleToFaul.VehicleEngine;
            FuelEngine fuelEngine = engineToFaul as FuelEngine;
            

            if (fuelEngine == null)
            {
                throw new ArgumentException("This is not fuel car \n");
            }

            eFuel correctFuel = fuelEngine.FuelType;

            if (!correctFuel.Equals(i_Fual))
            {
                throw new ArgumentException("You entered wrong fuel type");
            }

            bool tryToFuel = fuelEngine.Fill(i_AmountToFaul, i_Fual);

            return tryToFuel;
        }

        public bool ChargeTheVehicle(string i_LicenseNumber, int i_AmountToCharge)
        {
            if (!VehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentNullException("This Vehicle doesn't exist in the garage \n");
            }

            UserDetails currentUserDetails = m_GarageList[i_LicenseNumber];
            Vehicle vehicleToCharge = currentUserDetails.Vehicle;
            Engine engineToCharge = vehicleToCharge.VehicleEngine;
            ElectricEngine electricEngine = engineToCharge as ElectricEngine;

            if (electricEngine == null)
            {
                throw new ArgumentException("This is not electric car \n");
            }

            bool tryToCharge = electricEngine.Fill((float)i_AmountToCharge /60);

            return tryToCharge;
        }

        public string GetVehicleInformation(string i_LicenseNumber)
        {
            if (!VehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentNullException("This Vehicle doesn't exist in the garage \n");
            }

            UserDetails userDetaile = m_GarageList[i_LicenseNumber];
            string nameOfModel = userDetaile.Vehicle.ModelName;
            string ownerName = userDetaile.UserName;
            string vehicleCondition = userDetaile.vehicleCondition;
            List<Wheel> listOfWheels = userDetaile.Vehicle.WheelList;
            int numOfWheels = listOfWheels.Count;
            string currentWheelSituation = GetWheelsInformation(listOfWheels);
            
            string vehicleInformation = string.Format("Information about vevhicle number {0} : \n" +
                "Model : {1} \nOwner Name : {2} \nCar Condition : {3} \nThere are {4} Wheels :\n" +
                "{5}",
                i_LicenseNumber, nameOfModel, ownerName , vehicleCondition , numOfWheels , currentWheelSituation.ToString());

            Vehicle currentVehicle = userDetaile.Vehicle;
            Engine currentEnginVehicle = currentVehicle.VehicleEngine;
            FuelEngine checkEngine = currentEnginVehicle as FuelEngine;

            string engineStatus = string.Empty;

            if (checkEngine == null)
            {
                ElectricEngine electricEngine = currentEnginVehicle as ElectricEngine;
                float energyLeft = electricEngine.EnergyLeft;
                engineStatus = string.Format("Battary statuse : {0} hours left\n", energyLeft);
            }
            else
            {
                eFuel kindOfFuel = checkEngine.FuelType;
                float energyLeft = checkEngine.EnergyLeft;
                engineStatus = string.Format("Fuel statuse : {0} , {1} liters left\n", kindOfFuel , energyLeft);
            }

            return vehicleInformation + engineStatus;
        }

        public string GetWheelsInformation(List<Wheel> i_ListOfWheels)
        {

            int Wheels = 1;
            StringBuilder currentWheelSituation = new StringBuilder();

            foreach (Wheel wheel in i_ListOfWheels)
            {
                float airPressure = wheel.CurrentAirPressure;
                string nameOfManufecture = wheel.NameOfManufacturer;
                string currentWheel = string.Format("Wheel number {0} : \nManufecture Name : {1} AirPressure : {2}\n",
                    Wheels, nameOfManufecture, airPressure);
                Wheels++;
                currentWheelSituation.Append(currentWheel);
            }

            return currentWheelSituation.ToString();
        }

    }
}
