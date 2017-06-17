using System.Collections.Generic;

using SeaBattle.Model.Ships;

namespace SeaBattle.Model.BattleGrids
{
    public abstract class BattleGrid
    {
        #region Constants

        public const int MaxGridSize = 10;

        #endregion Constants

        private List<List<Cell>> _cells;

        private List<Ship> _ships;

        public List<List<Cell>> Cells => _cells;

        public List<Ship> Ships => _ships;

        public void InitBattleGrid()
        {
            _cells = new List<List<Cell>>();

            for (int i = 0; i < MaxGridSize; i++)
            {
                _cells.Add(new List<Cell>());

                for (int j = 0; j < MaxGridSize; j++)
                {
                    _cells[i].Add(new Cell(i,j) );
                }
            }
        }

        public virtual void SetupShips()
        {
            
        }
    }
}
