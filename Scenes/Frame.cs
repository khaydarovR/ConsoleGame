using static System.Console;

namespace ConsoleApp1.Scenes
{
    abstract class Frame
    {
        protected const int mapWidth = 80;
        protected const int mapHight = 40;

        protected const int comandLinePosX = mapWidth / 3;
        protected const int comandLinePosY = mapHight - 10;
        protected const int messagePosX = mapHight / 2;
        protected const int messagePosY = 3;
        protected string lastMessage;
        protected string curentMessage;
        private int distanceBetweenMessages = 2;

        protected List<Comand> ComandsList = new();

        public Frame()
        {
            CreateComands();

            lastMessage = "                         ";
            curentMessage = "                         ";
            SetWindowSize(mapWidth, mapHight);
            SetBufferSize(mapWidth, mapHight);
            DrawBorder();

            SetCursorPosition(comandLinePosX, comandLinePosY);
            Write(">>");
            SetCursorPosition(comandLinePosX + 2, comandLinePosY);
        }

        protected void СommandHandler(string newComand)
        {
            ClearArea(comandLinePosX + 2, comandLinePosY);
            SetCursorPosition(comandLinePosX + 2, comandLinePosY);
            var cmd_not_found = false;
            foreach (var comand in ComandsList)
            {
                if (newComand == comand.Name && comand.is_accessible)
                {
                    comand.Action();
                    return;
                }
                else if (newComand == comand.Name && !comand.is_accessible)
                {
                    SendMessage("Эта команда не доступна в текущий момент");
                    return;
                }
                else
                {
                    cmd_not_found = true;
                }
            }
            if (cmd_not_found)
            {
                SendMessage($"{newComand} не найден");
            }

        }

        public void AddStatus(Dictionary<string, int> attributes)
        {
            SetCursorPosition(2, 2);
            foreach (var atirbut in attributes)
            {
                Write($"{atirbut.Key}: {atirbut.Value}    ");
            }
        }
        public void SendMessage(string text)
        {
            lastMessage = curentMessage;
            curentMessage = text;
            ShowMessages(lastMessage, curentMessage);
        }

        protected void ClearArea(int posX, int posY, int length = mapWidth / 3)
        {
            SetCursorPosition(posX, posY);
            for (int i = 0; i < length; i++)
            {
                Write(' ');
            }
        }

        protected void ShowComands()
        {
            for (var i = 0; i < ComandsList.LongCount(); i++)
            {
                ClearArea(mapWidth / 3, mapHight / 2 + i);
                SetCursorPosition(mapWidth / 3, mapHight / 2 + i);
                WriteLine(ComandsList[i].Name + $" - {ComandsList[i].Description}");
            }
        }

        private void ShowMessages(string lastMes, string curentMes)
        {
            ClearMessageArea();
            SetCursorPosition(messagePosX, messagePosY);
            WriteLine(lastMes);
            SetCursorPosition(messagePosX, messagePosY + distanceBetweenMessages);
            WriteLine(curentMes);
        }

        private void ClearMessageArea()
        {
            SetCursorPosition(messagePosX, messagePosY);
            WriteLine(" . . . . . . . . . . . . . . ");
            SetCursorPosition(messagePosX, messagePosY + distanceBetweenMessages);
            WriteLine(" . . . . . . . . . . . . . . ");
        }

        private void DrawBorder()
        {
            for (int i = 0; i < mapWidth; i++)
            {
                new Pixel(i, 0).Draw();
                new Pixel(i, mapHight - 1).Draw();
            }

            for (int i = 0; i < mapHight; i++)
            {
                new Pixel(0, i).Draw();
                new Pixel(mapWidth - 1, i).Draw();
            }
        }

        private void CreateComands()
        {
            ComandsList.Add(new Comand("menu", "возврат в меню", () => SceneManager.Load(new MainMenu())));
            ComandsList.Add(new Comand("exit", "выход из игры", () => SendMessage("Закройте консоль")));
        }
    }
}
