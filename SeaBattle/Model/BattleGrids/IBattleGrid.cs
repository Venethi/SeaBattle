using SeaBattle.Model.Ships;

namespace SeaBattle.Model.BattleGrids
{
    public interface IBattleGrid
    {
        void AddShip(IShip ship);
    }
}
