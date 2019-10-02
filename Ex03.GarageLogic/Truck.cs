using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_DangerousMaterials = !true;
        private float m_CargoVolume = 0;

        public Truck(string i_ModelName,
            List<Wheel> i_WheelList, float i_EnergyPercent, Engine i_Engine, bool i_DangerousMaterials,
            float i_CargoVolume, string i_LicenseNumber = "default")
            : base(i_ModelName,i_WheelList, i_EnergyPercent, i_Engine, i_LicenseNumber)
        {
            this.m_DangerousMaterials = i_DangerousMaterials;
            this.m_CargoVolume = i_CargoVolume;
        }

        public bool DangerousMaterials
        {
            get
            {
                return this.m_DangerousMaterials;
            }
            set
            {
                this.m_DangerousMaterials = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return this.m_CargoVolume;
            }
            set
            {
                this.m_CargoVolume = value;
            }
        }

    }
}
