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

        private int _x;

        private int _y;

        private bool _isSunk;

        public Ship(Orientation orientation, int length,  int x, int y)
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
            _x = x;
            _y = y;

            _deck = new List<Deck>();

            if (_orientation == Orientation.Horizontal)
            {
                for (int i = 0; i < length; i++)
                {
                    _deck.Add(new Deck(_x + i, _y));
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    _deck.Add(new Deck(_x, _y + i));
                }
            }
        }

        public Orientation Orientation => _orientation;

        public IList<Deck> Deck => _deck;

        public int X => _x;

        public int Y => _y;

        public bool IsSunk
        {
            get => _isSunk;
            set => _isSunk = value;
        }
    }
}
