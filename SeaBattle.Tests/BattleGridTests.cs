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
        public void CheckFreePositionOnExistedOneDeckerShouldBeFalseTest()
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
        public void CheckFreePositionOreolOnExistedOneDeckerShouldBeFalseTest()
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
        public void CheckFreePositionOreolOnExistedOneDeckerWithXandYZeroPositionsShouldBeFalseTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Horizontal, 1, 0, 0));

            // Assert
            Assert.IsFalse(bg.CheckFreePosition(0, 0));
            Assert.IsFalse(bg.CheckFreePosition(1, 0));
            Assert.IsFalse(bg.CheckFreePosition(0, 1));
            Assert.IsFalse(bg.CheckFreePosition(1, 1));
        }

        [TestMethod]
        public void CheckFreePositionOreolOnExistedOneDeckerWithXandYMaxPositionsShouldBeFalseTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Horizontal, 1, 9, 9));

            // Assert
            Assert.IsFalse(bg.CheckFreePosition(8, 8));
            Assert.IsFalse(bg.CheckFreePosition(9, 8));
            Assert.IsFalse(bg.CheckFreePosition(8, 9));
            Assert.IsFalse(bg.CheckFreePosition(9, 9));
        }

        [TestMethod]
        public void CheckFreePositionOreolOnExistedHorizontalTwoDeckerShouldBeFalseTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Horizontal, 2, 2, 2));

            // Assert
            Assert.IsFalse(bg.CheckFreePosition(1, 1));
            Assert.IsFalse(bg.CheckFreePosition(2, 1));
            Assert.IsFalse(bg.CheckFreePosition(3, 1));
            Assert.IsFalse(bg.CheckFreePosition(4, 1));
            Assert.IsFalse(bg.CheckFreePosition(1, 2));
            Assert.IsFalse(bg.CheckFreePosition(2, 2));
            Assert.IsFalse(bg.CheckFreePosition(3, 2));
            Assert.IsFalse(bg.CheckFreePosition(4, 2));
            Assert.IsFalse(bg.CheckFreePosition(1, 3));
            Assert.IsFalse(bg.CheckFreePosition(2, 3));
            Assert.IsFalse(bg.CheckFreePosition(3, 3));
            Assert.IsFalse(bg.CheckFreePosition(4, 3));
        }

        [TestMethod]
        public void CheckFreePositionOreolOnExistedVerticalTwoDeckerShouldBeFalseTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Vertical, 2, 2, 2));

            // Assert
            Assert.IsFalse(bg.CheckFreePosition(1, 1));
            Assert.IsFalse(bg.CheckFreePosition(1, 2));
            Assert.IsFalse(bg.CheckFreePosition(1, 3));
            Assert.IsFalse(bg.CheckFreePosition(1, 4));
            Assert.IsFalse(bg.CheckFreePosition(2, 1));
            Assert.IsFalse(bg.CheckFreePosition(2, 2));
            Assert.IsFalse(bg.CheckFreePosition(2, 3));
            Assert.IsFalse(bg.CheckFreePosition(2, 4));
            Assert.IsFalse(bg.CheckFreePosition(3, 1));
            Assert.IsFalse(bg.CheckFreePosition(3, 2));
            Assert.IsFalse(bg.CheckFreePosition(3, 3));
            Assert.IsFalse(bg.CheckFreePosition(3, 4));
        }

        [TestMethod]
        public void CheckFreePositionOreolOnExistedHorizontalThreeDeckerShouldBeFalseTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Horizontal, 3, 2, 2));

            // Assert
            Assert.IsFalse(bg.CheckFreePosition(1, 1));
            Assert.IsFalse(bg.CheckFreePosition(2, 1));
            Assert.IsFalse(bg.CheckFreePosition(3, 1));
            Assert.IsFalse(bg.CheckFreePosition(4, 1));
            Assert.IsFalse(bg.CheckFreePosition(5, 1));
            Assert.IsFalse(bg.CheckFreePosition(1, 2));
            Assert.IsFalse(bg.CheckFreePosition(2, 2));
            Assert.IsFalse(bg.CheckFreePosition(3, 2));
            Assert.IsFalse(bg.CheckFreePosition(4, 2));
            Assert.IsFalse(bg.CheckFreePosition(5, 2));
            Assert.IsFalse(bg.CheckFreePosition(1, 3));
            Assert.IsFalse(bg.CheckFreePosition(2, 3));
            Assert.IsFalse(bg.CheckFreePosition(3, 3));
            Assert.IsFalse(bg.CheckFreePosition(4, 3));
            Assert.IsFalse(bg.CheckFreePosition(5, 3));
        }

        [TestMethod]
        public void CheckFreePositionOreolOnExistedVerticalThreeDeckerShouldBeFalseTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Vertical, 3, 2, 2));

            // Assert
            Assert.IsFalse(bg.CheckFreePosition(1, 1));
            Assert.IsFalse(bg.CheckFreePosition(1, 2));
            Assert.IsFalse(bg.CheckFreePosition(1, 3));
            Assert.IsFalse(bg.CheckFreePosition(1, 4));
            Assert.IsFalse(bg.CheckFreePosition(1, 5));
            Assert.IsFalse(bg.CheckFreePosition(2, 1));
            Assert.IsFalse(bg.CheckFreePosition(2, 2));
            Assert.IsFalse(bg.CheckFreePosition(2, 3));
            Assert.IsFalse(bg.CheckFreePosition(2, 4));
            Assert.IsFalse(bg.CheckFreePosition(2, 5));
            Assert.IsFalse(bg.CheckFreePosition(3, 1));
            Assert.IsFalse(bg.CheckFreePosition(3, 2));
            Assert.IsFalse(bg.CheckFreePosition(3, 3));
            Assert.IsFalse(bg.CheckFreePosition(3, 4));
            Assert.IsFalse(bg.CheckFreePosition(3, 5));
        }

        [TestMethod]
        public void CheckFreePositionOreolOnExistedHorizontalFourDeckerShouldBeFalseTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Horizontal, 4, 2, 2));

            // Assert
            Assert.IsFalse(bg.CheckFreePosition(1, 1));
            Assert.IsFalse(bg.CheckFreePosition(2, 1));
            Assert.IsFalse(bg.CheckFreePosition(3, 1));
            Assert.IsFalse(bg.CheckFreePosition(4, 1));
            Assert.IsFalse(bg.CheckFreePosition(5, 1));
            Assert.IsFalse(bg.CheckFreePosition(6, 1));
            Assert.IsFalse(bg.CheckFreePosition(1, 2));
            Assert.IsFalse(bg.CheckFreePosition(2, 2));
            Assert.IsFalse(bg.CheckFreePosition(3, 2));
            Assert.IsFalse(bg.CheckFreePosition(4, 2));
            Assert.IsFalse(bg.CheckFreePosition(5, 2));
            Assert.IsFalse(bg.CheckFreePosition(6, 2));
            Assert.IsFalse(bg.CheckFreePosition(1, 3));
            Assert.IsFalse(bg.CheckFreePosition(2, 3));
            Assert.IsFalse(bg.CheckFreePosition(3, 3));
            Assert.IsFalse(bg.CheckFreePosition(4, 3));
            Assert.IsFalse(bg.CheckFreePosition(5, 3));
            Assert.IsFalse(bg.CheckFreePosition(6, 3));
        }

        [TestMethod]
        public void CheckFreePositionOreolOnExistedVerticalFourDeckerShouldBeFalseTest()
        {
            // Arrange
            BattleGridBase bg = new BattleGridBase();

            // Act
            bg.AddShip(new Ship(Orientation.Vertical, 4, 2, 2));

            // Assert
            Assert.IsFalse(bg.CheckFreePosition(1, 1));
            Assert.IsFalse(bg.CheckFreePosition(1, 2));
            Assert.IsFalse(bg.CheckFreePosition(1, 3));
            Assert.IsFalse(bg.CheckFreePosition(1, 4));
            Assert.IsFalse(bg.CheckFreePosition(1, 5));
            Assert.IsFalse(bg.CheckFreePosition(1, 6));
            Assert.IsFalse(bg.CheckFreePosition(2, 1));
            Assert.IsFalse(bg.CheckFreePosition(2, 2));
            Assert.IsFalse(bg.CheckFreePosition(2, 3));
            Assert.IsFalse(bg.CheckFreePosition(2, 4));
            Assert.IsFalse(bg.CheckFreePosition(2, 5));
            Assert.IsFalse(bg.CheckFreePosition(2, 6));
            Assert.IsFalse(bg.CheckFreePosition(3, 1));
            Assert.IsFalse(bg.CheckFreePosition(3, 2));
            Assert.IsFalse(bg.CheckFreePosition(3, 3));
            Assert.IsFalse(bg.CheckFreePosition(3, 4));
            Assert.IsFalse(bg.CheckFreePosition(3, 5));
            Assert.IsFalse(bg.CheckFreePosition(3, 6));
        }

        //[TestMethod]
        //public void CheckFreePositionOreolShouldBeTrueTest()
        //{
        //    // Arrange
        //    BattleGridBase bg = new BattleGridBase();

        //    // Act and Assert
        //    Assert.IsTrue(bg.CheckFreePosition(1, 1));
        //    Assert.IsTrue(bg.CheckFreePosition(2, 1));
        //    Assert.IsTrue(bg.CheckFreePosition(3, 1));
        //    Assert.IsTrue(bg.CheckFreePosition(1, 2));
        //    Assert.IsTrue(bg.CheckFreePosition(2, 2));
        //    Assert.IsTrue(bg.CheckFreePosition(3, 2));
        //    Assert.IsTrue(bg.CheckFreePosition(1, 3));
        //    Assert.IsTrue(bg.CheckFreePosition(2, 3));
        //    Assert.IsTrue(bg.CheckFreePosition(3, 3));
        //}
    }
}
