using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_lib
{
    class PassengerCar : Vehicle
    {
        private const int REDUCTION_PERCENT_PER_PASSENGER = 6;

        public override TypeOfVehicle VehicleType { get { return TypeOfVehicle.PassengerCar; } }
        public int PassengerNumberMax { get; }

        public PassengerCar(int fuelConsumption, int tankCapacity, int passengerNumberMax) : base(fuelConsumption, tankCapacity)
        {
            PassengerNumberMax = passengerNumberMax;
        }

        public override int MotionReserveOfEquip(int currentPassenger, int fuelCurrent)
        {
            int reserve = TravelDistance(fuelCurrent);

            if (PermissPassengerNumber(currentPassenger))
            {
                return reserve;
            }

            for (int i = currentPassenger; i > PassengerNumberMax; i--)
            {
                reserve = reserve * (100 - REDUCTION_PERCENT_PER_PASSENGER) / 100;
            }
            return reserve;
        }

        private bool PermissPassengerNumber(int currentPassenger)
        {
            return PassengerNumberMax >= currentPassenger;
        }
    }
}
