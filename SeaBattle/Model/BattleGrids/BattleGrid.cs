using System;
using System.Collections.Generic;
using SeaBattle.Core.Types;
using SeaBattle.Model.Ships;

namespace SeaBattle.Model.BattleGrids
{
    public class BattleGrid : IBattleGrid
    {
        public const int MaxGridSize = 10;

        private int[,] _grid;

        private List<Ship> _ships;

        public BattleGrid()
        {
            _grid = new int[MaxGridSize, MaxGridSize];

            for (int i = 0; i < MaxGridSize; i++)
            {
                for (int j = 0; j < MaxGridSize; j++)
                {
                    _grid[i, j] = 0;
                }
            }

            _ships = new List<Ship>();
        }

        public List<Ship> Ships => _ships;

        public void AddShip(Ship ship)
        {
            throw new NotImplementedException();
        }
    }
}
