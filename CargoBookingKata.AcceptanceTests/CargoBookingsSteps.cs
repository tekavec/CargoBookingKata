using System;
using CargoBookingKata.Metrics;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CargoBookingKata.AcceptanceTests
{
    [Binding]
    public class CargoBookingsSteps
    {
        private Cargo.Cargo _cargo;
        private Vessel _vessel;
        private CargoBookings _cargoBookings;
        private IIntegerSequenceGenerator _integerSequenceGenerator;
        private readonly IBookingRepository _bookingRepository = Substitute.For<IBookingRepository>();
        private readonly IBookingConsole _console = Substitute.For<IBookingConsole>();

        [Given(@"CargoBookings exist")]
        public void GivenCargoBookingsExist()
        {
            _integerSequenceGenerator = Substitute.For<IIntegerSequenceGenerator>();
            _cargoBookings = new CargoBookings(_integerSequenceGenerator, _bookingRepository, _console);
        }

        [Given(@"a cargo size is (.*) cubic feets")]
        public void GivenACargoSizeIsCubicFeet(int size)
        {
            _cargo = new Cargo.Cargo(new CubicFeet(size));
        }
        
        [Given(@"a vessel capacity is (.*) cubic feets")]
        public void GivenAVesselCapacityIsCubicFeet(int capacity)
        {
            _vessel = new Vessel(new CubicFeet(capacity));
        }

        [When(@"the application tries to book the cargo on vessel")]
        public void WhenTheApplicationTriesToBookTheCargoOnVessel()
        {
            _integerSequenceGenerator.GetNext().Returns(1);
            //_cargoBookings.BookCargo(_cargo, _vessel);

            Action bookingOperation = () => _cargoBookings.BookCargo(_cargo, _vessel);
            bookingOperation();
            //ScenarioContext.Current.Add("bookingOperation");
        }

        [Then(@"a new booking is created with the confirmation number (.*)")]
        public void ThenANewBookingIsCreatedWithTheConfirmationNumber(int number)
        {
            var confirmationNumber = new ConfirmationNumber(number);
            var booking = new Booking(_cargo, _vessel, confirmationNumber);

            _bookingRepository.Received().Add(booking);
        }

        [Then(@"the cargo is added to the vessel")]
        public void ThenTheCargoIsAddedToTheVessel()
        {
            Assert.That(_vessel.CargosCount(), Is.EqualTo(1));
        }

        [Then(@"the vessel new capacity is (.*) cubic feets")]
        public void ThenTheVesselNewCapacityIsCubicFeet_(int capacity)
        {
            Assert.That(_vessel.AvailableCapacity(), Is.EqualTo(new CubicFeet(capacity)));
        }

        [Then(@"the booking for the cargo on the vessel is rejected")]
        public void ThenTheBookingForTheCargoOnTheVesselIsRejected_()
        {
            
            //act.ShouldThrow<CargoExceedesVesselCapacityException>();
        }

        [Then(@"the message ""(.*)"" is displayed on the BookingConsole\.")]
        public void ThenTheMessageIsDisplayedOnTheConsole_(string exceptionMessage)
        {
            _console.Received().WriteLine(exceptionMessage);
        }

    }
}
    