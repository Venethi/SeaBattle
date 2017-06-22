using System;

using NUnit.Framework;

using SeaBattle.Model.Ships;

namespace SeaBattle.Tests
{
    [TestFixture]
    public class ShipTests
    {
        [Test]
        public void Ship_Constructor_WhenLenghtOutOfRange_ThrowsException()
        {
            Ship fourDecker;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            fourDecker = new Ship(Orientation.Horizontal, 5, 2, 2));
        }

        [Test]
        public void Ship_Constructor_WhenXOutOfRange_ThrowsException()
        {
            Ship fourDecker;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                fourDecker = new Ship(Orientation.Horizontal, 4, 11, 2));
        }

        [Test]
        public void Ship_Constructor_WhenYOutOfRange_ThrowsException()
        {
            Ship fourDecker;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                fourDecker = new Ship(Orientation.Horizontal, 4, 2, 11));
        }

        [Test]
        public void Ship_Deck_DeckCountEqualsLength([Values (1,2,3,4)] int length)
        {
            // Arrange
            Orientation orientation = Orientation.Horizontal;
            int x = 2;
            int y = 2;

            Ship threeDecker = new Ship(orientation, length, x, y);

            // Assert
            Assert.AreEqual(length, threeDecker.Deck.Count);
        }

        [Test]
        public void Ship_VerticalFourDecker_CheckIfPositionIsOccupied_ReturnsTrue([Values(0, 1, 2, 3)] int deckNumber)
        {
            // Arrange
            Orientation orientation = Orientation.Vertical;
            int length = 4;
            int x = 2;
            int y = 2;

            Ship fourDecker = new Ship(orientation, length, x, y);

            // Assert
            Assert.IsTrue(fourDecker.CheckIfPositionIsOccupied(x, y + deckNumber));
        }

        [Test]
        public void Ship_HorizontalFourDecker_CheckIfPositionIsOccupied_ReturnsTrue([Values(0, 1, 2, 3)] int deckNumber)
        {
            // Arrange
            Orientation orientation = Orientation.Horizontal;
            int length = 4;
            int x = 2;
            int y = 2;

            Ship fourDecker = new Ship(orientation, length, x, y);

            // Assert
            Assert.IsTrue(fourDecker.CheckIfPositionIsOccupied(x + deckNumber, y));
        }

        [Test]
        public void Ship_VerticalFourDecker_CheckIfPositionIsOccupied_ReturnsFalse([Values(0, 1, 2, 3)] int deckNumber)
        {
            // Arrange
            Orientation orientation = Orientation.Vertical;
            int length = 4;
            int x = 2;
            int y = 2;

            Ship fourDecker = new Ship(orientation, length, x, y);

            // Assert
            Assert.IsFalse(fourDecker.CheckIfPositionIsOccupied(x + 1, y + deckNumber));
        }

        [Test]
        public void Ship_HorizontalFourDecker_CheckIfPositionIsOccupied_ReturnsFalse([Values(0, 1, 2, 3)] int deckNumber)
        {
            // Arrange
            Orientation orientation = Orientation.Horizontal;
            int length = 4;
            int x = 2;
            int y = 2;

            Ship fourDecker = new Ship(orientation, length, x, y);

            // Assert
            Assert.IsFalse(fourDecker.CheckIfPositionIsOccupied(x + deckNumber, y + 1));
        }

        [Test]
        public void Ship_Deck_IsHitted_ReturnsTrue()
        {
            // Arrange
            Ship twoDecker = new Ship(Orientation.Horizontal, 2, 2, 2);

            // Act and assert
            Assert.IsTrue(twoDecker.Attack(2, 2));
        }

        [Test]
        public void Ship_Deck_IsHitted_ReturnsFalse()
        {
            // Arrange
            Ship twoDecker = new Ship(Orientation.Horizontal, 2, 2, 2);

            // Act and assert
            Assert.IsFalse(twoDecker.Attack(2, 1));
        }

        [Test]
        public void Ship_IsSunk_ReturnsTrue()
        {
            // Arrange
            Ship twoDecker = new Ship(Orientation.Horizontal, 2, 2, 2);

            twoDecker.Attack(2, 2);
            twoDecker.Attack(3, 2);

            // Act and assert
            Assert.IsTrue(twoDecker.IsSunk);
        }
    }
}
