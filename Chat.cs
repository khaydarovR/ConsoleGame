using System.Reflection;
using System.Security;
using static ConsoleApp1.Scenes.FrameSettings;
namespace ConsoleApp1;
public class Chat
{
    private static Chat instance;
    public int CurrentSize = 0;

    public readonly string[] MessaagesList;


    private Chat()
    {
        MessaagesList= new string[chatSize];
    }

    public static Chat getInstance()
    {
        if (instance == null)
            instance = new Chat();
        return instance;
    }

    public void Push(string message)
    {
        if (CurrentSize < chatSize)
        {
            ++CurrentSize;
            RaiseMessages();
            MessaagesList[0] = message;
        }
        else
        {
            RaiseMessages();
            MessaagesList[0] = message;
        }

    }

    private void RaiseMessages()
    {

        for(int i=chatSize-1; i>0; i--)
        {
            MessaagesList[i] = MessaagesList[i - 1];
        }
    }

}
