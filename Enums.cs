using System.ComponentModel;

namespace ConsoleApp1.Enums
{
    public enum GameSceneEnum
    {
        MainMenu,
        Main,
    }

    public enum AttributeEnum
    {
        [Description("Голод")]
        Hunger,
        [Description("Энергия")]
        Energy,
    }
}
