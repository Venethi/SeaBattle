using System;
using System.Collections.Generic;
using SeaBattle.Core.Types;
using SeaBattle.Model.Ships;

namespace SeaBattle.Model.BattleGrids
{
    public class BattleGridBase
    {
        public const int MaxGridSize = 10;

        private int[,] _grid;

        private List<Ship> _ships;

        public BattleGridBase()
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

        public bool CheckFreePosition(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void AddShip(Ship ship)
        {
            throw new NotImplementedException();
        }
    }
}
