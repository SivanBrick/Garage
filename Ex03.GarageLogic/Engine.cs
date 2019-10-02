using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_EnergyLeft = 0;
        private float m_Capacity = 0;

        public Engine(float i_EnergyType, float i_Capacity)
        {
            this.m_EnergyLeft = i_EnergyType;
            this.m_Capacity = i_Capacity;
        }

        public float EnergyLeft
        {
            get
            {
                return this.m_EnergyLeft;
            }
            set
            {
                this.m_EnergyLeft = value;
            }

        }
        public float Capacity
        {
            get
            {
                return this.m_Capacity;
            }
            set
            {
                this.m_Capacity = value;
            }
        }
    }

    public class FuelEngine : Engine
    {
        public eFuel fuelType;
        public enum eFuel
        {
            Octan98, Octan96, Octan95, Soler
        }

        public FuelEngine(eFuel i_FuelType, float i_EnergyLeft, float i_Capacity) : base(i_EnergyLeft, i_Capacity)
        {
            this.fuelType = i_FuelType;
        }

        public eFuel FuelType
        {
            get
            {
                return this.fuelType;
            }
            set
            {
                this.fuelType = value;
            }
        }

        public bool Fill(int i_Amount, eFuel i_FuelType)
        {
            bool fullTank = base.EnergyLeft + i_Amount > base.Capacity && this.fuelType == i_FuelType;

            if (!fullTank)
            {
                base.EnergyLeft += i_Amount;
            }
            else
            {
               throw new ValueOutOfRangeException (0,base.Capacity - base.EnergyLeft);
            }

            return fullTank;
        }
    
    }

    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_EnergyLeft, float i_Capacity) : base(i_EnergyLeft, i_Capacity) { }
        public bool Fill(float i_Amount)
        {
            bool tankFull = i_Amount + base.EnergyLeft > base.Capacity;

            if (tankFull)
            {
                throw new ValueOutOfRangeException(0, base.Capacity - base.EnergyLeft);
            }
            else
            {
                base.EnergyLeft += i_Amount;
            }

            return tankFull;
        }
    }
}