using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model.BattleGrids
{
    public class Cell
    {
        private int _x;

        private int _y;

        private bool _isOccupied;

        private bool _isBufferZone;

        private CellState _state;

        public Cell(int row, int column)
        {
            _x = row;
            _y = column;
            _isOccupied = false;
            _isBufferZone = false;
        }

        public int X => _x;

        public int Y => _y;

        public bool IsOccupied
        {
            get => _isOccupied;
            set => _isOccupied = value;
        }

        public bool IsBufferZone
        {
            get => _isBufferZone;
            set => _isBufferZone = value;
        }

        public CellState State
        {
            get => _state;
            set => _state = value;
        }
    }
}
