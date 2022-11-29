using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1.Scenes
{
    internal class MainMenu : Frame, IScene
    {
        GameScenes IScene.Name => GameScenes.MainMenu;
        private string curentComand = "";

        public void Start()
        {
            SetCursorPosition(mapWidth / 3, mapHight / 2);
            WriteLine("Добро пожоловать в игру");
            SetCursorPosition(mapWidth / 3, mapHight / 2 + 1);
            WriteLine("start - начать игру");
            SetCursorPosition(mapWidth / 3, mapHight / 2 + 2);
            WriteLine("setting - настройки игры?");
            SetCursorPosition(mapWidth / 3, mapHight / 2 + 3);
            WriteLine("exit - выйти из игры");

            while (true)
                Handler();
        }
        private void Handler()
        {
            ClearArea(comandLinePosX+2, comandLinePosY);
            SetCursorPosition(comandLinePosX+2, comandLinePosY);
            curentComand = ReadLine();

            switch (curentComand)
            {
                case "start":
                    SceneManager.Load(new Main());
                    break;
                case "exit": SendMessage("Так закрой консоль дурень"); 
                break;
                default: SendMessage("Нет такой команды"); 
                break;
            }
        }

    }
}
