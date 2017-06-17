using System;
using System.Collections.Generic;

namespace SeaBattle.Model.Ships
{
    public class Ship
    {
        private const int MaxShipLength = 4;
        private const int MaxXValue = 9;
        private const int MaxYValue = 9;

        private IList<Deck> _deck;

        private Orientation _orientation;

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
            _deck = new List<Deck>();

            if (orientation == Orientation.Horizontal)
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

        public IList<Deck> Deck => _deck;

        public Orientation Orientation => _orientation;

        public bool IsSunk
        {
            get => _isSunk;
            set => _isSunk = value;
        }
    }
}
