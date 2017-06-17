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
        public void OneDeckerHorizontalCoordinatesTest()
        {
            // Arrange
            Ship oneDecker = new Ship(Orientation.Horizontal, 1, 2, 2);

            // Act

            // Assert
            Assert.AreEqual(2, oneDecker.Deck[0].X);
            Assert.AreEqual(2, oneDecker.Deck[0].Y);
        }

        [TestMethod]
        public void TwoDeckerHorizontalCoordinatesTest()
        {
            // Arrange
            Ship twoDecker = new Ship(Orientation.Horizontal, 2, 2, 2);

            // Act

            // Assert
            Assert.AreEqual(2, twoDecker.Deck[0].X);
            Assert.AreEqual(2, twoDecker.Deck[0].Y);

            Assert.AreEqual(3, twoDecker.Deck[1].X);
            Assert.AreEqual(2, twoDecker.Deck[1].Y);
        }

        [TestMethod]
        public void ThreeDeckerHorizontalCoordinatesTest()
        {
            // Arrange
            Ship threeDecker = new Ship(Orientation.Horizontal, 3, 2, 2);

            // Act

            // Assert
            Assert.AreEqual(2, threeDecker.Deck[0].X);
            Assert.AreEqual(2, threeDecker.Deck[0].Y);

            Assert.AreEqual(3, threeDecker.Deck[1].X);
            Assert.AreEqual(2, threeDecker.Deck[1].Y);

            Assert.AreEqual(4, threeDecker.Deck[2].X);
            Assert.AreEqual(2, threeDecker.Deck[2].Y);
        }

        [TestMethod]
        public void FourDeckerHorizontalCoordinatesTest()
        {
            // Arrange
            Ship oneDecker = new Ship(Orientation.Horizontal, 4, 2, 2);

            // Act

            // Assert
            Assert.AreEqual(2, oneDecker.Deck[0].X);
            Assert.AreEqual(2, oneDecker.Deck[0].Y);

            Assert.AreEqual(3, oneDecker.Deck[1].X);
            Assert.AreEqual(2, oneDecker.Deck[1].Y);

            Assert.AreEqual(4, oneDecker.Deck[2].X);
            Assert.AreEqual(2, oneDecker.Deck[2].Y);

            Assert.AreEqual(5, oneDecker.Deck[3].X);
            Assert.AreEqual(2, oneDecker.Deck[3].Y);
        }

        [TestMethod]
        public void OneDeckerVerticalCoordinatesTest()
        {
            // Arrange
            Ship oneDecker = new Ship(Orientation.Vertical, 1, 3, 3);

            // Act

            // Assert
            Assert.AreEqual(3, oneDecker.Deck[0].X);
            Assert.AreEqual(3, oneDecker.Deck[0].Y);
        }

        [TestMethod]
        public void TwoDeckerVerticalCoordinatesTest()
        {
            // Arrange
            Ship twoDecker = new Ship(Orientation.Vertical, 2, 3, 3);

            // Act

            // Assert
            Assert.AreEqual(3, twoDecker.Deck[0].X);
            Assert.AreEqual(3, twoDecker.Deck[0].Y);

            Assert.AreEqual(3, twoDecker.Deck[1].X);
            Assert.AreEqual(4, twoDecker.Deck[1].Y);
        }

        [TestMethod]
        public void ThreeDeckerVerticalCoordinatesTest()
        {
            // Arrange
            Ship threeDecker = new Ship(Orientation.Vertical, 3, 3, 3);

            // Act

            // Assert
            Assert.AreEqual(3, threeDecker.Deck[0].X);
            Assert.AreEqual(3, threeDecker.Deck[0].Y);

            Assert.AreEqual(3, threeDecker.Deck[1].X);
            Assert.AreEqual(4, threeDecker.Deck[1].Y);

            Assert.AreEqual(3, threeDecker.Deck[2].X);
            Assert.AreEqual(5, threeDecker.Deck[2].Y);
        }

        //[TestMethod]
        //public void FourDeckerVerticalCoordinatesTest()
        //{
        //     Arrange
        //    Ship oneDecker = new Ship(Orientation.Vertical, 4, 3, 3);

        //     Act

        //     Assert
        //    Assert.AreEqual(3, oneDecker.Deck[0].X);
        //    Assert.AreEqual(3, oneDecker.Deck[0].Y);

        //    Assert.AreEqual(3, oneDecker.Deck[1].X);
        //    Assert.AreEqual(4, oneDecker.Deck[1].Y);

        //    Assert.AreEqual(3, oneDecker.Deck[2].X);
        //    Assert.AreEqual(5, oneDecker.Deck[2].Y);

        //    Assert.AreEqual(3, oneDecker.Deck[3].X);
        //    Assert.AreEqual(6, oneDecker.Deck[3].Y);
        //}
    }
}
