using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.FuelEngine;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    public class VehicleCreation
    {
        private readonly Dictionary<string, string> m_Parametres = null;
        private readonly eVehicleType m_Vehicletype;
        private string m_LicenceNum = string.Empty;
        private Wheel m_wheelType = null;
        private string m_ModelType = string.Empty;
        private Engine m_Engine= null;
        private float m_EnergyLeft = 0;
        private Vehicle m_vehicle = null;


        public VehicleCreation(Dictionary<string, string> i_Parametres, eVehicleType i_VehicleType)
        {
            this.m_Parametres = i_Parametres;
            this.m_Vehicletype = i_VehicleType;
            this.m_wheelType = createWheel();
            m_Parametres.TryGetValue("Model Type",out this.m_ModelType);
            string engineType;
            m_Parametres.TryGetValue("Engine Type", out engineType);
            m_Parametres.TryGetValue("Licence Number", out m_LicenceNum);
            this.m_Engine = createEngine(engineType);
            this.m_EnergyLeft = this.m_Engine.EnergyLeft / this.m_Engine.Capacity;
            

            if (i_VehicleType == eVehicleType.ElectricCar || i_VehicleType == eVehicleType.RegularCar)
            {

                createCar();
            }

            if (i_VehicleType == eVehicleType.ElectricMotorcycle || i_VehicleType == eVehicleType.RegularMotorcycle)
            {
                createMotorcycle();
            }

            if (i_VehicleType == eVehicleType.Truck)
            {
                createTruck();
            }
        }

        public Vehicle vehicle
        {
            get
            {
                return this.m_vehicle;
            }
        }

        public Dictionary<string, string> Parameters
        {
            get
            {
                return this.m_Parametres;
            }
        }

        private Engine createEngine(string i_EngineType) 
        {
            this.m_Parametres.TryGetValue("Amount Of Energy Left", out string AmountOfEnergyParse);
            float amountOfEnergy = float.Parse(AmountOfEnergyParse);
            
            this.m_Parametres.TryGetValue("Engine Capacity", out string engineCapacityParse);
            float energeyCapacity = float.Parse(engineCapacityParse);

            Engine engine = null;
            if (i_EngineType.Equals("Electric Engine"))
            {
                engine = new ElectricEngine(amountOfEnergy, energeyCapacity);
            }
            else
            {
                this.m_Parametres.TryGetValue("Fuel Kind", out string fuelTypeParse);
                Enum.TryParse<eFuel>(fuelTypeParse, out eFuel fuelType);
                engine = new FuelEngine(fuelType, amountOfEnergy, energeyCapacity);
            }
          
            return engine;
        }

        private Wheel createWheel()
        {
            string wheelManufacture;
            float wheelCurPressure;
            int maxAirPressure;
            this.m_Parametres.TryGetValue("Type Of Wheele", out wheelManufacture);
            this.m_Parametres.TryGetValue("Current Wheel Pressure", out string wheelCurPressureToParse);
            this.m_Parametres.TryGetValue("Maximal Air Pressure", out string maxAirPressureToParse);
            maxAirPressure = int.Parse(maxAirPressureToParse);
            wheelCurPressure =  float.Parse(wheelCurPressureToParse);
            Wheel wheel = new Wheel(wheelManufacture, wheelCurPressure, maxAirPressure);

            return wheel;
        }

        public void createMotorcycle()
        {
            string engineVolumeParse;
            this.m_Parametres.TryGetValue("Engine Volume", out engineVolumeParse);
            int engineVolume = int.Parse(engineVolumeParse);

            string lisenceTypeParse;
            this.m_Parametres.TryGetValue("License Type", out lisenceTypeParse);
            Enum.TryParse<eLicenseType>(lisenceTypeParse,out eLicenseType lisenceType);
            List<Wheel> wheelList = Wheel.CreateWheelList(2, this.m_wheelType);

            m_vehicle = new Motorcycle(m_ModelType, wheelList, m_EnergyLeft, m_Engine, lisenceType, engineVolume, m_LicenceNum);
        }

        public void createCar()
        {
            string numberOfDoorsParse;
            this.m_Parametres.TryGetValue("Number Of Doors", out numberOfDoorsParse);
            int numberOfDoors = int.Parse(numberOfDoorsParse);

            string doorColoreParse;
            this.m_Parametres.TryGetValue("Door Color", out doorColoreParse);
            Enum.TryParse<eDoorsColor>(doorColoreParse, out eDoorsColor doorsColor);
            List<Wheel> wheelList = Wheel.CreateWheelList(4, this.m_wheelType);

            m_vehicle = new Car(m_ModelType, wheelList, m_EnergyLeft, m_Engine, doorsColor, numberOfDoors, m_LicenceNum);

        }

        public void createTruck()
        {
            bool dangerousMaterials;
            string dangerousMaterialsParse;
            this.m_Parametres.TryGetValue("Danguroes Matiriels", out dangerousMaterialsParse);
            dangerousMaterials = dangerousMaterialsParse.ToLower().Equals("true");

            float cargoVolume;
            string cargoVolumeParse;
            this.m_Parametres.TryGetValue("Cargo Volume", out cargoVolumeParse);
            float.TryParse(cargoVolumeParse, out cargoVolume);

            List<Wheel> wheelList = Wheel.CreateWheelList(12, this.m_wheelType);

            m_vehicle = new Truck(m_ModelType, wheelList, m_EnergyLeft, m_Engine, dangerousMaterials, cargoVolume, m_LicenceNum);
        }

        public static void AddSpecInfo(eVehicleType i_vehicleType, Dictionary<string, string> i_Parameteres)
        {
            switch (i_vehicleType)
            {
                case eVehicleType.Truck:
                    i_Parameteres.Add("Engine Type", "Fuel Engine");
                    i_Parameteres.Add("Maximal Air Pressure", "26");
                    i_Parameteres.Add("Engine Capacity", "110");
                    i_Parameteres.Add("Fuel Kind", "Soler");
                    break;
                case eVehicleType.RegularMotorcycle:
                    i_Parameteres.Add("Engine Type", "Fuel Engine");
                    i_Parameteres.Add("Maximal Air Pressure", "33");
                    i_Parameteres.Add("Engine Capacity", "8");
                    i_Parameteres.Add("Fuel Kind", "Octan95");
                    break;

                case eVehicleType.ElectricMotorcycle:
                    i_Parameteres.Add("Engine Type", "Electric Engine");
                    i_Parameteres.Add("Maximal Air Pressure", "33");
                    i_Parameteres.Add("Engine Capacity", "1.8");
                    break;

                case eVehicleType.RegularCar:
                    i_Parameteres.Add("Engine Type", "Fuel Engine");
                    i_Parameteres.Add("Maximal Air Pressure", "31");
                    i_Parameteres.Add("Engine Capacity", "55");
                    i_Parameteres.Add("Fuel Kind", "Octan96");
                    break;
                case eVehicleType.ElectricCar:
                    i_Parameteres.Add("Engine Type", "Electric Engine");
                    i_Parameteres.Add("Maximal Air Pressure", "31");
                    i_Parameteres.Add("Engine Capacity", "1.8");
                    break;
            }
        }

        public enum eVehicleType
        {
            RegularMotorcycle, RegularCar, ElectricMotorcycle, ElectricCar, Truck
        }


    }
}







