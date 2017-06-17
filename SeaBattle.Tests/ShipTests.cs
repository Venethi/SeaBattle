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

        
    }
}
