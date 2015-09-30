using System;
using System.Runtime.Remoting.Messaging;

namespace CargoBookingKata
{
    public class CargoBookings
    {
        private readonly IIntegerSequenceGenerator _integerSequenceGenerator;
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingConsole _console;

        public CargoBookings(IIntegerSequenceGenerator integerSequenceGenerator, IBookingRepository bookingRepository, IBookingConsole console)
        {
            _integerSequenceGenerator = integerSequenceGenerator;
            _bookingRepository = bookingRepository;
            _console = console;
        }

        public void BookCargo(Cargo.Cargo cargo, Vessel vessel)
        {
            try
            {
                vessel.Add(cargo);
                _bookingRepository.Add(
                    new Booking(
                        cargo,
                        vessel,
                        new ConfirmationNumber(_integerSequenceGenerator.GetNext())));
            }
            catch (CargoExceedesVesselCapacityException ex)
            {
                _console.WriteLine(ex.Message);
            }
        }

    }

}