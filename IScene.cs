using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IScene
    {
        public Enums.GameScenes Name { get;}
        public void Start();
    }
}
