using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class UserDetails
    {
        private string m_UserName = string.Empty;
        private string m_UserPhoneNumber = string.Empty;
        private string m_VehicleCondition = string.Empty;
        private Vehicle m_UserVeicle = null;

        public UserDetails(string i_UserName, string i_UserPhoneNumber, Vehicle i_Vehicle, string i_VehicleCondition)
        {
            this.m_UserName = i_UserName;
            this.m_UserPhoneNumber = i_UserPhoneNumber;
            this.m_UserVeicle = i_Vehicle;
            this.m_VehicleCondition = i_VehicleCondition;
        }

        public string UserName
        {
            get 
            {
                return this.m_UserName;
            }
            set
            {
                this.m_UserName = value;
            }
        }

        public string UserPhoneNumber
        {
            get
            {
                return this.m_UserPhoneNumber;
            }
            set
            {
                this.m_UserPhoneNumber = value;
            }
        }

        public string vehicleCondition
        {
            get
            {
                return this.m_VehicleCondition;
            }
            set
            {
                this.m_VehicleCondition = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return this.m_UserVeicle;
            }
            set
            {
                this.m_UserVeicle = value;
            }
        }

    }
}
