using System;

namespace Vehicle_lib
{
    public abstract class Vehicle
    {
        public abstract TypeOfVehicle VehicleType { get; }
        public int FuelAverage { get; }
        public int TankCapacity { get; }
        public int Speed { get; set; }

        public Vehicle(int fuelConsumption, int tankCapacity)
        {
            FuelAverage = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public int TravelDistance(int fuelCurrent)
        {
            if (fuelCurrent > TankCapacity && new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name != "FuelForTravel")
                throw new VehicleParamOutOfRange("fuelCurrent", fuelCurrent, "Tank is overload");

            return fuelCurrent * 100 / FuelAverage;

        }

        public int FuelForTravel(int distance, int fuelCurrent)
        {
            if (TravelDistance(fuelCurrent) < distance)
                throw new VehicleParamOutOfRange("fuelCurrent", fuelCurrent, "Not enough fuel");

            return FuelAverage * distance / 100;
        }

        public abstract int MotionReserveOfEquip(int equipment, int fuelCurrent);
    }

    public enum TypeOfVehicle
    {
        PassengerCar,
        SportCar,
        Truck
    }
}
