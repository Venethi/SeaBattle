using System;
using System.Collections.Generic;

namespace SeaBattle.Model.Ships
{
    public class Ship
    {
        private const int MaxShipLength = 4;
        private const int MaxXValue = 9;
        private const int MaxYValue = 9;

        private Orientation _orientation;

        private IList<Deck> _deck;

        private bool _isSunk;

        public Ship(Orientation orientation, int length, int x, int y)
        {
            if (length <= 0 || length > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if (x < 0 || x > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            if (y < 0 || y > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }

            _orientation = orientation;

            _deck = new List<Deck>();

            if (_orientation == Orientation.Horizontal)
            {
                for (int i = 0; i < length; i++)
                {
                    _deck.Add(new Deck(x + i, y));
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    _deck.Add(new Deck(x, y + i));
                }
            }
        }

        public Orientation Orientation => _orientation;

        public IList<Deck> Deck => _deck;

        public int Length => _deck.Count;

        public bool IsSunk
        {
            get => _isSunk;
            set => _isSunk = value;
        }

        /// <summary>
        /// Checks if XY position is occupied by the ship
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <returns>
        /// True if position is occupied, False if position is free
        /// </returns>
        public bool CheckIfPositionIsOccupied(int x, int y)
        {
            foreach (Deck deck in _deck)
            {
                if (deck.X == x && deck.Y == y)
                {
                    return true;
                }
            }

            return false;
        }

        public void Attack(int x, int y)
        {
            foreach (Deck deck in _deck)
            {
                if (deck.X == x && deck.Y == y)
                {
                    deck.IsHit = true;
                }
            }
        }
    }
}
