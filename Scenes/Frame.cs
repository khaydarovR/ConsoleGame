using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using static System.Console;

namespace ConsoleApp1.Scenes
{
    internal class Frame
    {
        private const int maxMessageCount = 5;
        private int curentMessageCount = 0;
        protected const int mapWidth = 60;
        protected const int mapHight = 40;
        protected const int comandLinePosX = mapWidth / 3;
        protected const int comandLinePosY = mapHight-10;
        protected const int messagePosX = mapHight / 3;
        protected const int messagePosY = 10;
        protected Queue<string> allMessages;

        private const ConsoleColor borderColor = ConsoleColor.Gray;
        public Frame()
        {
            allMessages = new Queue<string>();
            SetWindowSize(mapWidth, mapHight);
            SetBufferSize(mapWidth, mapHight);
            //CursorVisible = false;

            SetCursorPosition(comandLinePosX, comandLinePosY);
            Write(">>");

            DrawBorder();
        }

        protected void SendMessage(string text)
        {
            //тут ч очердями
            if (curentMessageCount >= maxMessageCount)
            {
                allMessages.Dequeue();
                curentMessageCount--;
            }
            allMessages.Enqueue(text);
            curentMessageCount++;

            ShowMessages();
        }

        protected void ShowMessages()
        {
            foreach (var message in allMessages)
            {
                SetCursorPosition(messagePosX, messagePosY - curentMessageCount);
                WriteLine(message);
            }
        }
        private void DrawBorder()
        {
            for (int i = 0; i < mapWidth; i++)
            {
                new Pixel(i, 0, borderColor).Draw();
                new Pixel(i, mapHight - 1, borderColor).Draw();
            }

            for (int i = 0; i < mapHight; i++)
            {
                new Pixel(0, i, borderColor).Draw();
                new Pixel(mapWidth - 1, i, borderColor).Draw();
            }
        }

    }
}
