namespace GladiApi
{
    public sealed class ItemDimension
    {
        private int _x;
        private int _y;

        public ItemDimension(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X { get => _x; }
        public int Y { get => _y; }
    }
}
