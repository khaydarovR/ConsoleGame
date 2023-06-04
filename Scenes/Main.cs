using System.Xml.Linq;
using ConsoleApp1.Enums;
using static System.Console;
using static ConsoleApp1.Scenes.FrameSettings;

namespace ConsoleApp1.Scenes;

internal class Main : Frame, IScene
{
    GameSceneEnum IScene.Name => GameSceneEnum.Main;
    private Character character = new Character();
    public Main(): base()
    {
        Character_OnStatusUpdate();
        AddComands();
        character.OnStatusUpdate += Character_OnStatusUpdate;
        character.OnDeth += Character_OnDeath;
    }

    private void Character_OnDeath()
    {
        SendMessage("Вы умерли");
    }

    private void Character_OnStatusUpdate()
    {
        AddStatus(character.GetAttributes());
    }

    public void Start(string startMessage)
    {
        ShowComands();

        while (true)
        {
            SetCursorPosition(comandLinePosX + 2, comandLinePosY);
            СommandHandler(ReadLine());
        }
    }

    private void AddComands()
    {
        var eatComand = new Comand("eat", "кушать", () =>
        {
            character.Eat();
        });

        ComandsList.Add(eatComand);
    }
}
