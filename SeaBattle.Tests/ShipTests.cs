using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaBattle.Model.Ships;

namespace SeaBattle.Tests
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LenghtOutOfRangeConstructor()
        {
            Ship fourDecker = new Ship(Orientation.Horizontal, 5, 2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void XOutOfRangeConstructor()
        {
            Ship fourDecker = new Ship(Orientation.Horizontal, 4, 11, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void YOutOfRangeConstructor()
        {
            Ship fourDecker = new Ship(Orientation.Horizontal, 4, 2, 11);
        }

        [TestMethod]
        public void ShipDecksConstructionTest()
        {
            // Arrange
            Ship threeDecker = new Ship(Orientation.Horizontal, 3, 2, 2);

            // Act

            // Assert
            Assert.AreEqual(3, threeDecker.Deck.Count);
        }

        [TestMethod]
        public void CheckIsVerticalOccupiedPositionShouldBeTrueTest()
        {
            // Arrange
            Ship fourDecker = new Ship(Orientation.Vertical, 4, 2, 2);

            // Act

            // Assert
            Assert.IsTrue(fourDecker.CheckIfPositionIsOccupied(2, 2));
            Assert.IsTrue(fourDecker.CheckIfPositionIsOccupied(2, 3));
            Assert.IsTrue(fourDecker.CheckIfPositionIsOccupied(2, 4));
            Assert.IsTrue(fourDecker.CheckIfPositionIsOccupied(2, 5));
        }

        [TestMethod]
        public void CheckIsHorizontalOccupiedPositionShouldBeTrueTest()
        {
            // Arrange
            Ship fourDecker = new Ship(Orientation.Horizontal, 4, 2, 2);

            // Act

            // Assert
            Assert.IsTrue(fourDecker.CheckIfPositionIsOccupied(2, 2));
            Assert.IsTrue(fourDecker.CheckIfPositionIsOccupied(3, 2));
            Assert.IsTrue(fourDecker.CheckIfPositionIsOccupied(4, 2));
            Assert.IsTrue(fourDecker.CheckIfPositionIsOccupied(5, 2));
        }

        [TestMethod]
        public void CheckIsVerticalOccupiedPositionShouldBeFalseTest()
        {
            // Arrange
            Ship fourDecker = new Ship(Orientation.Vertical, 4, 2, 2);

            // Act

            // Assert
            Assert.IsFalse(fourDecker.CheckIfPositionIsOccupied(3, 2));
            Assert.IsFalse(fourDecker.CheckIfPositionIsOccupied(3, 3));
            Assert.IsFalse(fourDecker.CheckIfPositionIsOccupied(3, 4));
            Assert.IsFalse(fourDecker.CheckIfPositionIsOccupied(3, 5));
        }

        [TestMethod]
        public void CheckIsHorizontalOccupiedPositionShouldBeFalseTest()
        {
            // Arrange
            Ship fourDecker = new Ship(Orientation.Horizontal, 4, 2, 2);

            // Act

            // Assert
            Assert.IsFalse(fourDecker.CheckIfPositionIsOccupied(2, 3));
            Assert.IsFalse(fourDecker.CheckIfPositionIsOccupied(3, 3));
            Assert.IsFalse(fourDecker.CheckIfPositionIsOccupied(4, 3));
            Assert.IsFalse(fourDecker.CheckIfPositionIsOccupied(5, 3));
        }

        [TestMethod]
        public void CheckShipDeckIsHittedShouldBeTrue()
        {
            // Arrange
            Ship twoDecker = new Ship(Orientation.Horizontal, 2, 2, 2);

            // Act
            twoDecker.Attack(2,2);

            // Assert
            Assert.IsTrue(twoDecker.Deck[0].IsHit);
        }

        [TestMethod]
        public void CheckShipDeckIsHittedShouldBeFalse()
        {
            // Arrange
            Ship twoDecker = new Ship(Orientation.Horizontal, 2, 2, 2);

            // Act
            twoDecker.Attack(2, 3);

            // Assert
            Assert.IsFalse(twoDecker.Deck[0].IsHit);
        }
    }
}
