using ConsoleApp1.Enums;
using static System.Console;

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
        ComandsList.Add(new Comand("eat", "кушать", () => character.Eat()));
    }

}
