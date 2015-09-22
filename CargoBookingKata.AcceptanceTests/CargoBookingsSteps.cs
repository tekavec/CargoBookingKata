using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CargoBookingKata.AcceptanceTests
{
    [Binding]
    public class CargoBookingsSteps
    {
        private Cargo _cargo;
        private Vessel _vessel;
        private readonly CargoBookings _cargoBookings = new CargoBookings();

        [Given(@"a cargo size is (.*) cubic feet")]
        public void GivenACargoSizeIsCubicFeet(int size)
        {
            _cargo = new Cargo(size);
        }
        
        [Given(@"a vessel capacity is (.*) cubic feet")]
        public void GivenAVesselCapacityIsCubicFeet(int capacity)
        {
            _vessel = new Vessel(capacity);
        }
        
        [When(@"the application try to book the cargo on vessel")]
        public void WhenTheApplicationTryToBookTheCargoOnVessel()
        {
            _cargoBookings.Book(_cargo).On(_vessel);
        }
        
        [Then(@"the cargo gets the booking number (.*)")]
        public void ThenTheCargoGetsTheBookingNumber(int bookingId)
        {
            Assert.That(_cargo.BookingId(), Is.EqualTo(bookingId));
        }

        [Then(@"the vessel capacity is (.*) cubic feet\.")]
        public void ThenTheVesselCapacityIsCubicFeet_(int capacity)
        {
            Assert.That(_vessel.Capacity, Is.EqualTo(capacity));
        }
        
        [Then(@"the cargo is rejected\.")]
        public void ThenTheCargoIsRejected_()
        {
            Assert.That(_cargo.BookingId(), Is.Null);
        }
        
    }
}
