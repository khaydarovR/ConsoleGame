namespace ConsoleApp1.Scenes
{
    public static class FrameSettings
    {
        public static readonly int mapWidth = 80;
        public static readonly int mapHight = 40;

        public static readonly int comandLinePosX = mapWidth / 2;
        public static readonly int comandLinePosY = mapHight - 10;

        public static readonly int comandListX = 3;
        public static readonly int comandListY = 5;
        public static readonly int separatorX = mapWidth / 2 - 10;

        public static readonly int messagePosX = mapWidth / 2;
        public static readonly int messagePosY = comandLinePosY-3;
        public static readonly int distanceBetweenMessages = 2;
        public static readonly int chatSize = 10;

    }
}
