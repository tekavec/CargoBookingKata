using CargoBookingKata.Metrics;
using NUnit.Framework;

namespace CargoBookingKata.Tests
{
    [TestFixture]
    public class BookingRepositoryShould
    {
        private CargoRepository _cargoRepository;

        [SetUp]
        public void Init()
        {
            _cargoRepository = new CargoRepository();
        }

        [Test]
        public void BookACargo()
        {
            var cargo = new Cargo.Cargo(new CubicFeet(400));
            var vessel = new Vessel(new CubicFeet(200));
            var confirmationNumber = new ConfirmationNumber(1);
            var booking = new Booking(cargo, vessel, confirmationNumber);

            _cargoRepository.Add(booking);

            Assert.That(_cargoRepository.Count(), Is.EqualTo(1));
            Assert.That(_cargoRepository.FindByConfirmationNumber(confirmationNumber), Is.EqualTo(booking));
        }

    }
}