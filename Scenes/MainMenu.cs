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
            SetCursorPosition(mapWidth / 3, mapHight / 2 + 5);
            WriteLine("Введите команду start");

            while(true)
                Handler();
        }
        private void Handler()
        {
            SetCursorPosition(comandLinePosX+2, comandLinePosY);
            curentComand = ReadLine();

            if(curentComand == "start")
            {
                SceneManager.Load(new Main());
            }
            switch (curentComand)
            {
                case "start": SceneManager.Load(new Main());
                break;
                case "exit": SendMessage("Так закрой консоль дурень"); 
                break;
                default: SendMessage("Нет такой команды"); 
                break;
            }
        }

    }
}
