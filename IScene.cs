namespace ConsoleApp1
{
    public interface IScene
    {
        public Enums.GameSceneEnum Name { get; }
        public void Start(string startMessage);

    }
}
