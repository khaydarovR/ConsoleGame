using static System.Console;

namespace ConsoleApp1
{
    internal struct Pixel
    {
        private const char drawSym = '█';
        public Pixel() : this(0, 0)
        {
        }
        public Pixel(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int x { get; }
        public int y { get; }


        public void Clear(int x, int y)
        {
            SetCursorPosition(x, y);
            Write(' ');
        }

        public void Draw()
        {
            SetCursorPosition(this.x, this.y);
            Write(drawSym);
        }

    }
}
