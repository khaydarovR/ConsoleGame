using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
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
    abstract class Frame
    {
        protected const int mapWidth = 60;
        protected const int mapHight = 40;
        protected const int comandLinePosX = mapWidth / 3;
        protected const int comandLinePosY = mapHight-10;
        protected const int messagePosX = mapHight / 3;
        protected const int messagePosY = 5;
        protected string lastMessage;
        protected string curentMessage;
        private int distanceBetweenMessages = 2;

        private const ConsoleColor borderColor = ConsoleColor.Gray;
        public Frame()
        {
            lastMessage = "                         ";
            curentMessage = "                         ";
            SetWindowSize(mapWidth, mapHight);
            SetBufferSize(mapWidth, mapHight);
            //CursorVisible = false;

            SetCursorPosition(comandLinePosX, comandLinePosY);
            Write(">>");

            DrawBorder();
        }
        public void AddStatus(Dictionary<string, int> atr)
        {
            SetCursorPosition(2, 2);
            foreach(var item in atr)
            {
                Write($"{item.Key}: {item.Value}    ");
            }
        }
        public void SendMessage(string text)
        {
            lastMessage = curentMessage;
            curentMessage = text;
            ShowMessages(lastMessage, curentMessage);
        }

        private void ShowMessages(string lastMes, string curentMes)
        {
            ClearMessageArea();
            SetCursorPosition(messagePosX, messagePosY);
            WriteLine(lastMes);
            SetCursorPosition(messagePosX, messagePosY+distanceBetweenMessages);
            WriteLine(curentMes);
        }

        private void ClearMessageArea()
        {
            SetCursorPosition(messagePosX, messagePosY);
            WriteLine(" . . . . . . . . . . . . . . ");
            SetCursorPosition(messagePosX, messagePosY+distanceBetweenMessages);
            WriteLine(" . . . . . . . . . . . . . . ");
        }

        protected void ClearArea(int posX, int posY, int length=mapWidth/2)
        {
            SetCursorPosition(posX, posY);
            for(int i=0; i<length; i++)
            {
                Write(' ');
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
