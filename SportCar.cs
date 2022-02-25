using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_lib
{
    class SportCar : Vehicle
    {
        public override TypeOfVehicle VehicleType { get { return TypeOfVehicle.SportCar; } }

        public SportCar(int fuelConsumption, int tankCapacity) : base(fuelConsumption, tankCapacity)
        {

        }

        public override int MotionReserveOfEquip(int equipment, int fuelCurrent)
        {
            return TravelDistance(fuelCurrent);
        }
    }
}
