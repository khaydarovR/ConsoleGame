using ConsoleApp1.Enums;
using System.ComponentModel;
using System.Reflection;

namespace ConsoleApp1
{
    sealed class Character
    {
        public delegate void StatusUpdater();
        public event StatusUpdater? OnStatusUpdate;

        public event Action? OnDeth;

        private Dictionary<string, int> attributes = new();
        private int hunger;
        private int energy;
        private int health;

        private int oldHunger;
        private int oldEnergy;
        private int oldHealth;

        public Character()
        {
            Random rand = new Random();
            hunger = rand.Next(50, 80);
            energy = rand.Next(50, 80);
            health = rand.Next(50, 80);
            oldHunger = hunger;
            oldEnergy = energy;
            oldHealth = health;
        }


        public Dictionary<string, int> GetAttributes()//string -> Enum
        {
            attributes[GetDescription(AttributeEnum.Hunger)] = Hunger;
            attributes[GetDescription(AttributeEnum.Energy)] = Energy;
            attributes[GetDescription(AttributeEnum.Health)] = Health;
            return attributes;
        }


        private void StateUpdate()
        {
            HandlerStatus();
            OnStatusUpdate?.Invoke();
        }


        internal void Eat(int value = 5)
        {
            Hunger += value;
            Energy -= value;
            StateUpdate();
        }

        public int Hunger
        {
            get { return hunger; }
            set
            {
                if (value >= 100) { hunger = 100; }
                else if (value <= 0) { hunger = 0; }
                hunger = value;        
            }
        }
        public int Energy
        {
            get { return energy; }
            set
            {
                if (value >= 100) { energy = 100; }
                else if (value <= 0) { energy = 0; }
                energy = value;
            }
        }

        public int Health
        {
            get { return health; }
            set
            {
                if(value <= 0)
                {
                    health = 0;
                    Dead();
                }
                health = value;
            }
        }

        private void Dead()
        {
            OnDeth?.Invoke();
        }


        private void HandlerStatus()
        {
            if(energy == 0 || hunger == 0)
            {
                Health -= 2;
            }
        }


        private static string GetDescription(Enum enumElement)
        {
            Type type = enumElement.GetType();

            MemberInfo[] memInfo = type.GetMember(enumElement.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return enumElement.ToString();
        }
    }
}
