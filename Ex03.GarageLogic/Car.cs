using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eDoorsColor
        {
            Red, Blue, Black, Gray    
        }

        private eDoorsColor m_DoorsColor;
        private int m_NumberOfDoors = 0;

        public Car(string i_ModelName,
            List<Wheel> i_WheelList, float i_EnergyPercent, Engine i_Engine, eDoorsColor i_DoorsColor, int i_numOfDoors , string i_LicenseNumber = "default")
            : base(i_ModelName, i_WheelList, i_EnergyPercent, i_Engine , i_LicenseNumber)
        {
            this.m_DoorsColor = i_DoorsColor;
            this.m_NumberOfDoors = i_numOfDoors;
        }

        public int NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                if (value > 5 || value < 2)
                {
                    throw new ValueOutOfRangeException(2, 5);
                }
                this.m_NumberOfDoors = value;
            }
        }
    }
}
