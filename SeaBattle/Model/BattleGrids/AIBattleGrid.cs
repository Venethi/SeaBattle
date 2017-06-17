using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle.Model.Ships;

namespace SeaBattle.Model.BattleGrids
{
    public class AIBattleGrid : BattleGrid
    {
        public AIBattleGrid()
        {
            
        }

        public override void SetupShips()
        {
            int[] ships = {4, 3, 3, 2, 2, 2, 1, 1, 1, 1};
            Random random = new Random();

            for (int i = 0; i < ships.Length; i++)
            {
                //ToDo: Реализовать буффер свободных ячеек

                var orientation = (Orientation) random.Next(0, 1);
                var x = random.Next(0, 9);
                var y = random.Next(0, 9);

                if (checkPositionForShip(x, y, ships[i], orientation))
                {
                    Ships.Add(new Ship(orientation, ships[i], x, y));

                    //ToDo: Обвовить состояние ячеек
                }
                else
                {
                    
                }

            }
        }

        private bool checkPositionForShip(int x, int y, int shipLength, Orientation orientation)
        {
            bool result = true;

            //ToDo: Проверка на крайние ячейки

            if (orientation == Orientation.Horizontal)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < shipLength; j++)
                    {
                        if (Cells[x - 1 + j][y - 1 + i].IsOccupied ||
                            Cells[x -1 + j][y - 1 + i].IsBufferZone)
                        {
                            result = false;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < shipLength; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Cells[x - 1 + j][y - 1 + i].IsOccupied ||
                            Cells[x - 1 + j][y - 1 + i].IsBufferZone)
                        {
                            result = false;
                        }
                    }
                }
            }

            return result;
        }
    }
}
