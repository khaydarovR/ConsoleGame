using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;   

namespace ConsoleApp1.Scenes;

internal class Main: Frame, IScene
{
    GameScenes IScene.Name => GameScenes.Main;
    private string curentComand = "";
    private Character character = new Character();
    public Main()
    {
            
    }
    public void Start()
    {
        AddStatus(character.GetAttributes());
        SetCursorPosition(mapWidth / 3, mapHight / 2);
        WriteLine("status - полный cтатус персонажа");

        while (true)
            Handler();
    }

    private void Handler()
    {
        ClearArea(comandLinePosX + 2, comandLinePosY);
        SetCursorPosition(comandLinePosX + 2, comandLinePosY);
        curentComand = ReadLine();

        switch (curentComand)
        {
            case "status":
                SceneManager.Load(new Main());
                break;
            case "exit":
                SendMessage("Так закрой консоль дурень");
                break;
            default:
                SendMessage("Нет такой команды");
                break;
        }
    }
}
