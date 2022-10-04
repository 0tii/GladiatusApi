namespace GladiApi
{
    public class Durability
    {
        private int _current;
        private int _max;

        public Durability(int current, int max)
        {
            _current = current;
            _max = max;
        }

        public int Current { get => _current; set => _current = value; }
        public int Max { get => _max; set => _max = value; }
    }
}
