using System;

namespace CargoBookingKata.Exceptions
{
    public class CargoExceedesVesselCapacityException : Exception
    {
        public CargoExceedesVesselCapacityException(string message) : base(message)
        {
        }
    }
}