namespace CargoBookingKata
{
    public class Vessel
    {
        private readonly int _capacity;

        public Vessel(int capacity)
        {
            _capacity = capacity;
        }

        public int AvailableCapacity()
        {
            return _capacity;
        }

        protected bool Equals(Vessel other)
        {
            return _capacity == other._capacity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Vessel) obj);
        }

        public override int GetHashCode()
        {
            return _capacity;
        }

        public Booking FindBookingByConfirmationNumber(ConfirmationNumber confirmationNumber)
        {
            throw new System.NotImplementedException();
        }

        public int CargosCount()
        {
            throw new System.NotImplementedException();
        }

        public void Book(Cargo cargo, ConfirmationNumber confirmationNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}