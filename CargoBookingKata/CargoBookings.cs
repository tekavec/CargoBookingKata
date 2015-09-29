namespace CargoBookingKata
{
    public class CargoBookings
    {
        private readonly IIntegerSequenceGenerator _integerSequenceGenerator;

        public CargoBookings(IIntegerSequenceGenerator integerSequenceGenerator)
        {
            _integerSequenceGenerator = integerSequenceGenerator;
        }

        public void BookCargoOnVessel(Cargo cargo, Vessel vessel)
        {
            vessel.Book(cargo,new ConfirmationNumber(_integerSequenceGenerator.GetNext()));
        }
    }

}