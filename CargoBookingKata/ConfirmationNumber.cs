namespace CargoBookingKata
{
    public class ConfirmationNumber
    {
        private readonly int _number;

        public ConfirmationNumber(int number)
        {
            _number = number;
        }

        protected bool Equals(ConfirmationNumber other)
        {
            return _number == other._number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ConfirmationNumber) obj);
        }

        public override int GetHashCode()
        {
            return _number;
        }
    }
}