using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Scenes
{
    internal class Main: IScene
    {
        public GameScenes Name => GameScenes.Main;

        public void Start()
        {

            while (true)
            {
                Console.WriteLine("scene main");
            }
        }
    }
}
