using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A, A1, A2, B
        }

        private int m_EngineVolume = 0;
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_ModelName , List<Wheel> i_WheelList , float i_EnergyPercent , Engine i_Engine,
            eLicenseType i_type, int i_EngineCapacity, string i_LicenseNumber = "default") 
            : base(i_ModelName, i_WheelList, i_EnergyPercent , i_Engine, i_LicenseNumber)
        {
            this.m_EngineVolume = i_EngineCapacity;
            this.m_LicenseType = i_type;
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                this.m_EngineVolume = value;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return this.m_LicenseType;
            }
            set
            {
                this.m_LicenseType = value;
            }
        }
    }
}
