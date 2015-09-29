using System;
using System.Runtime.Serialization;

namespace CargoBookingKata
{
    [Serializable]
    public class CargoExceedesVesselCapacityException : Exception
    {
        public CargoExceedesVesselCapacityException()
        {
        }

        public CargoExceedesVesselCapacityException(string message) : base(message)
        {
        }

        public CargoExceedesVesselCapacityException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CargoExceedesVesselCapacityException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}