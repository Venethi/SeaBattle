using System;
using System.Collections.Generic;
using SeaBattle.Core.Types;
using SeaBattle.Model.Ships;

namespace SeaBattle.Model.BattleGrids
{
    public class BattleGridBase
    {
        private List<Ship> _ships;

        public BattleGridBase()
        {
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
                        if (ship.CheckIfPositionIsOccupied(x + i - Convert.ToInt32(x != 0), y + j - Convert.ToInt32(y != 0)))
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
            if (ship.Orientation == Orientation.Horizontal && ship.Length + ship.Deck[0].X > 10)
            {
                throw new OutOfRangePositionException();
            }

            if (ship.Orientation == Orientation.Vertical && ship.Length + ship.Deck[0].Y > 10)
            {
                throw new OutOfRangePositionException();
            }

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
