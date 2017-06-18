﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaBattle.Core.Types;
using SeaBattle.Model.BattleGrids;
using SeaBattle.Model.Ships;

namespace SeaBattle.Tests
{
    [TestClass]
    public class BattleGridTests
    {
        [TestMethod]
        [ExpectedException(typeof(WrongPositionException))]
        public void TwoShipsCollisionTest()
        {
            // Arrange
            IBattleGrid bg = new BattleGrid();

            // Act
            bg.AddShip(new Ship(Orientation.Horizontal, 4, 1, 1));
            bg.AddShip(new Ship(Orientation.Horizontal, 3, 3, 1));
        }

        [TestMethod]
        public void AttackShipTest()
        {
            
        }
    }
}
