using CargoBookingKata.Metrics;

namespace CargoBookingKata.Cargo
{
    public class Cargo
    {
        private readonly CubicFeet _size;

        public Cargo(CubicFeet size)
        {
            _size = size;
        }

        public CubicFeet Size()
        {
            return _size;
        }
    }
}