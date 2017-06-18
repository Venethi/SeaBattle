using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaBattle.Core.Types;
using SeaBattle.Model.BattleGrids;
using SeaBattle.Model.Ships;

namespace SeaBattle.Tests
{
    [TestClass]
    public class BattleGridTests
    {
        [TestMethod]
        [ExpectedException(typeof(OccupiedPositionException))]
        public void TryAddShipToOccupiedPositionShouldBeExceptionTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act and assert
            bg.AddShip(new Ship(Orientation.Horizontal, 4, 1, 1));
            bg.AddShip(new Ship(Orientation.Horizontal, 3, 1, 1));
        }

        [TestMethod]
        public void TryAddShipToFreePositionShouldBeSuccessTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act and assert
            bg.AddShip(new Ship(Orientation.Horizontal, 4, 1, 1));
            bg.AddShip(new Ship(Orientation.Vertical, 3, 1, 3));
        }

        [TestMethod]
        public void CheckFreePositionOnExistedOneDackerShouldBeFalseTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Horizontal, 1, 2, 2));

            // Assert
            Assert.IsFalse(bg.CheckFreePosition(2,2));
        }

        [TestMethod]
        public void CheckFreePositionShouldBeTrueTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act and Assert
            Assert.IsTrue(bg.CheckFreePosition(2, 2));
        }

        [TestMethod]
        public void CheckFreePositionOreolOnExistedOneDackerShouldBeFalseTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Horizontal, 1, 2, 2));

            // Assert
            Assert.IsFalse(bg.CheckFreePosition(1, 1));
            Assert.IsFalse(bg.CheckFreePosition(2, 1));
            Assert.IsFalse(bg.CheckFreePosition(3, 1));
            Assert.IsFalse(bg.CheckFreePosition(1, 2));
            Assert.IsFalse(bg.CheckFreePosition(2, 2));
            Assert.IsFalse(bg.CheckFreePosition(3, 2));
            Assert.IsFalse(bg.CheckFreePosition(1, 3));
            Assert.IsFalse(bg.CheckFreePosition(2, 3));
            Assert.IsFalse(bg.CheckFreePosition(3, 3));
        }

        [TestMethod]
        public void CheckFreePositionOreolShouldBeTrueTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act and Assert
            Assert.IsTrue(bg.CheckFreePosition(1, 1));
            Assert.IsTrue(bg.CheckFreePosition(2, 1));
            Assert.IsTrue(bg.CheckFreePosition(3, 1));
            Assert.IsTrue(bg.CheckFreePosition(1, 2));
            Assert.IsTrue(bg.CheckFreePosition(2, 2));
            Assert.IsTrue(bg.CheckFreePosition(3, 2));
            Assert.IsTrue(bg.CheckFreePosition(1, 3));
            Assert.IsTrue(bg.CheckFreePosition(2, 3));
            Assert.IsTrue(bg.CheckFreePosition(3, 3));
        }
    }
}
