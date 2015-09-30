using CargoBookingKata.SequenceGeneration;
using NUnit.Framework;

namespace CargoBookingKata.Tests
{
    [TestFixture]
    public class IntegerSequenceGeneratorShould
    {
        [Test]
        public void ReturnASequenceOfIntegersStatrtingWith1()
        {
            var integerSequenceGenerator = new IntegerSequenceGenerator();

            Assert.That(1, Is.EqualTo(integerSequenceGenerator.GetNext()));
            Assert.That(2, Is.EqualTo(integerSequenceGenerator.GetNext()));
        }
    }
}