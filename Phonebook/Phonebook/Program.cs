namespace Task3_Phonebook
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ShowMenu();
        }
        /// <summary>
        /// Пользовательское меню.
        /// </summary>
        private static void ShowMenu()
        {
            Console.WriteLine("Добро пожаловать в справочник абонентов.");
            bool exitCase = false;
            while (!exitCase)
            {
                PrintMenu();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        PrintMessage("Добавление нового абонента", ConsoleColor.Green);
                        AddAbonent();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        PrintMessage("Удаление существующего абонента", ConsoleColor.Green);
                        RemoveAbonent();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        PrintMessage("Поиск в базе данных абонентов по номеру телефона", ConsoleColor.Green);
                        SearchByNumber();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        PrintMessage("Поиск в базе данных абонентов по имени", ConsoleColor.Green);
                        SearchByName();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        PrintMessage("Завершение работы с телефонной книгой", ConsoleColor.Green);
                        var phoneBook = Phonebook.GetInstance();
                        phoneBook.SavePhoneBook();
                        exitCase = true;
                        break;
                    default:
                        PrintMessage("Выбран не сущестующий пункт меню", ConsoleColor.Red);
                        break;
                }
            }
        }

        /// <summary>
        /// Вывод меню на консоль.
        /// </summary>
        private static void PrintMenu()
        {
            Console.WriteLine("Выбери пункт меню:");
            Console.WriteLine("1. Добавить нового абонента.");
            Console.WriteLine("2. Удалить абонента.");
            Console.WriteLine("3. Поиск абонента по номеру телефона.");
            Console.WriteLine("4. Поиск абонента по имени.");
            Console.WriteLine("5. Выход.");
        }

        /// <summary>
        /// Вывод текста на экран консоли с раскраской в определенный цвет.
        /// </summary>
        /// <param name="str">Строка символов для вывода в консоль.</param>
        /// <param name="color">Цвет выводимого текста в консоль.</param>
        /// <param name="needClearConsole">Требуется ли очистить окно консоли перед выводом сообщения.</param>
        private static void PrintMessage(string str, ConsoleColor color, bool needClearConsole = true)
        {
            if (needClearConsole)
            {
                Console.Clear();
            }
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }

        /// <summary>
        /// Добавление нового абонента в справочник.
        /// </summary>
        private static void AddAbonent()
        {
            var phoneBook = Phonebook.GetInstance();
            Console.WriteLine("Введите имя нового абонента");
            string name = Console.ReadLine();
            if (name.Equals(""))
            {
                Console.WriteLine("Имя нового абонента не введено");
                return;
            }
            Console.WriteLine("Введите номер нового абонента");
            long number;
            if (!long.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Номер введен не верно");
                return;
            }
            Console.WriteLine(phoneBook.AddAbonent(name, number));
        }

        /// <summary>
        /// Удаление абонента из справочника.
        /// </summary>
        private static void RemoveAbonent()
        {
            var phoneBook = Phonebook.GetInstance();
            Console.WriteLine("Введите номер абонента для удаления.");
            if (long.TryParse(Console.ReadLine(), out long number))
            {
                Console.WriteLine(phoneBook.RemoveAbonent(number));
            }
            else
            {
                Console.WriteLine("Номер введен не верно");
                return;
            }
        }

        /// <summary>
        /// Поиск абонента по номеру телефона
        /// </summary>
        private static void SearchByNumber()
        {
            var phoneBook = Phonebook.GetInstance();
            Console.WriteLine("Введите номер абонента для поиска.");
            if (long.TryParse(Console.ReadLine(), out long number))
            {
                Console.WriteLine(phoneBook.SearchAbonent(number));
            }
            else
            {
                Console.WriteLine("Номер введен не верно");
                return;
            }
        }

        /// <summary>
        /// Поиск абонента по имени
        /// </summary>
        private static void SearchByName()
        {
            var phoneBook = Phonebook.GetInstance();
            Console.WriteLine("Введите имя абонента для поиска.");
            Console.WriteLine(phoneBook.SearchAbonent(Console.ReadLine()));
        }
    }
}