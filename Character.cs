using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    sealed class Character
    {
        static private Random rand = new Random();

        private Dictionary<string, int> attributes = new();
        private int hunger;
        private int energy;
        public Character() 
        {
            Hunger = rand.Next(0,100);
            Energy = rand.Next(0, 100);
        }

        public Dictionary<string, int> GetAttributes()
        {
            attributes["Голод"] = Hunger;
            attributes["Энергия"] = Energy;
            return attributes;
        }
        public int Hunger
        {
            get { return hunger; }
            set
            {
                if (value >= 0 && value <= 100) { hunger = value; }
                else { hunger = 0;}
            }
        }
        public int Energy
        {
            get { return energy; }
            set
            {
                if (value >= 0 && value <= 100) { energy = value; }
                else { energy = 0;}
            }
        }

    }
}
