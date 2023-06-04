using static ConsoleApp1.Scenes.FrameSettings;
using static System.Console;

namespace ConsoleApp1.Scenes
{
    abstract class Frame
    {
        static string? lastMessage;
        static string? curentMessage;
        static Dictionary<string, int>? oldValue = null;
        private Chat chat;

        protected List<Comand> ComandsList = new();

        public Frame()
        {
            chat = Chat.getInstance();
            CreateComands();

            lastMessage = "                         ";
            curentMessage = "                         ";
            SetWindowSize(mapWidth, mapHight);
            SetBufferSize(mapWidth, mapHight);
            DrawBorder();
            DrawSeparatorComandsList();
            DrawSeparatorStatus();


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
                    SendMessage(comand.Result);
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
                SendMessage($"{newComand}-не найден");
            }

        }

        public void AddStatus(Dictionary<string, int> attributes)
        {
            string[] change = new string[attributes.Count];
            if (oldValue is null)
            {
                oldValue = attributes.ToDictionary(entry => entry.Key, entry => entry.Value);
            }

            for (int i = 0; i < change.Length; i++)
            {
                if (attributes.ElementAt(i).Value > oldValue.ElementAt(i).Value)
                {
                    change[i] = "↑";
                    continue;
                }
                if (attributes.ElementAt(i).Value < oldValue.ElementAt(i).Value)
                {
                    change[i] = "↓";
                    continue;
                }
                if(attributes.ElementAt(i).Value == oldValue.ElementAt(i).Value)
                {
                    change[i] = "→"; 
                }
            }

            SetCursorPosition(2, 2);
            int j = 0;
            foreach (var atirbut in attributes)
            {
                Write($"{atirbut.Key}: {change[j]}{atirbut.Value}      ");
                j++;
            }
            oldValue = attributes.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        public void SendMessage(string text)
        {
            chat.Push(text);
            ShowMessages(chat);
        }

        protected void ClearArea(int posX, int posY)
        {
            int length = mapWidth / 3;
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
                ClearArea(comandListX, comandListY + i);
                SetCursorPosition(comandListX, comandListY + i);
                WriteLine(ComandsList[i].Name + $" - {ComandsList[i].Description}");
            }
        }

        private void ShowMessages(Chat chat)
        {
            ClearMessageArea();
            SetCursorPosition(messagePosX, messagePosY);
            for (int i = 0; i < chat.CurrentSize; i++)
            {
                SetCursorPosition(messagePosX, messagePosY - distanceBetweenMessages * i);
                WriteLine(chat.MessaagesList[i]);
            }
        }

        private void ClearMessageArea()
        {
            for(int i=0; i<chat.CurrentSize; i++)
            {
                SetCursorPosition(messagePosX, messagePosY-i*distanceBetweenMessages);
                WriteLine(" . . . . . . . . . . . . . . ");
            }
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

        private void DrawSeparatorComandsList()
        {
            for (int i = 3; i < mapHight; i++)
            {
                new Pixel(separatorX, i).Draw();
            }
        }

        private void DrawSeparatorStatus()
        {
            for (int i = 0; i < mapWidth; i++)
            {
                new Pixel(i, 3).Draw();
            }
        }

        private void CreateComands()
        {
            ComandsList.Add(new Comand("menu", "возврат в меню", () => SceneManager.Load(new MainMenu())));
            ComandsList.Add(new Comand("exit", "выход из игры", () => SendMessage("Закройте консоль")));
        }
    }
}
