using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_NameOfManufacturer = string.Empty;
        private float m_CurrentAirPressure = 0;
        private float m_MaximalAirPressure = 0;

        public Wheel(string i_NameOfManufacturer, float i_CurrentAirPressure, float i_MaximalAirPressure = 0)
        {
            this.m_NameOfManufacturer = i_NameOfManufacturer;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.m_MaximalAirPressure = i_MaximalAirPressure;
        }

        public void FillAirPressure(float i_Air_pressure_to_blow)
        {
            float totalAirPressureAfterBlowing = i_Air_pressure_to_blow + this.m_CurrentAirPressure;

            if (!(totalAirPressureAfterBlowing > this.m_MaximalAirPressure))
            {
                this.m_CurrentAirPressure = totalAirPressureAfterBlowing;
            }

        }
        

        public string NameOfManufacturer
        {
            get
            {
                return this.m_NameOfManufacturer;
            }
            set
            {
                this.m_NameOfManufacturer = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return this.m_CurrentAirPressure;
            }
            set
            {
                this.m_CurrentAirPressure = value;
            }
        }

        public float MaximalAirPressure
        {
            get
            {
                return this.m_MaximalAirPressure;
            }
            set
            {
                this.m_MaximalAirPressure = value;
            }
        }

        public static List<Wheel> CreateWheelList(int i_numOfWheels, Wheel i_Wheel)
        {
            List<Wheel> ListOfWheels = new List<Wheel>();

            for (int i = 0; i < i_numOfWheels; i++)
            {
                Wheel add = new Wheel(i_Wheel.NameOfManufacturer, i_Wheel.CurrentAirPressure, i_Wheel.MaximalAirPressure);
                ListOfWheels.Add(add);
            }

            return ListOfWheels;
        }
    }

}

