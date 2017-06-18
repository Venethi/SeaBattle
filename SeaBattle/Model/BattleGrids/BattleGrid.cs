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
            if (checkPositionForShip(ship))
            {
                _ships.Add(ship);

                foreach (Deck deck in ship.Deck)
                {
                    _grid[deck.X, deck.Y] = 1;
                }
            }
            else
            {
                throw new WrongPositionException();
            }
        }

        private bool checkPositionForShip(Ship ship)
        {
            if (ship.Orientation == Orientation.Horizontal)
            {
                if (ship.X + ship.Deck.Count >= MaxGridSize)
                {
                    return false;
                }

                for (int i = 0; i < ship.Deck.Count; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_grid[
                            ship.X + i - Convert.ToInt32(ship.X != 0),
                            ship.Y + j - Convert.ToInt32(ship.Y != 0)
                            ] == 1)
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                if (ship.Y + ship.Deck.Count >= MaxGridSize)
                {
                    return false;
                }

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < ship.Deck.Count; j++)
                    {
                        if (_grid[
                                ship.X + i - Convert.ToInt32(ship.X != 0),
                                ship.Y + j - Convert.ToInt32(ship.Y != 0)
                            ] == 1)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
