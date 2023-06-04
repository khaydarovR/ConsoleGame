namespace ConsoleApp1
{
    public class Comand
    {
        public List<Comand> ComandList = new();

        public string Name { get; set; }
        public string Description { get; set; }

        public Action Action;

        public bool is_accessible = true;

        public string Result { get; set; }


        public Comand(string name, string description, Action func, string resultMessage = "") //Действие по умолчанию
        {
            description = description == "" ? "Не реализована" : description;

            if (name == null) throw new ArgumentNullException();

            var selectedComand = ComandList.Where(c => c.Name.Contains(name));
            if (selectedComand.Count() > 0)
            {
                throw new ArgumentNullException($"{selectedComand.FirstOrDefault()} - Такая команда уже существует");
            }

            ComandList.Add(this);
            is_accessible = true;


            Result = resultMessage == "" ?  $"{name} выполена" : resultMessage;
            Name = name;
            Description = description;
            Action = func;
        }
    }
}