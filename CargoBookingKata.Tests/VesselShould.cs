using System.Runtime.InteropServices;
using CargoBookingKata.Exceptions;
using CargoBookingKata.Metrics;
using NUnit.Framework;

namespace CargoBookingKata.Tests
{
    [TestFixture]
    public class VesselShould
    {
        private Vessel.Vessel _vessel;
        private Cargo.Cargo _smallCargo;
        private Cargo.Cargo _bigCargo;

        [SetUp]
        public void Init()
        {
            _vessel = new Vessel.Vessel(new CubicFeet(900));
            _smallCargo = new Cargo.Cargo(new CubicFeet(200));
            _bigCargo = new Cargo.Cargo(new CubicFeet(1200));
        }

        [Test]
        [ExpectedException(typeof(CargoExceedesVesselCapacityException))]
        public void ThrowAnExceptionIfCargoSizeExceedsItsCapacity()
        {
            _vessel.Add(_bigCargo);
        }


        [Test]
        public void AcceptACargoIfItHasEnoughCapacity()
        {
            _vessel.Add(_smallCargo);

            Assert.That(_vessel.CargosCount(), Is.EqualTo(1));
        }

        [Test]
        public void DecreaseItsCapacityAfterACargoIsAdded()
        {
            _vessel.Add(_smallCargo);

            Assert.That(_vessel.AvailableCapacity(), Is.EqualTo(new CubicFeet(700)));
        }
    }
}