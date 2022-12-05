using ConsoleApp1.Enums;
using static System.Console;

namespace ConsoleApp1.Scenes
{
    internal class MainMenu : Frame, IScene
    {
        GameSceneEnum IScene.Name => GameSceneEnum.MainMenu;

        public MainMenu(): base()
        {
            AddComands();
            ShowComands();
        }


        public void Start(string startMessage)
        {

            while (true)
            {
                SetCursorPosition(comandLinePosX + 2, comandLinePosY);
                СommandHandler(ReadLine());
            }
        }


        private void AddComands()
        {
            ComandsList.Add(new Comand("start", "начать игру", () => SceneManager.Load(new Main())));
            ComandsList.Add(new Comand("settings", "настройки игры", () => SendMessage("Пока не релизована")));
        }
    }
}
