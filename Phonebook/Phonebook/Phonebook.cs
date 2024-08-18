using System.Text.Json;

namespace Task3_Phonebook
{
    internal class Phonebook
    {
        private static string PhonebookFile { get { return "phonebook.txt"; } }
        private class Abonent
        {
            public long number { get; set; }
            public string name { get; set; }
            public Abonent(long number, string name)
            {
                this.number = number;
                this.name = name;
            }
        }
        private static List<Abonent> abonents;
        private static Phonebook instance;
        private Phonebook() { }
        public static Phonebook GetInstance()
        {
            if (instance == null)
            {
                instance = new Phonebook();
                abonents = new List<Abonent>();
                instance.LoadPhoneBook();
            }
            return instance;
        }

        /// <summary>
        /// Добавление нового абонента.
        /// </summary>
        /// <param name="name">Имя абонента</param>
        /// <param name="number">Номер абонента</param>
        /// <returns>Результат добавления.</returns>
        public string AddAbonent(string name, long number)
        {
            if (abonents.Any(x => x.number == number))
            {
                return "Такой абонент уже существует";
            }
            abonents.Add(new Abonent(number, name));
            SavePhoneBook();
            return "Новый абонент добавлен";
        }

        /// <summary>
        /// Удаление абонента по номеру телефона.
        /// </summary>
        /// <param name="number">Номер телефона абонента.</param>
        /// <returns>Результат удаления абонента.</returns>
        public string RemoveAbonent(long number)
        {
            if (abonents.Any(x => x.number == number))
            {
                abonents.RemoveAt(abonents.FindIndex(x => x.number == number));
                return $"Абонент с номером {number} удален из справочника.";
            }
            else
            {
                return "Абонента с таким номером не найдено.";
            }
        }

        /// <summary>
        /// Поиск абонента по имени.
        /// </summary>
        /// <param name="name">Имя абонента.</param>
        /// <returns>Результаты поиска по заданному имени.</returns>
        public string SearchAbonent(string name)
        {
            if (abonents.Any(x => x.name.ToLower().Equals(name.ToLower())))
            {
                string str = "";
                if (abonents.Where(x => x.name.ToLower().Equals(name.ToLower())).Count() > 1)
                    str += "Найденные абоненты по имени:\r\n";
                else
                    str += "Найденный абонент по имени:\r\n";
                foreach (var abonent in abonents.Where(x => x.name.ToLower().Equals(name.ToLower())))
                {
                    str += $"{abonent.number}: {abonent.name} \r\n";
                }
                return str;
            }
            else
            {
                return "Абонента с таким именем не найден.";
            }
        }

        /// <summary>
        /// Поиск абонента по номеру телефона.
        /// </summary>
        /// <param name="number">Номер телефона абонента.</param>
        /// <returns>Результаты поиска по номеру телефона.</returns>
        public string SearchAbonent(long number)
        {
            if (abonents.Any(x => x.number == number))
            {
                string str = "Найденный абонент по номеру:\r\n";
                foreach (var abonent in abonents.Where(x => x.number == number))
                {
                    str += $"{abonent.number}: {abonent.name}\r\n";
                }
                return str;
            }
            else
            {
                return "Абонент с таким номером не найден.";
            }
        }

        /// <summary>
        /// Загрузка справочника из файла.
        /// </summary>
        public void LoadPhoneBook()
        {
            if (File.Exists(PhonebookFile))
            {
                using (StreamReader r = new StreamReader(PhonebookFile))
                {
                    string json = r.ReadToEnd();
                    abonents = JsonSerializer.Deserialize<List<Abonent>>(json);
                }
            }
        }
        /// <summary>
        /// Сохранение справочника в файл.
        /// </summary>
        public void SavePhoneBook()
        {
            var json = JsonSerializer.Serialize(abonents);
            File.WriteAllText(PhonebookFile, json);
        }
    }
}