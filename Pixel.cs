using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    internal struct Pixel
    {
        private const char drawSym = '█';
        public Pixel(): this(0,0, ConsoleColor.Gray)
        {
        }
        public Pixel(int x, int y, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
        public int x { get; }
        public int y { get; }

        private ConsoleColor color { get; set; }

        public void Draw()
        {
            SetCursorPosition(this.x, this.y);
            Write(drawSym);
        }

        public void Clear(int x, int y)
        {
            SetCursorPosition(x, y);
            Write(' ');
        }

    }
}
