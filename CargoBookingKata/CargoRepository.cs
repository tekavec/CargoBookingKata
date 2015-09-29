using System.Collections.Generic;
using System.Linq;

namespace CargoBookingKata
{
    public class CargoRepository : ICargoRepository
    {
        private readonly IList<Booking> _bookings = new List<Booking>();

        public void Add(Booking booking)
        {
            _bookings.Add(booking);
        }

        public int Count()
        {
            return _bookings.Count;
        }

        public Booking FindByConfirmationNumber(ConfirmationNumber confirmationNumber)
        {
            return _bookings.SingleOrDefault(a => a.ConfirmationNumber().Equals(confirmationNumber));
        }
    }
}