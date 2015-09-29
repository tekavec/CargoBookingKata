using System.Collections.Generic;

namespace CargoBookingKata
{
    public interface ICargoRepository
    {
        void Add(Booking booking);
        int Count();
        Booking FindByConfirmationNumber(ConfirmationNumber confirmationNumber);
    }
}