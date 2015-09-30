using System.Collections.Generic;
using System.Linq;
using CargoBookingKata.Metrics;

namespace CargoBookingKata
{
    public class Vessel
    {
        private CubicFeet _capacity;
        private readonly IList<Cargo.Cargo> _cargos = new List<Cargo.Cargo>();

        public Vessel(CubicFeet capacity)
        {
            _capacity = capacity;
        }

        public CubicFeet AvailableCapacity()
        {
            return _capacity - _cargos.Sum(a => a.Size());
        }

        public int CargosCount()
        {
            return _cargos.Count;
        }

        public void Add(Cargo.Cargo cargo)
        {
            if (_capacity < cargo.Size())
            {
                throw new CargoExceedesVesselCapacityException("Cargo size exceeds vessel's available capacity.");
            }
            _cargos.Add(cargo);
        }
    }

}