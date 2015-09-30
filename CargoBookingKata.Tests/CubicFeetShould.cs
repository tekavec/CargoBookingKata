using CargoBookingKata.Metrics;
using NUnit.Framework;

namespace CargoBookingKata.Tests
{
    [TestFixture]
    public class CubicFeetShould
    {
        private readonly CubicFeet _smallCubicFeet = new CubicFeet(10);
        private readonly CubicFeet _hugeCubicFeet = new CubicFeet(1000);

        [Test]
        public void PerformLessThanOperation()
        {
            Assert.That(_smallCubicFeet < _hugeCubicFeet, Is.True);
        }

        [Test]
        public void PerformGreaterThanOperation()
        {
            Assert.That(_smallCubicFeet > _hugeCubicFeet, Is.False);
        }

        [Test]
        public void PerformPlusOperation()
        {
            Assert.That(_smallCubicFeet + _hugeCubicFeet, Is.EqualTo(new CubicFeet(1010)));
        }

        [Test]
        public void PerformMinusOperation()
        {
            Assert.That(_smallCubicFeet - _hugeCubicFeet, Is.EqualTo(new CubicFeet(-990)));
        }

        [Test]
        public void PerformToStringRepresentation()
        {
            Assert.That(_smallCubicFeet.ToString(), Is.EqualTo("10"));
        }
         
    }
}