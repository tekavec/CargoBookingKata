using System;

namespace CargoBookingKata
{
    public class Cargo
    {
        private readonly int _size;

        public Cargo(int size)
        {
            _size = size;
        }

        public int BookingId()
        {
            throw new NotImplementedException();
        }

        protected bool Equals(Cargo other)
        {
            return _size == other._size;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Cargo) obj);
        }

        public override int GetHashCode()
        {
            return _size;
        }

        public int Size()
        {
            return _size;
        }
    }
}