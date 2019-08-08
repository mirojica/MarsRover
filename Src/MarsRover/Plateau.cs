namespace MarsRover
{
    internal class Plateau
    {
        public int Width { get; }
        public int Height { get; }

        private Plateau(int width, int height)
        {
            Width = width;
            Height = height;
        }

        internal static Plateau Size(int width, int height) => new Plateau(width, height);
    }
}
