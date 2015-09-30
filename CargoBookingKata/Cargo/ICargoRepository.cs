namespace CargoBookingKata.Cargo
{
    public interface ICargoRepository
    {
        void Add(Booking booking);
        int Count();
        Booking FindByConfirmationNumber(ConfirmationNumber confirmationNumber);
    }
}