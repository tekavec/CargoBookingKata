namespace CargoBookingKata
{
    public class Booking
    {
        private readonly Cargo.Cargo _cargo;
        private readonly Vessel _vessel;
        private readonly ConfirmationNumber _confirmationNumber;

        public Booking(Cargo.Cargo cargo, Vessel vessel, ConfirmationNumber confirmationNumber)
        {
            _cargo = cargo;
            _vessel = vessel;
            _confirmationNumber = confirmationNumber;
        }

        public ConfirmationNumber ConfirmationNumber()
        {
            return _confirmationNumber;
        }

        protected bool Equals(Booking other)
        {
            return Equals(_cargo, other._cargo) && Equals(_vessel, other._vessel) && Equals(_confirmationNumber, other._confirmationNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Booking) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_cargo != null ? _cargo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_vessel != null ? _vessel.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_confirmationNumber != null ? _confirmationNumber.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}