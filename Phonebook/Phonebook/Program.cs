using System;
using System.Collections.Generic;

// Класс Abonent
class Abonent
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public Abonent(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }
}

// Класс Phonebook (синглтон)
class Phonebook
{
    private static Phonebook instance;
    private List<Abonent> abonents;

    private Phonebook()
    {
        abonents = new List<Abonent>();
    }

    public static Phonebook GetInstance()
    {
        if (instance == null)
        {
            instance = new Phonebook();
        }
        return instance;
    }

    public void AddAbonent(string name, string phoneNumber)
    {
        abonents.Add(new Abonent(name, phoneNumber));
    }

    public void RemoveAbonent(string phoneNumber)
    {
        Abonent abonent = abonents.Find(a => a.PhoneNumber == phoneNumber);
        if (abonent != null)
        {
            abonents.Remove(abonent);
        }
    }

    public Abonent SearchAbonentByNumber(string phoneNumber)
    {
        return abonents.Find(a => a.PhoneNumber == phoneNumber);
    }

    public List<Abonent> SearchAbonentByName(string name)
    {
        return abonents.FindAll(a => a.Name == name);
    }

    public void SavePhoneBook()
    {
        // Логика сохранения справочника в файл или другое хранилище
        Console.WriteLine("Справочник сохранен.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ShowMenu();
    }

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
                    PrintMessage("Выбран не существующий пункт меню", ConsoleColor.Red);
                    break;
            }
        }
    }

    private static void PrintMenu()
    {
        Console.WriteLine("Выберите пункт меню:");
        Console.WriteLine("1. Добавить нового абонента.");
        Console.WriteLine("2. Удалить абонента.");
        Console.WriteLine("3. Поиск абонента по номеру телефона.");
        Console.WriteLine("4. Поиск абонента по имени.");
        Console.WriteLine("5. Выход.");
    }

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

    private static void AddAbonent()
    {
        Console.WriteLine("Введите имя абонента:");
        string name = Console.ReadLine();
        Console.WriteLine("Введите номер телефона абонента:");
        string phoneNumber = Console.ReadLine();

        var phoneBook = Phonebook.GetInstance();
        phoneBook.AddAbonent(name, phoneNumber);
        PrintMessage($"Абонент {name} с номером {phoneNumber} успешно добавлен в справочник.", ConsoleColor.Yellow, needClearConsole: false);
    }

    private static void RemoveAbonent()
    {
        Console.WriteLine("Введите номер телефона абонента для удаления:");
        string phoneNumber = Console.ReadLine();

        var phoneBook = Phonebook.GetInstance();
        phoneBook.RemoveAbonent(phoneNumber);
        PrintMessage($"Абонент с номером {phoneNumber} успешно удален из справочника.", ConsoleColor.Yellow, needClearConsole: false);
    }

    private static void SearchByNumber()
    {
        Console.WriteLine("Введите номер телефона для поиска:");
        string phoneNumber = Console.ReadLine();

        var phoneBook = Phonebook.GetInstance();
        var abonent = phoneBook.SearchAbonentByNumber(phoneNumber);

        if (abonent != null)
        {
            PrintMessage($"Найден абонент: {abonent.Name}, Номер телефона: {abonent.PhoneNumber}", ConsoleColor.Yellow, needClearConsole: false);
        }
        else
        {
            PrintMessage("Абонент с указанным номером не найден.", ConsoleColor.Red, needClearConsole: false);
        }
    }

    private static void SearchByName()
    {
        Console.WriteLine("Введите имя абонента для поиска:");
        string name = Console.ReadLine();

        var phoneBook = Phonebook.GetInstance();
        var abonents = phoneBook.SearchAbonentByName(name);

        if (abonents.Count > 0)
        {
            foreach (var abonent in abonents)
            {
                PrintMessage($"Найден абонент: {abonent.Name}, Номер телефона: {abonent.PhoneNumber}", ConsoleColor.Yellow, needClearConsole: false);
            }
        }
        else
        {
            PrintMessage("Абонент с указанным именем не найден.", ConsoleColor.Red, needClearConsole: false);
        }
    }
}
