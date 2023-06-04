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
        [Description("Сытость")]
        Hunger,
        [Description("Энергия")]
        Energy,
        [Description("Здоровье")]
        Health
    }
}
