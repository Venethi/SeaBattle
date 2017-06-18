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
            foreach (Ship ship in _ships)
            {
                for (int i = 0; i < 3 - Convert.ToInt32(x == 0 && x == 9); i++)
                {
                    for (int j = 0; j < 3 - Convert.ToInt32(y == 0 && y == 9); j++)
                    {
                        if (ship.IsOccupiedPosition(x + i - Convert.ToInt32(x != 0), y + j - Convert.ToInt32(y != 0)))
                        {
                            return false;
                        }
                    }   
                }
            }

            return true;
        }

        public void AddShip(Ship ship)
        {
            //ToDo: Сделать проверку на выход корабля за границы

            //if (ship.Orientation == Orientation.Horizontal)
            //{
            //    if (ship.Deck.Coun)
            //    {
                    
            //    }
            //}
            //else
            //{
                
            //}

            foreach (Deck deck in ship.Deck)
            {
                if (!CheckFreePosition(deck.X, deck.Y))
                {
                    throw new OccupiedPositionException();
                }
            }

            _ships.Add(ship);
        }
    }
}
