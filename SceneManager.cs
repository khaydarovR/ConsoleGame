using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Enums;

namespace ConsoleApp1
{
    public static class SceneManager
    {
        public static void Load(IScene nextScene)
        {
            nextScene.Start();
        }
    }
}
