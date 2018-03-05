using System;
using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class RservationTests
    {
        //Name pattern for unit test methods
        //public void MethodName_Scenario_ExpectedBehavior()

        [Test]
        public void CanBeCancelledBy_AdminCancellingReservation_ReturnsTrue()
        {
            // Arrange - initialize objects, prepare them for tests
            var reservation = new Reservation();

            // Act - call methods ect.
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert -- exactly the same meaning
            //Assert.IsTrue(result);
            Assert.That(result, Is.True);
            //Assert.That(result == true);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingReservation_ReturnsTrue()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation() { MadeBy = user };

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_DifferentUserCancellingReservation_ReturnsFalse()
        {
            // Arrange
            var reservationCreator = new User();
            var differentUser = new User();
            var reservation = new Reservation();
            reservation.MadeBy = reservationCreator;

            // Act
            var result = reservation.CanBeCancelledBy(differentUser);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
