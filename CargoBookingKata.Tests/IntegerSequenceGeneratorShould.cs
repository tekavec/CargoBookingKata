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

            Assert.That(integerSequenceGenerator.GetNext(), Is.EqualTo(1));
            Assert.That(integerSequenceGenerator.GetNext(), Is.EqualTo(2));
        }
    }
}