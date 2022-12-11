using ConsoleApp1.Scenes;

namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        SceneManager.Load(new MainMenu());
    }
}

//TODO:
// divide Frame class(visual/logic)
// fix Character status
// manage folder
