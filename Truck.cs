using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_lib
{
    class Truck : Vehicle
    {
        private const int TONNAGE_REDUCE_STEP_ON_PERCENT = 200;
        private const int REDUCTION_PERCENT_PER_TONNAGE_STEP = 4;

        public override TypeOfVehicle VehicleType { get { return TypeOfVehicle.Truck; } }
        public int Tonnage { get; }

        public Truck(int fuelConsumption, int tankCapacity, int tonnage) : base(fuelConsumption, tankCapacity)
        {
            Tonnage = tonnage;
        }

        public override int MotionReserveOfEquip(int cargoWeight, int fuelCurrent)
        {
            int reserve = TravelDistance(fuelCurrent);

            if (PermissCargoWeight(cargoWeight))
            {
                return reserve;
            }

            for (int i = cargoWeight - Tonnage; i > TONNAGE_REDUCE_STEP_ON_PERCENT; i -= TONNAGE_REDUCE_STEP_ON_PERCENT)
            {
                reserve = reserve * (100 - REDUCTION_PERCENT_PER_TONNAGE_STEP) / 100;
            }
            return reserve;
        }

        private bool PermissCargoWeight(int cargoWeight)
        {
            return Tonnage >= cargoWeight;
        }
    }
}
