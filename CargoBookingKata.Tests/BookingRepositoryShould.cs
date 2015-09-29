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
        public void AddABooking()
        {
            var cargo = new Cargo(400);
            var vessel = new Vessel(200);
            var confirmationNumber = new ConfirmationNumber(1);
            var booking = new Booking(cargo, vessel, confirmationNumber);

            _cargoRepository.Add(booking);

            Assert.That(_cargoRepository.Count(), Is.EqualTo(1));
            Assert.That(_cargoRepository.FindByConfirmationNumber(confirmationNumber), Is.EqualTo(booking));
        }
    }
}