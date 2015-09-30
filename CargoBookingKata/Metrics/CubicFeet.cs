namespace CargoBookingKata.Metrics
{
    public class CubicFeet
    {
        private readonly int _value;

        public CubicFeet(int value)
        {
            _value = value;
        }

        public static bool operator >(CubicFeet a, CubicFeet b)
        {
            return a._value > b._value;
        }

        public static bool operator <(CubicFeet a, CubicFeet b)
        {
            return a._value < b._value;
        }

        public static CubicFeet operator -(CubicFeet a, CubicFeet b)
        {
            return new CubicFeet(a._value - b._value);
        }

        public static CubicFeet operator +(CubicFeet a, CubicFeet b)
        {
            return new CubicFeet(a._value + b._value);
        }

        protected bool Equals(CubicFeet other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CubicFeet) obj);
        }

        public override int GetHashCode()
        {
            return _value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}