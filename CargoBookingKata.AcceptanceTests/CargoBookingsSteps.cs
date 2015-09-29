using NSubstitute;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CargoBookingKata.AcceptanceTests
{
    [Binding]
    public class CargoBookingsSteps
    {
        private Cargo _cargo;
        private Vessel _vessel;
        private CargoBookings _cargoBookings;
        private IIntegerSequenceGenerator _integerSequenceGenerator;

        [Given(@"CargoBookings exist")]
        public void GivenCargoBookingsExist()
        {
            _integerSequenceGenerator = Substitute.For<IIntegerSequenceGenerator>();
            _cargoBookings = new CargoBookings(_integerSequenceGenerator);
        }

        [Given(@"a cargo size is (.*) cubic feets")]
        public void GivenACargoSizeIsCubicFeet(int size)
        {
            _cargo = new Cargo(size);
        }
        
        [Given(@"a vessel capacity is (.*) cubic feets")]
        public void GivenAVesselCapacityIsCubicFeet(int capacity)
        {
            _vessel = new Vessel(capacity);
        }

        [When(@"the application tries to book the cargo on vessel")]
        public void WhenTheApplicationTriesToBookTheCargoOnVessel()
        {
            _integerSequenceGenerator.GetNext().Returns(1);
            _cargoBookings.BookCargoOnVessel(_cargo, _vessel);
        }

        [Then(@"a new booking is created with the confirmation number (.*)")]
        public void ThenANewBookingIsCreatedWithTheConfirmationNumber(int number)
        {
            var confirmationNumber = new ConfirmationNumber(number);
            var booking = _vessel.FindBookingByConfirmationNumber(confirmationNumber);

            Assert.That(confirmationNumber, Is.EqualTo(booking.ConfirmationNumber()));
        }

        [Then(@"the cargo is added to the vessel")]
        public void ThenTheCargoIsAddedToTheVessel()
        {
            Assert.That(_vessel.CargosCount(), Is.EqualTo(1));
        }

        [Then(@"the vessel new capacity is (.*) cubic feets\.")]
        public void ThenTheVesselNewCapacityIsCubicFeet_(int capacity)
        {
            Assert.That(_vessel.AvailableCapacity(), Is.EqualTo(capacity));
        }

        [Then(@"the booking for the cargo on the vessel is rejected\.")]
        [ExpectedException(typeof(CargoExceedesVesselCapacityException))]
        public void ThenTheBookingForTheCargoOnTheVesselIsRejected_()
        {
            _cargoBookings.BookCargoOnVessel(_cargo, _vessel);
        }
        
    }
}
