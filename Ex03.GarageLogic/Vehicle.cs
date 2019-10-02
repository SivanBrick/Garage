using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName = string.Empty;
        private string m_LicenseNumber = string.Empty;
        private float m_EnergyPercent = 0;
        private List<Wheel> m_WheelList = new List<Wheel>();
        private Engine m_Engine = null;
            
        public Vehicle(string i_ModelName, List<Wheel> i_Wheel, float i_currentEnergy , Engine i_Engine, string i_LicenseNumber = "default")
        {
            this.m_ModelName = i_ModelName;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_EnergyPercent = (i_currentEnergy / i_Engine.Capacity) * 100;
            this.m_WheelList = i_Wheel;
            this.m_Engine = i_Engine;
        }

        public string ModelName
        {
            get
            {
                return this.m_ModelName;
            }
            set
            {
                this.m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;
            }
            set
            {
                this.m_LicenseNumber = value;
            }
        }

        public float EnergyPercent
        {
            get
            {
                return this.m_EnergyPercent;
            }
            set
            {
                this.m_EnergyPercent = value;
            }
        }

        public List<Wheel> WheelList
        {
            get
            {
                return this.m_WheelList;
            }
            set
            {
                this.m_WheelList = value;
            }
        }

        public Engine VehicleEngine
        {
            get
            {
                return this.m_Engine;
            }
            set
            {
                this.m_Engine = value;
            }
        } 

    }
    
}
