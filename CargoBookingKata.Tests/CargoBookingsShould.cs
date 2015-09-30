using CargoBookingKata.Bookings;
using CargoBookingKata.Metrics;
using CargoBookingKata.SequenceGeneration;
using NSubstitute;
using NUnit.Framework;

namespace CargoBookingKata.Tests
{
    [TestFixture]
    public class CargoBookingsShould
    {
        private CargoBookings _cargoBookings;
        private Vessel.Vessel _vesselA;
        private Cargo.Cargo _smallCargo;
        private Cargo.Cargo _bigCargo;
        private IIntegerSequenceGenerator _integerSequenceGenerator;
        private readonly IBookingRepository _bookingRepository = Substitute.For<IBookingRepository>();
        private readonly IBookingConsole _console = Substitute.For<IBookingConsole>();

        [SetUp]
        public void Init()
        {
            _integerSequenceGenerator=Substitute.For<IIntegerSequenceGenerator>();
            _cargoBookings = new CargoBookings(_integerSequenceGenerator, _bookingRepository, _console);
            _vesselA = new Vessel.Vessel(new CubicFeet(900));
            _smallCargo = new Cargo.Cargo(new CubicFeet(200));
            _bigCargo = new Cargo.Cargo(new CubicFeet(1200));
        }

        [Test]
        public void RejectBookingACargoOnAVesselWithNotEnoughCapacityAndDisplaysAMessageToConsole()
        {
            _cargoBookings.BookCargo(_bigCargo, _vesselA);

            _console.Received().WriteLine("Cargo size exceeds vessel's available capacity.");
        }

        [Test]
        public void BookACargoOnAVesselWithEnoughCapacity()
        {
            _integerSequenceGenerator.GetNext().Returns(1);
            var confirmationNumber = new ConfirmationNumber(_integerSequenceGenerator.GetNext());
            
            _cargoBookings.BookCargo(_smallCargo, _vesselA);

            _bookingRepository.Received().Add(new Booking(_smallCargo, _vesselA, confirmationNumber));
        }
    }
}
