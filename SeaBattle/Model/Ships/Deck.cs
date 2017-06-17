namespace SeaBattle.Model.Ships
{
    public class Deck
    {
        private int _x;

        private int _y;

        private bool _isHit;

        public Deck(int x, int y)
        {
            _x = x;
            _y = y;
            _isHit = false;
        }

        public int X => _x;

        public int Y => _y;

        public bool IsHit
        {
            get => _isHit;

            set
            {
                if (!Equals(_isHit, value))
                {
                    _isHit = value;
                }
            }
        }
    }

    
}
