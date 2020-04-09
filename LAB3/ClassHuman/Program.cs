using System;
using System.Text;

namespace _ИСП_ЛР3
{
    class Program
    {
        static void Main(string[] args)
        {
            Human humans = new Human();
            //Students[] students = new Students[50];
            humans[0] = new Human(1, "Петров", "Пётр", "Петрович", "мужской", 18, 180, 90);
            bool check = true;
            while (check)
            {
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1) Просмотреть все личные дела");
                Console.WriteLine("2) Просмотреть определённое личное дело");
                Console.WriteLine("3) Добавить личное дело");
                Console.WriteLine("4) Изменить существующее личное дело");
                Console.WriteLine("5) Поиск по возрасту");
                Console.WriteLine("6) Поиск по росту");
                Console.WriteLine("7) Сортировать по возрасту");
                Console.WriteLine("8) Сортировать по росту");
                Console.WriteLine("9) Выход");
                string choiceInput = Console.ReadLine();
                int choice;
                while (!(Int32.TryParse(choiceInput, out choice)) || choice <= 0 || choice > 9)
                {
                    Console.WriteLine("Неверный ввод, попробуйте снова : ");
                    choiceInput = Console.ReadLine();
                }
                switch (choice)
                {
                    case 1:
                        for (int i = 0; i < Human.count - 1; i++)
                        {
                            humans[i].Print();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Введите номер личного дела");
                        string choiceInputIde = Console.ReadLine();
                        int ideChoice;
                        while (!(Int32.TryParse(choiceInputIde, out ideChoice)) || ideChoice <= 0)
                        {
                            Console.WriteLine("Неверный ввод, попробуйте снова : ");
                            choiceInputIde = Console.ReadLine();
                        }
                        Human.SearchByIde(humans, Human.count - 1, ideChoice);
                        break;
                    case 3:
                        humans[Human.count - 1] = new Human();
                        humans[Human.count - 1].Add();
                        break;
                    case 4:
                        Console.WriteLine("Введите номер личного дела, которое хотите изменить : ");
                        string choiceInputWork = Console.ReadLine();
                        int workChoice;
                        while (!(Int32.TryParse(choiceInputWork, out workChoice)) || workChoice <= 0)
                        {
                            Console.WriteLine("Неверный ввод, попробуйте снова : ");
                            choiceInputWork = Console.ReadLine();
                        }
                        int checker = 0;
                        int index = 0;
                        for (int i = 0; i < Human.count - 1; i++)
                        {
                            if (humans[i].Ide == workChoice)
                            {
                                humans[i].Print();
                                checker++;
                                index = i;
                            }
                        }
                        if (checker == 0)
                        {
                            Console.WriteLine("Нет такого личного дела");
                            break;
                        }
                        bool exit = true;
                        while (exit)
                        {
                            Console.WriteLine("Введите поле, которое хотите изменить : ");
                            Console.WriteLine("1) Фамилия");
                            Console.WriteLine("2) Имя");
                            Console.WriteLine("3) Отчество");
                            Console.WriteLine("4) Возраст");
                            Console.WriteLine("5) Рост");
                            Console.WriteLine("6) Вес");
                            Console.WriteLine("7) Выход");
                            string choiceInputMargine = Console.ReadLine();
                            int margineChoice;
                            while (!(Int32.TryParse(choiceInputMargine, out margineChoice)) || margineChoice <= 0 || margineChoice > 7)
                            {
                                Console.WriteLine("Неверный ввод, попробуйте снова : ");
                                choiceInputMargine = Console.ReadLine();
                            }
                            switch (margineChoice)
                            {
                                case 1:
                                    Console.WriteLine("Введите новую фамилию : ");
                                    string input = Console.ReadLine();
                                    while (!Human.CheckStr(input))
                                    {
                                        Console.WriteLine("Введите данные снова");
                                        input = Console.ReadLine();
                                    }
                                    humans[index].Surname = input;
                                    break;
                                case 2:
                                    Console.WriteLine("Введите новое имя : ");
                                    input = Console.ReadLine();
                                    while (!Human.CheckStr(input))
                                    {
                                        Console.WriteLine("Введите данные снова");
                                        input = Console.ReadLine();
                                    }
                                    humans[index].Name = input;
                                    break;
                                case 3:
                                    Console.WriteLine("Введите новое отчество : ");
                                    input = Console.ReadLine();
                                    while (!Human.CheckStr(input))
                                    {
                                        Console.WriteLine("Введите данные снова");
                                        input = Console.ReadLine();
                                    }
                                    humans[index].Patronymic = input;
                                    break;
                                case 4:
                                    Console.WriteLine("Введите новый возраст : ");
                                    string inputChoice = Console.ReadLine();
                                    int ageChoice;
                                    while (!(Int32.TryParse(inputChoice, out ageChoice)))
                                    {
                                        Console.WriteLine("Неверный ввод, попробуйте снова : ");
                                        inputChoice = Console.ReadLine();
                                    }
                                    humans[index].Age = ageChoice;
                                    break;
                                case 5:
                                    Console.WriteLine("Введите новый рост : ");
                                    string inputMyChoice = Console.ReadLine();
                                    decimal heightChoice;
                                    while (!(Decimal.TryParse(inputMyChoice, out heightChoice)))
                                    {
                                        Console.WriteLine("Неверный ввод, попробуйте снова : ");
                                        inputMyChoice = Console.ReadLine();
                                    }
                                    humans[index].Height = heightChoice;
                                    break;
                                case 6:
                                    Console.WriteLine("Введите новый вес : ");
                                    string myChoice = Console.ReadLine();
                                    decimal weightChoice;
                                    while (!(Decimal.TryParse(myChoice, out weightChoice)))
                                    {
                                        Console.WriteLine("Неверный ввод, попробуйте снова : ");
                                        myChoice = Console.ReadLine();
                                    }
                                    humans[index].Height = weightChoice;
                                    break;
                                case 7:
                                    exit = false;
                                    break;
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Введите возраст : ");
                        string choiceInputAge = Console.ReadLine();
                        int choiceAge;
                        while (!(Int32.TryParse(choiceInputAge, out choiceAge)) || choiceAge <= 0)
                        {
                            Console.WriteLine("Неверный ввод, попробуйте снова : ");
                            choiceInputAge = Console.ReadLine();
                        }
                        Human.Search(humans, Human.count - 1, choiceAge);
                        break;
                    case 6:
                        Console.WriteLine("Выберите рост : ");
                        string choiceInputHeight = Console.ReadLine();
                        decimal choiceHeight;
                        while (!(Decimal.TryParse(choiceInputHeight, out choiceHeight)) || choiceHeight <= 0)
                        {
                            Console.WriteLine("Неверный ввод, попробуйте снова : ");
                            choiceInputHeight = Console.ReadLine();
                        }
                        Human.Search(humans, Human.count - 1, choiceHeight);
                        break;
                    case 7:
                        Human.SortByAge(humans, Human.count - 1);
                        break;
                    case 8:
                        Human.SortByHeight(humans, Human.count - 1);
                        break;
                    case 9:
                        check = false;
                        break;
                }
            }

        }
    }
}
