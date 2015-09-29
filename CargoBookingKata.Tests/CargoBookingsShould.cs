using NSubstitute;
using NUnit.Framework;

namespace CargoBookingKata.Tests
{
    [TestFixture]
    public class CargoBookingsShould
    {
        private readonly ICargoRepository _cargoRepository = Substitute.For<ICargoRepository>();
        private CargoBookings _cargoBookings;
        private Vessel _vesselA;
        private Cargo _smallCargo;
        private Cargo _bigCargo;
        private IIntegerSequenceGenerator _integerSequenceGenerator;

        [SetUp]
        public void Init()
        {
            _integerSequenceGenerator=Substitute.For<IIntegerSequenceGenerator>();
            _cargoBookings = new CargoBookings(_integerSequenceGenerator);
            _vesselA = new Vessel(900);
            _smallCargo = new Cargo(200);
            _bigCargo = new Cargo(1200);
        }

        [Test]
        [ExpectedException(typeof(CargoExceedesVesselCapacityException))]
        public void ThrowAnExceptionIfCargoSizeExceedsVesselCapacity()
        {
            _cargoBookings.BookCargoOnVessel(_bigCargo, _vesselA);
        }

        [Test]
        public void BookACargoOnAVesselWithEnoughCapacity()
        {
            _integerSequenceGenerator.GetNext().Returns(1);
            var confirmationNumber = new ConfirmationNumber(_integerSequenceGenerator.GetNext());
            _cargoBookings.BookCargoOnVessel(_bigCargo, _vesselA);

            _cargoRepository.Received().Add(new Booking(_bigCargo, _vesselA, confirmationNumber));
        }
    }
}
