using System;
using NUnit.Framework;
using SeaBattle.Core.Types;
using SeaBattle.Model.BattleGrids;
using SeaBattle.Model.Ships;

namespace SeaBattle.Tests
{
    [TestFixture]
    public class BattleGridTests
    {
        [Test]
        public void BattleGrid_AddShip_WhenOccupiedPosition_ThrowsException()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            bg.AddShip(new Ship(Orientation.Horizontal, 4, 1, 1));

            // Assert
            Assert.Throws<OccupiedPositionException>(() => bg.AddShip(new Ship(Orientation.Horizontal, 3, 1, 1)));
        }

        [Test]
        public void BattleGrid_AddShip_WhenFreePosition_Success()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act and assert
            bg.AddShip(new Ship(Orientation.Horizontal, 4, 1, 1));
            bg.AddShip(new Ship(Orientation.Vertical, 3, 1, 3));
        }

        [Test]
        public void BattleGrid_AddShip_WhenLenghtAndHorizontalPositionSumOutOfRange_ThrowsException()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Assert
            Assert.Throws<OutOfRangePositionException>(() => 
            bg.AddShip(new Ship(Orientation.Horizontal, 2, 9, 9)));
        }

        [Test]
        public void BattleGrid_AddShip_WhenLenghtAndVerticalPositionSumOutOfRange_ThrowsException()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Assert
            Assert.Throws<OutOfRangePositionException>(() =>
                bg.AddShip(new Ship(Orientation.Vertical, 2, 9, 9)));
        }

        [Test]
        public void BattleGrid_CheckPositionIsFree_WhenOccupiedByOneDecker_ReturnsFalse()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Horizontal, 1, 2, 2));

            // Assert
            Assert.IsFalse(bg.CheckPositionIsFree(2,2));
        }

        [Test]
        public void BattleGrid_CheckPositionIsFree_WhenFree_ReturnsTrue()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act and Assert
            Assert.IsTrue(bg.CheckPositionIsFree(2, 2));
        }

        [Test]
        public void BattleGrid_CheckPositionOreolIsFree_WhenOccupiedByOneDecker_ReturnsFalse([Values(1,2,3)] int xPos, [Values(1,2,3)] int yPos)
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            Orientation orientation = Orientation.Horizontal;
            int length = 1;
            int x = 2;
            int y = 2;

            // Act
            bg.AddShip(new Ship(Orientation.Horizontal, length, x, y));

            // Assert
            Assert.IsFalse(bg.CheckPositionIsFree(xPos, yPos));
        }

        [Test]
        public void BattleGrid_CheckPositionOreolIsFree_WhenBorder_Success([Values(0,9)] int xPos, [Values(0, 9)] int yPos)
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Horizontal, 1, 0, 0));

            // Assert
            bg.CheckPositionIsFree(xPos, yPos);
        }

        [Test]
        public void BattleGrid_CheckPositionOreolIsFree_WhenOccupiedByHorizontalTwoDecker_ReturnsFalse([Values(1, 2, 3, 4)] int xPos, [Values(1, 2, 3)] int yPos)
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Horizontal, 2, 2, 2));

            // Assert
            Assert.IsFalse(bg.CheckPositionIsFree(xPos, yPos));
        }

        [Test]
        public void BattleGrid_CheckPositionOreolIsFree_WhenOccupiedByVerticalTwoDecker_ReturnsFalse([Values(1, 2, 3)] int xPos, [Values(1, 2, 3, 4)] int yPos)
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Vertical, 2, 2, 2));

            // Assert
            Assert.IsFalse(bg.CheckPositionIsFree(xPos, yPos));
        }

        [Test]
        public void BattleGrid_AttackShip_WhenOccupiedPosition_ReturnsTrue()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            bg.AddShip(new Ship(bg, Orientation.Horizontal, 2, 2, 2));

            // Act and assert
            Assert.IsTrue(bg.AttackShip(2, 2));

        }

        [Test]
        public void BattleGrid_AttackShip_WhenFreePosition_ReturnsFalse()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act and assert
            Assert.IsFalse(bg.AttackShip(2, 2));
        }

        [Test]
        public void BattleGrid_Ship_Deck_IsHitted_ShouldFireEvent()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            Ship threeDecker = new Ship(bg, Orientation.Horizontal, 3, 2, 2);

            bg.AddShip(threeDecker);

            bool isEventFired = false;

            
            bg.OnShipDeckIsDestoryed += (o, e) => isEventFired = true;

            // Act
            threeDecker.Attack(2, 2);

            // Assert
            Assert.IsTrue(isEventFired);
        }

        [Test]
        public void BattleGrid_Ship_IsSunk_ShouldFireEvent()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            Ship threeDecker = new Ship(bg, Orientation.Horizontal, 3, 2, 2);

            bg.AddShip(threeDecker);

            bool isEventFired = false;

            bg.OnShipIsDestoryed += (o, e) => isEventFired = true;

            // Act
            threeDecker.Attack(2, 2);
            threeDecker.Attack(3, 2);
            threeDecker.Attack(4, 2);

            // Assert
            Assert.IsTrue(isEventFired);
        }
    }
}
