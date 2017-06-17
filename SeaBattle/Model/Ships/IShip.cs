using System.Collections.Generic;

namespace SeaBattle.Model.Ships
{
    public interface IShip
    {
        Orientation Orientation { get; }

        IList<Deck> Deck { get; }

        int X { get; }

        int Y { get; }

        bool IsSunk { get; set; }
    }
}
