using ConsoleApp1.Enums;
using System.ComponentModel;
using System.Reflection;

namespace ConsoleApp1
{
    sealed class Character
    {
        public delegate void StatusUpdater();
        public event StatusUpdater? OnStatusUpdate;
        private Dictionary<string, int> attributes = new();
        private int hunger;
        private int energy;

        public Character()
        {
            Random rand = new Random();
            Hunger = rand.Next(0, 100);
            Energy = rand.Next(0, 100);
        }

        public Dictionary<string, int> GetAttributes()
        {
            attributes[GetDescription(AttributeEnum.Hunger)] = Hunger;
            attributes[GetDescription(AttributeEnum.Energy)] = Energy;
            return attributes;
        }

        internal void Eat(int value = 5)
        {
            Hunger += value;
            Energy -= value / 2;
        }

        public int Hunger
        {
            get { return hunger; }
            set
            {
                if (value >= 0 && value <= 100) { hunger = value; }
                else { hunger = 0; }
                OnStatusUpdate?.Invoke();
            }
        }
        public int Energy
        {
            get { return energy; }
            set
            {
                OnStatusUpdate?.Invoke();
                if (value >= 0 && value <= 100) { energy = value; }
                else { energy = 0; }
                OnStatusUpdate?.Invoke();
            }
        }

        static string GetDescription(Enum enumElement)
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
