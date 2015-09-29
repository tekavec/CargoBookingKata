namespace CargoBookingKata
{
    public class IntegerSequenceGenerator : IIntegerSequenceGenerator
    {
        private int _integerSequence = 1;

        public int GetNext()
        {
            return _integerSequence++;
        }
    }
}