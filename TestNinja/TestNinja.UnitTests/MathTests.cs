using NUnit.Framework;
using System.Linq;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        //Runs before every test - usefull for initializing an object that we want to test
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            // Arrange        
            //var math = new Math();

            // Act - always use simple values
            var result = _math.Add(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnGreaterArgument(int a, int b, int expectedResult)
        {
            // Arrange
            //var math = new Math();

            // Act
            var result = _math.Max(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            //Very general assertions
            //Assert.That(result, Is.Not.Empty);
            //Assert.That(result.Count(), Is.EqualTo(3));

            //More specific assertions - in this case better
            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));

            //Same specifi as above, but written in cleaner way
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            //Other usefull assertios - not nessecary for our case
            //Assert.That(result, Is.Ordered); //when we want to validate if results are sorted
            //Assert.That(result, Is.Unique);
        }

        #region before using parametrised method
        [Test]
        [Ignore("Obsolete - moved test into parametrized test method")]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            // Arrange
            //var math = new Math();

            // Act
            var result = _math.Max(2, 1);

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }
                
        [Test]
        [Ignore("Obsolete - moved test into parametrized test method")]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            // Arrange
            //var math = new Math();

            // Act
            var result = _math.Max(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        [Ignore("Obsolete - moved test into parametrized test method")]
        public void Max_ArgumentAreEqual_ReturnTheSameArgument()
        {
            // Arrange
            //var math = new Math();

            // Act
            var result = _math.Max(1, 1);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
        #endregion
    }
}
