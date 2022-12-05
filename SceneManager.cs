namespace ConsoleApp1
{
    public static class SceneManager
    {
        public static void Load(IScene nextScene)
        {
            nextScene.Start("Здраствуй путник");
        }
    }
}

