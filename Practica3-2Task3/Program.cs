
namespace MathHelper
{
    public class Person
    {
        public Person() { }

        public Person(string name, int age)
        {
            Console.Write("Введите своё имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите свой возраст: ");
            int age = Console.ReadLine();

            Console.WriteLine($"Привет, {name}. Возраст {age}");
        }
    }
}